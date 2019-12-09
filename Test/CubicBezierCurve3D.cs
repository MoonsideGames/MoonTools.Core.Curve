using NUnit.Framework;
using FluentAssertions;

using MoonTools.Core.Curve;
using System;
using System.Numerics;

namespace Tests
{
    public class CubicBezierCurve3DMathTests
    {
        [Test]
        public void Point()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezierCurve3D.Point(p0, p1, p2, p3, 0f).Should().BeEquivalentTo(p0);
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 1f).Should().BeEquivalentTo(p3);

            Action invalidTime = () => CubicBezierCurve3D.Point(p0, p1, p2, p3, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezierCurve3D.Point(p0, p1, p2, p3, 15, 15, 17).Should().BeEquivalentTo(p0);
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
            CubicBezierCurve3D.Point(p0, p1, p2, p3, 1, -8, 1).Should().BeEquivalentTo(p3);

            Action invalidTime = () => CubicBezierCurve3D.Point(p0, p1, p2, p3, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));

            Action invalidTime = () => CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 1.5f);
            invalidTime.Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));

            Action invalidTime = () => CubicBezierCurve3D.Velocity(p0, p1, p2, p3, 15, 2, 5);
            invalidTime.Should().Throw<ArgumentException>();
        }
    }

    public class CubicBezierCurve3DStructTests
    {
        [Test]
        public void Point()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            myCurve.Point(0f).Should().BeEquivalentTo(myCurve.P0);
            myCurve.Point(0.5f).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            myCurve.Point(0.25f).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            myCurve.Point(0.75f).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
            myCurve.Point(1f).Should().BeEquivalentTo(myCurve.P3);

            myCurve.Invoking(x => x.Point(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void PointNormalized()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            myCurve.Point(15, 15, 17).Should().BeEquivalentTo(myCurve.P0);
            myCurve.Point(3, 2, 4).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            myCurve.Point(2, 1, 5).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            myCurve.Point(11, 2, 14).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
            myCurve.Point(1, -8, 1).Should().BeEquivalentTo(myCurve.P3);

            myCurve.Invoking(x => x.Point(15, 2, 5)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Velocity()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            myCurve.Velocity(0.5f).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            myCurve.Velocity(0.25f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            myCurve.Velocity(0.75f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));

            myCurve.Invoking(x => x.Velocity(1.5f)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void VelocityNormalized()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            myCurve.Velocity(3, 2, 4).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            myCurve.Velocity(2, 1, 5).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            myCurve.Velocity(11, 2, 14).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));

            myCurve.Invoking(x => x.Velocity(15, 2, 5)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Equals()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            var otherCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            (myCurve == otherCurve).Should().BeTrue();
        }

        [Test]
        public void NotEquals()
        {
            var myCurve = new CubicBezierCurve3D(
                new Vector3(-1, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            var otherCurve = new CubicBezierCurve3D(
                new Vector3(-4, -4, -3),
                new Vector3(-2, 4, 0),
                new Vector3(2, -4, 3),
                new Vector3(4, 4, 0)
            );

            (myCurve != otherCurve).Should().BeTrue();
        }
    }
}