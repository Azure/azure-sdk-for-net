// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class UpdateOperationMethodProvider : ResourceOperationMethodProvider
    {
        public UpdateOperationMethodProvider(
            ResourceClientProvider resource,
            ParameterContextRegistry parameterMappings,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            bool isAsync,
            ResourceOperationKind methodKind,
            bool forceLro = false,
            bool isCompatibilityOverload = false)
        : base(resource, parameterMappings, restClientInfo, method, methodKind, isAsync, methodName: isAsync ? "UpdateAsync" : "Update", description: GetDescription(resource, methodKind, isCompatibilityOverload), forceLro: forceLro)
        {
            if (isCompatibilityOverload)
            {
                _signature.Update(attributes:
                [
                    .. _signature.Attributes,
                    new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))
                ]);
            }
        }

        private static FormattableString? GetDescription(ResourceClientProvider resource, ResourceOperationKind methodKind, bool isCompatibilityOverload)
        {
            // Only override description if this is a Create operation being used as Update.
            if (methodKind != ResourceOperationKind.Create)
            {
                return null;
            }

            return isCompatibilityOverload
                ? FormattableStringFactory.Create("Updates the {0}.", resource.ResourceName)
                : FormattableStringFactory.Create("Update a {0}.", resource.ResourceName);
        }
    }
}
