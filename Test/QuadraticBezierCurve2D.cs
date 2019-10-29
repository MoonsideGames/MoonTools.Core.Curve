using NUnit.Framework;
using FluentAssertions;

using MoonTools.Core.Curve;
using System;
using System.Numerics;

namespace Tests
{
    public class QuadraticBezierCurve2DMathTests
    {
        [Test]
        public void Point()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            QuadraticBezierCurve2D.Point(p0, p1, p2, 0).Should().BeEquivalentTo(p0);
            QuadraticBezierCurve2D.Point(p0, p1, p2, 0.25f).Should().BeEquivalentTo(new Vector2(-1.25f, -3.5f));
            QuadraticBezierCurve2D.Point(p0, p1, p2, 0.75f).Should().BeEquivalentTo(new Vector2(2.75f, 0.5f));
            QuadraticBezierCurve2D.Point(p0, p1, p2, 1).Should().BeEquivalentTo(p2);

            Action invalidTime = () => QuadraticBezierCurve2D.Point(p0, p1, p2, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            QuadraticBezierCurve2D.Point(p0, p1, p2, 15, 15, 17).Should().BeEquivalentTo(p0);
            QuadraticBezierCurve2D.Point(p0, p1, p2, 2, 1, 5).Should().BeEquivalentTo(new Vector2(-1.25f, -3.5f));
            QuadraticBezierCurve2D.Point(p0, p1, p2, 8, 2, 10).Should().BeEquivalentTo(new Vector2(2.75f, 0.5f));
            QuadraticBezierCurve2D.Point(p0, p1, p2, 1, -8, 1).Should().BeEquivalentTo(p2);

            Action invalidTime = () => QuadraticBezierCurve2D.Point(p0, p1, p2, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            QuadraticBezierCurve2D.Velocity(p0, p1, p2, 0.25f).Should().BeEquivalentTo(new Vector2(10f, 3.9999998f));
            QuadraticBezierCurve2D.Velocity(p0, p1, p2, 0.75f).Should().BeEquivalentTo(new Vector2(6, 12));

            Action invalidTime = () => QuadraticBezierCurve2D.Velocity(p0, p1, p2, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            QuadraticBezierCurve2D.Velocity(p0, p1, p2, 2, 1, 5).Should().BeEquivalentTo(new Vector2(10f, 3.9999998f));
            QuadraticBezierCurve2D.Velocity(p0, p1, p2, 8, 2, 10).Should().BeEquivalentTo(new Vector2(6, 12f));

            Action invalidTime = () => QuadraticBezierCurve2D.Velocity(p0, p1, p1, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }
    }

    public class QuadraticBezierCurve2DStructTests
    {
        [Test]
        public void Point()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            var myCurve = new QuadraticBezierCurve2D(p0, p1, p2);

            myCurve.Point(0).Should().BeEquivalentTo(p0);
            myCurve.Point(0.25f).Should().BeEquivalentTo(new Vector2(-1.25f, -3.5f));
            myCurve.Point(0.75f).Should().BeEquivalentTo(new Vector2(2.75f, 0.5f));
            myCurve.Point(1).Should().BeEquivalentTo(p2);

            myCurve.Invoking(x => x.Point(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            var myCurve = new QuadraticBezierCurve2D(p0, p1, p2);

            myCurve.Point(15, 15, 17).Should().BeEquivalentTo(p0);
            myCurve.Point(2, 1, 5).Should().BeEquivalentTo(new Vector2(-1.25f, -3.5f));
            myCurve.Point(8, 2, 10).Should().BeEquivalentTo(new Vector2(2.75f, 0.5f));
            myCurve.Point(1, -8, 1).Should().BeEquivalentTo(p2);

            myCurve.Invoking(x => x.Point(15, 2, 5)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            var myCurve = new QuadraticBezierCurve2D(p0, p1, p2);

            myCurve.Velocity(0.25f).Should().BeEquivalentTo(new Vector2(10f, 3.9999998f));
            myCurve.Velocity(0.75f).Should().BeEquivalentTo(new Vector2(6, 12));

            myCurve.Invoking(x => x.Velocity(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            var myCurve = new QuadraticBezierCurve2D(p0, p1, p2);

            myCurve.Velocity(2, 1, 5).Should().BeEquivalentTo(new Vector2(10f, 3.9999998f));
            myCurve.Velocity(8, 2, 10).Should().BeEquivalentTo(new Vector2(6, 12));

            myCurve.Invoking(x => x.Velocity(15, 2, 5)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void AsCubic()
        {
            var p0 = new Vector2(-4, -4);
            var p1 = new Vector2(2, -4);
            var p2 = new Vector2(4, 4);

            var myCurve = new QuadraticBezierCurve2D(p0, p1, p2);
            var myCubicCurve = myCurve.AsCubic();

            myCurve.Point(0f).Should().BeEquivalentTo(myCubicCurve.Point(0f));
            myCurve.Point(0.25f).Should().BeEquivalentTo(myCubicCurve.Point(0.25f));
            myCurve.Point(0.75f).Should().BeEquivalentTo(myCubicCurve.Point(0.75f));
            myCurve.Point(1f).Should().BeEquivalentTo(myCubicCurve.Point(1f));
        }
    }
}