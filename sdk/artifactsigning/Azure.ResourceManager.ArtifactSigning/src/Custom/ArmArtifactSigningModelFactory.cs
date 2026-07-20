// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ArtifactSigning;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ArtifactSigning.Models
{
    // Suppress the generated model-factory overload (which names the first payload parameter
    // `certificateProfileType`) so only the custom overload below, preserving the original
    // `profileType` parameter name, is exposed. Remove once the generated parameter name matches.
    [CodeGenSuppress("ArtifactSigningCertificateProfileData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(CertificateProfileType?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(ArtifactSigningProvisioningState?), typeof(CertificateProfileStatus?), typeof(IEnumerable<ArtifactSigningCertificate>))]
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
        /// <param name="programType"> Indicates whether the resource is intended for a specific usage scenario. </param>
        /// <param name="provisioningState"> Status of the current operation on certificate profile. </param>
        /// <param name="status"> Status of the certificate profile. </param>
        /// <param name="certificates"> List of renewed certificates. </param>
        /// <returns> A new <see cref="ArtifactSigning.ArtifactSigningCertificateProfileData"/> instance for mocking. </returns>
        public static ArtifactSigningCertificateProfileData ArtifactSigningCertificateProfileData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, CertificateProfileType? profileType = default, bool? includeStreetAddress = default, bool? includeCity = default, bool? includeState = default, bool? includeCountry = default, bool? includePostalCode = default, string identityValidationId = default, string programType = default, ArtifactSigningProvisioningState? provisioningState = default, CertificateProfileStatus? status = default, IEnumerable<ArtifactSigningCertificate> certificates = default)
        {
            return new ArtifactSigningCertificateProfileData(
                id,
                name,
                resourceType,
                systemData,
                profileType is null && includeStreetAddress is null && includeCity is null && includeState is null && includeCountry is null && includePostalCode is null && identityValidationId is null && programType is null && provisioningState is null && status is null && certificates is null ? default : new CertificateProfileProperties(
                    profileType.GetValueOrDefault(),
                    includeStreetAddress,
                    includeCity,
                    includeState,
                    includeCountry,
                    includePostalCode,
                    identityValidationId,
                    programType,
                    provisioningState,
                    status,
                    (certificates ?? new ChangeTrackingList<ArtifactSigningCertificate>()).ToList(),
                    null),
                additionalBinaryDataProperties: null);
        }

        // Backward-compatibility shim. Preserves the previous factory signature (without the
        // `programType` parameter added in this version) so existing callers keep compiling.
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Use the overload that includes the programType parameter instead.")]
        public static ArtifactSigningCertificateProfileData ArtifactSigningCertificateProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CertificateProfileType? profileType, bool? includeStreetAddress, bool? includeCity, bool? includeState, bool? includeCountry, bool? includePostalCode, string identityValidationId, ArtifactSigningProvisioningState? provisioningState, CertificateProfileStatus? status, IEnumerable<ArtifactSigningCertificate> certificates)
        {
            return ArtifactSigningCertificateProfileData(id, name, resourceType, systemData, profileType, includeStreetAddress, includeCity, includeState, includeCountry, includePostalCode, identityValidationId, default, provisioningState, status, certificates);
        }
    }
}
