// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal class SafeFlattenVisitor : ScmLibraryVisitor
    {
        private Dictionary<ModelProvider, (HashSet<PropertyProvider> FlattenedProperties, HashSet<PropertyProvider> InternalizedProperties)> _flattenedModels = new();

        // TODO: we can't check property count of property types in VisitType since we don't have TypeProvider from CSharpType.
        // Once we have CSharpType to TypeProvider mapping, we can remove this and have this logic in VisitType instead
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is null)
            {
                return null;
            }

            var flattenedProperties = new HashSet<PropertyProvider>();
            var internalizedProperties = new HashSet<PropertyProvider>();
            foreach (var property in model.Properties)
            {
                var propertyType = property.Type;
                if (propertyType is InputModelType propertyModelType)
                {
                    // If the property type is a model with only one property, we can safely flatten it.
                    var propertyTypeProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(propertyModelType)!;
                    if (propertyTypeProvider.Properties.Count == 1)
                    {
                        var singleProperty = propertyTypeProvider.Properties.Single();

                        // make the current property internal
                        var internalSingleProperty = type!.Properties.Single(p => p.Type.AreNamesEqual(propertyTypeProvider.Type)); // type equal not working here, so we use AreNamesEqual
                        internalizedProperties.Add(internalSingleProperty);

                        // flatten the single property to public and associate it with the internal property
                        var flattenPropertyName = $"{singleProperty.Name}"; // TODO: handle name conflicts
                        var checkNullExpression = This.Property(internalSingleProperty.Name).Is(Null);
                        var flattenPropertyBody = new MethodPropertyBody(
                            Return(new TernaryConditionalExpression(checkNullExpression, Default, new MemberExpression(internalSingleProperty, singleProperty.Name))),
                            new List<MethodBodyStatement>
                            {
                                new IfStatement(checkNullExpression)
                                {
                                    internalSingleProperty.Assign(New.Instance(propertyTypeProvider.Type!)).Terminate()
                                },
                                This.Property(internalSingleProperty.Name).Property(singleProperty.Name).Assign(Value).Terminate()
                            });
                        var flattenedProperty = new PropertyProvider(singleProperty.Description, singleProperty.Modifiers, singleProperty.Type, flattenPropertyName, flattenPropertyBody, type, singleProperty.ExplicitInterface, singleProperty.WireInfo, singleProperty.Attributes);
                        flattenedProperties.Add(flattenedProperty);
                    }
                }
            }
            if (flattenedProperties.Count > 0)
            {
                _flattenedModels[type!] = (flattenedProperties, internalizedProperties);
            }
            return base.PreVisitModel(model, type);
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model && _flattenedModels.TryGetValue(model, out var value))
            {
                var (flattenedProperties, internalizedProperties) = value;
                type.Update(properties: [.. type.Properties, .. flattenedProperties]);
                foreach (var internalProperty in internalizedProperties)
                {
                    // make the internalized properties internal
                    internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
                }
            }

            return base.VisitType(type);
        }
    }
}
