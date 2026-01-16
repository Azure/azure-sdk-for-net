// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _Type.Model.Visibility;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Visibility
{
    public class TypeModelVisibilityTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Models_ReadOnlyRoundTrip() => Test(async (host) =>
        {
            var response = await new VisibilityClient(host, null).PutReadOnlyModelAsync(new ReadOnlyModel());
            Assert.That(response.Value.OptionalNullableIntList.Count, Is.EqualTo(3));
            Assert.That(response.Value.OptionalNullableIntList[0], Is.EqualTo(1));
            Assert.That(response.Value.OptionalNullableIntList[1], Is.EqualTo(2));
            Assert.That(response.Value.OptionalNullableIntList[2], Is.EqualTo(3));
            Assert.That(response.Value.OptionalStringRecord["k1"], Is.EqualTo("value1"));
            Assert.That(response.Value.OptionalStringRecord["k2"], Is.EqualTo("value2"));
        });

        [SpectorTest]
        public void ReadOnlyPropertiesAreReadOnly()
        {
            var property = HasProperty(typeof(VisibilityModel), "ReadProp", BindingFlags.Public | BindingFlags.Instance);
            var listProperty = HasProperty(typeof(ReadOnlyModel), "OptionalNullableIntList", BindingFlags.Public | BindingFlags.Instance);

            Assert.That(property.SetMethod, Is.Null);
            Assert.That(listProperty.SetMethod, Is.Null);
            Assert.That(listProperty.PropertyType, Is.EqualTo(typeof(IReadOnlyList<int>)));
        }

        [SpectorTest]
        public void RequiredListsAreNotSettable()
        {
            var requiredStringList = HasProperty(typeof(VisibilityModel), nameof(VisibilityModel.ReadProp), BindingFlags.Public | BindingFlags.Instance);
            var requiredIntList = HasProperty(typeof(ReadOnlyModel), nameof(ReadOnlyModel.OptionalNullableIntList), BindingFlags.Public | BindingFlags.Instance);

            Assert.That(requiredIntList.SetMethod, Is.Null);
            Assert.That(requiredStringList.SetMethod, Is.Null);
        }

        [SpectorTest]
        public void ReadOnlyPropertiesAreDeserialized()
        {
            var model = ModelReaderWriter.Read<VisibilityModel>(BinaryData.FromString("{\"readProp\":\"abc\"}"));
            Assert.That(model!.ReadProp, Is.EqualTo("abc"));
        }

        private static PropertyInfo HasProperty(Type type, string name, BindingFlags bindingFlags)
        {
            var parameterInfo = type.GetProperties(bindingFlags).FirstOrDefault(p => p.Name == name);
            Assert.That(parameterInfo, Is.Not.Null, $"Property '{name}' is not found");
            return parameterInfo!;
        }
    }
}
