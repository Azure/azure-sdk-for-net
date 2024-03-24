// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

internal class Argument
{
    #region Argument validation
    public static void AssertNotNull<T>(T value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void AssertNotNullOrEmpty(string value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }

        if (value.Length == 0)
        {
            throw new ArgumentException("Value cannot be an empty string.", name);
        }
    }

    /// <summary>
    /// Throws if <paramref name="value"/> is less than the <paramref name="minimum"/> or greater than the <paramref name="maximum"/>.
    /// </summary>
    /// <typeparam name="T">The type of to validate which implements <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="minimum">The minimum value to compare.</param>
    /// <param name="maximum">The maximum value to compare.</param>
    /// <param name="name">The name of the parameter.</param>
    public static void AssertInRange<T>(T value, T minimum, T maximum, string name) where T : notnull, IComparable<T>
    {
        if (minimum.CompareTo(value) > 0)
        {
            throw new ArgumentOutOfRangeException(name, "Value is less than the minimum allowed.");
        }

        if (maximum.CompareTo(value) < 0)
        {
            throw new ArgumentOutOfRangeException(name, "Value is greater than the maximum allowed.");
        }
    }
    #endregion
}
