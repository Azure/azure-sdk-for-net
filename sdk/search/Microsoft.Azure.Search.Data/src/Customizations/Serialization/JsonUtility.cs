// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Serialization.Internal;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static System.Linq.Expressions.Expression;
using Throw = Microsoft.Azure.Search.Common.Throw;

namespace Microsoft.Azure.Search.Serialization
{
    internal static class JsonUtility
    {
        private static IContractResolver CamelCaseResolver { get; } = new CamelCasePropertyNamesContractResolver();

        private static IContractResolver DefaultResolver { get; } = new DefaultContractResolver();

        public static JsonSerializerSettings CreateTypedSerializerSettings<T>(JsonSerializerSettings baseSettings, bool useCamelCase) =>
            CreateSerializerSettings<T>(baseSettings, useCamelCase);

        public static JsonSerializerSettings CreateTypedDeserializerSettings<T>(JsonSerializerSettings baseSettings) =>
            CreateDeserializerSettings<T>(baseSettings);

        public static JsonSerializerSettings CreateDocumentSerializerSettings(JsonSerializerSettings baseSettings) =>
            CreateSerializerSettings<Document>(baseSettings, useCamelCase: false);

        public static JsonSerializerSettings CreateDocumentDeserializerSettings(JsonSerializerSettings baseSettings) =>
            CreateDeserializerSettings<Document>(baseSettings);

        private static JsonSerializerSettings CreateSerializerSettings<T>(
            JsonSerializerSettings baseSettings,
            bool useCamelCase)
        {
            JsonSerializerSettings settings = CopySettings(baseSettings);
            settings.Converters.Add(new GeoJsonPointConverter());
            settings.Converters.Add(new IndexActionConverter<T>());
            settings.Converters.Add(new Iso8601DateTimeConverter());
            settings.Converters.Add(new EdmDoubleConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;

            if (useCamelCase)
            {
                settings.ContractResolver = CamelCaseResolver;
            }
            else if (settings.ContractResolver is ReadOnlyJsonContractResolver)
            {
                settings.ContractResolver = DefaultResolver;
            }

            return settings;
        }

        private static JsonSerializerSettings CreateDeserializerSettings<T>(JsonSerializerSettings baseSettings)
        {
            JsonSerializerSettings settings = CopySettings(baseSettings);
            settings.Converters.Add(new GeoJsonPointConverter());
            settings.Converters.Add(new DocumentConverter());
            settings.Converters.Add(new Iso8601DateTimeConverter());
            settings.Converters.Add(new EdmDoubleConverter());
            settings.Converters.Add(new SearchResultConverter<T>());
            settings.Converters.Add(new SuggestResultConverter<T>());
            settings.DateParseHandling = DateParseHandling.DateTimeOffset;

            // Fail when deserializing null into a non-nullable type. This is to avoid silent data corruption issues.
            settings.NullValueHandling = NullValueHandling.Include;

            if (settings.ContractResolver is ReadOnlyJsonContractResolver)
            {
                settings.ContractResolver = DefaultResolver;
            }

            return settings;
        }

        private static JsonSerializerSettings CopySettings(JsonSerializerSettings baseSettings) =>
            JsonSerializerSettingsCopier.Instance.Copy(baseSettings);

        // Unfortunately we can't just assign the properties of JsonSerializerSettings between instances,
        // because some of these properties come and go within the span of a few JSON.NET versions, and the
        // Azure .NET SDKs can reference a very wide range of possible versions. Instead, we use reflection
        // and dynamic compilation to create a copy method tailored to whatever version of JSON.NET we find
        // ourselves using.
        private class JsonSerializerSettingsCopier
        {
            private readonly Delegate _copy;

            private JsonSerializerSettingsCopier()
            {
                Type sourceType, targetType;
                sourceType = targetType = typeof(JsonSerializerSettings);

                ParameterExpression source = Parameter(sourceType);
                Expression copyExpr = MakeCopyExpr(source);

                // Emits 'source => {copyExpr}' where copyExpr refers to source and returns a copy of it.
                LambdaExpression lambdaExpression =
                    Lambda(
                        delegateType: GetFuncType(sourceType, targetType),
                        body: copyExpr,
                        parameters: source);

                _copy = lambdaExpression.Compile();
            }

            public static JsonSerializerSettingsCopier Instance { get; } = new JsonSerializerSettingsCopier();

            public JsonSerializerSettings Copy(JsonSerializerSettings source)
            {
                Throw.IfArgumentNull(source, nameof(source));

                // Shallow copy all the properties first, then deep copy Converters.
                var newSettings = (JsonSerializerSettings)_copy.DynamicInvoke(source);
                newSettings.Converters = new List<JsonConverter>(source.Converters);
                return newSettings;
            }

            private static Expression MakeCopyExpr(ParameterExpression sourceExpr)
            {
                ParameterExpression source = Variable(typeof(JsonSerializerSettings));
                ParameterExpression target = Variable(typeof(JsonSerializerSettings));

                Expression assignSource = Assign(left: source, right: sourceExpr);
                Expression assignTarget = Assign(left: target, right: New(typeof(JsonSerializerSettings)));

                IEnumerable<Expression> copy = CopyAllProperties(source, target);

                return Block(
                    type: typeof(JsonSerializerSettings),
                    variables: new[] { source, target },
                    expressions: new[] { assignSource, assignTarget }.Concat(copy));
            }

            private static IEnumerable<Expression> CopyAllProperties(
                ParameterExpression source,
                ParameterExpression target)
            {
                var settableNonDeprecatedProperties =
                    typeof(JsonSerializerSettings).GetTypeInfo().DeclaredProperties
                    .Where(p => p.CanRead && p.CanWrite && !IsPropertyDeprecated(p));

                foreach (PropertyInfo property in settableNonDeprecatedProperties)
                {
                    yield return Assign(
                        left: PropertyOrField(target, property.Name),
                        right: PropertyOrField(source, property.Name));
                }

                yield return target;
            }

            private static bool IsPropertyDeprecated(PropertyInfo property) =>
                property.GetCustomAttributes().Any(a => a is ObsoleteAttribute);
        }
    }
}
