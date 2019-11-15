// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#if CommonSDK
namespace Azure.Storage.Sas
#elif BlobSDK
namespace Azure.Storage.Sas
#elif DataLakeSDK
namespace Azure.Storage.Files.DataLake.Sas
#endif
{

    internal static class SasQueryParametersExtensions
    {
        internal static void ParseKeyProperties(
#if CommonSDK
            SasQueryParameters // unfortunately, generics won't work as UserDelegationKey is internal.
#elif BlobSDK
            BlobSasQueryParameters
#elif DataLakeSDK
            DataLakeSasQueryParameters
#endif
            parameters,
            Dictionary<string, string> values,
            bool preserve = false)
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
                if (isSasKey && !preserve)
                {
                    values.Remove(kv.Key);
                }
            }
        }
    }
}
