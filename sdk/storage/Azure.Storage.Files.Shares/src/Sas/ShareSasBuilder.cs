// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ShareSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage share, directory, or file.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas" />.
    /// </summary>
    public class ShareSasBuilder
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
        /// <see cref="SasProtocol.HttpsAndHttp"/>, <see cref="SasProtocol.Https"/>,
        /// and <see cref="SasProtocol.None"/>.
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
        /// stored access policy.  The <see cref="ShareFileSasPermissions"/>,
        /// <see cref="ShareSasPermissions"/>, or <see cref="ShareAccountSasPermissions"/>
        /// can be used to create the permissions string.
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
        /// correlates to an access policy specified for the share.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the share being made accessible.
        /// </summary>
        public string ShareName { get; set; }

        /// <summary>
        /// The path of the file or directory being made accessible, or <see cref="string.Empty"/>
        /// for a share SAS.
        /// </summary>
        public string FilePath { get; set; }

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
        /// <see cref="ShareFileSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(ShareFileSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a file account level SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="ShareAccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(ShareAccountSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a share SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="ShareSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(ShareSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
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
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        public SasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));
            if (ExpiresOn == default)
            {
                throw Errors.SasMissingData(nameof(ExpiresOn));
            }
            if (string.IsNullOrEmpty(Permissions))
            {
                throw Errors.SasMissingData(nameof(Permissions));
            }

            string resource;

            if (string.IsNullOrEmpty(FilePath))
            {
                resource = Constants.Sas.Resource.Share;
            }
            else
            {
                resource = Constants.Sas.Resource.File;
            }

            if (string.IsNullOrEmpty(Version))
            {
                Version = SasQueryParameters.DefaultSasVersion;
            }

            var startTime = SasQueryParameters.FormatTimesForSasSigning(StartsOn);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, ShareName ?? string.Empty, FilePath ?? string.Empty),
                Identifier,
                IPRange.ToString(),
                Protocol.ToProtocolString(),
                Version,
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);

            var p = new SasQueryParameters(
                version: Version,
                services: default,
                resourceTypes: default,
                protocol: Protocol,
                startsOn: StartsOn,
                expiresOn: ExpiresOn,
                ipRange: IPRange,
                identifier: Identifier,
                resource: resource,
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
        /// Computes the canonical name for a share or file resource for SAS signing.
        /// Share: "/file/account/sharename"
        /// File:  "/file/account/sharename/filename"
        /// File:  "/file/account/sharename/directoryname/filename"
        /// </summary>
        /// <param name="account">The name of the storage account.</param>
        /// <param name="shareName">The name of the share.</param>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The canonical resource name.</returns>
        private static string GetCanonicalName(string account, string shareName, string filePath)
            => !string.IsNullOrEmpty(filePath)
               ? $"/file/{account}/{shareName}/{filePath.Replace("\\", "/")}"
               : $"/file/{account}/{shareName}";

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two FileSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the FileSasBuilder.
        /// </summary>
        /// <returns>Hash code for the FileSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
