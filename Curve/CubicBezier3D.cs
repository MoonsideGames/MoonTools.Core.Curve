using Microsoft.Xna.Framework;

namespace MoonTools.Core.Curve
{
    public static class CubicBezier3D
    {
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
            return Point(p0, p1, p2, p3, NormalizedT(t, minT, maxT));
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
            return FirstDerivative(p0, p1, p2, p3, NormalizedT(t, minT, maxT));
        }

        private static float NormalizedT(float t, float minT, float maxT)
        {
            return ((t - minT)) / (maxT - minT);
        }
    }
}
