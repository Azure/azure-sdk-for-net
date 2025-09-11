// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class UpdateOperationMethodProvider(
        ResourceClientProvider resource,
        RequestPathPattern contextualPath,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        bool isAsync) : ResourceOperationMethodProvider(resource, contextualPath, restClientInfo, method, isAsync, methodName: isAsync ? "UpdateAsync" : "Update")
    {
    }
}
