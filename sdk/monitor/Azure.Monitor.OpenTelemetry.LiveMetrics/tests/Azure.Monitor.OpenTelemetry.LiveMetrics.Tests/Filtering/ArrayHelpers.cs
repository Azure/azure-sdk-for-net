namespace Microsoft.ApplicationInsights.Tests
{
    using System;

    internal static class ArrayHelpers
    {
        public static void ForEach<T>(T[] array, Action<T> action)
        {
            foreach (T item in array)
            {
                action(item);
            }
        }
    }
}
