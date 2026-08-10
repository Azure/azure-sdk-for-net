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
        public SessionMode SessionMode { get; set; } = SessionMode.Enabled;

        /// <summary>
        /// The Account name to use for signing the session key.
        /// Optional. When not set, the account name is derived from the request URL at
        /// signing time. Set this explicitly when the endpoint is a custom URL from which
        /// the account name cannot be derived; otherwise there may be failures or implicit
        /// fallback to bearer token authentication.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// An optional session provider that owns the session cache and mints sessions.
        /// When set, the same provider (and its cache) can be shared across multiple
        /// clients. When not set, the client creates a client-scoped provider internally.
        /// </summary>
        public SessionProvider SessionProvider { get; set; }

        /// <summary>
        /// Creates a shallow copy.
        /// </summary>
        internal SessionOptions Clone() => new SessionOptions
        {
            SessionMode = this.SessionMode,
            AccountName = this.AccountName,
            SessionProvider = this.SessionProvider,
        };
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
