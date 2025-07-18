// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies service methods to group conditional request headers into RequestConditions/MatchConditions types.
    /// </summary>
    internal class MatchConditionsVisitor : ScmLibraryVisitor
    {
        private const string IfMatchHeaderName = "If-Match";
        private const string IfNoneMatchHeaderName = "If-None-Match";
        private const string IfModifiedSinceHeaderName = "If-Modified-Since";
        private const string IfUnmodifiedSinceHeaderName = "If-Unmodified-Since";

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            var matchConditionParameters = GetMatchConditionParameters(serviceMethod.Parameters);
            
            if (matchConditionParameters.Count == 0)
                return methods;

            // Determine if we need RequestConditions (for date-based conditions) or MatchConditions (for ETags only)
            bool hasDateConditions = matchConditionParameters.ContainsKey(IfModifiedSinceHeaderName) || 
                                   matchConditionParameters.ContainsKey(IfUnmodifiedSinceHeaderName);

            // Update the service method to remove individual match condition parameters
            var filteredParameters = serviceMethod.Parameters
                .Where(p => !IsMatchConditionParameter(p))
                .ToList();

            serviceMethod.Update(parameters: filteredParameters);
            serviceMethod.Operation.Update(parameters: filteredParameters);

            // Create a new method collection with the updated service method
            methods = new ScmMethodProviderCollection(serviceMethod, client);

            // Reset the rest client so that its methods are rebuilt
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
                    if (variable.Type.Equals(variable.ToApi<HttpRequestApi>().Type))
                    {
                        requestVariable = variable;
                    }
                }
            }

            if (requestVariable != null)
            {
                // Create a placeholder parameter expression for the conditions
                // This would be properly wired up through method signature transformation
                string parameterName = hasDateConditions ? "requestConditions" : "matchConditions";
                var parameterType = hasDateConditions ? typeof(RequestConditions) : typeof(MatchConditions);
                var conditionsParameter = new ParameterExpression(parameterName, parameterType, null);
                
                // Add conditional header setting using Azure.Core extension methods
                if (hasDateConditions)
                {
                    // Generate: if (requestConditions != null) { request.Headers.Add(requestConditions, "R"); }
                    var condition = conditionsParameter.NotEqual(Null);
                    var headerStatement = requestVariable.Property(nameof(Request.Headers))
                        .Invoke("Add", conditionsParameter, Literal("R")).Terminate();
                    newStatements.Add(new IfStatement(condition, headerStatement));
                }
                else
                {
                    // Generate: if (matchConditions != null) { request.Headers.Add(matchConditions); }
                    var condition = conditionsParameter.NotEqual(Null);
                    var headerStatement = requestVariable.Property(nameof(Request.Headers))
                        .Invoke("Add", conditionsParameter).Terminate();
                    newStatements.Add(new IfStatement(condition, headerStatement));
                }
            }

            // Add the return statement back
            newStatements.Add(originalBodyStatements[^1]);
            createRequestMethod.Update(bodyStatements: newStatements);

            return methods;
        }

        private static Dictionary<string, InputParameter> GetMatchConditionParameters(IReadOnlyList<InputParameter> parameters)
        {
            var matchConditionParameters = new Dictionary<string, InputParameter>();
            
            foreach (var parameter in parameters)
            {
                if (IsMatchConditionParameter(parameter))
                {
                    matchConditionParameters[parameter.NameInRequest] = parameter;
                }
            }
            
            return matchConditionParameters;
        }

        private static bool IsMatchConditionParameter(InputParameter parameter)
        {
            return parameter.Location == InputRequestLocation.Header &&
                   (parameter.NameInRequest == IfMatchHeaderName ||
                    parameter.NameInRequest == IfNoneMatchHeaderName ||
                    parameter.NameInRequest == IfModifiedSinceHeaderName ||
                    parameter.NameInRequest == IfUnmodifiedSinceHeaderName);
        }
    }
}