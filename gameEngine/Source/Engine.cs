using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Source;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameEngine.Source
{
    abstract class Engine
    {
        private const string ClassName = "Engine";
        // Height and Width
        private uint height = 500;
        public uint width = 500;

        //window title
        private string title = "Zenva Engine 0.0.1";

        // window color
        private Color windowColor = Color.Black;

        // window renderer
        private static RenderWindow? App;

        // GameObjects
        private static List<GameObject> GameObjects = [];
        private static List<GameObject> GameObjectsToAdd = [];
        private static List<GameObject> GameObjectsToRemove = [];

        protected Engine(uint WIDTH, uint HEIGHT, string TITLE, Color WINDOWCOLOR)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = WINDOWCOLOR;

            App = new RenderWindow(new VideoMode(width, height), title, style: Styles.Resize | Styles.Close);
            App.KeyPressed += App_KeyPressed;
            App.KeyReleased += App_KeyReleased;
            App.Closed += App_Closed;
            App.Resized += App_Resized;
            App.SetFramerateLimit(100);

            GameLoop();
        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow? window = (RenderWindow?)sender;
            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            if (window != null)
            {
                window?.SetView(new View(visibleArea));
            } else
            {
                Log.Error(ClassName, "Window Object is null!");
            }
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            RenderWindow? window = (RenderWindow?)sender;
            if (window != null)
            {
                window?.Close();
            } else
            {
                Log.Error(ClassName, "Window Object is null!");
            }            
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }

        public static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Add(gameObject);
        }

        void GameLoop()
        {
            LoadObjects();
            
            OnLoad();

            if (App != null)
            {
                while (App.IsOpen)
                {
                    App.DispatchEvents();
                    App.Clear(windowColor);

                    UpdateObjects();
                    OnUpdate();

                    App.Display();
                }
            }
        }

        private void UpdateObjects()
        {
            for ( int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }
            

            if (GameObjectsToAdd.Count > 0)
            {
                for (int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }

                GameObjectsToAdd.Clear();
            }

            if(GameObjectsToRemove.Count > 0)
            {
                for (int i = 0; i > GameObjectsToRemove.Count; i++)
                {
                    GameObjectsToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }

                GameObjectsToRemove.Clear();
            }
        }
        
        private void LoadObjects()
        {
            foreach(GameObject gameObject in GameObjects)
            {
                gameObject.OnLoad();
            }
        }

        public abstract void OnLoad();

        public virtual void OnUpdate()
        {
            RectangleShape shape = new RectangleShape(new Vector2f(50, 50));
            shape.FillColor = Color.White;
            shape.Position = new Vector2(400, 400);
            App?.Draw(shape);

            // if (Input.ActionJustPressed("Right"))
            // {
            //     Log.Info(CLASS_NAME, "Key just pressed");
            // }

            // if (Input.ActionPressed("Left"))
            // {
            //     Log.Info(CLASS_NAME, "Key Pressed");
            // }
        }
    }
}