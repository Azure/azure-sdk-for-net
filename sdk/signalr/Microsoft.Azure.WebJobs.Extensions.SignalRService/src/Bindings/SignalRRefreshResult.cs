// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>A result from the SignalR authentication refresh input binding.</summary>
    public sealed class SignalRRefreshResult
    {
        internal SignalRRefreshResult(SignalRRefreshStatus status, SignalRConnectionInfo connectionInfo)
        {
            Status = status;
            ConnectionInfo = connectionInfo;
        }

        /// <summary>Gets the outcome of the refresh.</summary>
        public SignalRRefreshStatus Status { get; }

        /// <summary>Gets the refreshed connection information, or null if refresh was rejected.</summary>
        public SignalRConnectionInfo ConnectionInfo { get; }
    }

    /// <summary>Outcomes the SignalR authentication refresh input binding can return.</summary>
    public enum SignalRRefreshStatus
    {
        /// <summary>The refresh succeeded.</summary>
        Succeeded,

        /// <summary>The connection token from the binding or the default request header was missing or blank.</summary>
        MissingConnectionToken,

        /// <summary>The request failed authentication or the application's authentication policy.</summary>
        Unauthorized,

        /// <summary>The refreshed token resolves to a different user than the existing connection.</summary>
        Forbidden,

        /// <summary>The target connection was not found, is disconnected, or uses an unsupported negotiate version.</summary>
        ConnectionNotFound,
    }
}
