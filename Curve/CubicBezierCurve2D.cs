using System;
using System.Numerics;
using MoonTools.Core.Curve.Extensions;

namespace MoonTools.Core.Curve
{
    /// <summary>
    /// A 2-dimensional Bezier curve defined by 4 points.
    /// </summary>
    public struct CubicBezierCurve2D : IEquatable<CubicBezierCurve2D>
    {
        /// <summary>
        /// The start point.
        /// </summary>
        public Vector2 P0 { get; }

        /// <summary>
        /// The first control point.
        /// </summary>
        public Vector2 P1 { get; }

        /// <summary>
        /// The second control point.
        /// </summary>
        public Vector2 P2 { get; }

        /// <summary>
        /// The end point.
        /// </summary>
        public Vector2 P3 { get; }

        /// <summary>
        /// A representation of a 2D cubic Bezier curve.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        public CubicBezierCurve2D(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        /// <summary>
        /// Returns the curve coordinate given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector2 Point(float t) => Point(P0, P1, P2, P3, t);

        /// <summary>
        /// Returns the curve coordinate given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Point(float t, float startTime, float endTime) => Point(P0, P1, P2, P3, t, startTime, endTime);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector2 Velocity(float t) => Velocity(P0, P1, P2, P3, t);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Velocity(float t, float startTime, float endTime) => Velocity(P0, P1, P2, P3, TimeHelper.Normalized(t, startTime, endTime));

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
        /// <param name="t">A value between minT and maxT.</param>
        /// <param name="minT">The starting time value.</param>
        /// <param name="maxT">The ending time value.</param>
        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t, float minT, float maxT)
        {
            return Velocity(p0, p1, p2, p3, TimeHelper.Normalized(t, minT, maxT));
        }

        public override bool Equals(object obj)
        {
            return obj is CubicBezierCurve2D d && Equals(d);
        }

        public bool Equals(CubicBezierCurve2D other)
        {
            return P0.Equals(other.P0) &&
                   P1.Equals(other.P1) &&
                   P2.Equals(other.P2) &&
                   P3.Equals(other.P3);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(P0, P1, P2, P3);
        }

        public static bool operator ==(CubicBezierCurve2D left, CubicBezierCurve2D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CubicBezierCurve2D left, CubicBezierCurve2D right)
        {
            return !(left == right);
        }
    }
}