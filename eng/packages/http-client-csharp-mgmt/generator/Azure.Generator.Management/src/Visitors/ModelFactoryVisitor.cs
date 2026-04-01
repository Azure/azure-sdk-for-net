// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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
                        // Skip factory methods where any parameter type is internal.
                        // This can happen when a properties type is made internal via custom code
                        // or by a previous visitor (e.g., FlattenPropertyVisitor), but the factory
                        // method was still generated with the now-internal type as a parameter.
                        if (HasInternalParameterType(method))
                        {
                            continue;
                        }

                        // Fix ArgumentNullException XML documentation for parameters that are nullable
                        // Model factory methods should allow all parameters to be null for mocking purposes
                        FixArgumentNullExceptionXmlDoc(method);

                        // Update parameter names for specific properties
                        UpdateParameterNames(method);

                        // Ensure all parameters have default values for mocking purposes
                        EnsureDefaultParameterValues(method);

                        updatedMethods.Add(method);
                    }
                }
                modelFactory.Update(methods: updatedMethods);
                return modelFactory;
            }
            return base.VisitType(type);
        }

        /// <summary>
        /// Checks whether any parameter of the given factory method has an internal (non-public) type.
        /// Public factory methods must not expose internal types as parameters.
        /// </summary>
        private static bool HasInternalParameterType(MethodProvider method)
        {
            foreach (var parameter in method.Signature.Parameters)
            {
                if (IsInternalType(parameter.Type))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a CSharpType resolves to an internal (non-public) TypeProvider.
        /// This checks the TypeProvider's DeclarationModifiers directly, which reflects custom code
        /// changes, rather than relying on CSharpType.IsPublic which may be stale.
        /// </summary>
        private static bool IsInternalType(CSharpType type)
        {
            // For framework types (System types), they are always public
            if (type.IsFrameworkType)
            {
                return false;
            }

            // Check if the type resolves to a TypeProvider and whether it's internal
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(type, out var typeProvider)
                && typeProvider is not null)
            {
                return !typeProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public);
            }

            // Fall back to CSharpType.IsPublic for types not in the map
            return !type.IsPublic;
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
                // Check if the parameter is associated with a property and needs renaming
                if (parameter.Property != null &&
                    PropertyToParameterNameMap.TryGetValue(parameter.Property.Name, out var newName) &&
                    parameter.Name != newName)
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

        /// <summary>
        /// Ensures all parameters in the factory method have default values.
        /// Model factory methods are used for mocking and all parameters should be optional
        /// with default values (typically 'default') so callers only need to specify the
        /// properties they care about.
        /// </summary>
        private static void EnsureDefaultParameterValues(MethodProvider method)
        {
            bool updated = false;
            foreach (var parameter in method.Signature.Parameters)
            {
                if (parameter.DefaultValue is null)
                {
                    parameter.DefaultValue = Default;
                    updated = true;
                }
            }

            if (updated)
            {
                method.Update(signature: method.Signature);
            }
        }
    }
}
