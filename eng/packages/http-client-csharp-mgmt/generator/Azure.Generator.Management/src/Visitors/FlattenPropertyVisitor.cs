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

            if (type is ModelProvider model && _collectionTypeProperties.TryGetValue(model, out var value))
            {
                foreach (var (internalProperty, collectionProperties) in value)
                {
                    // If the property is a collection type, we need to ensure that it is initialized
                    foreach (var (flattenedProperty, innerProperty) in collectionProperties)
                        flattenedProperty.Update(body: new MethodPropertyBody(
                                PropertyHelpers.BuildGetter(true, internalProperty, ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[internalProperty.Type]!, innerProperty),
                                PropertyHelpers.BuildSetterForCollectionProperty(collectionProperties.Select(x => x.InnerProperty), internalProperty, innerProperty)));
                }
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
            var parameterMap = new Dictionary<ParameterProvider, ParameterProvider>();
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
                        var propertyParameter = flattenedProperty.AsParameter;
                        if (parameterShouldBeNullable || flattenedProperty.Type.IsNullable)
                        {
                            // The same parameter is used in public constructor, we need a new copy for model factory method with different nullability.
                            var updatedParameter = new ParameterProvider(propertyParameter.Name, propertyParameter.Description, propertyParameter.Type, propertyParameter.DefaultValue,
                                propertyParameter.IsRef, propertyParameter.IsOut, propertyParameter.IsParams, propertyParameter.Attributes, propertyParameter.Property,
                                propertyParameter.Field, propertyParameter.InitializationValue, propertyParameter.Location, propertyParameter.WireInfo, propertyParameter.Validation);

                            if (isOverriddenValueType)
                            {
                                updatedParameter.Update(type: updatedParameter.Type.WithNullable(true));
                            }
                            parameterShouldBeNullable = true;
                            updatedParameter.DefaultValue = Default; // Ensure that the default value is set to null for nullable types

                            parameterMap.Add(propertyParameter, updatedParameter);
                            updatedParameters.Add(updatedParameter);
                        }
                        else
                        {
                            updatedParameters.Add(propertyParameter);
                        }
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
                                        BuildConditionExpression(value, parameterMap),
                                        Default,
                                        New.Instance(variable.Type, BuildConstructorParameters(variable.Type, value, parameterMap))));
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

        private ValueExpression BuildConditionExpression(List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider> parameterMap)
        {
            ScopedApi<bool>? result = null;
            foreach (var (_, flattenProperty) in flattenedProperties)
            {
                var propertyParameter = flattenProperty.AsParameter;
                if (parameterMap.TryGetValue(propertyParameter, out var updatedParameter))
                {
                    if (result is null)
                    {
                        result = updatedParameter.Is(Null);
                    }
                    else
                    {
                        result = result.Or(updatedParameter.Is(Null));
                    }
                }
                else
                {
                    if (result is null)
                    {
                        result = propertyParameter.Is(Null);
                    }
                    else
                    {
                        result = result.Or(propertyParameter.Is(Null));
                    }
                }
            }
            return result!;
        }

        // Use the flattened property as the parameter, if it is an overridden value type, we need to use the Value property.
        private ValueExpression[] BuildConstructorParameters(CSharpType propertyType, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider> parameterMap)
        {
            var propertyModelType = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[propertyType] as ModelProvider;

            var parameters = new List<ValueExpression>();
            var additionalPropertyIndex = GetAdditionalPropertyIndex();
            for (var i = 0; i < flattenedProperties.Count; i++)
            {
                if (i == additionalPropertyIndex)
                {
                    // If the additionalProperties parameter exists, we need to pass null for it.
                    parameters.Add(Null);
                }
                var (isOverriddenValueType, flattenedProperty) = flattenedProperties[i];
                var propertyParameter = flattenedProperty.AsParameter;
                if (parameterMap.TryGetValue(propertyParameter, out var updatedParameter))
                {
                    parameters.Add(isOverriddenValueType ? updatedParameter.Property("Value") : updatedParameter);
                }
                else
                {
                    parameters.Add(isOverriddenValueType ? propertyParameter.Property("Value") : propertyParameter);
                }
            }
            return parameters.ToArray();

            int GetAdditionalPropertyIndex()
            {
                var additionalPropertyIndex = -1;
                var fullConstructorParmeters = propertyModelType!.FullConstructor.Signature.Parameters;
                for (var index = 0; index < fullConstructorParmeters.Count; index++)
                {
                    if (fullConstructorParmeters[index].Name.Equals("additionalBinaryDataProperties"))
                    {
                        additionalPropertyIndex = index;
                        break;
                    }
                }
                return additionalPropertyIndex;
            }
        }

        // This dictionary holds the flattened model types, where the key is the CSharpType of the model and the value is a dictionary of property names to flattened PropertyProvider.
        // So that, we can use this to update the model factory methods later.
        private readonly Dictionary<CSharpType, Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>>> _flattenedModelTypes = new();
        // TODO: Workadound to initialize all collection-type properties in all collection-type setters, remove this once we have lazy initializtion for collection-type properties
        private readonly Dictionary<ModelProvider, Dictionary<PropertyProvider, List<(PropertyProvider FlattenedProperty, PropertyProvider InnerProperty)>>> _collectionTypeProperties = new();
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
                            var (_, includeGetterNullCheck, _) = PropertyHelpers.GetFlags(property, innerProperty);
                            var flattenPropertyName = innerProperty.Name; // TODO: handle name conflicts
                            var flattenPropertyBody = new MethodPropertyBody(
                                PropertyHelpers.BuildGetter(includeGetterNullCheck, property, modelProvider, innerProperty),
                                !innerProperty.Body.HasSetter ? null : PropertyHelpers.BuildSetterForPropertyFlatten(modelProvider, property, innerProperty)
                            );

                            // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
                            var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
                            var flattenedProperty =
                                new PropertyProvider(
                                    innerProperty.Description,
                                    innerProperty.Modifiers,
                                    innerProperty.Type,
                                    flattenPropertyName,
                                    flattenPropertyBody,
                                    model,
                                    innerProperty.ExplicitInterface,
                                    innerProperty.WireInfo,
                                    innerProperty.Attributes);

                            flattenedProperties.Add((isOverriddenValueType, flattenedProperty));
                            AddInternalSetterForFlattenTypeCollectionProperty(property, innerProperty, flattenedProperty, model);
                        }
                        // make the internalized properties internal
                        property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
                        map.Add(property.Name.ToVariableName(), flattenedProperties);
                    }
                }
            }
            if (isFlattened)
            {
                var flattenedProperties = map.Values.SelectMany(x => x.Select(item => item.FlattenedProperty));
                model.Update(properties: [.. model.Properties, .. flattenedProperties]);
                UpdatePublicConstructor(model, map);
                _flattenedModelTypes[model.Type] = map;
            }
        }

        // TODO: workaround to add internal setter, we should remove this once we add lazy initialization for collection type properties
        private void AddInternalSetterForFlattenTypeCollectionProperty(PropertyProvider internalProperty, PropertyProvider innerProperty, PropertyProvider flattenedProperty, ModelProvider modelProvider)
        {
            if (innerProperty.Type.IsCollection)
            {
                if (_collectionTypeProperties.TryGetValue(modelProvider, out var value))
                {
                    if (value.TryGetValue(internalProperty, out var properties))
                    {
                        properties.Add((flattenedProperty, innerProperty));
                    }
                    else
                    {
                        value.Add(internalProperty, [(flattenedProperty, innerProperty)]);
                    }
                }
                else
                {
                    var dict = new Dictionary<PropertyProvider, List<(PropertyProvider FlattenedProperty, PropertyProvider InnerProperty)>>();
                    dict.Add(internalProperty, [(flattenedProperty, innerProperty)]);
                    _collectionTypeProperties.Add(modelProvider, dict);
                }
                innerProperty.Update(body: new AutoPropertyBody(true, MethodSignatureModifiers.Internal));
            }
        }

        private static void UpdatePublicConstructor(ModelProvider model, Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>> map)
        {
            var publicConstructor = model.Constructors.SingleOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            if (publicConstructor is null)
            {
                return;
            }

            var updated = false;
            var updateParameters = new List<ParameterProvider>();
            foreach (var parameter in publicConstructor.Signature.Parameters)
            {
                if (map.TryGetValue(parameter.Name, out var value))
                {
                    updated = true;
                    foreach (var (_, flattenedProperty) in value)
                    {
                        var flattenedParameter = flattenedProperty.AsParameter;
                        if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenedProperty))
                        {
                            updateParameters.Add(flattenedParameter);
                        }
                    }
                }
                else
                {
                    updateParameters.Add(parameter);
                }
            }

            UpdatePublicConstructorBody(model, map, publicConstructor);

            if (updated)
            {
                publicConstructor.Signature.Update(parameters: updateParameters);
                publicConstructor.Update(signature: publicConstructor.Signature); // workaround to update the xml docs
            }
        }

        private static bool ShouldIncludeFlattenedPropertyInPublicConstructor(PropertyProvider flattenedProperty)
            => (flattenedProperty.WireInfo?.IsRequired == true) && !flattenedProperty.Type.IsCollection;

        private static void UpdatePublicConstructorBody(ModelProvider model, Dictionary<string, List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>> map, ConstructorProvider publicConstructor)
        {
            var body = publicConstructor.BodyStatements;
            if (body is not null)
            {
                var updatedBodyStatements = new List<MethodBodyStatement>();
                foreach (var statement in body)
                {
                    // If the statement is validating a parameter, we need to update it to validate the flattened properties.
                    if (statement is ExpressionStatement expressionStatement && expressionStatement.Expression is InvokeMethodExpression invokeExpression)
                    {
                        var methodName = invokeExpression.MethodName;
                        if (invokeExpression.InstanceReference is TypeReferenceExpression typeReference && typeReference.Type?.Name == "Argument") // get the validation expression
                        {
                            var parameterName = invokeExpression.Arguments[0].ToDisplayString(); // we can ensure the first argument is always the parameter for validation expression
                            if (map.TryGetValue(parameterName, out var value))
                            {
                                foreach (var (_, flattenProperty) in value)
                                {
                                    if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenProperty))
                                    {
                                        updatedBodyStatements.Add(ArgumentSnippets.ValidateParameter(flattenProperty.AsParameter));
                                    }
                                }
                            }
                        }
                        else
                        {
                            updatedBodyStatements.Add(statement);
                        }
                    }
                    // If the statement is assigning a parameter, we need to update it to validate the flattened properties.
                    else if (statement is ExpressionStatement expression && expression.Expression is AssignmentExpression assignment && assignment.Value is VariableExpression variable)
                    {
                        if (map.TryGetValue(variable.Declaration.RequestedName, out var value))
                        {
                            foreach (var (_, flattenProperty) in value)
                            {
                                if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenProperty))
                                {
                                    // Assign the flattened property to the internalized property
                                    updatedBodyStatements.Add(((MemberExpression)flattenProperty).Assign(flattenProperty.AsParameter).Terminate());
                                }
                            }
                        }
                        else
                        {
                            updatedBodyStatements.Add(statement);
                        }
                    }
                    else
                    {
                        updatedBodyStatements.Add(statement);
                    }
                }
                publicConstructor.Update(signature: publicConstructor.Signature, bodyStatements: updatedBodyStatements);
            }
        }
    }
}
