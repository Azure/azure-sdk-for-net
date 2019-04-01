// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ServerManagement.Tests
{
    internal static class Extensions
    {
        internal static bool MatchesName(this string id, string str)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(str))
            {
                return false;
            }

            return id.Substring(id.LastIndexOf("/", StringComparison.Ordinal) + 1) == str;
        }

        internal static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> elements)
        {
            if (elements != null)
            {
                foreach (var e in elements)
                {
                    if( e != null )
                    {
                        yield return e;
                    }
                }
            }
        }

        internal static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(
                o,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    Converters = new JsonConverter[] { new StringEnumConverter() },
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Reuse,
                });
        }

        internal static string ToJsonTight(this object o)
        {
            return JsonConvert.SerializeObject(
                o,
                Formatting.None,
                new JsonSerializerSettings
                {
                    Converters = new JsonConverter[] { new StringEnumConverter() },
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Reuse,
                });
        }


        internal static TaskAwaiter GetAwaiter(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks).GetAwaiter();
        }

        internal static void SetEnvironmentVariableIfNotAlreadySet(string variable, string value)
        {
            if (Environment.GetEnvironmentVariable(variable) == null)
            {
                Environment.SetEnvironmentVariable(variable, value);
            }
        }
    }
}