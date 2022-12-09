// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.DigitalTwins.Models
{
    using System.Collections.Generic;

    public partial class DigitalTwinsDescription
    {
        /// <summary>
        /// Initializes a new instance of the DigitalTwinsDescription class.
        /// </summary>
        /// <param name="location">The resource location.</param>
        /// <param name="id">The resource identifier.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="type">The resource type.</param>
        /// <param name="tags">The resource tags.</param>
        /// <param name="identity">The managed identity for the
        /// DigitalTwinsInstance.</param>
        /// <param name="systemData">Metadata pertaining to creation and last
        /// modification of the DigitalTwinsInstance.</param>
        /// <param name="createdTime">Time when DigitalTwinsInstance was
        /// created.</param>
        /// <param name="lastUpdatedTime">Time when DigitalTwinsInstance was
        /// updated.</param>
        /// <param name="provisioningState">The provisioning state. Possible
        /// values include: 'Provisioning', 'Deleting', 'Updating',
        /// 'Succeeded', 'Failed', 'Canceled', 'Deleted', 'Warning',
        /// 'Suspending', 'Restoring', 'Moving'</param>
        /// <param name="hostName">Api endpoint to work with
        /// DigitalTwinsInstance.</param>
        /// <param name="privateEndpointConnections">The private endpoint
        /// connections.</param>
        /// <param name="publicNetworkAccess">Public network access for the
        /// DigitalTwinsInstance. Possible values include: 'Enabled',
        /// 'Disabled'</param>
        public DigitalTwinsDescription(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), DigitalTwinsIdentity identity = default(DigitalTwinsIdentity), System.DateTime? createdTime = default(System.DateTime?), System.DateTime? lastUpdatedTime = default(System.DateTime?), string provisioningState = default(string), string hostName = default(string), IList<PrivateEndpointConnection> privateEndpointConnections = default(IList<PrivateEndpointConnection>), string publicNetworkAccess = default(string), SystemData systemData = default(SystemData))
            : base(location, id, name, type, tags, identity, systemData)
        {
            CreatedTime = createdTime;
            LastUpdatedTime = lastUpdatedTime;
            ProvisioningState = provisioningState;
            HostName = hostName;
            PrivateEndpointConnections = privateEndpointConnections;
            PublicNetworkAccess = publicNetworkAccess;
            CustomInit();
        }
    }
}
