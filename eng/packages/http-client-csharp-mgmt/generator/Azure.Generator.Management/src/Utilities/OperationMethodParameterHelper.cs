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
        /// <summary>
        /// Builds the operation method parameters by taking parameters from the convenience method
        /// and filtering out contextual parameters that can be derived from the resource identifier.
        /// </summary>
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

            // Build a dictionary of input parameters by serialized name for looking up additional info (like IsRequired)
            var inputParamsBySerializedName = serviceMethod.Operation.Parameters
                .Where(p => p.Scope == InputParameterScope.Method)
                .ToDictionary(p => p.SerializedName, p => p);

            // Iterate through the convenience method parameters directly
            // The convenience method has already been processed by visitors (e.g., MatchConditionsHeadersVisitor)
            // and contains the correct types (e.g., MatchConditions instead of separate ifMatch/ifNoneMatch)
            foreach (var convenienceParam in convenienceMethod.Signature.Parameters)
            {
                // Skip CancellationToken - we add it at the end
                if (convenienceParam.Type.Equals(typeof(System.Threading.CancellationToken)))
                {
                    continue;
                }

                // Get the serialized name from WireInfo if available
                var serializedName = convenienceParam.WireInfo?.SerializedName;

                // Check if this is a contextual parameter (can be derived from resource ID)
                // If contextual, skip it - it will be resolved from the resource identifier
                if (serializedName != null &&
                    parameterMapping.TryGetValue(serializedName, out var mapping) &&
                    mapping.ContextualParameter is not null)
                {
                    continue;
                }

                ParameterProvider outputParameter = convenienceParam;

                // Look up corresponding input parameter for additional transformations
                InputParameter? inputParameter = null;
                if (serializedName != null)
                {
                    inputParamsBySerializedName.TryGetValue(serializedName, out inputParameter);
                }

                // Rename resource model parameters to "data"
                if (inputParameter?.Type is InputModelType modelType && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(modelType))
                {
                    outputParameter = RenameWithNewInstance(outputParameter, "data");
                }

                // Apply name transformations as needed
                // For extension-scoped operations in MockableArmClient, transform the first string parameter to ResourceIdentifier scope
                if (enclosingTypeProvider is MockableArmClientProvider &&
                    !scopeParameterTransformed &&
                    inputParameter?.Type is InputPrimitiveType primitiveType &&
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

                // Determine if required based on whether parameter has a default value
                bool isRequired = outputParameter.DefaultValue == null;

                if (isRequired)
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