// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway probe.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IApplicationGatewayProbe  :
        IHasInner<Models.ApplicationGatewayProbeInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasProtocol<Models.ApplicationGatewayProtocol>
    {
        /// <summary>
        /// Gets the number of failed retry probes before the backend server is marked as being down
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        int RetriesBeforeUnhealthy { get; }

        /// <summary>
        /// Gets the relative path to be called by the probe.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets the number of seconds between probe retries.
        /// </summary>
        int TimeBetweenProbesInSeconds { get; }

        /// <summary>
        /// Gets host name to send the probe to.
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the number of seconds waiting for a response after which the probe times out and it is marked as failed
        /// Acceptable values are from 1 to 86400 seconds.
        /// </summary>
        int TimeoutInSeconds { get; }
    }
}