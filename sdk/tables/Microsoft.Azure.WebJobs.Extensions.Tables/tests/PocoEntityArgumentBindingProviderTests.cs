// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class PocoEntityArgumentBindingProviderTests
    {
        private ParameterInfo[] _parameters;

        public PocoEntityArgumentBindingProviderTests()
        {
            _parameters = this.GetType().GetMethod("Parameters", BindingFlags.NonPublic | BindingFlags.Static).GetParameters();
        }

        [Test]
        public void Create_ReturnsNull_IfByRefParameter()
        {
            var converterMock = CreateConverterMock(typeof(SimpleTableEntity));

            // Act
            IArgumentBinding<TableEntityContext> binding = TableAttributeBindingProvider.TryCreatePocoBinding(_parameters[0], converterMock.Object);
            // Assert
            Assert.Null(binding);
        }

        [Test]
        public void Create_ReturnsBinding_IfContainsResolvedGenericParameter()
        {
            var converterMock = CreateConverterMock(typeof(GenericClass<SimpleTableEntity>));
            // Act
            IArgumentBinding<TableEntityContext> binding = TableAttributeBindingProvider.TryCreatePocoBinding(_parameters[1], converterMock.Object);
            // Assert
            Assert.NotNull(binding);
        }

        [Test]
        public void Create_ReturnsBinding_IfImplementsITableEntity()
        {
            var converterMock = CreateConverterMock(typeof(SimpleITableEntity));
            // Act
            IArgumentBinding<TableEntityContext> binding = TableAttributeBindingProvider.TryCreatePocoBinding(_parameters[2], converterMock.Object);
            // Assert
            Assert.NotNull(binding);
        }

        private static Mock<IConverterManager> CreateConverterMock(Type converterType)
        {
            var converterMock = new Mock<IConverterManager>(MockBehavior.Strict);
            converterMock.Setup(c => c.GetConverter<TableAttribute>(typeof(TableEntity), converterType))
                .Returns<Type, Type>((_, _) => (_, _, _) => Task.FromResult<object>(null));
            converterMock.Setup(c => c.GetConverter<TableAttribute>(converterType, typeof(TableEntity)))
                .Returns<Type, Type>((_, _) => (_, _, _) => Task.FromResult<object>(null));
            return converterMock;
        }

        private static void Parameters(ref SimpleTableEntity byRef, GenericClass<SimpleTableEntity> generic, SimpleITableEntity p2)
        {
        }

        private class SimpleTableEntity
        {
        }

        private class SimpleITableEntity: ITableEntity
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }

        private class GenericClass<TArgument>
        {
        }
    }
}