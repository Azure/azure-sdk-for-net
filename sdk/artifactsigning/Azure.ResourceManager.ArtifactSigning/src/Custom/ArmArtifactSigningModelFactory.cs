// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ArtifactSigning;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ArtifactSigning.Models
{
    public static partial class ArmArtifactSigningModelFactory
    {
        // This method is hand-copied from the generated factory to preserve the original
        // parameter name `profileType`. Renaming a parameter is source-breaking for callers
        // using named arguments.
        // Remove this customization once https://github.com/microsoft/typespec/issues/10463
        // is resolved.
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="profileType"> Profile type of the certificate. </param>
        /// <param name="includeStreetAddress"> Whether to include SA in the certificate subject name. </param>
        /// <param name="includeCity"> Whether to include L in the certificate subject name. </param>
        /// <param name="includeState"> Whether to include S in the certificate subject name. </param>
        /// <param name="includeCountry"> Whether to include C in the certificate subject name. </param>
        /// <param name="includePostalCode"> Whether to include PC in the certificate subject name. </param>
        /// <param name="identityValidationId"> Identity validation id used for the certificate subject name. </param>
        /// <param name="provisioningState"> Status of the current operation on certificate profile. </param>
        /// <param name="status"> Status of the certificate profile. </param>
        /// <param name="certificates"> List of renewed certificates. </param>
        /// <returns> A new <see cref="ArtifactSigning.ArtifactSigningCertificateProfileData"/> instance for mocking. </returns>
        public static ArtifactSigningCertificateProfileData ArtifactSigningCertificateProfileData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, CertificateProfileType? profileType = default, bool? includeStreetAddress = default, bool? includeCity = default, bool? includeState = default, bool? includeCountry = default, bool? includePostalCode = default, string identityValidationId = default, ArtifactSigningProvisioningState? provisioningState = default, CertificateProfileStatus? status = default, IEnumerable<ArtifactSigningCertificate> certificates = default)
        {
            return new ArtifactSigningCertificateProfileData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                profileType is null && includeStreetAddress is null && includeCity is null && includeState is null && includeCountry is null && includePostalCode is null && identityValidationId is null && provisioningState is null && status is null && certificates is null ? default : new CertificateProfileProperties(
                    profileType.GetValueOrDefault(),
                    includeStreetAddress,
                    includeCity,
                    includeState,
                    includeCountry,
                    includePostalCode,
                    identityValidationId,
                    provisioningState,
                    status,
                    (certificates ?? new ChangeTrackingList<ArtifactSigningCertificate>()).ToList(),
                    null));
        }
    }
}
