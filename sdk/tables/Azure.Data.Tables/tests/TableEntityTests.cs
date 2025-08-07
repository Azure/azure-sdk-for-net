// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableEntityTests
    {
        private TableEntity emptyEntity = new TableEntity { { "My value was nulled!", null } };
        private TableEntity fullEntity = new TableEntity("partition", "row") {
            { TableConstants.PropertyNames.Timestamp, default(DateTimeOffset) },
            { "binary", new byte[] { 1, 2 }},
            { "binarydata", new BinaryData( new byte[] { 1, 2 })},
            { "boolean", true },
            { "datetime", new DateTime() },
            { "datetimeoffset", new DateTimeOffset() },
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
            Assert.That(fullEntity.GetBinaryData("binarydata"), Is.InstanceOf(typeof(BinaryData)));
            Assert.That(fullEntity.GetBoolean("boolean"), Is.InstanceOf(typeof(bool?)));
            Assert.That(fullEntity.GetDateTime("datetime"), Is.InstanceOf(typeof(DateTime?)));
            Assert.That(fullEntity.GetDateTimeOffset("datetimeoffset"), Is.InstanceOf(typeof(DateTimeOffset?)));
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
            Assert.That(() => fullEntity.GetBinaryData("boolean"), Throws.InstanceOf<InvalidOperationException>(), "GetBinary should validate that the value for the inputted key is a BinaryData.");
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
            Assert.That(fullEntity.GetBinaryData(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetBoolean(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetDateTime(nonexistentKey), Is.Null);
            Assert.That(fullEntity.GetDateTimeOffset(nonexistentKey), Is.Null);
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
            Assert.That(emptyEntity.GetDateTimeOffset(nulledPropertyKey), Is.Null);
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
            Assert.That(fullEntity["datetimeoffset"], Is.Not.Null);
            Assert.That(fullEntity["datetimeoffset"], Is.InstanceOf(typeof(DateTimeOffset?)));
            Assert.That(fullEntity["double"], Is.Not.Null);
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

        [Test]
        public void TypeCoercionForNumericTypes()
        {
            var entity = new TableEntity("partition", "row");

            // Initialize a property to an int value
            entity["Foo"] = 0;
            Assert.That(entity["Foo"] is int);
            Assert.That(entity["Foo"], Is.EqualTo(0));

            // Try to change the value to a double
            entity["Foo"] = 1.1;
            Assert.That(entity["Foo"] is double);
            Assert.That(entity["Foo"], Is.EqualTo(1.1));

            // Change to a double compatible int
            entity["Foo"] = 0;
            Assert.That(entity["Foo"] is double);
            Assert.That(entity["Foo"], Is.EqualTo(0));

            // Change to a double compatible int
            entity["Foo"] = 1;
            Assert.That(entity["Foo"] is double);
            Assert.That(entity["Foo"], Is.EqualTo(1));

            // Initialize a property to an int value
            entity["Foo2"] = 0;
            Assert.That(entity["Foo2"] is int);
            Assert.That(entity["Foo2"], Is.EqualTo(0));

            // Change to a long
            entity["Foo2"] = 5L;
            Assert.That(entity["Foo2"] is long);
            Assert.That(entity["Foo2"], Is.EqualTo(5L));

            // Change to a long compatible int
            entity["Foo2"] = 0;
            Assert.That(entity["Foo2"] is long);
            Assert.That(entity["Foo2"], Is.EqualTo(0));

            // Initialize a property to an int value
            entity["Foo3"] = 0;
            Assert.That(entity["Foo3"] is int);
            Assert.That(entity["Foo3"], Is.EqualTo(0));

            // Validate invalid conversions
            entity["Foo3"] = "fail";
            Assert.That(entity["Foo3"], Is.EqualTo("fail"));
            Assert.That(entity["Foo3"] is string);

            entity["Foo3"] = new byte[] { 0x02 };
            Assert.That(entity["Foo3"], Is.EqualTo(new byte[] { 0x02 }));
            Assert.That(entity["Foo3"] is byte[]);

            entity["Foo3"] = false;
            Assert.That(entity["Foo3"], Is.EqualTo(false));
            Assert.That(entity["Foo3"] is bool);

            var guid = Guid.NewGuid();
            entity["Foo3"] = guid;
            Assert.That(entity["Foo3"], Is.EqualTo(guid));
            Assert.That(entity["Foo3"] is Guid);

            var now = DateTime.Now;
            entity["Foo3"] = now;
            Assert.That(entity["Foo3"], Is.EqualTo(now));
            Assert.That(entity["Foo3"] is DateTime);
        }

        [Test]
        public void TypeCoercionForDateTimeTypes()
        {
            var entity = new TableEntity("partition", "row");
            var offsetNow = DateTimeOffset.UtcNow;
            var dateNow = offsetNow.UtcDateTime;

            // Initialize a property to an DateTimeOffset value
            entity["DTOffset"] = offsetNow;
            Assert.That(entity["DTOffset"] is DateTimeOffset);
            Assert.That(entity["DTOffset"], Is.EqualTo(offsetNow));
            Assert.That(entity.GetDateTimeOffset("DTOffset"), Is.EqualTo(offsetNow));
            Assert.That(entity.GetDateTime("DTOffset"), Is.EqualTo(dateNow));

            // Initialize a property to an DateTime value
            entity["DT"] = dateNow;
            Assert.AreEqual(typeof(DateTime), entity["DT"].GetType());
            DateTimeOffset dtoffset = (DateTime)entity["DT"];
            Assert.That(entity["DT"], Is.EqualTo(dateNow));
            Assert.That(entity.GetDateTime("DT"), Is.EqualTo(dateNow));
            Assert.That(entity.GetDateTimeOffset("DT"), Is.EqualTo(offsetNow));
        }

        [Test]
        public void TypeCoercionForStringTypes()
        {
            var entity = new TableEntity("partition", "row");

            // Initialize a property to an DateTimeOffset value
            entity["PartitionKey"] = new DateTime();
            Assert.DoesNotThrow(() => { string foo = entity.PartitionKey; });
            Assert.That(entity["PartitionKey"] is string);
        }

        [Test]
        public void GetBinaryDataRoundtripsBytes()
        {
            TableEntity te = new("a", "b");
            byte[] array = new byte[] { 1, 2, 3, 4, 5 };
            te.Add("binarydata", array);
            byte[] roundTrip = te.GetBinaryData("binarydata").ToArray();
            CollectionAssert.AreEqual(array, roundTrip);
        }
    }
}
