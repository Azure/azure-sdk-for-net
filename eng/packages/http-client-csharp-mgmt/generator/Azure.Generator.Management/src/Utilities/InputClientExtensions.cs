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

    internal static ValueExpression BuildConstructorApiVersion(
        (string ResourceType, string DefaultVersion) version,
        bool isCollection = false,
        string variableName = "apiVersion")
    {
        Microsoft.TypeSpec.Generator.Snippets.ScopedApi<string> apiVersion;
        var tryGetVersion = isCollection
            ? This.As<ArmCollection>().TryGetApiVersion(Literal(version.ResourceType), variableName, out apiVersion)
            : This.As<ArmResource>().TryGetApiVersion(Literal(version.ResourceType), variableName, out apiVersion);
        return new TernaryConditionalExpression(tryGetVersion, apiVersion, Literal(version.DefaultVersion));
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
        internal bool NeedsOperationApiVersion => inputClient.HasOperationApiVersionDefaults
            || ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas.Any(resource =>
                resource.CategorizeMethods().MethodsInExtension.Any(method => ReferenceEquals(method.InputClient, inputClient)));

        /// <summary>
        /// A single fixed resource key and common wire default can be resolved by the caller
        /// at construction. Mixed requests, dynamic keys and differing defaults keep a resolver.
        /// </summary>
        internal (string ResourceType, string DefaultVersion)? ConstructorApiVersion
        {
            get
            {
                var plans = ManagementClientGenerator.Instance.InputLibrary.ConstructorApiVersions;
                if (plans.TryGetValue(inputClient, out var plan))
                {
                    return plan;
                }
                // Reuse the same decision during field, caller and request discovery,
                // rather than repeatedly walking the resource metadata.
                return plans[inputClient] = BuildPlan();

                (string ResourceType, string DefaultVersion)? BuildPlan()
                {
                if (!inputClient.NeedsOperationApiVersion)
                {
                    return null;
                }
                (string ResourceType, string DefaultVersion)? result = null;
                foreach (var method in inputClient.Methods)
                {
                    var parameter = method.Operation.Parameters.FirstOrDefault(parameter => parameter.IsApiVersion
                        || parameter is InputQueryParameter { SerializedName: "api-version" });
                    if (parameter is null)
                    {
                        continue;
                    }
                    // Keep the base generator's method/constant parameter representation
                    // unchanged. Only client query fields have a matching string constructor.
                    if (parameter is not InputQueryParameter || parameter.Scope != InputParameterScope.Client
                        || !inputClient.UsesOperationApiVersion(method))
                    {
                        return null;
                    }
                    var resources = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas
                        .Where(resource => resource.Methods.Any(resourceMethod => ReferenceEquals(resourceMethod.InputMethod, method)))
                        .ToArray();
                    if (resources.Length == 0 || resources.Any(resource => !resource.ResourceType.All(segment => segment.IsConstant)))
                    {
                        return null;
                    }
                    string resourceType = resources[0].ResourceType.SerializedResourceType;
                    if (resources.Any(resource => resource.ResourceType.SerializedResourceType != resourceType))
                    {
                        return null;
                    }
                    var wireDefault = parameter.Type is InputLiteralType literal ? literal.Value : parameter.DefaultValue?.Value;
                    var version = (resourceType, wireDefault as string ?? inputClient.CurrentApiVersion);
                    if (result is not null && result.Value != version)
                    {
                        return null;
                    }
                    result = version;
                }
                return result;
                }
            }
        }

        internal bool NeedsApiVersionResolver => inputClient.NeedsOperationApiVersion && inputClient.ConstructorApiVersion is null;

        /// <summary>
        /// Whether any request still reads the shared constructor version. Resolver-only
        /// clients use operation defaults instead and must not retain unused version plumbing.
        /// </summary>
        internal bool NeedsApiVersionField => !inputClient.NeedsApiVersionResolver
            || inputClient.Methods.Any(method =>
                method.Operation.Parameters.Any(parameter =>
                    (parameter.IsApiVersion || parameter is InputQueryParameter { SerializedName: "api-version" })
                    && parameter.Type is not InputLiteralType && parameter.Scope != InputParameterScope.Constant
                    // The base generator also reads the client field for a method-scoped
                    // API-version default. Scope alone does not identify all field users.
                    && (parameter.Scope == InputParameterScope.Client
                        || parameter.IsApiVersion && parameter.DefaultValue is not null))
                && !inputClient.UsesOperationApiVersion(method));

        internal bool UsesOperationApiVersion(InputServiceMethod method)
            => inputClient.NeedsOperationApiVersion
                && method.Operation.Parameters.FirstOrDefault(parameter => parameter.IsApiVersion) is InputQueryParameter
                && (inputClient.HasOperationApiVersionDefaults
                    || ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas.Any(resource =>
                        resource.Methods.Any(resourceMethod => ReferenceEquals(resourceMethod.InputMethod, method))));

        /// <summary>
        /// Gets the API version for this client from its <see cref="InputClient.ApiVersions"/>.
        /// </summary>
        public string CurrentApiVersion
            => inputClient.ApiVersions.LastOrDefault()
                ?? throw new InvalidOperationException($"Cannot determine API version for client '{inputClient.Name}'. The client has no API versions defined.");
    }
}
