// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
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

    /// <summary>
    /// Gets a resource-type-shaped override key for a scope-level operation group without
    /// resource metadata. This is an operation-group key, not an inferred ARM resource.
    /// Only a concrete scope/providers/namespace/group path is supported; resource instance
    /// and action suffixes must not be treated as additional resource-type segments.
    /// </summary>
    internal static string? GetOperationGroupApiVersionKey(InputServiceMethod method)
    {
        var nonResourceMethod = ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods
            .FirstOrDefault(m => ReferenceEquals(m.InputMethod, method));
        if (nonResourceMethod is null)
        {
            return null;
        }
        var operationPath = new RequestPathPattern(method.Operation.Path);
        var scopePath = nonResourceMethod.Scope.ScopeIdPattern;
        if (!scopePath.IsAncestorOf(operationPath))
        {
            return null;
        }
        var groupPath = scopePath.TrimAncestorFrom(operationPath);
        return groupPath.Count == 3 && groupPath[0].IsProvidersSegment
            && groupPath[1].IsConstant && groupPath[2].IsConstant
            ? $"{groupPath[1].Value}/{groupPath[2].Value}"
            : null;
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
        /// Whether the REST client needs a per-operation resolver. Ordinary resource and
        /// collection clients already resolve their constructor version; mockable extension
        /// operations need their own lookup even when every wire default is the client version.
        /// </summary>
        internal bool NeedsApiVersionResolver => inputClient.HasOperationApiVersionDefaults
            || ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas.Any(resource =>
                resource.CategorizeMethods().MethodsInExtension.Any(method => ReferenceEquals(method.InputClient, inputClient)))
            || inputClient.Methods.Any(method => GetOperationGroupApiVersionKey(method) is not null);

        /// <summary>
        /// Gets the API version for this client from its <see cref="InputClient.ApiVersions"/>.
        /// </summary>
        public string CurrentApiVersion
            => inputClient.ApiVersions.LastOrDefault()
                ?? throw new InvalidOperationException($"Cannot determine API version for client '{inputClient.Name}'. The client has no API versions defined.");
    }
}
