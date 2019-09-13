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
            (time == new DateTimeOffset()) ? "" : time.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture);

        // All members are immutable or values so copies of this struct are thread safe.

        // sv
        private readonly string version;

        // ss
        private readonly string services;

        // srt
        private readonly string resourceTypes;

        // spr
        private readonly SasProtocol protocol;

        // st
        private readonly DateTimeOffset startTime;

        // se
        private readonly DateTimeOffset expiryTime;

        // sip
        private readonly IPRange ipRange;

        // si
        private readonly string identifier;

        // sr
        private readonly string resource;

        // sp
        private readonly string permissions;

        // sig
        private readonly string signature;

        /// <summary>
        /// Gets the storage service version to use to authenticate requests
        /// made with this shared access signature, and the service version to
        /// use when handling requests made with this shared access signature.
        /// </summary>
        public string Version => version ?? DefaultSasVersion;

        /// <summary>
        /// Gets the signed services accessible with an account level shared
        /// access signature. 
        /// </summary>
        public string Services => services ?? string.Empty;

        /// <summary>
        /// Gets which resources are accessible via the shared access signature.
        /// </summary>
        public string ResourceTypes => resourceTypes ?? string.Empty;

        /// <summary>
        /// Optional. Specifies the protocol permitted for a request made with
        /// the shared access signature.
        /// </summary>
        public SasProtocol Protocol => protocol;

        /// <summary>
        /// Gets the optional time at which the shared access signature becomes
        /// valid.  If omitted, start time for this call is assumed to be the
        /// time when the storage service receives the request.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset StartTime => startTime;

        /// <summary>
        /// Gets the time at which the shared access signature becomes invalid.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset ExpiryTime => expiryTime;

        /// <summary>
        /// Gets the optional IP address or a range of IP addresses from which
        /// to accept requests.  When specifying a range, note that the range
        /// is inclusive.
        /// </summary>
        public IPRange IPRange => ipRange;

        /// <summary>
        /// Gets the optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container, queue,
        /// or share.
        /// </summary>
        public string Identifier => identifier ?? string.Empty;

        /// <summary>
        /// Gets the resources are accessible via the shared access signature.
        /// </summary>
        public string Resource => resource ?? string.Empty;

        /// <summary>
        /// Gets the permissions associated with the shared access signature.
        /// The user is restricted to operations allowed by the permissions.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public string Permissions => permissions ?? string.Empty;

        /// <summary>
        /// Gets the string-to-sign, a unique string constructed from the
        /// fields that must be verified in order to authenticate the request.
        /// The signature is an HMAC computed over the string-to-sign and key
        /// using the SHA256 algorithm, and then encoded using Base64 encoding.
        /// </summary>
        public string Signature => signature ?? string.Empty;

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
            this.services = services ?? string.Empty;
            this.resourceTypes = resourceTypes ?? string.Empty;
            this.protocol = protocol;
            this.startTime = startTime;
            this.expiryTime = expiryTime;
            this.ipRange = ipRange;
            this.identifier = identifier ?? string.Empty;
            this.resource = resource ?? string.Empty;
            this.permissions = permissions ?? string.Empty;
            this.signature = signature ?? string.Empty;  // Should never be null
            keyObjectId = keyOid;
            keyTenantId = keyTid;
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
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                // these are already decoded
                var isSasKey = true;
                switch (kv.Key.ToUpperInvariant())
                {
                    case Constants.Sas.Parameters.VersionUpper: version = kv.Value; break;
                    case Constants.Sas.Parameters.ServicesUpper: services = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceTypesUpper: resourceTypes = kv.Value; break;
                    case Constants.Sas.Parameters.ProtocolUpper: protocol = SasProtocol.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.StartTimeUpper: startTime = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.ExpiryTimeUpper: expiryTime = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.IPRangeUpper: ipRange = IPRange.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.IdentifierUpper: identifier = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceUpper: resource = kv.Value; break;
                    case Constants.Sas.Parameters.PermissionsUpper: permissions = kv.Value; break;
                    case Constants.Sas.Parameters.SignatureUpper: signature = kv.Value; break;

                    // Optionally include Blob parameters
                    case Constants.Sas.Parameters.KeyOidUpper:
                        if (includeBlobParameters) { keyObjectId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyTidUpper:
                        if (includeBlobParameters) { keyTenantId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyStartUpper:
                        if (includeBlobParameters) { keyStart = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyExpiryUpper:
                        if (includeBlobParameters) { keyExpiry = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyServiceUpper:
                        if (includeBlobParameters) { keyService = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyVersionUpper:
                        if (includeBlobParameters) { keyVersion = kv.Value; }
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
            Encode();

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

            if (!string.IsNullOrWhiteSpace(Version))
            {
                AddToBuilder(Constants.Sas.Parameters.Version, Version);
            }

            if (!string.IsNullOrWhiteSpace(Services))
            {
                AddToBuilder(Constants.Sas.Parameters.Services, Services);
            }

            if (!string.IsNullOrWhiteSpace(ResourceTypes))
            {
                AddToBuilder(Constants.Sas.Parameters.ResourceTypes, ResourceTypes);
            }

            if (Protocol != SasProtocol.None)
            {
                AddToBuilder(Constants.Sas.Parameters.Protocol, Protocol.ToString());
            }

            if (StartTime != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(StartTime.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (ExpiryTime != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(ExpiryTime.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            var ipr = IPRange.ToString();
            if (ipr.Length > 0)
            {
                AddToBuilder(Constants.Sas.Parameters.IPRange, ipr);
            }

            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                AddToBuilder(Constants.Sas.Parameters.Identifier, Identifier);
            }

            if (!string.IsNullOrWhiteSpace(Resource))
            {
                AddToBuilder(Constants.Sas.Parameters.Resource, Resource);
            }

            if (!string.IsNullOrWhiteSpace(Permissions))
            {
                AddToBuilder(Constants.Sas.Parameters.Permissions, Permissions);
            }

            if (includeBlobParameters)
            {
                if (!string.IsNullOrWhiteSpace(keyObjectId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyOid, keyObjectId);
                }

                if (!string.IsNullOrWhiteSpace(keyTenantId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyTid, keyTenantId);
                }

                if (keyStart != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(keyStart.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (keyExpiry != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(keyExpiry.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (!string.IsNullOrWhiteSpace(keyService))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyService, keyService);
                }

                if (!string.IsNullOrWhiteSpace(keyVersion))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyVersion, keyVersion);
                }
            }

            if (!string.IsNullOrWhiteSpace(Signature))
            {
                AddToBuilder(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(Signature));
            }

            return sb.ToString();
        }
    }
}
