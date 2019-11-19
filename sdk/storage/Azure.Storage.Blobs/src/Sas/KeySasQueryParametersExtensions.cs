// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Storage.Sas
{
    internal static class KeySasQueryParametersExtensions
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
#endif
            parameters,
            Dictionary<string, string> values)
        {
            // make copy, otherwise we'll get an exception when we remove
            IEnumerable<KeyValuePair<string, string>> kvps = values.ToArray();
            var isSasKey = true;
            parameters._keyProperties = new UserDelegationKeyProperties();
            foreach (KeyValuePair<string, string> kv in kvps)
            {
                // these are already decoded
                switch (kv.Key.ToUpperInvariant())
                {
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
    }
}
