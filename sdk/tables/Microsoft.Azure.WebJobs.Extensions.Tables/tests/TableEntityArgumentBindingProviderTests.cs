// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Azure;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityArgumentBindingProviderTests
    {
        private ParameterInfo[] _parameters;

        public TableEntityArgumentBindingProviderTests()
        {
            _parameters = this.GetType().GetMethod("Parameters", BindingFlags.NonPublic | BindingFlags.Static).GetParameters();
        }

        [Test]
        public void Create_ReturnsNull_IfByRefParameter()
        {
            // Arrange
            ITableEntityArgumentBindingProvider product = new TableEntityArgumentBindingProvider();
            Type parameterType = typeof(SimpleTableEntity).MakeByRefType();
            // Act
            IArgumentBinding<TableEntityContext> binding = product.TryCreate(_parameters[0]);
            // Assert
            Assert.Null(binding);
        }

        [Test]
        public void Create_ReturnsBinding_IfContainsResolvedGenericParameter()
        {
            // Arrange
            ITableEntityArgumentBindingProvider product = new TableEntityArgumentBindingProvider();
            Type parameterType = typeof(GenericClass<int>);
            // Act
            IArgumentBinding<TableEntityContext> binding = product.TryCreate(_parameters[1]);
            // Assert
            Assert.NotNull(binding);
        }

        private static void Parameters(ref SimpleTableEntity byRef, GenericClass<int> generic)
        {
        }

        private class SimpleTableEntity : ITableEntity
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }

        private class GenericClass<TArgument> : ITableEntity
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }
    }
}