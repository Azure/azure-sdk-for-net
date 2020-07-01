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
    /// For more information, <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">Create a service SAS</see>.
    /// </summary>
    public partial class SasQueryParameters
    {
        /// <summary>
        /// The default service version to use for Shared Access Signatures.
        /// </summary>
        public const string DefaultSasVersion = Constants.DefaultSasVersion;

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

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static SasQueryParameters Empty => new SasQueryParameters();

        /// <summary>
        /// Initializes a new instance of the <see cref="SasQueryParameters"/> class.
        /// </summary>
        protected SasQueryParameters() { }

        /// <summary>
        /// Creates a new instance of the <see cref="SasQueryParameters"/> type
        /// based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        protected SasQueryParameters(IDictionary<string, string> values)
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
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        protected SasQueryParameters(
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
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default)
        {
            _version = version;
            _services = services;
            _resourceTypes = resourceTypes;
            _protocol = protocol;
            _startTime = startsOn;
            _expiryTime = expiresOn;
            _ipRange = ipRange;
            _identifier = identifier;
            _resource = resource;
            _permissions = permissions;
            _signature = signature;
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
        protected static SasQueryParameters Create(IDictionary<string, string> values) =>
            new SasQueryParameters(values);

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        protected static SasQueryParameters Create(
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
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default) =>
            new SasQueryParameters(
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
                cacheControl,
                contentDisposition,
                contentEncoding,
                contentLanguage,
                contentType);

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.AppendProperties(sb);
            return sb.ToString();
        }
    }
}
