// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

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
                var flattenedProperties = new List<PropertyProvider>();
                foreach (var property in propertiesToFlatten)
                {
                    var propertyProvider = ManagementClientGenerator.Instance.TypeFactory.CreateProperty(property, type)!;
                    if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(propertyProvider.Type, out var propertyTypeProvider) && propertyTypeProvider is ModelProvider propertyModelProvider)
                    {
                        var innerProperties = GetInnerProperties(propertyModelProvider);
                        // let safe flatten handle single property flattening
                        if (innerProperties.Count == 1)
                            continue;

                        foreach (var innerProperty in innerProperties)
                        {
                            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(propertyProvider, innerProperty);
                            var flattenPropertyName = innerProperty.Name; // TODO: handle name conflicts
                            var flattenPropertyBody = new MethodPropertyBody(
                                PropertyHelpers.BuildGetter(includeGetterNullCheck, propertyProvider, type, innerProperty),
                                isFlattenedPropertyReadOnly ? null : PropertyHelpers.BuildSetterForPropertyFlatten(includeSetterNullCheck, propertyModelProvider, propertyProvider, innerProperty)
                            );

                            // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
                            var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
                            var flattenedProperty = new PropertyProvider(innerProperty.Description, innerProperty.Modifiers, isOverriddenValueType ? innerProperty.Type.WithNullable(true) : innerProperty.Type, flattenPropertyName, flattenPropertyBody, type, innerProperty.ExplicitInterface, innerProperty.WireInfo, innerProperty.Attributes);
                            flattenedProperties.Add(flattenedProperty);
                        }

                        // internalize property
                        propertyProvider.Update(modifiers: propertyProvider.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
                    }
                }
                type.Update(properties: type.Properties.Concat(flattenedProperties));
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
