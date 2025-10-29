using System.Numerics;

namespace GameEngine.Source
{
    public abstract class GameObject
    {
        private static readonly string CLASS_NAME = "GameObject";
        abstract public Vector2 Position { get; set; }
        abstract public Vector2 Origin { get; set; }
        abstract public Vector2 Scale { get; set; }
        abstract public string Tag { get; set; }
        abstract public List<GameObject> Children { get; set; }

        

        public GameObject()
        {
            Children = new List<GameObject>();
            Position = new Vector2();
            Origin = Position;
            Scale = new Vector2();
            Tag = "EmptyGameObject";
            Engine.RegisterGameObject(this);
        }

        public GameObject(Vector2 position, Vector2 scale, string tag)
        {
            Children = [];
            Position = position;
            Origin = position;
            Scale = scale;
            Tag = tag;
            Engine.RegisterGameObject(this);
        }

        public virtual void AddChild(GameObject child)
        {
            Children.Add(child);
        }

        public virtual void DestroyChild(GameObject child)
        {
            Children.Remove(child);
            child.DestroySelf();
        }

        public virtual void DestroySelf()
        {
            Engine.UnRegisterGameObject(this);

            if (Children == null) { return; }
            foreach (GameObject child in Children)
            {
                child.DestroySelf();
            }
        }

        public virtual void UpdateChildren()
        {
            foreach (GameObject child in Children)
            {
                child.Position = Position + child.Origin;
            }
        }
        
        public virtual GameObject? GetChild(string childTag)
        {
            foreach (GameObject child in Children)
            {
                if (childTag.Equals(child.Tag))
                {
                    return child;
                }
            }

            Log.Error(CLASS_NAME, $"GameObject {childTag} does not exist!");
            return null;
        }

        abstract public void OnLoad();
        abstract public void OnUpdate();
        abstract public void OnDestroy();
    }
}