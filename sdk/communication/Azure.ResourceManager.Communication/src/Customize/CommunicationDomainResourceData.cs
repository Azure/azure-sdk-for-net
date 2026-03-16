// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication
{
    // Backward compat: baseline API had DomainManagement? (nullable) but the TypeSpec property
    // is required, generating non-nullable DomainManagement. This shim restores nullable to match
    // the published API surface (ApiCompatVersion 1.3.1).
    public partial class CommunicationDomainResourceData
    {
        /// <summary> Describes how a Domains resource is being managed. </summary>
        [WirePath("properties.domainManagement")]
        public DomainManagement? DomainManagement
        {
            get => Properties is null ? default(DomainManagement?) : Properties.DomainManagement;
            set
            {
                if (Properties is null)
                {
                    Properties = new DomainProperties();
                }
                Properties.DomainManagement = value ?? default;
            }
        }
    }
}
