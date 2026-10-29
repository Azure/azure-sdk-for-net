// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    internal static class CompatibilityTestHelpers
    {
        internal static void AssertUriIgnoringApiVersion(Uri actual, Uri expected)
        {
            string Normalize(Uri uri)
            {
                const string pattern = @"([?&]api-version=)([^&#]*)";
                MatchCollection versions = Regex.Matches(uri.Query, pattern);
                Assert.That(versions, Has.Count.EqualTo(1), "Expected exactly one api-version query parameter.");
                Assert.That(versions[0].Groups[2].Value, Is.Not.Empty, "Expected a nonempty api-version query value.");
                return uri.GetLeftPart(UriPartial.Path) + Regex.Replace(uri.Query, pattern, "${1}ignored") + uri.Fragment;
            }

            Assert.That(Normalize(actual), Is.EqualTo(Normalize(expected)));
        }

        internal static T ReadJson<T>(string payload, ModelReaderWriterOptions options)
        {
            var model = (IJsonModel<T>)Activator.CreateInstance(typeof(T), nonPublic: true);
            var reader = new Utf8JsonReader(BinaryData.FromString(payload).ToMemory().Span);
            return model.Create(ref reader, options);
        }

        internal static BinaryData WriteJson<T>(IJsonModel<T> model, ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                model.Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        internal static string GetWirePath(PropertyInfo property) =>
            property.GetCustomAttributesData()
                .SingleOrDefault(attribute => attribute.AttributeType.Name == "WirePathAttribute")
                ?.ConstructorArguments[0].Value as string;

        internal static void AssertHidden(MemberInfo member)
        {
            Assert.That(member, Is.Not.Null);
            Assert.That(member.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
        }

        internal static void AssertDeprecated(MemberInfo member, string replacement = null)
        {
            AssertHidden(member);
            ObsoleteAttribute obsolete = member.GetCustomAttribute<ObsoleteAttribute>();
            Assert.That(obsolete, Is.Not.Null);
            if (replacement != null)
            {
                Assert.That(obsolete.Message, Does.Contain(replacement));
            }
        }

        internal static object InvokeFactory(MethodInfo factory, string parameterName, object value)
            => InvokeFactory(factory, new Dictionary<string, object> { [parameterName] = value });

        internal static object InvokeFactory(MethodInfo factory, IReadOnlyDictionary<string, object> values)
        {
            object[] arguments = factory.GetParameters().Select(parameter => values.TryGetValue(parameter.Name, out object value) ? value
                : parameter.HasDefaultValue ? parameter.DefaultValue
                : parameter.ParameterType.IsValueType ? Activator.CreateInstance(parameter.ParameterType) : null).ToArray();
            return factory.Invoke(null, arguments);
        }
    }
}
