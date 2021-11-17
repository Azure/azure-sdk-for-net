// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }
}
