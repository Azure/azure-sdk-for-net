// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary>
    /// A class representing the SecurityInsightsEntity data model.
    /// Specific entity.
    /// Please note <see cref="SecurityInsightsEntity"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SecurityInsightsAccountEntity"/>, <see cref="SecurityInsightsAzureResourceEntity"/>, <see cref="SecurityInsightsHuntingBookmark"/>, <see cref="SecurityInsightsCloudApplicationEntity"/>, <see cref="SecurityInsightsDnsEntity"/>, <see cref="SecurityInsightsFileEntity"/>, <see cref="SecurityInsightsFileHashEntity"/>, <see cref="SecurityInsightsHostEntity"/>, <see cref="SecurityInsightsIotDeviceEntity"/>, <see cref="SecurityInsightsIPEntity"/>, <see cref="SecurityInsightsMailboxEntity"/>, <see cref="SecurityInsightsMailClusterEntity"/>, <see cref="SecurityInsightsMailMessageEntity"/>, <see cref="SecurityInsightsMalwareEntity"/>, <see cref="NicEntity"/>, <see cref="SecurityInsightsProcessEntity"/>, <see cref="SecurityInsightsRegistryKeyEntity"/>, <see cref="SecurityInsightsRegistryValueEntity"/>, <see cref="SecurityInsightsAlert"/>, <see cref="SecurityInsightsGroupEntity"/>, <see cref="SecurityInsightsSubmissionMailEntity"/> and <see cref="SecurityInsightsUriEntity"/>.
    /// </summary>
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation exposes the discriminated base constructor publicly; keep the previously shipped parameterless constructor instead.
    [CodeGenType("SecurityInsightsEntityData")]
    [CodeGenSuppress("SecurityInsightsEntity")]
    [CodeGenSuppress("SecurityInsightsEntity", typeof(SecurityInsightsEntityKind))]
    public partial class SecurityInsightsEntity
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsEntity"/>. </summary>
        public SecurityInsightsEntity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsEntity"/>. </summary>
        /// <param name="kind"> The kind of the entity. </param>
        private protected SecurityInsightsEntity(SecurityInsightsEntityKind kind)
        {
            Kind = kind;
        }
    }
}