// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Cosmos.Table;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class PocoToTableEntityConverterTests
    {
        [Test]
        public void Create_ReturnsInstance()
        {
            // Act
            IConverter<Poco, ITableEntity> converter = PocoToTableEntityConverter<Poco>.Create();
            // Assert
            Assert.NotNull(converter);
        }

        [Test]
        public void Create_IfPartitionKeyIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => PocoToTableEntityConverter<PocoWithNonStringPartitionKey>.Create(),
                "If the PartitionKey property is present, it must be a String.");
        }

        [Test]
        public void Create_IfPartitionKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => PocoToTableEntityConverter<PocoWithIndexerPartitionKey>.Create(),
                "If the PartitionKey property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfRowKeyIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => PocoToTableEntityConverter<PocoWithNonStringRowKey>.Create(),
                "If the RowKey property is present, it must be a String.");
        }

        [Test]
        public void Create_IfRowKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => PocoToTableEntityConverter<PocoWithIndexerRowKey>.Create(),
                "If the RowKey property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfTimestampIsNonDateTimeOffset_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => PocoToTableEntityConverter<PocoWithNonDateTimeOffsetTimestamp>.Create(),
                "If the Timestamp property is present, it must be a DateTimeOffset.");
        }

        [Test]
        public void Create_IfTimestampHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => PocoToTableEntityConverter<PocoWithIndexerTimestamp>.Create(),
                "If the Timestamp property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfETagIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => PocoToTableEntityConverter<PocoWithNonStringETag>.Create(),
                "If the ETag property is present, it must be a String.");
        }

        [Test]
        public void Create_IfETagHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => PocoToTableEntityConverter<PocoWithIndexerETag>.Create(),
                "If the ETag property is present, it must not be an indexer.");
        }

        [Test]
        public void Convert_IfInputIsNull_ReturnsNull()
        {
            // Arrange
            IConverter<Poco, ITableEntity> product = CreateProductUnderTest<Poco>();
            Poco input = null;
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void Convert_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPartitionKey, ITableEntity> product = CreateProductUnderTest<PocoWithPartitionKey>();
            PocoWithPartitionKey input = new PocoWithPartitionKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsReadOnly_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithReadOnlyPartitionKey, ITableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyPartitionKey>();
            PocoWithReadOnlyPartitionKey input = new PocoWithReadOnlyPartitionKey
            {
                WritePartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_DoesNotIncludePartitionKeyInDictionary()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPartitionKey, ITableEntity> product = CreateProductUnderTest<PocoWithPartitionKey>();
            PocoWithPartitionKey input = new PocoWithPartitionKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("PartitionKey"));
        }

        [Test]
        public void Convert_IfPartitionKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithPrivatePartitionKey, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKey>();
            PocoWithPrivatePartitionKey input = new PocoWithPrivatePartitionKey
            {
                PartitionKeyPublic = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.PartitionKey);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfPartitionKeyGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithPrivatePartitionKeyGetter, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKeyGetter>();
            PocoWithPrivatePartitionKeyGetter input = new PocoWithPrivatePartitionKeyGetter
            {
                PartitionKey = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.PartitionKey);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsStatic_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithStaticPartitionKey, ITableEntity> product =
                CreateProductUnderTest<PocoWithStaticPartitionKey>();
            PocoWithStaticPartitionKey.PartitionKey = "UnexpectedPK";
            PocoWithStaticPartitionKey input = new PocoWithStaticPartitionKey
            {
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.PartitionKey);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithWriteOnlyPartitionKey, ITableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyPartitionKey>();
            PocoWithWriteOnlyPartitionKey input = new PocoWithWriteOnlyPartitionKey
            {
                PartitionKey = "IgnorePK",
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.PartitionKey);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_PopulatesRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithRowKey, ITableEntity> product = CreateProductUnderTest<PocoWithRowKey>();
            PocoWithRowKey input = new PocoWithRowKey
            {
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfRowKeyIsReadOnly_PopulatesRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithReadOnlyRowKey, ITableEntity> product = CreateProductUnderTest<PocoWithReadOnlyRowKey>();
            PocoWithReadOnlyRowKey input = new PocoWithReadOnlyRowKey
            {
                WriteRowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_DoesNotIncludeRowKeyInDictionary()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithRowKey, ITableEntity> product = CreateProductUnderTest<PocoWithRowKey>();
            PocoWithRowKey input = new PocoWithRowKey
            {
                RowKey = expectedRowKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("RowKey"));
        }

        [Test]
        public void Convert_IfRowKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateRowKey, ITableEntity> product = CreateProductUnderTest<PocoWithPrivateRowKey>();
            PocoWithPrivateRowKey input = new PocoWithPrivateRowKey
            {
                PartitionKey = expectedPartitionKey,
                RowKeyPublic = "UnexpectedRK"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.RowKey);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfRowKeyGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateRowKeyGetter, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateRowKeyGetter>();
            PocoWithPrivateRowKeyGetter input = new PocoWithPrivateRowKeyGetter
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "UnexpectedRK"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.RowKey);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfRowKeyIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticRowKey, ITableEntity> product = CreateProductUnderTest<PocoWithStaticRowKey>();
            PocoWithStaticRowKey.RowKey = "UnexpectedRK";
            PocoWithStaticRowKey input = new PocoWithStaticRowKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.RowKey);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfRowKeyIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyRowKey, ITableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyRowKey>();
            PocoWithWriteOnlyRowKey input = new PocoWithWriteOnlyRowKey
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "IgnoreRK"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.RowKey);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<PocoWithTimestamp, ITableEntity> product = CreateProductUnderTest<PocoWithTimestamp>();
            PocoWithTimestamp input = new PocoWithTimestamp
            {
                Timestamp = expectedTimestamp
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Offset);
        }

        [Test]
        public void Convert_IfTimestampIsReadOnly_PopulatesTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<PocoWithReadOnlyTimestamp, ITableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyTimestamp>();
            PocoWithReadOnlyTimestamp input = new PocoWithReadOnlyTimestamp
            {
                WriteTimestamp = expectedTimestamp
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Offset);
        }

        [Test]
        public void Convert_DoesNotIncludeTimestampInDictionary()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<PocoWithTimestamp, ITableEntity> product = CreateProductUnderTest<PocoWithTimestamp>();
            PocoWithTimestamp input = new PocoWithTimestamp
            {
                Timestamp = expectedTimestamp
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Offset);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("Timestamp"));
        }

        [Test]
        public void Convert_IfTimestampIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateTimestamp, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateTimestamp>();
            PocoWithPrivateTimestamp input = new PocoWithPrivateTimestamp
            {
                PartitionKey = expectedPartitionKey,
                TimestampPublic = DateTimeOffset.Now
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateTimestampGetter, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateTimestampGetter>();
            PocoWithPrivateTimestampGetter input = new PocoWithPrivateTimestampGetter
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticTimestamp, ITableEntity> product =
                CreateProductUnderTest<PocoWithStaticTimestamp>();
            PocoWithStaticTimestamp.Timestamp = DateTimeOffset.Now;
            PocoWithStaticTimestamp input = new PocoWithStaticTimestamp
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyTimestamp, ITableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyTimestamp>();
            PocoWithWriteOnlyTimestamp input = new PocoWithWriteOnlyTimestamp
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<PocoWithETag, ITableEntity> product = CreateProductUnderTest<PocoWithETag>();
            PocoWithETag input = new PocoWithETag
            {
                ETag = expectedETag
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ETag);
        }

        [Test]
        public void Convert_IfETagIsReadOnly_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<PocoWithReadOnlyETag, ITableEntity> product = CreateProductUnderTest<PocoWithReadOnlyETag>();
            PocoWithReadOnlyETag input = new PocoWithReadOnlyETag
            {
                WriteETag = expectedETag
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ETag);
        }

        [Test]
        public void Convert_DoesNotIncludeETagInDictionary()
        {
            // Arrange
            const string expectedETag = "RK";
            IConverter<PocoWithETag, ITableEntity> product = CreateProductUnderTest<PocoWithETag>();
            PocoWithETag input = new PocoWithETag
            {
                ETag = expectedETag
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ETag);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("ETag"));
        }

        [Test]
        public void Convert_IfETagIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateETag, ITableEntity> product = CreateProductUnderTest<PocoWithPrivateETag>();
            PocoWithPrivateETag input = new PocoWithPrivateETag
            {
                PartitionKey = expectedPartitionKey,
                ETagPublic = "UnexpectedETag"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateETagGetter, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateETagGetter>();
            PocoWithPrivateETagGetter input = new PocoWithPrivateETagGetter
            {
                PartitionKey = expectedPartitionKey,
                ETag = "UnexpectedETag"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticETag, ITableEntity> product = CreateProductUnderTest<PocoWithStaticETag>();
            PocoWithStaticETag.ETag = "UnexpectedETag";
            PocoWithStaticETag input = new PocoWithStaticETag
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyETag, ITableEntity> product = CreateProductUnderTest<PocoWithWriteOnlyETag>();
            PocoWithWriteOnlyETag input = new PocoWithWriteOnlyETag
            {
                PartitionKey = expectedPartitionKey,
                ETag = "IgnoreETag"
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<PocoWithOtherProperty, ITableEntity> product = CreateProductUnderTest<PocoWithOtherProperty>();
            PocoWithOtherProperty input = new PocoWithOtherProperty
            {
                OtherProperty = expectedOtherProperty
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey("OtherProperty"));
            EntityProperty otherProperty = properties["OtherProperty"];
            Assert.NotNull(otherProperty);
            Assert.AreEqual(EdmType.Int32, otherProperty.PropertyType);
            Assert.AreEqual(expectedOtherProperty, otherProperty.Int32Value);
        }

        [Test]
        public void Convert_IfOtherPropertyIsReadOnly_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<PocoWithReadOnlyOtherProperty, ITableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyOtherProperty>();
            PocoWithReadOnlyOtherProperty input = new PocoWithReadOnlyOtherProperty
            {
                WriteOtherProperty = expectedOtherProperty
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey("OtherProperty"));
            EntityProperty otherProperty = properties["OtherProperty"];
            Assert.NotNull(otherProperty);
            Assert.AreEqual(EdmType.Int32, otherProperty.PropertyType);
            Assert.AreEqual(expectedOtherProperty, otherProperty.Int32Value);
        }

        [Test]
        public void Convert_IfOtherPropertyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateOtherProperty, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateOtherProperty>();
            PocoWithPrivateOtherProperty input = new PocoWithPrivateOtherProperty
            {
                PartitionKey = expectedPartitionKey,
                OtherPropertyPublic = 456
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateOtherPropertyGetter, ITableEntity> product =
                CreateProductUnderTest<PocoWithPrivateOtherPropertyGetter>();
            PocoWithPrivateOtherPropertyGetter input = new PocoWithPrivateOtherPropertyGetter
            {
                PartitionKey = expectedPartitionKey,
                OtherProperty = 456
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticOtherProperty, ITableEntity> product =
                CreateProductUnderTest<PocoWithStaticOtherProperty>();
            PocoWithStaticOtherProperty.OtherProperty = 456;
            PocoWithStaticOtherProperty input = new PocoWithStaticOtherProperty
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyOtherProperty, ITableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyOtherProperty>();
            PocoWithWriteOnlyOtherProperty input = new PocoWithWriteOnlyOtherProperty
            {
                PartitionKey = expectedPartitionKey,
                OtherProperty = 456
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsIndexer_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithIndexerOtherProperty, ITableEntity> product =
                CreateProductUnderTest<PocoWithIndexerOtherProperty>();
            PocoWithIndexerOtherProperty input = new PocoWithIndexerOtherProperty
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            ITableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            IDictionary<string, EntityProperty> properties = actual.WriteEntity(operationContext: null);
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void ConvertsPartitionKey_IfPocoHasPartitionKeyProperty_ReturnsTrue()
        {
            // Arrange
            PocoToTableEntityConverter<PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            // Act
            bool convertsPartitionKey = product.ConvertsPartitionKey;
            // Assert
            Assert.True(convertsPartitionKey);
        }

        [Test]
        public void ConvertsPartitionKey_IfPocoDoesNotHavePartitionKeyProperty_ReturnsFalse()
        {
            // Arrange
            PocoToTableEntityConverter<Poco> product = CreateProductUnderTest<Poco>();
            // Act
            bool convertsPartitionKey = product.ConvertsPartitionKey;
            // Assert
            Assert.False(convertsPartitionKey);
        }

        [Test]
        public void ConvertsRowKey_IfPocoHasRowKeyProperty_ReturnsTrue()
        {
            // Arrange
            PocoToTableEntityConverter<PocoWithRowKey> product = CreateProductUnderTest<PocoWithRowKey>();
            // Act
            bool convertsRowKey = product.ConvertsRowKey;
            // Assert
            Assert.True(convertsRowKey);
        }

        [Test]
        public void ConvertsRowKey_IfPocoDoesNotHaveRowKeyProperty_ReturnsFalse()
        {
            // Arrange
            PocoToTableEntityConverter<Poco> product = CreateProductUnderTest<Poco>();
            // Act
            bool convertsRowKey = product.ConvertsRowKey;
            // Assert
            Assert.False(convertsRowKey);
        }

        [Test]
        public void ConvertsETag_IfPocoHasETagProperty_ReturnsTrue()
        {
            // Arrange
            PocoToTableEntityConverter<PocoWithETag> product = CreateProductUnderTest<PocoWithETag>();
            // Act
            bool convertsETag = product.ConvertsETag;
            // Assert
            Assert.True(convertsETag);
        }

        [Test]
        public void ConvertsETag_IfPocoDoesNotHaveETagProperty_ReturnsFalse()
        {
            // Arrange
            PocoToTableEntityConverter<Poco> product = CreateProductUnderTest<Poco>();
            // Act
            bool convertsETag = product.ConvertsETag;
            // Assert
            Assert.False(convertsETag);
        }

        private static PocoToTableEntityConverter<TInput> CreateProductUnderTest<TInput>()
        {
            var product = PocoToTableEntityConverter<TInput>.Create();
            Assert.NotNull(product); // Guard
            return product;
        }

        private class Poco
        {
        }

        private class PocoWithNonStringPartitionKey
        {
            public int PartitionKey { get; set; }
        }

        private class PocoWithIndexerPartitionKey
        {
            [IndexerName("PartitionKey")]
            public string this[object index]
            {
                get { return null; }
                set { }
            }
        }

        private class PocoWithNonStringRowKey
        {
            public int RowKey { get; set; }
        }

        private class PocoWithIndexerRowKey
        {
            [IndexerName("RowKey")]
            public string this[object index]
            {
                get { return null; }
                set { }
            }
        }

        private class PocoWithNonDateTimeOffsetTimestamp
        {
            public string Timestamp { get; set; }
        }

        private class PocoWithIndexerTimestamp
        {
            [IndexerName("Timestamp")]
            public DateTimeOffset this[object index]
            {
                get { return default(DateTimeOffset); }
                set { }
            }
        }

        private class PocoWithNonStringETag
        {
            public int ETag { get; set; }
        }

        private class PocoWithIndexerETag
        {
            [IndexerName("ETag")]
            public string this[object index]
            {
                get { return null; }
                set { }
            }
        }

        private class PocoWithPartitionKey
        {
            public string PartitionKey { get; set; }
        }

        private class PocoWithReadOnlyPartitionKey
        {
            private string _partitionKey;

            public string PartitionKey
            {
                get { return _partitionKey; }
            }

            public string WritePartitionKey
            {
                set { _partitionKey = value; }
            }
        }

        private class PocoWithPrivatePartitionKey
        {
            private string PartitionKey { get; set; }

            public string PartitionKeyPublic
            {
                get { return PartitionKey; }
                set { PartitionKey = value; }
            }

            public string RowKey { get; set; }
        }

        private class PocoWithPrivatePartitionKeyGetter
        {
            public string PartitionKey { private get; set; }
            public string RowKey { get; set; }
        }

        private class PocoWithStaticPartitionKey
        {
            public static string PartitionKey { get; set; }
            public string RowKey { get; set; }
        }

        private class PocoWithWriteOnlyPartitionKey
        {
            public string PartitionKey
            {
                set { }
            }

            public string RowKey { get; set; }
        }

        private class PocoWithRowKey
        {
            public string RowKey { get; set; }
        }

        private class PocoWithReadOnlyRowKey
        {
            private string _rowKey;

            public string RowKey
            {
                get { return _rowKey; }
            }

            public string WriteRowKey
            {
                set { _rowKey = value; }
            }
        }

        private class PocoWithPrivateRowKey
        {
            public string PartitionKey { get; set; }
            private string RowKey { get; set; }

            public string RowKeyPublic
            {
                get { return RowKey; }
                set { RowKey = value; }
            }
        }

        private class PocoWithPrivateRowKeyGetter
        {
            public string PartitionKey { get; set; }
            public string RowKey { private get; set; }
        }

        private class PocoWithStaticRowKey
        {
            public string PartitionKey { get; set; }
            public static string RowKey { get; set; }
        }

        private class PocoWithWriteOnlyRowKey
        {
            public string PartitionKey { get; set; }

            public string RowKey
            {
                set { }
            }
        }

        private class PocoWithTimestamp
        {
            public DateTimeOffset Timestamp { get; set; }
        }

        private class PocoWithReadOnlyTimestamp
        {
            private DateTimeOffset _timestamp;

            public DateTimeOffset Timestamp
            {
                get { return _timestamp; }
            }

            public DateTimeOffset WriteTimestamp
            {
                set { _timestamp = value; }
            }
        }

        private class PocoWithPrivateTimestamp
        {
            public string PartitionKey { get; set; }
            private DateTimeOffset Timestamp { get; set; }

            public DateTimeOffset TimestampPublic
            {
                get { return Timestamp; }
                set { Timestamp = value; }
            }
        }

        private class PocoWithPrivateTimestampGetter
        {
            public string PartitionKey { get; set; }
            public DateTimeOffset Timestamp { private get; set; }
        }

        private class PocoWithStaticTimestamp
        {
            public string PartitionKey { get; set; }
            public static DateTimeOffset Timestamp { get; set; }
        }

        private class PocoWithWriteOnlyTimestamp
        {
            public string PartitionKey { get; set; }

            public DateTimeOffset Timestamp
            {
                set { }
            }
        }

        private class PocoWithETag
        {
            public string ETag { get; set; }
        }

        private class PocoWithReadOnlyETag
        {
            private string _eTag;

            public string ETag
            {
                get { return _eTag; }
            }

            public string WriteETag
            {
                set { _eTag = value; }
            }
        }

        private class PocoWithPrivateETag
        {
            public string PartitionKey { get; set; }
            private string ETag { get; set; }

            public string ETagPublic
            {
                get { return ETag; }
                set { ETag = value; }
            }
        }

        private class PocoWithPrivateETagGetter
        {
            public string PartitionKey { get; set; }
            public string ETag { private get; set; }
        }

        private class PocoWithStaticETag
        {
            public string PartitionKey { get; set; }
            public static string ETag { get; set; }
        }

        private class PocoWithWriteOnlyETag
        {
            public string PartitionKey { get; set; }

            public string ETag
            {
                set { }
            }
        }

        private class PocoWithOtherProperty
        {
            public int? OtherProperty { get; set; }
        }

        private class PocoWithReadOnlyOtherProperty
        {
            private int? _otherProperty;

            public int? OtherProperty
            {
                get { return _otherProperty; }
            }

            public int? WriteOtherProperty
            {
                set { _otherProperty = value; }
            }
        }

        private class PocoWithPrivateOtherProperty
        {
            public string PartitionKey { get; set; }
            private int? OtherProperty { get; set; }

            public int? OtherPropertyPublic
            {
                get { return OtherProperty; }
                set { OtherProperty = value; }
            }
        }

        private class PocoWithPrivateOtherPropertyGetter
        {
            public string PartitionKey { get; set; }
            public int? OtherProperty { private get; set; }
        }

        private class PocoWithStaticOtherProperty
        {
            public string PartitionKey { get; set; }
            public static int? OtherProperty { get; set; }
        }

        private class PocoWithWriteOnlyOtherProperty
        {
            public string PartitionKey { get; set; }

            public int? OtherProperty
            {
                set { }
            }
        }

        private class PocoWithIndexerOtherProperty
        {
            public string PartitionKey { get; set; }

            [IndexerName("OtherProperty")]
            public int? this[object index]
            {
                get { return null; }
                set { }
            }
        }
    }
}