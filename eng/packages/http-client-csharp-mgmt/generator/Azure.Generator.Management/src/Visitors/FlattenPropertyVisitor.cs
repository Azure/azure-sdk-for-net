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
using System;
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
                // If this model type has already been flattened, we don't need to flatten it again.
                if (!_flattenedModelTypes.ContainsKey(model.Type))
                {
                    FlattenModel(model);
                }
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
                    var (propertyNameMap, _) = value;
                    UpdateModelFactoryMethod(method, returnType, propertyNameMap);
                }
            }
        }

        private void UpdateModelFactoryMethod(MethodProvider method, CSharpType returnType, Dictionary<string, List<FlattenPropertyInfo>> propertyNameMap)
        {
            var parameterMap = new Dictionary<ParameterProvider, ParameterProvider>();
            var updatedParameters = new List<ParameterProvider>(method.Signature.Parameters.Count);
            var updated = false;
            foreach (var parameter in method.Signature.Parameters)
            {
                if (propertyNameMap.TryGetValue(parameter.Name, out var value))
                {
                    updated = true;
                    foreach (var (isOverriddenValueType, flattenedProperty) in value)
                    {
                        // If the flattened property is a value type, we need to ensure that we handle the nullability correctly.
                        var propertyParameter = flattenedProperty.AsParameter;

                        // The same parameter is used in public constructor, we need a new copy for model factory method with different nullability.
                        var updatedParameter = new ParameterProvider(propertyParameter.Name, propertyParameter.Description, propertyParameter.Type, propertyParameter.DefaultValue,
                            propertyParameter.IsRef, propertyParameter.IsOut, propertyParameter.IsIn, propertyParameter.IsParams, propertyParameter.Attributes, propertyParameter.Property,
                            propertyParameter.Field, propertyParameter.InitializationValue, propertyParameter.Location, propertyParameter.WireInfo, propertyParameter.Validation);

                        if (isOverriddenValueType)
                        {
                            updatedParameter.Update(type: updatedParameter.Type.WithNullable(true));
                        }
                        updatedParameter.DefaultValue = Default; // Ensure that the default value is set to null for nullable types

                        parameterMap.Add(propertyParameter, updatedParameter);
                        updatedParameters.Add(updatedParameter);
                    }
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
                            // We need to update the parameters of the new instance expression with the flattened properties, the key is property name.
                            var updatedInstanceParameters = new List<ValueExpression>(newInstanceExpression.Parameters.Count);
                            foreach (var parameter in newInstanceExpression.Parameters)
                            {
                                if (parameter is VariableExpression variable && propertyNameMap.TryGetValue(variable.Declaration.RequestedName, out var value))
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

        private ValueExpression BuildConditionExpression(List<FlattenPropertyInfo> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider> parameterMap)
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
        private ValueExpression[] BuildConstructorParameters(CSharpType propertyType, List<FlattenPropertyInfo> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider> parameterMap)
        {
            var propertyModelType = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[propertyType] as ModelProvider;
            var fullConstructorParameters = propertyModelType!.FullConstructor.Signature.Parameters;

            var parameters = new List<ValueExpression>();
            var additionalPropertyIndex = GetAdditionalPropertyIndex();
            for (int i = 0, fullConstructorParameterIndex = 0; i < flattenedProperties.Count; i++, fullConstructorParameterIndex++)
            {
                if (i == additionalPropertyIndex)
                {
                    // If the additionalProperties parameter exists, we need to pass a new instance for it.
                    parameters.Add(New.Instance(new CSharpType(typeof(Dictionary<string, BinaryData>))));

                    // If the additionalProperties parameter is the last parameter, we can break the loop.
                    if (additionalPropertyIndex == fullConstructorParameters.Count - 1)
                    {
                        break;
                    }
                    fullConstructorParameterIndex++;
                }
                var (isOverriddenValueType, flattenedProperty) = flattenedProperties[i];
                var propertyParameter = flattenedProperty.AsParameter;
                var flattenedPropertyType = flattenedProperty.Type;
                var constructorParameterType = fullConstructorParameters[fullConstructorParameterIndex].Type;
                // If the internal property type is the same as the property type, we can use the flattened property directly.
                if (constructorParameterType.AreNamesEqual(flattenedPropertyType))
                {
                    if (parameterMap.TryGetValue(propertyParameter, out var updatedParameter))
                    {
                        parameters.Add(isOverriddenValueType ? updatedParameter.Property("Value") : updatedParameter);
                    }
                    else
                    {
                        parameters.Add(isOverriddenValueType ? propertyParameter.Property("Value") : propertyParameter);
                    }
                }
                else
                {
                    if (_flattenedModelTypes.TryGetValue(propertyType, out var result))
                    {
                        var (_, propertyTypeMap) = result;
                        if (propertyTypeMap.TryGetValue(constructorParameterType, out var list))
                        {
                            var innerParameters = BuildConstructorParameters(constructorParameterType, list, parameterMap);
                            parameters.Add(New.Instance(constructorParameterType, innerParameters));
                        }
                    }
                }
            }

            // If the additionalProperties parameter exists at the end, we need to pass a new instance for it.
            if (additionalPropertyIndex == propertyModelType!.FullConstructor.Signature.Parameters.Count - 1)
            {
                parameters.Add(New.Instance(new CSharpType(typeof(Dictionary<string, BinaryData>))));
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
        private readonly Dictionary<CSharpType, (Dictionary<string, List<FlattenPropertyInfo>>, Dictionary<CSharpType, List<FlattenPropertyInfo>>)> _flattenedModelTypes = new(new CSharpTypeNameComparer());
        private readonly HashSet<CSharpType> _visitedModelTypes = new();
        private void FlattenModel(ModelProvider model)
        {
            if (_visitedModelTypes.Contains(model.Type))
            {
                // already visiting this model type, we have a cycle, return
                return;
            }
            _visitedModelTypes.Add(model.Type);

            var isFlattenProperty = false;
            var isSafeFlatten = false;
            var propertyMap = new Dictionary<PropertyProvider, List<FlattenPropertyInfo>>();
            foreach (var internalProperty in model.Properties)
            {
                // we need to flatten the inner property type first
                var propertyType = internalProperty.Type;
                if (!propertyType.IsFrameworkType && ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[propertyType] is ModelProvider propertyModel
                    && !_flattenedModelTypes.ContainsKey(propertyType) && propertyType != model.Type)
                {
                    FlattenModel(propertyModel);
                }

                // handle `@flattenProperty`
                if (ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var propertiesToFlatten) && propertiesToFlatten.Contains(internalProperty))
                {
                    isFlattenProperty = PropertyFlatten(model, propertyMap, internalProperty);
                    continue;
                }
                // safe flatten single property
                else if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(internalProperty.Type, out var typeProvider) && typeProvider is ModelProvider modelProvider)
                {
                    var innerProperties = PropertyHelpers.GetAllProperties(modelProvider);
                    // only safe flatten single property
                    if (innerProperties.Count != 1)
                    {
                        continue;
                    }

                    // skip discriminator property
                    if (internalProperty.IsDiscriminator)
                    {
                        ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-warning", "Discriminator property should not be flattened.");
                        continue;
                    }

                    isSafeFlatten = SafeFlatten(model, propertyMap, internalProperty, modelProvider);
                }
            }

            var propertyNameMap = propertyMap.ToDictionary(kvp => kvp.Key.Name.ToVariableName(), kvp => kvp.Value);
            var propertyTypeMap = propertyMap.GroupBy(kvp => kvp.Key.Type).ToDictionary(kvp => kvp.Key, kvp => kvp.SelectMany(x => x.Value).ToList());

            if (isSafeFlatten || isFlattenProperty)
            {
                var flattenedProperties = propertyMap.Values.SelectMany(x => x.Select(item => item.FlattenedProperty));
                model.Update(properties: [.. model.Properties, .. flattenedProperties]);
                _flattenedModelTypes.Add(model.Type, (propertyNameMap, propertyTypeMap));
            }

            if (isFlattenProperty)
            {
                UpdatePublicConstructor(model, propertyNameMap);
            }
        }

        private bool PropertyFlatten(ModelProvider model, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty)
        {
            var isFlattened = false;
            var flattenedProperties = new List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>();
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(internalProperty.Type, out var typeProvider)
                && typeProvider is ModelProvider modelProvider)
            {
                isFlattened = true;

                foreach (var innerProperty in PropertyHelpers.GetAllProperties(modelProvider))
                {
                    if (!innerProperty.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        continue;
                    }
                    UpdateFlattenTypeCollectionProperty(internalProperty, innerProperty, model);
                    // flatten the property to public and associate it with the internal property
                    var (_, includeGetterNullCheck, _) = PropertyHelpers.GetFlags(internalProperty, innerProperty);
                    var flattenPropertyName = innerProperty.Name; // TODO: handle name conflicts
                    var flattenPropertyBody = new MethodPropertyBody(
                        PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, modelProvider, innerProperty),
                        !innerProperty.Body.HasSetter ? null : PropertyHelpers.BuildSetterForPropertyFlatten(modelProvider, internalProperty, innerProperty)
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
                            innerProperty.IsRef,
                            innerProperty.Attributes);

                    if (propertyMap.TryGetValue(internalProperty, out var value))
                    {
                        value.Add(new(isOverriddenValueType, flattenedProperty));
                    }
                    else
                    {
                        propertyMap.Add(internalProperty, new List<FlattenPropertyInfo> { new(isOverriddenValueType, flattenedProperty) });
                    }
                }
                // make the internalized properties internal
                internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
            }

            return isFlattened;
        }

        private bool SafeFlatten(ModelProvider model, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty, ModelProvider modelProvider)
        {
            bool isFlattened;
            var innerProperty = modelProvider.Properties.Single();
            isFlattened = true;

            // flatten the single property to public and associate it with the internal property
            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(internalProperty, innerProperty);
            var flattenPropertyName = PropertyHelpers.GetCombinedPropertyName(innerProperty, internalProperty); // TODO: handle name conflicts
            var flattenPropertyBody = new MethodPropertyBody(
                PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, modelProvider, innerProperty),
                isFlattenedPropertyReadOnly ? null : PropertyHelpers.BuildSetterForSafeFlatten(includeSetterNullCheck, modelProvider, internalProperty, innerProperty)
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
                    innerProperty.IsRef,
                    innerProperty.Attributes);

            // make the internalized properties internal
            internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
            if (propertyMap.TryGetValue(internalProperty, out var value))
            {
                value.Add(new(isOverriddenValueType, flattenedProperty));
            }
            else
            {
                propertyMap.Add(internalProperty, new List<FlattenPropertyInfo> { new(isOverriddenValueType, flattenedProperty) });
            }
            return isFlattened;
        }

        private void UpdateFlattenTypeCollectionProperty(PropertyProvider internalProperty, PropertyProvider innerProperty, ModelProvider modelProvider)
        {
            if (innerProperty.Type.IsCollection)
            {
                // add initialization for collection type property
                if (innerProperty.Type.IsList)
                {
                    innerProperty.Update(body: new AutoPropertyBody(false, InitializationExpression: New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(innerProperty.Type.Arguments))));
                }
                else if (innerProperty.Type.IsDictionary)
                {
                    innerProperty.Update(body: new AutoPropertyBody(false, InitializationExpression: New.Instance(ManagementClientGenerator.Instance.TypeFactory.DictionaryInitializationType.MakeGenericType(innerProperty.Type.Arguments))));
                }
            }
        }

        private static void UpdatePublicConstructor(ModelProvider model, Dictionary<string, List<FlattenPropertyInfo>> map)
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
                // if the public constructor became parameterless, we need to remove it
                if (updateParameters.Count == 0)
                {
                    var updatedConstructors = model.Constructors.ToList();
                    updatedConstructors.Remove(publicConstructor);
                    model.Update(constructors: updatedConstructors);
                }
                else
                {
                    publicConstructor.Signature.Update(parameters: updateParameters);
                    publicConstructor.Update(signature: publicConstructor.Signature); // workaround to update the xml docs
                }
            }
        }

        private static bool ShouldIncludeFlattenedPropertyInPublicConstructor(PropertyProvider flattenedProperty)
            => (flattenedProperty.WireInfo?.IsRequired == true) && !flattenedProperty.Type.IsCollection;

        private static void UpdatePublicConstructorBody(ModelProvider model, Dictionary<string, List<FlattenPropertyInfo>> map, ConstructorProvider publicConstructor)
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

        private class CSharpTypeNameComparer : IEqualityComparer<CSharpType>
        {
            public bool Equals(CSharpType? x, CSharpType? y)
            {
                if (x is null && y is null)
                {
                    return true;
                }
                if (x is null || y is null)
                {
                    return false;
                }
                return x.Namespace == y.Namespace && x.Name == y.Name;
            }

            public int GetHashCode(CSharpType obj)
            {
                HashCode hashCode = new HashCode();
                hashCode.Add(obj.Namespace);
                hashCode.Add(obj.Name);
                return hashCode.ToHashCode();
            }
        }

        private record FlattenPropertyInfo(bool IsOverriddenValueType, PropertyProvider FlattenedProperty);
    }
}
