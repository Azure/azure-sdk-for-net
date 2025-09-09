// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Extensions;
using Humanizer;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal class PropertyHelpers
    {
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
