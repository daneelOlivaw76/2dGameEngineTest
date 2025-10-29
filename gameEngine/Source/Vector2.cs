namespace GameEngine.Source
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2()
        {
            this.x = Zero().x;
            this.y = Zero().y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        public Vector2 Normalize()
        {
            if (this.x == 0 && this.y == 0) return this;

            float number = (float)Math.Sqrt(x * x + y * y);
            float number1 = 1f / number;

            return new Vector2(x * number1, y * number1);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static implicit operator SFML.System.Vector2f(Vector2 v)
        {
            return new SFML.System.Vector2f(v.x, v.y);
        }
    }
}