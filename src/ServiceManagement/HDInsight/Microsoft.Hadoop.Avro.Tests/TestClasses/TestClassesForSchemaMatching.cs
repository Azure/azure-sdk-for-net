// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.Serialization;

    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Used by reflection."),
     DataContract(Name = "WriterClass")]
    internal class WriterClass : IEquatable<WriterClass>
    {
        [DataMember]
        public bool BoolA = Utilities.GetRandom<bool>(false);
        [DataMember]
        public bool BoolB = Utilities.GetRandom<bool>(false);
        [DataMember]
        public float FloatA = Utilities.GetRandom<float>(false);
        [DataMember]
        public float FloatB = Utilities.GetRandom<float>(false);
        [DataMember]
        public double DoubleA = Utilities.GetRandom<double>(false);
        [DataMember]
        public double DoubleB = Utilities.GetRandom<double>(false);
        [DataMember]
        public int IntA = Utilities.GetRandom<int>(false);
        [DataMember]
        public int IntB = Utilities.GetRandom<int>(false);
        [DataMember]
        public long LongA = Utilities.GetRandom<int>(false);
        [DataMember]
        public long LongB = Utilities.GetRandom<int>(false);
        [DataMember]
        public string StringA = Utilities.GetRandom<string>(false);
        [DataMember]
        public string StringB = Utilities.GetRandom<string>(false);
        [DataMember]
        public byte[] ByteArrayA = Utilities.GetRandom<byte[]>(false);
        [DataMember]
        public byte[] ByteArrayB = Utilities.GetRandom<byte[]>(false);
        [DataMember]
        public double[] DoubleArrayA = Utilities.GetRandom<double[]>(false);
        [DataMember]
        public double[] DoubleArrayB = Utilities.GetRandom<double[]>(false);
        [DataMember]
        public ClassOfInt[] SimpleClassArrayA = { ClassOfInt.Create(true), ClassOfInt.Create(true) };
        [DataMember]
        public List<Recursive> RecursiveListA = new List<Recursive> { Recursive.Create(), Recursive.Create() };
        [DataMember]
        public Dictionary<Uri, Recursive> RecursiveDictionaryA = new Dictionary<Uri, Recursive>
        {
            { Utilities.GetRandom<Uri>(false), Recursive.Create() },
            { Utilities.GetRandom<Uri>(false), Recursive.Create() }
        };
        [DataMember]
        public Suit Suit { get; set; }
        [DataMember]
        public Guid Guid { get; set; }

        public bool Equals(WriterClass other)
        {
            if (other == null)
            {
                return false;
            }

            return this.BoolA == other.BoolA
                && this.BoolB == other.BoolB
                && this.FloatA == other.FloatA
                && this.FloatB == other.FloatB
                && this.DoubleA == other.DoubleA
                && this.DoubleB == other.DoubleB
                && this.IntA == other.IntA
                && this.IntB == other.IntB
                && this.LongA == other.LongA
                && this.LongB == other.LongB
                && this.StringA == other.StringA
                && this.StringB == other.StringB
                && this.ByteArrayA.SequenceEqual(other.ByteArrayA)
                && this.ByteArrayB.SequenceEqual(other.ByteArrayB)
                && this.DoubleArrayA.SequenceEqual(other.DoubleArrayA)
                && this.DoubleArrayB.SequenceEqual(other.DoubleArrayB)
                && this.SimpleClassArrayA.SequenceEqual(other.SimpleClassArrayA)
                && this.RecursiveListA.SequenceEqual(other.RecursiveListA)
                && Utilities.DictionaryEquals(this.RecursiveDictionaryA, other.RecursiveDictionaryA)
                && this.Suit == other.Suit
                && this.Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as WriterClass);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    [DataContract(Name = "WriterClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "It is created by deserialzer.")]
    internal class EmptyClass
    {
    }

    [DataContract(Name = "WriterClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "It is created by deserialzer.")]
    internal class WriterClassWithPermutatedFields
    {
        [DataMember]
        public double DoubleB = 0;
        [DataMember]
        public float FloatB = 0;
        [DataMember]
        public float FloatA = 0;
        [DataMember]
        public bool BoolB = false;
        [DataMember]
        public bool BoolA = false;
        [DataMember]
        public double DoubleA = 0;
    }

    [DataContract(Name = "WriterClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "It is created by deserialzer.")]
    internal class WriterClassWithMissingAndAddedFields
    {
        [DataMember]
        public bool BoolC = false;
        [DataMember]
        public bool BoolB = false;
        [DataMember]
        public float FloatA = 0;
        [DataMember]
        public float FloatC = 0;
        [DataMember]
        public double DoubleC = 0;
        [DataMember]
        public double DoubleB = 0;
        [DataMember]
        public int IntB = 0;
        [DataMember]
        public long LongB = 0;
        [DataMember]
        public string StringB = string.Empty;
        [DataMember]
        public byte[] ByteArrayB = { };
        [DataMember]
        public double[] DoubleArrayB = { 1, 6, 7, 8 };
    }

    [DataContract]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class ClassWithPromotionalFields
    {
        private static readonly Random Random = new Random(13);

        [DataMember]
        public int IntToLongField = Random.Next();

        [DataMember]
        public int IntToFloatField = Random.Next();

        [DataMember]
        public int IntToDoubleField = Random.Next();

        [DataMember]
        public long LongToFloatField = Random.Next();

        [DataMember]
        public long LongToDoubleField = Random.Next();

        [DataMember]
        public float FloatToDoubleField = (float)Random.NextDouble();
    }

    [DataContract(Name = "ClassWithPromotionalFields")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class ReaderClassWithPromotionalFields
    {
        [DataMember]
        public long IntToLongField = 0;

        [DataMember]
        public float IntToFloatField = 0;

        [DataMember]
        public double IntToDoubleField = 0;

        [DataMember]
        public float LongToFloatField = 0;

        [DataMember]
        public double LongToDoubleField = 0;

        [DataMember]
        public double FloatToDoubleField = 0;
    }

    [DataContract(Name = "ClassWithPromotionalInt", Namespace = "test")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "It is created by deserializer.")]
    internal class ClassWithPromotionalInt
    {
        [DataMember]
        internal int A = 0;

        [DataMember]
        public int B = 0;

        [DataMember]
        public int C = 0;
    }

    [DataContract(Name = "ClassWithPromotionalInt")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "It is created by deserialzer.")]
    internal class ClassWithPromotionalInt4MatchCase
    {
        [DataMember]
        public long A = 11;

        [DataMember]
        public float B = 21;

        [DataMember]
        public double C = 31;
    }

    [DataContract(Name = "SimpleIntClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleIntClassWithExtraFields
    {
        [DataMember]
        public int ExtraFieldInt { get; set; }

        [DataMember]
        public float ExtraFieldFloat { get; set; }

        [DataMember]
        public long ExtraFieldLong { get; set; }

        [DataMember]
        public int IntField { get; set; }

        [DataMember]
        public double ExtraFieldDouble { get; set; }
        
        [DataMember]
        public string ExtraFieldString { get; set; }

        [DataMember]
        public bool ExtraFieldBool { get; set; }
    }

    [DataContract(Name = "Suit")]
    internal enum SuitWithExtraFields
    {
        [EnumMember]
        Spades,
        [EnumMember]
        Hearts,
        [EnumMember]
        Diamonds,
        [EnumMember]
        Clubs,
        [EnumMember]
        ExtraField1,
        [EnumMember]
        ExtraField2,
        [EnumMember]
        ExtraField3
    }

    [DataContract(Name = "Suit")]
    internal enum SuitAllCaps
    {
        [EnumMember]
        HEARTS,
        [EnumMember]
        SPADES,
        [EnumMember]
        DIAMONDS,
        [EnumMember]
        CLUBS
    }

    [DataContract(Name = "Suit")]
    internal enum SuitMissingSymbols
    {
        [EnumMember]
        Spades,
        [EnumMember]
        Hearts,
        [EnumMember]
        Diamonds
    }

    [DataContract]
    internal enum Suit
    {
        [EnumMember]
        Spades,
        [EnumMember]
        Hearts,
        [EnumMember]
        Diamonds,
        [EnumMember]
        Clubs
    }

    [DataContract(Name = "SimpleIntClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleIntClassWithStringFieldType
    {
        [DataMember]
        public string IntField { get; set; }
    }

    [DataContract(Name = "SimpleIntClass")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleIntClassWithDifferentFieldName
    {
        [DataMember]
        public string IntFieldChanged { get; set; }
    }

    [DataContract(Name = "SimpleMap")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleMap
    {
        [DataMember]
        public Dictionary<string, string> Values { get; set; }
    }

    [DataContract(Name = "SimpleMap")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleMapWithLongValues
    {
        [DataMember]
        public Dictionary<string, long> Values { get; set; }
    }

    [DataContract(Name = "SimpleMap")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Type is used by serializer.")]
    internal class SimpleMapWithReaderClassWithPromotionalFields
    {
        [DataMember]
        public Dictionary<string, ReaderClassWithPromotionalFields> Values { get; set; }
    }
}