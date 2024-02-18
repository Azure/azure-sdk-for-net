// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="AccountSasBuilder"/> is used to generate an account level
    /// Shared Access Signature (SAS) for Azure Storage services.
    /// For more information, see
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/constructing-an-account-sas">
    /// Create an account SAS</see>.
    /// </summary>
    public class AccountSasBuilder
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
        /// user is restricted to operations allowed by the permissions. The
        /// <see cref="AccountSasPermissions"/> type can be used to create the
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
        /// The services associated with the shared access signature. The
        /// user is restricted to operations with the specified services.
        /// </summary>
        public AccountSasServices Services { get; set; }

        /// <summary>
        /// The resource types associated with the shared access signature. The
        /// user is restricted to operations on the specified resources.
        /// </summary>
        public AccountSasResourceTypes ResourceTypes { get; set; }

        /// <summary>
        /// Optional.  Encryption scope to use when sending requests authorized with this SAS URI.
        /// </summary>
        public string EncryptionScope { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSasBuilder"/>
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor has been deprecated. Please consider using
        /// <see cref="AccountSasBuilder(AccountSasPermissions, DateTimeOffset, AccountSasServices, AccountSasResourceTypes)"/>
        /// to create a Service SAS. This change does not have any impact on how
        /// your application generates or makes use of SAS tokens.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccountSasBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSasBuilder"/>
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
        /// <param name="services">
        /// Specifies the services accessible from an account level shared access
        /// signature.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types accessible from an account level shared
        /// access signature.
        /// </param>
        public AccountSasBuilder(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasServices services,
            AccountSasResourceTypes resourceTypes)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
            Services = services;
            ResourceTypes = resourceTypes;
        }

        /// <summary>
        /// Sets the permissions for an account SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="AccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(AccountSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for the SAS using a raw permissions string.
        /// </summary>
        /// <param name="rawPermissions">Raw permissions string for the SAS.</param>
        public void SetPermissions(string rawPermissions)
        {
            Permissions = SasExtensions.ValidateAndSanitizeRawPermissions(
                permissions: rawPermissions,
                validPermissionsInOrder: s_validPermissionsInOrder);
        }

        private static readonly List<char> s_validPermissionsInOrder = new List<char>
        {
            Constants.Sas.Permissions.Read,
            Constants.Sas.Permissions.Write,
            Constants.Sas.Permissions.Delete,
            Constants.Sas.Permissions.DeleteBlobVersion,
            Constants.Sas.Permissions.PermanentDelete,
            Constants.Sas.Permissions.List,
            Constants.Sas.Permissions.Add,
            Constants.Sas.Permissions.Create,
            Constants.Sas.Permissions.Update,
            Constants.Sas.Permissions.Process,
            Constants.Sas.Permissions.Tag,
            Constants.Sas.Permissions.FilterByTags,
            Constants.Sas.Permissions.SetImmutabilityPolicy,
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
        /// The <see cref="SasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-common")]
        public SasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/Constructing-an-Account-SAS
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            if (ExpiresOn == default || string.IsNullOrEmpty(Permissions) || ResourceTypes == default || Services == default)
            {
                throw Errors.AccountSasMissingData();
            }

            Version = SasQueryParametersInternals.DefaultSasVersionInternal;

            string startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            string expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            string stringToSign = string.Join("\n",
                sharedKeyCredential.AccountName,
                Permissions,
                Services.ToPermissionsString(),
                ResourceTypes.ToPermissionsString(),
                startTime,
                expiryTime,
                IPRange.ToString(),
                Protocol.ToProtocolString(),
                Version,
                EncryptionScope,
                string.Empty);  // That's right, the account SAS requires a terminating extra newline

            string signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);
            SasQueryParameters p = SasQueryParametersInternals.Create(
                Version,
                Services,
                ResourceTypes,
                Protocol,
                StartsOn,
                ExpiresOn,
                IPRange,
                identifier: null,
                resource: null,
                Permissions,
                signature,
                encryptionScope: EncryptionScope);
            return p;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="AccountSasBuilder"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="AccountSasBuilder"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="AccountSasBuilder"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
