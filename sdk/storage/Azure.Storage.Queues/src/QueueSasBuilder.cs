// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Common;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// QueueSasBuilder is used to generate a Shared Access Signature (SAS) for an Azure Storage queue.
    /// </summary>
    public struct QueueSasBuilder : IEquatable<QueueSasBuilder>
    {
        public string Version { get; set; }
        public SasProtocol Protocol { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset ExpiryTime { get; set; }
        public string Permissions { get; set; }
        public IPRange IPRange { get; set; }
        public string Identifier { get; set; }
        public string QueueName { get; set; }


        /// <summary>
        /// ToSasQueryParameters uses an account's shared key credential to sign this signature values to produce
        /// the proper SAS query parameters.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// <see cref="SharedKeyCredentials"/>
        /// </param>
        /// <returns>
        /// <see cref="SasQueryParameters"/>
        /// </returns>
        public SasQueryParameters ToSasQueryParameters(SharedKeyCredentials sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            this.Permissions = QueueAccountSasPermissions.Parse(this.Permissions).ToString();
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
                GetCanonicalName(sharedKeyCredential.AccountName, this.QueueName ?? String.Empty),
                this.Identifier,
                this.IPRange.ToString(),
                this.Protocol.ToString(),
                this.Version);
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
                resource: null, 
                permissions: this.Permissions, 
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
        static string GetCanonicalName(string account, string queueName) =>
            // Queue: "/queue/account/queuename"
            String.Join("", new[] { "/queue/", account, "/", queueName });

        public override bool Equals(object obj)
            => obj is QueueSasBuilder other
            && this.Equals(other)
            ;

        /// <summary>
        /// Get a hash code for the QueueSasBuilder.
        /// </summary>
        /// <returns>Hash code for the QueueSasBuilder.</returns>
        public override int GetHashCode()
            => this.ExpiryTime.GetHashCode()
            ^ this.Identifier.GetHashCode()
            ^ this.IPRange.GetHashCode()
            ^ this.Permissions.GetHashCode()
            ^ this.Protocol.GetHashCode()
            ^ this.QueueName.GetHashCode()
            ^ this.StartTime.GetHashCode()
            ^ this.Version.GetHashCode()
            ;

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueSasBuilder left, QueueSasBuilder right) => left.Equals(right);

        /// <summary>
        /// Check if two QueueSasBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>

        public static bool operator !=(QueueSasBuilder left, QueueSasBuilder right) => !(left == right);

        /// <summary>
        /// Check if two QueueSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueSasBuilder other)
            => this.ExpiryTime == other.ExpiryTime
            && this.Identifier == other.Identifier
            && this.IPRange == other.IPRange
            && this.Permissions == other.Permissions
            && this.Protocol == other.Protocol
            && this.QueueName == other.QueueName
            && this.StartTime == other.StartTime
            && this.Version == other.Version
            ;
    }
}
