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
        private const string ClientRequestIdParameterName = "client-request-id";
        private const string ReturnClientRequestIdParameterName = "return-client-request-id";
        private const string XMsClientRequestIdParameterName = "x-ms-client-request-id";
        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            var clientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.NameInRequest == ClientRequestIdParameterName);
            var returnClientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.NameInRequest == ReturnClientRequestIdParameterName);
            var xMsClientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.NameInRequest == XMsClientRequestIdParameterName);

            if (clientRequestIdParameter != null || returnClientRequestIdParameter != null || xMsClientRequestIdParameter != null)
            {
                serviceMethod.Update(parameters: serviceMethod.Parameters
                    .Where(p => p.NameInRequest != ClientRequestIdParameterName && p.NameInRequest != ReturnClientRequestIdParameterName && p.NameInRequest != XMsClientRequestIdParameterName)
                    .ToList());
                serviceMethod.Operation.Update(parameters: serviceMethod.Operation.Parameters
                    .Where(p => p.NameInRequest != ClientRequestIdParameterName && p.NameInRequest != ReturnClientRequestIdParameterName && p.NameInRequest != XMsClientRequestIdParameterName)
                    .ToList());

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

                if (returnClientRequestIdParameter?.DefaultValue?.Value != null)
                {
                    if (bool.TryParse(returnClientRequestIdParameter.DefaultValue.Value.ToString(), out bool value))
                    {
                        // Set the return-client-request-id header
                        newStatements.Add(requestVariable!.As<Request>().SetHeaderValue(
                            returnClientRequestIdParameter.NameInRequest,
                            Literal(value.ToString().ToLowerInvariant())));
                    }
                }

                // Add the return statement back
                newStatements.Add(originalBodyStatements[^1]);

                createRequestMethod.Update(bodyStatements: newStatements);
            }

            return methods;
        }
    }
}