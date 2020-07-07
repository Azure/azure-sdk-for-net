// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Tables;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Tables
{
    public class PocoEntityValueBinderTests
    {
        [Fact]
        public void HasChanged_ReturnsFalse_IfValueHasNotChanged()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            SimpleTableEntity value = new SimpleTableEntity { Item = "Foo" };
            Type valueType = typeof(SimpleTableEntity);
            PocoEntityValueBinder<SimpleTableEntity> product = new PocoEntityValueBinder<SimpleTableEntity>(
                entityContext, "etag", value);

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.False(hasChanged);
        }

        [Fact]
        public void HasChanged_ReturnsTrue_IfValueHasChanged()
        {
            // Arrange
            TableEntityContext entityContext = new TableEntityContext();
            SimpleTableEntity value = new SimpleTableEntity { Item = "Foo" };
            Type valueType = typeof(SimpleTableEntity);
            PocoEntityValueBinder<SimpleTableEntity> product = new PocoEntityValueBinder<SimpleTableEntity>(
                entityContext, "etag", value);

            value.Item = "Bar";

            // Act
            bool hasChanged = product.HasChanged;

            // Assert
            Assert.True(hasChanged);
        }

        private class SimpleTableEntity
        {
            public string Item { get; set; }
        }
    }
}
