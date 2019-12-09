using MoonTools.Core.Curve.Extensions;
using System;
using System.Numerics;

namespace MoonTools.Core.Curve
{
    /// <summary>
    /// A 2-dimensional Bezier curve defined by 3 points.
    /// </summary>
    public struct QuadraticBezierCurve2D : IEquatable<QuadraticBezierCurve2D>
    {
        /// <summary>
        /// The start point.
        /// </summary>
        public Vector2 P0 { get; }

        /// <summary>
        /// The control point.
        /// </summary>
        public Vector2 P1 { get; }

        /// <summary>
        /// The end point.
        /// </summary>
        public Vector2 P2 { get; }

        /// <summary>
        /// A representation of a 2D quadratic Bezier curve.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The control point.</param>
        /// <param name="p2">The end point.</param>
        public QuadraticBezierCurve2D(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
        }

        /// <summary>
        /// Returns the curve coordinate given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector2 Point(float t) => Point(P0, P1, P2, t);

        /// <summary>
        /// Returns the curve coordinate given by a normalized time value.
        /// </summary>
        /// <param name="t">A time value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Point(float t, float startTime, float endTime) => Point(P0, P1, P2, t, startTime, endTime);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by t.
        /// </summary>
        /// <param name="t">A value between 0 and 1.</param>
        public Vector2 Velocity(float t) => Velocity(P0, P1, P2, t);

        /// <summary>
        /// Returns the instantaneous velocity on the curve given by a normalized time value.
        /// </summary>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public Vector2 Velocity(float t, float startTime, float endTime) => Velocity(P0, P1, P2, t, startTime, endTime);

        /// <summary>
        /// Performs degree elevation on the curve to turn it into a Cubic Bezier curve.
        /// </summary>
        public CubicBezierCurve2D AsCubic()
        {
            var (p0, p1, p2, p3) = AsCubic(this.P0, this.P1, this.P2);
            return new CubicBezierCurve2D(p0, p1, p2, p3);
        }

        /// <summary>
        /// Given quadratic control points, returns cubic control points.
        /// </summary>
        public static (Vector2, Vector2, Vector2, Vector2) AsCubic(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            var cubicP0 = p0;
            var cubicP1 = (2f / 3f * p1) + ((1f / 3f) * p0);
            var cubicP2 = (2f / 3f * p1) + ((1f / 3f) * p2);
            var cubicP3 = p2;

            return (cubicP0, cubicP1, cubicP2, cubicP3);
        }

        /// <summary>
        /// Returns the curve coordinate given by 3 points and a time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The control point.</param>
        /// <param name="p2">The end point.</param>
        /// <param name="t">A value between 0 and 1.</param>
        public static Vector2 Point(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            return QuadraticBezierCurve3D.Point(
                new Vector3(p0.X, p0.Y, 0),
                new Vector3(p1.X, p1.Y, 0),
                new Vector3(p2.X, p2.Y, 0),
                t
            ).XY();
        }

        /// <summary>
        /// Returns the curve coordinate given by 3 points and a normalized time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The control point.</param>
        /// <param name="p2">The end point.</param>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public static Vector2 Point(Vector2 p0, Vector2 p1, Vector2 p2, float t, float startTime, float endTime)
        {
            return Point(p0, p1, p2, TimeHelper.Normalized(t, startTime, endTime));
        }

        /// <summary>
        /// Returns the instantaneous velocity given by 3 points and a normalized time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The control point.</param>
        /// <param name="p2">The end point.</param>
        /// <param name="t">A value between 0 and 1.</param>
        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            return QuadraticBezierCurve3D.Velocity(
                new Vector3(p0.X, p0.Y, 0),
                new Vector3(p1.X, p1.Y, 0),
                new Vector3(p2.X, p2.Y, 0),
                t
            ).XY();
        }

        /// <summary>
        /// Returns the instantaneous velocity given by 3 points and a normalized time value.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The control point.</param>
        /// <param name="p2">The end point.</param>
        /// <param name="t">A value between startTime and endTime.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public static Vector2 Velocity(Vector2 p0, Vector2 p1, Vector2 p2, float t, float startTime, float endTime)
        {
            return Velocity(p0, p1, p2, TimeHelper.Normalized(t, startTime, endTime));
        }

        public override bool Equals(object obj)
        {
            return obj is QuadraticBezierCurve2D d && Equals(d);
        }

        public bool Equals(QuadraticBezierCurve2D other)
        {
            return P0.Equals(other.P0) &&
                   P1.Equals(other.P1) &&
                   P2.Equals(other.P2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(P0, P1, P2);
        }

        public static bool operator ==(QuadraticBezierCurve2D left, QuadraticBezierCurve2D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuadraticBezierCurve2D left, QuadraticBezierCurve2D right)
        {
            return !(left == right);
        }
    }
}