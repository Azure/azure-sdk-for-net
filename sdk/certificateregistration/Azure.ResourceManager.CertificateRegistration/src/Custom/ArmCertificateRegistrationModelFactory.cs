// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.CertificateRegistration;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CertificateRegistration.Models
{
    public static partial class ArmCertificateRegistrationModelFactory
    {
        // These methods are hand-copied from the generated factory to preserve the original
        // parameter name `productType`. Renaming a parameter is source-breaking for callers
        // using named arguments.
        // Remove these customizations once https://github.com/microsoft/typespec/issues/10463
        // is resolved.

        /// <summary> Initializes a new instance of <see cref="AppServiceCertificateOrderData"/>. </summary>
        public static AppServiceCertificateOrderData AppServiceCertificateOrderData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, IDictionary<string, AppServiceCertificateProperties> certificates = default, string distinguishedName = default, string domainVerificationToken = default, int? validityInYears = default, int? keySize = default, CertificateProductType? productType = default, bool? isAutoRenew = default, CertificateRegistrationProvisioningState? provisioningState = default, CertificateOrderStatus? status = default, AppServiceCertificateDetails signedCertificate = default, string csr = default, AppServiceCertificateDetails intermediate = default, AppServiceCertificateDetails root = default, string serialNumber = default, DateTimeOffset? lastCertificateIssuedOn = default, DateTimeOffset? expireOn = default, bool? isPrivateKeyExternal = default, IEnumerable<AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = default, DateTimeOffset? nextAutoRenewOn = default, CertificateOrderContact contact = default, string kind = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new AppServiceCertificateOrderData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                certificates is null && distinguishedName is null && domainVerificationToken is null && validityInYears is null && keySize is null && productType is null && isAutoRenew is null && provisioningState is null && status is null && signedCertificate is null && csr is null && intermediate is null && root is null && serialNumber is null && lastCertificateIssuedOn is null && expireOn is null && isPrivateKeyExternal is null && appServiceCertificateNotRenewableReasons is null && nextAutoRenewOn is null && contact is null ? default : new AppServiceCertificateOrderProperties(
                    certificates,
                    distinguishedName,
                    domainVerificationToken,
                    validityInYears,
                    keySize,
                    productType.GetValueOrDefault(),
                    isAutoRenew,
                    provisioningState,
                    status,
                    signedCertificate,
                    csr,
                    intermediate,
                    root,
                    serialNumber,
                    lastCertificateIssuedOn,
                    expireOn,
                    isPrivateKeyExternal,
                    (appServiceCertificateNotRenewableReasons ?? new ChangeTrackingList<AppServiceCertificateNotRenewableReason>()).ToList(),
                    nextAutoRenewOn,
                    contact,
                    null),
                kind);
        }

        /// <summary> Initializes a new instance of <see cref="AppServiceCertificateOrderPatch"/>. </summary>
        public static AppServiceCertificateOrderPatch AppServiceCertificateOrderPatch(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, AppServiceCertificateProperties> certificates = default, string distinguishedName = default, string domainVerificationToken = default, int? validityInYears = default, int? keySize = default, CertificateProductType? productType = default, bool? isAutoRenew = default, CertificateRegistrationProvisioningState? provisioningState = default, CertificateOrderStatus? status = default, AppServiceCertificateDetails signedCertificate = default, string csr = default, AppServiceCertificateDetails intermediate = default, AppServiceCertificateDetails root = default, string serialNumber = default, DateTimeOffset? lastCertificateIssuedOn = default, DateTimeOffset? expireOn = default, bool? isPrivateKeyExternal = default, IEnumerable<AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = default, DateTimeOffset? nextAutoRenewOn = default, CertificateOrderContact contact = default)
        {
            return new AppServiceCertificateOrderPatch(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                certificates is null && distinguishedName is null && domainVerificationToken is null && validityInYears is null && keySize is null && productType is null && isAutoRenew is null && provisioningState is null && status is null && signedCertificate is null && csr is null && intermediate is null && root is null && serialNumber is null && lastCertificateIssuedOn is null && expireOn is null && isPrivateKeyExternal is null && appServiceCertificateNotRenewableReasons is null && nextAutoRenewOn is null && contact is null ? default : new AppServiceCertificateOrderPatchResourceProperties(
                    certificates,
                    distinguishedName,
                    domainVerificationToken,
                    validityInYears,
                    keySize,
                    productType.GetValueOrDefault(),
                    isAutoRenew,
                    provisioningState,
                    status,
                    signedCertificate,
                    csr,
                    intermediate,
                    root,
                    serialNumber,
                    lastCertificateIssuedOn,
                    expireOn,
                    isPrivateKeyExternal,
                    (appServiceCertificateNotRenewableReasons ?? new ChangeTrackingList<AppServiceCertificateNotRenewableReason>()).ToList(),
                    nextAutoRenewOn,
                    contact,
                    null));
        }
    }
}
