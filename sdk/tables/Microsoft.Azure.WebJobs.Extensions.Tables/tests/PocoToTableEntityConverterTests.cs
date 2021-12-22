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
    public class PocoToTableEntityConverterTests
    {
        [Test]
        public void Create_ReturnsInstance()
        {
            // Act
            IConverter<Poco, TableEntity> converter = new PocoToTableEntityConverter<Poco>();
            // Assert
            Assert.NotNull(converter);
        }

        [Test]
        public void Create_IfPartitionKeyIsNonString_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithNonStringPartitionKey>());

            Assert.AreEqual("If the PartitionKey property is present, it must be a String.", exception.Message);
        }

        [Test]
        public void Create_IfPartitionKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithIndexerPartitionKey>());

            Assert.AreEqual(exception.Message, "If the PartitionKey property is present, it must not be an indexer.");
        }

        [Test]
        public void Create_IfRowKeyIsNonString_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithNonStringRowKey>());

            Assert.AreEqual("If the RowKey property is present, it must be a String.", exception.Message);
        }

        [Test]
        public void Create_IfRowKeyHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithIndexerRowKey>());

            Assert.AreEqual("If the RowKey property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Create_IfTimestampIsNonDateTimeOffset_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithNonDateTimeOffsetTimestamp>());

            Assert.AreEqual("If the Timestamp property is present, it must be a DateTimeOffset.", exception.Message);
        }

        [Test]
        public void Create_IfTimestampHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithIndexerTimestamp>());

            Assert.AreEqual("If the Timestamp property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Create_IfETagIsNonString_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithNonStringETag>());

            Assert.AreEqual("If the ETag property is present, it must be a String.", exception.Message);
        }

        [Test]
        public void Create_IfETagHasIndexParameters_Throws()
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => new PocoToTableEntityConverter<PocoWithIndexerETag>());

            Assert.AreEqual("If the ETag property is present, it must not be an indexer.", exception.Message);
        }

        [Test]
        public void Convert_IfInputIsNull_ReturnsNull()
        {
            // Arrange
            IConverter<Poco, TableEntity> product = CreateProductUnderTest<Poco>();
            Poco input = null;
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void Convert_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPartitionKey, TableEntity> product = CreateProductUnderTest<PocoWithPartitionKey>();
            PocoWithPartitionKey input = new PocoWithPartitionKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfPartitionKeyIsReadOnly_PopulatesPartitionKey()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithReadOnlyPartitionKey, TableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyPartitionKey>();
            PocoWithReadOnlyPartitionKey input = new PocoWithReadOnlyPartitionKey
            {
                WritePartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        [Ignore("TODO: In T2 all properties are inside the dictionary")]
        public void Convert_DoesNotIncludePartitionKeyInDictionary()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPartitionKey, TableEntity> product = CreateProductUnderTest<PocoWithPartitionKey>();
            PocoWithPartitionKey input = new PocoWithPartitionKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
            Assert.False(actual.ContainsKey("PartitionKey"));
        }

        [Test]
        public void Convert_IfPartitionKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithPrivatePartitionKey, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKey>();
            PocoWithPrivatePartitionKey input = new PocoWithPrivatePartitionKey
            {
                PartitionKeyPublic = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithPrivatePartitionKeyGetter, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivatePartitionKeyGetter>();
            PocoWithPrivatePartitionKeyGetter input = new PocoWithPrivatePartitionKeyGetter
            {
                PartitionKey = "UnexpectedPK",
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithStaticPartitionKey, TableEntity> product =
                CreateProductUnderTest<PocoWithStaticPartitionKey>();
            PocoWithStaticPartitionKey.PartitionKey = "UnexpectedPK";
            PocoWithStaticPartitionKey input = new PocoWithStaticPartitionKey
            {
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithWriteOnlyPartitionKey, TableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyPartitionKey>();
            PocoWithWriteOnlyPartitionKey input = new PocoWithWriteOnlyPartitionKey
            {
                PartitionKey = "IgnorePK",
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithRowKey, TableEntity> product = CreateProductUnderTest<PocoWithRowKey>();
            PocoWithRowKey input = new PocoWithRowKey
            {
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        public void Convert_IfRowKeyIsReadOnly_PopulatesRowKey()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithReadOnlyRowKey, TableEntity> product = CreateProductUnderTest<PocoWithReadOnlyRowKey>();
            PocoWithReadOnlyRowKey input = new PocoWithReadOnlyRowKey
            {
                WriteRowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
        }

        [Test]
        [Ignore("TODO: In T2 all properties are inside the dictionary")]
        public void Convert_DoesNotIncludeRowKeyInDictionary()
        {
            // Arrange
            const string expectedRowKey = "RK";
            IConverter<PocoWithRowKey, TableEntity> product = CreateProductUnderTest<PocoWithRowKey>();
            PocoWithRowKey input = new PocoWithRowKey
            {
                RowKey = expectedRowKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreSame(expectedRowKey, actual.RowKey);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("RowKey"));
        }

        [Test]
        public void Convert_IfRowKeyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateRowKey, TableEntity> product = CreateProductUnderTest<PocoWithPrivateRowKey>();
            PocoWithPrivateRowKey input = new PocoWithPrivateRowKey
            {
                PartitionKey = expectedPartitionKey,
                RowKeyPublic = "UnexpectedRK"
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithPrivateRowKeyGetter, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateRowKeyGetter>();
            PocoWithPrivateRowKeyGetter input = new PocoWithPrivateRowKeyGetter
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "UnexpectedRK"
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithStaticRowKey, TableEntity> product = CreateProductUnderTest<PocoWithStaticRowKey>();
            PocoWithStaticRowKey.RowKey = "UnexpectedRK";
            PocoWithStaticRowKey input = new PocoWithStaticRowKey
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithWriteOnlyRowKey, TableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyRowKey>();
            PocoWithWriteOnlyRowKey input = new PocoWithWriteOnlyRowKey
            {
                PartitionKey = expectedPartitionKey,
                RowKey = "IgnoreRK"
            };
            // Act
            TableEntity actual = product.Convert(input);
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
            IConverter<PocoWithTimestamp, TableEntity> product = CreateProductUnderTest<PocoWithTimestamp>();
            PocoWithTimestamp input = new PocoWithTimestamp
            {
                Timestamp = expectedTimestamp
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Value.Offset);
        }

        [Test]
        public void Convert_IfTimestampIsReadOnly_PopulatesTimestamp()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<PocoWithReadOnlyTimestamp, TableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyTimestamp>();
            PocoWithReadOnlyTimestamp input = new PocoWithReadOnlyTimestamp
            {
                WriteTimestamp = expectedTimestamp
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Value.Offset);
        }

        [Test]
        [Ignore("TODO: In T2 all properties are inside the dictionary")]
        public void Convert_DoesNotIncludeTimestampInDictionary()
        {
            // Arrange
            DateTimeOffset expectedTimestamp = DateTimeOffset.Now;
            IConverter<PocoWithTimestamp, TableEntity> product = CreateProductUnderTest<PocoWithTimestamp>();
            PocoWithTimestamp input = new PocoWithTimestamp
            {
                Timestamp = expectedTimestamp
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedTimestamp, actual.Timestamp);
            Assert.AreEqual(expectedTimestamp.Offset, actual.Timestamp.Value.Offset);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("Timestamp"));
        }

        [Test]
        public void Convert_IfTimestampIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateTimestamp, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateTimestamp>();
            PocoWithPrivateTimestamp input = new PocoWithPrivateTimestamp
            {
                PartitionKey = expectedPartitionKey,
                TimestampPublic = DateTimeOffset.Now
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateTimestampGetter, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateTimestampGetter>();
            PocoWithPrivateTimestampGetter input = new PocoWithPrivateTimestampGetter
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticTimestamp, TableEntity> product =
                CreateProductUnderTest<PocoWithStaticTimestamp>();
            PocoWithStaticTimestamp.Timestamp = DateTimeOffset.Now;
            PocoWithStaticTimestamp input = new PocoWithStaticTimestamp
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfTimestampIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyTimestamp, TableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyTimestamp>();
            PocoWithWriteOnlyTimestamp input = new PocoWithWriteOnlyTimestamp
            {
                PartitionKey = expectedPartitionKey,
                Timestamp = DateTimeOffset.Now
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.Null(actual.Timestamp);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<PocoWithETag, TableEntity> product = CreateProductUnderTest<PocoWithETag>();
            PocoWithETag input = new PocoWithETag
            {
                ETag = expectedETag
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(new ETag(expectedETag), actual.ETag);
        }

        [Test]
        public void Convert_IfETagIsReadOnly_PopulatesETag()
        {
            // Arrange
            string expectedETag = "abc";
            IConverter<PocoWithReadOnlyETag, TableEntity> product = CreateProductUnderTest<PocoWithReadOnlyETag>();
            PocoWithReadOnlyETag input = new PocoWithReadOnlyETag
            {
                WriteETag = expectedETag
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(new ETag(expectedETag), actual.ETag);
        }

        [Test]
        public void Convert_DoesNotIncludeETagInDictionary()
        {
            // Arrange
            const string expectedETag = "RK";
            IConverter<PocoWithETag, TableEntity> product = CreateProductUnderTest<PocoWithETag>();
            PocoWithETag input = new PocoWithETag
            {
                ETag = expectedETag
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(new ETag(expectedETag), actual.ETag);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("ETag"));
        }

        [Test]
        public void Convert_IfETagIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateETag, TableEntity> product = CreateProductUnderTest<PocoWithPrivateETag>();
            PocoWithPrivateETag input = new PocoWithPrivateETag
            {
                PartitionKey = expectedPartitionKey,
                ETagPublic = "UnexpectedETag"
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(ETag), actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateETagGetter, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateETagGetter>();
            PocoWithPrivateETagGetter input = new PocoWithPrivateETagGetter
            {
                PartitionKey = expectedPartitionKey,
                ETag = "UnexpectedETag"
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(ETag), actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticETag, TableEntity> product = CreateProductUnderTest<PocoWithStaticETag>();
            PocoWithStaticETag.ETag = "UnexpectedETag";
            PocoWithStaticETag input = new PocoWithStaticETag
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(ETag), actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfETagIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyETag, TableEntity> product = CreateProductUnderTest<PocoWithWriteOnlyETag>();
            PocoWithWriteOnlyETag input = new PocoWithWriteOnlyETag
            {
                PartitionKey = expectedPartitionKey,
                ETag = "IgnoreETag"
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(default(ETag), actual.ETag);
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<PocoWithOtherProperty, TableEntity> product = CreateProductUnderTest<PocoWithOtherProperty>();
            PocoWithOtherProperty input = new PocoWithOtherProperty
            {
                OtherProperty = expectedOtherProperty
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.True(actual.ContainsKey("OtherProperty"));
            var otherProperty = actual["OtherProperty"];
            Assert.NotNull(otherProperty);
            Assert.AreEqual(expectedOtherProperty, otherProperty);
        }

        [Test]
        public void Convert_IfOtherPropertyIsReadOnly_PopulatesOtherProperty()
        {
            // Arrange
            int? expectedOtherProperty = 123;
            IConverter<PocoWithReadOnlyOtherProperty, TableEntity> product =
                CreateProductUnderTest<PocoWithReadOnlyOtherProperty>();
            PocoWithReadOnlyOtherProperty input = new PocoWithReadOnlyOtherProperty
            {
                WriteOtherProperty = expectedOtherProperty
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.True(actual.ContainsKey("OtherProperty"));
            var otherProperty = actual["OtherProperty"];
            Assert.NotNull(otherProperty);
            Assert.AreEqual(expectedOtherProperty, otherProperty);
        }

        [Test]
        public void Convert_IfOtherPropertyIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateOtherProperty, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateOtherProperty>();
            PocoWithPrivateOtherProperty input = new PocoWithPrivateOtherProperty
            {
                PartitionKey = expectedPartitionKey,
                OtherPropertyPublic = 456
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyGetterIsPrivate_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithPrivateOtherPropertyGetter, TableEntity> product =
                CreateProductUnderTest<PocoWithPrivateOtherPropertyGetter>();
            PocoWithPrivateOtherPropertyGetter input = new PocoWithPrivateOtherPropertyGetter
            {
                PartitionKey = expectedPartitionKey,
                OtherProperty = 456
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsStatic_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithStaticOtherProperty, TableEntity> product =
                CreateProductUnderTest<PocoWithStaticOtherProperty>();
            PocoWithStaticOtherProperty.OtherProperty = 456;
            PocoWithStaticOtherProperty input = new PocoWithStaticOtherProperty
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsWriteOnly_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithWriteOnlyOtherProperty, TableEntity> product =
                CreateProductUnderTest<PocoWithWriteOnlyOtherProperty>();
            PocoWithWriteOnlyOtherProperty input = new PocoWithWriteOnlyOtherProperty
            {
                PartitionKey = expectedPartitionKey,
                OtherProperty = 456
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("OtherProperty"));
            Assert.AreSame(expectedPartitionKey, actual.PartitionKey);
        }

        [Test]
        public void Convert_IfOtherPropertyIsIndexer_Ignores()
        {
            // Arrange
            const string expectedPartitionKey = "PK";
            IConverter<PocoWithIndexerOtherProperty, TableEntity> product =
                CreateProductUnderTest<PocoWithIndexerOtherProperty>();
            PocoWithIndexerOtherProperty input = new PocoWithIndexerOtherProperty
            {
                PartitionKey = expectedPartitionKey
            };
            // Act
            TableEntity actual = product.Convert(input);
            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual);
            Assert.False(actual.ContainsKey("OtherProperty"));
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
            var product = new PocoToTableEntityConverter<TInput>();
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