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
        public SessionMode SessionMode { get; set; } = SessionMode.Disabled;

        /// <summary>
        /// The Account name to use for signing the session key.
        /// Must be set if <see cref="Models.SessionMode"/> is <see cref="SessionMode.Enabled"/>.
        /// </summary>
        public string AccountName { get; set; }
    }

    /// <summary>
    /// Determines the session authentication mode for blob operations.
    /// </summary>
    public enum SessionMode
    {
        /// <summary>
        /// Always use bearer token authentication. No session tokens are used.
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Opt in to session token authentication for all containers.
        /// Each container gets its own cached session token.
        /// </summary>
        Enabled = 1
    }
}
