// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    internal static class Throw
    {
        public static void IfArgument(bool isInvalid, string paramName, string message = null) 
        {
            if (isInvalid)
            {
                message = message ?? "Invalid argument.";
                throw new ArgumentException(message, paramName);
            }
        }

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

        public static void IfArgumentNullOrEmpty(string value, string paramName, string message = null)
        {
            Throw.IfArgumentNull(value, paramName, message);

            message = message ?? "Argument cannot be an empty string.";
            Throw.IfArgument(value.Length == 0, paramName, message);
        }
    }
}
