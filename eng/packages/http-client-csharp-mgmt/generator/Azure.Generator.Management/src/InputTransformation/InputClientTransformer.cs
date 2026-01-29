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
                // remove and return the subscriptionId parameter if any
                var subscriptionIdParameter = RemoveSubscriptionIdFromClient(client);
                if (subscriptionIdParameter is InputMethodParameter methodParameter)
                {
                    // if client has this subscriptionId parameter, we need to add it into the parameter list of the method again
                    UpdateInputMethodParameters(method, methodParameter);
                }
                SetSubscriptionIdToMethodParameter(method.Operation);
            }

            return client;
        }

        // Remove subscriptionId from client parameter, this is needed due to MTG.
        // Otherwise, subscriptionId will be added to client constructor
        private static InputParameter? RemoveSubscriptionIdFromClient(InputClient client)
        {
            var updatedParameters = new List<InputParameter>(client.Parameters.Count);
            InputParameter? subscriptionIdParameter = null;
            foreach (var parameter in client.Parameters)
            {
                if (!parameter.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    updatedParameters.Add(parameter);
                }
                else
                {
                    subscriptionIdParameter = parameter;
                }
            }
            client.Update(parameters: updatedParameters);

            return subscriptionIdParameter;
        }

        private static void UpdateInputMethodParameters(InputServiceMethod method, InputMethodParameter subscriptionIdParameter)
        {
            subscriptionIdParameter.Update(scope: InputParameterScope.Method);
            IReadOnlyList<InputMethodParameter> updatedParameters = [subscriptionIdParameter, .. method.Parameters];
            method.Update(parameters: updatedParameters);
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
