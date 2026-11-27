// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Utilities
{
    internal class PropertyHelpers
    {
        public static IReadOnlyList<PropertyProvider> GetAllProperties(ModelProvider propertyModelProvider)
        {
            var result = new List<PropertyProvider>();
            var baseType = propertyModelProvider.BaseModelProvider;
            var baseTypes = new Stack<ModelProvider>();

            // Recursively get properties from base types
            while (baseType is not null)
            {
                baseTypes.Push(baseType);
                baseType = baseType.BaseModelProvider;
            }
            while (baseTypes.TryPop(out var item))
            {
                result.AddRange(item.CanonicalView.Properties);
            }
            result.AddRange(propertyModelProvider.CanonicalView.Properties);
            return result;
        }

        public static (bool IsReadOnly, bool? IncludeGetterNullCheck, bool IncludeSetterNullCheck) GetFlags(PropertyProvider property, PropertyProvider innerProperty)
        {
            var isInnerPropertyReadOnly = !innerProperty.Body.HasSetter;
            var isPropertyReadOnly = !property.Body.HasSetter;
            if (!isPropertyReadOnly && isInnerPropertyReadOnly)
            {
                if (HasDefaultPublicCtor(innerProperty.EnclosingType as ModelProvider))
                {
                    if (innerProperty.Type.Arguments.Count > 0)
                        return (true, true, false);
                    else
                        return (true, false, false);
                }
                else
                {
                    return (false, false, false);
                }
            }
            else if (!isPropertyReadOnly && !isInnerPropertyReadOnly)
            {
                if (HasDefaultPublicCtor(innerProperty.EnclosingType as ModelProvider))
                    return (false, false, true);
                else
                    return (false, false, false);
            }

            return (true, null, false);
        }

        public static bool HasDefaultPublicCtor(ModelProvider? innerModel)
        {
            if (innerModel is null)
                return false;

            foreach (var ctor in innerModel.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !ctor.Signature.Parameters.Any())
                    return true;
            }

            return false;
        }

        public static MethodBodyStatement BuildGetter(bool? includeGetterNullCheck, PropertyProvider internalProperty, TypeProvider innerModel, PropertyProvider innerProperty, CSharpType publicPropertyType, bool allowWrapperAssignment = true)
        {
            var checkNullExpression = This.Property(internalProperty.Name).Is(Null);
            ValueExpression value = new MemberExpression(internalProperty, innerProperty.Name);
            if (publicPropertyType is { IsValueType: true, IsNullable: false } && innerProperty.Type.IsNullable)
            {
                // Keep the wire value optional without changing the shipped non-nullable API.
                value = value.Invoke(nameof(Nullable<int>.GetValueOrDefault));
            }
            var guardedDefault = publicPropertyType.IsNullable && innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable
                ? Default.CastTo(innerProperty.Type.WithNullable(true))
                : Default;
            var shouldNullGuard = internalProperty.Type.IsNullable || internalProperty.WireInfo?.IsRequired == false || innerModel.Type.IsNullable;
            // For collection types, we initialize the internal property if it's null and return the inner property.
            if (innerProperty.Type.IsCollection && internalProperty.WireInfo?.IsRequired == true)
            {
                if (!internalProperty.Body.HasSetter || !allowWrapperAssignment)
                {
                    return Return(new TernaryConditionalExpression(checkNullExpression, guardedDefault, value));
                }

                return new List<MethodBodyStatement> {
                    new IfStatement(checkNullExpression)
                    {
                        internalProperty.Assign(New.Instance(innerModel.Type)).Terminate()
                    },
                    Return(value)
                };
            }

            if (includeGetterNullCheck == true)
            {
                if (!allowWrapperAssignment)
                {
                    return Return(new TernaryConditionalExpression(checkNullExpression, guardedDefault, value));
                }
                return new List<MethodBodyStatement> {
                    new IfStatement(checkNullExpression)
                    {
                        internalProperty.Assign(New.Instance(innerModel.Type)).Terminate()
                    },
                    Return(value)
                };
            }
            else if (includeGetterNullCheck == false)
            {
                // For collection types with a settable internal property, initialize the internal property
                // to avoid returning null, which would cause NullReferenceException during serialization.
                if (innerProperty.Type.IsCollection && internalProperty.Body.HasSetter && allowWrapperAssignment)
                {
                    return new List<MethodBodyStatement> {
                        new IfStatement(checkNullExpression)
                        {
                            internalProperty.Assign(New.Instance(innerModel.Type)).Terminate()
                        },
                        Return(value)
                    };
                }
                return Return(new TernaryConditionalExpression(checkNullExpression, guardedDefault, value));
            }
            else
            {
                if (shouldNullGuard)
                {
                    return Return(new TernaryConditionalExpression(checkNullExpression, guardedDefault, value));
                }
                return Return(value);
            }
        }

        public static MethodBodyStatement? BuildSetterForPropertyFlatten(ModelProvider innerModel, PropertyProvider internalProperty, PropertyProvider innerProperty, bool isPropertyLiftedToNullable, bool allowCollectionSetter = false)
        {
            if (innerProperty.Type.IsCollection && !allowCollectionSetter)
            {
                return null;
            }

            // Use the shared "lazy-create wrapper, then assign leaf" pattern. When the
            // public setter receives Nullable<T> for a non-nullable value-type inner, the
            // helper guards on HasValue so a null assignment is a no-op rather than
            // silently erasing the inner leaf to default(T). Setting a leaf to null does
            // NOT clear sibling leaves on the same parent. For already-nullable inners
            // and reference types the public type matches the inner type and the value
            // is passed through directly.
            return BuildLazyCreateAndAssignSetter(innerModel, internalProperty, innerProperty, isPropertyLiftedToNullable);
        }

        public static bool HasAccessibleDefaultConstructor(ModelProvider model)
        {
            if (model is SystemObjectModelProvider)
            {
                return HasAccessibleExternalDefaultConstructor(model);
            }
            var constructors = model.CanonicalView.Constructors
                .Concat(model.SerializationProviders.SelectMany(p => p.Constructors)).ToArray();
            if (constructors.Length == 0)
            {
                // An implicit parameterless constructor still has to satisfy required members.
                return CanConstructWithoutUnsatisfiedRequiredMembers(model, null);
            }

            var applicable = constructors.Where(c => c.Signature.Parameters.All(p => p.DefaultValue is not null || p.IsParams)).ToArray();
            // A parameterless overload wins over optional/params overloads. Otherwise fail closed
            // when multiple overloads could make new T() ambiguous.
            var parameterless = applicable.Where(c => c.Signature.Parameters.Count == 0).ToArray();
            var candidate = parameterless.Length == 1 ? parameterless[0] :
                parameterless.Length == 0 && applicable.Length == 1 ? applicable[0] : null;
            if (candidate is null && model.Type.IsStruct && parameterless.Length == 0 && applicable.Length == 0)
            {
                return CanConstructWithoutUnsatisfiedRequiredMembers(model, null);
            }
            return candidate is not null && !candidate.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Private) &&
                (candidate.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) ||
                 candidate.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) && model is not SystemObjectModelProvider) &&
                CanConstructWithoutUnsatisfiedRequiredMembers(model, candidate);
        }

        public static INamedTypeSymbol? GetExternalTypeSymbol(CSharpType type)
        {
            var metadataName = $"{type.Namespace}.{type.ClrMetadataName}";
            var source = ManagementClientGenerator.Instance.SourceInputModel;
            var symbol = source.Customization?.GetTypeByMetadataName(metadataName) ?? source.LastContract?.GetTypeByMetadataName(metadataName);
            if (symbol is not null)
            {
                return symbol;
            }

            // Inspect already-loaded runtime metadata when neither source compilation resolves the type.
            // Do not load arbitrary assemblies or treat an input projection as the actual external type.
            var runtimeType = type.IsFrameworkType ? type.FrameworkType : Type.GetType(metadataName) ??
                AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(metadataName, throwOnError: false)).FirstOrDefault(t => t is not null);
            if (runtimeType is null)
            {
                return null;
            }
            var paths = new[] { typeof(object).Assembly.Location, runtimeType.Assembly.Location }
                .Where(path => !string.IsNullOrEmpty(path) && System.IO.File.Exists(path)).Distinct(StringComparer.Ordinal);
            var references = paths.Select(path => MetadataReference.CreateFromFile(path));
            return CSharpCompilation.Create("ExternalTypeInspection", references: references).GetTypeByMetadataName(metadataName);
        }

        private static bool HasAccessibleExternalDefaultConstructor(ModelProvider model)
        {
            var symbol = GetExternalTypeSymbol(model.Type);
            if (symbol is null || symbol.IsAbstract)
            {
                return false;
            }
            var applicable = symbol.InstanceConstructors.Where(c => c.Parameters.All(p => p.IsOptional || p.IsParams)).ToArray();
            var parameterless = applicable.Where(c => c.Parameters.Length == 0).ToArray();
            var candidate = parameterless.Length == 1 ? parameterless[0] :
                parameterless.Length == 0 && applicable.Length == 1 ? applicable[0] : null;
            if (candidate is null || candidate.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }
            return ExternalConstructorSatisfiesRequiredMembers(symbol, candidate);
        }

        public static bool HasAccessibleExternalValueConstructor(ModelProvider model, CSharpType valueType)
        {
            var symbol = GetExternalTypeSymbol(model.Type);
            if (symbol is null || symbol.IsAbstract)
            {
                return false;
            }
            var applicable = symbol.InstanceConstructors.Where(c => c.Parameters.Length > 0 &&
                c.Parameters[0].RefKind == RefKind.None && !c.Parameters[0].IsParams &&
                c.Parameters.Skip(1).All(p => p.IsOptional || p.IsParams)).ToArray();
            var exact = applicable.Where(c => ExternalTypeMatches(c.Parameters[0].Type, valueType)).ToArray();
            var singleArgument = exact.Where(c => c.Parameters.Length == 1).ToArray();
            var candidate = singleArgument.Length == 1 ? singleArgument[0] : null;
            return candidate is not null && candidate.DeclaredAccessibility == Accessibility.Public &&
                ExternalConstructorSatisfiesRequiredMembers(symbol, candidate);
        }

        private static bool ExternalTypeMatches(ITypeSymbol symbol, CSharpType type)
        {
            if (symbol is IArrayTypeSymbol array)
            {
                if (!type.IsArray)
                {
                    return false;
                }
                var rank = type.IsFrameworkType ? type.FrameworkType.GetArrayRank() : GetGeneratedArrayRank(type.Name);
                return array.Rank == rank && ExternalTypeMatches(array.ElementType, type.ElementType);
            }
            if (symbol is not INamedTypeSymbol named)
            {
                return false;
            }
            if (named.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T)
            {
                return type.IsValueType && type.IsNullable && ExternalTypeMatches(named.TypeArguments[0], type.WithNullable(false));
            }
            return !(type.IsValueType && type.IsNullable) && named.Name == type.Name &&
                named.ContainingNamespace.ToDisplayString() == type.Namespace && named.TypeArguments.Length == type.Arguments.Count &&
                (named.ContainingType is null && type.DeclaringType is null ||
                 named.ContainingType is not null && type.DeclaringType is not null && ExternalTypeMatches(named.ContainingType, type.DeclaringType)) &&
                named.TypeArguments.Zip(type.Arguments).All(p => ExternalTypeMatches(p.First, p.Second));
        }

        private static int GetGeneratedArrayRank(string name)
        {
            var start = name.LastIndexOf('[');
            if (start < 0 || !name.EndsWith(']'))
            {
                return 0;
            }
            var dimensions = name.AsSpan(start + 1, name.Length - start - 2);
            var rank = 1;
            foreach (var dimension in dimensions)
            {
                if (dimension != ',')
                {
                    return 0;
                }
                rank++;
            }
            return rank;
        }

        private static bool ExternalConstructorSatisfiesRequiredMembers(INamedTypeSymbol type, IMethodSymbol constructor)
        {
            for (var current = type; current is not null; current = current.BaseType)
            {
                if (current.GetMembers().Any(member => member is IPropertySymbol { IsRequired: true } or IFieldSymbol { IsRequired: true }))
                {
                    return constructor.GetAttributes().Any(a =>
                        a.AttributeClass?.ToDisplayString() == "System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute");
                }
            }
            return true;
        }

        public static bool HasSafeFlattenDefaultConstructor(ModelProvider model)
            => model is SystemObjectModelProvider ? HasAccessibleExternalDefaultConstructor(model) :
                model.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 0 &&
                !c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Private) &&
                (c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) ||
                 c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) && model is not SystemObjectModelProvider) &&
                CanConstructWithoutUnsatisfiedRequiredMembers(model, c));

        public static bool CanConstructWithoutUnsatisfiedRequiredMembers(ModelProvider model, ConstructorProvider? constructor)
        {
            if (model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract) ||
                model.CustomCodeView?.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract) == true)
            {
                return false;
            }
            var compilation = ManagementClientGenerator.Instance.SourceInputModel.Customization;
            var visited = new HashSet<ModelProvider>();
            var hasRequiredMembers = false;
            for (var current = model; current is not null && visited.Add(current); current = current.BaseModelProvider)
            {
                var custom = current.CustomCodeView;
                var type = custom?.Type ?? (current is SystemObjectModelProvider ? current.Type : null);
                if (type is null)
                {
                    continue;
                }
                var symbol = compilation?.GetTypeByMetadataName($"{type.Namespace}.{type.ClrMetadataName}");
                if (symbol is null)
                {
                    return false;
                }
                for (var declaring = symbol; declaring is not null; declaring = declaring.BaseType)
                {
                    if (declaring.GetMembers().Any(member => member is IPropertySymbol { IsRequired: true } or IFieldSymbol { IsRequired: true }))
                    {
                        hasRequiredMembers = true;
                        break;
                    }
                }
            }
            if (!hasRequiredMembers)
            {
                return true;
            }
            if (constructor is null)
            {
                return false;
            }
            if (constructor.Signature.Attributes.Any(a => a.Type.Namespace == "System.Diagnostics.CodeAnalysis" && a.Type.Name == "SetsRequiredMembersAttribute"))
            {
                return true;
            }

            // Custom constructor providers omit this attribute. Confirm it on the source symbol;
            // require every same-name/arity match to carry the attribute when overloads are ambiguous.
            var customView = model.CustomCodeView;
            if (customView is null || !customView.Constructors.Any(c => ReferenceEquals(c, constructor)))
            {
                return false;
            }
            var customType = customView.Type;
            var customSymbol = compilation?.GetTypeByMetadataName($"{customType.Namespace}.{customType.ClrMetadataName}");
            var matches = customSymbol?.InstanceConstructors.Where(c =>
                c.Parameters.Length == constructor.Signature.Parameters.Count &&
                c.Parameters.Zip(constructor.Signature.Parameters).All(p => p.First.Name == p.Second.Name)).ToArray();
            return matches is { Length: > 0 } && matches.All(c => c.GetAttributes().Any(a =>
                a.AttributeClass?.ToDisplayString() == "System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute"));
        }

        public static MethodBodyStatement? BuildSetterForSafeFlatten(bool includeSetterCheck, ModelProvider innerModel, PropertyProvider internalProperty, PropertyProvider innerProperty, bool isPropertyLiftedToNullable, bool allowDefaultConstructorForCompatibility = false)
        {
            // An output-only model may have an internal parameterless initialization constructor even when
            // it has no public one. Use it for a restored setter instead of assuming a one-value constructor.
            // Keep the existing safe-flatten choice between value construction and assignment:
            // serialization-only constructors must not change its null-setter semantics.
            var hasAccessibleDefaultConstructor = allowDefaultConstructorForCompatibility && HasSafeFlattenDefaultConstructor(innerModel);
            if (includeSetterCheck && HasAccessibleDefaultConstructor(innerModel) || hasAccessibleDefaultConstructor)
            {
                // Same shape as property flatten: lazy-create the wrapper and assign the
                // leaf, with a HasValue guard around the body when the public type was
                // lifted to Nullable<T> over a non-nullable value-type inner.
                return BuildLazyCreateAndAssignSetter(innerModel, internalProperty, innerProperty, isPropertyLiftedToNullable);
            }

            var setter = new List<MethodBodyStatement>();
            var internalPropertyExpression = This.Property(internalProperty.Name);
            var needsUnwrap = isPropertyLiftedToNullable && innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
            if (needsUnwrap)
            {
                // Inner model has no parameterless ctor — the single required ctor arg IS the
                // lifted leaf, so the parent's only meaningful state is that one value. In this
                // safe-flatten case, assigning null is interpreted as "erase the parent": we
                // wrap a non-null value in a new parent, and set the parent to null otherwise.
                var hasValueGuard = Value.Property(nameof(Nullable<int>.HasValue));
                var unwrappedValue = Value.Property(nameof(Nullable<int>.Value));
                setter.Add(internalPropertyExpression.Assign(new TernaryConditionalExpression(hasValueGuard, New.Instance(innerModel.Type!, unwrappedValue), Default)).Terminate());
            }
            else
            {
                // When the inner property is itself a flattened property (chained safe-flatten across
                // 3+ levels of single-property models), `new innerModel(value)` is invalid because the
                // value's type does not match any constructor parameter on innerModel. In that case we
                // fall back to the safe pattern of constructing innerModel via its parameterless
                // (internal) constructor and delegating the assignment through innerProperty's own
                // flattened setter. See https://github.com/microsoft/typespec/issues/7380.
                if (innerProperty is FlattenedPropertyProvider)
                {
                    setter.Add(new IfStatement(internalPropertyExpression.Is(Null))
                    {
                        internalPropertyExpression.Assign(New.Instance(innerModel.Type!)).Terminate()
                    });
                    setter.Add(internalPropertyExpression.Property(innerProperty.Name).Assign(Value).Terminate());
                }
                else
                {
                    setter.Add(internalPropertyExpression.Assign(New.Instance(innerModel.Type, Value)).Terminate());
                }
            }
            return setter;
        }

        // Emits the canonical "lazy-create wrapper, then assign leaf" setter body. When
        // the public property is lifted to Nullable<T> over a non-nullable value-type
        // inner the body is wrapped in `if (value.HasValue) { ... }` so a null
        // assignment is a no-op (the only safe choice — there's no original value to
        // preserve and assigning default(T) would silently corrupt the inner leaf).
        private static MethodBodyStatement BuildLazyCreateAndAssignSetter(ModelProvider innerModel, PropertyProvider internalProperty, PropertyProvider innerProperty, bool isPropertyLiftedToNullable)
        {
            var internalPropertyExpression = This.Property(internalProperty.Name);
            var needsUnwrap = isPropertyLiftedToNullable && innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;
            var lazyCreateAndAssign = new List<MethodBodyStatement>
            {
                new IfStatement(internalPropertyExpression.Is(Null))
                {
                    internalPropertyExpression.Assign(New.Instance(innerModel.Type!)).Terminate()
                },
                internalPropertyExpression.Property(innerProperty.Name).Assign(needsUnwrap ? Value.Property(nameof(Nullable<int>.Value)) : Value).Terminate()
            };

            if (needsUnwrap)
            {
                return new IfStatement(Value.Property(nameof(Nullable<int>.HasValue)))
                {
                    lazyCreateAndAssign
                };
            }

            return lazyCreateAndAssign;
        }

        public static string GetCombinedPropertyName(PropertyProvider innerProperty, PropertyProvider immediateParentProperty, string? innerPropertyName = null)
        {
            var immediateParentPropertyName = GetPropertyName(immediateParentProperty);
            var name = innerPropertyName ?? innerProperty.Name;

            if (innerProperty.Type.Equals(typeof(bool)) || innerProperty.Type.Equals(typeof(bool?)))
            {
                return name.Equals("Enabled", StringComparison.Ordinal) ? $"{immediateParentPropertyName}{name}" : name;
            }

            if (name.Equals("Id", StringComparison.Ordinal))
                return $"{immediateParentPropertyName}{name}";

            if (immediateParentPropertyName.EndsWith(name, StringComparison.Ordinal))
                return immediateParentPropertyName;

            var parentWords = immediateParentPropertyName.SplitByCamelCase();
            bool suffixStripped = false;
            if (immediateParentPropertyName.EndsWith("Profile", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Policy", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Configuration", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Properties", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Settings", StringComparison.Ordinal))
            {
                parentWords = parentWords.Take(parentWords.Count() - 1);
                suffixStripped = true;
            }

            var parentWordArray = parentWords.ToArray();
            var parentWordsHash = new HashSet<string>(parentWordArray);
            var nameWords = name.SplitByCamelCase().ToArray();
            var lastWord = string.Empty;
            for (int i = 0; i < nameWords.Length; i++)
            {
                var word = nameWords[i];
                lastWord = word;
                if (parentWordsHash.Contains(word))
                {
                    if (i == nameWords.Length - 2 && parentWordArray.Length >= 2 && word.Equals(parentWordArray[parentWordArray.Length - 2], StringComparison.Ordinal))
                    {
                        parentWords = parentWords.Take(parentWords.Count() - 2);
                        break;
                    }
                    {
                        return name;
                    }
                }

                //need to pluralize or singularize the last word and check
                if (i == nameWords.Length - 1 && (parentWordsHash.Contains(lastWord.Pluralize()) || (suffixStripped && parentWordsHash.Contains(lastWord.Singularize()))))
                    return name;
            }

            immediateParentPropertyName = string.Join("", parentWords);

            return $"{immediateParentPropertyName}{name}";
        }

        private static string GetPropertyName(PropertyProvider property)
        {
            const string properties = "Properties";
            if (property.Name.Equals(properties, StringComparison.Ordinal))
            {
                string typeName = property.Type.Name;
                int index = typeName.IndexOf(properties);
                if (index > -1 && index + properties.Length == typeName.Length)
                    return typeName.Substring(0, index);

                return typeName;
            }
            return property.Name;
        }
    }
}
