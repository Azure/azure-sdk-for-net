// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault
{
    internal static class Argument
    {
        internal static void NotEmpty<T>(ref T value, string name) where T : struct, IEquatable<T>
        {
            if (value.Equals(default))
            {
                throw new ArgumentException("Value cannot be empty.", name);
            }
        }

        internal static void NotNull(object value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void NotNullOrEmpty(string value, string name)
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
    }
}
