// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Storage.Common;

#if BlobSDK
namespace Azure.Storage.Blobs
{
#elif QueueSDK
namespace Azure.Storage.Queues 
{
#elif FileSDK
namespace Azure.Storage.Files
{
#endif
    /// <summary>
    /// A SasQueryParameters object represents the components that make up an Azure Storage SAS' query parameters.
    /// You parse a map of query parameters into its fields by calling NewSasQueryParameters(). You add the components
    /// to a query parameter map by calling AddToValues().
    /// NOTE: Changing any field requires computing a new SAS signature using a XxxSASSignatureValues type.
    ///
    /// This type defines the components used by all Azure Storage resources (Containers, Blobs, Files, & Queues).
    /// See https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas
    /// </summary>
    public sealed partial class SasQueryParameters
    {
        // SASVersion indicates the SAS version.
        public const string SasVersion = "2018-11-09";

        // SASTimeFormat represents the format of a SAS start or expiry time. Use it when formatting/parsing a time.Time.
        // ISO 8601 uses "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
        const string TimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// FormatTimesForSASSigning converts a time.Time to a snapshotTimeFormat string suitable for a
        /// SASField's StartTime or ExpiryTime fields. Returns "" if value.IsZero().
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTimesForSasSigning(DateTimeOffset time) =>
            // "yyyy-MM-ddTHH:mm:ssZ"
            (time == new DateTimeOffset()) ? "" : time.ToString(TimeFormat, CultureInfo.InvariantCulture); 

        // All members are immutable or values so copies of this struct are thread safe.

        // sv
        readonly string version;

        // ss
        readonly string services;    

        // srt
        readonly string resourceTypes;

        // Use auto property
#pragma warning disable IDE0032

        // spr
        readonly SasProtocol protocol;

        // st
        readonly DateTimeOffset startTime;

        // se
        readonly DateTimeOffset expiryTime;

        // sip
        readonly IPRange ipRange;

        // Use auto property
#pragma warning restore IDE0032 

        // si
        readonly string identifier;

        // sr
        readonly string resource;

        // sp
        readonly string permissions;

        // sig
        readonly string signature;

#if BlobSDK
#pragma warning disable IDE0032 // Use auto property
        readonly string keyOid;
        readonly string keyTid;
        readonly DateTimeOffset keyStart;
        readonly DateTimeOffset keyExpiry;
        readonly string keyService;
        readonly string keyVersion;
#pragma warning restore IDE0032 // Use auto property
#endif

        public string Version => this.version ?? SasVersion;
        public string Services => this.services ?? String.Empty;
        public string ResourceTypes => this.resourceTypes ?? String.Empty;
        public SasProtocol Protocol => this.protocol;
        // DateTimeOffset.MinValue means not set
        public DateTimeOffset StartTime => this.startTime;
        // DateTimeOffset.MinValue means not set
        public DateTimeOffset ExpiryTime => this.expiryTime;
        public IPRange IPRange => this.ipRange;
        public string Identifier => this.identifier ?? String.Empty;
        public string Resource => this.resource ?? String.Empty;
        public string Permissions => this.permissions ?? String.Empty;
        public string Signature => this.signature ?? String.Empty;

#if BlobSDK
        public string KeyOid => this.keyOid;
        public string KeyTid => this.keyTid;
        public DateTimeOffset KeyStart => this.keyStart;
        public DateTimeOffset KeyExpiry => this.keyExpiry;
        public string KeyService => this.keyService;
        public string KeyVersion => this.keyVersion;
#endif

        public static SasQueryParameters Empty => new SasQueryParameters();

        SasQueryParameters() { }

        /// <summary>
        /// Takes decoded values
        /// </summary>
        /// <param name="version"></param>
        /// <param name="services"></param>
        /// <param name="resourceTypes"></param>
        /// <param name="protocol"></param>
        /// <param name="startTime"></param>
        /// <param name="expiryTime"></param>
        /// <param name="ipRange"></param>
        /// <param name="identifier"></param>
        /// <param name="resource"></param>
        /// <param name="permissions"></param>
        /// <param name="signature"></param>
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
            string signature
#if BlobSDK
            , string keyOid = default,
            string keyTid = default,
            DateTimeOffset keyStart = default,
            DateTimeOffset keyExpiry = default,
            string keyService = default,
            string keyVersion = default
#endif
            )
        {
            // assume URL-decoded
            this.version = version ?? SasVersion;
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
#if BlobSDK
            this.keyOid = keyOid;
            this.keyTid = keyTid;
            this.keyStart = keyStart;
            this.keyExpiry = keyExpiry;
            this.keyService = keyService;
            this.keyVersion = keyVersion;
#endif
        }


        /// <summary>
        /// Creates and initializes a SASQueryParameters object based on the
        /// query parameter map's passed-in values. If deleteSASParametersFromValues is true,
        /// all SAS-related query parameters are removed from the passed-in map. If
        /// deleteSASParametersFromValues is false, the map passed-in map is unaltered.
        /// </summary>
        /// <param name="values"></param>
        internal SasQueryParameters(UriQueryParamsCollection values)
        {
            // make copy, otherwise we'll get an exception when we remove

            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray(); ;

            foreach (var kv in kvps)
            {
                // these are already decoded
                var isSASKey = true;
                switch (kv.Key.ToUpperInvariant())
                {
                    case Constants.Sas.Parameters.VersionUpper: this.version = kv.Value; break;
                    case Constants.Sas.Parameters.ServicesUpper: this.services = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceTypesUpper: this.resourceTypes = kv.Value; break;
                    case Constants.Sas.Parameters.ProtocolUpper: this.protocol = SasProtocol.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.StartTimeUpper: this.startTime = DateTimeOffset.ParseExact(kv.Value, TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.ExpiryTimeUpper: this.expiryTime = DateTimeOffset.ParseExact(kv.Value, TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.IPRangeUpper: this.ipRange = IPRange.Parse(kv.Value); break;
                    case Constants.Sas.Parameters.IdentifierUpper: this.identifier = kv.Value; break;
                    case Constants.Sas.Parameters.ResourceUpper: this.resource = kv.Value; break;
                    case Constants.Sas.Parameters.PermissionsUpper: this.permissions = kv.Value; break;
                    case Constants.Sas.Parameters.SignatureUpper: this.signature = kv.Value; break;
#if BlobSDK
                    case Constants.Sas.Parameters.KeyOidUpper: this.keyOid = kv.Value; break;
                    case Constants.Sas.Parameters.KeyTidUpper: this.keyTid = kv.Value; break;
                    case Constants.Sas.Parameters.KeyStartUpper: this.keyStart = DateTimeOffset.ParseExact(kv.Value, TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.KeyExpiryUpper: this.keyExpiry = DateTimeOffset.ParseExact(kv.Value, TimeFormat, CultureInfo.InvariantCulture); break;
                    case Constants.Sas.Parameters.KeyServiceUpper: this.keyService = kv.Value; break;
                    case Constants.Sas.Parameters.KeyVersionUpper: this.keyVersion = kv.Value; break;
#endif
                    default: isSASKey = false; break; // We didn't recognize the query parameter
                }
                if (isSASKey)
                {
                    values.Remove(kv.Key);
                }
            }
        }

        /// <summary>
        /// Encode encodes the SAS query parameters into URL encoded form.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
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
                AddToBuilder(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(this.StartTime.ToString(TimeFormat, CultureInfo.InvariantCulture)));
            }

            if (this.ExpiryTime != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(this.ExpiryTime.ToString(TimeFormat, CultureInfo.InvariantCulture)));
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

#if BlobSDK
            if (!String.IsNullOrWhiteSpace(this.KeyOid))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyOid, this.KeyOid);
            }

            if (!String.IsNullOrWhiteSpace(this.KeyTid))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyTid, this.KeyTid);
            }

            if (this.KeyStart != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(this.KeyStart.ToString(TimeFormat, CultureInfo.InvariantCulture)));
            }

            if (this.KeyExpiry != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(this.KeyExpiry.ToString(TimeFormat, CultureInfo.InvariantCulture)));
            }

            if (!String.IsNullOrWhiteSpace(this.KeyService))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyService, this.KeyService);
            }

            if (!String.IsNullOrWhiteSpace(this.KeyVersion))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyVersion, this.KeyVersion);
            }
#endif

            if (!String.IsNullOrWhiteSpace(this.Signature))
            {
                AddToBuilder(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(this.Signature));
            }

            return sb.ToString();
        }
    }
}
