// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities
{
    internal static class OperationMethodParameterHelper
    {
        // TODO -- we should be able to just use the parameters from convenience method. But currently the xml doc provider has some bug that we build the parameters prematurely.
        public static IReadOnlyList<ParameterProvider> GetOperationMethodParameters(
            InputServiceMethod serviceMethod,
            ContextualPath contextualPath,
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

            // TODO -- Refactor needed. we need the same mapping in RequestPathPatternExtensions.PopulateArguments method.
            // To avoid large scale of refactoring right now, we just call this method twice to build the map twice.
            var pathParameterMapping = contextualPath.BuildParameterMapping(new(serviceMethod.Operation.Path));

            // TODO -- considering to change here instead of iterating on raw parameters, iterating on the convenience method parameters in which the parameters have been transformed properly.
            for (int i = 0; i < serviceMethod.Operation.Parameters.Count; i++)
            {
                var parameter = serviceMethod.Operation.Parameters[i];
                if (parameter.Scope != InputParameterScope.Method)
                {
                    continue;
                }

                var outputParameter = ManagementClientGenerator.Instance.TypeFactory.CreateParameter(parameter)!.ToPublicInputParameter();

                // if the parameter can be found in the parameter mapping meaning it is a contextual parameter which should not show up on the signature.
                if (pathParameterMapping.TryGetValue(outputParameter.Name, out var pathParameter) &&
                    pathParameter.IsContextual)
                {
                    continue;
                }

                // TODO -- maybe we no longer need this?
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
    }
}