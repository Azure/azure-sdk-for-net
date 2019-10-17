﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="QueueSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage queue.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas" />.
    /// </summary>
    public struct QueueSasBuilder : IEquatable<QueueSasBuilder>
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
        /// stored access policy.  <see cref="QueueSasPermissions"/> and
        /// <see cref="QueueAccountSasPermissions"/> can be used to create the
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
        /// The optional name of the blob being made accessible.
        /// </summary>
        public string QueueName { get; set; }

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
        public SasQueryParameters ToSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            Permissions = QueueAccountSasPermissions.Parse(Permissions).ToString();
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
                GetCanonicalName(sharedKeyCredential.AccountName, QueueName ?? string.Empty),
                Identifier,
                IPRange.ToString(),
                Protocol.ToProtocolString(),
                Version);
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
                resource: null,
                permissions: Permissions,
                signature: signature);
            return p;
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
        public override string ToString() =>
            base.ToString();

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is QueueSasBuilder other && Equals(other);

        /// <summary>
        /// Get a hash code for the QueueSasBuilder.
        /// </summary>
        /// <returns>Hash code for the QueueSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            ExpiresOn.GetHashCode() ^
            Identifier.GetHashCode() ^
            IPRange.GetHashCode() ^
            Permissions.GetHashCode() ^
            Protocol.GetHashCode() ^
            QueueName.GetHashCode() ^
            StartsOn.GetHashCode() ^
            Version.GetHashCode();

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueSasBuilder left, QueueSasBuilder right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two QueueSasBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>

        public static bool operator !=(QueueSasBuilder left, QueueSasBuilder right) =>
            !(left == right);

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueSasBuilder other) =>
            ExpiresOn == other.ExpiresOn &&
            Identifier == other.Identifier &&
            IPRange == other.IPRange &&
            Permissions == other.Permissions &&
            Protocol == other.Protocol &&
            QueueName == other.QueueName &&
            StartsOn == other.StartsOn &&
            Version == other.Version;
    }
}
