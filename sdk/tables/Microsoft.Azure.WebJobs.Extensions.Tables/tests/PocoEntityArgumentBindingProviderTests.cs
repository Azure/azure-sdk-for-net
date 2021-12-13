// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;
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
            // Arrange
            ITableEntityArgumentBindingProvider product = new PocoEntityArgumentBindingProvider();
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
            ITableEntityArgumentBindingProvider product = new PocoEntityArgumentBindingProvider();
            Type parameterType = typeof(GenericClass<SimpleTableEntity>);
            // Act
            IArgumentBinding<TableEntityContext> binding = product.TryCreate(_parameters[1]);
            // Assert
            Assert.NotNull(binding);
        }

        private static void Parameters(ref SimpleTableEntity byRef, GenericClass<SimpleTableEntity> generic)
        {
        }

        private class SimpleTableEntity
        {
        }

        private class GenericClass<TArgument>
        {
        }
    }
}