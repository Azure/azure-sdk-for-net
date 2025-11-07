// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly Dictionary<InputServiceMethod, (InputMethodParameter? ReturnClientRequestId, InputMethodParameter? XmsClientRequestId, InputMethodParameter? ClientRequestId)> _serviceMethodParameterMap;

        public ClientRequestIdHeaderVisitor(bool includeXmsClientRequestIdInRequest = false)
        {
            _includeXmsClientRequestIdInRequest = includeXmsClientRequestIdInRequest;
            _serviceMethodParameterMap = [];
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
            var hasRequestIdParameters = clientRequestIdParameter != null ||
                                         xMsClientRequestIdParameter != null ||
                                         returnClientRequestIdParameter != null;

            if (hasRequestIdParameters)
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

                if (hasRequestIdParameters)
                {
                    _serviceMethodParameterMap.TryAdd(serviceMethod, (returnClientRequestIdParameter, xMsClientRequestIdParameter, clientRequestIdParameter));
                }

                // Reset the rest client so that its methods are rebuilt.
                client.RestClient.Reset();
            }

            return methods;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.Kind != ScmMethodKind.CreateRequest ||
                method.ServiceMethod == null ||
                !_serviceMethodParameterMap.TryGetValue(method.ServiceMethod, out var parameters))
            {
                return method;
            }

            var (returnClientRequestIdParameter, xMsClientRequestIdParameter, clientRequestIdParameter) = parameters;

            var originalBodyStatements = method.BodyStatements!.ToList();

            // Find the request variable
            VariableExpression? requestVariable = null;
            var sb = new StringBuilder();
            foreach (var statement in originalBodyStatements)
            {
                sb.Append(statement.ToDisplayString());
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
            if (request == null)
            {
                return method;
            }

            if (returnClientRequestIdParameter?.DefaultValue?.Value != null)
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

            if (_includeXmsClientRequestIdInRequest && xMsClientRequestIdParameter != null)
            {
                SetClientRequestId(xMsClientRequestIdParameter, method, request);
            }

            if (clientRequestIdParameter != null)
            {
                SetClientRequestId(clientRequestIdParameter, method, request);
            }

            return method;
        }

        private static void SetClientRequestId(
            InputMethodParameter clientRequestIdParameter,
            ScmMethodProvider method,
            HttpRequestApi request)
        {
            var originalBodyStatements = method.BodyStatements!.ToList();

            // Exclude the last statement which is the return statement. We will add it back later.
            var newStatements = new List<MethodBodyStatement>(originalBodyStatements[..^1]);

            newStatements.Add(request.SetHeaders(
            [
                Literal(clientRequestIdParameter.SerializedName),
                request.ClientRequestId()
            ]));

            // Add the return statement back
            newStatements.Add(originalBodyStatements[^1]);

            method.Update(bodyStatements: newStatements);
        }
    }
}
