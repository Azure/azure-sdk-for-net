// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal class FlattenPropertyVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                FlattenProperties(model, type);
            }
            return base.PreVisitModel(model, type);
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            return base.VisitType(type);
        }

        private void FlattenProperties(InputModelType model, ModelProvider type)
        {
            if (ManagementClientGenerator.Instance.InputLibrary.FlattenPropertyMap.TryGetValue(model, out var propertiesToFlatten))
            {
                foreach (var property in propertiesToFlatten)
                {
                    var propertyProvider = ManagementClientGenerator.Instance.TypeFactory.CreateProperty(property, type)!;
                    if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(propertyProvider.Type, out var propertyTypeProvider) && propertyTypeProvider is ModelProvider propertyModelProvider)
                    {
                        var flattenedProperties = new List<PropertyProvider>();
                        foreach (var innerProperty in GetInnerProperties(propertyModelProvider))
                        {
                            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(propertyProvider, innerProperty);
                            var flattenPropertyName = PropertyHelpers.GetCombinedPropertyName(innerProperty, propertyProvider); // TODO: handle name conflicts
                            var flattenPropertyBody = new MethodPropertyBody(
                                PropertyHelpers.BuildGetter(includeGetterNullCheck, propertyProvider, type, innerProperty),
                                isFlattenedPropertyReadOnly ? null : PropertyHelpers.BuildSetter(includeSetterNullCheck, type, propertyProvider, innerProperty)
                            );

                            // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
                            var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
                            var flattenedProperty = new PropertyProvider(innerProperty.Description, innerProperty.Modifiers, isOverriddenValueType ? innerProperty.Type.WithNullable(true) : innerProperty.Type, flattenPropertyName, flattenPropertyBody, type, innerProperty.ExplicitInterface, innerProperty.WireInfo, innerProperty.Attributes);
                        }

                        // internalize property
                        propertyProvider.Update(modifiers: propertyProvider.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);

                        //// update constructors to initialize the flattened properties and remove the internal property
                        //UpdateConstructorParameters(propertyModelProvider, propertyProvider, flattenedProperties);
                    }
                }
            }
        }

        private static void UpdateConstructorParameters(ModelProvider propertyModelProvider, PropertyProvider propertyProvider, IReadOnlyList<PropertyProvider> flattenedProperties)
        {
            var updatedParameters = new List<ParameterProvider>();
            var flattenedParameters = flattenedProperties.Select(p => new ParameterProvider(p.Name.ToVariableName(), p.Description ?? $"", p.Type)).ToList();
            var updated = false;
            var parameterShouldBeNullable = false; // if the previous method parameter is nullable, we need to ensure that the current parameter is also set with default value

            foreach (var param in propertyModelProvider.FullConstructor.Signature.Parameters)
            {
                if (param.Type.Equals(propertyProvider.Type) && param.Name == propertyProvider.Name.ToVariableName())
                {
                    updated = true;
                    foreach (var flattenedProperty in flattenedProperties)
                    {
                        var updatedParameter = flattenedProperty.AsParameter;
                        if (parameterShouldBeNullable || flattenedProperty.Type.IsNullable)
                        {
                            parameterShouldBeNullable = true;
                            updatedParameter.DefaultValue = Default; // Ensure that the default value is set to null for nullable types
                        }
                        updatedParameters.Add(updatedParameter);
                    }
                }
                else
                {
                    updatedParameters.Add(param);
                }
            }
            if (updated)
            {
                propertyModelProvider.FullConstructor.Signature.Update(parameters: updatedParameters);
            }
        }

        private IReadOnlyList<PropertyProvider> GetInnerProperties(ModelProvider propertyModelProvider)
        {
            var result = new List<PropertyProvider>(propertyModelProvider.Properties);
            var baseType = propertyModelProvider.BaseModelProvider;

            // Recursively get properties from base types
            while (baseType is not null)
            {
                result.AddRange(baseType.Properties);
                baseType = baseType.BaseModelProvider;
            }
            return result;
        }
    }
}
