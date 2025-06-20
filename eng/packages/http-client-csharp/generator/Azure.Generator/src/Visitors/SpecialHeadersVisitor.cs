// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor to handle removing special header parameters from service methods and adding them to the request. Note,
    /// "x-ms-client-request-id" is not added to the request as it is handled by the Azure.Core pipeline.
    /// </summary>
    internal class SpecialHeadersVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            var clientRequestIdParameter =
                serviceMethod.Operation.Parameters.FirstOrDefault(p => p.NameInRequest == "client-request-id");
            var returnClientRequestIdParameter =
                serviceMethod.Operation.Parameters.FirstOrDefault(p => p.NameInRequest == "return-client-request-id");
            var xMsClientRequestIdParameter =
                serviceMethod.Operation.Parameters.FirstOrDefault(p => p.NameInRequest == "x-ms-client-request-id");

            if (clientRequestIdParameter != null || returnClientRequestIdParameter != null || xMsClientRequestIdParameter != null)
            {
                serviceMethod.Update(parameters: serviceMethod.Parameters
                    .Where(p => p != clientRequestIdParameter && p != returnClientRequestIdParameter && p != xMsClientRequestIdParameter)
                    .ToList());
                serviceMethod.Operation.Update(parameters: serviceMethod.Parameters);

                // Create a new method collection with the updated service method
                methods = new ScmMethodProviderCollection(serviceMethod, client);

                // Reset the rest client so that its methods are rebuilt.
                client.RestClient.Reset();
                var createRequestMethod = client.RestClient.GetCreateRequestMethod(serviceMethod.Operation);

                var originalBodyStatements = createRequestMethod.BodyStatements!.ToList();

                // Exclude the last statement which is the return statement. We will add it back later.
                var newStatements = new List<MethodBodyStatement>(originalBodyStatements[..^1]);

                // Find the request variable
                VariableExpression? requestVariable = null;
                foreach (var statement in newStatements)
                {
                    if (statement is ExpressionStatement
                        {
                            Expression: AssignmentExpression { Variable: DeclarationExpression declaration }
                        })
                    {
                        var variable = declaration.Variable;
                        if (variable.Type.Equals(typeof(Request)))
                        {
                            requestVariable = variable;
                        }
                    }
                }

                if (clientRequestIdParameter != null)
                {
                    // Set the client-request-id header
                    newStatements.Add(requestVariable!.As<Request>().SetHeaderValue(
                        clientRequestIdParameter.NameInRequest, requestVariable.Property(nameof(Request.ClientRequestId))));
                }
                if (returnClientRequestIdParameter != null)
                {
                    // Set the return-client-request-id header
                    newStatements.Add(requestVariable!.As<Request>().SetHeaderValue(
                        returnClientRequestIdParameter.NameInRequest, Literal(returnClientRequestIdParameter.DefaultValue?.Value ?? "true")));
                }

                // Add the return statement back
                newStatements.Add(originalBodyStatements[^1]);

                createRequestMethod.Update(bodyStatements: newStatements);
            }

            return methods;
        }
    }
}