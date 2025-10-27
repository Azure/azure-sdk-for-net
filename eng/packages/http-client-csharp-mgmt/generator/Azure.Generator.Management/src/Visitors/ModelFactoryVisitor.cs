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
        // Dictionary mapping property names to their preferred parameter names
        private static readonly Dictionary<string, string> PropertyToParameterNameMap = new()
        {
            { "ETag", "etag" }
        };

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
            bool updated = false;

            // Check if any parameter needs to be renamed based on the property name mapping
            foreach (var parameter in method.Signature.Parameters)
            {
                // Check if the parameter is associated with a property
                if (parameter.Property != null &&
                    PropertyToParameterNameMap.TryGetValue(parameter.Property.Name, out var newName))
                {
                    parameter.Update(name: newName);
                    updated = true;
                }
            }

            if (updated)
            {
                // Update the method signature to refresh documentation
                method.Update(signature: method.Signature);
            }
        }
    }
}
