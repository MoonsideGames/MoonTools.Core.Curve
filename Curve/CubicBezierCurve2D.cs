using System.Numerics;
using MoonTools.Core.Curve.Extensions;

namespace MoonTools.Core.Curve
{
    /// <summary>
    /// A 2-dimensional Bezier curve defined by 4 points.
    /// </summary>
    public struct CubicBezierCurve2D
    {
        /// <summary>
        /// The start point.
        /// </summary>
        public Vector2 p0;

        /// <summary>
        /// The first control point.
        /// </summary>
        public Vector2 p1;

        /// <summary>
        /// The second control point.
        /// </summary>
        public Vector2 p2;

        /// <summary>
        /// The end point.
        /// </summary>
        public Vector2 p3;

        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        public CubicBezierCurve2D(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
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
        public Vector2 Point(float t) => Point(p0, p1, p2, p3, t);

        /// <summary>
        /// Returns the curve coordinate given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Point(float t, float startTime, float endTime) => Point(p0, p1, p2, p3, t, startTime, endTime);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector2 Velocity(float t) => Velocity(p0, p1, p2, p3, t);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Velocity(float t, float startTime, float endTime) => Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, startTime, endTime));

        /// <summary>
        /// Returns the curve coordinate given by 4 points and a time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="t">A value between 0 and 1.</param>
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
        public static Vector2 Point(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t, float startTime, float endTime)
        {
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
        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t, float minT, float maxT)
        {
            return Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, minT, maxT));
        }
    }
}