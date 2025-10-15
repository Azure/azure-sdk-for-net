// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// For more information,
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">
    /// Create a service SAS</see>.
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
        private (AccountSasServices? Parsed, string Raw) _services;

        // srt
        private (AccountSasResourceTypes? Parsed, string Raw) _resourceTypes;

        // spr
        private (SasProtocol? Parsed, string Raw) _protocol;

        // st
        private DateTimeOffset _startTime;

        // st as a string
        private string _startTimeString;

        // se
        private DateTimeOffset _expiryTime;

        // se as a string
        private string _expiryTimeString;

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

        // saoid
        private string _preauthorizedAgentObjectId;

        /// suoid
        private string _agentObjectId;

        /// scid
        private string _correlationId;

        // sdd
        private int? _directoryDepth;

        // ses
        private string _encryptionScope;

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

        // sduoid
        private string _delegatedUserObjectId;

        // skdutid
        private string _delegatedUserTenantId;

        /// <summary>
        /// Gets the storage service version to use to authenticate requests
        /// made with this shared access signature, and the service version to
        /// use when handling requests made with this shared access signature.
        /// </summary>
        public string Version => _version ?? SasQueryParametersInternals.DefaultSasVersionInternal;

        /// <summary>
        /// Gets the signed services accessible with an account level shared
        /// access signature.
        /// </summary>
        public AccountSasServices? Services => _services.Parsed;

        /// <summary>
        /// Gets which resources are accessible via the shared access signature.
        /// </summary>
        public AccountSasResourceTypes? ResourceTypes => _resourceTypes.Parsed;

        /// <summary>
        /// Optional. Specifies the protocol permitted for a request made with
        /// the shared access signature.
        /// </summary>
        public SasProtocol Protocol => _protocol.Parsed ?? SasExtensions.ParseProtocol(_protocol.Raw);
        private string ProtocolAsString => _protocol.Raw ?? _protocol.Parsed?.ToProtocolString();

        /// <summary>
        /// Gets the optional time at which the shared access signature becomes
        /// valid.  If omitted, start time for this call is assumed to be the
        /// time when the storage service receives the request.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset StartsOn => _startTime;

        internal string StartsOnString => _startTimeString;

        /// <summary>
        /// Gets the time at which the shared access signature becomes invalid.
        /// <see cref="DateTimeOffset.MinValue"/> means not set.
        /// </summary>
        public DateTimeOffset ExpiresOn => _expiryTime;

        internal string ExpiresOnString => _expiryTimeString;

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
        /// Gets the Authorized AAD Object Id associated with the shared access signature.
        /// The AAD Object ID of a user authorized by the owner of the User Delegation Key
        /// to perform the action granted by the SAS. The Azure Storage service will
        /// ensure that the owner of the user delegation key has the required permissions
        /// before granting access but no additional permission check for the user specified
        /// in this value will be performed. This cannot be used in conjuction with
        /// <see cref="AgentObjectId"/>.
        /// Only valid in an HNS enabled account. If this value is set in an non-HNS enabled
        /// account, an authorization failure will be thrown.
        /// </summary>
        public string PreauthorizedAgentObjectId => _preauthorizedAgentObjectId ?? string.Empty;

        /// <summary>
        /// Gets the Unauthorized AAD Object Id associated with the shared access signature.
        /// The AAD Object Id of a user that is assumed to be unauthorized by the owner of the
        /// User Delegation Key. The Azure Storage Service will perform an additional POSIX ACL
        /// check to determine if the user is authorized to perform the requested operation.
        /// This cannot be used in conjuction with <see cref="PreauthorizedAgentObjectId"/>.
        /// Only valid in an HNS enabled account. If this value is set in an non-HNS enabled
        /// account, an authorization failure will be thrown.
        /// </summary>
        public string AgentObjectId => _agentObjectId ?? string.Empty;

        /// <summary>
        /// Gets the Correlation Id associated with the shared access signature. This is used to
        /// correlate the storage audit logs with the audit logs used by the principal generating
        /// and distributing SAS.
        /// </summary>
        public string CorrelationId => _correlationId ?? string.Empty;

        /// <summary>
        /// Gets the Directory Depth specificed in the canonicalizedresource field of the
        /// string-to-sign. The depth of the directory is the number of directories beneath the
        /// root folder. Required when resource (sr) = d to indicate the depth of the directory.
        /// The value must be a non-negative integer.
        /// </summary>
        public int? DirectoryDepth => _directoryDepth ?? null;

        /// <summary>
        /// Gets the Encryption Scope associated with the shared access signature.
        /// </summary>
        public string EncryptionScope => _encryptionScope ?? string.Empty;

        /// <summary>
        /// Gets the Delegated User Object Id associated with the shared access signature.
        /// Optional. Beginning in version 2025-07-05, this value  specifies the Entra ID of the user would is authorized to
        /// use the resulting SAS URL.  The resulting SAS URL must be used in conjunction with an Entra ID token that has been
        /// issued to the user specified in this value.
        /// </summary>
        public string DelegatedUserObjectId => _delegatedUserObjectId ?? string.Empty;

        /// <summary>
        /// Gets the Delegated User Tenant Id associated with the shared access signature.
        /// Optional. This value specifies the Entra ID of the tenant that is authorized to
        /// use the resulting SAS URL.  The resulting SAS URL must be used in conjunction with an Entra ID token that has been
        /// issued to the tenant specified in this value.
        /// </summary>
        public string DelegatedUserTenantId => _delegatedUserTenantId ?? string.Empty;

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
                        _services = (SasExtensions.ParseAccountServices(kv.Value), kv.Value);
                        break;
                    case Constants.Sas.Parameters.ResourceTypesUpper:
                        _resourceTypes = (SasExtensions.ParseResourceTypes(kv.Value), kv.Value);
                        break;
                    case Constants.Sas.Parameters.ProtocolUpper:
                        _protocol = (SasExtensions.ParseProtocol(kv.Value), kv.Value);
                        break;
                    case Constants.Sas.Parameters.StartTimeUpper:
                        _startTimeString = kv.Value;
                        _startTime = ParseSasTime(kv.Value);
                        break;
                    case Constants.Sas.Parameters.ExpiryTimeUpper:
                        _expiryTimeString = kv.Value;
                        _expiryTime = ParseSasTime(kv.Value);
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
                    case Constants.Sas.Parameters.PreauthorizedAgentObjectIdUpper:
                        _preauthorizedAgentObjectId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.AgentObjectIdUpper:
                        _agentObjectId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.CorrelationIdUpper:
                        _correlationId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.DirectoryDepthUpper:
                        _directoryDepth = int.Parse(kv.Value, NumberStyles.Integer, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.EncryptionScopeUpper:
                        _encryptionScope = kv.Value;
                        break;
                    case Constants.Sas.Parameters.DelegatedUserObjectIdUpper:
                        _delegatedUserObjectId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.DelegatedUserTenantIdUpper:
                        _delegatedUserTenantId = kv.Value;
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default,
            string delegatedUserObjectId = default,
            string delegatedUserTenantId = default)
        {
            _version = version;
            _services = (services, services?.ToPermissionsString());
            _resourceTypes = (resourceTypes, resourceTypes?.ToPermissionsString());
            _protocol = (protocol, protocol.ToProtocolString());
            _startTime = startsOn;
            _startTimeString = startsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            _expiryTime = expiresOn;
            _expiryTimeString = expiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
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
            _preauthorizedAgentObjectId = authorizedAadObjectId;
            _agentObjectId = unauthorizedAadObjectId;
            _correlationId = correlationId;
            _directoryDepth = directoryDepth;
            _encryptionScope = encryptionScope;
            _delegatedUserObjectId = delegatedUserObjectId;
            _delegatedUserTenantId = delegatedUserTenantId;
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default,
            string delegatedUserObjectId = default)
        {
            _version = version;
            _services = (services, services?.ToPermissionsString());
            _resourceTypes = (resourceTypes, resourceTypes?.ToPermissionsString());
            _protocol = (protocol, protocol.ToProtocolString());
            _startTime = startsOn;
            _startTimeString = startsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            _expiryTime = expiresOn;
            _expiryTimeString = expiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
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
            _preauthorizedAgentObjectId = authorizedAadObjectId;
            _agentObjectId = unauthorizedAadObjectId;
            _correlationId = correlationId;
            _directoryDepth = directoryDepth;
            _encryptionScope = encryptionScope;
            _delegatedUserObjectId = delegatedUserObjectId;
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default)
        {
            _version = version;
            _services = (services, services?.ToPermissionsString());
            _resourceTypes = (resourceTypes, resourceTypes?.ToPermissionsString());
            _protocol = (protocol, protocol.ToProtocolString());
            _startTime = startsOn;
            _startTimeString = startsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            _expiryTime = expiresOn;
            _expiryTimeString = expiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
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
            _preauthorizedAgentObjectId = authorizedAadObjectId;
            _agentObjectId = unauthorizedAadObjectId;
            _correlationId = correlationId;
            _directoryDepth = directoryDepth;
            _encryptionScope = encryptionScope;
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            _services = (services, services?.ToPermissionsString());
            _resourceTypes = (resourceTypes, resourceTypes?.ToPermissionsString());
            _protocol = (protocol, SasExtensions.ToProtocolString(protocol));
            _startTime = startsOn;
            _startTimeString = startsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            _expiryTime = expiresOn;
            _expiryTimeString = expiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
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
            _preauthorizedAgentObjectId = default;
            _agentObjectId = default;
            _correlationId = default;
            _directoryDepth = default;
        }

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default)
        {
            _version = version;
            _services = (services, services?.ToPermissionsString());
            _resourceTypes = (resourceTypes, resourceTypes?.ToPermissionsString());
            _protocol = (protocol, SasExtensions.ToProtocolString(protocol));
            _startTime = startsOn;
            _startTimeString = startsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            _expiryTime = expiresOn;
            _expiryTimeString = expiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
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
            _preauthorizedAgentObjectId = authorizedAadObjectId;
            _agentObjectId = unauthorizedAadObjectId;
            _correlationId = correlationId;
            _directoryDepth = directoryDepth;
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default,
            string delegatedUserObjectId = default,
            string delegatedUserTenantId = default) =>
            new SasQueryParameters(
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType,
                authorizedAadObjectId: authorizedAadObjectId,
                unauthorizedAadObjectId: unauthorizedAadObjectId,
                correlationId: correlationId,
                directoryDepth: directoryDepth,
                encryptionScope: encryptionScope,
                delegatedUserObjectId: delegatedUserObjectId,
                delegatedUserTenantId: delegatedUserTenantId);

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default,
            string delegatedUserObjectId = default) =>
            new SasQueryParameters(
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType,
                authorizedAadObjectId: authorizedAadObjectId,
                unauthorizedAadObjectId: unauthorizedAadObjectId,
                correlationId: correlationId,
                directoryDepth: directoryDepth,
                encryptionScope: encryptionScope,
                delegatedUserObjectId: delegatedUserObjectId);

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default) =>
            new SasQueryParameters(
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType,
                authorizedAadObjectId: authorizedAadObjectId,
                unauthorizedAadObjectId: unauthorizedAadObjectId,
                correlationId: correlationId,
                directoryDepth: directoryDepth,
                encryptionScope: encryptionScope);

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType);

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default) =>
            new SasQueryParameters(
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType,
                authorizedAadObjectId: authorizedAadObjectId,
                unauthorizedAadObjectId: unauthorizedAadObjectId,
                correlationId: correlationId,
                directoryDepth: directoryDepth);

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            AppendProperties(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Builds the query parameter string for the SasQueryParameters instance.
        /// </summary>
        /// <param name="stringBuilder">
        /// StringBuilder instance to add the query params to
        /// </param>
        protected internal void AppendProperties(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Version))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Version, Version);
            }

            if (Services != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Services, _services.Raw);
            }

            if (ResourceTypes != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ResourceTypes, _resourceTypes.Raw);
            }

            if (!string.IsNullOrEmpty(ProtocolAsString))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Protocol, ProtocolAsString);
            }

            if (StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(StartsOnString));
            }

            if (ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(ExpiresOnString));
            }

            var ipr = IPRange.ToString();
            if (ipr.Length > 0)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.IPRange, ipr);
            }

            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Identifier, Identifier);
            }

            if (!string.IsNullOrWhiteSpace(Resource))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Resource, Resource);
            }

            if (!string.IsNullOrWhiteSpace(Permissions))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Permissions, Permissions);
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.CacheControl, WebUtility.UrlEncode(CacheControl));
            }

            if (!string.IsNullOrWhiteSpace(ContentDisposition))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentDisposition, WebUtility.UrlEncode(ContentDisposition));
            }

            if (!string.IsNullOrWhiteSpace(ContentEncoding))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentEncoding, WebUtility.UrlEncode(ContentEncoding));
            }

            if (!string.IsNullOrWhiteSpace(ContentLanguage))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentLanguage, WebUtility.UrlEncode(ContentLanguage));
            }

            if (!string.IsNullOrWhiteSpace(ContentType))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentType, WebUtility.UrlEncode(ContentType));
            }

            if (!string.IsNullOrWhiteSpace(PreauthorizedAgentObjectId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.PreauthorizedAgentObjectId, WebUtility.UrlEncode(PreauthorizedAgentObjectId));
            }

            if (!string.IsNullOrWhiteSpace(AgentObjectId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.AgentObjectId, WebUtility.UrlEncode(AgentObjectId));
            }

            if (!string.IsNullOrWhiteSpace(CorrelationId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.CorrelationId, WebUtility.UrlEncode(CorrelationId));
            }

            if (!(DirectoryDepth == default))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.DirectoryDepth, WebUtility.UrlEncode(DirectoryDepth.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(EncryptionScope))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.EncryptionScope, WebUtility.UrlEncode(EncryptionScope));
            }

            if (!string.IsNullOrWhiteSpace(DelegatedUserTenantId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.DelegatedUserTenantId, WebUtility.UrlEncode(DelegatedUserTenantId));
            }

            if (!string.IsNullOrWhiteSpace(DelegatedUserObjectId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.DelegatedUserObjectId, WebUtility.UrlEncode(DelegatedUserObjectId));
            }

            if (!string.IsNullOrWhiteSpace(Signature))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(Signature));
            }
        }

        private static DateTimeOffset ParseSasTime(string dateTimeString)
        {
            if (string.IsNullOrEmpty(dateTimeString))
            {
                return DateTimeOffset.MinValue;
            }

            return DateTimeOffset.ParseExact(dateTimeString, s_sasTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }

        private static readonly string[] s_sasTimeFormats = {
            Constants.SasTimeFormatSeconds,
            Constants.SasTimeFormatSubSeconds,
            Constants.SasTimeFormatMinutes,
            Constants.SasTimeFormatDays
        };
    }
}
