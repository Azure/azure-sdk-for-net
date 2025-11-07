// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class UpdateOperationMethodProvider : ResourceOperationMethodProvider
    {
        public UpdateOperationMethodProvider(
            ResourceClientProvider resource,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            bool isAsync,
            ResourceOperationKind methodKind,
            bool forceLro = false)
            : base(resource, contextualPath, restClientInfo, method, isAsync, methodName: isAsync ? "UpdateAsync" : "Update", description: GetDescription(resource, methodKind), forceLro: forceLro)
        {
        }

        private static FormattableString? GetDescription(ResourceClientProvider resource, ResourceOperationKind methodKind)
        {
            // Only override description if this is a Create operation being used as Update
            return methodKind == ResourceOperationKind.Create ? FormattableStringFactory.Create("Update a {0}.", resource.ResourceName) : null;
        }
    }
}
