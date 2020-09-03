// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="DataLakeSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for a Data Lake file system or path
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
    /// Constructing a Service SAS</see>.
    /// </summary>
    public class DataLakeSasBuilder
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
        /// stored access policy.  The <see cref="DataLakeSasPermissions"/>,
        /// <see cref="DataLakeFileSystemSasPermissions"/>
        /// or <see cref="DataLakeAccountSasPermissions"/> can be used to create the
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
        /// correlates to an access policy specified for the file system.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the file system being made accessible.
        /// </summary>
        public string FileSystemName { get; set; }

        /// <summary>
        /// The name of the path being made accessible, or
        /// <see cref="String.Empty"/> for a file system SAS.
        /// </summary>
        public string Path { get; set; }

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
        /// Sets the permissions for a file SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="DataLakeSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(DataLakeSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a path account level SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="DataLakeAccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(DataLakeAccountSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a file system SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="DataLakeFileSystemSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(DataLakeFileSystemSasPermissions permissions)
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
                    validPermissionsInOrder: s_validPermissionsInOrder);
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

        private static readonly List<char> s_validPermissionsInOrder = new List<char>
        {
            Constants.Sas.Permissions.Read,
            Constants.Sas.Permissions.Add,
            Constants.Sas.Permissions.Create,
            Constants.Sas.Permissions.Write,
            Constants.Sas.Permissions.Delete,
            Constants.Sas.Permissions.DeleteBlobVersion,
            Constants.Sas.Permissions.List,
            Constants.Sas.Permissions.Tag,
            Constants.Sas.Permissions.Update,
            Constants.Sas.Permissions.Process
        };

        /// <summary>
        /// Use an account's <see cref="StorageSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="StorageSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DataLakeSasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        public DataLakeSasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
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
                GetCanonicalName(sharedKeyCredential.AccountName, FileSystemName ?? String.Empty, Path ?? String.Empty),
                Identifier,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                Resource,
                null, // snapshot
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(sharedKeyCredential, stringToSign);

            var p = new DataLakeSasQueryParameters(
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
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// The <see cref="DataLakeSasQueryParameters"/> used for authenticating requests.
        /// </returns>
        public DataLakeSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName)
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
                GetCanonicalName(accountName, FileSystemName ?? String.Empty, Path ?? String.Empty),
                userDelegationKey.SignedObjectId,
                userDelegationKey.SignedTenantId,
                signedStart,
                signedExpiry,
                userDelegationKey.SignedService,
                userDelegationKey.SignedVersion,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                Resource,
                null, // snapshot
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = ComputeHMACSHA256(userDelegationKey.Value, stringToSign);

            var p = new DataLakeSasQueryParameters(
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
                contentType: ContentType);
            return p;
        }

        /// <summary>
        /// Computes the canonical name for a container or blob resource for SAS signing.
        /// Container: "/blob/account/containername"
        /// Blob: "/blob/account/containername/blobname"
        /// </summary>
        /// <param name="account">The name of the storage account.</param>
        /// <param name="fileSystemName">The name of the container.</param>
        /// <param name="path">The name of the blob.</param>
        /// <returns>The canonical resource name.</returns>
        private static string GetCanonicalName(string account, string fileSystemName, string path)
            => !String.IsNullOrEmpty(path)
               ? $"/blob/{account}/{fileSystemName}/{path.Replace("\\", "/")}"
               : $"/blob/{account}/{fileSystemName}";

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
        /// Ensure the <see cref="DataLakeSasBuilder"/>'s properties are in a
        /// consistent state.
        /// </summary>
        internal void EnsureState()
        {
            // Identifier is not present
            if (string.IsNullOrEmpty(Identifier))
            {
                if (string.IsNullOrEmpty(Permissions))
                {
                    throw Errors.SasMissingData(nameof(Permissions));
                }

                if (ExpiresOn == default)
                {
                    throw Errors.SasMissingData(nameof(ExpiresOn));
                }
            }

            // File System
            if (string.IsNullOrEmpty(Path))
            {
                Resource = Constants.Sas.Resource.Container;
            }

            // Path
            else
            {
                Resource = Constants.Sas.Resource.Blob;
            }
            if (string.IsNullOrEmpty(Version))
            {
                Version = SasQueryParameters.DefaultSasVersion;
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
            => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the BlobSasBuilder.
        /// </summary>
        /// <returns>Hash code for the BlobSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
