// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies service methods to set the `client-request-id`, `x-ms-client-request-id`, and `return-client-request-id` headers.
    /// </summary>
    internal class ClientRequestIdHeaderVisitor : ScmLibraryVisitor
    {
        private const string ClientRequestIdParameterName = "client-request-id";
        private const string XMsClientRequestIdParameterName = "x-ms-client-request-id";
        private const string ReturnClientRequestIdParameterName = "return-client-request-id";
        private readonly bool _includeXmsClientRequestIdInRequest;
        private readonly Dictionary<InputServiceMethod, InputMethodParameter?> _returnClientRequestIdParameterMap;

        public ClientRequestIdHeaderVisitor(bool includeXmsClientRequestIdInRequest = false)
        {
            _includeXmsClientRequestIdInRequest = includeXmsClientRequestIdInRequest;
            _returnClientRequestIdParameterMap = [];
        }

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            var clientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == ClientRequestIdParameterName);
            var xMsClientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == XMsClientRequestIdParameterName);
            var returnClientRequestIdParameter =
                serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == ReturnClientRequestIdParameterName);

            if (clientRequestIdParameter != null || xMsClientRequestIdParameter != null || returnClientRequestIdParameter != null)
            {
                // Update the service method to remove the client-request-id, x-ms-client-request-id, and return-client-request-id parameters from the request parameters
                serviceMethod.Update(parameters: [.. serviceMethod.Parameters.Where(p =>
                    p.SerializedName != ClientRequestIdParameterName &&
                    p.SerializedName != XMsClientRequestIdParameterName &&
                    p.SerializedName != ReturnClientRequestIdParameterName)]);
                serviceMethod.Operation.Update(parameters: [.. serviceMethod.Operation.Parameters.Where(p =>
                    p.SerializedName != ClientRequestIdParameterName &&
                    p.SerializedName != XMsClientRequestIdParameterName &&
                    p.SerializedName != ReturnClientRequestIdParameterName)]);

                // Create a new method collection with the updated service method
                methods = new ScmMethodProviderCollection(serviceMethod, client);

                // Store the return-client-request-id parameter for later use in VisitMethod
                if (returnClientRequestIdParameter != null)
                {
                    _returnClientRequestIdParameterMap.TryAdd(serviceMethod, returnClientRequestIdParameter);
                }

                // Reset the rest client so that its methods are rebuilt.
                client.RestClient.Reset();

                // Handle client-request-id and x-ms-client-request-id headers
                methods = AddClientIdHeaders(serviceMethod, client, methods, clientRequestIdParameter, xMsClientRequestIdParameter);
            }

            return methods;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            // Handle return-client-request-id parameter if it exists
            if (method.ServiceMethod is not null && _returnClientRequestIdParameterMap.TryGetValue(method.ServiceMethod, out var returnClientRequestIdParameter))
            {
                var originalBodyStatements = method.BodyStatements!.ToList();

                // Find the request variable
                VariableExpression? requestVariable = null;
                foreach (var statement in originalBodyStatements)
                {
                    if (statement is ExpressionStatement
                        {
                            Expression: AssignmentExpression { Variable: DeclarationExpression declaration }
                        })
                    {
                        var variable = declaration.Variable;
                        if (variable.Type.Equals(variable.ToApi<HttpRequestApi>().Type))
                        {
                            requestVariable = variable;
                            break;
                        }
                    }
                }

                var request = requestVariable?.ToApi<HttpRequestApi>();
                if (request != null && returnClientRequestIdParameter?.DefaultValue?.Value != null)
                {
                    if (bool.TryParse(returnClientRequestIdParameter.DefaultValue.Value.ToString(), out bool value))
                    {
                        // Exclude the last statement which is the return statement. We will add it back later.
                        var newStatements = new List<MethodBodyStatement>(originalBodyStatements[..^1]);

                        // Set the return-client-request-id header
                        newStatements.Add(request.SetHeaders(
                        [
                            Literal(returnClientRequestIdParameter.SerializedName),
                            Literal(value.ToString().ToLowerInvariant())
                        ]));

                        // Add the return statement back
                        newStatements.Add(originalBodyStatements[^1]);

                        method.Update(bodyStatements: newStatements);
                    }
                }
            }

            return method;
        }

        private ScmMethodProviderCollection? AddClientIdHeaders(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods,
            InputMethodParameter? clientRequestIdParameter,
            InputMethodParameter? xMsClientRequestIdParameter)
        {
            if (clientRequestIdParameter != null || xMsClientRequestIdParameter != null)
            {
                var createRequestMethod = client.RestClient.GetCreateRequestMethod(serviceMethod.Operation);
                var originalBodyStatements = createRequestMethod.BodyStatements!.ToList();

                // Find the request variable
                HttpRequestApi? requestVariable = null;
                foreach (var statement in originalBodyStatements)
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
                            break;
                        }
                    }
                }

                if (requestVariable != null)
                {
                    // Exclude the last statement which is the return statement. We will add it back later.
                    var newStatements = new List<MethodBodyStatement>(originalBodyStatements[..^1]);

                    // Set the client-request-id header
                    if (clientRequestIdParameter != null)
                    {
                        newStatements.Add(requestVariable.As<Request>().SetHeaderValue(
                            clientRequestIdParameter.SerializedName,
                            requestVariable.ClientRequestId()));
                    }

                    // Set the x-ms-client-request-id header if requested
                    if (_includeXmsClientRequestIdInRequest && xMsClientRequestIdParameter != null)
                    {
                        newStatements.Add(requestVariable.As<Request>().SetHeaderValue(
                            xMsClientRequestIdParameter.SerializedName,
                            requestVariable.ClientRequestId()));
                    }

                    // Add the return statement back
                    newStatements.Add(originalBodyStatements[^1]);
                    createRequestMethod.Update(bodyStatements: newStatements);
                }
            }

            return methods;
        }
    }
}
