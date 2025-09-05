// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Text;
using Azure.Core;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using static Azure.Storage.Constants.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="QueueSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage queue.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
    /// Create  a Service SAS</see>.
    /// </summary>
    public class QueueSasBuilder
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
        /// stored access policy.  <see cref="QueueSasPermissions"/> and
        /// <see cref="QueueAccountSasPermissions"/> can be used to create the
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
        /// The optional name of the blob being made accessible.
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// Optional. Beginning in version 2025-07-05, this value  specifies the Entra ID of the user would is authorized to
        /// use the resulting SAS URL.  The resulting SAS URL must be used in conjunction with an Entra ID token that has been
        /// issued to the user specified in this value.
        /// </summary>
        public string DelegatedUserObjectId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueSasBuilder"/>
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor has been deprecated. Please consider using
        /// <see cref="QueueSasBuilder(QueueSasPermissions, DateTimeOffset)"/>
        /// to create a Service SAS or
        /// <see cref="QueueSasBuilder(QueueAccountSasPermissions, DateTimeOffset)"/>
        /// to create an Account SAS. This change does not have any impact on how
        /// your application generates or makes use of SAS tokens.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public QueueSasBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueSasBuilder"/>
        /// class.
        /// </summary>
        /// <param name="permissions">
        /// The permissions associated with the shared access signature.
        /// The user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public QueueSasBuilder(QueueSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueSasBuilder"/>
        /// class.
        /// </summary>
        /// <param name="permissions">
        /// The permissions associated with the shared access signature.
        /// The user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        public QueueSasBuilder(QueueAccountSasPermissions permissions, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Sets the permissions for a queue SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="QueueSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(QueueSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for a queue account level SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="QueueAccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(QueueAccountSasPermissions permissions)
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
            Constants.Sas.Permissions.Write,
            Constants.Sas.Permissions.Delete,
            Constants.Sas.Permissions.DeleteBlobVersion,
            Constants.Sas.Permissions.List,
            Constants.Sas.Permissions.Add,
            Constants.Sas.Permissions.Create,
            Constants.Sas.Permissions.Update,
            Constants.Sas.Permissions.Process,
            Constants.Sas.Permissions.Tag,
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
        /// The <see cref="SasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
        /// The <see cref="SasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
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
                resource: null,
                permissions: Permissions,
                signature: signature);
            return p;
        }

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="userDelegationKey">
        /// A <see cref="UserDelegationKey"/> returned from
        /// <see cref="QueueServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// The <see cref="QueueSasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public QueueSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName)
            => ToSasQueryParameters(userDelegationKey, accountName, out _);

        /// <summary>
        /// Use an account's <see cref="UserDelegationKey"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="userDelegationKey">
        /// A <see cref="UserDelegationKey"/> returned from
        /// <see cref="QueueServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the <see cref="SasQueryParameters"/>.
        /// </param>
        /// The <see cref="SasQueryParameters"/> used for authenticating requests.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-queues")]
        public QueueSasQueryParameters ToSasQueryParameters(UserDelegationKey userDelegationKey, string accountName, out string stringToSign)
        {
            userDelegationKey = userDelegationKey ?? throw Errors.ArgumentNull(nameof(userDelegationKey));

            EnsureState();

            stringToSign = ToStringToSign(userDelegationKey, accountName);

            string signature = SasExtensions.ComputeHMACSHA256(userDelegationKey.Value, stringToSign);

            QueueSasQueryParameters p = new QueueSasQueryParameters(
                version: Version,
                services: default,
                resourceTypes: default,
                protocol: Protocol,
                startsOn: StartsOn,
                expiresOn: ExpiresOn,
                ipRange: IPRange,
                identifier: null,
                resource: Resource.Queue,
                permissions: Permissions,
                keyOid: userDelegationKey.SignedObjectId,
                keyTid: userDelegationKey.SignedTenantId,
                keyStart: userDelegationKey.SignedStartsOn,
                keyExpiry: userDelegationKey.SignedExpiresOn,
                keyService: userDelegationKey.SignedService,
                keyVersion: userDelegationKey.SignedVersion,
                delegatedUserObjectId: DelegatedUserObjectId,
                signature: signature);
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
                    GetCanonicalName(accountName, QueueName ?? string.Empty),
                    userDelegationKey.SignedObjectId,
                    userDelegationKey.SignedTenantId,
                    signedStart,
                    signedExpiry,
                    userDelegationKey.SignedService,
                    userDelegationKey.SignedVersion,
                    null, // SignedKeyDelegatedUserTenantId, will be added in a future release.
                    DelegatedUserObjectId,
                    IPRange.ToString(),
                    SasExtensions.ToProtocolString(Protocol),
                    Version);
        }

        /// <summary>
        /// For debugging purposes only.
        /// Returns the string to sign that will be used to generate the signature for the SAS URL.
        /// If you use this method, call it immediately before <see cref="ToSasQueryParameters(StorageSharedKeyCredential)"/>.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="StorageSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// The string to sign that will be used to generate the signature for the SAS URL.
        /// </returns>
        private string ToStringToSign(StorageSharedKeyCredential sharedKeyCredential)
        {
            string startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            string expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            return string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, QueueName ?? string.Empty),
                Identifier,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version);
        }

        /// <summary>
        /// Computes the canonical name for a queue resource for SAS signing.
        /// </summary>
        /// <param name="account">
        /// Account.
        /// </param>
        /// <param name="queueName">
        /// Name of queue.
        /// </param>
        /// <returns>
        /// Canonical name as a string.
        /// </returns>
        private static string GetCanonicalName(string account, string queueName) =>
            // Queue: "/queue/account/queuename"
            string.Join("", new[] { "/queue/", account, "/", queueName });

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the QueueSasBuilder.
        /// </summary>
        /// <returns>Hash code for the QueueSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Ensure the <see cref="QueueSasBuilder"/>'s properties are in a
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

            Version = SasQueryParametersInternals.DefaultSasVersionInternal;
        }

        internal static QueueSasBuilder DeepCopy(QueueSasBuilder originalQueueSasBuilder)
            => new QueueSasBuilder
            {
                Version = originalQueueSasBuilder.Version,
                Protocol = originalQueueSasBuilder.Protocol,
                StartsOn = originalQueueSasBuilder.StartsOn,
                ExpiresOn = originalQueueSasBuilder.ExpiresOn,
                Permissions = originalQueueSasBuilder.Permissions,
                IPRange = originalQueueSasBuilder.IPRange,
                Identifier = originalQueueSasBuilder.Identifier,
                QueueName = originalQueueSasBuilder.QueueName
            };
    }
}
