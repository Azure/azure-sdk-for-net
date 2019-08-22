// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage container or blob.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas" />.
    /// </summary>
    public struct BlobSasBuilder : IEquatable<BlobSasBuilder>
    {
        /// <summary>
        /// The storage service version to use to authenticate requests made
        /// with this shared access signature, and the service version to use
        /// when handling requests made with this shared access signature.
        /// </summary>
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
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// The permissions associated with the shared access signature. The
        /// user is restricted to operations allowed by the permissions. This
        /// field must be omitted if it has been specified in an associated
        /// stored access policy.  The <see cref="BlobSasPermissions"/>,
        /// <see cref="ContainerSasPermissions"/>, and
        /// <see cref="SnapshotSasPermissions"/> can be used to create the
        /// permissions string.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Specifies an IP address or a range of IP addresses from which to
        /// accept requests. If the IP address from which the request
        /// originates does not match the IP address or address range
        /// specified on the SAS token, the request is not authenticated.
        /// When specifying a range of IP addresses, note that the range is
        /// inclusive.
        /// </summary>
        public IPRange IPRange { get; set; }

        /// <summary>
        /// An optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the container being made accessible.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// The name of the blob being made accessible, or
        /// <see cref="String.Empty"/> for a container SAS.
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// The name of the snapshot being made accessible, or
        /// <see cref="String.Empty"/> for a blob SAS.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// Specifies which resources are accessible via the shared access
        /// signature.
        ///
        /// Specify b if the shared resource is a blob. This grants access to
        /// the content and metadata of the blob.
        ///
        /// Specify c if the shared resource is a container. This grants
        /// access to the content and metadata of any blob in the container,
        /// and to the list of blobs in the container.
        ///
        /// Beginning in version 2018-11-09, specify bs if the shared resource
        /// is a blob snapshot.  This grants access to the content and
        /// metadata of the specific snapshot, but not the corresponding root
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

            this.EnsureState();

            var startTime = SasQueryParameters.FormatTimesForSasSigning(this.StartTime);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(this.ExpiryTime);

            // See http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                this.Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, this.ContainerName ?? String.Empty, this.BlobName ?? String.Empty),
                this.Identifier,
                this.IPRange.ToString(),
                this.Protocol.ToString(),
                this.Version,
                this.Resource,
                this.Snapshot,
                this.CacheControl,
                this.ContentDisposition,
                this.ContentEncoding,
                this.ContentLanguage,
                this.ContentType);

            var signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);

            var p = new BlobSasQueryParameters(
                version: this.Version,
                services: null,
                resourceTypes: null,
                protocol: this.Protocol,
                startTime: this.StartTime,
                expiryTime: this.ExpiryTime,
                ipRange: this.IPRange,
                identifier: this.Identifier,
                resource: this.Resource,
                permissions: this.Permissions,
                signature: signature);
            return p;
        }

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the propery SAS query
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

            this.EnsureState();

            var startTime = SasQueryParameters.FormatTimesForSasSigning(this.StartTime);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(this.ExpiryTime);
            var signedStart = SasQueryParameters.FormatTimesForSasSigning(userDelegationKey.SignedStart);
            var signedExpiry = SasQueryParameters.FormatTimesForSasSigning(userDelegationKey.SignedExpiry);

            // See http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                this.Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(accountName, this.ContainerName ?? String.Empty, this.BlobName ?? String.Empty),
                userDelegationKey.SignedOid,
                userDelegationKey.SignedTid,
                signedStart,
                signedExpiry,
                userDelegationKey.SignedService,
                userDelegationKey.SignedVersion,
                this.IPRange.ToString(),
                this.Protocol.ToString(),
                this.Version,
                this.Resource,
                this.Snapshot,
                this.CacheControl,
                this.ContentDisposition,
                this.ContentEncoding,
                this.ContentLanguage,
                this.ContentType);

            var signature = ComputeHMACSHA256(userDelegationKey.Value, stringToSign);

            var p = new BlobSasQueryParameters(
                version: this.Version,
                services: null,
                resourceTypes: null,
                protocol: this.Protocol,
                startTime: this.StartTime,
                expiryTime: this.ExpiryTime,
                ipRange: this.IPRange,
                identifier: null,
                resource: this.Resource,
                permissions: this.Permissions,
                keyOid: userDelegationKey.SignedOid,
                keyTid: userDelegationKey.SignedTid,
                keyStart: userDelegationKey.SignedStart,
                keyExpiry: userDelegationKey.SignedExpiry,
                keyService: userDelegationKey.SignedService,
                keyVersion: userDelegationKey.SignedVersion,
                signature: signature);
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
        static string GetCanonicalName(string account, string containerName, string blobName)
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
        static string ComputeHMACSHA256(string userDelegationKeyValue, string message) =>
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
            // Container
            if (String.IsNullOrEmpty(this.BlobName))
            {
                // Make sure the permission characters are in the correct order
                this.Permissions = ContainerSasPermissions.Parse(this.Permissions).ToString();
                this.Resource = Constants.Sas.Resource.Container;
            }

            // Blob or Snapshot
            else
            {
                // Blob
                if (String.IsNullOrEmpty(this.Snapshot))
                {
                    // Make sure the permission characters are in the correct order
                    this.Permissions = BlobSasPermissions.Parse(this.Permissions).ToString();
                    this.Resource = Constants.Sas.Resource.Blob;
                }
                // Snapshot
                else
                {
                    // Make sure the permission characters are in the correct order
                    this.Permissions = SnapshotSasPermissions.Parse(this.Permissions).ToString();
                    this.Resource = Constants.Sas.Resource.BlobSnapshot;
                }

            }
            if (String.IsNullOrEmpty(this.Version))
            {
                this.Version = SasQueryParameters.DefaultSasVersion;
            }
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
            => obj is BlobSasBuilder other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobSasBuilder.
        /// </summary>
        /// <returns>Hash code for the BlobSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            this.BlobName.GetHashCode() ^
            this.CacheControl.GetHashCode() ^
            this.ContainerName.GetHashCode() ^
            this.ContentDisposition.GetHashCode() ^
            this.ContentEncoding.GetHashCode() ^
            this.ContentLanguage.GetHashCode() ^
            this.ContentType.GetHashCode() ^
            this.ExpiryTime.GetHashCode() ^
            this.Identifier.GetHashCode() ^
            this.IPRange.GetHashCode() ^
            this.Permissions.GetHashCode() ^
            this.Protocol.GetHashCode() ^
            this.StartTime.GetHashCode() ^
            this.Version.GetHashCode();

        /// <summary>
        /// Check if two BlobSasBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobSasBuilder left, BlobSasBuilder right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two BlobSasBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobSasBuilder left, BlobSasBuilder right) =>
            !(left == right);

        /// <summary>
        /// Check if two BlobSasBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobSasBuilder other) =>
            this.BlobName == other.BlobName &&
            this.CacheControl == other.CacheControl &&
            this.ContainerName == other.ContainerName &&
            this.ContentDisposition == other.ContentDisposition &&
            this.ContentEncoding == other.ContentEncoding &&
            this.ContentLanguage == other.ContentEncoding &&
            this.ContentType == other.ContentType &&
            this.ExpiryTime == other.ExpiryTime &&
            this.Identifier == other.Identifier &&
            this.IPRange == other.IPRange &&
            this.Permissions == other.Permissions &&
            this.Protocol == other.Protocol &&
            this.StartTime == other.StartTime &&
            this.Version == other.Version;
    }
}
