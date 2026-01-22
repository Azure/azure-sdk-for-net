// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.GeoJson;
using Azure.Core.Serialization;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonTests
    {
        [Test]
        public void CanGetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
            """);

            int value = jsonData.Foo;

            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void CanGetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            int value = jsonData.Foo.Bar;

            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void CanSetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData.Foo = 2;

            Assert.That((int)jsonData.Foo, Is.EqualTo(2));
        }

        [Test]
        public void CanSetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            jsonData.Foo.Bar = 2;

            Assert.That((int)jsonData.Foo.Bar, Is.EqualTo(2));
        }

        [Test]
        public void CanGetArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            Assert.That((int)jsonData[0], Is.EqualTo(0));
            Assert.That((int)jsonData[1], Is.EqualTo(1));
            Assert.That((int)jsonData[2], Is.EqualTo(2));
        }

        [Test]
        public void CanGetNestedArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2]
                }
                """);

            Assert.That((int)jsonData.Foo[0], Is.EqualTo(0));
            Assert.That((int)jsonData.Foo[1], Is.EqualTo(1));
            Assert.That((int)jsonData.Foo[2], Is.EqualTo(2));
        }

        [Test]
        public void CanGetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            Assert.That((int)jsonData["foo"], Is.EqualTo(1));
        }

        [Test]
        public void CanGetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            Assert.That((int)jsonData.Foo["bar"], Is.EqualTo(1));
        }

        [Test]
        public void CanSetArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            jsonData[0] = 4;
            jsonData[1] = 5;
            jsonData[2] = 6;

            Assert.That((int)jsonData[0], Is.EqualTo(4));
            Assert.That((int)jsonData[1], Is.EqualTo(5));
            Assert.That((int)jsonData[2], Is.EqualTo(6));
        }

        [Test]
        public void CanSetNestedArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2]
                }
                """);

            jsonData.Foo[0] = 4;
            jsonData.Foo[1] = 5;
            jsonData.Foo[2] = 6;

            Assert.That((int)jsonData.Foo[0], Is.EqualTo(4));
            Assert.That((int)jsonData.Foo[1], Is.EqualTo(5));
            Assert.That((int)jsonData.Foo[2], Is.EqualTo(6));
        }

        [Test]
        public void CannotGetOrSetValuesOnAbsentArrays()
        {
            dynamic value = BinaryData.FromString("""{"foo": [1, 2]}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            Assert.Throws<InvalidOperationException>(() => { int i = value[0]; });
            Assert.Throws<InvalidOperationException>(() => { value[0] = 1; });

            Assert.Throws<InvalidOperationException>(() => { int i = value.Foo[0][0]; });
            Assert.Throws<InvalidOperationException>(() => { value.Foo[0][0] = 2; });
        }

        [Test]
        public void CannotGetOrSetValuesOnAbsentProperties()
        {
            dynamic value = BinaryData.FromString("""{"foo": 1}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            Assert.Throws<InvalidOperationException>(() => { int i = value.Foo.Bar.Baz; });
            Assert.Throws<InvalidOperationException>(() => { value.Foo.Bar.Baz = "hi"; });

            Assert.Throws<RuntimeBinderException>(() => { int i = value.A.B.C; });
            Assert.Throws<RuntimeBinderException>(() => { value.A.B.C = 1; });
        }

        [Test]
        public void CanSetArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2, 3]""");

            jsonData[1] = 4;
            jsonData[2] = true;
            jsonData[3] = "string";

            Assert.That((int)jsonData[0], Is.EqualTo(0));
            Assert.That((int)jsonData[1], Is.EqualTo(4));
            Assert.That((bool)jsonData[2], Is.EqualTo(true));
            Assert.That((string)jsonData[3], Is.EqualTo("string"));
        }

        [Test]
        public void CanSetNestedArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2, 3]
                }
                """);

            jsonData.Foo[1] = 4;
            jsonData.Foo[2] = true;
            jsonData.Foo[3] = "string";

            Assert.That((int)jsonData.Foo[0], Is.EqualTo(0));
            Assert.That((int)jsonData.Foo[1], Is.EqualTo(4));
            Assert.That((bool)jsonData.Foo[2], Is.EqualTo(true));
            Assert.That((string)jsonData.Foo[3], Is.EqualTo("string"));
        }

        [Test]
        public void CanGetNullPropertyValue()
        {
            dynamic jsonData = GetDynamicJson("""{ "foo" : null }""");

            Assert.That((CustomType)jsonData.Foo, Is.Null);
            Assert.That((int?)jsonData.Foo, Is.Null);
            Assert.IsNull(jsonData.Foo);
            Assert.IsNull(jsonData.foo);
        }

        [Test]
        public void CanGetNullArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[ null ]""");

            Assert.That((CustomType)jsonData[0], Is.Null);
            Assert.That((int?)jsonData[0], Is.Null);
            Assert.IsNull(jsonData[0]);
        }

        [Test]
        public void CanSetPropertyValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""{ "foo" : null }""");

            jsonData.Foo = null;

            Assert.That((CustomType)jsonData.Foo, Is.Null);
            Assert.That((int?)jsonData.Foo, Is.Null);
            Assert.IsNull(jsonData.Foo);
            Assert.IsNull(jsonData.foo);
        }

        [Test]
        public void CanSetArrayValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""[0]""");

            jsonData[0] = null;

            Assert.That((CustomType)jsonData[0], Is.Null);
            Assert.That((int?)jsonData[0], Is.Null);
            Assert.IsNull(jsonData[0]);
        }

        [Test]
        public void CanSetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData["Foo"] = 4;

            Assert.That((int)jsonData["Foo"], Is.EqualTo(4));
        }

        [Test]
        public void CanSetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            jsonData["foo"]["bar"] = 4;

            Assert.That((int)jsonData.Foo["bar"], Is.EqualTo(4));
        }

        [Test]
        public void CanAddNewProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData.Bar = 2;

            Assert.That((int)jsonData.Foo, Is.EqualTo(1));
            Assert.That((int)jsonData.Bar, Is.EqualTo(2));
        }

        [Test]
        public void CanMakeChangesAndAddNewProperty()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic jsonData = BinaryData.FromString("""
                {
                  "foo" : 1
                }
                """).ToDynamicFromJson(options);

            Assert.That((int)jsonData.Foo, Is.EqualTo(1));

            jsonData.Foo = "hi";

            Assert.That((string)jsonData.Foo, Is.EqualTo("hi"));

            jsonData.Bar = 2;

            Assert.That((string)jsonData.Foo, Is.EqualTo("hi"));
            Assert.That((int)jsonData.Bar, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAddPocoProperty()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            SampleModel model = new()
            {
                Message = "hi",
                Number = 2,
            };

            value.Model = model;

            Assert.IsTrue(value.Foo == 1);
            Assert.IsTrue(value.foo == 1);
            Assert.IsTrue(value.Model.Message == "hi");
            Assert.IsTrue(value.model.message == "hi");
            Assert.IsTrue(value.Model.Number == 2);
            Assert.IsTrue(value.model.number == 2);

            RequestContent content = RequestContent.Create((object)value);
            Stream stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Flush();
            stream.Position = 0;

            BinaryData data = BinaryData.FromStream(stream);
            dynamic roundTripValue = data.ToDynamicFromJson(options);

            Assert.IsTrue(roundTripValue.foo == value.Foo);
            Assert.IsTrue(roundTripValue.model.message == value.Model.Message);
            Assert.IsTrue(roundTripValue.model.number == value.Model.Number);

            Assert.That((SampleModel)roundTripValue.model, Is.EqualTo(model));
            Assert.That((SampleModel)roundTripValue.Model, Is.EqualTo(model));
            Assert.That((SampleModel)value.model, Is.EqualTo(model));
            Assert.That((SampleModel)value.Model, Is.EqualTo(model));
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAddNestedPocoProperty()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            ParentModel model = new ParentModel()
            {
                Name = "Parent",
                Value = new ChildModel()
                {
                    Message = "Child",
                    Number = 1
                }
            };

            value.Model = model;

            Assert.IsTrue(value.Foo == 1);
            Assert.IsTrue(value.foo == 1);
            Assert.IsTrue(value.Model.Name == "Parent");
            Assert.IsTrue(value.model.name == "Parent");
            Assert.IsTrue(value.Model.Value.Message == "Child");
            Assert.IsTrue(value.model.value.message == "Child");

            // Test serialization
            BinaryData jdocBuffer = MutableJsonDocumentTests.GetWriteToBuffer(JsonDocument.Parse(value.ToString()));
            BinaryData dataBuffer = GetWriteToBuffer(value);

            Assert.That(dataBuffer.ToString(), Is.EqualTo(jdocBuffer.ToString()));
            Assert.That(jdocBuffer.ToMemory().Span.SequenceEqual(dataBuffer.ToMemory().Span),
                Is.True,
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Test deserialization
            BinaryData bd = BinaryData.FromString(value.ToString());
            dynamic roundTripValue = bd.ToDynamicFromJson(options);
            Assert.That((ChildModel)roundTripValue.Model.Value, Is.EqualTo(model.Value));
            Assert.That((ParentModel)roundTripValue.Model, Is.EqualTo(model));
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanSetNestedPocoProperty()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            ParentModel model = new ParentModel()
            {
                Name = "Parent",
                Value = new ChildModel()
                {
                    Message = "Child",
                    Number = 1
                }
            };

            value.Foo = model;

            Assert.IsTrue(value.Foo.Name == "Parent");
            Assert.IsTrue(value.foo.name == "Parent");
            Assert.IsTrue(value.Foo.Value.Message == "Child");
            Assert.IsTrue(value.foo.value.message == "Child");

            // Test serialization
            BinaryData jdocBuffer = MutableJsonDocumentTests.GetWriteToBuffer(JsonDocument.Parse(value.ToString()));
            BinaryData dataBuffer = GetWriteToBuffer(value);

            Assert.That(dataBuffer.ToString(), Is.EqualTo(jdocBuffer.ToString()));
            Assert.That(jdocBuffer.ToMemory().Span.SequenceEqual(dataBuffer.ToMemory().Span),
                Is.True,
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Test deserialization
            BinaryData bd = BinaryData.FromString(value.ToString());
            dynamic roundTripValue = bd.ToDynamicFromJson(options);
            Assert.That((ChildModel)roundTripValue.Foo.Value, Is.EqualTo(model.Value));
            Assert.That((ParentModel)roundTripValue.Foo, Is.EqualTo(model));
        }

        internal static BinaryData GetWriteToBuffer(dynamic data)
        {
            using MemoryStream stream = new();
            data.WriteTo(stream);
            stream.Position = 0;
            return BinaryData.FromStream(stream);
        }

        [Test]
        public void CanCheckOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "foo"
                }
                """);

            // Property is present
            Assert.IsFalse(json.Foo == null);
            Assert.AreNotEqual(null, json.Foo);

            // Property is absent
            Assert.IsTrue(json.Bar == null);
            Assert.AreEqual(null, json.Bar);
        }

        [Test]
        public void CanCheckOptionalPropertyWithChanges()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic json = BinaryData.FromString("""
                {
                  "foo" : "foo",
                  "bar" : {
                    "a" : "a"
                  }
                }
            """).ToDynamicFromJson(options);

            // Add property Baz
            json.Baz = "baz";

            // Remove property A
            json.Bar = new { B = "b" };

            // Properties are present
            Assert.IsFalse(json.Foo == null);
            Assert.AreNotEqual(null, json.Foo);
            Assert.IsFalse(json.Bar.B == null);
            Assert.AreNotEqual(null, json.Bar.B);
            Assert.IsFalse(json.Baz == null);
            Assert.AreNotEqual(null, json.Baz);

            // Properties are absent
            Assert.IsTrue(json.Bar.A == null);
            Assert.AreEqual(null, json.Bar.A);
        }

        [Test]
        public void CanSetOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "foo"
                }
                """);

            // Property is absent
            Assert.IsTrue(json.OptionalValue == null);
            Assert.AreEqual(null, json.OptionalValue);

            json.OptionalValue = 5;

            // Property is present
            Assert.IsFalse(json.OptionalValue == null);
            Assert.That((int)json.OptionalValue, Is.EqualTo(5));
        }

        [Test]
        public void CanDispose()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "Hello"
                }
                """);

            json.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void CanDisposeViaUsing()
        {
            string json = """
                {
                  "foo" : "Hello"
                }
                """;

            dynamic outer = default;
            using (dynamic jsonData = GetDynamicJson(json))
            {
                Assert.IsTrue(jsonData.Foo == "Hello");
                outer = jsonData;

                Assert.IsTrue(outer.Foo == "Hello");
            }

            Assert.Throws<ObjectDisposedException>(() => { var foo = outer.Foo; });
        }

        [Test]
        public void DisposingAChildDisposesTheParent()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : {
                    "a": "Hello"
                  }
                }
                """);

            dynamic child = json.Foo.A;
            child.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void ThrowsInvalidCastForOriginalJsonValue()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic json = BinaryData.FromString(
                """
                {
                    "foo": 1
                }
                """
                ).ToDynamicFromJson(options);

            Exception e = Assert.Throws<InvalidCastException>(() => { var value = (bool)json.Foo; });
            Assert.That(e.Message.Contains(JsonValueKind.Number.ToString()));
        }

        [Test]
        public void ThrowsInvalidCastForChangedJsonValue()
        {
            dynamic json = BinaryData.FromString(
                """
                {
                    "foo": 1
                }
                """
                ).ToDynamicFromJson();

            json.Foo = true;

            Exception e = Assert.Throws<InvalidCastException>(() => { var value = (int)json.Foo; });
            Assert.That(e.Message.Contains(JsonValueKind.True.ToString()));
        }

        [Test]
        public void CanCastToByte()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic json = BinaryData.FromString("""
                {
                  "foo" : 42
                }
                """).ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.That((byte)json.Foo, Is.EqualTo((byte)42));
            Assert.IsTrue(((byte)42) == json.Foo);

            // Get from assigned existing value
            json.Foo = (byte)43;
            Assert.That((byte)json.Foo, Is.EqualTo((byte)43));
            Assert.IsTrue(((byte)43) == json.Foo);

            // Get from added value
            json.Bar = (byte)44;
            Assert.That((byte)json.Bar, Is.EqualTo((byte)44));
            Assert.IsTrue(((byte)44) == json.Bar);

            // Doesn't work if number change is outside byte range
            json.Foo = 256;
            Assert.Throws<InvalidCastException>(() => { byte b = json.Foo; });

            // Doesn't work for non-number change
            json.Foo = "string";
            Assert.Throws<InvalidCastException>(() => { byte b = json.Foo; });
        }

        [TestCaseSource(nameof(NumberValues))]
        public void CanCastToNumber<T, U>(string serializedX, T x, T y, T z, U invalid)
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            dynamic json = BinaryData.FromString($"{{\"foo\" : {serializedX}}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.That((T)json.Foo, Is.EqualTo(x));
            Assert.IsTrue(x == json.Foo);
            Assert.IsTrue(json.Foo == x);

            // Get from assigned existing value
            json.Foo = y;
            Assert.That((T)json.Foo, Is.EqualTo(y));
            Assert.IsTrue(y == json.Foo);
            Assert.IsTrue(json.Foo == y);

            // Get from added value
            json.Bar = z;
            Assert.That((T)json.Bar, Is.EqualTo(z));
            Assert.IsTrue(z == json.Bar);
            Assert.IsTrue(json.Bar == z);

            // Doesn't work if number change is outside T range
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            if (invalid is bool testRange && testRange)
            {
                json.Foo = invalid;
                Assert.Throws<InvalidCastException>(() => { T b = json.Foo; });
            }

            // Doesn't work for non-number change
            json.Foo = "string";
            Assert.Throws<InvalidCastException>(() => { T b = json.Foo; });
        }

        [Test]
        public void CanExplicitCastToGuid()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            Guid guid = Guid.NewGuid();
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{guid}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.That((Guid)json.Foo, Is.EqualTo(guid));
            Assert.That(guid, Is.EqualTo((Guid)json.Foo));
            Assert.That((Guid)json.Foo, Is.EqualTo(guid));

            // Get from assigned existing value
            Guid fooValue = Guid.NewGuid();
            json.Foo = fooValue;
            Assert.That((Guid)json.Foo, Is.EqualTo(fooValue));
            Assert.That(fooValue, Is.EqualTo((Guid)json.Foo));
            Assert.That((Guid)json.Foo, Is.EqualTo(fooValue));

            // Get from added value
            Guid barValue = Guid.NewGuid();
            json.Bar = barValue;
            Assert.That((Guid)json.Bar, Is.EqualTo(barValue));
            Assert.That(barValue, Is.EqualTo((Guid)json.Bar));
            Assert.That((Guid)json.Bar, Is.EqualTo(barValue));

            // Also works as a string
            Assert.That((string)json.Foo, Is.EqualTo(fooValue.ToString()));
            Assert.IsTrue(fooValue.ToString() == json.Foo);
            Assert.IsTrue(json.Foo == fooValue.ToString());

            Assert.That((string)json.Bar, Is.EqualTo(barValue.ToString()));
            Assert.IsTrue(barValue.ToString() == json.Bar);
            Assert.IsTrue(json.Bar == barValue.ToString());

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { Guid g = (Guid)json.Foo; });
        }

        [Test]
        public void CanExplicitCastToDateTime()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            DateTime dateTime = DateTime.UtcNow;
            string dateTimeString = FormatDateTime(dateTime);
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{dateTimeString}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.That((DateTime)json.Foo, Is.EqualTo(dateTime));
            Assert.That(dateTime, Is.EqualTo((DateTime)json.Foo));
            Assert.That((DateTime)json.Foo, Is.EqualTo(dateTime));

            // Get from assigned existing value
            DateTime fooValue = DateTime.UtcNow.AddDays(1);
            json.Foo = fooValue;
            Assert.That((DateTime)json.Foo, Is.EqualTo(fooValue));
            Assert.That(fooValue, Is.EqualTo((DateTime)json.Foo));
            Assert.That((DateTime)json.Foo, Is.EqualTo(fooValue));

            // Get from added value
            DateTime barValue = DateTime.UtcNow.AddDays(2);
            json.Bar = barValue;
            Assert.That((DateTime)json.Bar, Is.EqualTo(barValue));
            Assert.That(barValue, Is.EqualTo((DateTime)json.Bar));
            Assert.That((DateTime)json.Bar, Is.EqualTo(barValue));

            // Also works as a string
            string fooValueString = FormatDateTime(fooValue);
            Assert.That((string)json.Foo, Is.EqualTo(fooValueString));
            Assert.IsTrue(fooValueString == json.Foo);
            Assert.IsTrue(json.Foo == fooValueString);

            string barValueString = FormatDateTime(barValue);
            Assert.That((string)json.Bar, Is.EqualTo(barValueString));
            Assert.IsTrue(barValueString == json.Bar);
            Assert.IsTrue(json.Bar == barValueString);

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { DateTime g = (DateTime)json.Foo; });
        }

        [Test]
        public void CanExplicitCastToDateTimeOffset()
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            DateTimeOffset dateTime = DateTimeOffset.UtcNow;
            string dateTimeString = FormatDateTimeOffset(dateTime);
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{dateTimeString}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.That((DateTimeOffset)json.Foo, Is.EqualTo(dateTime));
            Assert.That(dateTime, Is.EqualTo((DateTimeOffset)json.Foo));
            Assert.That((DateTimeOffset)json.Foo, Is.EqualTo(dateTime));

            // Get from assigned existing value
            DateTimeOffset fooValue = DateTimeOffset.UtcNow.AddDays(1);
            json.Foo = fooValue;
            Assert.That((DateTimeOffset)json.Foo, Is.EqualTo(fooValue));
            Assert.That(fooValue, Is.EqualTo((DateTimeOffset)json.Foo));
            Assert.That((DateTimeOffset)json.Foo, Is.EqualTo(fooValue));

            // Get from added value
            DateTimeOffset barValue = DateTimeOffset.UtcNow.AddDays(2);
            json.Bar = barValue;
            Assert.That((DateTimeOffset)json.Bar, Is.EqualTo(barValue));
            Assert.That(barValue, Is.EqualTo((DateTimeOffset)json.Bar));
            Assert.That((DateTimeOffset)json.Bar, Is.EqualTo(barValue));

            // Also works as a string
            string fooValueString = FormatDateTimeOffset(fooValue);
            Assert.That((string)json.Foo, Is.EqualTo(fooValueString));
            Assert.IsTrue(fooValueString == json.Foo);
            Assert.IsTrue(json.Foo == fooValueString);

            string barValueString = FormatDateTimeOffset(barValue);
            Assert.That((string)json.Bar, Is.EqualTo(barValueString));
            Assert.IsTrue(barValueString == json.Bar);
            Assert.IsTrue(json.Bar == barValueString);

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { DateTimeOffset d = (DateTimeOffset)json.Foo; });
        }

        internal static string FormatDateTime(DateTime d)
        {
            return d.ToUniversalTime().ToString("o");
        }

        internal static string FormatDateTimeOffset(DateTimeOffset d)
        {
            return d.ToUniversalTime().UtcDateTime.ToString("o");
        }

        [Test]
        public void CanRoundTripUnixDateTime()
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                DateTimeFormat = "x"
            };

            dynamic value = BinaryData.FromString("""{ "foo": 0 }""").ToDynamicFromJson(options);

            // Existing value
            value.Foo = DateTimeOffset.UtcNow;

            // New Value
            value.Bar = DateTimeOffset.UtcNow.AddDays(1);

            void validate(dynamic a, dynamic b)
            {
                Assert.That((long)b, Is.EqualTo((long)a));
                Assert.That((DateTime)b, Is.EqualTo((DateTime)a));
                Assert.That((DateTimeOffset)b, Is.EqualTo((DateTimeOffset)a));
            }

            string json = value.ToString();
            dynamic fromString = BinaryData.FromString(json).ToDynamicFromJson(options);
            validate(value.Foo, fromString.Foo);
            validate(value.Bar, fromString.Bar);

            BinaryData data = GetWriteToBuffer(value);
            dynamic fromWriteTo = data.ToDynamicFromJson(options);
            validate(value.Foo, fromWriteTo.Foo);
            validate(value.Bar, fromWriteTo.Bar);
        }

        [Test]
        public void ThrowsOnNonUtcDateTimeAssignment()
        {
            dynamic value = BinaryData.FromString("""{ "foo": 0 }""").ToDynamicFromJson();

            Assert.Throws<NotSupportedException>(() => value.Foo = DateTime.Now);
        }

        [Test]
        public void CanDifferentiateBetweenNullAndAbsent()
        {
            dynamic json = BinaryData.FromString("""{ "foo": null }""").ToDynamicFromJson();

            // GetMember binding mirrors Azure SDK models, so we allow a null check for an optional
            // property through the C#-style dynamic interface.
            Assert.IsTrue(json.foo == null);
            Assert.AreEqual(null, json.foo);
            Assert.IsTrue(json.bar == null);
            Assert.AreEqual(null, json.bar);

            // Indexer lookup mimics JsonNode behavior and so throws if a property is absent.
            Assert.IsTrue(json["foo"] == null);
            Assert.AreEqual(null, json["foo"]);
            Assert.Throws<KeyNotFoundException>(() => _ = json["bar"]);
            Assert.Throws<KeyNotFoundException>(() => { if (json["bar"] == null) {; } });
        }
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            json[1] = 2;
            json[2] = null;
            json[3] = "string";

            Assert.AreEqual("[0,2,null,\"string\"]", json.ToString());
        }

        [Test]
        public void ExistingObjectPropertiesCanBeAssigned()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{\"a\":1}");

            json.a = "2";

            Assert.AreEqual("{\"a\":\"2\"}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void NewObjectPropertiesCanBeAssignedWithPrimitive<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = value;

            Assert.AreEqual("{\"a\":" + expected + "}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void PrimitiveValuesCanBeParsedDirectly<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson(expected);

            Assert.That((T)json, Is.EqualTo(value));
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithArrays()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = new bool[] { true, false, true, false };

            Assert.AreEqual("{\"a\":[true,false,true,false]}", json.ToString());
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObject()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = DynamicJsonTests.GetDynamicJson("{}");
            json.a.b = 2;

            Assert.AreEqual("{\"a\":{\"b\":2}}", json.ToString());
        }

        [Test]
        public void NewObjectPropertiesCannotBeAssignedViaReferences()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");
            dynamic anotherJson = DynamicJsonTests.GetDynamicJson("{}");

            json.a = anotherJson;

            // DynamicData uses value semantics, so this has no effect on the parent
            anotherJson.b = 2;

            Assert.AreEqual("{\"a\":{}}", json.ToString());
            Assert.AreEqual("{\"b\":2}", anotherJson.ToString());

            // Value can still be updated on the object directly
            json.a.b = 2;

            Assert.AreEqual("{\"a\":{\"b\":2}}", json.ToString());
        }

        [Test]
        [Ignore("Not an allowed type")]
        public void NewObjectPropertiesCanBeAssignedWithSerializedObject()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = new GeoPoint(1, 2);

            Assert.AreEqual("{\"a\":{\"type\":\"Point\",\"coordinates\":[1,2]}}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void CanModifyNestedProperties<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{\"a\":{\"b\":2}}");

            json.a.b = value;

            Assert.AreEqual("{\"a\":{\"b\":" + expected + "}}", json.ToString());
            Assert.That((T)json.a.b, Is.EqualTo(value));

            dynamic reparsedJson = DynamicJsonTests.GetDynamicJson(json.ToString());

            Assert.That((T)reparsedJson.a.b, Is.EqualTo(value));
        }
        [Test]
        public void DynamicCanConvertToString() => Assert.That(JsonAsType<string>("\"string\""), Is.EqualTo("string"));

        [Test]
        public void DynamicCanConvertToInt() => Assert.That(JsonAsType<int>("5"), Is.EqualTo(5));

        [Test]
        public void DynamicCanConvertToLong() => Assert.That(JsonAsType<long>("5"), Is.EqualTo(5L));

        [Test]
        public void DynamicCanConvertToBool() => Assert.That(JsonAsType<bool>("true"), Is.EqualTo(true));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.That(JsonAsType<string>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.That(JsonAsType<int?>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.That(JsonAsType<long?>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableBool() => Assert.That(JsonAsType<bool?>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToIEnumerableDynamic()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[1, null, \"s\"]");
            int i = 0;
            foreach (var dynamicItem in jsonData)
            {
                switch (i)
                {
                    case 0:
                        Assert.That((int)dynamicItem, Is.EqualTo(1));
                        break;
                    case 1:
                        Assert.That((string)dynamicItem, Is.EqualTo(null));
                        break;
                    case 2:
                        Assert.That((string)dynamicItem, Is.EqualTo("s"));
                        break;
                    default:
                        Assert.Fail();
                        break;
                }

                i++;
            }
            Assert.That(i, Is.EqualTo(3));
        }

        [Test]
        public void DynamicCanConvertToIEnumerableInt()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");
            int i = 0;
            foreach (int dynamicItem in jsonData)
            {
                Assert.That(dynamicItem, Is.EqualTo(i));

                i++;
            }
            Assert.That(i, Is.EqualTo(4));
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("""
                {
                  "primitive" : "Hello",
                  "nested" : {
                      "nestedPrimitive": true
                 }
              }
            """);

            Assert.That((string)jsonData.primitive, Is.EqualTo("Hello"));
            Assert.That((bool)jsonData.nested.nestedPrimitive, Is.EqualTo(true));
        }

        [Test]
        public void CanRoundTripSerialize()
        {
            dynamic orig = new BinaryData(
                """
                {
                    "property" : "hello"
                }
                """).ToDynamicFromJson();

            void validate(dynamic d)
            {
                Assert.IsTrue(d.property == "hello");

                int count = 0;
                foreach (dynamic item in d)
                {
                    count++;
                }

                Assert.That(count, Is.EqualTo(1));
            }

            validate(orig);

            dynamic roundTrip = JsonSerializer.Deserialize<DynamicData>(JsonSerializer.Serialize(orig, orig.GetType()));

            validate(roundTrip);
        }

        #region Helpers
        internal static dynamic GetDynamicJson(string json)
        {
            DynamicDataOptions options = new() { PropertyNameFormat = JsonPropertyNames.CamelCase };
            return new BinaryData(json).ToDynamicFromJson(options);
        }

        public static IEnumerable<object[]> NumberValues()
        {
            // Valid ranges:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            yield return new object[] { "42", (byte)42, (byte)43, (byte)44, 256 };
            yield return new object[] { "42", (sbyte)42, (sbyte)43, (sbyte)44, 128 };
            yield return new object[] { "42", (short)42, (short)43, (short)44, 32768 };
            yield return new object[] { "42", (ushort)42, (ushort)43, (ushort)44, 65536 };
            yield return new object[] { "42", 42, 43, 44, 2147483648 };
            yield return new object[] { "42", 42u, 43u, 44u, 4294967296 };
            yield return new object[] { "42", 42L, 43L, 44L, 9223372036854775808 };
            yield return new object[] { "42", 42ul, 43ul, 44ul, -1 };
            yield return new object[] { "42.1", 42.1f, 43.1f, 44.1f, false /* don't test range */ };
            yield return new object[] { "42.1", 42.1d, 43.1d, 44.1d, false /* don't test range */ };
            yield return new object[] { "42.1", 42.1m, 43.1m, 44.1m, false /* don't test range */ };
        }

        public static IEnumerable<object[]> PrimitiveValues()
        {
            yield return new object[] { "string", "\"string\"" };
            yield return new object[] { 1L, "1" };
            yield return new object[] { 1, "1" };
            yield return new object[] { 1.0, "1" };
#if NETCOREAPP
            yield return new object[] { 1.1D, "1.1" };
            yield return new object[] { 1.1F, "1.1" };
#else
            yield return new object[] { 1.1D, "1.1000000000000001" };
            yield return new object[] { 1.1F, "1.10000002" };
#endif
            yield return new object[] { 1.1M, "1.1" };
            yield return new object[] { true, "true" };
            yield return new object[] { false, "false" };
            yield return new object[] { 1U, "1" };
            yield return new object[] { 1UL, "1" };
            yield return new object[] { (byte)1, "1" };
            yield return new object[] { (sbyte)1, "1" };
            yield return new object[] { (short)1, "1" };
            yield return new object[] { (ushort)1, "1" };
        }

        internal class CustomType
        {
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        internal class ParentModel : IEquatable<ParentModel>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public string Name { get; set; }
            public ChildModel Value { get; set; }

            public override bool Equals(object obj)
            {
                ParentModel other = obj as ParentModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(ParentModel obj)
            {
                return Name == obj.Name && Value.Equals(obj.Value);
            }
        }

        internal class ChildModel : IEquatable<ChildModel>
        {
            public string Message { get; set; }
            public int Number { get; set; }

            public override bool Equals(object obj)
            {
                ChildModel other = obj as ChildModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(ChildModel obj)
            {
                return Message == obj.Message && Number == obj.Number;
            }
        }
        private T JsonAsType<T>(string json)
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson(json);
            return (T)jsonData;
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        internal class SampleModel : IEquatable<SampleModel>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public SampleModel() { }

            public string Message { get; set; }
            public int Number { get; set; }

            public SampleModel(string message, int number)
            {
                Message = message;
                Number = number;
            }

            public override bool Equals(object obj)
            {
                SampleModel other = obj as SampleModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(SampleModel obj)
            {
                return Message == obj.Message && Number == obj.Number;
            }
        }
        #endregion
    }
}
