// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal class FlattenPropertyVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                FlattenProperties(model);
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

        private void UpdateModelFactoryMethod(MethodProvider method, CSharpType returnType, Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>> propertyMap)
        {
            var updatedParameters = new List<ParameterProvider>(method.Signature.Parameters.Count);
            var updated = false;
            var parameterShouldBeNullable = false; // if the previous method parameter is nullable, we need to ensure that the current parameter is also set with default value
            foreach (var parameter in method.Signature.Parameters)
            {
                if (propertyMap.TryGetValue(parameter.Name, out var value))
                {
                    updated = true;
                    foreach (var (isOverriddenValueType, flattenedProperty) in value)
                    {
                        // If the flattened property is a value type, we need to ensure that we handle the nullability correctly.
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
                                    updatedInstanceParameters.Add(
                                    new TernaryConditionalExpression(
                                        BuildConditionExpression(value),
                                        Default,
                                        New.Instance(variable.Type, BuildConstructorParameters(value))));
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

        private ValueExpression BuildConditionExpression(List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)> flattenedProperties)
        {
            ScopedApi<bool>? result = null;
            foreach (var (_, flattenProperty) in flattenedProperties)
            {
                if (result is null)
                {
                    result = flattenProperty.AsParameter.Is(Null);
                }
                else
                {
                    result = result.Or(flattenProperty.AsParameter.Is(Null));
                }
            }
            return result!;
        }

        // Use the flattened property as the parameter, if it is an overridden value type, we need to use the Value property.
        private ValueExpression[] BuildConstructorParameters(List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)> flattenedProperties)
        {
            var parameters = new List<ValueExpression>();
            foreach (var (isOverriddenValueType, flattenedProperty) in flattenedProperties)
            {
                parameters.Add(isOverriddenValueType ? flattenedProperty.AsParameter.Property("Value") : flattenedProperty.AsParameter);
            }
            return parameters.ToArray();
        }

        // This dictionary holds the flattened model types, where the key is the CSharpType of the model and the value is a dictionary of property names to flattened PropertyProvider.
        // So that, we can use this to update the model factory methods later.
        private readonly Dictionary<CSharpType, Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>>> _flattenedModelTypes = new();
        private void FlattenProperties(ModelProvider model)
        {
            var isFlattened = false;
            var map = new Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>>();

            if (ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var propertiesToFlatten))
            {
                foreach (var property in propertiesToFlatten)
                {
                    var flattenedProperties = new List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>();
                    if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(property.Type, out var typeProvider)
                        && typeProvider is ModelProvider modelProvider)
                    {
                        var innerProperties = PropertyHelpers.GetAllProperties(modelProvider);
                        // skip safe flatten single property, otherwise we will flatten twice
                        if (innerProperties.Count == 1)
                        {
                            continue;
                        }

                        isFlattened = true;
                        foreach (var innerProperty in innerProperties)
                        {
                            // flatten the property to public and associate it with the internal property
                            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(property, innerProperty);
                            var flattenPropertyName = PropertyHelpers.GetCombinedPropertyName(innerProperty, property); // TODO: handle name conflicts
                            var flattenPropertyBody = new MethodPropertyBody(
                                PropertyHelpers.BuildGetter(includeGetterNullCheck, property, modelProvider, innerProperty),
                                isFlattenedPropertyReadOnly ? null : PropertyHelpers.BuildSetterForPropertyFlatten(includeSetterNullCheck, modelProvider, property, innerProperty)
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
                            flattenedProperties.Add((isOverriddenValueType, flattenedProperty));
                        }
                        map.Add(property.Name.ToVariableName(), flattenedProperties);
                    }
                }
            }
            if (isFlattened)
            {
                model.Update(properties: [.. model.Properties, .. map.Values.SelectMany(x => x.Select(item => item.FlattenedProperty))]);
                _flattenedModelTypes[model.Type] = map;
            }
        }
    }
}
