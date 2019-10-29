using System.Numerics;

namespace MoonTools.Core.Curve.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 XY(this Vector3 vector) => new Vector2(vector.X, vector.Y);
    }
}