// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// (Blob Containers, Blobs, Files, and Queues).  You can construct a new instance
    /// using the service specific SAS builder types.
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
        private readonly string _version;

        // ss
        private readonly AccountSasServices? _services;

        // srt
        private readonly AccountSasResourceTypes? _resourceTypes;

        // spr
        private readonly SasProtocol _protocol;

        // st
        private readonly DateTimeOffset _startTime;

        // se
        private readonly DateTimeOffset _expiryTime;

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

        // rscc
        private readonly string _cacheControl;

        // rscd
        private readonly string _contentDisposition;

        // rsce
        private readonly string _contentEncoding;

        // rscl
        private readonly string _contentLanguage;

        // rsct
        private readonly string _contentType;

        /// <summary>
        /// Gets the storage service version to use to authenticate requests
        /// made with this shared access signature, and the service version to
        /// use when handling requests made with this shared access signature.
        /// </summary>
        public string Version => _version ?? DefaultSasVersion;

        /// <summary>
        /// Gets the signed services accessible with an account level shared
        /// access signature.
        /// </summary>
        public AccountSasServices? Services => _services;

        /// <summary>
        /// Gets which resources are accessible via the shared access signature.
        /// </summary>
        public AccountSasResourceTypes? ResourceTypes => _resourceTypes;

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
        /// Gets the Cache-Control response header, which allows for
        /// specifying the client-side caching to be used for blob and file downloads.
        /// </summary>
        public string CacheControl => _cacheControl ?? string.Empty;

        /// <summary>
        /// Gets the Content-Disposition response header, which allows for
        /// specifying the way that the blob or file content can be displayed in the browser.
        /// </summary>
        public string ContentDisposition => _contentDisposition ?? string.Empty;

        /// <summary>
        /// Gets the Content-Encoding response header, which allows for specifying
        /// the type of encoding used for blob and file downloads.
        /// </summary>
        public string ContentEncoding => _contentEncoding ?? string.Empty;

        /// <summary>
        /// Gets the Content-Language response header, which allows for specifying the
        /// language of the downloaded blob or file content.
        /// </summary>
        public string ContentLanguage => _contentLanguage ?? string.Empty;

        /// <summary>
        /// Gets the Content-Type response header, which allows for specifying the
        /// type of the downloaded blob or file content.
        /// </summary>
        public string ContentType => _contentType ?? string.Empty;

        /// <summary>
        /// Gets the string-to-sign, a unique string constructed from the
        /// fields that must be verified in order to authenticate the request.
        /// The signature is an HMAC computed over the string-to-sign and key
        /// using the SHA256 algorithm, and then encoded using Base64 encoding.
        /// </summary>
        public string Signature => _signature ?? string.Empty;

        #region Blob Only Parameters
        // skoid
        internal readonly string _keyObjectId;

        // sktid
        internal readonly string _keyTenantId;

        // skt
        internal readonly DateTimeOffset _keyStart;

        // ske
        internal readonly DateTimeOffset _keyExpiry;

        // sks
        internal readonly string _keyService;

        // skv
        internal readonly string _keyVersion;
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
            AccountSasServices? services,
            AccountSasResourceTypes? resourceTypes,
            SasProtocol protocol,
            DateTimeOffset startsOn,
            DateTimeOffset expiresOn,
            SasIPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature,
            string keyOid = default,
            string keyTid = default,
            DateTimeOffset keyStart = default,
            DateTimeOffset keyExpiry = default,
            string keyService = default,
            string keyVersion = default,
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default)
        {
            // Assume URL-decoded
            _version = version ?? DefaultSasVersion;
            _services = services;
            _resourceTypes = resourceTypes;
            _protocol = protocol;
            _startTime = startsOn;
            _expiryTime = expiresOn;
            _ipRange = ipRange;
            _identifier = identifier ?? string.Empty;
            _resource = resource ?? string.Empty;
            _permissions = permissions ?? string.Empty;
            _signature = signature ?? string.Empty;  // Should never be null
            _keyObjectId = keyOid;
            _keyTenantId = keyTid;
            _keyStart = keyStart;
            _keyExpiry = keyExpiry;
            _keyService = keyService;
            _keyVersion = keyVersion;
            _cacheControl = cacheControl;
            _contentDisposition = contentDisposition;
            _contentEncoding = contentEncoding;
            _contentLanguage = contentLanguage;
            _contentType = contentType;
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
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray();
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                // these are already decoded
                var isSasKey = true;
                switch (kv.Key.ToUpperInvariant())
                {
                    case Constants.Sas.Parameters.VersionUpper:
                        _version = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ServicesUpper:
                        _services = SasExtensions.ParseAccountServices(kv.Value);
                        break;
                    case Constants.Sas.Parameters.ResourceTypesUpper:
                        _resourceTypes = SasExtensions.ParseResourceTypes(kv.Value);
                        break;
                    case Constants.Sas.Parameters.ProtocolUpper:
                        _protocol = SasExtensions.ParseProtocol(kv.Value);
                        break;
                    case Constants.Sas.Parameters.StartTimeUpper:
                        _startTime = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.ExpiryTimeUpper:
                        _expiryTime = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.IPRangeUpper:
                        _ipRange = SasIPRange.Parse(kv.Value);
                        break;
                    case Constants.Sas.Parameters.IdentifierUpper:
                        _identifier = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ResourceUpper:
                        _resource = kv.Value;
                        break;
                    case Constants.Sas.Parameters.PermissionsUpper:
                        _permissions = kv.Value;
                        break;
                    case Constants.Sas.Parameters.SignatureUpper:
                        _signature = kv.Value;
                        break;
                    case Constants.Sas.Parameters.CacheControlUpper:
                        _cacheControl = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ContentDispositionUpper:
                        _contentDisposition = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ContentEncodingUpper:
                        _contentEncoding = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ContentLanguageUpper:
                        _contentLanguage = kv.Value;
                        break;
                    case Constants.Sas.Parameters.ContentTypeUpper:
                        _contentType = kv.Value;
                        break;

                    // Optionally include Blob parameters
                    case Constants.Sas.Parameters.KeyObjectIdUpper:
                        if (includeBlobParameters) { _keyObjectId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyTenantIdUpper:
                        if (includeBlobParameters) { _keyTenantId = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyStartUpper:
                        if (includeBlobParameters) { _keyStart = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyExpiryUpper:
                        if (includeBlobParameters) { _keyExpiry = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture); }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyServiceUpper:
                        if (includeBlobParameters) { _keyService = kv.Value; }
                        else { isSasKey = false; }
                        break;
                    case Constants.Sas.Parameters.KeyVersionUpper:
                        if (includeBlobParameters) { _keyVersion = kv.Value; }
                        else { isSasKey = false; }
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

            if (Services != null)
            {
                AddToBuilder(Constants.Sas.Parameters.Services, Services.Value.ToPermissionsString());
            }

            if (ResourceTypes != null)
            {
                AddToBuilder(Constants.Sas.Parameters.ResourceTypes, ResourceTypes.Value.ToPermissionsString());
            }

            if (Protocol != default)
            {
                AddToBuilder(Constants.Sas.Parameters.Protocol, Protocol.ToProtocolString());
            }

            if (StartsOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(StartsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (ExpiresOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(ExpiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
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

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                AddToBuilder(Constants.Sas.Parameters.CacheControl, CacheControl);
            }

            if (!string.IsNullOrWhiteSpace(ContentDisposition))
            {
                AddToBuilder(Constants.Sas.Parameters.ContentDisposition, ContentDisposition);
            }

            if (!string.IsNullOrWhiteSpace(ContentEncoding))
            {
                AddToBuilder(Constants.Sas.Parameters.ContentEncoding, ContentEncoding);
            }

            if (!string.IsNullOrWhiteSpace(ContentLanguage))
            {
                AddToBuilder(Constants.Sas.Parameters.ContentLanguage, ContentLanguage);
            }

            if (!string.IsNullOrWhiteSpace(ContentType))
            {
                AddToBuilder(Constants.Sas.Parameters.ContentType, ContentType);
            }

            if (includeBlobParameters)
            {
                if (!string.IsNullOrWhiteSpace(_keyObjectId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyObjectId, _keyObjectId);
                }

                if (!string.IsNullOrWhiteSpace(_keyTenantId))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyTenantId, _keyTenantId);
                }

                if (_keyStart != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(_keyStart.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (_keyExpiry != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(_keyExpiry.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (!string.IsNullOrWhiteSpace(_keyService))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyService, _keyService);
                }

                if (!string.IsNullOrWhiteSpace(_keyVersion))
                {
                    AddToBuilder(Constants.Sas.Parameters.KeyVersion, _keyVersion);
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
