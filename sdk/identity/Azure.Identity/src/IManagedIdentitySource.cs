// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal interface IManagedIdentitySource
    {
        Request CreateRequest(string[] scopes);
        AccessToken GetAccessTokenFromJson(in JsonElement jsonAccessToken, in JsonElement jsonExpiresOn);
        ValueTask HandleFailedRequestAsync(Response response, ClientDiagnostics diagnostics, bool async);
    }
}
