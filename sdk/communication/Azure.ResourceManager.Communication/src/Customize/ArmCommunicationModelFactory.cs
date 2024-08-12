// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Communication.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmCommunicationModelFactory
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
        /// <returns> A new <see cref="Communication.CommunicationServiceResourceData"/> instance for mocking. </returns>
        public static CommunicationServiceResourceData CommunicationServiceResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, CommunicationServicesProvisioningState? provisioningState = null, string hostName = null, string dataLocation = null, ResourceIdentifier notificationHubId = null, string version = null, Guid? immutableResourceId = null, IEnumerable<string> linkedDomains = null)
        {
            tags ??= new Dictionary<string, string>();
            linkedDomains ??= new List<string>();

            return new CommunicationServiceResourceData(id, name, resourceType, systemData, tags, location, provisioningState, hostName, dataLocation, notificationHubId, version, immutableResourceId, linkedDomains?.ToList());
        }
    }
}
