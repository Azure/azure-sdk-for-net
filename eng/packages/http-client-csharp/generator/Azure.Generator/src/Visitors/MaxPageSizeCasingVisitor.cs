// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that fixes the casing of "maxpagesize" parameter to "maxPageSize" in ScmMethodProvider methods.
    /// </summary>
    internal class MaxPageSizeCasingVisitor : ScmLibraryVisitor
    {
        private const string IncorrectParameterName = "maxpagesize";
        private const string CorrectParameterName = "maxPageSize";

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            UpdateMethodParameterCasing(method);
            return method;
        }

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            if (methods != null)
            {
                foreach (var method in methods)
                {
                    UpdateMethodParameterCasing(method);
                }
            }

            return methods;
        }

        private static void UpdateMethodParameterCasing(ScmMethodProvider method)
        {
            var parameters = method.Signature.Parameters;
            var needsUpdate = false;
            var updatedParameters = new List<ParameterProvider>();

            foreach (var parameter in parameters)
            {
                if (parameter.Name == IncorrectParameterName)
                {
                    var updatedParameter = new ParameterProvider(
                        CorrectParameterName,
                        parameter.Description,
                        parameter.Type,
                        parameter.DefaultValue,
                        parameter.IsRef,
                        parameter.IsOut,
                        parameter.IsIn,
                        parameter.IsParams,
                        parameter.Attributes,
                        parameter.Property,
                        parameter.Field,
                        parameter.InitializationValue,
                        parameter.Location,
                        parameter.WireInfo,
                        parameter.Validation);

                    updatedParameters.Add(updatedParameter);
                    needsUpdate = true;
                }
                else
                {
                    updatedParameters.Add(parameter);
                }
            }

            if (needsUpdate)
            {
                method.Signature.Update(parameters: updatedParameters);
            }
        }
    }
}