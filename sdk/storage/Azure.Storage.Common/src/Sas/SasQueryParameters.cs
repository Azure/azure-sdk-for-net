//// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// A <see cref="SasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  It includes components used by all Azure Storage resources
    /// (Containers, Blobs, Files, and Queues).  You can construct a new instance
    /// using the service specific SAS builder types.
    /// 
    /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas"/>.
    /// </summary>
    public partial class SasQueryParameters
    {
        /// <summary>
        /// The default service version to use for Shared Access Signatures.
        /// </summary>
        public const string DefaultSasVersion = Constants.DefaultSasVersion;

        /// <summary>
        /// FormatTimesForSASSigning converts a time.Time to a snapshotTimeFormat string suitable for a
        /// SASField's StartTime or ExpiryTime fields. Returns "" if value.IsZero().
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTimesForSasSigning(DateTimeOffset time) =>
            // "yyyy-MM-ddTHH:mm:ssZ"
            (time == new DateTimeOffset()) ? "" : time.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture);

        // All members are immutable or values so copies of this struct are thread safe.

        // sv
        readonly string version;

        // ss
        readonly string services;

        // srt
        readonly string resourceTypes;

        // spr
        readonly SasProtocol protocol;

        // st
        readonly DateTimeOffset startTime;

        // se
        readonly DateTimeOffset expiryTime;

        // sip
        readonly IPRange ipRange;

        // si
        readonly string identifier;

        // sr
        readonly string resource;

        // sp
        readonly string permissions;

        // sig
        readonly string signature;

        /// <summary>
        /// Gets the storage service version to use to authenticate requests
        /// made with this shared access signature, and the service version to
        /// use when handling requests made with this shared access signature.
        /// </summary>
        public string Version => this.version ?? DefaultSasVersion;

        /// <summary>
        /// Gets the signed services accessible with an account level shared
        /// access signature. 
        /// </summary>
        public string Services => this.services ?? String.Empty;

        /// <summary>
        /// Gets which resources are accessible via the shared access signature.
        /// </summary>
        public string ResourceTypes => this.resourceTypes ?? String.Empty;

        /// <summary>
        /// Optional. Specifies the protocol permitted for a request made with
        /// the shared access signature.
        /// </summary>
        public SasProtocol Protocol => this.protocol;

        /// <summary>
        /// Gets the optional time at which the shared access signature becomes
        /// valid.  If omitted, start time for this call is assumed to be the
        /// time when the storage service receives the request.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset StartTime => this.startTime;

        /// <summary>
        /// Gets the time at which the shared access signature becomes invalid.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset ExpiryTime => this.expiryTime;

        /// <summary>
        /// Gets the optional IP address or a range of IP addresses from which
        /// to accept requests.  When specifying a range, note that the range
        /// is inclusive.
        /// </summary>
        public IPRange IPRange => this.ipRange;

        /// <summary>
        /// Gets the optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container, queue,
        /// or share.
        /// </summary>
        public string Identifier => this.identifier ?? String.Empty;

        /// <summary>
        /// Gets the resources are accessible via the shared access signature.
        /// </summary>
        public string Resource => this.resource ?? String.Empty;

        /// <summary>
        /// Gets the permissions associated with the shared access signature.
        /// The user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public string Permissions => this.permissions ?? String.Empty;

        /// <summary>
        /// Gets the string-to-sign, a unique string constructed from the
        /// fields that must be verified in order to authenticate the request.
        /// The signature is an HMAC computed over the string-to-sign and key
        /// using the SHA256 algorithm, and then encoded using Base64 encoding.
        /// </summary>
        public string Signature => this.signature ?? String.Empty;

        #region Blob Only Parameters
        // skoid
        internal readonly string keyObjectId;

        // sktid
        internal readonly string keyTenantId;

        // skt
        internal readonly DateTimeOffset keyStart;

        // ske
        internal readonly DateTimeOffset keyExpiry;

        // sks
        internal readonly string keyService;

        // skv
        internal readonly string keyVersion;
        #endregion Blob Only Parameters

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static SasQueryParameters Empty => new SasQueryParameters();

        // Prevent external instantiation
        internal SasQueryParameters() { }

        /// <summary>
        /// Creates a new instance of the <see cref="SasQueryParameters"/> type.
        /// 
        /// Expects decoded values.
        /// </summary>
        internal SasQueryParameters(
            string version,
            string services,
            string resourceTypes,
            SasProtocol protocol,
            DateTimeOffset startTime,
            DateTimeOffset expiryTime,
            IPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature,
            string keyOid = default,
            string keyTid = default,
            DateTimeOffset keyStart = default,
            DateTimeOffset keyExpiry = default,
            string keyService = default,
            string keyVersion = default)
        {
            // Assume URL-decoded
            this.version = version ?? DefaultSasVersion;
            this.services = services ?? String.Empty;
            this.resourceTypes = resourceTypes ?? String.Empty;
            this.protocol = protocol;
            this.startTime = startTime;
            this.expiryTime = expiryTime;
            this.ipRange = ipRange;
            this.identifier = identifier ?? String.Empty;
            this.resource = resource ?? String.Empty;
            this.permissions = permissions ?? String.Empty;
            this.signature = signature ?? String.Empty;  // Should never be null
            this.keyObjectId = keyOid;
            this.keyTenantId = keyTid;
            this.keyStart = keyStart;
            this.keyExpiry = keyExpiry;
            this.keyService = keyService;
            this.keyVersion = keyVersion;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SasQueryParameters"/> type
        /// based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        /// <param name="includeBlobParameters">
        /// Optional flag indicating whether to process blob-specific query
        /// parameters.  The default value is false.
        /// </param>
        internal SasQueryParameters(
            UriQueryParamsCollection values,
            bool includeBlobParameters = false)
        {
            // make copy, otherwise we'll get an exception when we remove
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray(); ;
            foreach (var kv in kvps)
            {
                // these are already decoded
                var isSasKey = true;
                switch (kv.Key.ToUpperInvariant())
                {
                    case Constants.Sas.Parameters.VersionUpper: this.version = kv.Value; break;
                    case Constants.Sas.Parameters.ServicesUpper: this.services = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceTypesUpper: this.resourceTypes = kv.Value; break;
                    case Constants.Sas.Parameters.ProtocolUpper: this.protocol = SasProtocol.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.StartTimeUpper: this.startTime = DateTimeOffset.ParseExact(kv.Value, Constants.TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.ExpiryTimeUpper: this.expiryTime = DateTimeOffset.ParseExact(kv.Value, Constants.TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.IPRangeUpper: this.ipRange = IPRange.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.IdentifierUpper: this.identifier = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceUpper: this.resource = kv.Value; break;
                    case Constants.Sas.Parameters.PermissionsUpper: this.permissions = kv.Value; break;
                    case Constants.Sas.Parameters.SignatureUpper: this.signature = kv.Value; break;

                    // Optionally include Blob parameters
                    case Constants.Sas.Parameters.KeyOidUpper:
                        if (includeBlobParameters) { this.keyObjectId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyTidUpper:
                        if (includeBlobParameters) { this.keyTenantId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyStartUpper:
                        if (includeBlobParameters) { this.keyStart = DateTimeOffset.ParseExact(kv.Value, Constants.TimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyExpiryUpper:
                        if (includeBlobParameters) { this.keyExpiry = DateTimeOffset.ParseExact(kv.Value, Constants.TimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyServiceUpper:
                        if (includeBlobParameters) { this.keyService = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyVersionUpper:
                        if (includeBlobParameters) { this.keyVersion = kv.Value; }
                        else { isSasKey = false; }
                        break;

                    // We didn't recognize the query parameter
                    default: isSasKey = false; break;
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
        public override string ToString() =>
            this.Encode();

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <param name="includeBlobParameters">
        /// Optional flag indicating whether to encode blob-specific query
        /// parameters.  The default value is false.
        /// </param>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        internal string Encode(bool includeBlobParameters = false)
        {
            var sb = new StringBuilder();

            void AddToBuilder(string key, string value)
                =>
                sb
                .Append(sb.Length > 0 ? "&" : "")
                .Append(key)
                .Append('=')
                .Append(value);

            if (!String.IsNullOrWhiteSpace(this.Version))
            {
                AddToBuilder(Constants.Sas.Parameters.Version, this.Version);
            }

            if (!String.IsNullOrWhiteSpace(this.Services))
            {
                AddToBuilder(Constants.Sas.Parameters.Services, this.Services);
            }

            if (!String.IsNullOrWhiteSpace(this.ResourceTypes))
            {
                AddToBuilder(Constants.Sas.Parameters.ResourceTypes, this.ResourceTypes);
            }

            if (this.Protocol != SasProtocol.None)
            {
                AddToBuilder(Constants.Sas.Parameters.Protocol, this.Protocol.ToString());
            }

            if (this.StartTime != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(this.StartTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture)));
            }

            if (this.ExpiryTime != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(this.ExpiryTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture)));
            }

            var ipr = this.IPRange.ToString();
            if (ipr.Length > 0)
            {
                AddToBuilder(Constants.Sas.Parameters.IPRange, ipr);
            }

            if (!String.IsNullOrWhiteSpace(this.Identifier))
            {
                AddToBuilder(Constants.Sas.Parameters.Identifier, this.Identifier);
            }

            if (!String.IsNullOrWhiteSpace(this.Resource))
            {
                AddToBuilder(Constants.Sas.Parameters.Resource, this.Resource);
            }

            if (!String.IsNullOrWhiteSpace(this.Permissions))
            {
                AddToBuilder(Constants.Sas.Parameters.Permissions, this.Permissions);
            }

            if (includeBlobParameters)
            {
                if (!String.IsNullOrWhiteSpace(this.keyObjectId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyOid, this.keyObjectId);
                }

                if (!String.IsNullOrWhiteSpace(this.keyTenantId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyTid, this.keyTenantId);
                }

                if (this.keyStart != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(this.keyStart.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture)));
                }

                if (this.keyExpiry != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(this.keyExpiry.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture)));
                }

                if (!String.IsNullOrWhiteSpace(this.keyService))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyService, this.keyService);
                }

                if (!String.IsNullOrWhiteSpace(this.keyVersion))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyVersion, this.keyVersion);
                }
            }

            if (!String.IsNullOrWhiteSpace(this.Signature))
            {
                AddToBuilder(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(this.Signature));
            }

            return sb.ToString();
        }
    }
}
