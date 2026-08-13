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
        /// Optional. When not set, the account name is derived from the request URL at
        /// signing time. Set this explicitly when the endpoint is a custom URL from which
        /// the account name cannot be derived; otherwise there may be failures or implicit
        /// fallback to bearer token authentication.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// An optional session provider that owns the session cache and mints sessions.
        /// Construct one with <see cref="ContainerSessionProvider(Uri, Core.TokenCredential, BlobClientOptions)"/>,
        /// which is for <see cref="Core.TokenCredential"/> authentication only.
        /// The provider must target the same blob service endpoint as the client that this is attached to.
        /// Sessions are cached per container, so clients configured with the same provider share its
        /// cached sessions and a session is created once per container no matter how many clients use it.
        /// When not set, the client creates a provider of its own, shared only with the clients derived from
        /// it (for example the container and blob clients created from a service client). Separately
        /// constructed clients do not share a cache, so each creates its own sessions.
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
        /// Default. The session authentication behavior is determined by the client library
        /// and may be updated in future releases.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Always use bearer token authentication. No session tokens are used.
        /// </summary>
        Disabled = 1,

        /// <summary>
        /// Opt in to session token authentication for all containers.
        /// Each container gets its own cached session token.
        /// </summary>
        Enabled = 2
    }
}
