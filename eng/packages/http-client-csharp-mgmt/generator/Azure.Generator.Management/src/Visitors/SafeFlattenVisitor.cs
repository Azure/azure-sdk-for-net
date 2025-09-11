// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
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
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                FlattenModel(model);
            }

            return base.VisitType(type);
        }

        protected override TypeProvider? PostVisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider modelFactory)
            {
                // If this is a model factory, we need to ensure that the flattened properties are also included in the factory methods.
                UpdateModelFactory(modelFactory);
            }

            return base.PostVisitType(type);
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

        private void UpdateModelFactoryMethod(MethodProvider method, CSharpType returnType, Dictionary<string, (bool IsOverriddenValueType, PropertyProvider FlattenedProperty)> propertyMap)
        {
            var updatedParameters = new List<ParameterProvider>(method.Signature.Parameters.Count);
            var updated = false;
            var parameterShouldBeNullable = false; // if the previous method parameter is nullable, we need to ensure that the current parameter is also set with default value
            foreach (var parameter in method.Signature.Parameters)
            {
                if (propertyMap.TryGetValue(parameter.Name, out var value))
                {
                    var (_, flattenedProperty) = value;
                    updated = true;
                    var updatedParameter = flattenedProperty.AsParameter;
                    if (parameterShouldBeNullable || flattenedProperty.Type.IsNullable)
                    {
                        parameterShouldBeNullable = true;
                        updatedParameter.DefaultValue = Default; // Ensure that the default value is set to null for nullable types
                    }
                    updatedParameters.Add(updatedParameter);
                }
                else
                {
                    if (parameter.Type.IsNullable)
                    {
                        parameterShouldBeNullable = true;
                    }
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
                            // We need to update the parameters of the new instance expression with the flattened properties, the key is property name.
                            var updatedInstanceParameters = new List<ValueExpression>(newInstanceExpression.Parameters.Count);
                            foreach (var parameter in newInstanceExpression.Parameters)
                            {
                                if (parameter is VariableExpression variable && propertyMap.TryGetValue(variable.Declaration.RequestedName, out var value))
                                {
                                    // Flatten the property to the new instance parameters
                                    // If the property is null, we need to ensure that we create a new instance of the model type.
                                    // If the property is not null, we can use the existing value.
                                    var (isOverriddenValueType, flattenedProperty) = value;
                                    updatedInstanceParameters.Add(
                                    new TernaryConditionalExpression(
                                        flattenedProperty.AsParameter.Is(Null),
                                        Default,
                                        New.Instance(
                                            variable.Type,
                                            // Use the flattened property as the parameter, if it is an overridden value type, we need to use the Value property.
                                            [isOverriddenValueType ? flattenedProperty.AsParameter.Property("Value") : flattenedProperty.AsParameter, New.Instance(new CSharpType(typeof(Dictionary<,>), typeof(string), typeof(BinaryData)))]))); // TODO: handle additional parameters properly or should it be nullable?
                                }
                                else
                                {
                                    updatedInstanceParameters.Add(parameter);
                                }
                            }
                            updatedBodyStatements.Add(Return(New.Instance(newInstanceExpression.Type!, updatedInstanceParameters)));
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

        // This dictionary holds the flattened model types, where the key is the CSharpType of the model and the value is a dictionary of property names to flattened PropertyProvider.
        // So that, we can use this to update the model factory methods later.
        private readonly Dictionary<CSharpType, Dictionary<string, (bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>> _flattenedModelTypes = new();
        private void FlattenModel(ModelProvider model)
        {
            var isFlattened = false;
            var map = new Dictionary<string, (bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>();
            var flattenedProperties = new List<PropertyProvider>();
            foreach (var property in model.Properties)
            {
                if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(property.Type, out var typeProvider)
                    && typeProvider is ModelProvider modelProvider)
                {
                    var innerProperties = PropertyHelpers.GetAllProperties(modelProvider);
                    // only safe flatten single property
                    if (innerProperties.Count != 1)
                    {
                        continue;
                    }

                    // skip discriminator property
                    if (property.IsDiscriminator)
                    {
                        ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-warning", "Discriminator property should not be flattened.");
                        continue;
                    }

                    var innerProperty = modelProvider.Properties.Single();
                    isFlattened = true;

                    // flatten the single property to public and associate it with the internal property
                    var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(property, innerProperty);
                    var flattenPropertyName = PropertyHelpers.GetCombinedPropertyName(innerProperty, property); // TODO: handle name conflicts
                    var flattenPropertyBody = new MethodPropertyBody(
                        PropertyHelpers.BuildGetter(includeGetterNullCheck, property, modelProvider, innerProperty),
                        isFlattenedPropertyReadOnly ? null : PropertyHelpers.BuildSetterForSafeFlatten(includeSetterNullCheck, modelProvider, property, innerProperty)
                    );

                    // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
                    var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
                    var flattenedProperty =
                        new PropertyProvider(
                            innerProperty.Description,
                            innerProperty.Modifiers,
                            isOverriddenValueType ? innerProperty.Type.WithNullable(true) : innerProperty.Type,
                            flattenPropertyName,
                            flattenPropertyBody,
                            model,
                            innerProperty.ExplicitInterface,
                            null,
                            innerProperty.Attributes);

                    // make the internalized properties internal
                    property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
                    flattenedProperties.Add(flattenedProperty);
                    map.Add(property.Name.ToVariableName(), (isOverriddenValueType, flattenedProperty));
                }
            }
            model.Update(properties: [.. model.Properties, .. flattenedProperties]);
            if (isFlattened)
            {
                _flattenedModelTypes[model.Type] = map;
            }
        }
    }
}
