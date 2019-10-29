using System.Numerics;

namespace MoonTools.Core.Curve
{
    /// <summary>
    /// A 3-dimensional Bezier curve defined by 4 points.
    /// </summary>
    public struct CubicBezierCurve3D
    {
        /// <summary>
        /// The start point.
        /// </summary>
        public Vector3 p0;

        /// <summary>
        /// The first control point.
        /// </summary>
        public Vector3 p1;

        /// <summary>
        /// The second control point.
        /// </summary>
        public Vector3 p2;

        /// <summary>
        /// The end point.
        /// </summary>
        public Vector3 p3;

        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        public CubicBezierCurve3D(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        /// <summary>
        /// Returns the curve coordinate given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector3 Point(float t) => Point(p0, p1, p2, p3, t);

        /// <summary>
        /// Returns the curve coordinate given by a normalized time value.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector3 Point(float t, float startTime, float endTime) => Point(p0, p1, p2, p3, t, startTime, endTime);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector3 Velocity(float t) => Velocity(p0, p1, p2, p3, t);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector3 Velocity(float t, float startTime, float endTime) => Velocity(p0, p1, p2, p3, t, startTime, endTime);

        /// <summary>
        /// Returns the curve coordinate given by 4 points and a time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="t">A value between 0 and 1.</param>
        public static Vector3 Point(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            ArgumentChecker.CheckT(t);

            return (1f - t) * (1f - t) * (1f - t) * p0 +
                    3f * (1f - t) * (1f - t) * t * p1 +
                    3f * (1f - t) * t * t * p2 +
                    t * t * t * p3;
        }

        /// <summary>
        /// Returns the curve coordinate given by 4 points and a normalized time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public static Vector3 Point(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t, float startTime, float endTime)
        {
            ArgumentChecker.CheckT(t, startTime, endTime);
            return Point(p0, p1, p2, p3, TimeHelper.Normalized(t, startTime, endTime));
        }

        /// <summary>
        /// Returns the instantaneous velocity given by 4 points and a time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="t">A value between 0 and 1.</param>
        public static Vector3 Velocity(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            ArgumentChecker.CheckT(t);

            return 3f * (1f - t) * (1f - t) * (p1 - p0) +
                    6f * (1f - t) * t * (p2 - p1) +
                    3f * t * t * (p3 - p2);
        }

        /// <summary>
        /// Returns the instantaneous velocity given by 4 points and a normalized time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static Vector3 Velocity(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t, float startTime, float endTime)
        {
            ArgumentChecker.CheckT(t, startTime, endTime);
            return Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, startTime, endTime));
        }
    }
}