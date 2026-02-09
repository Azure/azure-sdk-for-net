// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return string.Concat(char.ToLower(str[0]), str.AsSpan(1).ToString());
        }
        public static IEnumerable<string> SplitByCamelCase(this string camelCase)
        {
            return camelCase.Humanize().Split(' ').Select(w => w.FirstCharToUpperCase());
        }

        public static string FirstCharToUpperCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Pluralizes a PascalCase string by splitting it into words, pluralizing only the last word,
        /// and joining them back together.
        /// </summary>
        /// <param name="value">The PascalCase string to pluralize.</param>
        /// <param name="inputIsKnownToBeSingular">
        /// When true, Humanizer assumes the input is singular and always pluralizes it.
        /// When false, Humanizer checks if the word might already be plural and leaves it unchanged if so.
        /// </param>
        /// <returns>The pluralized string.</returns>
        public static string PluralizeLastWord(this string value, bool inputIsKnownToBeSingular)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var words = value.SplitByCamelCase().ToArray();

            // Pluralize only the last word
            words[words.Length - 1] = words[words.Length - 1].Pluralize(inputIsKnownToBeSingular);

            return string.Concat(words);
        }

        /// <summary>
        /// Gets the collection method name for a resource based on its name.
        /// If the pluralized name is the same as the original (e.g., "Quota" stays "Quota"),
        /// returns "GetAll{resourceName}" to clearly indicate a collection.
        /// Otherwise, returns "Get{pluralizedName}" (e.g., "GetVirtualMachines").
        /// </summary>
        /// <param name="resourceName">The PascalCase resource name.</param>
        /// <returns>The collection method name.</returns>
        public static string GetCollectionMethodName(this string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                return resourceName;
            }

            // Use inputIsKnownToBeSingular: false because some words like "Quota" and "Metadata"
            // are treated by Humanizer as already plural (from Latin), and we want to preserve
            // them unchanged rather than incorrectly pluralizing them (e.g., "Quotas" would be wrong).
            var pluralOfResourceName = resourceName.PluralizeLastWord(inputIsKnownToBeSingular: false);

            // If the pluralized name is the same as the original (e.g., "Quota" -> "Quota"),
            // use "GetAll{ResourceName}" to avoid having a method named "GetQuota" for a collection
            if (pluralOfResourceName == resourceName)
            {
                return $"GetAll{resourceName}";
            }
            return $"Get{pluralOfResourceName}";
        }
    }
}
