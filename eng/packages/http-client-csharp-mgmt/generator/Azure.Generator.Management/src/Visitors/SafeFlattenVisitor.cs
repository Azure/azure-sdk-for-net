// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal class SafeFlattenVisitor : ScmLibraryVisitor
    {
        private readonly Dictionary<ModelProvider, (HashSet<PropertyProvider> FlattenedProperties, HashSet<PropertyProvider> InternalizedProperties)> _flattenedModels = new();
        private readonly Dictionary<CSharpType, Dictionary<CSharpType, PropertyProvider>> _flattenedModelTypes = new();

        // TODO: we can't check property count of property types in VisitType since we don't have TypeProvider from CSharpType.
        // Once we have CSharpType to TypeProvider mapping, we can remove this and have this logic in VisitType instead
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is null)
            {
                return null;
            }

            var flattenedPropertyMap = new Dictionary<CSharpType, PropertyProvider>();
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
                        flattenedPropertyMap.Add(internalSingleProperty.Type, flattenedProperty);
                    }
                }
            }
            if (flattenedProperties.Count > 0)
            {
                _flattenedModels[type!] = (flattenedProperties, internalizedProperties);
                _flattenedModelTypes.Add(type.Type, flattenedPropertyMap);
            }
            return base.PreVisitModel(model, type);
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                UpdateModel(type, model);
            }

            if (type is ModelFactoryProvider modelFactory)
            {
                // If this is a model factory, we need to ensure that the flattened properties are also included in the factory methods.
                UpdateModelFactory(modelFactory);
            }

            return base.VisitType(type);
        }

        private void UpdateModelFactory(ModelFactoryProvider modelFactory)
        {
            foreach (var method in modelFactory.Methods)
            {
                var returnType = method.Signature.ReturnType;
                if (returnType is not null && _flattenedModelTypes.TryGetValue(returnType, out var value))
                {
                    UpdateModelFactoryMethod(method, returnType, value);
                }
            }
        }

        private void UpdateModelFactoryMethod(MethodProvider method, CSharpType returnType, Dictionary<CSharpType, PropertyProvider> propertyMap)
        {
            var updatedParameters = new List<ParameterProvider>(method.Signature.Parameters.Count);
            var updated = false;
            foreach (var parameter in method.Signature.Parameters)
            {
                if (propertyMap.TryGetValue(parameter.Type, out var flattenedProperty))
                {
                    updated = true;
                    var updatedParameter = flattenedProperty.AsParameter;
                    if (flattenedProperty.Type.IsNullable)
                    {
                        updatedParameter.DefaultValue = Default; // Ensure that the default value is set to null for nullable types
                    }
                    updatedParameters.Add(updatedParameter);
                }
                else
                {
                    updatedParameters.Add(parameter);
                }
            }
            if (updated)
            {
                method.Signature.Update(parameters: updatedParameters);

                // The model factory method return a new instance of the model type, update the constructor arguments with the flattened properties of internalized properties.
                if (method.BodyStatements is not null)
                {
                    var updatedBodyStatements = new List<MethodBodyStatement>();
                    foreach (var statement in method.BodyStatements)
                    {
                        // If the statement is returning a NewInstanceExpression, we need to update its parameters with the flattened properties.
                        if (statement is ExpressionStatement expressionStatement && (expressionStatement.Expression as KeywordExpression)?.Expression is NewInstanceExpression newInstanceExpression)
                        {
                            var updatedInstanceParameters = new List<ValueExpression>(newInstanceExpression.Parameters.Count);
                            foreach (var parameter in newInstanceExpression.Parameters)
                            {
                                if (parameter is VariableExpression variable && propertyMap.TryGetValue(variable.Type, out var flattenedProperty))
                                {
                                    updatedInstanceParameters.Add(
                                        new TernaryConditionalExpression(
                                            flattenedProperty.AsParameter.Is(Null),
                                            Default,
                                            New.Instance(
                                                variable.Type,
                                                [flattenedProperty.AsParameter, New.Instance(new CSharpType(typeof(Dictionary<,>), typeof(string), typeof(BinaryData)))]))); // TODO: handle additional parameters properly or should it be nullable?
                                }
                                else
                                {
                                    updatedInstanceParamters.Add(parameter);
                                }
                            }
                            updatedBodyStatements.Add(Return(New.Instance(newInstanceExpression.Type!, updatedInstanceParamters)));
                        }
                        else
                        {
                            updatedBodyStatements.Add(statement);
                        }
                    }
                    method.Update(signature: method.Signature, bodyStatements: updatedBodyStatements);
                }
            }
        }

        private void UpdateModel(TypeProvider type, ModelProvider model)
        {
            if (_flattenedModels.TryGetValue(model, out var value))
            {
                var (flattenedProperties, internalizedProperties) = value;
                type.Update(properties: [.. type.Properties, .. flattenedProperties]);
                foreach (var internalProperty in internalizedProperties)
                {
                    // make the internalized properties internal
                    internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
                }
            }
        }
    }
}
