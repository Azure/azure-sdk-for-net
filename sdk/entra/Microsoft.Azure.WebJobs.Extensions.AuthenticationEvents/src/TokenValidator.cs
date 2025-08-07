// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal abstract class TokenValidator
    {
        internal abstract Task<Dictionary<string, string>> ValidateAndGetClaims(
            HttpRequestMessage request,
            ConfigurationManager configurationManager);
    }
}
