// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Extensions;
using Humanizer;
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
                result.AddRange(item.Properties);
            }
            result.AddRange(propertyModelProvider.Properties);
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

        private static bool HasDefaultPublicCtor(ModelProvider? innerModel)
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

        public static MethodBodyStatement BuildGetter(bool? includeGetterNullCheck, PropertyProvider internalProperty, TypeProvider innerModel, PropertyProvider innerProperty)
        {
            var checkNullExpression = This.Property(internalProperty.Name).Is(Null);
            // For collection types, we initialize the internal property if it's null and return the inner property.
            if (innerProperty.Type.IsCollection && internalProperty.WireInfo?.IsRequired == true)
            {
                return new List<MethodBodyStatement> {
                    new IfStatement(checkNullExpression)
                    {
                        internalProperty.Assign(New.Instance(innerModel.Type)).Terminate()
                    },
                    Return(new MemberExpression(internalProperty, innerProperty.Name))
                };
            }

            if (includeGetterNullCheck == true)
            {
                return new List<MethodBodyStatement> {
                    new IfStatement(checkNullExpression)
                    {
                        internalProperty.Assign(New.Instance(innerModel.Type)).Terminate()
                    },
                    Return(new MemberExpression(internalProperty, innerProperty.Name))
                };
            }
            else
            {
                if (innerModel.Type.IsNullable)
                {
                    return Return(new MemberExpression(internalProperty.AsVariableExpression.NullConditional(), innerProperty.Name));
                }
                return Return(new MemberExpression(internalProperty, innerProperty.Name));
            }
        }

        public static MethodBodyStatement? BuildSetterForPropertyFlatten(ModelProvider innerModel, PropertyProvider internalProperty, PropertyProvider innerProperty)
        {
            if (innerProperty.Type.IsCollection)
            {
                return null;
            }

            var isNullableValueType = innerProperty.Type.IsValueType && innerProperty.Type.IsNullable;
            var setter = new List<MethodBodyStatement>();
            var internalPropertyExpression = This.Property(internalProperty.Name);

            setter.Add(
                new IfStatement(internalPropertyExpression.Is(Null))
                {
                        internalPropertyExpression.Assign(New.Instance(innerModel.Type!)).Terminate()
                });
            setter.Add(internalPropertyExpression.Property(innerProperty.Name).Assign(isNullableValueType ? Value.Property(nameof(Nullable<int>.Value)) : Value).Terminate());
            return setter;
        }

        public static MethodBodyStatement? BuildSetterForSafeFlatten(bool includeSetterCheck, ModelProvider innerModel, PropertyProvider internalProperty, PropertyProvider innerProperty)
        {
            // To not introduce breaking change, for collection types, we keep the setter for collection-type properties during safe flatten.
            var isOverriddenValueType = IsOverriddenValueType(innerProperty);
            var setter = new List<MethodBodyStatement>();
            var internalPropertyExpression = This.Property(internalProperty.Name);
            if (includeSetterCheck)
            {
                if (isOverriddenValueType)
                {
                    var ifStatement = new IfStatement(Value.Property(nameof(Nullable<int>.HasValue)))
                    {
                        new IfStatement(internalPropertyExpression.Is(Null))
                        {
                            internalPropertyExpression.Assign(New.Instance(innerModel.Type!)).Terminate(),
                            internalPropertyExpression.Property(innerProperty.Name).Assign(Value.Property(nameof(Nullable<int>.Value))).Terminate()
                        }
                    };
                    setter.Add(new IfElseStatement(ifStatement, internalProperty.AsVariableExpression.Assign(Null).Terminate()));
                }
                else
                {
                    setter.Add(new IfStatement(internalPropertyExpression.Is(Null))
                    {
                        internalPropertyExpression.Assign(New.Instance(innerModel.Type!)).Terminate()
                    });
                    setter.Add(internalPropertyExpression.Property(innerProperty.Name).Assign(Value).Terminate());
                }
            }
            else
            {
                if (isOverriddenValueType)
                {
                    setter.Add(internalPropertyExpression.Assign(new TernaryConditionalExpression(Value.Property(nameof(Nullable<int>.HasValue)), New.Instance(innerModel.Type!, Value.Property(nameof(Nullable<int>.Value))), Default)).Terminate());
                }
                else
                {
                    setter.Add(internalPropertyExpression.Assign(New.Instance(innerModel.Type, Value)).Terminate());
                }
            }
            return setter;
        }

        public static bool IsOverriddenValueType(PropertyProvider innerProperty)
            => innerProperty.Type.IsValueType && !innerProperty.Type.IsNullable;

        public static string GetCombinedPropertyName(PropertyProvider innerProperty, PropertyProvider immediateParentProperty)
        {
            var immediateParentPropertyName = GetPropertyName(immediateParentProperty);

            if (innerProperty.Type.Equals(typeof(bool)) || innerProperty.Type.Equals(typeof(bool?)))
            {
                return innerProperty.Name.Equals("Enabled", StringComparison.Ordinal) ? $"{immediateParentPropertyName}{innerProperty.Name}" : innerProperty.Name;
            }

            if (innerProperty.Name.Equals("Id", StringComparison.Ordinal))
                return $"{immediateParentPropertyName}{innerProperty.Name}";

            if (immediateParentPropertyName.EndsWith(innerProperty.Name, StringComparison.Ordinal))
                return immediateParentPropertyName;

            var parentWords = immediateParentPropertyName.SplitByCamelCase();
            if (immediateParentPropertyName.EndsWith("Profile", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Policy", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Configuration", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Properties", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Settings", StringComparison.Ordinal))
            {
                parentWords = parentWords.Take(parentWords.Count() - 1);
            }

            var parentWordArray = parentWords.ToArray();
            var parentWordsHash = new HashSet<string>(parentWordArray);
            var nameWords = innerProperty.Name.SplitByCamelCase().ToArray();
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
                        return innerProperty.Name;
                    }
                }

                //need to depluralize the last word and check
                if (i == nameWords.Length - 1 && parentWordsHash.Contains(lastWord.Pluralize()))
                    return innerProperty.Name;
            }

            immediateParentPropertyName = string.Join("", parentWords);

            return $"{immediateParentPropertyName}{innerProperty.Name}";
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
