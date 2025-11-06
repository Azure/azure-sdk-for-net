// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies service methods to set the `client-request-id` header.
    /// </summary>
    internal class RequestClientIdHeaderVisitor : ScmLibraryVisitor
    {
        private const string ClientRequestIdParameterName = "client-request-id";

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            var clientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == ClientRequestIdParameterName);

            if (clientRequestIdParameter != null)
            {
                // Update the service method to remove the client-request-id parameter from the request parameters
                serviceMethod.Update(parameters: [.. serviceMethod.Parameters.Where(p => p.SerializedName != ClientRequestIdParameterName)]);
                serviceMethod.Operation.Update(parameters: [.. serviceMethod.Operation.Parameters.Where(p => p.SerializedName != ClientRequestIdParameterName)]);

                // Create a new method collection with the updated service method
                methods = new ScmMethodProviderCollection(serviceMethod, client);

                // Reset the rest client so that its methods are rebuilt.
                client.RestClient.Reset();
                var createRequestMethod = client.RestClient.GetCreateRequestMethod(serviceMethod.Operation);
                var originalBodyStatements = createRequestMethod.BodyStatements!.ToList();

                // Exclude the last statement which is the return statement. We will add it back later.
                var newStatements = new List<MethodBodyStatement>(originalBodyStatements[..^1]);

                // Find the request variable
                HttpRequestApi? requestVariable = null;
                foreach (var statement in newStatements)
                {
                    if (statement is ExpressionStatement
                        {
                            Expression: AssignmentExpression { Variable: DeclarationExpression declaration }
                        })
                    {
                        var variable = declaration.Variable;
                        if (variable.Type.Equals(variable.ToApi<HttpRequestApi>().Type))
                        {
                            requestVariable = variable.ToApi<HttpRequestApi>();
                        }
                    }
                }

                if (requestVariable != null)
                {
                    // Set the client-request-id header
                    newStatements.Add(requestVariable.As<Request>().SetHeaderValue(
                        clientRequestIdParameter.SerializedName,
                        requestVariable.ClientRequestId()));
                }

                // Add the return statement back
                newStatements.Add(originalBodyStatements[^1]);
                createRequestMethod.Update(bodyStatements: newStatements);
            }

            return methods;
        }
    }
}
