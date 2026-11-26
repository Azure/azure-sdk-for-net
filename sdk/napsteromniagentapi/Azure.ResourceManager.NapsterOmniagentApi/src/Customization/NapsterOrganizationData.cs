// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NapsterOmniagentApi.Models;

namespace Azure.ResourceManager.NapsterOmniagentApi
{
    public partial class NapsterOrganizationData
    {
        internal NapsterOrganizationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NapsterOrganizationProperties properties, string organizationName, ManagedServiceIdentity identity, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            Identity = identity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // Retain the legacy property as an alias for the resource name.
        /// <summary> Gets the name of the organization resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OrganizationName => Name;
    }
}
