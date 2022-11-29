// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Static class for extension methods.</summary>
    internal static class Extensions
    {
        /// <summary>Verifies the claim based on the type and value.</summary>
        /// <param name="claims">The claims.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if the type and value match.</returns>
        internal static bool VerifyClaim(this IEnumerable<System.Security.Claims.Claim> claims, string type, string value) =>
            claims.Where(x => x.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .Any(x => x.Value.Equals(value, StringComparison.OrdinalIgnoreCase));

        /// <summary>Gets the attribute that is assigned to an enum.</summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The enum to check.</param>
        /// <returns>Return the Attribute if found.</returns>
        internal static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        /// <summary>Gets the description attribute value assigned to an enum.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The description string value if found.</returns>
        public static String GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description?.Description;
        }

        /// <summary>Adds a range of objects to a dictionary.</summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to append to.</param>
        /// <param name="other">The dictionary to append from.</param>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IReadOnlyDictionary<TKey, TValue> other)
        {
            if (other == null)
            {
                return;
            }

            foreach (var pair in other)
            {
                dictionary[pair.Key] = pair.Value;
            }
        }

        internal static bool Matches(this HttpRequestHeaders headers, string key, string value) => headers.Any(h => h.Key.Equals(key, StringComparison.OrdinalIgnoreCase) && h.Value.Any(v => v.Equals(value, StringComparison.OrdinalIgnoreCase)));

        internal static string DecodeBase64(this HttpRequestHeaders headers, string key)
        {
            return headers.Contains(key) ? Encoding.UTF8.GetString(Convert.FromBase64String(headers.GetValues(key).First())) : String.Empty;
        }

        internal static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string key in nvc.Keys)
                dic.Add(key, nvc[key]);
            return dic;
        }
    }
}
