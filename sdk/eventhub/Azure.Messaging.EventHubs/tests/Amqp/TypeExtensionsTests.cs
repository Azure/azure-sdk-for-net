// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.EventHubs.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TypeExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TypeExtensionsTests
    {
        /// <summary>
        ///   The set of test cases for the valid known types for AMQP properties.
        /// </summary>
        ///
        public static IEnumerable<object[]> ValidTypeTestCases()
        {
            foreach (var name in Enum.GetNames(typeof(AmqpProperty.Type)))
            {
                // Null and Unknown are special cases that should be tested for specifically.  Stream
                // intentionally does not have a mapping.

                if ((name == AmqpProperty.Type.Null.ToString())
                    || (name == AmqpProperty.Type.Unknown.ToString())
                    || (name == AmqpProperty.Type.Stream.ToString()))
                {
                    continue;
                }

                // Uri exists in a different assembly for .NET core then the full framework.  Rather than
                // using a more robust approach to reference the type, take the simple approach and cheat.

                if (name == AmqpProperty.Type.Uri.ToString())
                {
                    yield return new object[] { typeof(Uri) };
                    continue;
                }

                yield return new object[] { Type.GetType($"System.{ name }", true, true) };
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TypeExtensions.ToAmqpPropertyType" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToAmqpPropertyTypeAllowsNull()
        {
            Assert.That(((Type)null).ToAmqpPropertyType(), Is.EqualTo(AmqpProperty.Type.Null));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TypeExtensions.ToAmqpPropertyType" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ValidTypeTestCases))]
        public void ToAmqpPropertyMapsKnownTypes(Type knownType)
        {
            AmqpProperty.Type amqpType = knownType.ToAmqpPropertyType();

            Assert.That(amqpType, Is.Not.EqualTo(AmqpProperty.Type.Null), "Known types should not map to Null");
            Assert.That(amqpType, Is.Not.EqualTo(AmqpProperty.Type.Unknown), "Known types should not map to Unknown");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TypeExtensions.ToAmqpPropertyType" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(typeof(ArgumentTests))]
        [TestCase(typeof(DBNull))]
        [TestCase(typeof(Exception))]
        public void ToAmqpPropertyDoesNotMapUnknownTypes(Type unknownType)
        {
            Assert.That(unknownType.ToAmqpPropertyType(), Is.EqualTo(AmqpProperty.Type.Unknown));
        }
    }
}
