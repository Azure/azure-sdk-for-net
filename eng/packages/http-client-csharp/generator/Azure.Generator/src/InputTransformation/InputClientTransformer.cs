// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Input;
using System;
using System.Collections.Generic;

namespace Azure.Generator.InputTransformation
{
    internal static class InputClientTransformer
    {
        public static InputClient? TransformInputClient(InputClient client)
        {
            var operationsToKeep = new List<InputOperation>();
            foreach (var operation in client.Operations)
            {
                // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
                if (operation.CrossLanguageDefinitionId != "Azure.ResourceManager.Operations.list")
                {
                    var transformedOperation = new InputOperation(operation.Name, operation.ResourceName, operation.Summary, operation.Doc, operation.Deprecated, operation.Accessibility, TransformInputOperationParameters(operation), operation.Responses, operation.HttpMethod, operation.RequestBodyMediaType, operation.Uri, operation.Path, operation.ExternalDocsUrl, operation.RequestMediaTypes, operation.BufferResponse, operation.LongRunning, operation.Paging, operation.GenerateProtocolMethod, operation.GenerateConvenienceMethod, operation.CrossLanguageDefinitionId);
                    operationsToKeep.Add(transformedOperation);
                }
            }

            // We removed the list operation above, we should skip the empty client afterwards
            // There is no need to check sub-clients or custom code since it is specific to handle the above removing
            if (operationsToKeep.Count == 0) return null;

            return new InputClient(client.Name, client.Summary, client.Doc, operationsToKeep, client.Parameters, client.Parent);
        }

        private static IReadOnlyList<InputParameter> TransformInputOperationParameters(InputOperation operation)
        {
            var parameters = new List<InputParameter>();
            foreach (var parameter in operation.Parameters)
            {
                if (parameter.NameInRequest.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    // Always set subscriptionId to method parameter
                    parameters.Add(new InputParameter(parameter.Name, parameter.NameInRequest, parameter.Summary, parameter.Doc, parameter.Type, parameter.Location, parameter.DefaultValue, InputOperationParameterKind.Method, parameter.IsRequired, parameter.IsApiVersion, parameter.IsResourceParameter, parameter.IsContentType, parameter.IsEndpoint, parameter.SkipUrlEncoding, parameter.Explode, parameter.ArraySerializationDelimiter, parameter.HeaderCollectionPrefix));
                }
                else
                {
                    parameters.Add(parameter);
                }
            }
            return parameters;
        }
    }
}
