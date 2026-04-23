// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public static partial class ArmAppServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceCertificateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="keyVaultId"> Key Vault resource Id. </param>
        /// <param name="keyVaultSecretName"> Key Vault secret name. </param>
        /// <param name="provisioningState"> Status of the Key Vault secret. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.AppServiceCertificateData"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateData AppServiceCertificateData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, KeyVaultSecretStatus? provisioningState = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AppServiceCertificateData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                keyVaultId,
                keyVaultSecretName,
                provisioningState,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceCertificateOrderData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="certificates"> State of the Key Vault secret. </param>
        /// <param name="distinguishedName"> Certificate distinguished name. </param>
        /// <param name="domainVerificationToken"> Domain verification token. </param>
        /// <param name="validityInYears"> Duration in years (must be 1). </param>
        /// <param name="keySize"> Certificate key size. </param>
        /// <param name="productType"> Certificate product type. </param>
        /// <param name="isAutoRenew"> &lt;code&gt;true&lt;/code&gt; if the certificate should be automatically renewed when it expires; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="provisioningState"> Status of certificate order. </param>
        /// <param name="status"> Current order status. </param>
        /// <param name="signedCertificate"> Signed certificate. </param>
        /// <param name="csr"> Last CSR that was created for this order. </param>
        /// <param name="intermediate"> Intermediate certificate. </param>
        /// <param name="root"> Root certificate. </param>
        /// <param name="serialNumber"> Current serial number of the certificate. </param>
        /// <param name="lastCertificateIssuedOn"> Certificate last issuance time. </param>
        /// <param name="expireOn"> Certificate expiration time. </param>
        /// <param name="isPrivateKeyExternal"> &lt;code&gt;true&lt;/code&gt; if private key is external; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="appServiceCertificateNotRenewableReasons"> Reasons why App Service Certificate is not renewable at the current moment. </param>
        /// <param name="nextAutoRenewTimeStamp"> Time stamp when the certificate would be auto renewed next. </param>
        /// <param name="contact"> Contact info. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.AppServiceCertificateOrderData"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateOrderData AppServiceCertificateOrderData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, IDictionary<string, AppServiceCertificateProperties> certificates = null, string distinguishedName = null, string domainVerificationToken = null, int? validityInYears = null, int? keySize = null, CertificateProductType? productType = null, bool? isAutoRenew = null, ProvisioningState? provisioningState = null, CertificateOrderStatus? status = null, AppServiceCertificateDetails signedCertificate = null, string csr = null, AppServiceCertificateDetails intermediate = null, AppServiceCertificateDetails root = null, string serialNumber = null, DateTimeOffset? lastCertificateIssuedOn = null, DateTimeOffset? expireOn = null, bool? isPrivateKeyExternal = null, IEnumerable<AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = null, DateTimeOffset? nextAutoRenewTimeStamp = null, CertificateOrderContact contact = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            certificates ??= new Dictionary<string, AppServiceCertificateProperties>();
            appServiceCertificateNotRenewableReasons ??= new List<AppServiceCertificateNotRenewableReason>();

            return new AppServiceCertificateOrderData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                certificates,
                distinguishedName,
                domainVerificationToken,
                validityInYears,
                keySize,
                productType,
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
                appServiceCertificateNotRenewableReasons?.ToList(),
                nextAutoRenewTimeStamp,
                contact,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceCertificateDetails"/>. </summary>
        /// <param name="version"> Certificate Version. </param>
        /// <param name="serialNumber"> Certificate Serial Number. </param>
        /// <param name="thumbprintString"> Certificate Thumbprint. </param>
        /// <param name="subject"> Certificate Subject. </param>
        /// <param name="notBefore"> Date Certificate is valid from. </param>
        /// <param name="notAfter"> Date Certificate is valid to. </param>
        /// <param name="signatureAlgorithm"> Certificate Signature algorithm. </param>
        /// <param name="issuer"> Certificate Issuer. </param>
        /// <param name="rawData"> Raw certificate data. </param>
        /// <returns> A new <see cref="Models.AppServiceCertificateDetails"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateDetails AppServiceCertificateDetails(int? version = null, string serialNumber = null, string thumbprintString = null, string subject = null, DateTimeOffset? notBefore = null, DateTimeOffset? notAfter = null, string signatureAlgorithm = null, string issuer = null, string rawData = null)
        {
            return new AppServiceCertificateDetails(
                version,
                serialNumber,
                thumbprintString,
                subject,
                notBefore,
                notAfter,
                signatureAlgorithm,
                issuer,
                rawData,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceCertificateProperties"/>. </summary>
        /// <param name="keyVaultId"> Key Vault resource Id. </param>
        /// <param name="keyVaultSecretName"> Key Vault secret name. </param>
        /// <param name="provisioningState"> Status of the Key Vault secret. </param>
        /// <returns> A new <see cref="Models.AppServiceCertificateProperties"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateProperties AppServiceCertificateProperties(ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, KeyVaultSecretStatus? provisioningState = null)
        {
            return new AppServiceCertificateProperties(keyVaultId, keyVaultSecretName, provisioningState, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceCertificateOrderPatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="certificates"> State of the Key Vault secret. </param>
        /// <param name="distinguishedName"> Certificate distinguished name. </param>
        /// <param name="domainVerificationToken"> Domain verification token. </param>
        /// <param name="validityInYears"> Duration in years (must be 1). </param>
        /// <param name="keySize"> Certificate key size. </param>
        /// <param name="productType"> Certificate product type. </param>
        /// <param name="isAutoRenew"> &lt;code&gt;true&lt;/code&gt; if the certificate should be automatically renewed when it expires; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="provisioningState"> Status of certificate order. </param>
        /// <param name="status"> Current order status. </param>
        /// <param name="signedCertificate"> Signed certificate. </param>
        /// <param name="csr"> Last CSR that was created for this order. </param>
        /// <param name="intermediate"> Intermediate certificate. </param>
        /// <param name="root"> Root certificate. </param>
        /// <param name="serialNumber"> Current serial number of the certificate. </param>
        /// <param name="lastCertificateIssuanceOn"> Certificate last issuance time. </param>
        /// <param name="expireOn"> Certificate expiration time. </param>
        /// <param name="isPrivateKeyExternal"> &lt;code&gt;true&lt;/code&gt; if private key is external; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="appServiceCertificateNotRenewableReasons"> Reasons why App Service Certificate is not renewable at the current moment. </param>
        /// <param name="nextAutoRenewalTimeStamp"> Time stamp when the certificate would be auto renewed next. </param>
        /// <param name="contact"> Contact info. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.AppServiceCertificateOrderPatch"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateOrderPatch AppServiceCertificateOrderPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, AppServiceCertificateProperties> certificates = null, string distinguishedName = null, string domainVerificationToken = null, int? validityInYears = null, int? keySize = null, CertificateProductType? productType = null, bool? isAutoRenew = null, ProvisioningState? provisioningState = null, CertificateOrderStatus? status = null, AppServiceCertificateDetails signedCertificate = null, string csr = null, AppServiceCertificateDetails intermediate = null, AppServiceCertificateDetails root = null, string serialNumber = null, DateTimeOffset? lastCertificateIssuanceOn = null, DateTimeOffset? expireOn = null, bool? isPrivateKeyExternal = null, IEnumerable<AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = null, DateTimeOffset? nextAutoRenewalTimeStamp = null, CertificateOrderContact contact = null, string kind = null)
        {
            certificates ??= new Dictionary<string, AppServiceCertificateProperties>();
            appServiceCertificateNotRenewableReasons ??= new List<AppServiceCertificateNotRenewableReason>();

            return new AppServiceCertificateOrderPatch(
                id,
                name,
                resourceType,
                systemData,
                certificates,
                distinguishedName,
                domainVerificationToken,
                validityInYears,
                keySize,
                productType,
                isAutoRenew,
                provisioningState,
                status,
                signedCertificate,
                csr,
                intermediate,
                root,
                serialNumber,
                lastCertificateIssuanceOn,
                expireOn,
                isPrivateKeyExternal,
                appServiceCertificateNotRenewableReasons?.ToList(),
                nextAutoRenewalTimeStamp,
                contact,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceCertificatePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="keyVaultId"> Key Vault resource Id. </param>
        /// <param name="keyVaultSecretName"> Key Vault secret name. </param>
        /// <param name="provisioningState"> Status of the Key Vault secret. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.AppServiceCertificatePatch"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificatePatch AppServiceCertificatePatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, KeyVaultSecretStatus? provisioningState = null, string kind = null)
        {
            return new AppServiceCertificatePatch(
                id,
                name,
                resourceType,
                systemData,
                keyVaultId,
                keyVaultSecretName,
                provisioningState,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceCertificateEmail"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="emailId"> Email id. </param>
        /// <param name="timeStamp"> Time stamp. </param>
        /// <returns> A new <see cref="Models.AppServiceCertificateEmail"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceCertificateEmail AppServiceCertificateEmail(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string emailId = null, DateTimeOffset? timeStamp = null)
        {
            return new AppServiceCertificateEmail(
                id,
                name,
                resourceType,
                systemData,
                emailId,
                timeStamp,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CertificateOrderContact"/>. </summary>
        /// <param name="email"></param>
        /// <param name="nameFirst"></param>
        /// <param name="nameLast"></param>
        /// <param name="phone"></param>
        /// <returns> A new <see cref="Models.CertificateOrderContact"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CertificateOrderContact CertificateOrderContact(string email = null, string nameFirst = null, string nameLast = null, string phone = null)
        {
            return new CertificateOrderContact(email, nameFirst, nameLast, phone, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CertificateOrderAction"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="actionType"> Action type. </param>
        /// <param name="createdOn"> Time at which the certificate action was performed. </param>
        /// <returns> A new <see cref="Models.CertificateOrderAction"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CertificateOrderAction CertificateOrderAction(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, CertificateOrderActionType? actionType = null, DateTimeOffset? createdOn = null)
        {
            return new CertificateOrderAction(
                id,
                name,
                resourceType,
                systemData,
                actionType,
                createdOn,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ReissueCertificateOrderContent"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="keySize"> Certificate Key Size. </param>
        /// <param name="delayExistingRevokeInHours"> Delay in hours to revoke existing certificate after the new certificate is issued. </param>
        /// <param name="csr"> Csr to be used for re-key operation. </param>
        /// <param name="isPrivateKeyExternal"> Should we change the ASC type (from managed private key to external private key and vice versa). </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.ReissueCertificateOrderContent"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ReissueCertificateOrderContent ReissueCertificateOrderContent(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, int? keySize = null, int? delayExistingRevokeInHours = null, string csr = null, bool? isPrivateKeyExternal = null, string kind = null)
        {
            return new ReissueCertificateOrderContent(
                id,
                name,
                resourceType,
                systemData,
                keySize,
                delayExistingRevokeInHours,
                csr,
                isPrivateKeyExternal,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.RenewCertificateOrderContent"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="keySize"> Certificate Key Size. </param>
        /// <param name="csr"> Csr to be used for re-key operation. </param>
        /// <param name="isPrivateKeyExternal"> Should we change the ASC type (from managed private key to external private key and vice versa). </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.RenewCertificateOrderContent"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenewCertificateOrderContent RenewCertificateOrderContent(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, int? keySize = null, string csr = null, bool? isPrivateKeyExternal = null, string kind = null)
        {
            return new RenewCertificateOrderContent(
                id,
                name,
                resourceType,
                systemData,
                keySize,
                csr,
                isPrivateKeyExternal,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SiteSeal"/>. </summary>
        /// <param name="html"> HTML snippet. </param>
        /// <returns> A new <see cref="Models.SiteSeal"/> instance for mocking. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteSeal SiteSeal(string html = null)
        {
            return new SiteSeal(html, serializedAdditionalRawData: null);
        }
    }
}
