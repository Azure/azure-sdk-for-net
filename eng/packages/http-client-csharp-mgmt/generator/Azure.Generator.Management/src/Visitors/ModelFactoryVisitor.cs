// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal class ModelFactoryVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider modelFactory)
            {
                var updatedMethods = new List<MethodProvider>();
                foreach (var method in modelFactory.Methods)
                {
                    var returnType = method.Signature.ReturnType;
                    if (returnType is not null && ManagementClientGenerator.Instance.OutputLibrary.IsModelFactoryModelType(returnType))
                    {
                        // Fix ArgumentNullException XML documentation for parameters that are nullable
                        // Model factory methods should allow all parameters to be null for mocking purposes
                        FixArgumentNullExceptionXmlDoc(method);

                        // Update parameter names for specific properties
                        UpdateParameterNames(method);

                        updatedMethods.Add(method);
                    }
                }
                modelFactory.Update(methods: updatedMethods);
                return modelFactory;
            }
            return base.VisitType(type);
        }

        private void FixArgumentNullExceptionXmlDoc(MethodProvider method)
        {
            // Model factory methods are for mocking and should not have ArgumentNullException validation
            // The method implementation uses ternary operators to handle null values gracefully
            // Remove any ArgumentNullException documentation by clearing the exceptions list
            if (method.XmlDocs != null)
            {
                // Clear exceptions to remove ArgumentNullException documentation
                method.XmlDocs.Update(exceptions: Array.Empty<XmlDocExceptionStatement>());
            }
        }

        private void UpdateParameterNames(MethodProvider method)
        {
            if (PreservePreviousParameterNames(method))
            {
                // Update the method signature to refresh documentation after parameter renames.
                method.Update(signature: method.Signature);
            }
        }

        private static bool PreservePreviousParameterNames(MethodProvider method)
        {
            var previousMethods = method.EnclosingType.LastContractView?.Methods;
            if (previousMethods is null || previousMethods.Count == 0)
            {
                return false;
            }

            var previousMethod = previousMethods.FirstOrDefault(previous => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previous.Signature));
            if (previousMethod is null)
            {
                return false;
            }

            var currentParameters = method.Signature.Parameters;
            var previousParameters = previousMethod.Signature.Parameters;
            if (currentParameters.Count != previousParameters.Count)
            {
                return false;
            }

            var updated = false;
            for (int i = 0; i < currentParameters.Count; i++)
            {
                var previousName = previousParameters[i].Name;
                var currentParameter = currentParameters[i];
                if (string.IsNullOrEmpty(previousName) || currentParameter.Name == previousName)
                {
                    continue;
                }

                if (currentParameters.Where((parameter, index) => index != i).Any(parameter => string.Equals(parameter.Name, previousName, StringComparison.Ordinal)))
                {
                    continue;
                }

                currentParameter.Update(name: previousName);
                updated = true;
            }

            return updated;
        }
    }
}
