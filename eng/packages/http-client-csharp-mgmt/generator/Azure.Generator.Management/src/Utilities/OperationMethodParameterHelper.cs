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
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal static class OperationMethodParameterHelper
    {
        // TODO -- we should be able to just use the parameters from convenience method. But currently the xml doc provider has some bug that we build the parameters prematurely.
        public static IReadOnlyList<ParameterProvider> GetOperationMethodParameters(
            InputServiceMethod serviceMethod,
            MethodProvider convenienceMethod,
            ParameterContextRegistry parameterMapping,
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

            // Build a dictionary of convenience method parameters by name for efficient lookup
            var convenienceParamsByName = convenienceMethod.Signature.Parameters
                .Where(p => !p.Type.Equals(typeof(System.Threading.CancellationToken)))
                .ToDictionary(p => p.Name, p => p);

            // Loop through service method parameters and check their scope
            foreach (var inputParameter in serviceMethod.Operation.Parameters)
            {
                // Only include parameters with Method scope
                if (inputParameter.Scope != InputParameterScope.Method)
                {
                    continue;
                }

                // Create temporary parameter to check filtering conditions
                var tempParameter = ManagementClientGenerator.Instance.TypeFactory.CreateParameter(inputParameter)!;

                // Skip contextual parameters
                if (parameterMapping.TryGetValue(tempParameter.WireInfo.SerializedName, out var mapping) && mapping.ContextualParameter is not null)
                {
                    continue;
                }

                // Try to find corresponding parameter in convenience method by name
                ParameterProvider? outputParameter = null;
                var inputParamName = tempParameter.Name;

                // Check if convenience method has a parameter with the same name
                if (convenienceParamsByName.TryGetValue(inputParamName, out var matchedParam))
                {
                    outputParameter = matchedParam;
                }
                else
                {
                    // If no match by name, create it from input parameter
                    outputParameter = tempParameter;
                }

                // TODO -- we should be able to just update the parameters from convenience method.
                // But currently the xml doc provider has some bug that we build the parameters prematurely, we create new instance here instead.

                // Rename resource model parameters to "data"
                if (inputParameter.Type is InputModelType modelType && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(modelType))
                {
                    outputParameter = RenameWithNewInstance(outputParameter, "data");
                }

                // Apply name transformations as needed
                // For extension-scoped operations in MockableArmClient, transform the first string parameter to ResourceIdentifier scope
                if (enclosingTypeProvider is MockableArmClientProvider &&
                    !scopeParameterTransformed &&
                    inputParameter.Type is InputPrimitiveType primitiveType &&
                    primitiveType.Kind == InputPrimitiveTypeKind.String)
                {
                    outputParameter = RenameWithNewInstance(outputParameter, "scope", description: $"The scope that the resource will apply against.", typeof(ResourceIdentifier));
                    scopeParameterTransformed = true;
                }

                // Rename body parameters for Resource/ResourceCollection/MockableArmClient/MockableResource operations
                if ((enclosingTypeProvider is ResourceClientProvider or ResourceCollectionClientProvider or MockableArmClientProvider or MockableResourceProvider) &&
                    (serviceMethod.Operation.HttpMethod == "PUT" || serviceMethod.Operation.HttpMethod == "POST" || serviceMethod.Operation.HttpMethod == "PATCH"))
                {
                    var normalizedName = BodyParameterNameNormalizer.GetNormalizedBodyParameterName(outputParameter);
                    if (normalizedName != null)
                    {
                        outputParameter = RenameWithNewInstance(outputParameter, normalizedName);
                    }
                }

                if (inputParameter.IsRequired)
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

        private static ParameterProvider RenameWithNewInstance(ParameterProvider outputParameter, string normalizedName, FormattableString? description = null, Type? type = null)
            => new(
                    name: normalizedName,
                    description: description ?? outputParameter.Description,
                    type: type ?? outputParameter.Type,
                    defaultValue: outputParameter.DefaultValue,
                    isRef: outputParameter.IsRef,
                    isOut: outputParameter.IsOut,
                    isIn: outputParameter.IsIn,
                    isParams: outputParameter.IsParams,
                    attributes: outputParameter.Attributes,
                    property: outputParameter.Property,
                    field: outputParameter.Field,
                    initializationValue: outputParameter.InitializationValue,
                    location: outputParameter.Location,
                    wireInfo: outputParameter.WireInfo,
                    validation: outputParameter.Validation);
    }
}