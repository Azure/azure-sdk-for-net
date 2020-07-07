// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Enumeration of the internal SDK trace sources used when logging
    /// to <see cref="TraceWriter"/>.
    /// </summary>
    internal static class TraceSource
    {
        private const string SdkPrefix = "WebJobs.";

        /// <summary>
        /// Trace message coming from function indexing.
        /// </summary>
        public const string Indexing = SdkPrefix + "Indexing";

        /// <summary>
        /// Trace message coming from <see cref="JobHost"/>.
        /// </summary>
        public const string Host = SdkPrefix + "Host";

        /// <summary>
        /// Trace message coming from function execution.
        /// </summary>
        public const string Execution = SdkPrefix + "Execution";
    }
}
