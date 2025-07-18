// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

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

            // Update the service method to remove individual match condition parameters
            var filteredParameters = serviceMethod.Parameters
                .Where(p => !IsMatchConditionParameter(p))
                .ToList();

            serviceMethod.Update(parameters: filteredParameters);
            serviceMethod.Operation.Update(parameters: filteredParameters);

            // Create a new method collection with the updated service method
            methods = new ScmMethodProviderCollection(serviceMethod, client);

            // TODO: Add logic to modify method signatures to include RequestConditions/MatchConditions parameter
            // TODO: Add logic to modify request creation to use Azure.Core extension methods

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