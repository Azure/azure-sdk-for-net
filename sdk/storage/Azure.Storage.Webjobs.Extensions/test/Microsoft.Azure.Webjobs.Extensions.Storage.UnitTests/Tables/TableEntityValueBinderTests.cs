// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Tables;
using Microsoft.Azure.Cosmos.Table;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Tables
{
    public class TableEntityValueBinderTests
    {
        [Fact]
        public void HasChanged_ReturnsFalse_IfValueHasNotChanged()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };
            Type valueType = typeof(DynamicTableEntity);
            TableEntityValueBinder product = new TableEntityValueBinder(entityContext, value, valueType);

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.False(hasChanged);
        }

        [Fact]
        public void HasChanged_ReturnsTrue_IfPropertyHasBeenAdded()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };
            Type valueType = typeof(DynamicTableEntity);
            TableEntityValueBinder product = new TableEntityValueBinder(entityContext, value, valueType);

            value.Properties["Item2"] = new EntityProperty("Bar");

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.True(hasChanged);
        }

        [Fact]
        public void HasChanged_ReturnsTrue_IfValueHasChanged()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };
            Type valueType = typeof(DynamicTableEntity);
            TableEntityValueBinder product = new TableEntityValueBinder(entityContext, value, valueType);

            value.Properties["Item"].StringValue = "Bar";

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.True(hasChanged);
        }

        [Fact]
        public void HasChanged_ReturnsTrue_IfMutuableValueHasBeenMutated()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            byte[] bytes = new byte[] { 0x12 };
            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty(bytes) } }
            };
            Type valueType = typeof(DynamicTableEntity);
            TableEntityValueBinder product = new TableEntityValueBinder(entityContext, value, valueType);

            bytes[0] = 0xFE;

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.True(hasChanged);
        }

        [Fact]
        public void DeepClone_IfBinary_PreservesValue()
        {
            // Arrange
            byte[] expected = new byte[] { 0x12, 0x34 };

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Binary, property.PropertyType);
            Assert.Equal(expected, property.BinaryValue);
        }

        [Fact]
        public void DeepClone_IfEmptyBinary_PreservesValue()
        {
            // Arrange
            byte[] expected = new byte[0];

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Binary, property.PropertyType);
            Assert.Equal(expected, property.BinaryValue);
        }

        [Fact]
        public void DeepClone_IfBinaryNull_PreservesValue()
        {
            // Arrange
            byte[] input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Binary, property.PropertyType);
            Assert.Null(property.BinaryValue);
        }

        [Fact]
        public void DeepClone_IfBinary_CopiesValue()
        {
            // Arrange
            byte original = 0x12;
            byte[] expected = new byte[] { original, 0x34 };

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            expected[0] = 0xFF;
            Assert.NotNull(property);
            Assert.Equal(EdmType.Binary, property.PropertyType); // Guard
            byte[] actual = property.BinaryValue;
            Assert.NotNull(actual); // Guard
            Assert.True(actual.Length == 2); // Guard
            Assert.Equal(original, actual[0]);
        }

        [Fact]
        public void DeepClone_IfBoolean_PreservesValue()
        {
            // Arrange
            bool? expected = true;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Boolean, property.PropertyType);
            Assert.Equal(expected, property.BooleanValue);
        }

        [Fact]
        public void DeepClone_IfBooleanNull_PreservesValue()
        {
            // Arrange
            bool? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Boolean, property.PropertyType);
            Assert.Null(property.BooleanValue);
        }

        [Fact]
        public void DeepClone_IfDateTime_PreservesValue()
        {
            // Arrange
            DateTime expected = DateTime.Now;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.DateTime, property.PropertyType);
            Assert.Equal(expected, property.DateTime);
        }

        [Fact]
        public void DeepClone_IfDateTimeNull_PreservesValue()
        {
            // Arrange
            DateTime? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.DateTime, property.PropertyType);
            Assert.Null(property.DateTime);
        }

        [Fact]
        public void DeepClone_IfDouble_PreservesValue()
        {
            // Arrange
            double expected = 1.23;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Double, property.PropertyType);
            Assert.Equal(expected, property.DoubleValue);
        }

        [Fact]
        public void DeepClone_IfDoubleNull_PreservesValue()
        {
            // Arrange
            double? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Double, property.PropertyType);
            Assert.Null(property.DoubleValue);
        }

        [Fact]
        public void DeepClone_IfGuid_PreservesValue()
        {
            // Arrange
            Guid expected = Guid.NewGuid();

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Guid, property.PropertyType);
            Assert.Equal(expected, property.GuidValue);
        }

        [Fact]
        public void DeepClone_IfGuidNull_PreservesValue()
        {
            // Arrange
            Guid? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Guid, property.PropertyType);
            Assert.Null(property.GuidValue);
        }

        [Fact]
        public void DeepClone_IfInt32_PreservesValue()
        {
            // Arrange
            int expected = 123;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int32, property.PropertyType);
            Assert.Equal(expected, property.Int32Value);
        }

        [Fact]
        public void DeepClone_IfInt32Null_PreservesValue()
        {
            // Arrange
            int? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int32, property.PropertyType);
            Assert.Null(property.Int32Value);
        }

        [Fact]
        public void DeepClone_IfInt64_PreservesValue()
        {
            // Arrange
            long expected = 123;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int64, property.PropertyType);
            Assert.Equal(expected, property.Int64Value);
        }

        [Fact]
        public void DeepClone_IfInt64Null_PreservesValue()
        {
            // Arrange
            long? input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int64, property.PropertyType);
            Assert.Null(property.Int64Value);
        }

        [Fact]
        public void DeepClone_IfString_PreservesValue()
        {
            // Arrange
            string expected = "abc";

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(expected));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.String, property.PropertyType);
            Assert.Same(expected, property.StringValue);
        }

        [Fact]
        public void DeepClone_IfStringNull_PreservesValue()
        {
            // Arrange
            string input = null;

            // Act
            EntityProperty property = TableEntityValueBinder.DeepClone(new EntityProperty(input));

            // Assert
            Assert.NotNull(property);
            Assert.Equal(EdmType.String, property.PropertyType);
            Assert.Null(property.StringValue);
        }

        private class SimpleTableEntity
        {
            public string Item { get; set; }
        }
    }
}
