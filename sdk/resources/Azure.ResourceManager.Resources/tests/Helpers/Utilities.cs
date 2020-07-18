// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Resources.Tests
{
    public static class Utilities
    {
        /// <summary>
        /// Equality comparison for locations returned by resource management
        /// </summary>
        /// <param name="expected">The expected location</param>
        /// <param name="actual">The actual location returned by resource management</param>
        /// <returns>true if the locations are equivalent, otherwise false</returns>
        public static bool LocationsAreEqual(string expected, string actual)
        {
            bool result = string.Equals(expected, actual, System.StringComparison.OrdinalIgnoreCase);
            if (!result && !string.IsNullOrEmpty(expected))
            {
                string normalizedLocation = expected.ToLower().Replace(" ", null);
                result = string.Equals(normalizedLocation, actual, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
