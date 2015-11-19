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
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.Serialization;
    using ProtoBuf;

    [DataContract]
    public class ClassOfArrayOfInt : IEquatable<ClassOfArrayOfInt>
    {
        [DataMember]
        public int[] ArrayOfInt;

        public static ClassOfArrayOfInt Create(bool nullablesAreNulls)
        {
            return new ClassOfArrayOfInt { ArrayOfInt = Utilities.GetRandom<int[]>(nullablesAreNulls), };
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassOfArrayOfInt);
        }

        public bool Equals(ClassOfArrayOfInt other)
        {
            if (other == null)
            {
                return false;
            }
            return this.ArrayOfInt.SequenceEqual(other.ArrayOfInt);
        }

        public override int GetHashCode()
        {
            return this.ArrayOfInt.GetHashCode();
        }
    }

    [ProtoContract]
    [DataContract]
    internal class IListClass : IEquatable<IListClass>
    {
        public static IListClass Create()
        {
            return new IListClass { Field1 = new List<Guid> { Guid.NewGuid() }, Field2 = new List<int> { 117 } };
        }

        public static IListClass CreateWithArray()
        {
            return new IListClass { Field1 = new[] { Guid.NewGuid(), Guid.NewGuid() }, Field2 = new List<int> { 12 } };
        }

        public static IListClass CreateWithCollection()
        {
            return new IListClass { Field1 = new Collection<Guid>() { Guid.NewGuid(), Guid.NewGuid() }, Field2 = new Collection<int>() { 12 } };
        }

        [ProtoMember(1)]
        [DataMember]
        public IList<Guid> Field1 { get; set; }

        [ProtoMember(1)]
        [DataMember]
        public IList<int> Field2 { get; set; }

        public bool Equals(IListClass other)
        {
            if (other == null)
            {
                return false;
            }

            if (!this.Field1.SequenceEqual(other.Field1))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as IListClass);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [ProtoContract]
    [DataContract]
    internal class ArrayClass : IEquatable<ArrayClass>
    {
        public static ArrayClass Create()
        {
            return new ArrayClass
            {
                ArrayField = Utilities.GetRandom<double[]>(false),
                IntArrayField = Utilities.GetRandom<int[]>(false),
                EmptyArrayField = new SimpleFlatClass[0]
            };
        }

        [ProtoMember(1)]
        [DataMember]
        public double[] ArrayField { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public SimpleFlatClass[] EmptyArrayField { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public int[] IntArrayField { get; set; }

        public bool Equals(ArrayClass other)
        {
            if (other == null)
            {
                return false;
            }

            if (!this.ArrayField.SequenceEqual(other.ArrayField))
            {
                return false;
            }

            if (!this.IntArrayField.SequenceEqual(other.IntArrayField))
            {
                return false;
            }

            if (!this.EmptyArrayField.SequenceEqual(other.EmptyArrayField))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as ArrayClass);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [ProtoContract]
    [DataContract]
    internal class JaggedArrayClass : IEquatable<JaggedArrayClass>
    {
        public static JaggedArrayClass Create(int seed = 13)
        {
            return new JaggedArrayClass { FloatArrayField = Utilities.GetRandom<float[][]>(false) };
        }

        [ProtoMember(1)]
        [DataMember]
        public float[][] FloatArrayField { get; set; }

        public bool Equals(JaggedArrayClass other)
        {
            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < this.FloatArrayField.Length; i++)
            {
                for (int j = 0; j < this.FloatArrayField[i].Length; j++)
                {
                    if (this.FloatArrayField[i][j] != other.FloatArrayField[i][j])
                    {
                        return false;
                    }
                }

                if (this.FloatArrayField[i].Length != other.FloatArrayField[i].Length)
                {
                    return false;
                }
            }

            return this.FloatArrayField.Length == other.FloatArrayField.Length;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as JaggedArrayClass);
        }

        public override int GetHashCode()
        {
            return this.FloatArrayField.GetHashCode();
        }
    }

    [ProtoContract]
    [DataContract]
    internal class MultidimArrayClass : IEquatable<MultidimArrayClass>
    {
        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body",
            Justification = "Given the nature of what this represents, this usage is appropriate. [tgs]")]
        public static MultidimArrayClass Create(int seed = 13)
        {
            return new MultidimArrayClass
            {
                ArrayField =
                    new int[2, 3, 4] { { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } }, { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } } }
            };
        }

        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member",
            Justification = "Given the nature of what this represents, this usage is appropriate. [tgs]")]
        [ProtoMember(1)]
        [DataMember]
        public int[,,] ArrayField { get; set; }

        public bool Equals(MultidimArrayClass other)
        {
            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (this.ArrayField[i, j, k] != other.ArrayField[i, j, k])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as MultidimArrayClass);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class ContainingDictionaryClass<TK, TV> : IEquatable<ContainingDictionaryClass<TK, TV>>
    {
        public static ContainingDictionaryClass<TK, TV> Create(Dictionary<TK, TV> dictionary)
        {
            return new ContainingDictionaryClass<TK, TV> { Property = dictionary };
        }

        [DataMember]
        public Dictionary<TK, TV> Property { get; set; }

        public bool Equals(ContainingDictionaryClass<TK, TV> other)
        {
            if (other == null)
            {
                return false;
            }

            return Utilities.DictionaryEquals(this.Property, other.Property);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ContainingDictionaryClass<TK, TV>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class ListInheritedClass<T> : List<T>, IEquatable<ListInheritedClass<T>>
    {
        public bool Equals(ListInheritedClass<T> other)
        {
            if (other == null)
            {
                return false;
            }

            return this.SequenceEqual(other);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ListInheritedClass<T>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class DictionaryInheritedClass<TKey, TValue> : Dictionary<TKey, TValue>, IEquatable<DictionaryInheritedClass<TKey, TValue>>
    {
        public bool Equals(DictionaryInheritedClass<TKey, TValue> other)
        {
            if (other == null)
            {
                return false;
            }

            return Utilities.DictionaryEquals(this, other);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DictionaryInheritedClass<TKey, TValue>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class DictionaryInheritedClass : Dictionary<string, string>, IEquatable<DictionaryInheritedClass>
    {
        public static DictionaryInheritedClass Create()
        {
            return new DictionaryInheritedClass { { "1", "2" }, { "3", "4" } };
        }

        public bool Equals(DictionaryInheritedClass other)
        {
            if (other == null)
            {
                return false;
            }

            return Utilities.DictionaryEquals(this, other);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DictionaryInheritedClass);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class IEnumerableClass<T> : IEquatable<IEnumerableClass<T>>
    {
        public static IEnumerableClass<T> Create(IEnumerable<T> enumerable)
        {
            return new IEnumerableClass<T> { Property = enumerable };
        }

        [DataMember]
        public IEnumerable<T> Property { get; set; }

        public bool Equals(IEnumerableClass<T> other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.Property.Count() != other.Property.Count())
            {
                return false;
            }

            return this.Property.Zip(other.Property, (a, b) => new Tuple<T, T>(a, b))
                .ToList()
                .TrueForAll(tuple => tuple.Item1.Equals(tuple.Item2));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as IEnumerableClass<T>);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
