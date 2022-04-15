// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TToEntityPropertyConverterFactoryTests
    {
        private static DateTime _minimumValidDateTimeValue = new DateTime(1601, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        private static DateTimeOffset _minimumValidDateTimeOffsetValue = new DateTimeOffset(_minimumValidDateTimeValue);

        [Test]
        public void Create_EntityProperty_CanConvert()
        {
            // Act
            IConverter<EntityProperty, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<EntityProperty>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty expected = new EntityProperty(1);
            EntityProperty property = converter.Convert(expected);
            Assert.AreSame(expected, property);
        }

        [Theory]
        [TestCase(false)]
        [TestCase(true)]
        public void Create_Boolean_CanConvert(bool expectedValue)
        {
            // Act
            IConverter<bool, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<bool>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Boolean, property.PropertyType);
            Assert.True(property.BooleanValue.HasValue);
            Assert.AreEqual(expectedValue, property.BooleanValue.Value);
        }

        [Theory]
        [TestCase(false)]
        [TestCase(true)]
        public void Create_NullableBoolean_CanConvert(bool expectedValue)
        {
            // Act
            IConverter<bool?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<bool?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Boolean, property.PropertyType);
            Assert.True(property.BooleanValue.HasValue);
            Assert.AreEqual(expectedValue, property.BooleanValue.Value);
        }

        [Test]
        public void Create_NullableBoolean_CanConvertNull()
        {
            // Act
            IConverter<bool?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<bool?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Boolean, property.PropertyType);
            Assert.False(property.BooleanValue.HasValue);
        }

        [Test]
        public void Create_ByteArray_CanConvert()
        {
            // Act
            IConverter<byte[], EntityProperty> converter = TToEntityPropertyConverterFactory.Create<byte[]>();
            // Assert
            Assert.NotNull(converter);
            byte[] expected = new byte[] { 0x12 };
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Binary, property.PropertyType);
            Assert.AreSame(expected, property.BinaryValue);
        }

        [Test]
        public void Create_DateTime_CanConvert()
        {
            // Act
            IConverter<DateTime, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime>();
            // Assert
            Assert.NotNull(converter);
            DateTime expected = DateTime.Now;
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTime.HasValue);
            Assert.AreEqual(expected, property.DateTime.Value);
        }

        [Test]
        public void Create_DateTime_CanConvertMinimumValidValue()
        {
            // Act
            IConverter<DateTime, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(_minimumValidDateTimeValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTime.HasValue);
            Assert.AreEqual(_minimumValidDateTimeValue, property.DateTime.Value);
        }

        [Test]
        public void Create_DateTime_ConvertLessThanMinimumValidValueThrows()
        {
            // Act
            IConverter<DateTime, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime>();
            // Assert
            Assert.NotNull(converter);
            DateTime value = _minimumValidDateTimeValue.AddTicks(-1);
            ExceptionAssert.ThrowsArgumentOutOfRange(() => converter.Convert(value), "input", "Azure Tables cannot " +
                                                                                              "store DateTime values before the year 1601. Did you mean to use a nullable DateTime?");
        }

        [Test]
        public void Create_NullableDateTime_CanConvert()
        {
            // Act
            IConverter<DateTime?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime?>();
            // Assert
            Assert.NotNull(converter);
            DateTime? expected = DateTime.Now;
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTime.HasValue);
            Assert.AreEqual(expected, property.DateTime.Value);
        }

        [Test]
        public void Create_NullableDateTime_CanConvertNull()
        {
            // Act
            IConverter<DateTime?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.False(property.DateTime.HasValue);
        }

        [Test]
        public void Create_NullableDateTime_CanConvertMinimumValidValue()
        {
            // Act
            IConverter<DateTime?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(_minimumValidDateTimeValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTime.HasValue);
            Assert.AreEqual(_minimumValidDateTimeValue, property.DateTime.Value);
        }

        [Test]
        public void Create_NullableDateTime_ConvertLessThanMinimumValidValueThrows()
        {
            // Act
            IConverter<DateTime?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<DateTime?>();
            // Assert
            Assert.NotNull(converter);
            DateTime value = _minimumValidDateTimeValue.AddTicks(-1);
            ExceptionAssert.ThrowsArgumentOutOfRange(() => converter.Convert(value), "input", "Azure Tables cannot " +
                                                                                              "store DateTime values before the year 1601. Did you mean to use a nullable DateTime?");
        }

        [Test]
        public void Create_DateTimeOffset_CanConvert()
        {
            // Act
            IConverter<DateTimeOffset, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset expected = DateTimeOffset.UtcNow;
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTimeOffsetValue.HasValue);
            Assert.AreEqual(expected, property.DateTimeOffsetValue.Value);
        }

        [Test]
        public void Create_DateTimeOffset_CanConvertMinimumValidValue()
        {
            // Act
            IConverter<DateTimeOffset, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(_minimumValidDateTimeOffsetValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTimeOffsetValue.HasValue);
            Assert.AreEqual(_minimumValidDateTimeOffsetValue, property.DateTimeOffsetValue.Value);
        }

        [Test]
        public void Create_DateTimeOffset_ConvertLessThanMinimumValidValueThrows()
        {
            // Act
            IConverter<DateTimeOffset, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset value = _minimumValidDateTimeOffsetValue.AddTicks(-1);
            ExceptionAssert.ThrowsArgumentOutOfRange(() => converter.Convert(value), "input", "Azure Tables cannot " +
                "store DateTime values before the year 1601. Did you mean to use a nullable DateTime?");
        }

        [Test]
        public void Create_NullableDateTimeOffset_CanConvert()
        {
            // Act
            IConverter<DateTimeOffset?, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset?>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset? expected = DateTimeOffset.Now;
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTimeOffsetValue.HasValue);
            Assert.AreEqual(expected, property.DateTimeOffsetValue.Value);
        }

        [Test]
        public void Create_NullableDateTimeOffset_CanConvertNull()
        {
            // Act
            IConverter<DateTimeOffset?, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.False(property.DateTimeOffsetValue.HasValue);
        }

        [Test]
        public void Create_NullableDateTimeOffset_CanConvertMinimumValidValue()
        {
            // Act
            IConverter<DateTimeOffset?, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(_minimumValidDateTimeOffsetValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.DateTime, property.PropertyType);
            Assert.True(property.DateTimeOffsetValue.HasValue);
            Assert.AreEqual(_minimumValidDateTimeOffsetValue, property.DateTimeOffsetValue.Value);
        }

        [Test]
        public void Create_NullableDateTimeOffset_ConvertLessThanMinimumValidValueThrows()
        {
            // Act
            IConverter<DateTimeOffset?, EntityProperty> converter =
                TToEntityPropertyConverterFactory.Create<DateTimeOffset?>();
            // Assert
            Assert.NotNull(converter);
            DateTimeOffset value = _minimumValidDateTimeOffsetValue.AddTicks(-1);
            ExceptionAssert.ThrowsArgumentOutOfRange(() => converter.Convert(value), "input", "Azure Tables cannot " +
                                                                                              "store DateTime values before the year 1601. Did you mean to use a nullable DateTime?");
        }

        [Test]
        public void Create_Double_CanConvert()
        {
            // Act
            IConverter<double, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<double>();
            // Assert
            Assert.NotNull(converter);
            const double expectedValue = 3.14;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Double, property.PropertyType);
            Assert.True(property.DoubleValue.HasValue);
            Assert.AreEqual(expectedValue, property.DoubleValue.Value);
        }

        [Test]
        public void Create_NullableDouble_CanConvert()
        {
            // Act
            IConverter<double?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<double?>();
            // Assert
            Assert.NotNull(converter);
            const double expectedValue = 3.14;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Double, property.PropertyType);
            Assert.True(property.DoubleValue.HasValue);
            Assert.AreEqual(expectedValue, property.DoubleValue.Value);
        }

        [Test]
        public void Create_NullableDouble_CanConvertNull()
        {
            // Act
            IConverter<double?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<double?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Double, property.PropertyType);
            Assert.False(property.DoubleValue.HasValue);
        }

        [Test]
        public void Create_Guid_CanConvert()
        {
            // Act
            IConverter<Guid, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<Guid>();
            // Assert
            Assert.NotNull(converter);
            Guid expectedValue = Guid.NewGuid();
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Guid, property.PropertyType);
            Assert.True(property.GuidValue.HasValue);
            Assert.AreEqual(expectedValue, property.GuidValue.Value);
        }

        [Test]
        public void Create_NullableGuid_CanConvert()
        {
            // Act
            IConverter<Guid?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<Guid?>();
            // Assert
            Assert.NotNull(converter);
            Guid expectedValue = Guid.NewGuid();
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Guid, property.PropertyType);
            Assert.True(property.GuidValue.HasValue);
            Assert.AreEqual(expectedValue, property.GuidValue.Value);
        }

        [Test]
        public void Create_NullableGuid_CanConvertNull()
        {
            // Act
            IConverter<Guid?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<Guid?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Guid, property.PropertyType);
            Assert.False(property.GuidValue.HasValue);
        }

        [Test]
        public void Create_Int32_CanConvert()
        {
            // Act
            IConverter<int, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<int>();
            // Assert
            Assert.NotNull(converter);
            const int expectedValue = 123;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int32, property.PropertyType);
            Assert.True(property.Int32Value.HasValue);
            Assert.AreEqual(expectedValue, property.Int32Value.Value);
        }

        [Test]
        public void Create_NullableInt32_CanConvert()
        {
            // Act
            IConverter<int?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<int?>();
            // Assert
            Assert.NotNull(converter);
            const int expectedValue = 123;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int32, property.PropertyType);
            Assert.True(property.Int32Value.HasValue);
            Assert.AreEqual(expectedValue, property.Int32Value.Value);
        }

        [Test]
        public void Create_NullableInt32_CanConvertNull()
        {
            // Act
            IConverter<int?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<int?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int32, property.PropertyType);
            Assert.False(property.Int32Value.HasValue);
        }

        [Test]
        public void Create_Int64_CanConvert()
        {
            // Act
            IConverter<long, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<long>();
            // Assert
            Assert.NotNull(converter);
            const long expectedValue = 123;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int64, property.PropertyType);
            Assert.True(property.Int64Value.HasValue);
            Assert.AreEqual(expectedValue, property.Int64Value.Value);
        }

        [Test]
        public void Create_NullableInt64_CanConvert()
        {
            // Act
            IConverter<long?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<long?>();
            // Assert
            Assert.NotNull(converter);
            const long expectedValue = 123;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int64, property.PropertyType);
            Assert.True(property.Int64Value.HasValue);
            Assert.AreEqual(expectedValue, property.Int64Value.Value);
        }

        [Test]
        public void Create_NullableInt64_CanConvertNull()
        {
            // Act
            IConverter<long?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<long?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.Int64, property.PropertyType);
            Assert.False(property.Int64Value.HasValue);
        }

        [Test]
        public void Create_String_CanConvert()
        {
            // Act
            IConverter<string, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<string>();
            // Assert
            Assert.NotNull(converter);
            const string expected = "abc";
            EntityProperty property = converter.Convert(expected);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.AreSame(expected, property.StringValue);
        }

        [Test]
        public void Create_Enum_CanConvert()
        {
            // Act
            IConverter<AnEnum, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<AnEnum>();
            // Assert
            Assert.NotNull(converter);
            const AnEnum expectedValue = AnEnum.B;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.AreEqual(expectedValue.ToString(), property.StringValue);
        }

        [Test]
        public void Create_NullableEnum_CanConvert()
        {
            // Act
            IConverter<AnEnum?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<AnEnum?>();
            // Assert
            Assert.NotNull(converter);
            const AnEnum expectedValue = AnEnum.B;
            EntityProperty property = converter.Convert(expectedValue);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.AreEqual(expectedValue.ToString(), property.StringValue);
        }

        [Test]
        public void Create_NullableEnum_CanConvertNull()
        {
            // Act
            IConverter<AnEnum?, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<AnEnum?>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.Null(property.StringValue);
        }

        [Test]
        public void Create_OtherType_CanConvert()
        {
            // Act
            IConverter<Poco, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<Poco>();
            // Assert
            Assert.NotNull(converter);
            Poco original = new Poco { Value = "abc" };
            EntityProperty property = converter.Convert(original);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            string expected = JsonConvert.SerializeObject(original, Formatting.Indented);
            Assert.AreEqual(expected, property.StringValue);
        }

        [Test]
        public void Create_OtherType_CanConvertNull()
        {
            // Act
            IConverter<Poco, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<Poco>();
            // Assert
            Assert.NotNull(converter);
            EntityProperty property = converter.Convert(null);
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.AreEqual("null", property.StringValue);
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