// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Storage.Sas;

#if BlobSDK
namespace Azure.Storage.Sas
#elif DataLakeSDK
namespace Azure.Storage.Files.DataLake.Sas
#endif
{

    internal static class SasQueryParametersExtensions
    {
        internal static void ParseKeyProperties(
            this
#if BlobSDK
            BlobSasQueryParameters
#elif DataLakeSDK
            DataLakeSasQueryParameters
#endif
            parameters,
            Dictionary<string, string> values)
        {
            // make copy, otherwise we'll get an exception when we remove
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray();
            var isSasKey = true;
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                // these are already decoded
                switch (kv.Key.ToUpperInvariant())
                {
                    // Optionally include Blob parameters
                    case Constants.Sas.Parameters.KeyObjectIdUpper:
                        parameters._keyProperties._objectId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyTenantIdUpper:
                        parameters._keyProperties._tenantId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyStartUpper:
                        parameters._keyProperties._startsOn = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.KeyExpiryUpper:
                        parameters._keyProperties._expiresOn = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormat, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.KeyServiceUpper:
                        parameters._keyProperties._service = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyVersionUpper:
                        parameters._keyProperties._version = kv.Value;
                        break;

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
        internal static string GetPropertiesString(this UserDelegationKeyProperties keyProperties)
        {
            var sb = new StringBuilder();

            void AddToBuilder(string key, string value)
            =>
            sb
            .Append(sb.Length > 0 ? "&" : "")
            .Append(key)
            .Append('=')
            .Append(value);

            if (!string.IsNullOrWhiteSpace(keyProperties._objectId))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyObjectId, keyProperties._objectId);
            }

            if (!string.IsNullOrWhiteSpace(keyProperties._tenantId))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyTenantId, keyProperties._tenantId);
            }

            if (keyProperties._startsOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(keyProperties._startsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (keyProperties._expiresOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(keyProperties._expiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrWhiteSpace(keyProperties._service))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyService, keyProperties._service);
            }

            if (!string.IsNullOrWhiteSpace(keyProperties._version))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyVersion, keyProperties._version);
            }

            return sb.ToString();
        }
    }
}
