// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Storage.Sas
{
    internal static class SasQueryParametersExtensions
    {
        /// <summary>
        /// Parses the key properties into the QueryParameters instance.
        /// </summary>
        /// <param name="parameters">
        /// The BlobSasQueryParameters or DataLakeSasQueryParameters instance.
        /// </param>
        /// <param name="values">
        /// Dictionary of keys and values.
        /// </param>
        internal static void ParseKeyProperties(
            this
#if BlobSDK
            BlobSasQueryParameters
#elif DataLakeSDK
            DataLakeSasQueryParameters
#elif QueueSDK
            QueueSasQueryParameters
#elif FileSDK
            ShareSasQueryParameters
#endif
            parameters,
            IDictionary<string, string> values)
        {
            // make copy, otherwise we'll get an exception when we remove
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray();
            parameters.KeyProperties = new UserDelegationKeyProperties();
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                var isSasKey = true;
                // these are already decoded
                switch (kv.Key.ToUpperInvariant())
                {
                    case Constants.Sas.Parameters.KeyObjectIdUpper:
                        parameters.KeyProperties.ObjectId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyTenantIdUpper:
                        parameters.KeyProperties.TenantId = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyStartUpper:
                        parameters.KeyProperties.StartsOn = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.KeyExpiryUpper:
                        parameters.KeyProperties.ExpiresOn = DateTimeOffset.ParseExact(kv.Value, Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
                        break;
                    case Constants.Sas.Parameters.KeyServiceUpper:
                        parameters.KeyProperties.Service = kv.Value;
                        break;
                    case Constants.Sas.Parameters.KeyVersionUpper:
                        parameters.KeyProperties.Version = kv.Value;
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
    }
}
