// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.CompilerServices;
using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityToPocoConverterTests
    {
        [Test]
        public void Create_ReturnsInstance()
        {
            // Act
            IConverter<TableEntity, Poco> converter = new TableEntityToPocoConverter<Poco>();
            // Assert
            Assert.NotNull(converter);
        }

        [Test]
        public void Create_IfPartitionKeyIsNonString_Throws()
        {
            // Act & Asset;
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithNonStringPartitionKey>());

            Assert.AreEqual("If the PartitionKey property is present, it must be a System.String.", exception.Message);
        }

        [Test]
        public void Create_IfPartitionKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithIndexerPartitionKey>());

            Assert.AreEqual("If the PartitionKey property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Create_IfRowKeyIsNonString_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithNonStringRowKey>());

            Assert.AreEqual("If the RowKey property is present, it must be a System.String.", exception.Message);
        }

        [Test]
        public void Create_IfRowKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithIndexerRowKey>());

            Assert.AreEqual("If the RowKey property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Create_IfTimestampIsNonDateTimeOffset_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithNonDateTimeOffsetTimestamp>());

            Assert.AreEqual("If the Timestamp property is present, it must be a System.DateTimeOffset or System.Nullable`1[System.DateTimeOffset].", exception.Message);
        }

        [Test]
        public void Create_IfTimestampHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithIndexerTimestamp>());

            Assert.AreEqual("If the Timestamp property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Create_IfETagIsNonString_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithNonStringETag>());

            Assert.AreEqual("If the ETag property is present, it must be a System.String or Azure.ETag.", exception.Message);
        }

        [Test]
        public void Create_IfETagHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new TableEntityToPocoConverter<PocoWithIndexerETag>());

            Assert.AreEqual("If the ETag property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Convert_IfInputIsNull_ReturnsDefault()
        {
            // Arrange
            IConverter<TableEntity, Poco> product = CreateProductUnderTest<Poco>();
            TableEntity entity = null;
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
            IConverter<TableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithWriteOnlyPartitionKey> product =
                CreateProductUnderTest<PocoWithWriteOnlyPartitionKey>();
            TableEntity entity = new TableEntity
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
        [Ignore("TODO: in T2 these are not separate properties")]
        public void Convert_IfDictionaryContainsPartitionKey_PopulatesFromOfficialPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<TableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["PartitionKey"] = "UnexpectedPK"
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
            IConverter<TableEntity, PocoWithPrivatePartitionKey> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithPrivatePartitionKeySetter> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKeySetter>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithStaticPartitionKey> product =
                CreateProductUnderTest<PocoWithStaticPartitionKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithReadOnlyPartitionKey> product =
                CreateProductUnderTest<PocoWithReadOnlyPartitionKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithRowKey> product = CreateProductUnderTest<PocoWithRowKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithWriteOnlyRowKey> product =
                CreateProductUnderTest<PocoWithWriteOnlyRowKey>();
            TableEntity entity = new TableEntity
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
        [Ignore("TODO: in T2 these are not separate properties")]
        public void Convert_IfDictionaryContainsRowKey_PopulatesFromOfficialRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<TableEntity, PocoWithRowKey> product = CreateProductUnderTest<PocoWithRowKey>();
            TableEntity entity = new TableEntity
            {
                RowKey = expectedRowKey,
                ["RowKey"] = "UnexpectedRK"
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
            IConverter<TableEntity, PocoWithPrivateRowKey> product = CreateProductUnderTest<PocoWithPrivateRowKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithPrivateRowKeySetter> product =
                CreateProductUnderTest<PocoWithPrivateRowKeySetter>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithStaticRowKey> product = CreateProductUnderTest<PocoWithStaticRowKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithReadOnlyRowKey> product = CreateProductUnderTest<PocoWithReadOnlyRowKey>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithTimestamp> product = CreateProductUnderTest<PocoWithTimestamp>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithWriteOnlyTimestamp> product =
                CreateProductUnderTest<PocoWithWriteOnlyTimestamp>();
            TableEntity entity = new TableEntity
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
        [Ignore("TODO: in T2 these are not separate properties")]
        public void Convert_IfDictionaryContainsTimestamp_PopulatesFromOfficialTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<TableEntity, PocoWithTimestamp> product = CreateProductUnderTest<PocoWithTimestamp>();
            TableEntity entity = new TableEntity
            {
                Timestamp = expectedTimestamp,
                ["Timestamp"] =  DateTimeOffset.MinValue
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
            IConverter<TableEntity, PocoWithPrivateTimestamp> product =
                CreateProductUnderTest<PocoWithPrivateTimestamp>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithPrivateTimestampSetter> product =
                CreateProductUnderTest<PocoWithPrivateTimestampSetter>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithStaticTimestamp> product =
                CreateProductUnderTest<PocoWithStaticTimestamp>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithReadOnlyTimestamp> product =
                CreateProductUnderTest<PocoWithReadOnlyTimestamp>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithETag> product = CreateProductUnderTest<PocoWithETag>();
            TableEntity entity = new TableEntity
            {
                ETag = new ETag(expectedETag)
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
            IConverter<TableEntity, PocoWithWriteOnlyETag> product = CreateProductUnderTest<PocoWithWriteOnlyETag>();
            TableEntity entity = new TableEntity
            {
                ETag = new ETag(expectedETag)
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
            IConverter<TableEntity, PocoWithETag> product = CreateProductUnderTest<PocoWithETag>();
            TableEntity entity = new TableEntity
            {
                ETag = new ETag(expectedETag),
                ["ETag"] = "UnexpectedETag"
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
            IConverter<TableEntity, PocoWithPrivateETag> product = CreateProductUnderTest<PocoWithPrivateETag>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = new ETag("UnexpectedETag")
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
            IConverter<TableEntity, PocoWithPrivateETagSetter> product =
                CreateProductUnderTest<PocoWithPrivateETagSetter>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = new ETag("UnexpectedETag")
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
            IConverter<TableEntity, PocoWithStaticETag> product = CreateProductUnderTest<PocoWithStaticETag>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ETag = new ETag("UnexpectedETag")
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
            IConverter<TableEntity, PocoWithReadOnlyETag> product = CreateProductUnderTest<PocoWithReadOnlyETag>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithOtherProperty> product = CreateProductUnderTest<PocoWithOtherProperty>();
            TableEntity entity = new TableEntity
            {
                ["OtherProperty"] = expectedOtherProperty
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
            IConverter<TableEntity, PocoWithWriteOnlyOtherProperty> product =
                CreateProductUnderTest<PocoWithWriteOnlyOtherProperty>();
            TableEntity entity = new TableEntity
            {
                ["OtherProperty"] = expectedOtherProperty
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
            IConverter<TableEntity, PocoWithPrivateOtherProperty> product =
                CreateProductUnderTest<PocoWithPrivateOtherProperty>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["OtherProperty"] = 456
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
            IConverter<TableEntity, PocoWithPrivateOtherPropertySetter> product =
                CreateProductUnderTest<PocoWithPrivateOtherPropertySetter>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["OtherProperty"] = 456
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
            IConverter<TableEntity, PocoWithStaticOtherProperty> product =
                CreateProductUnderTest<PocoWithStaticOtherProperty>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["OtherProperty"] = 456
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
            IConverter<TableEntity, PocoWithReadOnlyOtherProperty> product =
                CreateProductUnderTest<PocoWithReadOnlyOtherProperty>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["OtherProperty"] = 456
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
            IConverter<TableEntity, PocoWithIndexerOtherProperty> product =
                CreateProductUnderTest<PocoWithIndexerOtherProperty>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["OtherProperty"] = 456
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
            IConverter<TableEntity, PocoWithPartitionKeyAndOtherProperty> product =
                CreateProductUnderTest<PocoWithPartitionKeyAndOtherProperty>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
            };
            // TODO:
            //Assert.Null(entity.WriteEntity(operationContext: null)); // Guard
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
            IConverter<TableEntity, PocoWithPartitionKeyAndOtherProperty> product =
                CreateProductUnderTest<PocoWithPartitionKeyAndOtherProperty>();
            TableEntity entity = new TableEntity
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
            IConverter<TableEntity, PocoWithPartitionKey> product = CreateProductUnderTest<PocoWithPartitionKey>();
            TableEntity entity = new TableEntity
            {
                PartitionKey = expectedPartitionKey,
                ["ExtraProperty"] = "abc"
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
            TableEntityToPocoConverter<TOutput> product = new TableEntityToPocoConverter<TOutput>();
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