// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ShareSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage share, directory, or file.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
    /// Creating a Service SAS</see>.
    /// </summary>
    public class ShareSasBuilder
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
        /// Specifies which resources are accessible via the shared access
        /// signature.
        ///
        /// Specify "f" if the shared resource is a file. This grants access
        /// to the content and metadata of the file.
        ///
        /// Specify "s" if the shared resource is a share. This grants access
        /// to the content and metadata of any file in the share, and to the
        /// list of directories and files in the share.
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
        /// Optional. Beginning in version 2025-07-05, this value  specifies the Entra ID of the user would is authorized to
        /// use the resulting SAS URL.  The resulting SAS URL must be used in conjunction with an Entra ID token that has been
        /// issued to the user specified in this value.
        /// </summary>
        public string DelegatedUserObjectId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareSasBuilder"/>
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor has been deprecated. Please consider using
        /// <see cref="ShareSasBuilder(ShareSasPermissions, DateTimeOffset)"/>
        /// to create a Service SAS. This change does not have any impact on how
        /// your application generates or makes use of SAS tokens.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShareSasBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareSasBuilder"/>
        /// class to create a Azure File Sas.
        /// </summary>
        /// <param name="permissions">
        /// The permissions associated with the shared access signature. The
        /// user is restricted to operations allowed by the permissions. This
        /// field must be omitted if it has been specified in an associated
        /// stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public ShareSasBuilder(ShareFileSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareSasBuilder"/>
        /// class to create a File Share Sas.
        /// </summary>
        /// <param name="permissions">
        /// The permissions associated with the shared access signature. The
        /// user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public ShareSasBuilder(ShareSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

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
            Constants.Sas.Permissions.Process,
            Constants.Sas.Permissions.FilterByTags,
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
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public SasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
            => ToSasQueryParameters(sharedKeyCredential, out _);

        /// <summary>
        /// Use an account's <see cref="StorageSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="StorageSharedKeyCredential"/>.
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the <see cref="SasQueryParameters"/>.
        /// </param>
        /// <returns>
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public SasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential, out string stringToSign)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            EnsureState();

            stringToSign = ToStringToSign(sharedKeyCredential);

            string signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(sharedKeyCredential, stringToSign);

            SasQueryParameters p = SasQueryParametersInternals.Create(
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

        private string ToStringToSign(StorageSharedKeyCredential sharedKeyCredential)
        {
            string startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            string expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            return string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, ShareName ?? string.Empty, FilePath ?? string.Empty),
                Identifier,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                CacheControl,
                ContentDisposition,
                ContentEncoding,
                ContentLanguage,
                ContentType);
        }

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="userDelegationKey">
        /// A <see cref="UserDelegationKey"/> returned from
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync(DateTimeOffset, ShareGetUserDelegationKeyOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// The <see cref="ShareSasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public ShareSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName)
            => ToSasQueryParameters(userDelegationKey, accountName, out _);

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="userDelegationKey">
        /// A <see cref="UserDelegationKey"/> returned from
        /// <see cref="ShareServiceClient.GetUserDelegationKeyAsync(DateTimeOffset, ShareGetUserDelegationKeyOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the <see cref="SasQueryParameters"/>.
        /// </param>
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-shares")]
        public ShareSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName, out string stringToSign)
        {
            userDelegationKey = userDelegationKey ?? throw Errors.ArgumentNull(nameof(userDelegationKey));

            EnsureState();

            stringToSign = ToStringToSign(userDelegationKey, accountName);

            string signature = SasExtensions.ComputeHMACSHA256(userDelegationKey.Value, stringToSign);

            ShareSasQueryParameters p = new ShareSasQueryParameters(
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
                signature: signature,
                keyOid: userDelegationKey.SignedObjectId,
                keyTid: userDelegationKey.SignedTenantId,
                keyStart: userDelegationKey.SignedStartsOn,
                keyExpiry: userDelegationKey.SignedExpiresOn,
                keyService: userDelegationKey.SignedService,
                keyVersion: userDelegationKey.SignedVersion,
                cacheControl: CacheControl,
                contentDisposition: ContentDisposition,
                contentEncoding: ContentEncoding,
                contentLanguage: ContentLanguage,
                contentType: ContentType,
                delegatedUserObjectId: DelegatedUserObjectId,
                keyDelegatedUserTenantId: userDelegationKey.SignedDelegatedUserTenantId);
            return p;
        }

        private string ToStringToSign(UserDelegationKey userDelegationKey, string accountName)
        {
            string startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            string expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);
            string signedStart = SasExtensions.FormatTimesForSasSigning(userDelegationKey.SignedStartsOn);
            string signedExpiry = SasExtensions.FormatTimesForSasSigning(userDelegationKey.SignedExpiresOn);

            // See http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            return string.Join("\n",
                    Permissions,
                    startTime,
                    expiryTime,
                    GetCanonicalName(accountName, ShareName ?? string.Empty, FilePath ?? string.Empty),
                    userDelegationKey.SignedObjectId,
                    userDelegationKey.SignedTenantId,
                    signedStart,
                    signedExpiry,
                    userDelegationKey.SignedService,
                    userDelegationKey.SignedVersion,
                    userDelegationKey.SignedDelegatedUserTenantId,
                    DelegatedUserObjectId,
                    IPRange.ToString(),
                    SasExtensions.ToProtocolString(Protocol),
                    Version,
                    CacheControl,
                    ContentDisposition,
                    ContentEncoding,
                    ContentLanguage,
                    ContentType);
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

        /// <summary>
        /// Ensure the <see cref="ShareSasBuilder"/>'s properties are in a
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

            if (string.IsNullOrEmpty(FilePath))
            {
                Resource = Constants.Sas.Resource.Share;
            }
            else
            {
                Resource = Constants.Sas.Resource.File;
            }

            Version = SasQueryParametersInternals.DefaultSasVersionInternal;
        }

        internal static ShareSasBuilder DeepCopy(ShareSasBuilder originalShareSasBuilder)
            => new ShareSasBuilder
            {
                Version = originalShareSasBuilder.Version,
                Protocol = originalShareSasBuilder.Protocol,
                StartsOn = originalShareSasBuilder.StartsOn,
                ExpiresOn = originalShareSasBuilder.ExpiresOn,
                Permissions = originalShareSasBuilder.Permissions,
                IPRange = originalShareSasBuilder.IPRange,
                Identifier = originalShareSasBuilder.Identifier,
                ShareName = originalShareSasBuilder.ShareName,
                FilePath = originalShareSasBuilder.FilePath,
                Resource = originalShareSasBuilder.Resource,
                CacheControl = originalShareSasBuilder.CacheControl,
                ContentDisposition = originalShareSasBuilder.ContentDisposition,
                ContentEncoding = originalShareSasBuilder.ContentEncoding,
                ContentLanguage = originalShareSasBuilder.ContentLanguage,
                ContentType = originalShareSasBuilder.ContentType
            };
    }
}
