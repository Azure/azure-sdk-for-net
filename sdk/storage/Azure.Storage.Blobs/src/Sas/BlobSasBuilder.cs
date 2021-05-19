﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage container or blob.
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
    /// Create a service SAS</see>.
    /// </summary>
    public class BlobSasBuilder
    {
        /// <summary>
        /// The storage service version to use to authenticate requests made
        /// with this shared access signature, and the service version to use
        /// when handling requests made with this shared access signature.
        /// </summary>
        /// <remarks>
        /// This property has been deprecated and we will always use the latest
        /// storage SAS version of the Storage service supported. This change
        /// does not have any impact on how your application generates or makes
        /// use of SAS tokens.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Version { get; set; }

        /// <summary>
        /// The optional signed protocol field specifies the protocol
        /// permitted for a request made with the SAS.  Possible values are
        /// <see cref="SasProtocol.HttpsAndHttp"/>,
        /// <see cref="SasProtocol.Https"/>, and
        /// <see cref="SasProtocol.None"/>.
        /// </summary>
        public SasProtocol Protocol { get; set; }

        /// <summary>
        /// Optionally specify the time at which the shared access signature
        /// becomes valid.  If omitted when DateTimeOffset.MinValue is used,
        /// start time for this call is assumed to be the time when the
        /// storage service receives the request.
        /// </summary>
        public DateTimeOffset StartsOn { get; set; }

        /// <summary>
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// The permissions associated with the shared access signature. The
        /// user is restricted to operations allowed by the permissions. This
        /// field must be omitted if it has been specified in an associated
        /// stored access policy.  The <see cref="BlobSasPermissions"/>,
        /// <see cref="BlobContainerSasPermissions"/>, <see cref="SnapshotSasPermissions"/>,
        /// or <see cref="BlobAccountSasPermissions"/> can be used to create the
        /// permissions string.
        /// </summary>
        public string Permissions { get; private set; }

        /// <summary>
        /// Specifies an IP address or a range of IP addresses from which to
        /// accept requests. If the IP address from which the request
        /// originates does not match the IP address or address range
        /// specified on the SAS token, the request is not authenticated.
        /// When specifying a range of IP addresses, note that the range is
        /// inclusive.
        /// </summary>
        public SasIPRange IPRange { get; set; }

        /// <summary>
        /// An optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the blob container being made accessible.
        /// </summary>
        public string BlobContainerName { get; set; }

        /// <summary>
        /// The name of the blob being made accessible, or
        /// <see cref="string.Empty"/> for a container SAS.
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// The name of the snapshot being made accessible, or
        /// <see cref="string.Empty"/> for a blob SAS.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// The name of the blob version being made accessible, or
        /// <see cref="string.Empty"/> for a blob SAS.
        /// </summary>
        public string BlobVersionId { get; set; }

        /// <summary>
        /// Specifies which resources are accessible via the shared access
        /// signature.
        ///
        /// Specify "b" if the shared resource is a blob. This grants access to
        /// the content and metadata of the blob.
        ///
        /// Specify "c" if the shared resource is a blob container. This grants
        /// access to the content and metadata of any blob in the container,
        /// and to the list of blobs in the container.
        ///
        /// Beginning in version 2018-11-09, specify "bs" if the shared resource
        /// is a blob snapshot.  This grants access to the content and
        /// metadata of the specific snapshot, but not the corresponding root
        /// blob.
        ///
        /// Beginning in version 2019-12-12, specify "bv" if the shared resource
        /// is a blob version.  This grants access to the content and
        /// metadata of the specific version, but not the corresponding root
        /// blob.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Override the value returned for Cache-Control response header.
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Override the value returned for Content-Disposition response
        /// header.
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// Override the value returned for Cache-Encoding response header.
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Override the value returned for Cache-Language response header.
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// Override the value returned for Cache-Type response header.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Optional. Beginning in version 2020-02-10, this value will be used for
        /// the AAD Object ID of a user authorized by the owner of the
        /// User Delegation Key to perform the action granted by the SAS.
        /// The Azure Storage service will ensure that the owner of the
        /// user delegation key has the required permissions before granting access.
        /// No additional permission check for the user specified in this value will be performed.
        /// This is only used with generating User Delegation SAS.
        /// </summary>
        public string PreauthorizedAgentObjectId { get; set; }

        /// <summary>
        /// Optional. Beginning in version 2020-02-10, this value will be used for
        /// to correlate the storage audit logs with the audit logs used by the
        /// principal generating and distributing SAS. This is only used for
        /// User Delegation SAS.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobSasBuilder"/>
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor has been deprecated. Please consider using
        /// <see cref="BlobSasBuilder(BlobSasPermissions, DateTimeOffset)"/>
        /// to create a Service SAS. This change does not have any impact on how
        /// your application generates or makes use of SAS tokens.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlobSasBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobSasBuilder"/>
        /// class to create a Blob Service Sas.
        /// </summary>
        /// <param name="permissions">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public BlobSasBuilder(BlobSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobSasBuilder"/>
        /// class to create a Blob Container Service Sas.
        /// </summary>
        /// <param name="permissions">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public BlobSasBuilder(BlobContainerSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Sets the permissions for a blob SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="BlobSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(BlobSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a blob account level SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="BlobAccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(BlobAccountSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a blob container SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="BlobContainerSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(BlobContainerSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a Snapshot SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="SnapshotSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(SnapshotSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a Version SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="SnapshotSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(BlobVersionSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for the SAS using a raw permissions string.
        /// </summary>
        /// <param name="rawPermissions">
        /// Raw permissions string for the SAS.
        /// </param>
        /// <param name="normalize">
        /// If the permissions should be validated and correctly ordered.
        /// </param>
        public void SetPermissions(
            string rawPermissions,
            bool normalize = default)
        {
            if (normalize)
            {
                rawPermissions = SasExtensions.ValidateAndSanitizeRawPermissions(
                    permissions: rawPermissions,
                    validPermissionsInOrder: Constants.Sas.ValidPermissionsInOrder);
            }

            SetPermissions(rawPermissions);
        }

        /// <summary>
        /// Sets the permissions for the SAS using a raw permissions string.
        /// </summary>
        /// <param name="rawPermissions">Raw permissions string for the SAS.</param>
        public void SetPermissions(string rawPermissions)
        {
            Permissions = rawPermissions;
        }

        /// <summary>
        /// Use an account's <see cref="StorageSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="StorageSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// The <see cref="BlobSasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        public BlobSasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            EnsureState();

            var startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            var expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // See http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, BlobContainerName ?? String.Empty, BlobName ?? String.Empty),
                Identifier,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                Resource,
                Snapshot ?? BlobVersionId,
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(sharedKeyCredential,stringToSign);

            var p = new BlobSasQueryParameters(
                version: Version,
                services: default,
                resourceTypes: default,
                protocol: Protocol,
                startsOn: StartsOn,
                expiresOn: ExpiresOn,
                ipRange: IPRange,
                identifier: Identifier,
                resource: Resource,
                permissions: Permissions,
                signature: signature,
                cacheControl: CacheControl,
                contentDisposition: ContentDisposition,
                contentEncoding: ContentEncoding,
                contentLanguage: ContentLanguage,
                contentType: ContentType);
            return p;
        }

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="userDelegationKey">
        /// A <see cref="UserDelegationKey"/> returned from
        /// <see cref="Azure.Storage.Blobs.BlobServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// The <see cref="BlobSasQueryParameters"/> used for authenticating requests.
        /// </returns>
        public BlobSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName)
        {
            userDelegationKey = userDelegationKey ?? throw Errors.ArgumentNull(nameof(userDelegationKey));

            EnsureState();

            var startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            var expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);
            var signedStart = SasExtensions.FormatTimesForSasSigning(userDelegationKey.SignedStartsOn);
            var signedExpiry = SasExtensions.FormatTimesForSasSigning(userDelegationKey.SignedExpiresOn);

            // See http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(accountName, BlobContainerName ?? String.Empty, BlobName ?? String.Empty),
                userDelegationKey.SignedObjectId,
                userDelegationKey.SignedTenantId,
                signedStart,
                signedExpiry,
                userDelegationKey.SignedService,
                userDelegationKey.SignedVersion,
                PreauthorizedAgentObjectId,
                null, // AgentObjectId - enabled only in HNS accounts
                CorrelationId,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                Resource,
                Snapshot ?? BlobVersionId,
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = ComputeHMACSHA256(userDelegationKey.Value, stringToSign);

            var p = new BlobSasQueryParameters(
                version: Version,
                services: default,
                resourceTypes: default,
                protocol: Protocol,
                startsOn: StartsOn,
                expiresOn: ExpiresOn,
                ipRange: IPRange,
                identifier: null,
                resource: Resource,
                permissions: Permissions,
                keyOid: userDelegationKey.SignedObjectId,
                keyTid: userDelegationKey.SignedTenantId,
                keyStart: userDelegationKey.SignedStartsOn,
                keyExpiry: userDelegationKey.SignedExpiresOn,
                keyService: userDelegationKey.SignedService,
                keyVersion: userDelegationKey.SignedVersion,
                signature: signature,
                cacheControl: CacheControl,
                contentDisposition: ContentDisposition,
                contentEncoding: ContentEncoding,
                contentLanguage: ContentLanguage,
                contentType: ContentType,
                authorizedAadObjectId: PreauthorizedAgentObjectId,
                correlationId: CorrelationId);
            return p;
        }

        /// <summary>
        /// Computes the canonical name for a container or blob resource for SAS signing.
        /// Container: "/blob/account/containername"
        /// Blob: "/blob/account/containername/blobname"
        /// </summary>
        /// <param name="account">The name of the storage account.</param>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>The canonical resource name.</returns>
        private static string GetCanonicalName(string account, string containerName, string blobName)
            => !String.IsNullOrEmpty(blobName)
               ? $"/blob/{account}/{containerName}/{blobName.Replace("\\", "/")}"
               : $"/blob/{account}/{containerName}";

        /// <summary>
        /// ComputeHMACSHA256 generates a base-64 hash signature string for an
        /// HTTP request or for a SAS.
        /// </summary>
        /// <param name="userDelegationKeyValue">
        /// A <see cref="UserDelegationKey.Value"/> used to sign with a key
        /// representing AD credentials.
        /// </param>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        private static string ComputeHMACSHA256(string userDelegationKeyValue, string message) =>
            Convert.ToBase64String(
                new HMACSHA256(
                    Convert.FromBase64String(userDelegationKeyValue))
                .ComputeHash(Encoding.UTF8.GetBytes(message)));

        /// <summary>
        /// Ensure the <see cref="BlobSasBuilder"/>'s properties are in a
        /// consistent state.
        /// </summary>
        private void EnsureState()
        {
            if (Identifier == default)
            {
                if (ExpiresOn == default)
                {
                    throw Errors.SasMissingData(nameof(ExpiresOn));
                }
                if (string.IsNullOrEmpty(Permissions))
                {
                    throw Errors.SasMissingData(nameof(Permissions));
                }
            }

            // Container
            if (string.IsNullOrEmpty(BlobName))
            {
                Resource = Constants.Sas.Resource.Container;
            }

            // Blob or Snapshot
            else
            {
                // Blob
                if (string.IsNullOrEmpty(Snapshot) && string.IsNullOrEmpty(BlobVersionId))
                {
                    Resource = Constants.Sas.Resource.Blob;
                }
                // Snapshot
                else if (string.IsNullOrEmpty(BlobVersionId))
                {
                    Resource = Constants.Sas.Resource.BlobSnapshot;
                }
                // Blob Version
                else
                {
                    Resource = Constants.Sas.Resource.BlobVersion;
                }
            }
            Version = SasQueryParameters.DefaultSasVersion;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() =>
            base.ToString();

        /// <summary>
        /// Check if two BlobSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the BlobSasBuilder.
        /// </summary>
        /// <returns>Hash code for the BlobSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
