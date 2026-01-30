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
                // TCGC has a default rule to put parameters with the name of subscriptionId into the client, instead of like other path parameters in the method.
                // because our implementation of the operation context, subscriptionId is always part of the context,
                // especially in some rare cases, there are parameters with the name subscriptionId which are not the real subscriptionId for the ARM subscription,
                // we must ensure the subscriptionId parameter is in the method.
                TransformSubscriptionIdParameter(client, method);
            }

            return client;
        }

        private static void TransformSubscriptionIdParameter(InputClient client, InputServiceMethod method)
        {
            // first we need to see if the Operation has a `Client` parameter for subscriptionId
            var hasClientSubscriptionIdParameter = SetSubscriptionIdInOperationToMethodParameter(method.Operation);

            // if we do not have such a parameter, just returns
            if (!hasClientSubscriptionIdParameter)
            {
                return;
            }

            // now we need to remove the parameter from the client's parameters.
            var subscriptionIdParameter = RemoveSubscriptionIdFromClient(client);

            // then we need to update the parameters of the method to add this parameter back
            // we need to figure out the correct order of parameters in Operation first, then insert the new parameter into the corresponding position.
            if (subscriptionIdParameter is not null)
            {
                UpdateInputMethodParameters(method, subscriptionIdParameter);
            }
        }

        private static bool SetSubscriptionIdInOperationToMethodParameter(InputOperation operation)
        {
            foreach (var parameter in operation.Parameters)
            {
                // if there is a path parameter name of subscriptionId and it has a client scope, we need to set its scope to Method
                if (parameter is InputPathParameter { Scope: InputParameterScope.Client } pathParameter
                    && pathParameter.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    // set subscriptionId to method parameter
                    pathParameter.Update(InputParameterScope.Method);
                    return true;
                }
            }
            return false;
        }

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

        private static void UpdateInputMethodParameters(InputServiceMethod method, InputParameter subscriptionIdParameter)
        {
            // Create a new InputMethodParameter from the InputParameter
            var subscriptionIdMethodParameter = new InputMethodParameter(
                subscriptionIdParameter.Name,
                subscriptionIdParameter.Summary,
                subscriptionIdParameter.Doc,
                subscriptionIdParameter.Type,
                subscriptionIdParameter.IsRequired,
                subscriptionIdParameter.IsReadOnly,
                subscriptionIdParameter.Access,
                subscriptionIdParameter.SerializedName,
                subscriptionIdParameter.IsApiVersion,
                subscriptionIdParameter.DefaultValue,
                InputParameterScope.Method,
                InputRequestLocation.Path);

            // Find which parameter the subscriptionId comes after in the operation parameters
            string? insertAfterSerializedName = null;
            foreach (var param in method.Operation.Parameters)
            {
                if (param.SerializedName.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                insertAfterSerializedName = param.SerializedName;
            }

            // Build the new parameters list with subscriptionId inserted after the correct parameter
            var updatedParameters = new List<InputMethodParameter>(method.Parameters.Count + 1);

            // If subscriptionId is the first parameter in operation (insertAfterSerializedName is null), insert at the beginning
            if (insertAfterSerializedName is null)
            {
                updatedParameters.Add(subscriptionIdMethodParameter);
                updatedParameters.AddRange(method.Parameters);
            }
            else
            {
                bool inserted = false;
                foreach (var param in method.Parameters)
                {
                    updatedParameters.Add(param);

                    // Insert subscriptionId after the parameter it follows in the operation
                    if (!inserted && param.SerializedName != null &&
                        param.SerializedName.Equals(insertAfterSerializedName, StringComparison.OrdinalIgnoreCase))
                    {
                        updatedParameters.Add(subscriptionIdMethodParameter);
                        inserted = true;
                    }
                }

                // If the parameter we should insert after wasn't found in method parameters, add at the end
                if (!inserted)
                {
                    updatedParameters.Add(subscriptionIdMethodParameter);
                }
            }

            method.Update(parameters: updatedParameters);
        }
    }
}
