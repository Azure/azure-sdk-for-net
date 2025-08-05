// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class UpdateOperationMethodProvider(
        ResourceClientProvider resource,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        bool isAsync) : ResourceOperationMethodProvider(resource, resource.ContextualPath, restClientInfo, method, convenienceMethod, isAsync, methodName: isAsync ? "UpdateAsync" : "Update")
    {
    }
}
