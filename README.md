# MoonTools.Core.Curve

[![NuGet Badge](https://buildstats.info/nuget/MoonTools.Core.Curve)](https://www.nuget.org/packages/MoonTools.Core.Curve/)
[![CircleCI](https://circleci.com/gh/MoonsideGames/MoonTools.Core.Curve.svg?style=svg)](https://circleci.com/gh/MoonsideGames/MoonTools.Core.Curve)

Implements quadratic and cubic Bezier curves in 2D and 3D.

## Example

```cs
    var myCurve = new CubicBezierCurve3D(
        new Vector3(-4, -4, -3),
        new Vector3(-2, 4, 0),
        new Vector3(2, -4, 3),
        new Vector3(4, 4, 0)
    );

    myCurve.Point(0.5f); // => Vector3(0, 0, 0.75f)
    myCurve.Point(3, 2, 4); // => Vector3(0, 0, 0.75f);
    myCurve.Velocity(0.5f); // => Vector3(9, 0, 4.5f)
    myCurve.Velocity(3, 2, 4); // => Vector3(9, 0, 4.5f);
```