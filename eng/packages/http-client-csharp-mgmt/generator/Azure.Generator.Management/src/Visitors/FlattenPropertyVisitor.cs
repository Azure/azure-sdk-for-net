// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
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
        private static CSharpType WirePathAttributeType => ManagementClientGenerator.Instance.OutputLibrary.WirePathAttributeDefinition.Type;

        // Drop any WirePath attribute that may be attached to the inner property (e.g., copied verbatim from a
        // customization partial class). When a property is flattened, its wire path changes (e.g., "left" becomes
        // "properties.left"), so any WirePath attribute copied from the inner property is stale and incorrect.
        // WirePathVisitor will add the correct combined wire-path attribute on the flattened property after it
        // is created; keeping the original attribute here can cause duplicate or malformed attributes.
        internal static IReadOnlyList<AttributeStatement> FilterAttributesForFlatten(IReadOnlyList<AttributeStatement> attributes)
        {
            if (attributes is null || attributes.Count == 0)
            {
                return attributes ?? [];
            }
            var wirePathType = WirePathAttributeType;
            return [.. attributes.Where(a => !IsWirePathAttribute(a, wirePathType))];
        }

        internal static bool IsWirePathAttribute(AttributeStatement attribute, CSharpType wirePathType)
        {
            // Resolving AttributeStatement.Type walks through Data!.AttributeClass!.GetCSharpType(); for
            // source-parsed attributes that fail to bind (e.g., the attribute type is not visible to the
            // customization compilation), that chain can throw. Fall through to a best-effort name compare
            // using whatever we can safely read.
            CSharpType? type = null;
            try
            {
                type = attribute.Type;
            }
            catch
            {
                return false;
            }

            if (type is null)
            {
                return false;
            }

            if (type.Equals(wirePathType))
            {
                return true;
            }
            // Source-parsed attributes (from a customization partial class) may have a different CSharpType
            // instance, so fall back to a name comparison.
            var name = type.Name;
            return name == wirePathType.Name || name == "WirePath";
        }

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
            // Update primary methods (replace 'properties' param with flattened params, fix body)
            foreach (var method in modelFactory.Methods)
            {
                var returnType = method.Signature.ReturnType;
                if (returnType is not null && TryGetFlattenPropertyInfo(returnType, out var propertyNameMap))
                {
                    UpdateModelFactoryMethod(method, propertyNameMap);
                }
            }
        }

        /// <summary>
        /// Checks if a property has the [Obsolete] attribute. Properties marked obsolete
        /// in custom code (partial classes) should be skipped during flattening to avoid
        /// generating code that references obsolete members, which causes CS0618 warnings.
        /// </summary>
        internal static bool IsObsoleteProperty(PropertyProvider property)
        {
            return property.Attributes.Any(a =>
                a.Type is { IsFrameworkType: true } && a.Type.FrameworkType == typeof(System.ObsoleteAttribute));
        }

        private static bool IsPublicModelProperty(PropertyProvider property)
        {
            return property.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                && IsEffectiveModelProperty(property);
        }

        private static bool IsEffectiveModelProperty(PropertyProvider property)
            => !IsObsoleteProperty(property)
                && !IsJsonPatchProperty(property)
                && !property.Modifiers.HasFlag(MethodSignatureModifiers.Static);

#pragma warning disable SCME0001 // JsonPatch is experimental.
        private static bool IsJsonPatchProperty(PropertyProvider property)
            => property.Type.Equals(typeof(System.ClientModel.Primitives.JsonPatch));
#pragma warning restore SCME0001

        private static bool IsFlattenableProperty(PropertyProvider property)
            => IsPublicModelProperty(property) && property.WireInfo is not null;

        private bool TryGetFlattenPropertyInfo(CSharpType returnType, [NotNullWhen(true)] out Dictionary<string, List<FlattenPropertyInfo>>? propertyNameMap)
        {
            Dictionary<string, List<FlattenPropertyInfo>>? mergedPropertyNameMap = null;
            var currentType = returnType;
            var foundFlattenedProperties = false;
            var visited = new HashSet<CSharpType>(new CSharpTypeNameComparer());

            void MergeFlattenedProperties(Dictionary<string, List<FlattenPropertyInfo>> source)
            {
                mergedPropertyNameMap ??= new Dictionary<string, List<FlattenPropertyInfo>>();
                foreach (var (parameterName, flattenInfoList) in source)
                {
                    if (mergedPropertyNameMap.TryGetValue(parameterName, out var existing))
                    {
                        existing.AddRange(flattenInfoList);
                    }
                    else
                    {
                        mergedPropertyNameMap[parameterName] = [.. flattenInfoList];
                    }
                }

                foundFlattenedProperties = true;
            }
            // Walk up the inheritance chain because flattened properties can come from
            // both the current leaf model and any ancestor model in the hierarchy.
            ModelProvider? currentModel;
            do
            {
                // Guard against cycles in the BaseType chain (e.g., ResourceData → ResourceData
                // when a Custom/ partial class forces a plain model to inherit from ResourceData
                // and KnownManagementTypes maps multiple TypeSpec types to the same CSharpType).
                if (!visited.Add(currentType))
                {
                    break;
                }

                if (_flattenedModelTypes.TryGetValue(currentType, out var value))
                {
                    MergeFlattenedProperties(value);
                }

                currentModel = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(currentType, out var typeProvider)
                    && typeProvider is ModelProvider model
                    && model.BaseType is not null
                    ? model
                    : null;

                if (currentModel is not null)
                {
                    currentType = currentModel.BaseType!;
                }
            }
            while (currentModel is not null);

            propertyNameMap = mergedPropertyNameMap;
            return foundFlattenedProperties;
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

                        // Skip if we've already processed this parameter (can happen when multiple flattened properties share the same underlying parameter)
                        if (parameterMap.ContainsKey(propertyParameter))
                        {
                            continue;
                        }

                        // The same parameter is used in public constructor, we need a new copy for model factory method with different nullability.
                        // When the flattened property was lifted (wrapper is optional), the model factory
                        // parameter is nullable so callers can omit it when mocking — regardless of
                        // whether the inner is a value type or a reference type.
                        // Always start from InputType so collections become IEnumerable<T> in the
                        // factory signature (preserves the long-standing factory-collection convention).
                        var liftedToNullable = (flattenedProperty as Primitives.FlattenedPropertyProvider)?.IsLiftedToNullable == true;
                        var newParamType = liftedToNullable
                            ? propertyParameter.Type.InputType.WithNullable(true)
                            : propertyParameter.Type.InputType;
                        var updatedParameter = new ParameterProvider(propertyParameter.Name, propertyParameter.Description, newParamType, propertyParameter.DefaultValue,
                            propertyParameter.IsRef, propertyParameter.IsOut, propertyParameter.IsIn, propertyParameter.IsParams, propertyParameter.Attributes, propertyParameter.Property,
                            propertyParameter.Field, propertyParameter.InitializationValue, propertyParameter.Location, propertyParameter.WireInfo, propertyParameter.Validation);

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
                                    var ctorParams = BuildConstructorParameters(variable.Type, value, parameterMap);
                                    if (ctorParams is not null)
                                    {
                                        var condition = BuildConditionExpression(value, parameterMap);
                                        if (condition is null)
                                        {
                                            // No nullable params to test (e.g., all flattened leaves are required value types) -
                                            // always construct the parent.
                                            updatedInstanceParameters.Add(New.Instance(variable.Type, ctorParams));
                                        }
                                        else
                                        {
                                            updatedInstanceParameters.Add(
                                            new TernaryConditionalExpression(
                                                condition,
                                                Default,
                                                New.Instance(variable.Type, ctorParams)));
                                        }
                                    }
                                    else
                                    {
                                        // Type not found in CSharpTypeMap, fall back to default to avoid referencing a removed parameter
                                        updatedInstanceParameters.Add(Default);
                                    }
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
            // Whether the wrapper that owns these flattened leaves is optional. When the wrapper
            // is required, we must always construct it (returning null here makes
            // UpdateModelFactoryMethod emit unconditional construction). When the wrapper is
            // optional, every leaf is lifted to nullable in the model-factory signature, so we
            // gate construction on "all leaves are null".
            // For the public constructor path we still want the legacy behaviour of skipping
            // non-nullable params (a required leaf in a public ctor cannot be null), so this
            // wrapper-required short-circuit only applies to the model-factory path.
            var wrapperIsOptional = flattenedProperties.Any(p =>
                (p.FlattenedProperty as Primitives.FlattenedPropertyProvider)?.IsLiftedToNullable == true);
            if (!publicConstructor && !wrapperIsOptional)
            {
                return null;
            }

            ScopedApi<bool>? result = null;
            foreach (var (flattenProperty, _) in flattenedProperties)
            {
                var propertyParameter = flattenProperty.AsParameter;
                var effectiveParameter = (parameterMap is not null && parameterMap.TryGetValue(propertyParameter, out var updatedParameter))
                    ? updatedParameter
                    : propertyParameter;

                // A non-nullable parameter (e.g. a required value type kept as `T` in the
                // public constructor) can never be null, so it must not appear in the
                // "all params null → default the parent" guard.
                if (!effectiveParameter.Type.IsNullable)
                {
                    continue;
                }

                if (result is null)
                {
                    result = effectiveParameter.Is(Null);
                }
                else
                {
                    result = result.And(effectiveParameter.Is(Null));
                }
            }
            return result;
        }

        // Use the flattened property as the parameter, if it is an overridden value type, we need to use the Value property.
        private ValueExpression[]? BuildConstructorParameters(CSharpType propertyType, List<FlattenPropertyInfo> flattenedProperties, IReadOnlyDictionary<ParameterProvider, ParameterProvider>? parameterMap = null, bool publicConstructor = false)
        {
            if (!TryGetModelProvider(propertyType, out var propertyModelType))
            {
                return null;
            }
            var constructorParameters = publicConstructor
                ? propertyModelType.Constructors.First(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)).Signature.Parameters
                : propertyModelType.FullConstructor.Signature.Parameters;

            var parameters = new List<ValueExpression>();
            var additionalPropertyIndex = GetAdditionalPropertyIndex();
            var usedFlattenedPropertyIndices = new HashSet<int>();
            for (int fullConstructorParameterIndex = 0; fullConstructorParameterIndex < constructorParameters.Count; fullConstructorParameterIndex++)
            {
                if (fullConstructorParameterIndex == additionalPropertyIndex)
                {
                    // If the additionalProperties parameter exists, we need to pass a new instance for it.
                    parameters.Add(Null);
                    continue;
                }

                var constructorParameter = constructorParameters[fullConstructorParameterIndex];
                var constructorParameterType = constructorParameter.Type;

                // First, try to find a match by name (ignoring case) in all unused flattened properties
                var nameMatchIndex = -1;
                for (int i = 0; i < flattenedProperties.Count; i++)
                {
                    if (!usedFlattenedPropertyIndices.Contains(i) &&
                        string.Equals(constructorParameter.Name, flattenedProperties[i].FlattenedProperty.Name, StringComparison.OrdinalIgnoreCase))
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
                        ? parameter.Invoke(nameof(Nullable<int>.GetValueOrDefault))
                        : NeedNullCoalesce(parameter) ? parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList() : parameter);

                    usedFlattenedPropertyIndices.Add(nameMatchIndex);
                }
                else
                {
                    // No name match found, try to match by type with unused flattened properties
                    var typeMatchIndex = -1;
                    for (int i = 0; i < flattenedProperties.Count; i++)
                    {
                        if (usedFlattenedPropertyIndices.Contains(i))
                        {
                            continue;
                        }
                        var flattenedPropertyType = flattenedProperties[i].FlattenedProperty.Type;
                        if (constructorParameterType.AreNamesEqual(flattenedPropertyType?.InputType) ||
                            constructorParameterType.AreNamesEqual(flattenedPropertyType))
                        {
                            typeMatchIndex = i;
                            break;
                        }
                    }

                    if (typeMatchIndex >= 0)
                    {
                        var (flattenedProperty, _) = flattenedProperties[typeMatchIndex];
                        var propertyParameter = flattenedProperty.AsParameter;
                        var parameter = (parameterMap is not null && parameterMap.TryGetValue(propertyParameter, out var updatedParameter)
                            ? updatedParameter
                            : propertyParameter);

                        // TODO: Ideally we could just call parameter.ToPublicInputParameter() to build the input type parameter, which is not working properly
                        // update the parameter type to match the constructor parameter type for now
                        parameters.Add(parameter.Type.IsValueType && parameter.Type.IsNullable && !constructorParameterType.IsNullable
                            ? parameter.Invoke(nameof(Nullable<int>.GetValueOrDefault))
                            : NeedNullCoalesce(parameter) ? parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList() : parameter);

                        usedFlattenedPropertyIndices.Add(typeMatchIndex);
                    }
                    else
                    {
                        // This is a nested flattened property case - the constructor parameter is a complex type
                        // We need to find the correct internal property by matching the constructor parameter name,
                        // then recursively collect all nested flattened properties for that specific internal property
                        if (TryGetFlattenedModelType(propertyType, out var propertyNameMap))
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
                                    if (innerParameters is not null)
                                    {
                                        parameters.Add(New.Instance(constructorParameterType, innerParameters));
                                    }
                                    else
                                    {
                                        parameters.Add(Default.CastTo(constructorParameterType));
                                    }
                                }
                                else
                                {
                                    // If innerFlattenedProperties is empty, we still need to add a parameter
                                    // to maintain the correct parameter count for the constructor.
                                    // This can happen when the nested model has no required properties, and all
                                    // flattened properties are optional.
                                    // Use Default.CastTo to handle both value types and reference types correctly.
                                    parameters.Add(Default.CastTo(constructorParameterType));
                                }
                            }
                            else
                            {
                                // Constructor parameter not found in propertyNameMap, add default as parameter
                                // Use Default.CastTo to handle both value types and reference types correctly.
                                parameters.Add(Default.CastTo(constructorParameterType));
                            }
                        }
                        else
                        {
                            // propertyType not found in _flattenedModelTypes, add default as parameter
                            // Use Default.CastTo to handle both value types and reference types correctly.
                            parameters.Add(Default.CastTo(constructorParameterType));
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
        private readonly Dictionary<FlattenedSetterCacheKey, bool> _flattenedIntoParentWithLastContractSetterCache = [];
        private readonly HashSet<PropertyProvider> _requiredCollectionSetters = new(ReferenceEqualityComparer.Instance);
        private readonly HashSet<PropertyProvider> _requiredScalarLeafSetters = new(ReferenceEqualityComparer.Instance);
        private readonly HashSet<InputProperty> _requiredScalarSetterSources = new(ReferenceEqualityComparer.Instance);
        private readonly HashSet<CSharpType> _visitedModelTypes = new();
        private void FlattenModel(ModelProvider model)
        {
            if (_visitedModelTypes.Contains(model.Type))
            {
                // already visiting this model type, we have a cycle, return
                return;
            }
            _visitedModelTypes.Add(model.Type);

            // Ensure base model types are flattened first so that inherited properties
            // are in their final state (e.g., safe-flattened single-property models become internal)
            // before this model processes them via GetAllProperties.
            if (model.BaseModelProvider is ModelProvider baseModel && !_flattenedModelTypes.ContainsKey(baseModel.Type))
            {
                FlattenModel(baseModel);
            }

            var isFlattenProperty = false;
            var isSafeFlatten = false;
            var propertyMap = new Dictionary<PropertyProvider, List<FlattenPropertyInfo>>();
            foreach (var internalProperty in model.Properties.Concat(model.CustomCodeView?.Properties ?? []))
            {
                ManagementClientGenerator.Instance.DateTimePropertyMatcher.RegisterCanonicalProperty(internalProperty, model);
                // only flatten complex type properties
                var propertyType = internalProperty.Type;
                if (!TryGetModelProvider(propertyType, out var modelProvider))
                {
                    continue;
                }

                // we need to flatten the inner property type first if its type is also a model type
                if (!propertyType.IsFrameworkType && !_flattenedModelTypes.ContainsKey(propertyType) && propertyType != model.Type)
                {
                    FlattenModel(modelProvider);
                }

                var innerProperties = PropertyHelpers.GetAllProperties(modelProvider);
                foreach (var innerProperty in innerProperties)
                {
                    ManagementClientGenerator.Instance.DateTimePropertyMatcher.RegisterCanonicalProperty(innerProperty, modelProvider);
                }

                // handle `@flattenProperty`
                // Use name-based matching instead of reference equality because custom code
                // may override the property, creating a different PropertyProvider instance
                // than the one cached in OutputFlattenPropertyMap.
                if (ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var propertiesToFlatten) && propertiesToFlatten.Any(p => p.Name == internalProperty.Name))
                {
                    isFlattenProperty = true;
                    PropertyFlatten(model, modelProvider, innerProperties, propertyMap, internalProperty);
                    continue;
                }
                // safe flatten single property
                else if (CanSafeFlatten(model, internalProperty, modelProvider, innerProperties))
                {
                    isSafeFlatten = SafeFlatten(model, innerProperties, propertyMap, internalProperty, modelProvider);
                }
            }

            var propertyNameMap = propertyMap.ToDictionary(kvp => kvp.Key.Name.ToVariableName(), kvp => kvp.Value);

            if (isSafeFlatten || isFlattenProperty)
            {
                var flattenedProperties = propertyMap.Values.SelectMany(x => x.Select(item => item.FlattenedProperty));
                model.Update(properties: [.. model.Properties, .. flattenedProperties]);
                _flattenedModelTypes.Add(model.Type, propertyNameMap);
            }

            // A derived model can flatten properties of its own while also inheriting a
            // flattened constructor parameter. Transform both sets together so its base
            // initializer agrees with the flattened base constructor.
            if (TryGetFlattenPropertyInfo(model.Type, out var constructorPropertyNameMap))
            {
                UpdatePublicConstructor(model, constructorPropertyNameMap);
            }
        }

        private static bool CanSafeFlatten(ModelProvider model, PropertyProvider wrapper, ModelProvider innerModel,
            IReadOnlyList<PropertyProvider> innerProperties)
        {
            // Preserve a shipped wrapper and count its flattened representation only once.
            if (ShouldPreserveLastContractProperty(model, wrapper))
            {
                return false;
            }
            var flattenedWrappers = innerProperties.OfType<FlattenedPropertyProvider>()
                .Select(p => p.FlattenedProperty).ToHashSet();
            var effectiveProperties = innerProperties
                .Where(p => IsEffectiveModelProperty(p) && !flattenedWrappers.Contains(p)).ToArray();
            return effectiveProperties.Length == 1 && IsFlattenableProperty(effectiveProperties[0]) &&
                !innerModel.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract) &&
                !innerProperties.Any(p => p.IsDiscriminator) &&
                !ManagementClientGenerator.Instance.OutputLibrary.SafeFlattenDisabledModels.Contains(innerModel);
        }

        private void PropertyFlatten(ModelProvider model, ModelProvider propertyModel, IReadOnlyList<PropertyProvider> innerProperties, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty)
        {
            foreach (var innerProperty in innerProperties)
            {
                if (!IsFlattenableProperty(innerProperty))
                {
                    continue;
                }
                // flatten the property to public and associate it with the internal property
                var flattenPropertyName = ResolveFlattenedDateTimePropertyName(
                    model,
                    internalProperty,
                    innerProperty,
                    innerProperty.Name,
                    propertyMap,
                    innerProperties,
                    static historicalName => historicalName); // TODO: handle name conflicts
                flattenPropertyName = ResolveFlattenedAcronymPropertyName(
                    model, internalProperty, innerProperty, flattenPropertyName, propertyMap, innerProperties, static historicalName => historicalName);

                // New properties reflect wrapper optionality; shipped value-type nullability
                // takes precedence without changing the serialized inner property.
                var shouldLiftToNullable = ShouldLiftToNullable(internalProperty);
                var propertyType = GetFlattenedPropertyType(model, flattenPropertyName, innerProperty, shouldLiftToNullable);
                var path = GetFlattenedWirePath(internalProperty, innerProperty);
                var contractSetter = FindLastContractSetter(model, flattenPropertyName, innerProperty.Type, path);
                var restrictedSetter = HasRestrictedContractSetter(model, flattenPropertyName, innerProperty.Type, path);
                var getterOnlyContract = HasGetterOnlyContractProperty(model, flattenPropertyName, innerProperty.Type, path);
                var delegationOnlyScalar = HasDelegationOnlyScalarSetter(innerProperty);
                var parentNeedsSetter = (innerProperty.Type.IsCollection || restrictedSetter || !innerProperty.Body.HasSetter || delegationOnlyScalar) &&
                    IsFlattenedIntoParentWithLastContractSetter(model, flattenPropertyName, internalProperty, innerProperty);
                var canAssignWrapper = CanAssignWrapper(model, internalProperty);
                var canConstructWrapper = PropertyHelpers.HasAccessibleDefaultConstructor(propertyModel);
                var shouldEmitSetter = (contractSetter is not null || parentNeedsSetter) && canAssignWrapper && canConstructWrapper && CanAssignProperty(innerProperty);
                EnsureFlattenedWrapperSetter(model, internalProperty, shouldEmitSetter);
                EnsureScalarLeafSetter(innerProperty, shouldEmitSetter);
                UpdateFlattenTypeCollectionProperty(internalProperty, innerProperty, model, shouldEmitSetter);
                var (_, includeGetterNullCheck, _) = PropertyHelpers.GetFlags(internalProperty, innerProperty);
                var flattenPropertyBody = new MethodPropertyBody(
                    PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, propertyModel, innerProperty, propertyType, canAssignWrapper && canConstructWrapper),
                    !internalProperty.Body.HasSetter || !innerProperty.Body.HasSetter || !canAssignWrapper || !canConstructWrapper || !CanAssignProperty(innerProperty) ||
                        (restrictedSetter && !parentNeedsSetter) || (delegationOnlyScalar && !shouldEmitSetter) ? null :
                        PropertyHelpers.BuildSetterForPropertyFlatten(propertyModel, internalProperty, innerProperty, propertyType.IsNullable, shouldEmitSetter),
                    GetContractSetterModifier(contractSetter, innerProperty.Modifiers, model, (restrictedSetter || getterOnlyContract) && parentNeedsSetter)
                );

                var flattenedProperty =
                    new FlattenedPropertyProvider(
                        innerProperty.Description,
                        innerProperty.Modifiers,
                        propertyType,
                        flattenPropertyName,
                        flattenPropertyBody,
                        model,
                        internalProperty,
                        innerProperty,
                        innerProperty.ExplicitInterface,
                        ConstructFlattenPropertyWireInfo(internalProperty, innerProperty),
                        innerProperty.IsRef,
                        FilterAttributesForFlatten(innerProperty.Attributes),
                        isLiftedToNullable: shouldLiftToNullable);
                ManagementClientGenerator.Instance.DateTimePropertyMatcher.RegisterDerivedProperty(flattenedProperty, innerProperty);

                PreserveConstructorParameterType(model, flattenedProperty, innerProperty, shouldLiftToNullable);

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
                innerPropertyWireInfo.IsHttpMetadata,
                innerPropertyWireInfo.IsApiVersion);
        }

        private bool SafeFlatten(ModelProvider model, IReadOnlyList<PropertyProvider> innerProperties, Dictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap, PropertyProvider internalProperty, ModelProvider modelProvider)
        {
            bool isFlattened;
            // Get the single public wire property from innerProperties.
            var innerProperty = innerProperties.Single(IsFlattenableProperty);
            isFlattened = true;

            // flatten the single property to public and associate it with the internal property
            var flattenPropertyName = ResolveFlattenedDateTimePropertyName(
                model,
                internalProperty,
                innerProperty,
                PropertyHelpers.GetCombinedPropertyName(innerProperty, internalProperty),
                propertyMap,
                innerProperties,
                historicalName => PropertyHelpers.GetCombinedPropertyName(innerProperty, internalProperty, historicalName)); // TODO: handle name conflicts
            flattenPropertyName = ResolveFlattenedAcronymPropertyName(
                model, internalProperty, innerProperty, flattenPropertyName, propertyMap, innerProperties,
                historicalName => PropertyHelpers.GetCombinedPropertyName(innerProperty, internalProperty, historicalName));

            // Apply the same historical type preservation as explicit property flattening.
            var shouldLiftToNullable = ShouldLiftToNullable(internalProperty);
            var propertyType = GetFlattenedPropertyType(model, flattenPropertyName, innerProperty, shouldLiftToNullable);

            var path = GetFlattenedWirePath(internalProperty, innerProperty);
            var contractSetter = FindLastContractSetter(model, flattenPropertyName, innerProperty.Type, path);
            var restrictedSetter = HasRestrictedContractSetter(model, flattenPropertyName, innerProperty.Type, path);
            var getterOnlyContract = HasGetterOnlyContractProperty(model, flattenPropertyName, innerProperty.Type, path);
            var delegationOnlyScalar = HasDelegationOnlyScalarSetter(innerProperty);
            var parentNeedsSetter = (innerProperty.Type.IsCollection || restrictedSetter || !innerProperty.Body.HasSetter || delegationOnlyScalar) &&
                IsFlattenedIntoParentWithLastContractSetter(model, flattenPropertyName, internalProperty, innerProperty);
            var canAssignWrapper = CanAssignWrapper(model, internalProperty);
            var canAssignInner = CanAssignProperty(innerProperty);
            // BuildSetterForSafeFlatten unwraps a lifted nullable value only when the inner value is non-nullable.
            var constructorArgumentType = propertyType.IsNullable && innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable
                ? innerProperty.Type : propertyType;
            var needsConstructor = !canAssignInner ||
                ((!innerProperty.Body.HasSetter || delegationOnlyScalar) && contractSetter is null && !parentNeedsSetter);
            var hasValueConstructor = HasAccessibleSingleValueConstructor(modelProvider, constructorArgumentType);
            var canConstructFromValue = needsConstructor && innerProperty is not FlattenedPropertyProvider && hasValueConstructor;
            var hasCallableDefaultConstructor = PropertyHelpers.HasAccessibleDefaultConstructor(modelProvider);
            var canUseDefaultConstructor = (contractSetter is not null || parentNeedsSetter) && canAssignInner &&
                PropertyHelpers.HasSafeFlattenDefaultConstructor(modelProvider);
            var needsUnwrap = propertyType.IsNullable && innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
            var requiresDefaultConstructor = innerProperty is FlattenedPropertyProvider && !needsUnwrap;
            var canConstructSetter = requiresDefaultConstructor ? hasCallableDefaultConstructor :
                hasValueConstructor || canUseDefaultConstructor ||
                hasCallableDefaultConstructor && PropertyHelpers.HasDefaultPublicCtor(innerProperty.EnclosingType as ModelProvider);
            var shouldEmitSetter = (contractSetter is not null || parentNeedsSetter) && canAssignWrapper &&
                (canAssignInner || canConstructFromValue) && canConstructSetter;
            EnsureFlattenedWrapperSetter(model, internalProperty, shouldEmitSetter);
            EnsureScalarLeafSetter(innerProperty, shouldEmitSetter);
            UpdateFlattenTypeCollectionProperty(internalProperty, innerProperty, model, shouldEmitSetter && innerProperty.Type.IsCollection);
            var (isFlattenedPropertyReadOnly, includeGetterNullCheck, includeSetterNullCheck) = PropertyHelpers.GetFlags(internalProperty, innerProperty);
            var canUseConstructor = canConstructFromValue && internalProperty.Body.HasSetter;
            var flattenPropertyBody = new MethodPropertyBody(
                PropertyHelpers.BuildGetter(includeGetterNullCheck, internalProperty, modelProvider, innerProperty, propertyType,
                    canAssignWrapper && hasCallableDefaultConstructor),
                // Emit collection setters only when compatibility or parent delegation requires them.
                (isFlattenedPropertyReadOnly && !canUseConstructor) || !canAssignWrapper || !canConstructSetter || (!canAssignInner && !canUseConstructor) ||
                    (restrictedSetter && !parentNeedsSetter) || (delegationOnlyScalar && !shouldEmitSetter && !canUseConstructor) ||
                    (innerProperty.Type.IsCollection && !shouldEmitSetter) ? null :
                    PropertyHelpers.BuildSetterForSafeFlatten(canUseConstructor ? false : includeSetterNullCheck, modelProvider, internalProperty, innerProperty, propertyType.IsNullable,
                        // Preserve the existing value-constructor semantics whenever that route is callable.
                        allowDefaultConstructorForCompatibility: shouldEmitSetter && canAssignInner && (!hasValueConstructor || requiresDefaultConstructor)),
                GetContractSetterModifier(contractSetter, innerProperty.Modifiers, model, (restrictedSetter || getterOnlyContract) && parentNeedsSetter)
            );

            var flattenedProperty =
                new FlattenedPropertyProvider(
                    innerProperty.Description,
                    innerProperty.Modifiers,
                    propertyType,
                    flattenPropertyName,
                    flattenPropertyBody,
                    model,
                    internalProperty,
                    innerProperty,
                    innerProperty.ExplicitInterface,
                    ConstructFlattenPropertyWireInfo(internalProperty, innerProperty),
                    innerProperty.IsRef,
                    FilterAttributesForFlatten(innerProperty.Attributes),
                    isLiftedToNullable: shouldLiftToNullable);
            ManagementClientGenerator.Instance.DateTimePropertyMatcher.RegisterDerivedProperty(flattenedProperty, innerProperty);
            PreserveConstructorParameterType(model, flattenedProperty, innerProperty, shouldLiftToNullable);

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

        private static CSharpType GetFlattenedPropertyType(ModelProvider model, string name, PropertyProvider innerProperty, bool lifted)
        {
            var currentType = lifted ? innerProperty.Type.WithNullable(true) : innerProperty.Type;
            var previous = model.LastContractView?.Properties.FirstOrDefault(p => p.Name == name && IsPublicApi(p.Modifiers));
            if (previous is null || previous.Type.HasSamePublicType(currentType)
                || model.CustomCodeView?.Properties.Any(p => p.Name == name) == true
                || ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, previous))
            {
                return currentType;
            }

            if (previous.Type.HasSamePublicType(currentType, ignoreNullable: true))
            {
                return currentType.IsValueType ? previous.Type : currentType;
            }

            return currentType;
        }

        private static void PreserveConstructorParameterType(ModelProvider model, PropertyProvider flattenedProperty, PropertyProvider innerProperty, bool lifted)
        {
            // Keep constructor parameter nullability independent of the property's wrapper lifting.
            // Mixed T/T? overloads are restored separately after upstream compatibility processing.
            var parameter = flattenedProperty.AsParameter;
            var previousTypes = model.LastContractView?.Constructors
                .Where(c => IsPublicApi(c.Signature.Modifiers)
                    && !ModelCompatibilityValidator.IsConstructorRemovalAccepted(model, c.Signature))
                .SelectMany(c => c.Signature.Parameters)
                .Where(p => p.Name == parameter.Name && p.Type.HasSamePublicType(parameter.Type, ignoreNullable: true))
                .Select(p => p.Type)
                .Distinct()
                .ToArray();
            if (previousTypes?.Length == 1)
            {
                parameter.Update(type: previousTypes[0]);
            }
            else if (lifted)
            {
                parameter.Update(type: innerProperty.Type);
            }
        }

        private static bool ShouldPreserveLastContractProperty(ModelProvider model, PropertyProvider property)
        {
            return model.LastContractView?.Properties.Any(p =>
                IsPublicApi(p.Modifiers) &&
                p.Name == property.Name &&
                p.Type.HasSamePublicType(property.Type, ignoreNullable: true)) == true;
        }

        private static PropertyProvider? FindLastContractSetter(ModelProvider model, string propertyName, CSharpType type, string? path)
            => model.LastContractView?.Properties.FirstOrDefault(p => p.Name == propertyName && HasPublicContractSetter(p) &&
                HasSameFlattenedType(p.Type, type) && HasCompatibleWirePath(p, path) &&
                !ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, p));

        private static bool ShouldPreserveLastContractSetter(ModelProvider model, string propertyName, CSharpType type, string? path)
            => FindLastContractSetter(model, propertyName, type, path) is not null;

        private static bool HasRestrictedContractSetter(ModelProvider model, string name, CSharpType type, string? path)
            => model.LastContractView?.Properties.Any(p => p.Name == name && IsPublicApi(p.Modifiers) && p.Body.HasSetter &&
                !HasPublicContractSetter(p) && HasSameFlattenedType(p.Type, type) &&
                HasCompatibleWirePath(p, path) && !ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, p)) == true;

        private static bool HasGetterOnlyContractProperty(ModelProvider model, string name, CSharpType type, string? path)
            => model.LastContractView?.Properties.Any(p => p.Name == name && IsPublicApi(p.Modifiers) && !p.Body.HasSetter &&
                HasSameFlattenedType(p.Type, type) && HasCompatibleWirePath(p, path) &&
                !ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, p)) == true;

        private static MethodSignatureModifiers GetContractSetterModifier(PropertyProvider? contractSetter,
            MethodSignatureModifiers propertyModifiers, ModelProvider model, bool internalDelegation)
        {
            if (internalDelegation)
            {
                return propertyModifiers.HasFlag(MethodSignatureModifiers.Public) ? MethodSignatureModifiers.Internal : MethodSignatureModifiers.None;
            }
            var modifiers = contractSetter?.Body switch
            {
                AutoPropertyBody body => body.SetterModifiers,
                MethodPropertyBody body => body.SetterModifiers,
                _ => MethodSignatureModifiers.None
            };
            const MethodSignatureModifiers access = MethodSignatureModifiers.Public | MethodSignatureModifiers.Protected |
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Private;
            modifiers &= access;
            if (modifiers == MethodSignatureModifiers.Protected && propertyModifiers.HasFlag(MethodSignatureModifiers.Public) &&
                IsUsedByAnotherModel(model))
            {
                // Preserve protected access outside the assembly while allowing generated forwarding setters.
                return MethodSignatureModifiers.Protected | MethodSignatureModifiers.Internal;
            }
            return modifiers == MethodSignatureModifiers.Public || modifiers == (propertyModifiers & access)
                ? MethodSignatureModifiers.None : modifiers;
        }

        private static bool IsUsedByAnotherModel(ModelProvider model)
            => ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>()
                .Where(parent => parent != model)
                .Any(parent => parent.Properties.Concat(parent.CustomCodeView?.Properties ?? [])
                    .Any(property => property.Type.AreNamesEqual(model.Type)));

        private static bool HasPublicContractSetter(PropertyProvider property)
        {
            if (!IsPublicApi(property.Modifiers) || property.Modifiers.HasFlag(MethodSignatureModifiers.Static) || !property.Body.HasSetter ||
                HasInitOnlyContractSetter(property))
            {
                return false;
            }
            var modifiers = property.Body switch
            {
                AutoPropertyBody body => body.SetterModifiers,
                MethodPropertyBody body => body.SetterModifiers,
                _ => MethodSignatureModifiers.None
            };
            return modifiers == MethodSignatureModifiers.None || IsPublicApi(modifiers);
        }

        private static bool HasInitOnlyContractSetter(PropertyProvider property)
        {
            // MTG's public property-body API cannot emit init accessors. Do not silently replace one with a
            // public setter; an init-only contract needs a separate compatibility solution.
            return IsInitOnlySetter(property, ManagementClientGenerator.Instance.SourceInputModel.LastContract) == true;
        }

        private static bool? IsInitOnlySetter(PropertyProvider property, Compilation? compilation)
        {
            var type = property.EnclosingType.Type;
            var symbol = compilation?.GetTypeByMetadataName($"{type.Namespace}.{type.ClrMetadataName}");
            var properties = symbol?.GetMembers(property.Name).OfType<IPropertySymbol>().ToArray();
            return properties is { Length: 1 } && properties[0].SetMethod is { } setter ? setter.IsInitOnly : null;
        }

        private static bool IsPublicApi(MethodSignatureModifiers modifiers)
            => (modifiers.HasFlag(MethodSignatureModifiers.Public) || modifiers.HasFlag(MethodSignatureModifiers.Protected)) &&
                !modifiers.HasFlag(MethodSignatureModifiers.Private);

        private static string ResolveFlattenedAcronymPropertyName(
            ModelProvider model,
            PropertyProvider wrapper,
            PropertyProvider innerProperty,
            string currentName,
            IReadOnlyDictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap,
            IReadOnlyList<PropertyProvider> projectedSiblings,
            Func<string, string> buildHistoricalFlattenedName)
        {
            var matcher = ManagementClientGenerator.Instance.DateTimePropertyMatcher;
            var source = matcher.GetSourceProperty(innerProperty);
            var previousProperties = model.LastContractView?.Properties;
            var path = GetFlattenedWirePath(wrapper, innerProperty);
            if (source is null || previousProperties is null ||
                previousProperties.Any(p => p.Name == currentName && IsPublicApi(p.Modifiers) &&
                    !p.Modifiers.HasFlag(MethodSignatureModifiers.Static) &&
                    HasSameFlattenedType(p.Type, innerProperty.Type) &&
                    !ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, p) && HasCompatibleWirePath(p, path)))
            {
                return currentName;
            }

            var dateTimeName = !source.IsExactName && matcher.TryGetPreviousMpgDateTimePropertyName(innerProperty, out var historicalInnerName)
                ? buildHistoricalFlattenedName(BuildHistoricalDateTimeName(innerProperty, historicalInnerName)) : null;
            var candidates = previousProperties.Where(previous =>
                IsPublicApi(previous.Modifiers) &&
                !previous.Modifiers.HasFlag(MethodSignatureModifiers.Static) &&
                (IsAcronymNormalization(previous.Name, currentName) ||
                    dateTimeName is not null && IsAcronymNormalization(previous.Name, dateTimeName)) &&
                HasSameFlattenedType(previous.Type, innerProperty.Type) &&
                !ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, previous) &&
                RetainsExactContributors(previous.Name, currentName, wrapper, innerProperty, matcher) &&
                HasCompatibleWirePath(previous, path) &&
                !HasCompetingInputName(model, wrapper, innerProperty, source, previous.Name, matcher) &&
                !projectedSiblings.Any(p => !ReferenceEquals(p, innerProperty) && IsFlattenableProperty(p) && p.Name == previous.Name) &&
                !HasMemberNameCollision(model, previous.Name) &&
                model.CustomCodeView?.Properties.Any(p => p.Name == previous.Name || p.Name == currentName ||
                    p.OriginalName == currentName || p.OriginalName == previous.Name || p.OriginalName == source.Name) != true &&
                model.CustomCodeView?.Fields.Any(f => f.Name == previous.Name || f.Name == currentName ||
                    HasCustomMemberMapping(f.Attributes, currentName, previous.Name, source.Name)) != true &&
                !propertyMap.Values.SelectMany(v => v).Any(info => info.FlattenedProperty.Name == previous.Name))
                .ToArray();
            return candidates.Length == 1 ? candidates[0].Name : currentName;
        }

        private static string BuildHistoricalDateTimeName(PropertyProvider property, string historicalLeafName)
        {
            if (property is not FlattenedPropertyProvider flattened)
            {
                return historicalLeafName;
            }

            var innerName = BuildHistoricalDateTimeName(flattened.OriginalProperty, historicalLeafName);
            var explicitlyFlattened = flattened.EnclosingType is ModelProvider model &&
                ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var properties) &&
                properties.Any(p => p.Name == flattened.FlattenedProperty.Name);
            return explicitlyFlattened ? innerName :
                PropertyHelpers.GetCombinedPropertyName(flattened.OriginalProperty, flattened.FlattenedProperty, innerName);
        }

        private static bool RetainsExactContributors(string previousName, string currentName,
            PropertyProvider wrapper, PropertyProvider innerProperty, MtgDateTimePropertyMatcher matcher)
        {
            var source = matcher.GetSourceProperty(innerProperty);
            if (source?.IsExactName == true && !RetainsExactName(previousName, currentName, source.Name))
            {
                return false;
            }

            var currentWrapper = wrapper;
            var currentInner = innerProperty;
            while (true)
            {
                var wrapperSource = matcher.GetSourceProperty(currentWrapper);
                var wrapperType = wrapperSource?.Type is InputNullableType nullable ? nullable.Type : wrapperSource?.Type;
                var exactTypeName = currentWrapper.Name == "Properties" && wrapperType is InputModelType { IsExactName: true } inputModel
                    ? inputModel.Name.EndsWith("Properties", StringComparison.Ordinal)
                        ? inputModel.Name[..^"Properties".Length] : inputModel.Name
                    : null;
                // A wrapper named Properties contributes its model type name, not the wrapper's text.
                var exactWrapperName = wrapperSource?.IsExactName == true && currentWrapper.Name != "Properties"
                    ? wrapperSource.Name : null;
                var wrapperContributes = !IsExplicitlyFlattenedWrapper(currentWrapper) &&
                    PropertyHelpers.GetCombinedPropertyName(currentInner, currentWrapper) != currentInner.Name;
                if (wrapperContributes &&
                    (!RetainsExactName(previousName, currentName, exactWrapperName) ||
                     !RetainsExactName(previousName, currentName, exactTypeName)))
                {
                    return false;
                }
                if (currentInner is not FlattenedPropertyProvider flattened)
                {
                    return true;
                }
                currentWrapper = flattened.FlattenedProperty;
                currentInner = flattened.OriginalProperty;
            }
        }

        private static bool HasCompetingInputName(ModelProvider model, PropertyProvider wrapper, PropertyProvider innerProperty,
            InputProperty source, string previousName, MtgDateTimePropertyMatcher matcher)
        {
            static bool ClaimsName(InputProperty property, InputProperty source, string name)
            {
                if (ReferenceEquals(property, source))
                {
                    return false;
                }
                var identifier = property.IsExactName ? property.Name : property.Name.ToIdentifierName();
                if (string.IsNullOrEmpty(identifier) || identifier.Length > name.Length)
                {
                    return false;
                }
                var suffix = name[^identifier.Length..];
                // A safe-flattened sibling may prepend a wrapper name to its leaf. Conservatively reserve
                // both its input spelling and its canonical acronym spelling, even if it is visited later.
                return suffix == identifier || !property.IsExactName && IsAcronymNormalization(identifier, suffix);
            }

            // Only effective public siblings can claim a direct projection. Raw input siblings may have
            // been replaced by private custom members and must not reserve a public name.
            var leaf = innerProperty;
            while (leaf is FlattenedPropertyProvider flattened)
            {
                leaf = flattened.OriginalProperty;
            }
            var leafOwner = leaf.EnclosingType as ModelProvider;
            if (leafOwner is null)
            {
                TryGetModelProvider(leaf.EnclosingType.Type, out leafOwner);
            }
            if (leafOwner is null || HasBaseModelCycle(leafOwner))
            {
                return true;
            }
            if (PropertyHelpers.GetAllProperties(leafOwner).Any(p => IsFlattenableProperty(p) && p.Name == previousName &&
                !ReferenceEquals(matcher.GetSourceProperty(p), source)))
            {
                return true;
            }

            var visited = new HashSet<ModelProvider>(ReferenceEqualityComparer.Instance);
            bool CanProject(ModelProvider owner, PropertyProvider candidate, ModelProvider nested)
            {
                if (ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(owner, out var mappings) &&
                    mappings.Any(p => p.Name == candidate.Name))
                {
                    return true;
                }
                if (ShouldPreserveLastContractProperty(owner, candidate))
                {
                    return false;
                }
                if (HasBaseModelCycle(nested))
                {
                    return true;
                }
                var nestedProperties = PropertyHelpers.GetAllProperties(nested);
                return CanSafeFlatten(owner, candidate, nested, nestedProperties) ||
                    !HasMultipleGuaranteedEffectiveProperties(nested, nestedProperties);
            }

            bool Search(ModelProvider current)
            {
                if (!visited.Add(current))
                {
                    return false;
                }
                if (HasBaseModelCycle(current))
                {
                    return true;
                }
                foreach (var property in PropertyHelpers.GetAllProperties(current).Where(IsFlattenableProperty))
                {
                    var input = matcher.GetSourceProperty(property);
                    if (property.Name == previousName || input is not null && ClaimsName(input, source, previousName))
                    {
                        return true;
                    }
                    if (TryGetModelProvider(property.Type, out var nested) && CanProject(current, property, nested) && Search(nested))
                    {
                        return true;
                    }
                }
                return false;
            }

            foreach (var otherWrapper in model.Properties.Concat(model.CustomCodeView?.Properties ?? [])
                .Where(p => !ReferenceEquals(p, wrapper)))
            {
                if (!TryGetModelProvider(otherWrapper.Type, out var otherModel) || !CanProject(model, otherWrapper, otherModel))
                {
                    continue;
                }
                var explicitFlatten = ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var mappings) &&
                    mappings.Any(p => p.Name == otherWrapper.Name);
                if (!explicitFlatten && !HasBaseModelCycle(otherModel))
                {
                    var otherProperties = PropertyHelpers.GetAllProperties(otherModel);
                    var leaves = otherProperties.Where(IsFlattenableProperty).ToArray();
                    if (CanSafeFlatten(model, otherWrapper, otherModel, otherProperties) && leaves.Length == 1 &&
                        !TryGetModelProvider(leaves[0].Type, out _))
                    {
                        var actualName = PropertyHelpers.GetCombinedPropertyName(leaves[0], otherWrapper);
                        var historicalName = matcher.TryGetPreviousMpgDateTimePropertyName(leaves[0], out var historicalLeaf)
                            ? PropertyHelpers.GetCombinedPropertyName(leaves[0], otherWrapper, historicalLeaf) : null;
                        if (actualName != previousName && !IsAcronymNormalization(previousName, actualName) &&
                            (historicalName is null || historicalName != previousName && !IsAcronymNormalization(previousName, historicalName)))
                        {
                            continue;
                        }
                    }
                }
                if (Search(otherModel))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasMultipleGuaranteedEffectiveProperties(ModelProvider model, IReadOnlyList<PropertyProvider> properties)
        {
            var flattenedWrappers = properties.OfType<FlattenedPropertyProvider>().Select(p => p.FlattenedProperty).ToHashSet();
            ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var explicitProperties);
            return properties.Count(p => IsEffectiveModelProperty(p) && !flattenedWrappers.Contains(p) &&
                explicitProperties?.Any(item => item.Name == p.Name) != true) >= 2;
        }

        private static bool HasBaseModelCycle(ModelProvider model)
        {
            var visited = new HashSet<ModelProvider>(ReferenceEqualityComparer.Instance);
            for (ModelProvider? current = model; current is not null; current = current.BaseModelProvider)
            {
                if (!visited.Add(current))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasMemberNameCollision(ModelProvider model, string name)
        {
            var visited = new HashSet<ModelProvider>(ReferenceEqualityComparer.Instance);
            for (ModelProvider? current = model; current is not null; current = current.BaseModelProvider)
            {
                if (!visited.Add(current))
                {
                    return true;
                }
                if (current.Properties.Any(p => p.Name == name) || current.Fields.Any(f => f.Name == name) ||
                    current.Methods.Any(m => m.Signature.Name == name) ||
                    current.CustomCodeView?.Properties.Any(p => p.Name == name) == true ||
                    current.CustomCodeView?.Fields.Any(f => f.Name == name) == true ||
                    current.CustomCodeView?.Methods.Any(m => m.Signature.Name == name) == true ||
                    HasCustomNestedTypeOrEvent(current, name))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasCustomNestedTypeOrEvent(ModelProvider model, string name)
        {
            var view = model.CustomCodeView;
            var compilation = ManagementClientGenerator.Instance.SourceInputModel.Customization;
            if (view is null || compilation is null)
            {
                return false;
            }
            var type = view.Type;
            var symbol = compilation.Assembly.GetTypeByMetadataName($"{type.Namespace}.{type.ClrMetadataName}");
            return symbol?.GetMembers(name).Any(member => member is INamedTypeSymbol or IEventSymbol) == true;
        }

        private static bool IsExplicitlyFlattenedWrapper(PropertyProvider wrapper)
        {
            var owner = wrapper.EnclosingType as ModelProvider;
            if (owner is null && !TryGetModelProvider(wrapper.EnclosingType.Type, out owner))
            {
                return false;
            }
            return ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(owner, out var properties) &&
                properties.Any(p => p.Name == wrapper.Name);
        }

        private static bool RetainsExactName(string previousName, string currentName, string? exactName)
        {
            if (string.IsNullOrEmpty(exactName))
            {
                return true;
            }
            var retainedName = exactName;
            var index = currentName.IndexOf(retainedName, StringComparison.Ordinal);
            if (index < 0)
            {
                // Safe flattening can remove a wrapper's conventional suffix before composing the name.
                // Protect the part that remains; if it cannot be identified, do not guess.
                foreach (var suffix in new[] { "Profile", "Policy", "Configuration", "Properties", "Settings" })
                {
                    if (exactName.Length > suffix.Length && exactName.EndsWith(suffix, StringComparison.Ordinal))
                    {
                        retainedName = exactName[..^suffix.Length];
                        index = currentName.IndexOf(retainedName, StringComparison.Ordinal);
                        break;
                    }
                }
                if (index < 0)
                {
                    return false;
                }
            }
            // When the same token occurs in several contributors, its exact origin cannot be determined
            // from the composed name alone. Fail closed if any occurrence would change.
            while (index >= 0)
            {
                if (index + retainedName.Length > previousName.Length ||
                    !previousName.AsSpan(index, retainedName.Length).SequenceEqual(retainedName))
                {
                    return false;
                }
                index = currentName.IndexOf(retainedName, index + 1, StringComparison.Ordinal);
            }
            return true;
        }

        private static bool HasCustomMemberMapping(IReadOnlyList<AttributeStatement> attributes, params string[] names)
        {
            foreach (var attribute in attributes)
            {
                try
                {
                    if (attribute.Type.Name == "CodeGenMemberAttribute" &&
                        (attribute.Arguments.Count != 1 || attribute.Arguments[0] is not LiteralExpression { Literal: string originalName } ||
                         names.Contains(originalName, StringComparer.Ordinal)))
                    {
                        return true;
                    }
                }
                catch
                {
                    // An unresolved customization cannot safely be assumed not to claim the name.
                    return true;
                }
            }
            return false;
        }

        private static string? GetFlattenedWirePath(PropertyProvider wrapper, PropertyProvider innerProperty)
        {
            if (wrapper.WireInfo is null)
            {
                return null;
            }

            var segments = new List<string> { wrapper.WireInfo.SerializedName };
            var current = innerProperty;
            while (current is FlattenedPropertyProvider flattened)
            {
                if (flattened.FlattenedProperty.WireInfo is null)
                {
                    return null;
                }
                segments.Add(flattened.FlattenedProperty.WireInfo.SerializedName);
                current = flattened.OriginalProperty;
            }
            if (current.WireInfo is null)
            {
                return null;
            }
            segments.Add(current.WireInfo.SerializedName);
            // WirePath joins unescaped segments with dots; a literal dot makes the path ambiguous.
            return segments.Any(segment => segment.Contains('.', StringComparison.Ordinal)) ? null : string.Join('.', segments);
        }

        private static bool HasCompatibleWirePath(PropertyProvider previous, string? currentPath)
        {
            var hasPath = false;
            foreach (var attribute in previous.Attributes)
            {
                try
                {
                    var name = attribute.Type.Name;
                    if (name == "ExperimentalAttribute")
                    {
                        return false;
                    }
                    if (name != "WirePathAttribute")
                    {
                        continue;
                    }
                    if (hasPath || currentPath is null || attribute.Arguments.Count != 1 ||
                        attribute.Arguments[0] is not LiteralExpression { Literal: string previousPath } ||
                        previousPath != currentPath)
                    {
                        return false;
                    }
                    hasPath = true;
                }
                catch
                {
                    // Do not guess identity when baseline attribute metadata cannot be resolved.
                    return false;
                }
            }
            return true;
        }

        // Match MTG's property acronym rules, not arbitrary case-insensitive names. Keep this list in sync
        // with MTG's CSharpNameExtensions; the comparison tests exercise the actual MTG property naming path.
        private static readonly (string Source, string Replacement)[] AcronymRules =
        [
            ("Ipv4", "IPv4"), ("Ipv6", "IPv6"), ("IpV4", "IPv4"), ("IpV6", "IPv6"),
            ("Ip", "IP"), ("Db", "DB"), ("Os", "OS")
        ];

        private static bool IsAcronymNormalization(string previous, string current)
        {
            if (previous.Length != current.Length)
            {
                return false;
            }

            var changed = false;
            for (var i = 0; i < previous.Length;)
            {
                var matched = false;
                foreach (var (source, replacement) in AcronymRules)
                {
                    var end = i + source.Length;
                    if (end > previous.Length || !previous.AsSpan(i).StartsWith(source, StringComparison.Ordinal) ||
                        (end < previous.Length && !char.IsUpper(previous[end])))
                    {
                        continue;
                    }
                    var currentPart = current.AsSpan(i, source.Length);
                    if (!currentPart.SequenceEqual(source) && !currentPart.SequenceEqual(replacement))
                    {
                        return false;
                    }
                    changed |= !currentPart.SequenceEqual(source);
                    i = end;
                    matched = true;
                    break;
                }
                if (!matched && previous[i] != current[i])
                {
                    return false;
                }
                if (!matched)
                {
                    i++;
                }
            }
            return changed;
        }

        private static string ResolveFlattenedDateTimePropertyName(
            ModelProvider model,
            PropertyProvider wrapper,
            PropertyProvider innerProperty,
            string currentName,
            IReadOnlyDictionary<PropertyProvider, List<FlattenPropertyInfo>> propertyMap,
            IReadOnlyList<PropertyProvider> projectedSiblings,
            Func<string, string> buildHistoricalFlattenedName)
        {
            var lastContractProperties = model.LastContractView?.Properties;
            if (lastContractProperties is null ||
                lastContractProperties.Any(p =>
                    p.Name == currentName &&
                    p.Type.HasSamePublicType(innerProperty.Type, ignoreNullable: true)))
            {
                return currentName;
            }

            var matcher = ManagementClientGenerator.Instance.DateTimePropertyMatcher;
            if (!matcher.TryGetPreviousMpgDateTimePropertyName(innerProperty, out var historicalInnerName))
            {
                return currentName;
            }

            var historicalName = buildHistoricalFlattenedName(historicalInnerName);
            var previousProperty = lastContractProperties.FirstOrDefault(p =>
                p.Name == historicalName &&
                p.Type.HasSamePublicType(innerProperty.Type, ignoreNullable: true));
            if (previousProperty is null ||
                model.Properties.Any(p => p.Name == historicalName) ||
                model.CustomCodeView?.Properties.Any(p => p.Name == historicalName) == true ||
                propertyMap.Values.SelectMany(v => v).Any(info => info.FlattenedProperty.Name == historicalName))
            {
                return currentName;
            }

            // Identifier normalization adds matches that the previous date-time matcher did not handle.
            // Apply the same identity and ownership safeguards as acronym recovery to those new matches,
            // without changing the existing behavior for previously recognized date-time names.
            if (!matcher.WasMtgRenamedDateTimePropertyBeforeIdentifierNormalization(innerProperty))
            {
                var source = matcher.GetSourceProperty(innerProperty);
                var path = GetFlattenedWirePath(wrapper, innerProperty);
                if (source is null || !IsPublicApi(previousProperty.Modifiers) ||
                    previousProperty.Modifiers.HasFlag(MethodSignatureModifiers.Static) ||
                    ModelCompatibilityValidator.IsPropertyRemovalAccepted(model, previousProperty) ||
                    !HasCompatibleWirePath(previousProperty, path) ||
                    !RetainsExactContributors(previousProperty.Name, currentName, wrapper, innerProperty, matcher) ||
                    HasMemberNameCollision(model, previousProperty.Name) ||
                    HasCompetingInputName(model, wrapper, innerProperty, source, previousProperty.Name, matcher) ||
                    projectedSiblings.Any(p => !ReferenceEquals(p, innerProperty) && IsFlattenableProperty(p) && p.Name == previousProperty.Name) ||
                    model.CustomCodeView?.Properties.Any(p => p.Name == currentName || p.OriginalName == currentName ||
                        p.OriginalName == previousProperty.Name || p.OriginalName == source.Name) == true ||
                    model.CustomCodeView?.Fields.Any(f => f.Name == currentName ||
                        HasCustomMemberMapping(f.Attributes, currentName, previousProperty.Name, source.Name)) == true)
                {
                    return currentName;
                }
            }
            return previousProperty.Name;
        }

        private bool IsFlattenedIntoParentWithLastContractSetter(
            ModelProvider model, string propertyName, PropertyProvider wrapper, PropertyProvider innerProperty)
        {
            var cacheKey = new FlattenedSetterCacheKey(model.Type.Namespace, model.Type.Name, propertyName, wrapper, innerProperty);
            if (_flattenedIntoParentWithLastContractSetterCache.TryGetValue(cacheKey, out var result))
            {
                return result;
            }

            // Explicit flattening retains the child name and safe flattening can only prepend a wrapper
            // name. If no compatible GA setter can possibly match that suffix, avoid enumerating every
            // path through a shared parent graph. This is only a necessary-condition filter; path and
            // exact-name checks still run for each surviving route.
            var matcher = ManagementClientGenerator.Instance.DateTimePropertyMatcher;
            var source = matcher.GetSourceProperty(innerProperty);
            string? historicalName = null;
            if (source is { IsExactName: false } && matcher.TryGetPreviousMpgDateTimePropertyName(innerProperty, out var historicalLeafName))
            {
                var innerName = BuildHistoricalDateTimeName(innerProperty, historicalLeafName);
                var explicitFlatten = ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(model, out var mappings) &&
                    mappings.Any(p => p.Name == wrapper.Name);
                historicalName = explicitFlatten ? innerName : PropertyHelpers.GetCombinedPropertyName(innerProperty, wrapper, innerName);
            }
            var initialPath = GetFlattenedWirePath(wrapper, innerProperty);
            var hasPossibleSetter = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>()
                .Any(parent => parent.LastContractView?.Properties.Any(previous =>
                    HasPublicContractSetter(previous) && HasSameFlattenedType(previous.Type, innerProperty.Type) &&
                    !ModelCompatibilityValidator.IsPropertyRemovalAccepted(parent, previous) &&
                    (CouldMatchAncestorName(previous.Name, propertyName) ||
                        historicalName is not null && CouldMatchAncestorName(previous.Name, historicalName)) &&
                    CouldMatchAncestorWirePath(previous, initialPath)) == true);
            if (!hasPossibleSetter)
            {
                _flattenedIntoParentWithLastContractSetterCache[cacheKey] = false;
                return false;
            }

            var wrappers = new List<PropertyProvider> { wrapper };
            var visiting = new HashSet<ModelProvider>();

            bool CanProjectSingleSource(ModelProvider current, HashSet<ModelProvider> visited)
            {
                if (source is null || !visited.Add(current))
                {
                    return false;
                }
                var properties = PropertyHelpers.GetAllProperties(current);
                var flattenedWrappers = properties.OfType<FlattenedPropertyProvider>().Select(p => p.FlattenedProperty).ToHashSet();
                var effective = properties.Where(p => IsEffectiveModelProperty(p) && !flattenedWrappers.Contains(p)).ToArray();
                if (effective.Length != 1 || !IsFlattenableProperty(effective[0]))
                {
                    return false;
                }
                var property = effective[0];
                if (ReferenceEquals(matcher.GetSourceProperty(property), source))
                {
                    return true;
                }
                if (!TryGetModelProvider(property.Type, out var nested))
                {
                    return false;
                }
                var explicitFlatten = ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(current, out var mappings) &&
                    mappings.Any(p => p.Name == property.Name);
                return (explicitFlatten || CanSafeFlatten(current, property, nested, PropertyHelpers.GetAllProperties(nested))) &&
                    CanProjectSingleSource(nested, visited);
            }

            bool HasParentSetter(ModelProvider child, string childName, string? historicalChildName, string? childPath)
            {
                if (!visiting.Add(child))
                {
                    return false;
                }
                try
                {
                    foreach (var parent in ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>())
                    {
                        if (parent == child || visiting.Contains(parent))
                        {
                            continue;
                        }

                        foreach (var parentWrapper in parent.Properties.Concat(parent.CustomCodeView?.Properties ?? [])
                            .Where(p => p.Type.AreNamesEqual(child.Type)))
                        {
                            var explicitFlatten = ManagementClientGenerator.Instance.OutputLibrary.OutputFlattenPropertyMap.TryGetValue(parent, out var mappings) &&
                                mappings.Any(p => p.Name == parentWrapper.Name);
                            if (!explicitFlatten && (!CanSafeFlatten(parent, parentWrapper, child, PropertyHelpers.GetAllProperties(child)) ||
                                !CanProjectSingleSource(child, [])))
                            {
                                continue;
                            }
                            var projectedName = explicitFlatten ? childName :
                                PropertyHelpers.GetCombinedPropertyName(innerProperty, parentWrapper, childName);
                            var historicalProjectedName = historicalChildName is null ? null : explicitFlatten ? historicalChildName :
                                PropertyHelpers.GetCombinedPropertyName(innerProperty, parentWrapper, historicalChildName);
                            if (HasCustomSetter(parent, projectedName))
                            {
                                continue;
                            }
                            var prefix = parentWrapper.WireInfo?.SerializedName;
                            var path = prefix is null || prefix.Contains('.', StringComparison.Ordinal) || childPath is null
                                ? null : $"{prefix}.{childPath}";
                            wrappers.Add(parentWrapper);
                            try
                            {
                                if (ShouldPreserveLastContractSetter(parent, projectedName, innerProperty.Type, path))
                                {
                                    return true;
                                }
                                if (source is not null && parent.LastContractView is { } contract)
                                {
                                    var candidates = contract.Properties.Where(previous =>
                                        HasPublicContractSetter(previous) &&
                                        (IsAcronymNormalization(previous.Name, projectedName) || historicalProjectedName is not null &&
                                            (previous.Name == historicalProjectedName || IsAcronymNormalization(previous.Name, historicalProjectedName))) &&
                                        HasSameFlattenedType(previous.Type, innerProperty.Type) &&
                                        !ModelCompatibilityValidator.IsPropertyRemovalAccepted(parent, previous) &&
                                        wrappers.All(w => RetainsExactContributors(previous.Name, projectedName, w, innerProperty, matcher)) &&
                                        HasCompatibleWirePath(previous, path) && !HasCustomSetter(parent, previous.Name) &&
                                        !HasMemberNameCollision(parent, previous.Name) &&
                                        !HasCompetingInputName(parent, parentWrapper, innerProperty, source, previous.Name, matcher))
                                        .ToArray();
                                    if (candidates.Length == 1)
                                    {
                                        return true;
                                    }
                                }
                                if (HasParentSetter(parent, projectedName, historicalProjectedName, path))
                                {
                                    return true;
                                }
                            }
                            finally
                            {
                                wrappers.RemoveAt(wrappers.Count - 1);
                            }
                        }
                    }
                    return false;
                }
                finally
                {
                    visiting.Remove(child);
                }
            }

            result = HasParentSetter(model, propertyName, historicalName, initialPath);
            _flattenedIntoParentWithLastContractSetterCache[cacheKey] = result;
            return result;
        }

        private static bool CouldMatchAncestorName(string previousName, string childName)
        {
            if (previousName.Length < childName.Length)
            {
                return false;
            }
            var suffix = previousName[^childName.Length..];
            return suffix == childName || IsAcronymNormalization(suffix, childName);
        }

        private static bool CouldMatchAncestorWirePath(PropertyProvider previous, string? childPath)
        {
            foreach (var attribute in previous.Attributes)
            {
                try
                {
                    if (attribute.Type.Name == "WirePathAttribute" && attribute.Arguments.Count == 1 &&
                        attribute.Arguments[0] is LiteralExpression { Literal: string previousPath })
                    {
                        return childPath is not null && (previousPath == childPath ||
                            previousPath.EndsWith($".{childPath}", StringComparison.Ordinal));
                    }
                }
                catch
                {
                    // Unknown metadata cannot prove that a route is impossible.
                    return true;
                }
            }
            return true;
        }

        private sealed record FlattenedSetterCacheKey(
            string? Namespace, string Name, string PropertyName, PropertyProvider Wrapper, PropertyProvider InnerProperty);

        private static bool HasCustomSetter(ModelProvider model, string propertyName)
            => model.CustomCodeView?.Properties.Any(p => p.Name == propertyName && p.Body.HasSetter) == true;

        private static void EnsureFlattenedWrapperSetter(ModelProvider model, PropertyProvider wrapper, bool shouldEmitSetter)
        {
            if (shouldEmitSetter && wrapper.Body is AutoPropertyBody { HasSetter: false } wrapperBody &&
                model.CustomCodeView?.Properties.Any(p => p.Name == wrapper.Name) != true)
            {
                // The internalized wrapper must be assignable so the historical setter can lazily
                // reconstruct it after deserialization as well as after public construction.
                wrapper.Update(body: wrapperBody with { HasSetter = true, SetterModifiers = MethodSignatureModifiers.None });
            }
        }

        private static PropertyProvider? FindCustomProperty(PropertyProvider property)
        {
            var custom = property.EnclosingType.CustomCodeView?.Properties;
            if (TryGetModelProvider(property.EnclosingType.Type, out var model))
            {
                custom = model.CustomCodeView?.Properties ?? custom;
            }
            return custom?.FirstOrDefault(p => ReferenceEquals(p, property) || p.Name == property.Name || p.OriginalName == property.Name);
        }

        private static bool HasAccessibleSingleValueConstructor(ModelProvider model, CSharpType valueType)
        {
            // External model providers describe input projections, not the constructors of the referenced type.
            if (model is SystemObjectModelProvider)
            {
                return PropertyHelpers.HasAccessibleExternalValueConstructor(model, valueType);
            }
            var applicable = model.CanonicalView.Constructors.Concat(model.SerializationProviders.SelectMany(p => p.Constructors))
                .Where(c => c.Signature.Parameters.Count > 0 &&
                !c.Signature.Parameters[0].IsRef && !c.Signature.Parameters[0].IsOut &&
                !c.Signature.Parameters[0].IsIn && !c.Signature.Parameters[0].IsParams &&
                c.Signature.Parameters.Skip(1).All(p => p.DefaultValue is not null || p.IsParams)).ToArray();
            // An exact one-argument overload wins over a collection conversion. Check that specific
            // overload even if it is inaccessible or lacks SetsRequiredMembers; a different callable
            // overload is not evidence that the emitted uncast new T(value) will choose it.
            var exact = applicable.Where(c => HasSameFlattenedType(c.Signature.Parameters[0].Type, valueType)).ToArray();
            ConstructorProvider? selected;
            if (exact.Length > 0)
            {
                var singleArgument = exact.Where(c => c.Signature.Parameters.Count == 1).ToArray();
                selected = singleArgument.Length == 1 ? singleArgument[0] : null;
            }
            else
            {
                // IList<T> and related list interfaces convert to IEnumerable<T>. If another
                // one-argument-compatible overload exists, its overload priority is uncertain.
                selected = applicable.Length == 1 && applicable[0].Signature.Parameters.Count == 1 &&
                    applicable[0].Signature.Parameters[0].Type.IsFrameworkType &&
                    applicable[0].Signature.Parameters[0].Type.FrameworkType == typeof(IEnumerable<>) &&
                    valueType.IsList && !valueType.IsReadOnlyMemory &&
                    applicable[0].Signature.Parameters[0].Type.Arguments.Count == 1 && valueType.Arguments.Count == 1 &&
                    HasSameFlattenedType(applicable[0].Signature.Parameters[0].Type.Arguments[0], valueType.Arguments[0])
                    ? applicable[0] : null;
            }
            return selected is not null &&
                (!valueType.IsValueType || !valueType.IsNullable || selected.Signature.Parameters[0].Type.IsNullable) &&
                !selected.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Private) &&
                (selected.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) ||
                 selected.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) && model is not SystemObjectModelProvider) &&
                PropertyHelpers.CanConstructWithoutUnsatisfiedRequiredMembers(model, selected);
        }

        private static bool HasSameFlattenedType(CSharpType first, CSharpType second)
        {
            if (!first.HasSamePublicType(second, ignoreNullable: true))
            {
                return false;
            }
            if (first.IsArray || second.IsArray)
            {
                return first.IsArray && second.IsArray && first.AreNamesEqual(second) &&
                    HasSameFlattenedType(first.ElementType, second.ElementType);
            }
            if (first.DeclaringType is null != (second.DeclaringType is null) ||
                first.DeclaringType is not null && second.DeclaringType is not null &&
                    !HasSameFlattenedType(first.DeclaringType, second.DeclaringType))
            {
                return false;
            }
            return first.Arguments.Zip(second.Arguments).All(p => HasSameFlattenedType(p.First, p.Second));
        }

        private static bool CanAssignWrapper(ModelProvider owner, PropertyProvider wrapper)
        {
            var custom = FindCustomProperty(wrapper);
            var actual = custom ?? wrapper;
            if (actual.EnclosingType.Type.AreNamesEqual(owner.Type) && actual.Body.HasSetter)
            {
                // A wrapper is accessed from its own partial class, where private/protected setters are
                // callable. Init-only custom setters are still unavailable from ordinary methods.
                return custom is null || IsInitOnlySetter(custom, ManagementClientGenerator.Instance.SourceInputModel.Customization) == false;
            }
            return CanAssignProperty(wrapper);
        }

        private static bool CanAssignProperty(PropertyProvider property)
        {
            if (property.EnclosingType is SystemObjectModelProvider external)
            {
                var symbol = PropertyHelpers.GetExternalTypeSymbol(external.Type);
                for (var current = symbol; current is not null; current = current.BaseType)
                {
                    var members = current.GetMembers(property.Name);
                    if (members.Length > 0)
                    {
                        return members.Length == 1 && members[0] is IPropertySymbol
                        {
                            IsStatic: false,
                            DeclaredAccessibility: Accessibility.Public,
                            SetMethod: { IsInitOnly: false, DeclaredAccessibility: Accessibility.Public }
                        };
                    }
                }
                return false;
            }
            var custom = FindCustomProperty(property);
            if (custom is not null &&
                (!custom.Body.HasSetter || IsInitOnlySetter(custom, ManagementClientGenerator.Instance.SourceInputModel.Customization) != false))
            {
                return false;
            }
            var actual = custom ?? property;
            if (!actual.Body.HasSetter)
            {
                // A generated auto-property can receive an internal delegation setter when needed.
                return custom is null;
            }
            var modifiers = actual.Body switch
            {
                AutoPropertyBody body => body.SetterModifiers,
                MethodPropertyBody body => body.SetterModifiers,
                _ => MethodSignatureModifiers.None
            };
            return !modifiers.HasFlag(MethodSignatureModifiers.Private) &&
                (!modifiers.HasFlag(MethodSignatureModifiers.Protected) || modifiers.HasFlag(MethodSignatureModifiers.Internal));
        }

        private bool HasDelegationOnlyScalarSetter(PropertyProvider property)
        {
            if (property.Type.IsCollection)
            {
                return false;
            }
            var matcher = ManagementClientGenerator.Instance.DateTimePropertyMatcher;
            var source = matcher.GetSourceProperty(property);
            if (source is not null && _requiredScalarSetterSources.Contains(source))
            {
                return true;
            }
            for (var current = property; ;)
            {
                if (_requiredScalarLeafSetters.Contains(current))
                {
                    return true;
                }
                if (current is not FlattenedPropertyProvider flattened)
                {
                    return false;
                }
                current = flattened.OriginalProperty;
            }
        }

        private void EnsureScalarLeafSetter(PropertyProvider property, bool shouldEmitSetter)
        {
            if (shouldEmitSetter && !property.Type.IsCollection && property.Body is AutoPropertyBody { HasSetter: false } body &&
                FindCustomProperty(property) is null)
            {
                _requiredScalarLeafSetters.Add(property);
                var source = ManagementClientGenerator.Instance.DateTimePropertyMatcher.GetSourceProperty(property);
                if (source is not null)
                {
                    _requiredScalarSetterSources.Add(source);
                }
                property.Update(body: body with { HasSetter = true, SetterModifiers = MethodSignatureModifiers.Internal });
            }
        }

        private void UpdateFlattenTypeCollectionProperty(PropertyProvider internalProperty, PropertyProvider innerProperty, ModelProvider modelProvider, bool allowSetter = false)
        {
            // Skip updating the body if the inner property is a flattened property from safe-flatten
            // These properties need a custom getter that wires to the backing object, not initialization
            if (innerProperty is FlattenedPropertyProvider || FindCustomProperty(innerProperty) is not null)
            {
                return;
            }

            if (innerProperty.Type.IsCollection)
            {
                // The same input property can be projected by several owners. Once a GA setter requires
                // delegation through this property, a later projection must not remove that internal setter.
                if (allowSetter)
                {
                    _requiredCollectionSetters.Add(innerProperty);
                }
                allowSetter = _requiredCollectionSetters.Contains(innerProperty);
                // add initialization for collection type property
                if (innerProperty.Type.IsList)
                {
                    innerProperty.Update(body: new AutoPropertyBody(allowSetter, allowSetter ? MethodSignatureModifiers.Internal : MethodSignatureModifiers.None,
                        InitializationExpression: New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(innerProperty.Type.Arguments))));
                }
                else if (innerProperty.Type.IsDictionary)
                {
                    innerProperty.Update(body: new AutoPropertyBody(allowSetter, allowSetter ? MethodSignatureModifiers.Internal : MethodSignatureModifiers.None,
                        InitializationExpression: New.Instance(ManagementClientGenerator.Instance.TypeFactory.DictionaryInitializationType.MakeGenericType(innerProperty.Type.Arguments))));
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
                if (updateParameters.Count == 0)
                {
                    // All flattened parameters were optional — the public constructor becomes
                    // parameterless. This is valid: users create the object and set optional
                    // properties via setters. Update the signature to remove the old parameters.
                    publicConstructor.Signature.Update(parameters: updateParameters);
                    publicConstructor.Update(signature: publicConstructor.Signature);

                    // The serialization type may have already added an internal parameterless
                    // constructor (for deserialization) before this visitor ran. Now that the
                    // model has a public parameterless constructor, the internal one is redundant
                    // and would cause CS0111. Remove it.
                    RemoveDuplicateSerializationConstructor(model);
                }
                else
                {
                    publicConstructor.Signature.Update(parameters: updateParameters);
                    publicConstructor.Update(signature: publicConstructor.Signature); // workaround to update the xml docs
                }

                // If this constructor delegates to a base constructor, update the base initializer
                // arguments to reference the new flattened parameters instead of the old ones.
                UpdatePublicConstructorBaseInitializer(publicConstructor, map);
            }
        }

        /// <summary>
        /// Updates the base constructor initializer arguments when the base model's public
        /// constructor signature was changed by property flattening. Replaces each argument
        /// that corresponded to a now-flattened parameter with the new flattened parameter.
        /// </summary>
        private static void UpdatePublicConstructorBaseInitializer(ConstructorProvider publicConstructor, Dictionary<string, List<FlattenPropertyInfo>> map)
        {
            var sig = publicConstructor.Signature;
            var initializer = sig.Initializer;
            if (initializer is null || !initializer.IsBase)
            {
                return;
            }

            var updatedArgs = new List<ValueExpression>();
            var changed = false;
            foreach (var arg in initializer.Arguments)
            {
                if (arg is VariableExpression variable && map.TryGetValue(variable.Declaration.RequestedName, out var flattenInfoList))
                {
                    changed = true;
                    foreach (var (flattenedProperty, _) in flattenInfoList)
                    {
                        if (ShouldIncludeFlattenedPropertyInPublicConstructor(flattenedProperty))
                        {
                            updatedArgs.Add(flattenedProperty.AsParameter);
                        }
                    }
                }
                else
                {
                    updatedArgs.Add(arg);
                }
            }

            if (changed)
            {
                var newInitializer = new ConstructorInitializer(initializer.IsBase, updatedArgs);
                var newSig = new ConstructorSignature(sig.Type, sig.Description, sig.Modifiers, sig.Parameters, sig.Attributes, newInitializer);
                publicConstructor.Update(signature: newSig);
            }
        }

        private static bool ShouldIncludeFlattenedPropertyInPublicConstructor(PropertyProvider flattenedProperty)
        {
            // We only include the flattened property in the public constructor if it is required
            return flattenedProperty.WireInfo?.IsRequired == true;
        }

        /// <summary>
        /// Removes the internal parameterless constructor from the serialization type if one exists.
        /// The serialization type adds an internal parameterless constructor for deserialization
        /// before the flatten visitor runs. When flattening makes the model's public constructor
        /// parameterless, the serialization constructor becomes a duplicate and must be removed.
        /// </summary>
        private static void RemoveDuplicateSerializationConstructor(ModelProvider model)
        {
            foreach (var serializationType in model.SerializationProviders)
            {
                var ctors = serializationType.Constructors;
                var parameterlessCtor = ctors.SingleOrDefault(c => !c.Signature.Parameters.Any());
                if (parameterlessCtor is not null)
                {
                    var updatedCtors = ctors.Where(c => c != parameterlessCtor).ToList();
                    serializationType.Update(constructors: updatedCtors);
                }
            }
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

                            // Construct the nested flattened property model and assign it to the internal property.
                            // When the nested model has a public constructor, use its parameters to match
                            // flattened properties by name; otherwise fall back to FullConstructor for
                            // Output-only models that only have internal constructors.
                            if (currentInternalProperty is not null)
                            {
                                var properties = value.Where(x => flattenedProperties.Contains(x.FlattenedProperty)).ToList();
                                bool nestedHasPublicCtor = false;
                                if (TryGetModelProvider(variable.Type, out var nestedModelType))
                                {
                                    nestedHasPublicCtor = nestedModelType.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
                                }
                                var conditionExpression = BuildConditionExpression(properties, publicConstructor: nestedHasPublicCtor);
                                var ctorParams = BuildConstructorParameters(variable.Type, properties, publicConstructor: nestedHasPublicCtor);
                                if (ctorParams is not null)
                                {
                                    var instanceExpression = New.Instance(variable.Type, ctorParams);
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
                                else
                                {
                                    // Type not found in CSharpTypeMap; emit a safe assignment that does not reference the original parameter
                                    updatedBodyStatements.Add(((MemberExpression)currentInternalProperty).Assign(Default).Terminate());
                                }
                            }
                            else
                            {
                                // No required leaves remain to initialize this wrapper in the public
                                // constructor. A required getter-only collection wrapper must still
                                // be usable, so initialize it inline without changing optional wrappers.
                                foreach (var internalProperty in value.Where(x => x.FlattenedProperty.Type.IsCollection)
                                    .Select(x => x.InternalProperty).Distinct())
                                {
                                    if (internalProperty.WireInfo?.IsRequired == true
                                        && internalProperty.Body is AutoPropertyBody { HasSetter: false, InitializationExpression: null } autoBody
                                        && TryGetModelProvider(internalProperty.Type, out var nestedModel)
                                        && nestedModel.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                                            && c.Signature.Parameters.Count == 0))
                                    {
                                        internalProperty.Update(body: autoBody with { InitializationExpression = New.Instance(internalProperty.Type) });
                                    }
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

        private static bool TryGetModelProvider(CSharpType type, [NotNullWhen(true)] out ModelProvider? modelProvider)
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(type, out var typeProvider) && typeProvider is ModelProvider model)
            {
                modelProvider = model;
                return true;
            }
            modelProvider = null;
            return false;
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

        /// <summary>
        /// Returns true when the flattened public property's type should be made
        /// <c>Nullable&lt;T&gt;</c> / <c>T?</c>. The decision is driven solely by whether
        /// the wrapping parent (the internalized property, e.g. <c>properties?:</c>) may be
        /// absent at runtime. When the wrapper is required, the flattened property keeps
        /// the inner property's original type. When the wrapper is optional, the flattened
        /// property is effectively optional too and must surface that absence to callers.
        /// Applies to both value types and reference types.
        /// </summary>
        private static bool ShouldLiftToNullable(PropertyProvider internalProperty)
        {
            return internalProperty.Type.IsNullable
                || internalProperty.WireInfo?.IsRequired == false;
        }

        /// <summary>
        /// Looks up the flattened model type map for the given type, also checking base types
        /// when the type itself has no entry (handles inherited flattened properties).
        /// </summary>
        private bool TryGetFlattenedModelType(CSharpType type, [NotNullWhen(true)] out Dictionary<string, List<FlattenPropertyInfo>>? propertyNameMap)
        {
            if (_flattenedModelTypes.TryGetValue(type, out propertyNameMap))
            {
                return true;
            }
            // Check base types for inherited flattened properties
            if (TryGetModelProvider(type, out var model))
            {
                var baseModel = model.BaseModelProvider;
                while (baseModel is not null)
                {
                    if (_flattenedModelTypes.TryGetValue(baseModel.Type, out propertyNameMap))
                    {
                        return true;
                    }
                    baseModel = baseModel.BaseModelProvider;
                }
            }
            return false;
        }

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
