// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class EntityPropertyToTConverterFactoryTests
    {
        [Test]
        public void Create_EntityProperty_CanConvert()
        {
            // Act
            IConverter<EntityProperty, EntityProperty> converter =
                EntityPropertyToTConverterFactory.Create<EntityProperty>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty expected = new EntityProperty(1);
            EntityProperty property = converter.Convert(expected);
            Assert.AreEqual(expected, property);
        }

        [Theory]
        [TestCase(false)]
        [TestCase(true)]
        public void Create_Boolean_CanConvert(bool expected)
        {
            // Act
            IConverter<EntityProperty, bool> converter = EntityPropertyToTConverterFactory.Create<bool>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = new EntityProperty(expected);
            bool actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Boolean_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, bool> converter = EntityPropertyToTConverterFactory.Create<bool>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Boolean_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, bool> converter = EntityPropertyToTConverterFactory.Create<bool>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Boolean");
        }

        [Test]
        public void Create_Boolean_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, bool> converter = EntityPropertyToTConverterFactory.Create<bool>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForBool(null));
        }

        [Theory]
        [TestCase(false)]
        [TestCase(true)]
        public void Create_NullableBoolean_CanConvert(bool? expected)
        {
            // Act
            IConverter<EntityProperty, bool?> converter = EntityPropertyToTConverterFactory.Create<bool?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = new EntityProperty(expected);
            bool? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableBoolean_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, bool?> converter = EntityPropertyToTConverterFactory.Create<bool?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForBool(null));
        }

        [Test]
        public void Create_NullableBoolean_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, bool?> converter = EntityPropertyToTConverterFactory.Create<bool?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableBoolean_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, bool?> converter = EntityPropertyToTConverterFactory.Create<bool?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Boolean");
        }

        [Test]
        public void Create_ByteArray_CanConvert()
        {
            // Act
            IConverter<EntityProperty, byte[]> converter = EntityPropertyToTConverterFactory.Create<byte[]>();
            // Assert
            Assert.NotNull(converter);
            byte[] expected = new byte[] { 0x12 };
            EntityProperty property = new EntityProperty(expected);
            byte[] actual = converter.Convert(property);
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Create_ByteArray_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, byte[]> converter = EntityPropertyToTConverterFactory.Create<byte[]>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_ByteArray_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, byte[]> converter = EntityPropertyToTConverterFactory.Create<byte[]>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Binary");
        }

        [Test]
        public void Create_DateTime_CanConvert()
        {
            // Act
            IConverter<EntityProperty, DateTime> converter = EntityPropertyToTConverterFactory.Create<DateTime>();
            // Assert
            Assert.NotNull(converter);
            DateTime expected = DateTime.Now;
            EntityProperty property = new EntityProperty(expected);
            DateTime actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Kind, actual.Kind);
        }

        [Test]
        public void Create_DateTime_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, DateTime> converter = EntityPropertyToTConverterFactory.Create<DateTime>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_DateTime_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, DateTime> converter = EntityPropertyToTConverterFactory.Create<DateTime>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "DateTime");
        }

        [Test]
        public void Create_DateTime_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, DateTime> converter = EntityPropertyToTConverterFactory.Create<DateTime>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForDateTimeOffset(null));
        }

        [Test]
        public void Create_NullableDateTime_CanConvert()
        {
            // Act
            IConverter<EntityProperty, DateTime?> converter = EntityPropertyToTConverterFactory.Create<DateTime?>();
            // Assert
            Assert.NotNull(converter);
            DateTime? expected = DateTime.Now;
            EntityProperty property = new EntityProperty(expected);
            DateTime? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableDateTime_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, DateTime?> converter = EntityPropertyToTConverterFactory.Create<DateTime?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForDateTimeOffset(null));
        }

        [Test]
        public void Create_NullableDateTime_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, DateTime?> converter = EntityPropertyToTConverterFactory.Create<DateTime?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableDateTime_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, DateTime?> converter = EntityPropertyToTConverterFactory.Create<DateTime?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "DateTime");
        }

        [Test]
        public void Create_DateTimeOffset_CanConvert()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            EntityProperty property = new EntityProperty(expected);
            DateTimeOffset actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Offset, actual.Offset);
        }

        [Test]
        public void Create_DateTimeOffset_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_DateTimeOffset_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "DateTime");
        }

        [Test]
        public void Create_DateTimeOffset_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForDateTimeOffset(null));
        }

        [Test]
        public void Create_NullableDateTimeOffset_CanConvert()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset?> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset?>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset? expected = DateTimeOffset.Now;
            EntityProperty property = new EntityProperty(expected);
            DateTimeOffset? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableDateTimeOffset_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset?> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForDateTimeOffset(null));
        }

        [Test]
        public void Create_NullableDateTimeOffset_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset?> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableDateTimeOffset_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, DateTimeOffset?> converter =
                EntityPropertyToTConverterFactory.Create<DateTimeOffset?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "DateTime");
        }

        [Test]
        public void Create_Double_CanConvert()
        {
            // Act
            IConverter<EntityProperty, double> converter = EntityPropertyToTConverterFactory.Create<double>();
            // Assert
            Assert.NotNull(converter);
            double expected = 3.14;
            EntityProperty property = new EntityProperty(expected);
            double actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Double_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, double> converter = EntityPropertyToTConverterFactory.Create<double>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Double_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, double> converter = EntityPropertyToTConverterFactory.Create<double>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Double");
        }

        [Test]
        public void Create_Double_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, double> converter = EntityPropertyToTConverterFactory.Create<double>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForDouble(null));
        }

        [Test]
        public void Create_NullableDouble_CanConvert()
        {
            // Act
            IConverter<EntityProperty, double?> converter = EntityPropertyToTConverterFactory.Create<double?>();
            // Assert
            Assert.NotNull(converter);
            double? expected = 3.14;
            EntityProperty property = new EntityProperty(expected);
            double? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableDouble_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, double?> converter = EntityPropertyToTConverterFactory.Create<double?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForDouble(null));
        }

        [Test]
        public void Create_NullableDouble_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, double?> converter = EntityPropertyToTConverterFactory.Create<double?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableDouble_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, double?> converter = EntityPropertyToTConverterFactory.Create<double?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Double");
        }

        [Test]
        public void Create_Guid_CanConvert()
        {
            // Act
            IConverter<EntityProperty, Guid> converter = EntityPropertyToTConverterFactory.Create<Guid>();
            // Assert
            Assert.NotNull(converter);
            Guid expected = Guid.NewGuid();
            EntityProperty property = new EntityProperty(expected);
            Guid actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Guid_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, Guid> converter = EntityPropertyToTConverterFactory.Create<Guid>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Guid_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, Guid> converter = EntityPropertyToTConverterFactory.Create<Guid>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Guid");
        }

        [Test]
        public void Create_Guid_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, Guid> converter = EntityPropertyToTConverterFactory.Create<Guid>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForGuid(null));
        }

        [Test]
        public void Create_NullableGuid_CanConvert()
        {
            // Act
            IConverter<EntityProperty, Guid?> converter = EntityPropertyToTConverterFactory.Create<Guid?>();
            // Assert
            Assert.NotNull(converter);
            Guid expected = Guid.NewGuid();
            EntityProperty property = new EntityProperty(expected);
            Guid? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableGuid_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, Guid?> converter = EntityPropertyToTConverterFactory.Create<Guid?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForGuid(null));
        }

        [Test]
        public void Create_NullableGuid_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, Guid?> converter = EntityPropertyToTConverterFactory.Create<Guid?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableGuid_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, Guid?> converter = EntityPropertyToTConverterFactory.Create<Guid?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Guid");
        }

        [Test]
        public void Create_Int32_CanConvert()
        {
            // Act
            IConverter<EntityProperty, int> converter = EntityPropertyToTConverterFactory.Create<int>();
            // Assert
            Assert.NotNull(converter);
            int expected = 123;
            EntityProperty property = new EntityProperty(expected);
            int actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Int32_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, int> converter = EntityPropertyToTConverterFactory.Create<int>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Int32_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, int> converter = EntityPropertyToTConverterFactory.Create<int>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Int32", new EntityProperty(false), "Boolean");
        }

        [Test]
        public void Create_Int32_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, int> converter = EntityPropertyToTConverterFactory.Create<int>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForInt(null));
        }

        [Test]
        public void Create_NullableInt32_CanConvert()
        {
            // Act
            IConverter<EntityProperty, int?> converter = EntityPropertyToTConverterFactory.Create<int?>();
            // Assert
            Assert.NotNull(converter);
            int? expected = 123;
            EntityProperty property = new EntityProperty(expected);
            int? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableInt32_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, int?> converter = EntityPropertyToTConverterFactory.Create<int?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForInt(null));
        }

        [Test]
        public void Create_NullableInt32_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, int?> converter = EntityPropertyToTConverterFactory.Create<int?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableInt32_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, int?> converter = EntityPropertyToTConverterFactory.Create<int?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Int32", new EntityProperty(false), "Boolean");
        }

        [Test]
        public void Create_Int64_CanConvert()
        {
            // Act
            IConverter<EntityProperty, long> converter = EntityPropertyToTConverterFactory.Create<long>();
            // Assert
            Assert.NotNull(converter);
            long expected = 123;
            EntityProperty property = new EntityProperty(expected);
            long actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Int64_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, long> converter = EntityPropertyToTConverterFactory.Create<long>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Int64_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, long> converter = EntityPropertyToTConverterFactory.Create<long>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Int64");
        }

        [Test]
        public void Create_Int64_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, long> converter = EntityPropertyToTConverterFactory.Create<long>();
            // Assert
            AssertConvertThrowsIfNullValue(converter, EntityProperty.GeneratePropertyForLong(null));
        }

        [Test]
        public void Create_NullableInt64_CanConvert()
        {
            // Act
            IConverter<EntityProperty, long?> converter = EntityPropertyToTConverterFactory.Create<long?>();
            // Assert
            Assert.NotNull(converter);
            long? expected = 123;
            EntityProperty property = new EntityProperty(expected);
            long? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableInt64_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, long?> converter = EntityPropertyToTConverterFactory.Create<long?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForLong(null));
        }

        [Test]
        public void Create_NullableInt64_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, long?> converter = EntityPropertyToTConverterFactory.Create<long?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableInt64_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, long?> converter = EntityPropertyToTConverterFactory.Create<long?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "Int64");
        }

        [Test]
        public void Create_Enum_CanConvert()
        {
            // Act
            IConverter<EntityProperty, AnEnum> converter = EntityPropertyToTConverterFactory.Create<AnEnum>();
            // Assert
            Assert.NotNull(converter);
            const AnEnum expected = AnEnum.B;
            EntityProperty property = new EntityProperty(expected.ToString());
            AnEnum actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_Enum_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, AnEnum> converter = EntityPropertyToTConverterFactory.Create<AnEnum>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_Enum_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, AnEnum> converter = EntityPropertyToTConverterFactory.Create<AnEnum>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "String");
        }

        [Test]
        public void Create_Enum_ConvertThrowsIfNullValue()
        {
            // Act
            IConverter<EntityProperty, AnEnum> converter = EntityPropertyToTConverterFactory.Create<AnEnum>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = EntityProperty.GeneratePropertyForString(null);
            ExceptionAssert.ThrowsInvalidOperation(() => converter.Convert(property),
                "Enum property value must not be null.");
        }

        [Test]
        public void Create_Enum_ConvertThrowsIfNonMemberValue()
        {
            // Act
            IConverter<EntityProperty, AnEnum> converter = EntityPropertyToTConverterFactory.Create<AnEnum>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = EntityProperty.GeneratePropertyForString("D");
            ExceptionAssert.ThrowsArgument(() => converter.Convert(property), null,
                "Requested value 'D' was not found.");
        }

        [Test]
        public void Create_NullableEnum_CanConvert()
        {
            // Act
            IConverter<EntityProperty, AnEnum?> converter = EntityPropertyToTConverterFactory.Create<AnEnum?>();
            // Assert
            Assert.NotNull(converter);
            AnEnum? expected = AnEnum.B;
            EntityProperty property = new EntityProperty(expected.ToString());
            AnEnum? actual = converter.Convert(property);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Create_NullableEnum_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, AnEnum?> converter = EntityPropertyToTConverterFactory.Create<AnEnum?>();
            // Assert
            AssertCanConvertNullValue(converter, EntityProperty.GeneratePropertyForString(null));
        }

        [Test]
        public void Create_NullableEnum_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, AnEnum?> converter = EntityPropertyToTConverterFactory.Create<AnEnum?>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_NullableEnum_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, AnEnum?> converter = EntityPropertyToTConverterFactory.Create<AnEnum?>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "String");
        }

        [Test]
        public void Create_NullableEnum_ConvertThrowsIfNonMemberValue()
        {
            // Act
            IConverter<EntityProperty, AnEnum?> converter = EntityPropertyToTConverterFactory.Create<AnEnum?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = EntityProperty.GeneratePropertyForString("D");
            ExceptionAssert.ThrowsArgument(() => converter.Convert(property), null,
                "Requested value 'D' was not found.");
        }

        [Test]
        public void Create_String_CanConvert()
        {
            // Act
            IConverter<EntityProperty, string> converter = EntityPropertyToTConverterFactory.Create<string>();
            // Assert
            Assert.NotNull(converter);
            string expected = "abc";
            EntityProperty property = new EntityProperty(expected);
            string actual = converter.Convert(property);
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Create_String_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, string> converter = EntityPropertyToTConverterFactory.Create<string>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_String_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, string> converter = EntityPropertyToTConverterFactory.Create<string>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "String");
        }

        [Test]
        public void Create_OtherType_CanConvert()
        {
            // Act
            IConverter<EntityProperty, Poco> converter = EntityPropertyToTConverterFactory.Create<Poco>();
            // Assert
            Assert.NotNull(converter);
            Poco original = new Poco { Value = "abc" };
            string expected = JsonConvert.SerializeObject(original, Formatting.Indented);
            EntityProperty property = new EntityProperty(expected);
            Poco actual = converter.Convert(property);
            Assert.NotNull(actual);
            Assert.AreEqual(original.Value, actual.Value);
        }

        [Test]
        public void Create_OtherType_CanConvertNullValue()
        {
            // Act
            IConverter<EntityProperty, Poco> converter = EntityPropertyToTConverterFactory.Create<Poco>();
            // Assert
            Assert.NotNull(converter);
            Poco original = null;
            string expected = JsonConvert.SerializeObject(original, Formatting.Indented);
            Assert.AreEqual("null", expected); // Guard
            EntityProperty property = new EntityProperty(expected);
            Poco actual = converter.Convert(property);
            Assert.Null(actual);
        }

        [Test]
        public void Create_OtherType_ConvertThrowsIfNullProperty()
        {
            // Act
            IConverter<EntityProperty, Poco> converter = EntityPropertyToTConverterFactory.Create<Poco>();
            // Assert
            AssertConvertThrowsIfNullProperty(converter);
        }

        [Test]
        public void Create_OtherType_ConvertThrowsIfPropertyTypeMismatches()
        {
            // Act
            IConverter<EntityProperty, Poco> converter = EntityPropertyToTConverterFactory.Create<Poco>();
            // Assert
            AssertConvertThrowsIfPropertyTypeMismatches(converter, "String");
        }

        [Test]
        public void Create_OtherType_ConvertThrowsIfNullStringValue()
        {
            // Act
            IConverter<EntityProperty, Poco> converter = EntityPropertyToTConverterFactory.Create<Poco>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = EntityProperty.GeneratePropertyForString(null);
            ExceptionAssert.ThrowsInvalidOperation(() => converter.Convert(property),
                "The String property must not be null for JSON objects.");
        }

        private static void AssertCanConvertNullValue<TValue>(IConverter<EntityProperty, TValue?> converter,
            EntityProperty propertyWithNullValue) where TValue : struct
        {
            if (propertyWithNullValue == null)
            {
                throw new ArgumentNullException(nameof(propertyWithNullValue));
            }
            else if (propertyWithNullValue.PropertyAsObject != null)
            {
                throw new ArgumentException("propertyWithNullValue");
            }

            Assert.NotNull(converter);
            TValue? actual = converter.Convert(propertyWithNullValue);
            Assert.False(actual.HasValue);
        }

        private static void AssertConvertThrowsIfNullProperty<TOutput>(IConverter<EntityProperty, TOutput> converter)
        {
            Assert.NotNull(converter);
            EntityProperty property = null;
            ExceptionAssert.ThrowsArgumentNull(() => converter.Convert(property), "input");
        }

        private static void AssertConvertThrowsIfNullValue<TOutput>(IConverter<EntityProperty, TOutput> converter,
            EntityProperty propertyWithNullValue)
        {
            if (propertyWithNullValue == null)
            {
                throw new ArgumentNullException(nameof(propertyWithNullValue));
            }
            else if (propertyWithNullValue.PropertyAsObject != null)
            {
                throw new ArgumentException("propertyWithNullValue");
            }

            // Assert
            Assert.NotNull(converter);
            ExceptionAssert.ThrowsInvalidOperation(() => converter.Convert(propertyWithNullValue),
                "Nullable object must have a value.");
        }

        private static void AssertConvertThrowsIfPropertyTypeMismatches<TOutput>(
            IConverter<EntityProperty, TOutput> converter, string expectedTypeName)
        {
            if (typeof(TOutput) == typeof(int) || typeof(TOutput) == typeof(int?))
            {
                throw new InvalidOperationException("This test helper only works with non-Int32 types.");
            }

            AssertConvertThrowsIfPropertyTypeMismatches(converter, expectedTypeName, new EntityProperty(0), "Int32");
        }

        private static void AssertConvertThrowsIfPropertyTypeMismatches<TOutput>(
            IConverter<EntityProperty, TOutput> converter,
            string expectedTypeName,
            EntityProperty actualProperty,
            string actualTypeName)
        {
            Assert.NotNull(converter);
            EntityProperty property = actualProperty;
            ExceptionAssert.ThrowsInvalidOperation(() => converter.Convert(property),
                "Cannot return " + expectedTypeName + " type for a " + actualTypeName + " typed property.");
        }

        private class Poco
        {
            public string Value { get; set; }
        }

        private enum AnEnum
        {
            A,
            B,
            C
        }
    }
}