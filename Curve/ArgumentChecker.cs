namespace MoonTools.Core.Curve
{
    public static class ArgumentChecker
    {
        public static void CheckT(float t, float startTime = 0, float endTime = 1)
        {
            if (t < startTime || t > endTime)
            {
                throw new System.ArgumentException($"{t} is not a valid value for t. Must be between {startTime} and {endTime}.");
            }
        }
    }
}