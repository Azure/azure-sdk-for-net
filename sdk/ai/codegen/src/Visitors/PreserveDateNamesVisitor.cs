// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Extensions.Plugin.Visitors
{
    internal sealed class PreserveDateNamesVisitor : ScmLibraryVisitor
    {
        // Rename before the generator builds constructor parameters and serialization from the property.
        protected override PropertyProvider PreVisitProperty(InputProperty property, PropertyProvider propertyProvider)
        {
            // This visitor was not in place before the Azure.AI.Projects.Agents release and
            // we cannot apply it to this package, because it will result in breaking changes.
            if (property.EnclosingType?.Namespace?.StartsWith("Azure.AI.Projects.Agents") == true)
            {
                return propertyProvider;
            }
            if (propertyProvider is null || property.IsExactName || !IsDateTimeType(property.Type))
            {
                return propertyProvider;
            }

            var generatedName = propertyProvider.Name;
            var name = GetNameWithAtSuffix(generatedName);
            var model = propertyProvider.EnclosingType;
            if (name is null || name == model.Name
                || property.EnclosingType?.Properties.Any(p => !ReferenceEquals(p, property)
                    && (p.IsExactName ? p.Name == name : string.Equals(p.Name.ToIdentifierName(), name, StringComparison.OrdinalIgnoreCase))) == true
                || model.LastContractView?.Properties.Any(p => p.Name == generatedName
                    && (p.Modifiers & (MethodSignatureModifiers.Public | MethodSignatureModifiers.Protected)) != 0) == true)
            {
                return propertyProvider;
            }

            propertyProvider.Update(name: name);
            return propertyProvider;
        }

        protected override ScmMethodProviderCollection Visit(
            InputServiceMethod serviceMethod, ClientProvider enclosingType, ScmMethodProviderCollection methods)
        {
            if (methods is null)
            {
                return methods;
            }

            var publishedMethods = enclosingType.LastContractView?.Methods;
            foreach (var method in methods)
            {
                // Custom partial methods use the names from the user's declaration.
                if (method.IsPartialMethod)
                {
                    continue;
                }

                var parameters = method.Signature.Parameters;
                foreach (var parameter in parameters)
                {
                    if (parameter.InputParameter is not { IsExactName: false } input || !IsDateTimeType(input.Type))
                    {
                        continue;
                    }

                    var generatedName = GetDeclarationName(parameter);
                    var name = GetNameWithAtSuffix(generatedName);
                    if (name is null
                        || parameters.Any(p => !ReferenceEquals(p, parameter) && GetDeclarationName(p) == name)
                        || publishedMethods?.Any(m => m.Signature.Name == method.Signature.Name
                            && (m.Signature.Modifiers & (MethodSignatureModifiers.Public | MethodSignatureModifiers.Protected)) != 0
                            && m.Signature.Parameters.Any(p => string.Equals(p.Name, generatedName, StringComparison.OrdinalIgnoreCase))) == true)
                    {
                        continue;
                    }

                    // The generated body, named arguments to this overload, and XML docs share the
                    // provider or its declaration. Leave the input and request-builder wire mapping alone.
                    parameter.Update(name: name);
                }
            }

            return methods;
        }

        private static string GetDeclarationName(ParameterProvider parameter)
            => ((VariableExpression)parameter).Declaration.RequestedName;

        private static string GetNameWithAtSuffix(string generatedName)
            => generatedName.EndsWith("On", StringComparison.Ordinal) ? generatedName[..^2] + "At" : null;

        private static bool IsDateTimeType(InputType type) => type switch
        {
            InputDateTimeType => true,
            InputPrimitiveType { Kind: InputPrimitiveTypeKind.PlainDate } => true,
            InputNullableType nullable => IsDateTimeType(nullable.Type),
            _ => false,
        };
    }
}
