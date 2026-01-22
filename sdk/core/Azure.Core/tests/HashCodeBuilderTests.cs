// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HashCodeBuilderTests
    {
        [Test]
        public static void HashCode_Add_HashCode()
        {
            var hc1 = new HashCodeBuilder();
            hc1.Add("Hello");

            var hc2 = new HashCodeBuilder();
            hc2.Add("Hello".GetHashCode());

            Assert.That(hc2.ToHashCode(), Is.EqualTo(hc1.ToHashCode()));
        }

        [Test]
        public static void HashCode_Add_Generic()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(new ConstHashCodeType());

            var expected = new HashCodeBuilder();
            expected.Add(1);
            expected.Add(ConstComparer.ConstantValue);

            Assert.That(hc.ToHashCode(), Is.EqualTo(expected.ToHashCode()));
        }

        [Test]
        public static void HashCode_Add_Null()
        {
            var hc = new HashCodeBuilder();
            hc.Add<string>(null);

            var expected = new HashCodeBuilder();
            expected.Add(EqualityComparer<string>.Default.GetHashCode(null));

            Assert.That(hc.ToHashCode(), Is.EqualTo(expected.ToHashCode()));
        }

        [Test]
        public static void HashCode_Add_GenericEqualityComparer()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add("Hello", new ConstComparer());

            var expected = new HashCodeBuilder();
            expected.Add(1);
            expected.Add(ConstComparer.ConstantValue);

            Assert.That(hc.ToHashCode(), Is.EqualTo(expected.ToHashCode()));
        }

        [Test]
        public static void HashCode_Add_NullEqualityComparer()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add("Hello", null);

            var expected = new HashCodeBuilder();
            expected.Add(1);
            expected.Add("Hello");

            Assert.That(hc.ToHashCode(), Is.EqualTo(expected.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine()
        {
            var hcs = new int[]
            {
                HashCodeBuilder.Combine(1),
                HashCodeBuilder.Combine(1, 2),
                HashCodeBuilder.Combine(1, 2, 3),
                HashCodeBuilder.Combine(1, 2, 3, 4),
                HashCodeBuilder.Combine(1, 2, 3, 4, 5),
                HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6),
                HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6, 7),
                HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6, 7, 8),

                HashCodeBuilder.Combine(2),
                HashCodeBuilder.Combine(2, 3),
                HashCodeBuilder.Combine(2, 3, 4),
                HashCodeBuilder.Combine(2, 3, 4, 5),
                HashCodeBuilder.Combine(2, 3, 4, 5, 6),
                HashCodeBuilder.Combine(2, 3, 4, 5, 6, 7),
                HashCodeBuilder.Combine(2, 3, 4, 5, 6, 7, 8),
                HashCodeBuilder.Combine(2, 3, 4, 5, 6, 7, 8, 9),
            };

            for (int i = 0; i < hcs.Length; i++)
                for (int j = 0; j < hcs.Length; j++)
                {
                    if (i == j)
                        continue;
                    Assert.That(hcs[j], Is.Not.EqualTo(hcs[i]));
                }
        }

        [Test]
        public static void HashCode_Combine_Add_1()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            Assert.That(HashCodeBuilder.Combine(1), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_2()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            Assert.That(HashCodeBuilder.Combine(1, 2), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_3()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_4()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            hc.Add(4);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3, 4), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_5()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            hc.Add(4);
            hc.Add(5);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3, 4, 5), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_6()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            hc.Add(4);
            hc.Add(5);
            hc.Add(6);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_7()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            hc.Add(4);
            hc.Add(5);
            hc.Add(6);
            hc.Add(7);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6, 7), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_Combine_Add_8()
        {
            var hc = new HashCodeBuilder();
            hc.Add(1);
            hc.Add(2);
            hc.Add(3);
            hc.Add(4);
            hc.Add(5);
            hc.Add(6);
            hc.Add(7);
            hc.Add(8);
            Assert.That(HashCodeBuilder.Combine(1, 2, 3, 4, 5, 6, 7, 8), Is.EqualTo(hc.ToHashCode()));
        }

        [Test]
        public static void HashCode_GetHashCode()
        {
            var hc = new HashCodeBuilder();

            Assert.Throws<NotSupportedException>(() => hc.GetHashCode());
        }

        [Test]
        public static void HashCode_Equals()
        {
            var hc = new HashCodeBuilder();

            Assert.Throws<NotSupportedException>(() => hc.Equals(hc));
        }

        [Test]
        public static void HashCode_GetHashCode_Boxed()
        {
            var hc = new HashCodeBuilder();
            var obj = (object)hc;

            Assert.Throws<NotSupportedException>(() => obj.GetHashCode());
        }

        [Test]
        public static void HashCode_Equals_Boxed()
        {
            var hc = new HashCodeBuilder();
            var obj = (object)hc;

            Assert.Throws<NotSupportedException>(() => obj.Equals(obj));
        }

        public class ConstComparer : System.Collections.Generic.IEqualityComparer<string>
        {
            public const int ConstantValue = 1234;

            public bool Equals(string x, string y) => false;
            public int GetHashCode(string obj) => ConstantValue;
        }

        public class ConstHashCodeType
        {
            public override int GetHashCode() => ConstComparer.ConstantValue;
        }
    }
}
