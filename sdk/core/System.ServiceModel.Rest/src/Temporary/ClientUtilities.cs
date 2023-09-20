// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Shared
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class ClientUtilities
    {
        /// <summary>
        /// TBD.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AssertNotNull<T>(T value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
    }
}
