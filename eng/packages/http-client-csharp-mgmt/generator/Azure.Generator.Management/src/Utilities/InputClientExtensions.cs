// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management.Utilities;

internal static class InputClientExtensions
{
    /// <summary>
    /// Builds a resolver for explicit resource-type overrides. Keeping this separate from the
    /// client version allows requests in a shared REST client to retain different wire defaults.
    /// </summary>
    internal static ValueExpression BuildApiVersionResolver(bool isCollection = false)
    {
        var resourceType = new VariableExpression(typeof(ResourceType), "resourceType");
        Microsoft.TypeSpec.Generator.Snippets.ScopedApi<string> apiVersion;
        var tryGetVersion = isCollection
            ? This.As<ArmCollection>().TryGetApiVersion(resourceType, "apiVersion", out apiVersion)
            : This.As<ArmResource>().TryGetApiVersion(resourceType, "apiVersion", out apiVersion);
        return new FuncExpression([resourceType.Declaration], new TernaryConditionalExpression(tryGetVersion, apiVersion, Null));
    }

    extension(InputClient inputClient)
    {
        /// <summary>
        /// Whether this client needs per-operation defaults instead of its shared version field.
        /// Availability metadata is intentionally not changed by a wire-default override.
        /// </summary>
        internal bool HasOperationApiVersionDefaults => inputClient.Methods.Any(method =>
            method.Operation.Decorators.Any(decorator => decorator.Name == "Azure.ResourceManager.@hasApiVersionOverride")
            || method.Operation.Parameters.Any(parameter => parameter.IsApiVersion
                && parameter.DefaultValue?.Value is string version
                && version != inputClient.CurrentApiVersion));
        /// <summary>
        /// Gets the API version for this client from its <see cref="InputClient.ApiVersions"/>.
        /// </summary>
        public string CurrentApiVersion
            => inputClient.ApiVersions.LastOrDefault()
                ?? throw new InvalidOperationException($"Cannot determine API version for client '{inputClient.Name}'. The client has no API versions defined.");
    }
}
