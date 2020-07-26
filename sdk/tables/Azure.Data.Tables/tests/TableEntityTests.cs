// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Azure.Data.Tables.Sas;
using Moq;
using NUnit.Framework;

namespace Azure.Tables.Tests
{
    public class TableEntityTests : ClientTestBase
    {
        public TableEntityTests(bool isAsync) : base(isAsync)
        { }

        private DynamicTableEntity entityWithoutPK = new DynamicTableEntity { { TableConstants.PropertyNames.RowKey, "row" } };
        private DynamicTableEntity entityWithoutRK = new DynamicTableEntity { { TableConstants.PropertyNames.PartitionKey, "partition" } };
        private DynamicTableEntity entityWithAllTypes = new DynamicTableEntity {
            { TableConstants.PropertyNames.PartitionKey, "partition" },
            { TableConstants.PropertyNames.RowKey, "row" },
            { "binary", new byte[] { 1, 2 }},
            { "boolean", true },
            { "datetime", new DateTime() },
            { "double", (double)2.0 },
            { "guid", new Guid() },
            { "int32", int.MaxValue },
            { "int64", long.MaxValue }};

        /// <summary>
        /// Validates the typed getters.
        /// </summary>
        [Test]
        public void ValidateDynamicTableEntityGetTypes()
        {
            Assert.IsInstanceOf(typeof(byte[]), entityWithAllTypes.GetBinary("binary"));
            Assert.IsInstanceOf(typeof(bool), entityWithAllTypes.GetBoolean("boolean"));
            Assert.IsInstanceOf(typeof(DateTime), entityWithAllTypes.GetDateTime("datetime"));
            Assert.IsInstanceOf(typeof(double), entityWithAllTypes.GetDouble("double"));
            Assert.IsInstanceOf(typeof(Guid), entityWithAllTypes.GetGuid("guid"));
            Assert.IsInstanceOf(typeof(int), entityWithAllTypes.GetInt32("int32"));
            Assert.IsInstanceOf(typeof(long), entityWithAllTypes.GetInt64("int64"));
        }

        /// <summary>
        /// Validates the typed getters throws InvalidOperationException when the retrieved value doesn't match the type.
        /// </summary>
        [Test]
        public void DynamicTableEntityGetWrongTypesThrows()
        {
            Assert.That(() => entityWithAllTypes.GetBinary("boolean"), Throws.InstanceOf<InvalidOperationException>(), "GetBinary should validate that the value for the inputted key is a Binary.");
            Assert.That(() => entityWithAllTypes.GetBoolean("datetime"), Throws.InstanceOf<InvalidOperationException>(), "GetBoolean should validate that the value for the inputted key is a Boolean.");
            Assert.That(() => entityWithAllTypes.GetDateTime("double"), Throws.InstanceOf<InvalidOperationException>(), "GetDateTime should validate that the value for the inputted key is a DateTime.");
            Assert.That(() => entityWithAllTypes.GetDouble("guid"), Throws.InstanceOf<InvalidOperationException>(), "GetDouble should validate that the value for the inputted key is an Double.");
            Assert.That(() => entityWithAllTypes.GetGuid("int32"), Throws.InstanceOf<InvalidOperationException>(), "GetGuid should validate that the value for the inputted key is an Guid.");
            Assert.That(() => entityWithAllTypes.GetInt32("int64"), Throws.InstanceOf<InvalidOperationException>(), "GetInt32 should validate that the value for the inputted key is a Int32.");
            Assert.That(() => entityWithAllTypes.GetInt64("binary"), Throws.InstanceOf<InvalidOperationException>(), "GetInt64 should validate that the value for the inputted key is a Int64.");
        }

        /// <summary>
        /// Validates setting values makes correct changes.
        /// </summary>
        [Test]
        public void ValidateDynamicTableEntitySetType()
        {
            // Test setting new value with same type works.
            entityWithAllTypes["boolean"] = false;
            Assert.IsFalse(entityWithAllTypes.GetBoolean("boolean"));

            // TODO: Fix error when setting an existing value to null.
        }

        /// <summary>
        /// Validates setting values to a different type throws InvalidOperationException.
        /// </summary>
        [Test]
        public void DynamicTableEntitySetWrongTypeThrows()
        {
            Assert.That(() => entityWithAllTypes["boolean"] = "A random string", Throws.InstanceOf<InvalidOperationException>(), "Setting an existing property to a new value validates that the new type matches the existing type.");
        }
    }
}
