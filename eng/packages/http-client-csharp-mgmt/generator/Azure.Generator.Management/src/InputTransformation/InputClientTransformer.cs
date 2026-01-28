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
            foreach (var method in client.Methods)
            {
                // TODO -- method also has a parameters list. We need to modify that list as well.
                var operation = method.Operation;
                SetSubscriptionIdToMethodParameter(operation);
                RemoveSubscriptionIdFromClient(client);
            }

            return client;
        }

        // Remove subscriptionId from client parameter, this is needed due to MTG.
        // Otherwise, subscriptionId will be added to client constructor
        private static void RemoveSubscriptionIdFromClient(InputClient client)
        {
            var updatedParameters = new List<InputParameter>();
            foreach (var parameter in client.Parameters)
            {
                if (!parameter.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    updatedParameters.Add(parameter);
                }
            }
            client.Update(parameters: updatedParameters);
        }

        private static void SetSubscriptionIdToMethodParameter(InputOperation operation)
        {
            foreach (var parameter in operation.Parameters)
            {
                if (parameter is InputPathParameter pathParameter && pathParameter.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    // Always set subscriptionId to method parameter
                    pathParameter.Update(InputParameterScope.Method);
                }
            }
        }
    }
}
