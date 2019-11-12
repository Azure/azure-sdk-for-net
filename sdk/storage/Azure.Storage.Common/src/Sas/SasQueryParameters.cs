// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Storage.Sas.Shared.Common;
using Internals = Azure.Storage.Shared.Common;
using SasInternals = Azure.Storage.Sas.Shared.Common;

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
        public const string DefaultSasVersion = Internals.Constants.DefaultSasVersion;

        /// <summary>
        /// FormatTimesForSASSigning converts a time.Time to a snapshotTimeFormat string suitable for a
        /// SASField's StartTime or ExpiryTime fields. Returns "" if value.IsZero().
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTimesForSasSigning(DateTimeOffset time) =>
            // "yyyy-MM-ddTHH:mm:ssZ"
            (time == new DateTimeOffset()) ? "" : time.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture);

        // All members are immutable or values so copies of this struct are thread safe.

        // sv
        private string _version;

        // ss
        private AccountSasServices? _services;

        // srt
        private AccountSasResourceTypes? _resourceTypes;

        // spr
        private SasProtocol _protocol;

        // st
        private DateTimeOffset _startTime;

        // se
        private DateTimeOffset _expiryTime;

        // sip
        private SasIPRange _ipRange;

        // si
        private string _identifier;

        // sr
        private string _resource;

        // sp
        private string _permissions;

        // sig
        private string _signature;

        // rscc
        private string _cacheControl;

        // rscd
        private string _contentDisposition;

        // rsce
        private string _contentEncoding;

        // rscl
        private string _contentLanguage;

        // rsct
        private string _contentType;

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
        //internal string _keyObjectId;

        //// sktid
        //internal string _keyTenantId;

        //// skt
        //internal DateTimeOffset _keyStart;

        //// ske
        //internal DateTimeOffset _keyExpiry;

        //// sks
        //internal string _keyService;

        //// skv
        //internal string _keyVersion;
        internal UserDelegationKeyProperties _keyProperties;
        #endregion Blob Only Parameters

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static SasQueryParameters Empty => new SasQueryParameters();

        /// <summary>
        /// Initializes a new instance of the <see cref="SasQueryParameters"/> class.
        /// </summary>
        protected SasQueryParameters() { }

        /// <summary>
        /// Creates a new instance of the <see cref="SasQueryParameters"/> type.
        ///
        /// Expects decoded values.
        /// </summary>
        [Obsolete]
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
            _keyProperties._objectId = keyOid;
            _keyProperties._tenantId = keyTid;
            _keyProperties._startsOn = keyStart;
            _keyProperties._expiresOn = keyExpiry;
            _keyProperties._service = keyService;
            _keyProperties._version = keyVersion;
            _cacheControl = cacheControl;
            _contentDisposition = contentDisposition;
            _contentEncoding = contentEncoding;
            _contentLanguage = contentLanguage;
            _contentType = contentType;
        }

        [Obsolete]
        internal SasQueryParameters(
            UriQueryParamsCollection values,
            bool includeBlobParameters = false) : this((Dictionary<string,string>) values, includeBlobParameters)
        {

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
            Dictionary<string, string> values,
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
                    case Internals.Constants.Sas.Parameters.VersionUpper:
                        _version = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ServicesUpper:
                        _services = SasInternals.SasExtensions.ParseAccountServices(kv.Value);
                        break;
                    case Internals.Constants.Sas.Parameters.ResourceTypesUpper:
                        _resourceTypes = SasInternals.SasExtensions.ParseResourceTypes(kv.Value);
                        break;
                    case Internals.Constants.Sas.Parameters.ProtocolUpper:
                        _protocol = SasInternals.SasExtensions.ParseProtocol(kv.Value);
                        break;
                    case Internals.Constants.Sas.Parameters.StartTimeUpper:
                        _startTime = DateTimeOffset.ParseExact(kv.Value, Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Internals.Constants.Sas.Parameters.ExpiryTimeUpper:
                        _expiryTime = DateTimeOffset.ParseExact(kv.Value, Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Internals.Constants.Sas.Parameters.IPRangeUpper:
                        _ipRange = SasIPRange.Parse(kv.Value);
                        break;
                    case Internals.Constants.Sas.Parameters.IdentifierUpper:
                        _identifier = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ResourceUpper:
                        _resource = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.PermissionsUpper:
                        _permissions = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.SignatureUpper:
                        _signature = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.CacheControlUpper:
                        _cacheControl = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ContentDispositionUpper:
                        _contentDisposition = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ContentEncodingUpper:
                        _contentEncoding = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ContentLanguageUpper:
                        _contentLanguage = kv.Value;
                        break;
                    case Internals.Constants.Sas.Parameters.ContentTypeUpper:
                        _contentType = kv.Value;
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
            // Optionally include Blob parameters
            if (includeBlobParameters)
            {
                SasQueryParametersExtensions.ParseKeyProperties(this, values);
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
        protected string Encode(bool includeBlobParameters = false)
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
                AddToBuilder(Internals.Constants.Sas.Parameters.Version, Version);
            }

            if (Services != null)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Services, Services.Value.ToPermissionsString());
            }

            if (ResourceTypes != null)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ResourceTypes, ResourceTypes.Value.ToPermissionsString());
            }

            if (Protocol != default)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Protocol, Protocol.ToProtocolString());
            }

            if (StartsOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(StartsOn.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (ExpiresOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(ExpiresOn.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            var ipr = IPRange.ToString();
            if (ipr.Length > 0)
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.IPRange, ipr);
            }

            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Identifier, Identifier);
            }

            if (!string.IsNullOrWhiteSpace(Resource))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Resource, Resource);
            }

            if (!string.IsNullOrWhiteSpace(Permissions))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Permissions, Permissions);
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.CacheControl, CacheControl);
            }

            if (!string.IsNullOrWhiteSpace(ContentDisposition))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ContentDisposition, ContentDisposition);
            }

            if (!string.IsNullOrWhiteSpace(ContentEncoding))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ContentEncoding, ContentEncoding);
            }

            if (!string.IsNullOrWhiteSpace(ContentLanguage))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ContentLanguage, ContentLanguage);
            }

            if (!string.IsNullOrWhiteSpace(ContentType))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.ContentType, ContentType);
            }

            if (includeBlobParameters)
            {
                if (!string.IsNullOrWhiteSpace(_keyProperties._objectId))
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyObjectId, _keyProperties._objectId);
                }

                if (!string.IsNullOrWhiteSpace(_keyProperties._tenantId))
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyTenantId, _keyProperties._tenantId);
                }

                if (_keyProperties._startsOn != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(_keyProperties._startsOn.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (_keyProperties._expiresOn != DateTimeOffset.MinValue)
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(_keyProperties._expiresOn.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
                }

                if (!string.IsNullOrWhiteSpace(_keyProperties._service))
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyService, _keyProperties._service);
                }

                if (!string.IsNullOrWhiteSpace(_keyProperties._version))
                {
                    AddToBuilder(Internals.Constants.Sas.Parameters.KeyVersion, _keyProperties._version);
                }
            }

            if (!string.IsNullOrWhiteSpace(Signature))
            {
                AddToBuilder(Internals.Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(Signature));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        public static SasQueryParameters Create(
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
            string contentType = default,
            SasQueryParameters instance = default) =>
                CopyToInstance(
                    instance ?? new SasQueryParameters(),
                    version,
                    services,
                    resourceTypes,
                    protocol,
                    startsOn,
                    expiresOn,
                    ipRange,
                    identifier,
                    resource,
                    permissions,
                    signature,
                    keyOid,
                    keyTid,
                    keyStart,
                    keyExpiry,
                    keyService,
                    keyVersion,
                    cacheControl,
                    contentDisposition,
                    contentEncoding,
                    contentLanguage,
                    contentType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="values"></param>
        /// <param name="includeBlobParameters"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static SasQueryParameters Create(
            Dictionary<string, string> values,
            bool includeBlobParameters = false,
            SasQueryParameters instance = default)
        {
            if (instance == default)
            {
                return new SasQueryParameters(values, includeBlobParameters);
            }
            else
            {
                var copy = new SasQueryParameters(values, includeBlobParameters);
                return CopyToInstance(
                    instance,
                    version: copy.Version,
                    services: copy.Services,
                    resourceTypes: copy.ResourceTypes,
                    protocol: copy.Protocol,
                    startsOn: copy.StartsOn,
                    expiresOn: copy.ExpiresOn,
                    ipRange: copy.IPRange,
                    identifier: copy.Identifier,
                    resource: copy.Resource,
                    permissions: copy.Permissions,
                    signature: copy.Signature,
                    keyOid: copy._keyProperties._objectId,
                    keyTid: copy._keyProperties._tenantId,
                    keyStart: copy._keyProperties._startsOn,
                    keyExpiry: copy._keyProperties._expiresOn,
                    keyService: copy._keyProperties._service,
                    keyVersion: copy._keyProperties._version,
                    cacheControl: copy.CacheControl,
                    contentDisposition: copy.ContentDisposition,
                    contentEncoding: copy.ContentEncoding,
                    contentLanguage: copy.ContentLanguage,
                    contentType: copy.ContentType);
            }
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        private static SasQueryParameters CopyToInstance(
            SasQueryParameters instance,
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
            instance._version = version ?? SasQueryParameters.DefaultSasVersion;
            instance._services = services;
            instance._resourceTypes = resourceTypes;
            instance._protocol = protocol;
            instance._startTime = startsOn;
            instance._expiryTime = expiresOn;
            instance._ipRange = ipRange;
            instance._identifier = identifier;
            instance._resource = resource;
            instance._permissions = permissions;
            instance._signature = signature;  // Should never be null
            instance._keyProperties._objectId = keyOid;
            instance._keyProperties._tenantId = keyTid;
            instance._keyProperties._startsOn = keyStart;
            instance._keyProperties._expiresOn = keyExpiry;
            instance._keyProperties._service = keyService;
            instance._keyProperties._version = keyVersion;
            instance._cacheControl = cacheControl;
            instance._contentDisposition = contentDisposition;
            instance._contentEncoding = contentEncoding;
            instance._contentLanguage = contentLanguage;
            instance._contentType = contentType;
            return instance;
        }
    }
}
