namespace MoonTools.Core.Curve
{
    public static class TimeHelper
    {
        public static float Normalized(float t, float minT, float maxT) => (t - minT) / (maxT - minT);
    }
}