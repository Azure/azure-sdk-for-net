// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NeonPostgres.Models
{
    /// <summary> The type used for update operations of the OrganizationResource. </summary>
    public partial class NeonOrganizationPatch
    {
        /// <summary> Initializes a new instance of <see cref="NeonOrganizationPatch"/>. </summary>
        internal NeonOrganizationPatch(NeonOrganizationData data)
        {
            Tags = data.Tags;
            Properties = new NeonOrganizationPatchProperties
            {
                MarketplaceDetails = data.Properties.MarketplaceDetails,
                UserDetails = data.Properties.UserDetails,
                CompanyDetails = data.Properties.CompanyDetails,
                PartnerOrganizationProperties = data.Properties.PartnerOrganizationProperties,
                ProjectProperties = data.Properties.ProjectProperties,
            };
        }
    }
}
