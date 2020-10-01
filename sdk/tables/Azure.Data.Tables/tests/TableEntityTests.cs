// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Azure.Tables.Tests
{
    public class TableEntityTests
    {
        private TableEntity emptyEntity = new TableEntity { { "My value was nulled!", null } };
        private TableEntity fullEntity = new TableEntity("partition", "row") {
            { TableConstants.PropertyNames.TimeStamp, default(DateTimeOffset) },
            { "binary", new byte[] { 1, 2 }},
            { "boolean", true },
            { "datetime", new DateTime() },
            { "double", (double)2.0 },
            { "guid", new Guid() },
            { "int32", int.MaxValue },
            { "int64", long.MaxValue },
            { "string", "hello!" }};

        private string nulledPropertyKey = "My value was nulled!";
        private string nonexistentKey = "My value was never set!";

        /// <summary>
        /// Validates the typed getters.
        /// </summary>
        [Test]
        public void ValidateDictionaryEntityGetTypes()
        {
            Assert.That(fullEntity.GetBinary("binary"), Is.InstanceOf(typeof(byte[])));
            Assert.That(fullEntity.GetBoolean("boolean"), Is.InstanceOf(typeof(bool?)));
            Assert.That(fullEntity.GetDateTime("datetime"), Is.InstanceOf(typeof(DateTime?)));
            Assert.That(fullEntity.GetDouble("double"), Is.InstanceOf(typeof(double?)));
            Assert.That(fullEntity.GetGuid("guid"), Is.InstanceOf(typeof(Guid)));
            Assert.That(fullEntity.GetInt32("int32"), Is.InstanceOf(typeof(int?)));
            Assert.That(fullEntity.GetInt64("int64"), Is.InstanceOf(typeof(long?)));
            Assert.That(fullEntity.GetString("string"), Is.InstanceOf(typeof(string)));
        }

        /// <summary>
        /// Validates the typed getters throws InvalidOperationException when the retrieved value doesn't match the type.
        /// </summary>
        [Test]
        public void DictionaryEntityGetWrongTypesThrows()
        {
            Assert.That(() => fullEntity.GetBinary("boolean"), Throws.InstanceOf<InvalidOperationException>(), "GetBinary should validate that the value for the inputted key is a Binary.");
            Assert.That(() => fullEntity.GetBoolean("datetime"), Throws.InstanceOf<InvalidOperationException>(), "GetBoolean should validate that the value for the inputted key is a Boolean.");
            Assert.That(() => fullEntity.GetDateTime("double"), Throws.InstanceOf<InvalidOperationException>(), "GetDateTime should validate that the value for the inputted key is a DateTime.");
            Assert.That(() => fullEntity.GetDouble("guid"), Throws.InstanceOf<InvalidOperationException>(), "GetDouble should validate that the value for the inputted key is an Double.");
            Assert.That(() => fullEntity.GetGuid("int32"), Throws.InstanceOf<InvalidOperationException>(), "GetGuid should validate that the value for the inputted key is an Guid.");
            Assert.That(() => fullEntity.GetInt32("int64"), Throws.InstanceOf<InvalidOperationException>(), "GetInt32 should validate that the value for the inputted key is a Int32.");
            Assert.That(() => fullEntity.GetInt64("binary"), Throws.InstanceOf<InvalidOperationException>(), "GetInt64 should validate that the value for the inputted key is a Int64.");
            Assert.That(() => fullEntity.GetString("binary"), Throws.InstanceOf<InvalidOperationException>(), "GetString should validate that the value for the inputted key is a string.");
        }

        /// <summary>
        /// Validates typed getters for nonexistent properties.
        /// </summary>
        [Test]
        public void ValidateDictionaryEntityGetTypeForNonexistentProperties()
        {
            Assert.That(fullEntity.GetBinary(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetBoolean(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetDateTime(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetDouble(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetGuid(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetInt32(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetInt64(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetString(nonexistentKey), Is.Null);
        }

        /// <summary>
        /// Validates typed getters for nulled properties.
        /// </summary>
        [Test]
        public void ValidateDictionaryEntityGetTypeForNulledProperties()
        {
            Assert.That(emptyEntity.GetBinary(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetBoolean(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetDateTime(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetDouble(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetGuid(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetInt32(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetInt64(nulledPropertyKey), Is.Null);
            Assert.That(emptyEntity.GetString(nulledPropertyKey), Is.Null);
        }

        /// <summary>
        /// Validates the typed getters.
        /// </summary>
        [Test]
        public void ValidateDictionaryEntityGetPropertiesWithIndexer()
        {
            Assert.That(fullEntity["binary"], Is.Not.Null);
            Assert.That(fullEntity["binary"], Is.InstanceOf(typeof(byte[])));
            Assert.That(fullEntity["boolean"], Is.Not.Null);
            Assert.That(fullEntity["boolean"], Is.InstanceOf(typeof(bool?)));
            Assert.That(fullEntity["datetime"], Is.Not.Null);
            Assert.That(fullEntity["datetime"], Is.InstanceOf(typeof(DateTime?)));
            Assert.That(fullEntity["double"], Is.Not.Null);
            Assert.That(fullEntity["double"], Is.InstanceOf(typeof(double?)));
            Assert.That(fullEntity["guid"], Is.Not.Null);
            Assert.That(fullEntity["guid"], Is.InstanceOf(typeof(Guid)));
            Assert.That(fullEntity["int32"], Is.Not.Null);
            Assert.That(fullEntity["int32"], Is.InstanceOf(typeof(int?)));
            Assert.That(fullEntity["int64"], Is.Not.Null);
            Assert.That(fullEntity["int64"], Is.InstanceOf(typeof(long?)));
            Assert.That(fullEntity["string"], Is.Not.Null);
            Assert.That(fullEntity["string"], Is.InstanceOf(typeof(string)));

            // Timestamp property returned as object casted as DateTimeOffset?
            Assert.That(fullEntity.Timestamp, Is.Not.Null);
            Assert.That(fullEntity.Timestamp, Is.InstanceOf(typeof(DateTimeOffset?)));
        }

        /// <summary>
        /// Validates getting properties with the indexer that either don't exist or were set to null.
        /// </summary>
        [Test]
        public void DictionaryEntityGetNullOrNonexistentPropertiesWithIndexer()
        {
            var nonexistentKey = "I was never set!";

            // Test getting nonexistent property works.
            Assert.That(emptyEntity[nonexistentKey], Is.Null);

            // Test getting a property that was set to null.
            Assert.That(emptyEntity[nulledPropertyKey], Is.Null);
        }

        /// <summary>
        /// Validates setting values makes correct changes.
        /// </summary>
        [Test]
        public void ValidateDictionaryEntitySetType()
        {
            var entity = new TableEntity("partition", "row") { { "exampleBool", true } };

            // Test setting an existing property with the same type works.
            entity["exampleBool"] = false;
            Assert.That(entity.GetBoolean("exampleBool").Value, Is.False);
        }

        /// <summary>
        /// Validates setting values to a different type throws InvalidOperationException.
        /// </summary>
        [Test]
        public void DictionaryEntitySetWrongTypeThrows()
        {
            var entity = new TableEntity("partition", "row") { { "exampleBool", true } };

            Assert.That(() => entity["exampleBool"] = "A random string", Throws.InstanceOf<InvalidOperationException>(), "Setting an existing property to a value with mismatched types should throw an exception.");
        }

        /// <summary>
        /// Validates setting required and additional properties involving null.
        /// </summary>
        [Test]
        public void DictionaryEntitySetNullProperties()
        {
            var entity = new TableEntity("partition", "row");

            // Test setting new property works.
            string stringKey = "key :D";
            string stringValue = "value D:";
            Assert.That(entity[stringKey], Is.Null);
            entity[stringKey] = stringValue;
            Assert.That(entity[stringKey], Is.EqualTo(stringValue));

            // Test setting existing value to null.
            entity[stringKey] = null;
            Assert.That(entity[stringKey], Is.Null);

            // Test setting existing null value to a non-null value.
            entity[stringKey] = stringValue;
            Assert.That(entity[stringKey], Is.EqualTo(stringValue));
        }
    }
}
