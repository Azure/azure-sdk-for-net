// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Storage.Common;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="FileSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage share, directory, or file.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas" />.
    /// </summary>
    public struct FileSasBuilder : IEquatable<FileSasBuilder>
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
        /// stored access policy.  The <see cref="FileSasPermissions"/>
        /// and <see cref="ShareSasPermissions"/>
        /// can be used to create the permissions string.
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

            string resource;

            if (string.IsNullOrEmpty(FilePath))
            {
                // Make sure the permission characters are in the correct order
                Permissions = ShareSasPermissions.Parse(Permissions).ToString();
                resource = Constants.Sas.Resource.Share;
            }
            else
            {
                // Make sure the permission characters are in the correct order
                Permissions = FileSasPermissions.Parse(Permissions).ToString();
                resource = Constants.Sas.Resource.File;
            }

            if (string.IsNullOrEmpty(Version))
            {
                Version = SasQueryParameters.DefaultSasVersion;
            }

            var startTime = SasQueryParameters.FormatTimesForSasSigning(StartTime);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(ExpiryTime);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, ShareName ?? string.Empty, FilePath ?? string.Empty),
                Identifier,
                IPRange.ToString(),
                Protocol.ToString(),
                Version,
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);

            var signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);

            var p = new SasQueryParameters(
                version: Version,
                services: null,
                resourceTypes: null,
                protocol: Protocol,
                startTime: StartTime,
                expiryTime: ExpiryTime,
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
        public override string ToString() =>
            base.ToString();

        /// <summary>
        /// Check if two FileSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is FileSasBuilder other && Equals(other);

        /// <summary>
        /// Get a hash code for the FileSasBuilder.
        /// </summary>
        /// <returns>Hash code for the FileSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
            => CacheControl.GetHashCode()
            ^ ContentDisposition.GetHashCode()
            ^ ContentEncoding.GetHashCode()
            ^ ContentLanguage.GetHashCode()
            ^ ContentType.GetHashCode()
            ^ ExpiryTime.GetHashCode()
            ^ FilePath.GetHashCode()
            ^ Identifier.GetHashCode()
            ^ IPRange.GetHashCode()
            ^ Permissions.GetHashCode()
            ^ Protocol.GetHashCode()
            ^ ShareName.GetHashCode()
            ^ StartTime.GetHashCode()
            ^ Version.GetHashCode()
            ;

        /// <summary>
        /// Check if two FileSasBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(FileSasBuilder left, FileSasBuilder right) => left.Equals(right);

        /// <summary>
        /// Check if two FileSasBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(FileSasBuilder left, FileSasBuilder right) => !(left == right);

        /// <summary>
        /// Check if two FileSasBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(FileSasBuilder other)
            => CacheControl == other.CacheControl
            && ContentDisposition == other.ContentDisposition
            && ContentEncoding == other.ContentEncoding
            && ContentLanguage == other.ContentEncoding
            && ContentType == other.ContentType
            && ExpiryTime == other.ExpiryTime
            && FilePath == other.FilePath
            && Identifier == other.Identifier
            && IPRange == other.IPRange
            && Permissions == other.Permissions
            && Protocol == other.Protocol
            && ShareName == other.ShareName
            && StartTime == other.StartTime
            && Version == other.Version
            ;
    }
}
