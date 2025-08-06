// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
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
            RequestPathPattern contextualPath,
            bool forceLro = false)
        {
            var requiredParameters = new List<ParameterProvider>();
            var optionalParameters = new List<ParameterProvider>();

            // Add WaitUntil parameter for long-running operations
            if (forceLro || serviceMethod.IsLongRunningOperation())
            {
                requiredParameters.Add(KnownAzureParameters.WaitUntil);
            }

            foreach (var parameter in serviceMethod.Operation.Parameters)
            {
                if (parameter.Kind != InputParameterKind.Method)
                {
                    continue;
                }

                var outputParameter = ManagementClientGenerator.Instance.TypeFactory.CreateParameter(parameter)!;
                if (!contextualPath.TryGetContextualParameter(outputParameter, out _))
                {
                    if (parameter.Type is InputModelType modelType && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(modelType))
                    {
                        outputParameter.Update(name: "data");
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
            }

            optionalParameters.Add(KnownParameters.CancellationTokenParameter);

            return [.. requiredParameters, .. optionalParameters];
        }
    }
}