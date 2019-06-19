// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Common;

namespace Azure.Storage.Files
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
        /// The path of the file or directory being made accessible, or <see cref="String.Empty"/>
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
        /// Use an account's <see cref="SharedKeyCredentials"/> to sign this 
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="SharedKeyCredentials"/>.
        /// </param>
        /// <returns>
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        public SasQueryParameters ToSasQueryParameters(SharedKeyCredentials sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            string resource;

            if (String.IsNullOrEmpty(this.FilePath))
            {
                // Make sure the permission characters are in the correct order
                this.Permissions = ShareSasPermissions.Parse(this.Permissions).ToString();
                resource = Constants.Sas.Resource.Share;
            }
            else
            {
                // Make sure the permission characters are in the correct order
                this.Permissions = FileSasPermissions.Parse(this.Permissions).ToString();
                resource = Constants.Sas.Resource.File;
            }

            if (String.IsNullOrEmpty(this.Version))
            {
                this.Version = SasQueryParameters.SasVersion;
            }

            var startTime = SasQueryParameters.FormatTimesForSasSigning(this.StartTime);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(this.ExpiryTime);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                this.Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, this.ShareName ?? String.Empty, this.FilePath ?? String.Empty),
                this.Identifier,
                this.IPRange.ToString(),
                this.Protocol.ToString(),
                this.Version,
                this.CacheControl,       
                this.ContentDisposition, 
                this.ContentEncoding,    
                this.ContentLanguage,    
                this.ContentType);       

            var signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);

            var p = new SasQueryParameters(
                version: this.Version,
                services: null,
                resourceTypes: null,
                protocol: this.Protocol,
                startTime: this.StartTime,
                expiryTime: this.ExpiryTime,
                ipRange: this.IPRange,
                identifier: this.Identifier,
                resource: resource, 
                permissions: this.Permissions, 
                signature: signature);
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
        static string GetCanonicalName(string account, string shareName, string filePath)
            => !String.IsNullOrEmpty(filePath)
               ? $"/file/{account}/{shareName}/{filePath.Replace("\\", "/")}"
               : $"/file/{account}/{shareName}";

        /// <summary>
        /// Check if two FileSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is FileSasBuilder other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the FileSasBuilder.
        /// </summary>
        /// <returns>Hash code for the FileSasBuilder.</returns>
        public override int GetHashCode()
            => this.CacheControl.GetHashCode()
            ^ this.ContentDisposition.GetHashCode()
            ^ this.ContentEncoding.GetHashCode()
            ^ this.ContentLanguage.GetHashCode()
            ^ this.ContentType.GetHashCode()
            ^ this.ExpiryTime.GetHashCode()
            ^ this.FilePath.GetHashCode()
            ^ this.Identifier.GetHashCode()
            ^ this.IPRange.GetHashCode()
            ^ this.Permissions.GetHashCode()
            ^ this.Protocol.GetHashCode()
            ^ this.ShareName.GetHashCode()
            ^ this.StartTime.GetHashCode()
            ^ this.Version.GetHashCode()
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
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(FileSasBuilder other)
            => this.CacheControl == other.CacheControl
            && this.ContentDisposition == other.ContentDisposition
            && this.ContentEncoding == other.ContentEncoding
            && this.ContentLanguage == other.ContentEncoding
            && this.ContentType == other.ContentType
            && this.ExpiryTime == other.ExpiryTime
            && this.FilePath == other.FilePath
            && this.Identifier == other.Identifier
            && this.IPRange == other.IPRange
            && this.Permissions == other.Permissions
            && this.Protocol == other.Protocol
            && this.ShareName == other.ShareName
            && this.StartTime == other.StartTime
            && this.Version == other.Version
            ;
    }
}
