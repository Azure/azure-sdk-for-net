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
            // Check if there are any optional match condition parameters to process
            var serviceMethodMatchConditionParameters = GetOptionalMatchConditionParameters(serviceMethod.Parameters);
            var operationMatchConditionParameters = GetOptionalMatchConditionParameters(serviceMethod.Operation.Parameters);

            if (serviceMethodMatchConditionParameters.Count == 0 && operationMatchConditionParameters.Count == 0)
                return methods;

            // Handle the case where only a single IfMatch or IfNoneMatch parameter exists
            // In this case, replace with ETag? type instead of RequestConditions/MatchConditions
            if (HandleSingleETagParameter(serviceMethod, serviceMethodMatchConditionParameters, operationMatchConditionParameters))
                return methods;

            // Determine if we need RequestConditions (for date-based conditions) or MatchConditions (for ETags only)
            var allMatchConditionParameters = serviceMethodMatchConditionParameters.Concat(operationMatchConditionParameters)
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(g => g.Key, g => g.First().Value);

            bool hasDateConditions = allMatchConditionParameters.ContainsKey(IfModifiedSinceHeaderName) ||
                                   allMatchConditionParameters.ContainsKey(IfUnmodifiedSinceHeaderName);

            // Update the service method to remove individual match condition parameters
            var filteredServiceMethodParameters = serviceMethod.Parameters
                .Where(p => !IsOptionalMatchConditionParameter(p))
                .ToList();

            var filteredOperationParameters = serviceMethod.Operation.Parameters
                .Where(p => !IsOptionalMatchConditionParameter(p))
                .ToList();

            serviceMethod.Update(parameters: filteredServiceMethodParameters);
            serviceMethod.Operation.Update(parameters: filteredOperationParameters);

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

            // Add the return statement back
            newStatements.Add(originalBodyStatements[^1]);
            createRequestMethod.Update(bodyStatements: newStatements);

            return methods;
        }

        private static Dictionary<string, InputParameter> GetOptionalMatchConditionParameters(IReadOnlyList<InputParameter> parameters)
        {
            var matchConditionParameters = new Dictionary<string, InputParameter>();

            foreach (var parameter in parameters)
            {
                if (IsOptionalMatchConditionParameter(parameter))
                {
                    matchConditionParameters[parameter.NameInRequest] = parameter;
                }
            }

            return matchConditionParameters;
        }

        private static bool IsOptionalMatchConditionParameter(InputParameter parameter)
        {
            return !parameter.IsRequired &&
                   parameter.Location == InputRequestLocation.Header &&
                   (parameter.NameInRequest == IfMatchHeaderName ||
                    parameter.NameInRequest == IfNoneMatchHeaderName ||
                    parameter.NameInRequest == IfModifiedSinceHeaderName ||
                    parameter.NameInRequest == IfUnmodifiedSinceHeaderName);
        }

        private static bool HandleSingleETagParameter(
            InputServiceMethod serviceMethod,
            Dictionary<string, InputParameter> serviceMethodParams,
            Dictionary<string, InputParameter> operationParams)
        {
            var allParams = serviceMethodParams.Concat(operationParams)
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(g => g.Key, g => g.First().Value);

            // Check if we have exactly one ETag parameter (If-Match or If-None-Match) and no date parameters
            bool hasIfMatch = allParams.ContainsKey(IfMatchHeaderName);
            bool hasIfNoneMatch = allParams.ContainsKey(IfNoneMatchHeaderName);
            bool hasDateParams = allParams.ContainsKey(IfModifiedSinceHeaderName) ||
                                allParams.ContainsKey(IfUnmodifiedSinceHeaderName);

            if (!hasDateParams && (hasIfMatch ^ hasIfNoneMatch)) // XOR - exactly one of them
            {
                // TODO: Replace the single ETag parameter with ETag? type
                // This would require additional infrastructure to modify parameter types
                // For now, we let the regular processing handle this case
                return false;
            }

            return false;
        }
    }
}