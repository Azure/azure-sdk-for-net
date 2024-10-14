// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Security.KeyVault
{
    internal static class ClientOptionsExtensions
    {
        public static void ConfigureLogging(this ClientOptions clientOptions)
        {
            IList<string> allowedHeaderNames = clientOptions.Diagnostics.LoggedHeaderNames;
            allowedHeaderNames.Add("x-ms-keyvault-network-info");
            allowedHeaderNames.Add("x-ms-keyvault-region");
            allowedHeaderNames.Add("x-ms-keyvault-service-version");
        }

        public static void ConfigureLogging(this ClientPipelineOptions clientOptions)
        {
            IList<string> allowedHeaderNames = clientOptions.Logging.AllowedHeaderNames;
            allowedHeaderNames.Add("x-ms-keyvault-network-info");
            allowedHeaderNames.Add("x-ms-keyvault-region");
            allowedHeaderNames.Add("x-ms-keyvault-service-version");
        }
    }
}
