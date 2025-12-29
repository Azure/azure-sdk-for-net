// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities
{
    internal static class OperationMethodParameterHelper
    {
        private const string IfMatch = "If-Match";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";

        private static readonly HashSet<string> _conditionalHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            IfMatch,
            IfNoneMatch,
            IfModifiedSince,
            IfUnmodifiedSince,
            "ifMatch",
            "ifNoneMatch",
            "ifModifiedSince",
            "ifUnmodifiedSince",
        };

        // TODO -- we should be able to just use the parameters from convenience method. But currently the xml doc provider has some bug that we build the parameters prematurely.
        public static IReadOnlyList<ParameterProvider> GetOperationMethodParameters(
            InputServiceMethod serviceMethod,
            RequestPathPattern contextualPath,
            TypeProvider? enclosingTypeProvider,
            bool forceLro = false)
        {
            var requiredParameters = new List<ParameterProvider>();
            var optionalParameters = new List<ParameterProvider>();
            var scopeParameterTransformed = false;
            var conditionalHeaders = new List<ParameterProvider>();
            var hasIfMatch = false;
            var hasIfNoneMatch = false;
            var hasIfModifiedSince = false;
            var hasIfUnmodifiedSince = false;

            // Add WaitUntil parameter for long-running operations
            if (forceLro || serviceMethod.IsLongRunningOperation())
            {
                requiredParameters.Add(KnownAzureParameters.WaitUntil);
            }

            foreach (var parameter in serviceMethod.Operation.Parameters)
            {
                if (parameter.Scope != InputParameterScope.Method)
                {
                    continue;
                }

                var outputParameter = ManagementClientGenerator.Instance.TypeFactory.CreateParameter(parameter)!;

                if (contextualPath.TryGetContextualParameter(outputParameter, out _))
                {
                    continue;
                }

                if (enclosingTypeProvider is ResourceCollectionClientProvider collectionProvider &&
                    collectionProvider.TryGetPrivateFieldParameter(outputParameter, out _))
                {
                    continue;
                }

                // For extension-scoped operations in MockableArmClient, transform the first string parameter to ResourceIdentifier scope
                // This is the scope parameter for non-resource operations
                if (enclosingTypeProvider is MockableArmClientProvider &&
                    !scopeParameterTransformed &&
                    parameter.Type is InputPrimitiveType primitiveType &&
                    primitiveType.Kind == InputPrimitiveTypeKind.String)
                {
                    // Update the parameter to use ResourceIdentifier type and "scope" name while preserving wire info
                    outputParameter.Update(name: "scope", description: $"The scope that the resource will apply against.", type: typeof(ResourceIdentifier));
                    scopeParameterTransformed = true;
                }

                if (parameter.Type is InputModelType modelType && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(modelType))
                {
                    outputParameter.Update(name: "data");
                }

                // Rename body parameters for resource/resourcecollection/mockablearmclient operations
                if ((enclosingTypeProvider is ResourceClientProvider or ResourceCollectionClientProvider or MockableArmClientProvider) &&
                    (serviceMethod.Operation.HttpMethod == "PUT" || serviceMethod.Operation.HttpMethod == "POST" || serviceMethod.Operation.HttpMethod == "PATCH"))
                {
                    var normalizedName = BodyParameterNameNormalizer.GetNormalizedBodyParameterName(outputParameter);
                    if (normalizedName != null)
                    {
                        outputParameter.Update(name: normalizedName);
                    }
                }

                // Check if this is a conditional header parameter
                var serializedName = outputParameter.WireInfo?.SerializedName ?? outputParameter.Name;
                if (_conditionalHeaders.Contains(serializedName))
                {
                    conditionalHeaders.Add(outputParameter);
                    if (serializedName.Equals(IfMatch, StringComparison.OrdinalIgnoreCase) || serializedName.Equals("ifMatch", StringComparison.OrdinalIgnoreCase))
                    {
                        hasIfMatch = true;
                    }
                    else if (serializedName.Equals(IfNoneMatch, StringComparison.OrdinalIgnoreCase) || serializedName.Equals("ifNoneMatch", StringComparison.OrdinalIgnoreCase))
                    {
                        hasIfNoneMatch = true;
                    }
                    else if (serializedName.Equals(IfModifiedSince, StringComparison.OrdinalIgnoreCase) || serializedName.Equals("ifModifiedSince", StringComparison.OrdinalIgnoreCase))
                    {
                        hasIfModifiedSince = true;
                    }
                    else if (serializedName.Equals(IfUnmodifiedSince, StringComparison.OrdinalIgnoreCase) || serializedName.Equals("ifUnmodifiedSince", StringComparison.OrdinalIgnoreCase))
                    {
                        hasIfUnmodifiedSince = true;
                    }
                    continue; // Don't add individual conditional headers yet
                }

                if (parameter.IsRequired)
                {
                    requiredParameters.Add(outputParameter);
                }
                else
                {
                    optionalParameters.Add(outputParameter);
                }
            }

            // Handle conditional headers transformation
            if (conditionalHeaders.Count > 0)
            {
                var conditionsParam = CreateConditionsParameter(conditionalHeaders, hasIfMatch, hasIfNoneMatch, hasIfModifiedSince, hasIfUnmodifiedSince);
                optionalParameters.Add(conditionsParam);
            }

            optionalParameters.Add(KnownParameters.CancellationTokenParameter);

            return [.. requiredParameters, .. optionalParameters];
        }

        private static ParameterProvider CreateConditionsParameter(
            IReadOnlyList<ParameterProvider> conditionalHeaders,
            bool hasIfMatch,
            bool hasIfNoneMatch,
            bool hasIfModifiedSince,
            bool hasIfUnmodifiedSince)
        {
            // If only a single IfMatch or IfNoneMatch, use ETag? type
            if (conditionalHeaders.Count == 1 && (hasIfMatch || hasIfNoneMatch))
            {
                var param = conditionalHeaders[0];
                param.Update(type: new CSharpType(typeof(ETag), true));
                return param;
            }

            // If both IfMatch and IfNoneMatch, use MatchConditions
            // Do NOT pass wireInfo to avoid SerializedName matching issues
            if (hasIfMatch && hasIfNoneMatch && !hasIfModifiedSince && !hasIfUnmodifiedSince)
            {
                return new ParameterProvider(
                    "matchConditions",
                    $"The content to send as the request conditions of the request.",
                    new CSharpType(typeof(MatchConditions), true));
            }

            // Otherwise use RequestConditions
            return new ParameterProvider(
                "requestConditions",
                $"The content to send as the request conditions of the request.",
                new CSharpType(typeof(RequestConditions), true));
        }
    }
}