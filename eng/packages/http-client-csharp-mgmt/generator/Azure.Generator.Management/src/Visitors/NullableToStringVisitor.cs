// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Management.Visitors
{
    /// <summary>
    /// Visitor that transforms nullable parameter ToString() calls to use the null-conditional operator.
    /// Replaces patterns like "parameter.ToString()" with "parameter?.ToString()" in CreateXxxRequest method calls.
    /// </summary>
    internal class NullableToStringVisitor : ScmLibraryVisitor
    {
        protected override InvokeMethodExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            // Check if this is a CreateXxxRequest method call on a RestClient
            // These methods are the ones that build HTTP requests and may receive nullable enum parameters
            // We use string matching because the RestClient types are generated and don't have a common base type
            if (expression.MethodName != null &&
                expression.MethodName.StartsWith("Create") &&
                expression.MethodName.EndsWith("Request"))
            {
                // Transform any ToString() call arguments to use null-conditional operator
                var transformedArguments = TransformArguments(expression.Arguments);
                if (transformedArguments != null)
                {
                    // Update the method invocation with transformed arguments
                    expression.Update(arguments: transformedArguments);
                }
            }

            // Call base to continue visiting
            var result = base.VisitInvokeMethodExpression(expression, method);
            return result as InvokeMethodExpression;
        }

        private List<ValueExpression>? TransformArguments(IReadOnlyList<ValueExpression> arguments)
        {
            List<ValueExpression>? transformedArguments = null;
            bool needsTransformation = false;

            for (int i = 0; i < arguments.Count; i++)
            {
                var arg = arguments[i];

                // Check if this argument is a ToString() call
                if (arg is InvokeMethodExpression toStringCall &&
                    toStringCall.MethodName == "ToString" &&
                    toStringCall.Arguments.Count == 0 &&
                    toStringCall.InstanceReference != null)
                {
                    // Initialize the transformed list if needed
                    if (transformedArguments == null)
                    {
                        transformedArguments = new List<ValueExpression>(arguments);
                    }

                    // Replace parameter.ToString() with parameter?.ToString()
                    // This is safe for both nullable and non-nullable types in C#
                    // For nullable types, it prevents NullReferenceException
                    // For non-nullable types, it's a no-op since they can't be null
                    var nullConditionalToString = toStringCall.InstanceReference.NullConditional().Invoke("ToString");
                    transformedArguments[i] = nullConditionalToString;
                    needsTransformation = true;
                }
            }

            return needsTransformation ? transformedArguments : null;
        }
    }
}
