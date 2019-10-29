using System.Numerics;
using MoonTools.Core.Curve.Extensions;

namespace MoonTools.Core.Curve
{
    public struct CubicBezierCurve2D
    {
        public Vector2 p0;
        public Vector2 p1;
        public Vector2 p2;
        public Vector2 p3;

        public CubicBezierCurve2D(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Vector2 Point(float t) => Point(p0, p1, p2, p3, t);
        public Vector2 Point(float t, float minT, float maxT) => Point(p0, p1, p2, p3, t, minT, maxT);
        public Vector2 Velocity(float t) => Velocity(p0, p1, p2, p3, t);
        public Vector2 Velocity(float t, float minT, float maxT) => Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, minT, maxT));
        public static Vector2 Point(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            return CubicBezierCurve3D.Point(
                new Vector3(p0.X, p0.Y, 0),
                new Vector3(p1.X, p1.Y, 0),
                new Vector3(p2.X, p2.Y, 0),
                new Vector3(p3.X, p3.Y, 0),
                t
            ).XY();
        }

        public static Vector2 Point(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t, float minT, float maxT)
        {
            return Point(p0, p1, p2, p3, TimeHelper.Normalized(t, minT, maxT));
        }

        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            return CubicBezierCurve3D.Velocity(
                new Vector3(p0.X, p0.Y, 0),
                new Vector3(p1.X, p1.Y, 0),
                new Vector3(p2.X, p2.Y, 0),
                new Vector3(p3.X, p3.Y, 0),
                t
            ).XY();
        }

        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t, float minT, float maxT)
        {
            return Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, minT, maxT));
        }
    }
}