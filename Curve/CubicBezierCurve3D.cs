using Microsoft.Xna.Framework;

namespace MoonTools.Core.Curve
{
    public struct CubicBezierCurve3D
    {
        public Vector3 p0;
        public Vector3 p1;
        public Vector3 p2;
        public Vector3 p3;

        public CubicBezierCurve3D(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Vector3 Point(float t) => Point(p0, p1, p2, p3, t);

        public Vector3 Point(float t, float minT, float maxT) => Point(p0, p1, p2, p3, t, minT, maxT);

        public Vector3 Velocity(float t) => FirstDerivative(p0, p1, p2, p3, t);

        public Vector3 Velocity(float t, float minT, float maxT) => FirstDerivative(p0, p1, p2, p3, t, minT, maxT);

        public static Vector3 Point(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            if (t < 0 || t > 1) { throw new System.ArgumentException($"{t} is an invalid value. Must be between 0 and 1"); }

            return (1f - t) * (1f - t) * (1f - t) * p0 +
                    3f * (1f - t) * (1f - t) * t * p1 +
                    3f * (1f - t) * t * t * p2 +
                    t * t * t * p3;
        }

        public static Vector3 Point(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t, float minT, float maxT)
        {
            return Point(p0, p1, p2, p3, Normalized(t, minT, maxT));
        }

        public static Vector3 FirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            if (t < 0 || t > 1) { throw new System.ArgumentException($"{t} is an invalid value. Must be between 0 and 1"); }

            return 3f * (1f - t) * (1f - t) * (p1 - p0) +
                    6f * (1f - t) * t * (p2 - p1) +
                    3f * t * t * (p3 - p2);
        }

        public static Vector3 FirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t, float minT, float maxT)
        {
            return FirstDerivative(p0, p1, p2, p3, Normalized(t, minT, maxT));
        }

        private static float Normalized(float t, float minT, float maxT) => ((t - minT)) / (maxT - minT);
    }
}