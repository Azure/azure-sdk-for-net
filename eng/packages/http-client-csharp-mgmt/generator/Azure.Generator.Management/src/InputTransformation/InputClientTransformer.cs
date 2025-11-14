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
                var operation = method.Operation;
                SetSubscriptionIdToMethodParameter(operation);
            }

            return client;
        }

        private static void RemoveSubscriptionIdFromClient(InputClient client)
        {
            var updatedParameters = new List<InputParameter>();
            foreach (var parameter in client.Parameters)
            {
                if (parameter is InputPathParameter pathParameter && pathParameter.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    // Remove subscriptionId from client parameter
                }
                else
                {
                    updatedParameters.Add(parameter);
                }
            }
            client.Parameters(updatedParameters);
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
