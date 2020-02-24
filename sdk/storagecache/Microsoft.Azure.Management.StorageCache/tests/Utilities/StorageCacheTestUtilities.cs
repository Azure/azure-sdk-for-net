// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Azure.Test.HttpRecorder;

    /// <summary>
    /// Helper class.
    /// </summary>
    public static class StorageCacheTestUtilities
    {
        /// <summary>
        /// Generate a random prefix that can be ingested by Azure.
        /// </summary>
        /// <returns>The generated string.</returns>
        public static string GeneratePrefix()
        {
            StringBuilder sb = new StringBuilder(DateTime.Now.ToString("MMdd"));
            var firstFour = Guid.NewGuid().ToString().Substring(0, 4);
            sb.Append(string.Format("x{0}", firstFour));
            return sb.ToString();
        }

        /// <summary>
        /// The GenerateName.
        /// </summary>
        /// <param name="prefix">The prefix<see cref="string"/>.</param>
        /// <param name="methodName">The methodName<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateName(
            string prefix = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "GenerateName_failed")
        {
            prefix += GeneratePrefix();
            try
            {
                return HttpMockServer.GetAssetName(methodName, prefix);
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(string.Format("Generated name not found for calling method: {0}", methodName), e);
            }
        }

        /// <summary>
        /// Throw expception if the given condition is satisfied.
        /// </summary>
        /// <param name="condition">Condition to verify.</param>
        /// <param name="message">Exception message to raise.</param>
        public static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
