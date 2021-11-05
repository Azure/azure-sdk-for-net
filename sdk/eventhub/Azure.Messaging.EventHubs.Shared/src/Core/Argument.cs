// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Messaging.EventHubs;

namespace Azure.Core
{
    /// <summary>
    ///   Provides a consistent means for verifying arguments and other invariants for a given
    ///   member.
    /// </summary>
    ///
    /// <remarks>
    ///   This class extends the <see cref="Azure.Core.Argument" /> type, referenced as a partial
    ///   class via shared source; the base partial class definition may be found in the "SharedSource"
    ///   folder of this project.
    /// </remarks>
    ///
    internal static partial class Argument
    {
        /// <summary>
        ///   Ensures that an argument's value is a string comprised of only whitespace, though
        ///   <c>null</c> is considered a valid value.  An <see cref="ArgumentException" /> is thrown
        ///   if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="argumentName">The name of the argument being considered.</param>
        ///
        /// <exception cref="ArgumentException">The argument is empty or contains only white-space.</exception>
        ///
        public static void AssertNotEmptyOrWhiteSpace(string argumentValue, string argumentName)
        {
            if (argumentValue is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException($"The argument '{argumentName}' may not be empty or white-space, though it may be null.", argumentName);
            }
        }

        /// <summary>
        ///   Ensures that a string argument's length is below a maximum allowed threshold,
        ///   throwing an <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="maximumLength">The maximum allowable length for the <paramref name="argumentValue" />; its length must be less than or equal to this value.</param>
        /// <param name="argumentName">The name of the argument being considered.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argumentValue" /> exceeds <paramref name="maximumLength" /> characters.</exception>
        ///
        public static void AssertNotTooLong(string argumentValue, int maximumLength, string argumentName)
        {
            if (argumentValue != null && argumentValue.Length > maximumLength)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument '{argumentName}' cannot exceed {maximumLength} characters.");
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is not a negative value, throwing an
        ///   <see cref="ArgumentOutOfRangeException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="argumentName">The name of the argument being considered.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argumentValue" /> is a negative <see cref="TimeSpan" /> value.</exception>
        ///
        public static void AssertNotNegative(TimeSpan argumentValue, string argumentName)
        {
            if (argumentValue < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"Argument {argumentName} must be a non-negative timespan value. The provided value was {argumentValue}.");
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is at least as large as a given lower bound, throwing
        ///   <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue" /> must be greater than or equal to this value.</param>
        /// <param name="argumentName">The name of the argument being considered.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argumentValue" /> is less than <paramref name="minimumValue" />.</exception>
        ///
        public static void AssertAtLeast(long argumentValue, long minimumValue, string argumentName)
        {
            if (argumentValue < minimumValue)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The value supplied must be greater than or equal to {minimumValue}.");
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is at least as large as a given lower bound, throwing
        ///   <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The value of the argument to verify.</param>
        /// <param name="minimumValue">The minimum to use for comparison; <paramref name="argumentValue" /> must be greater than or equal to this value.</param>
        /// <param name="argumentName">The name of the argument being considered.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argumentValue" /> is less than <paramref name="minimumValue" />.</exception>
        ///
        public static void AssertAtLeast(int argumentValue, int minimumValue, string argumentName)
        {
            if (argumentValue < minimumValue)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The value supplied must be greater than or equal to {minimumValue}.");
            }
        }

        /// <summary>
        ///   Ensures that an instance has not been disposed, throwing an
        ///   <see cref="ObjectDisposedException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="wasDisposed"><c>true</c> if the target instance has been disposed; otherwise, <c>false</c>.</param>
        /// <param name="targetName">The name of the target instance that is being verified.</param>
        ///
        public static void AssertNotDisposed(bool wasDisposed, string targetName)
        {
            if (wasDisposed)
            {
                throw new ObjectDisposedException(targetName, string.Format(CultureInfo.CurrentCulture, Resources.ClosedInstanceCannotPerformOperation, targetName));
            }
        }

        /// <summary>
        ///   Ensures that an instance has not been closed, throwing an
        ///   <see cref="EventHubsException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="wasClosed"><c>true</c> if the target instance has been closed; otherwise, <c>false</c>.</param>
        /// <param name="targetName">The name of the target instance that is being verified.</param>
        ///
        /// <exception cref="EventHubsException"><paramref name="wasClosed" /> is <c>true</c>.</exception>
        ///
        public static void AssertNotClosed(bool wasClosed, string targetName)
        {
            if (wasClosed)
            {
                throw new EventHubsException(targetName, string.Format(CultureInfo.CurrentCulture, Resources.ClosedInstanceCannotPerformOperation, targetName), EventHubsException.FailureReason.ClientClosed);
            }
        }

        /// <summary>
        ///   Ensures that an argument's value is a well-formed Event Hubs fully qualified namespace value,
        ///   throwing a <see cref="ArgumentException" /> if that invariant is not met.
        /// </summary>
        ///
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        ///
        ///
        /// <exception cref="ArgumentException"><paramref name="argumentValue" /> is not a well-formed Event Hubs fully qualified namespace.</exception>
        ///
        public static void AssertWellFormedEventHubsNamespace(string argumentValue, string argumentName)
        {
            argumentValue ??= string.Empty;

            if (Uri.CheckHostName(argumentValue) == UriHostNameType.Unknown)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidFullyQualifiedNamespace, argumentValue), argumentName);
            }
        }
    }
}
