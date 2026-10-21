// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class ConnectionMonitorCollection
    {
        /// <summary> Creates or updates a connection monitor without requesting migration. </summary>
        public virtual Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content) =>
            CreateOrUpdateAsync(waitUntil, connectionMonitorName, content, default(string), default);

        /// <summary> Creates or updates a connection monitor without requesting migration. </summary>
        public virtual Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, CancellationToken cancellationToken = default) =>
            CreateOrUpdateAsync(waitUntil, connectionMonitorName, content, default(string), cancellationToken);

        /// <summary> Creates or updates a connection monitor using its compatibility request name. </summary>
        public virtual Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorContent content, string migrate = default, CancellationToken cancellationToken = default) =>
            CreateOrUpdateAsync(waitUntil, connectionMonitorName, (ConnectionMonitorCreateOrUpdateContent)content, migrate, cancellationToken);

        /// <summary> Creates or updates a connection monitor using its compatibility request name. </summary>
        public virtual ArmOperation<ConnectionMonitorResource> CreateOrUpdate(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorContent content, string migrate = default, CancellationToken cancellationToken = default) =>
            CreateOrUpdate(waitUntil, connectionMonitorName, (ConnectionMonitorCreateOrUpdateContent)content, migrate, cancellationToken);
    }
}
