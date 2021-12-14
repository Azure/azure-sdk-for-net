// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Cosmos.Table;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityToPocoConverterTests
    {
        [Test]
        public void Create_ReturnsInstance()
        {
            // Act
            IConverter<ITableEntity, Poco> converter = TableEntityToPocoConverter<Poco>.Create();
            // Assert
            Assert.NotNull(converter);
        }

        [Test]
        public void Create_IfPartitionKeyIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => TableEntityToPocoConverter<PocoWithNonStringPartitionKey>.Create(),
                "If the PartitionKey property is present, it must be a String.");
        }

        [Test]
        public void Create_IfPartitionKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => TableEntityToPocoConverter<PocoWithIndexerPartitionKey>.Create(),
                "If the PartitionKey property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfRowKeyIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => TableEntityToPocoConverter<PocoWithNonStringRowKey>.Create(),
                "If the RowKey property is present, it must be a String.");
        }

        [Test]
        public void Create_IfRowKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => TableEntityToPocoConverter<PocoWithIndexerRowKey>.Create(),
                "If the RowKey property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfTimestampIsNonDateTimeOffset_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(
                () => TableEntityToPocoConverter<PocoWithNonDateTimeOffsetTimestamp>.Create(),
                "If the Timestamp property is present, it must be a DateTimeOffset.");
        }

        [Test]
        public void Create_IfTimestampHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => TableEntityToPocoConverter<PocoWithIndexerTimestamp>.Create(),
                "If the Timestamp property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfETagIsNonString_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => TableEntityToPocoConverter<PocoWithNonStringETag>.Create(),
                "If the ETag property is present, it must be a String.");
        }

        [Test]
        public void Create_IfETagHasIndexParameters_Throws()
        {
            // Act & Assert
            ExceptionAssert.ThrowsInvalidOperation(() => TableEntityToPocoConverter<PocoWithIndexerETag>.Create(),
                "If the ETag property is present, it must not be an indexer.");
        }

        [Test]
        public void Convert_IfInputIsNull_ReturnsDefault()
        {
            // Arrange
            IConverter<ITableEntity, Poco> product = CreateProductUnderTest<Poco>();
            ITableEntity entity = null;
            // Act
            Poco actual = product.Convert(entity);
            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void Convert_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsWriteOnly_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithWriteOnlyPartitionKey> product =
                CreateProductUnderTest<PocoWithWriteOnlyPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithWriteOnlyPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.ReadPartitionKey);
        }

        [Test]
        public void Convert_IfDictionaryContainsPartitionKey_PopulatesFromOfficialPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "PartitionKey", new EntityProperty("UnexpectedPK") }
                }
            };
            // Act
            PocoWithPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithPrivatePartitionKey> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            PocoWithPrivatePartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.PartitionKeyPublic);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfPartitionKeySetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithPrivatePartitionKeySetter> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKeySetter>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            PocoWithPrivatePartitionKeySetter actual = product.Convert(entity);
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
            IConverter<ITableEntity, PocoWithStaticPartitionKey> product =
                CreateProductUnderTest<PocoWithStaticPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            PocoWithStaticPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(PocoWithStaticPartitionKey.PartitionKey);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsReadOnly_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithReadOnlyPartitionKey> product =
                CreateProductUnderTest<PocoWithReadOnlyPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                RowKey = expectedRowKey
            };
            // Act
            PocoWithReadOnlyPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_PopulatesRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithRowKey> product = CreateProductUnderTest<PocoWithRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                RowKey = expectedRowKey
            };
            // Act
            PocoWithRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfRowKeyIsWriteOnly_PopulatesRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithWriteOnlyRowKey> product =
                CreateProductUnderTest<PocoWithWriteOnlyRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                RowKey = expectedRowKey
            };
            // Act
            PocoWithWriteOnlyRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.ReadRowKey);
        }

        [Test]
        public void Convert_IfDictionaryContainsRowKey_PopulatesFromOfficialRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<ITableEntity, PocoWithRowKey> product = CreateProductUnderTest<PocoWithRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                RowKey = expectedRowKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "RowKey", new EntityProperty("UnexpectedRK") }
                }
            };
            // Act
            PocoWithRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfRowKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateRowKey> product = CreateProductUnderTest<PocoWithPrivateRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "UnexpectedRK"
            };
            // Act
            PocoWithPrivateRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.RowKeyPublic);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfRowKeySetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateRowKeySetter> product =
                CreateProductUnderTest<PocoWithPrivateRowKeySetter>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "UnexpectedRK"
            };
            // Act
            PocoWithPrivateRowKeySetter actual = product.Convert(entity);
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
            IConverter<ITableEntity, PocoWithStaticRowKey> product = CreateProductUnderTest<PocoWithStaticRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "UnexpectedRK"
            };
            // Act
            PocoWithStaticRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(PocoWithStaticRowKey.RowKey);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfRowKeyIsReadOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithReadOnlyRowKey> product = CreateProductUnderTest<PocoWithReadOnlyRowKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithReadOnlyRowKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<ITableEntity, PocoWithTimestamp> product = CreateProductUnderTest<PocoWithTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                Timestamp = expectedTimestamp
            };
            // Act
            PocoWithTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Offset);
        }

        [Test]
        public void Convert_IfTimestampIsWriteOnly_PopulatesTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<ITableEntity, PocoWithWriteOnlyTimestamp> product =
                CreateProductUnderTest<PocoWithWriteOnlyTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                Timestamp = expectedTimestamp
            };
            // Act
            PocoWithWriteOnlyTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.ReadTimestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.ReadTimestamp.Offset);
        }

        [Test]
        public void Convert_IfDictionaryContainsTimestamp_PopulatesFromOfficialTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<ITableEntity, PocoWithTimestamp> product = CreateProductUnderTest<PocoWithTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                Timestamp = expectedTimestamp,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "Timestamp", new EntityProperty(DateTimeOffset.MinValue) }
                }
            };
            // Act
            PocoWithTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Offset);
        }

        [Test]
        public void Convert_IfTimestampIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateTimestamp> product =
                CreateProductUnderTest<PocoWithPrivateTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            PocoWithPrivateTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), actual.TimestampPublic);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampSetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateTimestampSetter> product =
                CreateProductUnderTest<PocoWithPrivateTimestampSetter>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            PocoWithPrivateTimestampSetter actual = product.Convert(entity);
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
            IConverter<ITableEntity, PocoWithStaticTimestamp> product =
                CreateProductUnderTest<PocoWithStaticTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            PocoWithStaticTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(DateTimeOffset), PocoWithStaticTimestamp.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampIsReadOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithReadOnlyTimestamp> product =
                CreateProductUnderTest<PocoWithReadOnlyTimestamp>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithReadOnlyTimestamp actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<ITableEntity, PocoWithETag> product = CreateProductUnderTest<PocoWithETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                ETag = expectedETag
            };
            // Act
            PocoWithETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ETag);
        }

        [Test]
        public void Convert_IfETagIsWriteOnly_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<ITableEntity, PocoWithWriteOnlyETag> product = CreateProductUnderTest<PocoWithWriteOnlyETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                ETag = expectedETag
            };
            // Act
            PocoWithWriteOnlyETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ReadETag);
        }

        [Test]
        public void Convert_IfDictionaryContainsETag_PopulatesFromOfficialETag()
        {
            // Arrange
            const string expectedETag = "ETag";
            IConverter<ITableEntity, PocoWithETag> product = CreateProductUnderTest<PocoWithETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                ETag = expectedETag,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "ETag", new EntityProperty("UnexpectedETag") }
                }
            };
            // Act
            PocoWithETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedETag, actual.ETag);
        }

        [Test]
        public void Convert_IfETagIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateETag> product = CreateProductUnderTest<PocoWithPrivateETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = "UnexpectedETag"
            };
            // Act
            PocoWithPrivateETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.ETagPublic);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagSetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateETagSetter> product =
                CreateProductUnderTest<PocoWithPrivateETagSetter>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = "UnexpectedETag"
            };
            // Act
            PocoWithPrivateETagSetter actual = product.Convert(entity);
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
            IConverter<ITableEntity, PocoWithStaticETag> product = CreateProductUnderTest<PocoWithStaticETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = "UnexpectedETag"
            };
            // Act
            PocoWithStaticETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(PocoWithStaticETag.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagIsReadOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithReadOnlyETag> product = CreateProductUnderTest<PocoWithReadOnlyETag>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithReadOnlyETag actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<ITableEntity, PocoWithOtherProperty> product = CreateProductUnderTest<PocoWithOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(expectedOtherProperty) }
                }
            };
            // Act
            PocoWithOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedOtherProperty, actual.OtherProperty);
        }

        [Test]
        public void Convert_IfOtherPropertyIsWriteOnly_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<ITableEntity, PocoWithWriteOnlyOtherProperty> product =
                CreateProductUnderTest<PocoWithWriteOnlyOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(expectedOtherProperty) }
                }
            };
            // Act
            PocoWithWriteOnlyOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedOtherProperty, actual.ReadOtherProperty);
        }

        [Test]
        public void Convert_IfOtherPropertyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateOtherProperty> product =
                CreateProductUnderTest<PocoWithPrivateOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(456) }
                }
            };
            // Act
            PocoWithPrivateOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.OtherPropertyPublic);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertySetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPrivateOtherPropertySetter> product =
                CreateProductUnderTest<PocoWithPrivateOtherPropertySetter>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(456) }
                }
            };
            // Act
            PocoWithPrivateOtherPropertySetter actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.OtherProperty);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithStaticOtherProperty> product =
                CreateProductUnderTest<PocoWithStaticOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(456) }
                }
            };
            // Act
            PocoWithStaticOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(PocoWithStaticOtherProperty.OtherProperty);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsReadOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithReadOnlyOtherProperty> product =
                CreateProductUnderTest<PocoWithReadOnlyOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(456) }
                }
            };
            // Act
            PocoWithReadOnlyOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsIndexer_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithIndexerOtherProperty> product =
                CreateProductUnderTest<PocoWithIndexerOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "OtherProperty", new EntityProperty(456) }
                }
            };
            // Act
            PocoWithIndexerOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfWriteEntityReturnsNull_DoesNotPopulateOtherProperties()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPartitionKeyAndOtherProperty> product =
                CreateProductUnderTest<PocoWithPartitionKeyAndOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = null
            };
            Assert.Null(entity.WriteEntity(operationContext: null)); // Guard
            // Act
            PocoWithPartitionKeyAndOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.OtherProperty);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsNotPresentInDictionary_DoesNotPopulateOtherProperty()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPartitionKeyAndOtherProperty> product =
                CreateProductUnderTest<PocoWithPartitionKeyAndOtherProperty>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            PocoWithPartitionKeyAndOtherProperty actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.OtherProperty);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfExtraPropertyIsPresentInDictionary_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<ITableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            DynamicTableEntity entity = new DynamicTableEntity
            {
                PartitionKey = expectedPartitionKey,
                Properties = new Dictionary<string, EntityProperty>
                {
                    { "ExtraProperty", new EntityProperty("abc") }
                }
            };
            // Act
            PocoWithPartitionKey actual = product.Convert(entity);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        private static TableEntityToPocoConverter<TOutput> CreateProductUnderTest<TOutput>()
            where TOutput : new()
        {
            TableEntityToPocoConverter<TOutput> product = TableEntityToPocoConverter<TOutput>.Create();
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

        private class PocoWithWriteOnlyPartitionKey
        {
            private string _partitionKey;

            public string PartitionKey
            {
                set { _partitionKey = value; }
            }

            public string ReadPartitionKey
            {
                get { return _partitionKey; }
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

        private class PocoWithPrivatePartitionKeySetter
        {
            public string PartitionKey { get; private set; }
            public string RowKey { get; set; }
        }

        private class PocoWithStaticPartitionKey
        {
            public static string PartitionKey { get; set; }
            public string RowKey { get; set; }
        }

        private class PocoWithReadOnlyPartitionKey
        {
            public string PartitionKey
            {
                get { return null; }
            }

            public string RowKey { get; set; }
        }

        private class PocoWithRowKey
        {
            public string RowKey { get; set; }
        }

        private class PocoWithWriteOnlyRowKey
        {
            private string _rowKey;

            public string RowKey
            {
                set { _rowKey = value; }
            }

            public string ReadRowKey
            {
                get { return _rowKey; }
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

        private class PocoWithPrivateRowKeySetter
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; private set; }
        }

        private class PocoWithStaticRowKey
        {
            public string PartitionKey { get; set; }
            public static string RowKey { get; set; }
        }

        private class PocoWithReadOnlyRowKey
        {
            public string PartitionKey { get; set; }

            public string RowKey
            {
                get { return null; }
            }
        }

        private class PocoWithTimestamp
        {
            public DateTimeOffset Timestamp { get; set; }
        }

        private class PocoWithWriteOnlyTimestamp
        {
            private DateTimeOffset _timestamp;

            public DateTimeOffset Timestamp
            {
                set { _timestamp = value; }
            }

            public DateTimeOffset ReadTimestamp
            {
                get { return _timestamp; }
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

        private class PocoWithPrivateTimestampSetter
        {
            public string PartitionKey { get; set; }
            public DateTimeOffset Timestamp { get; private set; }
        }

        private class PocoWithStaticTimestamp
        {
            public string PartitionKey { get; set; }
            public static DateTimeOffset Timestamp { get; set; }
        }

        private class PocoWithReadOnlyTimestamp
        {
            public string PartitionKey { get; set; }

            public DateTimeOffset Timestamp
            {
                get { return default(DateTimeOffset); }
            }
        }

        private class PocoWithETag
        {
            public string ETag { get; set; }
        }

        private class PocoWithWriteOnlyETag
        {
            private string _eTag;

            public string ETag
            {
                set { _eTag = value; }
            }

            public string ReadETag
            {
                get { return _eTag; }
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

        private class PocoWithPrivateETagSetter
        {
            public string PartitionKey { get; set; }
            public string ETag { get; private set; }
        }

        private class PocoWithStaticETag
        {
            public string PartitionKey { get; set; }
            public static string ETag { get; set; }
        }

        private class PocoWithReadOnlyETag
        {
            public string PartitionKey { get; set; }

            public string ETag
            {
                get { return default(string); }
            }
        }

        private class PocoWithOtherProperty
        {
            public int? OtherProperty { get; set; }
        }

        private class PocoWithWriteOnlyOtherProperty
        {
            private int? _otherProperty;

            public int? OtherProperty
            {
                set { _otherProperty = value; }
            }

            public int? ReadOtherProperty
            {
                get { return _otherProperty; }
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

        private class PocoWithPrivateOtherPropertySetter
        {
            public string PartitionKey { get; set; }
            public int? OtherProperty { get; private set; }
        }

        private class PocoWithStaticOtherProperty
        {
            public string PartitionKey { get; set; }
            public static int? OtherProperty { get; set; }
        }

        private class PocoWithReadOnlyOtherProperty
        {
            public string PartitionKey { get; set; }

            public int? OtherProperty
            {
                get { return null; }
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

        private class PocoWithPartitionKeyAndOtherProperty
        {
            public string PartitionKey { get; set; }
            public int? OtherProperty { get; set; }
        }
    }
}