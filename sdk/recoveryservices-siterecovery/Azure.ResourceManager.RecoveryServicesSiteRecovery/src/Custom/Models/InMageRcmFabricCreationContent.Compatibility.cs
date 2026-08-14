// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    [CodeGenSuppress("InMageRcmFabricCreationContent", typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(IdentityProviderContent))]
    public partial class InMageRcmFabricCreationContent
    {
        /// <summary> Initializes a new instance of <see cref="InMageRcmFabricCreationContent"/>. </summary>
        // TODO: Remove this compatibility constructor after https://github.com/microsoft/typespec/issues/11588 is fixed.
        public InMageRcmFabricCreationContent(ResourceIdentifier vmwareSiteId, ResourceIdentifier physicalSiteId, IdentityProviderContent sourceAgentIdentity)
            : base("InMageRcm")
        {
            Argument.AssertNotNull(vmwareSiteId, nameof(vmwareSiteId));
            Argument.AssertNotNull(physicalSiteId, nameof(physicalSiteId));
            Argument.AssertNotNull(sourceAgentIdentity, nameof(sourceAgentIdentity));

            VMwareSiteId = vmwareSiteId;
            PhysicalSiteId = physicalSiteId;
            SourceAgentIdentity = sourceAgentIdentity;
        }
    }
}
