// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Common
{
    using System;

    /// <summary>
    /// Defines utility methods for validating arguments.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Throws ArgumentException with the given parameter name and optional message if the given Boolean
        /// value is true.
        /// </summary>
        /// <param name="isInvalid">The flag to test. This method throws if it's true and does nothing if
        /// it's false.</param>
        /// <param name="paramName">The name of the parameter being validated. This is passed to the
        /// ArgumentException constructor.</param>
        /// <param name="message">An optional error message to include in the ArgumentException. The default
        /// message is "Invalid argument."</param>
        public static void IfArgument(bool isInvalid, string paramName, string message = null) 
        {
            if (isInvalid)
            {
                message = message ?? "Invalid argument.";
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// Throws ArgumentOutOfRangeException with the given parameter name and optional message if the given Boolean
        /// value is true.
        /// </summary>
        /// <param name="isInvalid">The flag to test. This method throws if it's true and does nothing if
        /// it's false.</param>
        /// <param name="paramName">The name of the parameter being validated. This is passed to the
        /// ArgumentOutOfRangeException constructor.</param>
        /// <param name="message">An optional error message to include in the ArgumentOutOfRangeException. The default
        /// message is "Argument out of range."</param>
        public static void IfArgumentOutOfRange(bool isInvalid, string paramName, string message = null)
        {
            if (isInvalid)
            {
                message = message ?? "Argument out of range.";
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Throws ArgumentNullException with the given parameter name and optional message if the given
        /// reference is null.
        /// </summary>
        /// <typeparam name="T">The type of value to test. Must be a reference type.</typeparam>
        /// <param name="value">The reference to test for null.</param>
        /// <param name="paramName">The name of the parameter being validated. This is passed to the
        /// ArgumentNullException constructor.</param>
        /// <param name="message">An optional error message to include in the ArgumentNullException.</param>
        public static void IfArgumentNull<T>(T value, string paramName, string message = null) where T : class
        {
            if (value == null)
            {
                if (message == null)
                {
                    throw new ArgumentNullException(paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName, message);
                }
            }
        }

        /// <summary>
        /// Throws ArgumentNullException or ArgumentException with the given parameter name and optional message
        /// if the given string is null or empty, respectively.
        /// </summary>
        /// <param name="value">The string to test for null or empty.</param>
        /// <param name="paramName">The name of the parameter being validated. This is passed to the
        /// ArgumentNullException or ArgumentException constructor.</param>
        /// <param name="message">An optional error message to include in the ArgumentNullException
        /// or ArgumentException.</param>
        public static void IfArgumentNullOrEmpty(string value, string paramName, string message = null)
        {
            IfArgumentNull(value, paramName, message);

            message = message ?? "Argument cannot be an empty string.";
            IfArgument(value.Length == 0, paramName, message);
        }

        /// <summary>
        /// Throws ArgumentNullException or ArgumentException with a pre-determined message if the given search
        /// service name is null or empty, respectively.
        /// </summary>
        /// <param name="searchServiceName">The search service name to validate.</param>
        public static void IfNullOrEmptySearchServiceName(string searchServiceName) =>
            IfArgumentNullOrEmpty(
                searchServiceName,
                nameof(searchServiceName),
                "Invalid search service name. Name cannot be null or an empty string.");
    }
}
