// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class FieldsAttributeTests
    {
        [Test]
        public void DiscoversFields([Fields]Data data)
        {
            Assert.That(data, Is.AnyOf(Data.Data1, Data.Data2));
        }

        [Test]
        public void IncludesNamedFields([Fields(nameof(Data.Data1), nameof(Data.InternalData))]Data data)
        {
            Assert.AreEqual(Data.Data1, data);
        }

        [Test]
        public void ExcludesNamedFields([Fields(Exclude = new[] { nameof(Data.Data2) })]Data data)
        {
            Assert.AreEqual(Data.Data1, data);
        }

        [Test]
        public void ExcludesNamedFieldsOverride([Fields(nameof(Data.Data1), nameof(Data.Data2), Exclude = new[] { nameof(Data.Data2) })]Data data)
        {
            Assert.AreEqual(Data.Data1, data);
        }

        public readonly struct Data : IEquatable<Data>
        {
            public static readonly Data Data1 = new Data(1);
            public static readonly Data Data2 = new Data(2);
            internal static readonly Data InternalData = new Data(3);
            private static readonly Data PrivateData = new Data(4);

            private readonly int _value;

            private Data(int value)
            {
                _value = value;
            }

            public bool Equals(Data other) => _value == other._value;
        }
    }
}
