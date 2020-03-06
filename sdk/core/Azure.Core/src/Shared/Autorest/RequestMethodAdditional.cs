// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Represents HTTP methods sent as part of a <see cref="Request"/>.
    /// </summary>
    internal readonly struct RequestMethodAdditional
    {
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for GET method.
        /// </summary>
        public static RequestMethod Get { get; } = new RequestMethod("GET");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for POST method.
        /// </summary>
        public static RequestMethod Post { get; } = new RequestMethod("POST");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for PUT method.
        /// </summary>
        public static RequestMethod Put { get; } = new RequestMethod("PUT");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for PATCH method.
        /// </summary>
        public static RequestMethod Patch { get; } = new RequestMethod("PATCH");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for DELETE method.
        /// </summary>
        public static RequestMethod Delete { get; } = new RequestMethod("DELETE");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for HEAD method.
        /// </summary>
        public static RequestMethod Head { get; } = new RequestMethod("HEAD");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for OPTIONS method.
        /// </summary>
        public static RequestMethod Options { get; } = new RequestMethod("OPTIONS");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for TRACE method.
        /// </summary>
        public static RequestMethod Trace { get; } = new RequestMethod("TRACE");
    }
}
