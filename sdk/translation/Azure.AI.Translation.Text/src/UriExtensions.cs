// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Translation.Text
{
    /// <summary>
    /// Extension methods for Uri.
    /// </summary>
    internal static class UriExtensions
    {
        private const string PLATFORM_HOST = "cognitiveservices";

        /// <summary>
        /// Checks the uri and decides whether it is platform host.
        /// </summary>
        /// <param name="uri">Uri to check</param>
        /// <returns>True - uri is pointing to platform. False otherwise.</returns>
        internal static bool IsPlatformHost(this Uri uri)
        {
            return uri.Host?.Contains(PLATFORM_HOST) == true;
        }
    }
}
