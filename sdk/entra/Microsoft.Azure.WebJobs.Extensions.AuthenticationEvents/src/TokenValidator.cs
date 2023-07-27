// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal abstract class TokenValidator
    {
        internal abstract Task<(bool Valid, Dictionary<string, string> Claims)> GetClaimsAndValidate(HttpRequestMessage request, ConfigurationManager configurationManager);
    }
}
