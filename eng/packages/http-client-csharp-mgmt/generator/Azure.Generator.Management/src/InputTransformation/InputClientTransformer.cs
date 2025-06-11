// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.InputTransformation
{
    internal static class InputClientTransformer
    {
        public static InputClient? TransformInputClient(InputClient client)
        {
            var methodsToKeep = new List<InputServiceMethod>();
            foreach (var method in client.Methods)
            {
                var operation = method.Operation;
                // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
                if (operation.CrossLanguageDefinitionId != "Azure.ResourceManager.Operations.list")
                {
                    SetSubscriptionIdToMethodParameter(operation);
                    methodsToKeep.Add(method);
                }
            }

            // We removed the list operation above, we should skip the empty client afterwards
            // There is no need to check sub-clients or custom code since it is specific to handle the above removing
            if (methodsToKeep.Count == 0) return null;

            return new InputClient(client.Name, client.Namespace, client.CrossLanguageDefinitionId, client.Summary, client.Doc, methodsToKeep, client.Parameters, client.Parent, client.Children);
        }

        private static void SetSubscriptionIdToMethodParameter(InputOperation operation)
        {
            foreach (var parameter in operation.Parameters)
            {
                if (parameter.NameInRequest.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    // Always set subscriptionId to method parameter
                    parameter.Update(InputParameterKind.Method);
                }
            }
        }
    }
}
