// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
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
using System.Diagnostics.CodeAnalysis;
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
                if (returnType is not null && TryGetFlattenPropertyInfo(returnType, out var propertyNameMap))
                {
                    UpdateModelFactoryMethod(method, propertyNameMap);
                }
            }
        }

        private bool TryGetFlattenPropertyInfo(CSharpType returnType, [NotNullWhen(true)] out Dictionary<string, List<FlattenPropertyInfo>>? propertyNameMap)
        {
            propertyNameMap = null;
            if (_flattenedModelTypes.TryGetValue(returnType, out var value))
            {
                propertyNameMap = value;
                return true;
            }
            // handle the case where the return type is a derived type of a flattened model type
            // we only deal with single level inheritance here to avoid complexity
            else if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(returnType, out var typeProvider) && typeProvider is ModelProvider model && model.BaseType is not null && _flattenedModelTypes.TryGetValue(model.BaseType, out value))
            {
                propertyNameMap = value;
                return true;
            }
            return false;
        }

        private void UpdateModelFactoryMethod(MethodProvider method, Dictionary<string, List<FlattenPropertyInfo>> propertyNameMap)
        {
            var parameterMap = new Dictionary<ParameterProvider, ParameterProvider>();
            var updatedParameters = new List<ParameterProvider>(method.Signature.Parameters.Count);
            var updated = false;
            foreach (var parameter in method.Signature.Parameters)
            {
                if (propertyNameMap.TryGetValue(parameter.Name, out var value))
                {
                    updated = true;
                    foreach (var (flattenedProperty, _) in value)
                    {
                        // If the flattened property is a value type, we need to ensure that we handle the nullability correctly.
                        var propertyParameter = flattenedProperty.AsParameter;

                        // The same parameter is used in public constructor, we need a new copy for model factory method with different nullability.
                        var updatedParameter = new ParameterProvider(propertyParameter.Name, propertyParameter.Description, propertyParameter.Type.InputType, propertyParameter.DefaultValue,
                            propertyParameter.IsRef, propertyParameter.IsOut, propertyParameter.IsIn, propertyParameter.IsParams, propertyParameter.Attributes, propertyParameter.Property,
                            propertyParameter.Field, propertyParameter.InitializationValue, propertyParameter.Location, propertyParameter.WireInfo, propertyParameter.Validation);

                        if (IsOverriddenValueType(flattenedProperty))
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
                                        BuildConditionExpression(value, parameterMap)!,
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

        private static ValueExpression? BuildConditionExpression(List<FlattenPropertyInfo> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider>? parameterMap = null, bool publicConstructor = false)
        {
            ScopedApi<bool>? result = null;
            foreach (var (flattenProperty, _) in flattenedProperties)
            {
                var propertyParameter = flattenProperty.AsParameter;
                if (parameterMap is not null && parameterMap.TryGetValue(propertyParameter, out var updatedParameter))
                {
                    if (result is null)
                    {
                        result = updatedParameter.Is(Null);
                    }
                    else
                    {
                        result = result.And(updatedParameter.Is(Null));
                    }
                }
                else if (publicConstructor && !propertyParameter.Type.IsNullable)
                {
                    continue;
                }
                else
                {
                    if (result is null)
                    {
                        result = propertyParameter.Is(Null);
                    }
                    else
                    {
                        result = result.And(propertyParameter.Is(Null));
                    }
                }
            }
            return result;
        }

        // Use the flattened property as the parameter, if it is an overridden value type, we need to use the Value property.
        private ValueExpression[] BuildConstructorParameters(CSharpType propertyType, List<FlattenPropertyInfo> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider>? parameterMap = null, bool publicConstructor = false)
        {
            var propertyModelType = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[propertyType] as ModelProvider;
            var constructorParameters = publicConstructor
                ? propertyModelType!.Constructors.First(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)).Signature.Parameters
                : propertyModelType!.FullConstructor.Signature.Parameters;

            var parameters = new List<ValueExpression>();
            var additionalPropertyIndex = GetAdditionalPropertyIndex();
            for (int flattenedPropertyIndex = 0, fullConstructorParameterIndex = 0; ; fullConstructorParameterIndex++)
            {
                // If we have processed all the flattened properties or all the constructor parameters, we can break the loop.
                if (flattenedPropertyIndex >= flattenedProperties.Count || fullConstructorParameterIndex >= constructorParameters.Count)
                {
                    break;
                }

                if (fullConstructorParameterIndex == additionalPropertyIndex)
                {
                    // If the additionalProperties parameter exists, we need to pass a new instance for it.
                    parameters.Add(Null);

                    // If the additionalProperties parameter is the last parameter, we can break the loop.
                    if (fullConstructorParameterIndex == constructorParameters.Count - 1)
                    {
                        break;
                    }
                    fullConstructorParameterIndex++;
                }

                var constructorParameter = constructorParameters[fullConstructorParameterIndex];
                var constructorParameterType = constructorParameter.Type;

                // First, try to find a match by name (ignoring case) in remaining flattened properties
                var nameMatchIndex = -1;
                for (int i = flattenedPropertyIndex; i < flattenedProperties.Count; i++)
                {
                    if (string.Equals(constructorParameter.Name, flattenedProperties[i].FlattenedProperty.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        nameMatchIndex = i;
                        break;
                    }
                }

                if (nameMatchIndex >= 0)
                {
                    // Found a name match - use that flattened property
                    var (flattenedProperty, _) = flattenedProperties[nameMatchIndex];
                    var propertyParameter = flattenedProperty.AsParameter;
                    var parameter = (parameterMap is not null && parameterMap.TryGetValue(propertyParameter, out var updatedParameter)
                        ? updatedParameter
                        : propertyParameter);

                    // TODO: Ideally we could just call parameter.ToPublicInputParameter() to build the input type parameter, which is not working properly
                    // update the parameter type to match the constructor parameter type for now
                    parameter.Update(type: parameter.Type.InputType);

                    parameters.Add(parameter.Type.IsValueType && parameter.Type.IsNullable && !constructorParameterType.IsNullable
                        ? parameter.Property("Value")
                        : NeedNullCoalesce(parameter) ? parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList() : parameter);

                    // Move past the matched property
                    flattenedPropertyIndex = nameMatchIndex + 1;
                }
                else
                {
                    // No name match found, try to match by type with current flattened property
                    var (flattenedProperty, _) = flattenedProperties[flattenedPropertyIndex];
                    var flattenedPropertyType = flattenedProperty.Type;

                    if (constructorParameterType.AreNamesEqual(flattenedPropertyType?.InputType) ||
                        constructorParameterType.AreNamesEqual(flattenedPropertyType))
                    {
                        var propertyParameter = flattenedProperty.AsParameter;
                        var parameter = (parameterMap is not null && parameterMap.TryGetValue(propertyParameter, out var updatedParameter)
                            ? updatedParameter
                            : propertyParameter);

                        // TODO: Ideally we could just call parameter.ToPublicInputParameter() to build the input type parameter, which is not working properly
                        // update the parameter type to match the constructor parameter type for now
                        parameters.Add(parameter.Type.IsValueType && parameter.Type.IsNullable && !constructorParameterType.IsNullable
                            ? parameter.Property("Value")
                            : NeedNullCoalesce(parameter) ? parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList() : parameter);

                        // only increase flattenedPropertyIndex when we use a flattened property
                        flattenedPropertyIndex++;
                    }
                    else
                    {
                        // This is a nested flattened property case - the constructor parameter is a complex type
                        // We need to find the correct internal property by matching the constructor parameter name,
                        // then recursively collect all nested flattened properties for that specific internal property
                        if (_flattenedModelTypes.TryGetValue(propertyType, out var propertyNameMap))
                        {
                            // Try to match the constructor parameter name with an internal property name
                            if (propertyNameMap.TryGetValue(constructorParameter.Name, out var list) && list.Count > 0)
                            {
                                // Found the internal property by name, now collect all nested flattened properties
                                // that correspond to this internal property from the current flattened properties list
                                // Note: list.Count > 0 check above ensures list[0] is safe to access
                                var internalProperty = list[0].InternalProperty;
                                var innerFlattenedProperties = CollectNestedFlattenedProperties(internalProperty, flattenedProperties);

                                if (innerFlattenedProperties.Count > 0)
                                {
                                    var innerParameters = BuildConstructorParameters(constructorParameterType, innerFlattenedProperties, parameterMap);
                                    parameters.Add(New.Instance(constructorParameterType, innerParameters));
                                }
                                // Note: If innerFlattenedProperties is empty, we skip adding this parameter.
                                // This can happen when the nested model has no required properties, and all
                                // flattened properties are optional. In such cases, the model factory will
                                // not include this nested object in the constructor call.
                            }
                        }
                    }
                }
            }

            // If the additionalProperties parameter is missing at the end, we need to pass a new instance for it.
            if (parameters.Count < constructorParameters.Count && additionalPropertyIndex == constructorParameters.Count - 1)
            {
                parameters.Add(Null);
            }
            return parameters.ToArray();

            int GetAdditionalPropertyIndex()
            {
                var additionalPropertyIndex = -1;
                for (var index = 0; index < constructorParameters.Count; index++)
                {
                    if (constructorParameters[index].Name.Equals("additionalBinaryDataProperties"))
                    {
                        additionalPropertyIndex = index;
                        break;
                    }
                }
                return additionalPropertyIndex;
            }

            bool NeedNullCoalesce(ParameterProvider parameter)
                => (!publicConstructor || parameter.Type.IsNullable) && IsNonReadOnlyMemoryList(parameter);

            bool IsNonReadOnlyMemoryList(ParameterProvider parameter) =>
                parameter.Type is { IsList: true, IsReadOnlyMemory: false };
        }

        // This dictionary holds the flattened model types, where the key is the CSharpType of the model and the value is a dictionary of property names to flattened PropertyProvider.
        // So that, we can use this to update the model factory methods later.
        private readonly Dictionary<CSharpType, Dictionary<string, List<FlattenPropertyInfo>>> _flattenedModelTypes = new(new CSharpTypeNameComparer());
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
            foreach (var internalProperty in model.Properties.Concat(model.CustomCodeView?.Properties ?? []))
            {
                // only flatten complex type properties
                var propertyType = internalProperty.Type;
                if (!(ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(propertyType, out var typeProvider) && typeProvider is ModelProvider modelProvider))
                {
                    continue;
                }

                // we need to flatten the inner property type first if its type is also a model type
                if (!propertyType.IsFrameworkType && !_flattenedModelTypes.ContainsKey(propertyType) && propertyType != model.Type)
                {
                    FlattenModel(modelProvider);
                }

                var innerProperties = PropertyHelpers.GetAllProperties(modelProvider);

                // handle `@flattenProperty`
                if (ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var propertiesToFlatten) && propertiesToFlatten.Contains(internalProperty))
                {
                    isFlattenProperty = true;
                    PropertyFlatten(model, modelProvider, innerProperties, propertyMap, internalProperty);
                    continue;
                }
                // safe flatten single property
                else
                {
                    // only safe flatten single public property
                    var publicPropertyCount = innerProperties.Count(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public));
                    if (publicPropertyCount != 1)
                    {
                        continue;
                    }

                    // skip discriminator property
                    if (internalProperty.IsDiscriminator)
                    {
                        ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-warning", "Discriminator property should not be flattened.");
                        continue;
                    }

                    // skip if internal property type is base abstract discriminator model
                    if (modelProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract))
                    {
                        continue;
                    }

                    isSafeFlatten = SafeFlatten(model, innerProperties, propertyMap, internalProperty, modelProvider);
                }
            }

            var propertyNameMap = propertyMap.ToDictionary(kvp => kvp.Key.Name.ToVariableName(), kvp => kvp.Value);

            if (isSafeFlatten || isFlattenProperty)
            {
                var flattenedProperties = propertyMap.Values.SelectMany(x => x.Select(item => item.FlattenedProperty));
                model.Update(properties: [.. model.Properties, .. flattenedProperties]);
                _flattenedModelTypes.Add(model.Type, propertyNameMap);
                UpdatePublicConstructor(model, propertyNameMap);
            }
        }

        private void PropertyFlatten(ModelProvider model, ModelProvider propertyModel, IReadOnlyList<PropertyProvider> innerProperties, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty)
        {
            var flattenedProperties = new List<(bool IsOverriddenValueType, PropertyProvider FlattenedProperty)>();

            foreach (var innerProperty in innerProperties)
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
                    PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, propertyModel, innerProperty),
                    !internalProperty.Body.HasSetter || !innerProperty.Body.HasSetter ? null : PropertyHelpers.BuildSetterForPropertyFlatten(propertyModel, internalProperty, innerProperty)
                );

                // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
                var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
                var flattenedProperty =
                    new FlattenedPropertyProvider(
                        innerProperty.Description,
                        innerProperty.Modifiers,
                        innerProperty.Type,
                        flattenPropertyName,
                        flattenPropertyBody,
                        model,
                        internalProperty,
                        innerProperty,
                        innerProperty.ExplicitInterface,
                        ConstructFlattenPropertyWireInfo(internalProperty, innerProperty),
                        innerProperty.IsRef,
                        innerProperty.Attributes);

                if (propertyMap.TryGetValue(internalProperty, out var value))
                {
                    value.Add(new(flattenedProperty, internalProperty));
                }
                else
                {
                    propertyMap.Add(internalProperty, new List<FlattenPropertyInfo> { new(flattenedProperty, internalProperty) });
                }
            }
            // make the internalized properties internal
            internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
        }

        private static PropertyWireInformation? ConstructFlattenPropertyWireInfo(PropertyProvider internalProperty, PropertyProvider innerProperty)
        {
            var innerPropertyWireInfo = innerProperty.WireInfo;
            var internalPropertyWireInfo = internalProperty.WireInfo;
            if (innerPropertyWireInfo is null || internalPropertyWireInfo is null)
            {
                return null;
            }
            return new PropertyWireInformation(innerPropertyWireInfo.SerializationFormat,
                innerPropertyWireInfo.IsRequired && internalPropertyWireInfo.IsRequired,
                innerPropertyWireInfo.IsReadOnly || internalPropertyWireInfo.IsReadOnly,
                innerPropertyWireInfo.IsNullable || internalPropertyWireInfo.IsNullable,
                innerPropertyWireInfo.IsDiscriminator,
                innerPropertyWireInfo.SerializedName,
                innerPropertyWireInfo.IsHttpMetadata);
        }

        private bool SafeFlatten(ModelProvider model, IReadOnlyList<PropertyProvider> innerProperties, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty, ModelProvider modelProvider)
        {
            bool isFlattened;
            // Get the single public property from innerProperties
            var innerProperty = innerProperties.Single(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            isFlattened = true;

            // flatten the single property to public and associate it with the internal property
            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(internalProperty, innerProperty);
            var flattenPropertyName = PropertyHelpers.GetCombinedPropertyName(innerProperty, internalProperty); // TODO: handle name conflicts
            var flattenPropertyBody = new MethodPropertyBody(
                PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, modelProvider, innerProperty),
                // if the flattened property is read-only or a collection, we don't generate a setter
                isFlattenedPropertyReadOnly || innerProperty.Type.IsCollection ? null : PropertyHelpers.BuildSetterForSafeFlatten(includeSetterNullCheck, modelProvider, internalProperty, innerProperty)
            );

            // If the inner property is a value type, we need to ensure that we handle the nullability correctly.
            var isOverriddenValueType = innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
            var flattenedProperty =
                new FlattenedPropertyProvider(
                    innerProperty.Description,
                    innerProperty.Modifiers,
                    isOverriddenValueType ? innerProperty.Type.WithNullable(true) : innerProperty.Type,
                    flattenPropertyName,
                    flattenPropertyBody,
                    model,
                    internalProperty,
                    innerProperty,
                    innerProperty.ExplicitInterface,
                    ConstructFlattenPropertyWireInfo(internalProperty, innerProperty),
                    innerProperty.IsRef,
                    innerProperty.Attributes);

            // make the internalized properties internal
            internalProperty.Update(modifiers: internalProperty.Modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal);
            if (propertyMap.TryGetValue(internalProperty, out var value))
            {
                value.Add(new(flattenedProperty, internalProperty));
            }
            else
            {
                propertyMap.Add(internalProperty, new List<FlattenPropertyInfo> { new(flattenedProperty, internalProperty) });
            }
            return isFlattened;
        }

        private void UpdateFlattenTypeCollectionProperty(PropertyProvider internalProperty, PropertyProvider innerProperty, ModelProvider modelProvider)
        {
            // Skip updating the body if the inner property is a flattened property from safe-flatten
            // These properties need a custom getter that wires to the backing object, not initialization
            if (innerProperty is FlattenedPropertyProvider)
            {
                return;
            }

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

        private void UpdatePublicConstructor(ModelProvider model, Dictionary<string, List<FlattenPropertyInfo>> map)
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
                    foreach (var (flattenedProperty, _) in value)
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
        {
            // We only include the flattened property in the public constructor if it is required
            return flattenedProperty.WireInfo?.IsRequired == true;
        }

        private void UpdatePublicConstructorBody(ModelProvider model, Dictionary<string, List<FlattenPropertyInfo>> flattenPropertyMap, ConstructorProvider publicConstructor)
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
                            // Remove the @ prefix if present (for C# keywords)
                            var normalizedParameterName = parameterName.StartsWith("@") ? parameterName[1..] : parameterName;
                            if (flattenPropertyMap.TryGetValue(normalizedParameterName, out var value))
                            {
                                foreach (var (flattenProperty, _) in value)
                                {
                                    if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenProperty))
                                    {
                                        updatedBodyStatements.Add(ArgumentSnippets.ValidateParameter(flattenProperty.AsParameter));
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
                    // If the statement is assigning a parameter, we need to update it to validate the flattened properties.
                    else if (statement is ExpressionStatement expression && expression.Expression is AssignmentExpression assignment && assignment.Value is VariableExpression variable)
                    {
                        PropertyProvider? currentInternalProperty = null;
                        var flattenedProperties = new HashSet<PropertyProvider>();
                        if (flattenPropertyMap.TryGetValue(variable.Declaration.RequestedName, out var value))
                        {
                            // collect all internal properties to assign
                            foreach (var (flattenProperty, internalProperty) in value)
                            {
                                if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenProperty))
                                {
                                    currentInternalProperty = internalProperty;
                                    flattenedProperties.Add(flattenProperty);
                                }
                            }

                            // we should only construct the flattened properties in the public constructor when assigning to the internal property
                            if (currentInternalProperty is not null)
                            {
                                var properties = value.Where(x => flattenedProperties.Contains(x.FlattenedProperty)).ToList();
                                var conditionExpression = BuildConditionExpression(properties, publicConstructor: true);
                                var instanceExpression = New.Instance(variable.Type, BuildConstructorParameters(variable.Type, properties, publicConstructor: true));
                                var assignmentExpression =
                                    conditionExpression is null
                                    ? instanceExpression
                                    : new TernaryConditionalExpression(
                                    conditionExpression,
                                    Default,
                                    instanceExpression
                                    );
                                updatedBodyStatements.Add(((MemberExpression)currentInternalProperty).Assign(assignmentExpression).Terminate());
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

        private record FlattenPropertyInfo(PropertyProvider FlattenedProperty, PropertyProvider InternalProperty);

        private bool IsOverriddenValueType(PropertyProvider flattenedProperty)
            => flattenedProperty.Type.IsValueType && !flattenedProperty.Type.IsNullable;

        /// <summary>
        /// Recursively collects all nested flattened properties for a given internal property.
        /// This handles cases where properties are flattened multiple levels deep.
        /// </summary>
        /// <param name="internalProperty">The internal property to collect nested flattened properties for</param>
        /// <param name="flattenedProperties">The list of all flattened properties at the current level</param>
        /// <returns>A list of FlattenPropertyInfo for all nested flattened properties</returns>
        private List<FlattenPropertyInfo> CollectNestedFlattenedProperties(PropertyProvider internalProperty, List<FlattenPropertyInfo> flattenedProperties)
        {
            var result = new List<FlattenPropertyInfo>();

            // Find all flattened properties at the current level that originate from this internal property
            foreach (var flattenedInfo in flattenedProperties)
            {
                if (flattenedInfo.FlattenedProperty is FlattenedPropertyProvider flattenedProvider)
                {
                    // Check if this flattened property comes from a chain that includes the target internal property
                    if (IsInFlattenChain(flattenedProvider, internalProperty))
                    {
                        result.Add(flattenedInfo);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if the given internal property is in the flattening chain of the flattened property.
        /// This handles multi-level flattening by recursively checking the chain.
        /// Note: The recursion depth is typically very shallow (2-3 levels at most) in practice,
        /// as TypeSpec models rarely have deeply nested flattening structures.
        /// </summary>
        /// <param name="flattenedProvider">The flattened property provider to check</param>
        /// <param name="targetInternalProperty">The internal property to look for in the chain</param>
        /// <returns>True if the internal property is in the flattening chain</returns>
        private bool IsInFlattenChain(FlattenedPropertyProvider flattenedProvider, PropertyProvider targetInternalProperty)
        {
            // The FlattenedProperty is the immediate parent (the property this was flattened from)
            // The OriginalProperty is the actual property from the inner model

            // Check if the OriginalProperty is itself a FlattenedPropertyProvider (multi-level flattening)
            if (flattenedProvider.OriginalProperty is FlattenedPropertyProvider innerFlattened)
            {
                // The inner flattened property's FlattenedProperty is what we need to check
                if (innerFlattened.FlattenedProperty == targetInternalProperty)
                {
                    return true;
                }

                // Recursively check deeper levels
                return IsInFlattenChain(innerFlattened, targetInternalProperty);
            }

            // For single-level flattening, check if FlattenedProperty matches
            // This handles the case where we're at the last level of flattening
            return flattenedProvider.FlattenedProperty == targetInternalProperty;
        }
    }
}
