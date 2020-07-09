// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// A <see cref="TableSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="TableSasBuilder"/>.
    ///
    /// For more information, <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">Create a service SAS</see>.
    /// </summary>
    public sealed class TableSasQueryParameters //: SasQueryParameters
    {
        // sv
        private readonly string _version;
        // spr
        private readonly SasProtocol _protocol;

        // st
        private DateTimeOffset _startTime;

        // se
        private DateTimeOffset _expiryTime;

        // sip
        private readonly SasIPRange _ipRange;

        // si
        private readonly string _identifier;

        // sr
        private readonly string _resource;

        // sp
        private readonly string _permissions;

        // sig
        private readonly string _signature;

        internal string TableName { get; set; }

        /// <summary>
        /// The default service version to use for Shared Access Signatures.
        /// </summary>
        public const string DefaultSasVersion = TableConstants.Sas.DefaultSasVersion;

        /// <summary>
        /// The start of PartionKey range.
        /// </summary>
        public string StartPartitionKey { get; set; }

        /// <summary>
        /// The end of PartionKey range.
        /// </summary>
        public string StartRowKey { get; set; }

        /// <summary>
        /// The start of RowKey range.
        /// </summary>
        public string EndPartitionKey { get; set; }

        /// <summary>
        /// The end of RowKey range.
        /// </summary>
        public string EndRowKey { get; set; }

        /// <summary>
        /// Gets the storage service version to use to authenticate requests
        /// made with this shared access signature, and the service version to
        /// use when handling requests made with this shared access signature.
        /// </summary>
        public string Version => _version ?? TableConstants.Sas.DefaultSasVersion;

        /// <summary>
        /// Optional. Specifies the protocol permitted for a request made with
        /// the shared access signature.
        /// </summary>
        public SasProtocol Protocol => _protocol;

        /// <summary>
        /// Gets the optional time at which the shared access signature becomes
        /// valid.  If omitted, start time for this call is assumed to be the
        /// time when the storage service receives the request.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset StartsOn => _startTime;

        /// <summary>
        /// Gets the time at which the shared access signature becomes invalid.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset ExpiresOn => _expiryTime;
        /// <summary>
        /// Gets the optional IP address or a range of IP addresses from which
        /// to accept requests.  When specifying a range, note that the range
        /// is inclusive.
        /// </summary>
        public SasIPRange IPRange => _ipRange;

        /// <summary>
        /// Gets the optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the blob container, queue,
        /// or share.
        /// </summary>
        public string Identifier => _identifier ?? string.Empty;

        /// <summary>
        /// Gets the resources are accessible via the shared access signature.
        /// </summary>
        public string Resource => _resource ?? string.Empty;

        /// <summary>
        /// Gets the permissions associated with the shared access signature.
        /// The user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public string Permissions => _permissions ?? string.Empty;

        /// <summary>
        /// The signature is an HMAC computed over the string-to-sign and key
        /// using the SHA256 algorithm, and then encoded using Base64 encoding.
        /// </summary>
        public string Signature => _signature ?? string.Empty;

        public static TableSasQueryParameters Empty => new TableSasQueryParameters();

        internal TableSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new TableSasQueryParameters instance.
        /// </summary>
        internal TableSasQueryParameters(
            string version,
            string tableName,
            string partitionKeyStart,
            string rowKeyStart,
            string partitionKeyEnd,
            string rowKeyEnd,
            SasProtocol protocol,
            DateTimeOffset startsOn,
            DateTimeOffset expiresOn,
            SasIPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature)
        {
            TableName = tableName;
            StartPartitionKey = partitionKeyStart;
            EndPartitionKey = partitionKeyEnd;
            StartRowKey = rowKeyStart;
            EndRowKey = rowKeyEnd;
            _version = version;
            _protocol = protocol;
            _startTime = startsOn;
            _expiryTime = expiresOn;
            _ipRange = ipRange;
            _identifier = identifier;
            _resource = resource;
            _permissions = permissions;
            _signature = signature;

        }

        /// <summary>
        /// Creates a new instance of the <see cref="TableSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal TableSasQueryParameters(
            IDictionary<string, string> values)
        {
            // make copy, otherwise we'll get an exception when we remove
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray();
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                // these are already decoded
                var isSasKey = true;
                switch (kv.Key.ToUpperInvariant())
                {
                    case TableConstants.Sas.Parameters.VersionUpper:
                        _version = kv.Value;
                        break;
                    case TableConstants.Sas.Parameters.ProtocolUpper:
                        _protocol = SasExtensions.ParseProtocol(kv.Value);
                        break;
                    case TableConstants.Sas.Parameters.StartTimeUpper:
                        _startTime = DateTimeOffset.ParseExact(kv.Value, TableConstants.Sas.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case TableConstants.Sas.Parameters.ExpiryTimeUpper:
                        _expiryTime = DateTimeOffset.ParseExact(kv.Value, TableConstants.Sas.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case TableConstants.Sas.Parameters.IPRangeUpper:
                        _ipRange = SasIPRange.Parse(kv.Value);
                        break;
                    case TableConstants.Sas.Parameters.IdentifierUpper:
                        _identifier = kv.Value;
                        break;
                    case TableConstants.Sas.Parameters.ResourceUpper:
                        _resource = kv.Value;
                        break;
                    case TableConstants.Sas.Parameters.PermissionsUpper:
                        _permissions = kv.Value;
                        break;
                    case TableConstants.Sas.Parameters.SignatureUpper:
                        _signature = kv.Value;
                        break;

                    // We didn't recognize the query parameter
                    default:
                        isSasKey = false;
                        break;
                }

                // Remove the query parameter if it's part of the SAS
                if (isSasKey)
                {
                    values.Remove(kv.Key);
                }
            }
        }

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendQueryParameter(TableConstants.Sas.Parameters.TableName, TableName);
            if (!string.IsNullOrWhiteSpace(StartPartitionKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.StartPartitionKey, StartPartitionKey);
            }
            if (!string.IsNullOrWhiteSpace(EndPartitionKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.EndPartitionKey, EndPartitionKey);
            }
            if (!string.IsNullOrWhiteSpace(StartRowKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.StartRowKey, StartRowKey);
            }
            if (!string.IsNullOrWhiteSpace(EndRowKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.EndRowKey, EndRowKey);
            }
            this.AppendProperties(sb);
            return sb.ToString();
        }
    }
}
