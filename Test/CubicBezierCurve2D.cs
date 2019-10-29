using NUnit.Framework;
using FluentAssertions;

using MoonTools.Core.Curve;
using Microsoft.Xna.Framework;
using System;

namespace Tests
{
    public class CubicBezierCurve2DTests
    {
        [Test]
        public void Point()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(-2, 4);
            var p2 = new Vector2(2, -4);
            var p3 = new Vector2(4, 4);

            CubicBezierCurve2D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector2(0, 0));
            CubicBezierCurve2D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector2(0, 0));
            CubicBezierCurve2D.Point(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector2(-2.1875f, -0.5f));
            CubicBezierCurve2D.Point(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector2(2.1875f, 0.5f));

            Action invalidTime = () => CubicBezierCurve2D.Point(p0, p1, p2, p3, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(-2, 4);
            var p2 = new Vector2(2, -4);
            var p3 = new Vector2(4, 4);

            CubicBezierCurve2D.Point(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector2(0, 0));
            CubicBezierCurve2D.Point(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector2(-2.1875f, -0.5f));
            CubicBezierCurve2D.Point(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector2(2.1875f, 0.5f));

            Action invalidTime = () => CubicBezierCurve2D.Point(p0, p1, p2, p3, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(-2, 4);
            var p2 = new Vector2(2, -4);
            var p3 = new Vector2(4, 4);

            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector2(9, 0));
            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector2(8.25f, 6f));
            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector2(8.25f, 6f));

            Action invalidTime = () => CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(-2, 4);
            var p2 = new Vector2(2, -4);
            var p3 = new Vector2(4, 4);

            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector2(9, 0));
            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector2(8.25f, 6f));
            CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector2(8.25f, 6f));

            Action invalidTime = () => CubicBezierCurve2D.Velocity(p0, p1, p2, p3, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }
    }

    public class CubicBezierCurve2DStructTests
    {
        [Test]
        public void Point()
        {
            var myCurve = new CubicBezierCurve2D(
                new Vector2(-4, -4),
                new Vector2(-2, 4),
                new Vector2(2, -4),
                new Vector2(4, 4)
            );

            myCurve.Point(0.5f).Should().BeEquivalentTo(new Vector2(0, 0));
            myCurve.Point(0.25f).Should().BeEquivalentTo(new Vector2(-2.1875f, -0.5f));
            myCurve.Point(0.75f).Should().BeEquivalentTo(new Vector2(2.1875f, 0.5f));

            myCurve.Invoking(x => x.Point(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var myCurve = new CubicBezierCurve2D(
                new Vector2(-4, -4),
                new Vector2(-2, 4),
                new Vector2(2, -4),
                new Vector2(4, 4)
            );

            myCurve.Point(3, 2, 4).Should().BeEquivalentTo(new Vector2(0, 0));
            myCurve.Point(2, 1, 5).Should().BeEquivalentTo(new Vector2(-2.1875f, -0.5f));
            myCurve.Point(11, 2, 14).Should().BeEquivalentTo(new Vector2(2.1875f, 0.5f));

            myCurve.Invoking(x => x.Point(15, 2, 4)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var myCurve = new CubicBezierCurve2D(
                new Vector2(-4, -4),
                new Vector2(-2, 4),
                new Vector2(2, -4),
                new Vector2(4, 4)
            );

            myCurve.Velocity(0.5f).Should().BeEquivalentTo(new Vector2(9, 0));
            myCurve.Velocity(0.25f).Should().BeEquivalentTo(new Vector2(8.25f, 6f));
            myCurve.Velocity(0.75f).Should().BeEquivalentTo(new Vector2(8.25f, 6f));

            myCurve.Invoking(x => x.Velocity(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var myCurve = new CubicBezierCurve2D(
                new Vector2(-4, -4),
                new Vector2(-2, 4),
                new Vector2(2, -4),
                new Vector2(4, 4)
            );

            myCurve.Velocity(3, 2, 4).Should().BeEquivalentTo(new Vector2(9, 0));
            myCurve.Velocity(2, 1, 5).Should().BeEquivalentTo(new Vector2(8.25f, 6f));
            myCurve.Velocity(11, 2, 14).Should().BeEquivalentTo(new Vector2(8.25f, 6f));

            myCurve.Invoking(x => x.Velocity(15, 2, 5)).Should().Throw<ArgumentException>();
        }
    }
}