// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Communication
{
    /// <summary>
    /// A class representing the CommunicationServiceResource data model.
    /// A class representing a CommunicationService resource.
    /// </summary>
    public partial class CommunicationServiceResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of CommunicationServiceResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="hostName"> FQDN of the CommunicationService instance. </param>
        /// <param name="dataLocation"> The location where the communication service stores its data at rest. </param>
        /// <param name="notificationHubId"> Resource ID of an Azure Notification Hub linked to this resource. </param>
        /// <param name="version"> Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs. </param>
        /// <param name="immutableResourceId"> The immutable resource Id of the communication service. </param>
        /// <param name="linkedDomains"> List of email Domain resource Ids. </param>
        internal CommunicationServiceResourceData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, CommunicationServicesProvisioningState? provisioningState, string hostName, string dataLocation, ResourceIdentifier notificationHubId, string version, Guid? immutableResourceId, IList<string> linkedDomains) : base(id, name, resourceType, systemData, tags, location)
        {
            ProvisioningState = provisioningState;
            HostName = hostName;
            DataLocation = dataLocation;
            NotificationHubId = notificationHubId;
            Version = version;
            ImmutableResourceId = immutableResourceId;
            LinkedDomains = linkedDomains;
        }
    }
}
