// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Provides a consistent means for verifying arguments and other invariants for a given
    ///   member.
    /// </summary>
    ///
    internal static class Guard
    {
        /// <summary>
        ///   Ensures that an argument's value is not <c>null</c>, throwing an
        ///   <see cref="ArgumentNullException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        ///
        public static void ArgumentNotNull(string argumentName,
                                           object argumentValue)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is not <c>null</c> or an empty string, throwing an
        ///   <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        ///
        public static void ArgumentNotNullOrEmpty(string argumentName,
                                                  string argumentValue)
        {
            if (String.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ArgumentNullOrEmpty, argumentName), argumentName);
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is not <c>null</c> or a string comprised of only whitespace,
        ///   throwing an <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        ///
        public static void ArgumentNotNullOrWhitespace(string argumentName,
                                                       string argumentValue)
        {
            if (String.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ArgumentNullOrWhiteSpace, argumentName), argumentName);
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is a string comprised of only whitespace, though
        ///   <c>null</c> is considered a valid value.  An <see cref="ArgumentException" /> is thrown
        ///   if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        ///
        public static void ArgumentNotEmptyOrWhitespace(string argumentName,
                                                        string argumentValue)
        {
            if (argumentValue == null)
            {
                return;
            }

            if (String.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ArgumentEmptyOrWhiteSpace, argumentName), argumentName);
            }
        }

        /// <summary>
        ///   Ensures that a string argument's length is below a maximum allowed threshold,
        ///   throwing an <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="maxmimumLength">The maximum allowable length for the <paramref name="argumentValue"/>; its length must be less than or equal to this value.</param>
        ///
        public static void ArgumentNotTooLong(string argumentName,
                                              string argumentValue,
                                              int maxmimumLength)
        {
            if (argumentValue?.Length > maxmimumLength)
            {
                throw new ArgumentOutOfRangeException(String.Format(CultureInfo.CurrentCulture, Resources.ArgumentStringTooLong, argumentName, maxmimumLength), argumentName);
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is not a negative value, throwing an
        ///   <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        ///
        public static void ArgumentNotNegative(string argumentName,
                                               TimeSpan argumentValue)
        {
            if (argumentValue < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName, String.Format(CultureInfo.CurrentCulture, Resources.TimeSpanMustBeNonNegative, argumentName, argumentValue));
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is at least as large as a given lower bound, throwing
        ///   <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue"/> must be greater than or equal to this value.</param>
        ///
        public static void ArgumentAtLeast(string argumentName,
                                           long argumentValue,
                                           long minimumValue)
        {
            if (argumentValue < minimumValue)
            {
                throw new ArgumentOutOfRangeException(argumentName, String.Format(CultureInfo.CurrentCulture, Resources.ValueMustBeAtLeast, minimumValue));
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is within a specified range, inclusive.
        ///   <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue"/> must be greater than or equal to this value.</param>
        /// <param name="maximumValue">The maximum to use for comparison; <paramref name="argumentValue"/> must be less than or equal to this value.</param>
        ///
        public static void ArgumentInRange(string argumentName,
                                           int argumentValue,
                                           int minimumValue,
                                           int maximumValue)
        {
            if ((argumentValue < minimumValue) || (argumentValue > maximumValue))
            {
                throw new ArgumentOutOfRangeException(argumentName, String.Format(CultureInfo.CurrentCulture, Resources.ValueOutOfRange, minimumValue, maximumValue));
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is within a specified range, inclusive.
        ///   <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue"/> must be greater than or equal to this value.</param>
        /// <param name="maximumValue">The maximum to use for comparison; <paramref name="argumentValue"/> must be less than or equal to this value.</param>
        ///
        public static void ArgumentInRange(string argumentName,
                                           long argumentValue,
                                           long minimumValue,
                                           long maximumValue)
        {
            if ((argumentValue < minimumValue) || (argumentValue > maximumValue))
            {
                throw new ArgumentOutOfRangeException(argumentName, String.Format(CultureInfo.CurrentCulture, Resources.ValueOutOfRange, minimumValue, maximumValue));
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is within a specified range, inclusive.
        ///   <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentName">The name of the argument being considered.</param>
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue"/> must be greater than or equal to this value.</param>
        /// <param name="maximumValue">The maximum to use for comparison; <paramref name="argumentValue"/> must be less than or equal to this value.</param>
        ///
        public static void ArgumentInRange(string argumentName,
                                           TimeSpan argumentValue,
                                           TimeSpan minimumValue,
                                           TimeSpan maximumValue)
        {
            if ((argumentValue < minimumValue) || (argumentValue > maximumValue))
            {
                throw new ArgumentOutOfRangeException(argumentName, String.Format(CultureInfo.CurrentCulture, Resources.ValueOutOfRange, minimumValue, maximumValue));
            }
        }
    }
}
