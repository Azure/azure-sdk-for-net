// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault
{
    internal static class ClientOptionsExtensions
    {
        public static void ConfigureLogging(this ClientOptions clientOptions)
        {
            IList<string> allowedHeaderNames = clientOptions.Diagnostics.LoggingAllowedHeaderNames;
            allowedHeaderNames.Add("x-ms-keyvault-network-info");
            allowedHeaderNames.Add("x-ms-keyvault-region");
            allowedHeaderNames.Add("x-ms-keyvault-service-version");

            clientOptions.Diagnostics.LoggingAllowedQueryParameters.Add("api-version");
        }
    }
}
