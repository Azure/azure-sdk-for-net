// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Core.Tests
{
    public class EnumValuesAttributeTests
    {
        [Test]
        public void DiscoversValues([EnumValues]Data data)
        {
            Assert.That(data, Is.AnyOf(Data.Field1, Data.Field2, Data.Property1, Data.Property2));
        }

        [Test]
        public void IncludesNamedValues([EnumValues(nameof(Data.Field1), nameof(Data.Property1), nameof(Data.InternalField), nameof(Data.InternalProperty))]Data data)
        {
            Assert.That(data, Is.AnyOf(Data.Field1, Data.Property1));
        }

        [Test]
        public void ExcludesNamedValues([EnumValues(Exclude = new[] { nameof(Data.Field2), nameof(Data.Property2) })]Data data)
        {
            Assert.That(data, Is.AnyOf(Data.Field1, Data.Property1));
        }

        [Test]
        public void ExcludesNamedValuesOverride([EnumValues(nameof(Data.Field1), nameof(Data.Field2), nameof(Data.Property1), nameof(Data.Property2), Exclude = new[] { nameof(Data.Field2), nameof(Data.Property2) })]Data data)
        {
            Assert.That(data, Is.AnyOf(Data.Field1, Data.Property1));
        }

        [Test]
        public void DiscoversEnumValues([EnumValues]DataEnum data)
        {
            Assert.That(data, Is.AnyOf(DataEnum.A, DataEnum.B));
        }

        [Test]
        public void IncludesNamedEnumValues([EnumValues(nameof(DataEnum.A))]DataEnum data)
        {
            Assert.AreEqual(DataEnum.A, data);
        }

        [Test]
        public void ExcludesNamedEnumValues([EnumValues(Exclude = new[] { nameof(DataEnum.B) })]DataEnum data)
        {
            Assert.AreEqual(DataEnum.A, data);
        }

        [Test]
        public void ExcludesNamedEnumValuesOverride([EnumValues(nameof(DataEnum.A), nameof(DataEnum.B), Exclude = new[] { nameof(DataEnum.B) })]DataEnum data)
        {
            Assert.AreEqual(DataEnum.A, data);
        }

        [Test]
        public void ThrowsIfNoneFound()
        {
            EnumValuesAttribute sut = new EnumValuesAttribute();

            Exception ex = Assert.Throws<InvalidDataSourceException>(() => sut.GetMembers(GetType(), "source"));
            Assert.AreEqual(@"No enumeration members found on parameter ""source"".", ex.Message);
        }

        // Should work for fields and properties alike.
        public readonly struct Data : IEquatable<Data>
        {
            public static readonly Data Field1 = new Data(1);
            public static readonly Data Field2 = new Data(2);
            public static Data ReadWriteField = new Data(5);
            internal static readonly Data InternalField = new Data(3);
            private static readonly Data PrivateField = new Data(4);

            private readonly int _value;

            private Data(int value)
            {
                _value = value;
            }

            public static Data Property1 { get; } = new Data(11);
            public static Data Property2 { get; } = new Data(12);
            public static Data ReadWriteProperty { get; set; } = new Data(15);
            internal static Data InternalProperty { get; } = new Data(13);
            private static Data PrivateProperty { get; } = new Data(14);

            public bool Equals(Data other) => _value == other._value;

            public override string ToString() => _value.ToString();
        }

        // Should also work, just in case people use this attribute for enums rather than NUnit's ValuesAttribute.
        public enum DataEnum
        {
            A,
            B,
        }
    }
}
