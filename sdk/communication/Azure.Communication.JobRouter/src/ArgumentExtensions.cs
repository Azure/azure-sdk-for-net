// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.JobRouter
{
    internal static partial class Argument
    {
        public static void AssertNotNullOrWhiteSpace(string value, string name)
        {
            AssertNotNullOrEmpty(value, name);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", name);
            }
        }

        public static T CheckNotNull<T>(T value, string name) where T : class
        {
            AssertNotNull(value, name);
            return value;
        }

        public static string CheckNotNullOrEmpty(string value, string name)
        {
            AssertNotNullOrEmpty(value, name);
            return value;
        }

        public static void AssertInRange<T>(T value, T minimum, T maximum, string name) where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0 || value.CompareTo(maximum) > 0)
            {
                throw new ArgumentOutOfRangeException(name, value, $"Value must be between {minimum} and {maximum}.");
            }
        }

        public static void AssertNull<T>(T? value, string name, string message = null) where T : struct
        {
            if (value.HasValue)
            {
                throw new ArgumentException(message ?? "Value must be null.", name);
            }
        }
    }
}
