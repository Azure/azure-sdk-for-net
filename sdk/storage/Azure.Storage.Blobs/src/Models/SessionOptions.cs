// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Options for configuring session token authentication for blob operations.
    /// </summary>
    public class SessionOptions
    {
        /// <summary>
        /// The session authentication mode to use for blob operations.
        /// </summary>
        public SessionMode SessionMode { get; set; } = SessionMode.Auto;

        /// <summary>
        /// The Account name to use for signing the session key.
        /// Must be set if <see cref="Models.SessionMode"/> is not <see cref="SessionMode.None"/>.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// The container name to cache for Session Authentication.
        /// Must be set if <see cref="Models.SessionMode"/> is <see cref="SessionMode.SingleSpecifiedContainer"/>.
        /// </summary>
        public string ContainerName { get; set; }
    }

    /// <summary>
    /// Determines the session authentication mode for blob operations.
    /// </summary>
    public enum SessionMode
    {
        /// <summary>
        /// Always use bearer token authentication. No session tokens are used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Default behavior. This is currently equivalent to <see cref="None"/>.
        /// </summary>
        Auto = None,

        /// <summary>
        /// Opt in to session token authentication scoped to a single container
        /// that is specified in <see cref="SessionOptions.ContainerName"/>.
        /// </summary>
        SingleSpecifiedContainer = 1
    }
}
