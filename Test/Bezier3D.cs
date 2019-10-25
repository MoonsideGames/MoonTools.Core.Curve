using NUnit.Framework;
using FluentAssertions;

using MoonTools.Core.Curve;
using Microsoft.Xna.Framework;

namespace Tests.TestExtensions
{
    static class TestExtensions
    {
        public static bool ApproximatelyEquals(this Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).Length() <= 0.001f;
        }
    }
}

namespace Tests
{
    using TestExtensions;

    public class Bezier3DTests
    {
        [Test]
        public void Point()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezier3D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezier3D.Point(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezier3D.Point(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            CubicBezier3D.Point(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
        }

        [Test]
        public void PointNormalized()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezier3D.Point(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector3(0, 0, 0.75f));
            CubicBezier3D.Point(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector3(-2.1875f, -0.5f, -0.84375f));
            CubicBezier3D.Point(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector3(2.1875f, 0.5f, 1.21875f));
        }

        [Test]
        public void FirstDerivative()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 0.5f).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 0.25f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 0.75f).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));
        }

        [Test]
        public void FirstDerivativeNormalized()
        {
            var p0 = new Vector3(-4, -4, -3);
            var p1 = new Vector3(-2, 4, 0);
            var p2 = new Vector3(2, -4, 3);
            var p3 = new Vector3(4, 4, 0);

            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 3, 2, 4).Should().BeEquivalentTo(new Vector3(9, 0, 4.5f));
            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 2, 1, 5).Should().BeEquivalentTo(new Vector3(8.25f, 6f, 7.875f));
            CubicBezier3D.FirstDerivative(p0, p1, p2, p3, 11, 2, 14).Should().BeEquivalentTo(new Vector3(8.25f, 6f, -1.125f));
        }
    }
}