using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine
{
    internal class Engine
    {
        // Height and Width
        public uint height = 500;
        public uint width = 500;

        //window title
        public string title = "Zenva Engine 0.0.1";

        // window color
        public Color windowColor = Color.Black;

        // window renderer
        public static RenderWindow app;

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
            throw new NotImplementedException();
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        void GameLoop()
        {
            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);
                app.Display();
            }
        }
    }
}