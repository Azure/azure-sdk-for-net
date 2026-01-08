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

                // For array body parameters, change the type from IList<T> to IEnumerable<T>
                if (outputParameter.Location == ParameterLocation.Body && IsArrayParameterType(outputParameter.Type, out var elementType))
                {
                    // Convert IList<T> to IEnumerable<T>
                    var enumerableType = new CSharpType(typeof(IEnumerable<>), elementType!);
                    outputParameter.Update(type: enumerableType);
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

                if (parameter.IsRequired)
                {
                    requiredParameters.Add(outputParameter);
                }
                else
                {
                    optionalParameters.Add(outputParameter);
                }
            }

            optionalParameters.Add(KnownParameters.CancellationTokenParameter);

            return [.. requiredParameters, .. optionalParameters];
        }

        private static bool IsArrayParameterType(CSharpType type, out CSharpType? elementType)
        {
            elementType = null;
            // Check if it's IList<T>, IEnumerable<T>, IReadOnlyList<T>, etc.
            if (type.IsGenericType && type.Arguments.Count == 1)
            {
                var frameworkType = type.FrameworkType;
                if (frameworkType != null)
                {
                    var typeName = frameworkType.Name;
                    if (typeName.StartsWith("IList") ||
                        typeName.StartsWith("IEnumerable") ||
                        typeName.StartsWith("IReadOnlyList") ||
                        typeName.StartsWith("ICollection"))
                    {
                        elementType = type.Arguments[0];
                        return true;
                    }
                }
            }
            return false;
        }
    }
}