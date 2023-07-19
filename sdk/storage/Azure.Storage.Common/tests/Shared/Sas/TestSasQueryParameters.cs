// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Test.Shared
{
    internal class TestSasQueryParameters : SasQueryParameters
    {
        private string _rawResourceTypes;
        private string _rawServices;

        /// <summary>
        /// Creates a new SasQueryParameters instance.
        /// </summary>
        public TestSasQueryParameters(
            string version,
            string services,
            string resourceTypes,
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
            : base(version,
                    default, // Services
                    default, // Resource Types
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
                    contentType,
                    authorizedAadObjectId,
                    unauthorizedAadObjectId,
                    correlationId,
                    directoryDepth,
                    encryptionScope)
        {
            _rawServices = services;
            _rawResourceTypes = resourceTypes;
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
            AppendCustomProperties(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Builds the query parameter string for the SasQueryParameters instance.
        /// </summary>
        /// <param name="stringBuilder">
        /// StringBuilder instance to add the query params to
        /// </param>
        protected internal void AppendCustomProperties(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Version))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Version, Version);
            }

            if (!string.IsNullOrEmpty(_rawServices))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Services, _rawServices);
            }
            else if (Services != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Services, Services.ToString());
            }

            if (!string.IsNullOrEmpty(_rawResourceTypes))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ResourceTypes, _rawResourceTypes);
            }
            else if (ResourceTypes != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ResourceTypes, ResourceTypes.Value.ToPermissionsString());
            }

            if (Protocol != default)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Protocol, Protocol.ToProtocolString());
            }

            if (StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(StartsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture)));
            }

            if (ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(ExpiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture)));
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

            if (!string.IsNullOrWhiteSpace(Signature))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(Signature));
            }
        }
    }
}
