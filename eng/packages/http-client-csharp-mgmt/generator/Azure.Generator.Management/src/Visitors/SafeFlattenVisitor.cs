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
        private HashSet<PropertyProvider> _flattenedProperties = new HashSet<PropertyProvider>();

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            var flattenedProperties = new List<PropertyProvider>();
            foreach (var property in model.Properties)
            {
                var propertyType = property.Type;
                if (propertyType is InputModelType propertyModelType)
                {
                    var propertyTypeProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(propertyModelType)!;
                    if (IsFlattenModel(propertyTypeProvider))
                    {
                        // If the property is a flattened model with only one public property, we can safely flatten it.
                        var singleProperty = propertyTypeProvider.Properties.Where(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public)).Single();

                        // make the current property internal
                        var internalSingleProperty = type!.Properties.Single(p => p.Type == propertyTypeProvider.Type);
                        internalSingleProperty.Update(modifiers: internalSingleProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);

                        // flatten the single property to public and associate it with the internal property
                        var flattenPropertyName = $"{internalSingleProperty.Type.Name}{singleProperty.Name}"; // TODO: handle name conflicts
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
                        _flattenedProperties.Add(flattenedProperty);
                    }
                }
            }
            if (flattenedProperties.Count > 0)
            {
                // Update the model with the flattened properties
                type?.Update(properties: [.. type.Properties, .. flattenedProperties]);
            }
            return base.PreVisitModel(model, type);
        }

        private bool IsFlattenModel(ModelProvider? propertyTypeProvider)
        {
            // If the model has a single property, we can safely flatten it
            if (propertyTypeProvider?.Properties.Count == 1)
            {
                return true;
            }

            // If the model has two properties, one internal property and one public flattened property, we can safely flatten it
            if (propertyTypeProvider?.Properties.Count == 2)
            {
                var internalProperty = propertyTypeProvider.Properties.SingleOrDefault(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Internal));
                var publicProperty = propertyTypeProvider.Properties.SingleOrDefault(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public));
                if (internalProperty is not null && publicProperty is not null && _flattenedProperties.Contains(publicProperty))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
