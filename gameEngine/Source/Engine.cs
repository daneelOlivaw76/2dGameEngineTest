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
        // Height and Width
        public uint height = 500;
        public uint width = 500;

        //window title
        public string title = "Zenva Engine 0.0.1";

        // window color
        public Color windowColor = Color.Black;

        // window renderer
        public static RenderWindow? app;

        // GameObjects
        public static List<GameObject> GameObjects = [];
        public static List<GameObject> GameObjectsToAdd = [];
        public static List<GameObject> GameObjectsToRemove = [];

        private static readonly string CLASS_NAME = "GameEngine";

        public Engine(uint WIDTH, uint HEIGHT, string TITLE, Color WINDOWCOLOR)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = WINDOWCOLOR;

            app = new RenderWindow(new VideoMode(width, height), title, style: Styles.Resize | Styles.Close);
            app.KeyPressed += App_KeyPressed;
            app.KeyReleased += App_KeyReleased;
            app.Closed += App_Closed;
            app.Resized += App_Resized;
            app.SetFramerateLimit(100);

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
                Log.Error(CLASS_NAME, "Window Object is null!");
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
                Log.Error(CLASS_NAME, "Window Object is null!");
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

        private static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }

        private static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Add(gameObject);
        }

        void GameLoop()
        {
            LoadObjects();
            
            OnLoad();

            if (app != null)
            {
                while (app.IsOpen)
                {
                    app.DispatchEvents();
                    app.Clear(windowColor);

                    UpdateObjects();
                    OnUpdate();

                    app.Display();
                }
            }
        }

        private static void UpdateObjects()
        {
            foreach(GameObject gameObject in GameObjectsToRemove)
            {
                GameObjects.Remove(gameObject);
            }
        }

        private static void LoadObjects()
        {
            if (GameObjects != null)
            {
                return;
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (GameObjects.Count > 0)
            {
                for ( int i = 0; i < GameObjects.Count; i++)
                {
                    GameObjects[i].OnUpdate();
                    GameObjects[i].UpdateChildren();
                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (GameObjectsToAdd != null && GameObjectsToAdd.Count > 0)
            {
                for (int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }

                GameObjectsToAdd.Clear();
            }

            if(GameObjectsToRemove != null && GameObjectsToRemove.Count > 0)
            {
                for (int i = 0; i > GameObjectsToRemove.Count; i++)
                {
                    GameObjectsToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }

                GameObjectsToRemove.Clear();
            }
        }

        public abstract void OnLoad();

        public virtual void OnUpdate()
        {
            RectangleShape shape = new RectangleShape(new Vector2f(50, 50));
            shape.FillColor = Color.White;
            shape.Position = new Vector2(400, 400);
            app?.Draw(shape);

            if (Input.ActionJustPressed("Down"))
            {
                Log.Info(CLASS_NAME, "Key just pressed");
            }

            if (Input.ActionPressed("Up"))
            {
                Log.Info(CLASS_NAME, "Key Pressed");
            }
        }
    }
}