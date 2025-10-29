// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
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
    }
}
