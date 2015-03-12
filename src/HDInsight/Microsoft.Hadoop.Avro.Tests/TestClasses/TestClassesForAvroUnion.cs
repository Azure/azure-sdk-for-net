namespace Microsoft.Hadoop.Avro.Tests.TestClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    internal class ClassOfUnion : IEquatable<ClassOfUnion>
    {
        public static ClassOfUnion Create()
        {
            return new ClassOfUnion
                   {
                       IntClassOfIntNullFieldClassOfInt = ClassOfInt.Create(false),
                       IntStringNullFieldInt = Utilities.GetRandom<int>(false),
                       IntStringNullFieldString = Utilities.GetRandom<string>(false),
                       IntStringNullFieldNull = null
                   };
        }

        [DataMember]
        [AvroUnion(typeof(int), typeof(ClassOfInt), typeof(AvroNull))]
        public object IntClassOfIntNullFieldClassOfInt;

        [DataMember]
        [AvroUnion(typeof(int), typeof(string), typeof(AvroNull))]
        public object IntStringNullFieldInt { get; set; }

        [DataMember]
        [AvroUnion(typeof(int), typeof(string), typeof(AvroNull))]
        public object IntStringNullFieldNull { get; set; }

        [DataMember]
        [AvroUnion(typeof(int), typeof(string), typeof(AvroNull))]
        public object IntStringNullFieldString { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassOfUnion);
        }

        public bool Equals(ClassOfUnion other)
        {
            if (other == null)
            {
                return false;
            }

            return this.IntClassOfIntNullFieldClassOfInt.Equals(other.IntClassOfIntNullFieldClassOfInt)
                   && this.IntStringNullFieldInt.Equals(other.IntStringNullFieldInt)
                   && this.IntStringNullFieldString.Equals(other.IntStringNullFieldString) 
                   && this.IntStringNullFieldNull == other.IntStringNullFieldNull;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Square))]
    [KnownType(typeof(AnotherSquare))]
    internal class ClassWithKnownTypesAndAvroUnion : IEquatable<ClassWithKnownTypesAndAvroUnion>
    {
        [AvroUnion(typeof(AnotherSquare))]
        [DataMember]
        public AnotherAbstractShape ASquare { get; set; }

        [DataMember]
        public int IntField { get; set; }

        [AvroUnion(typeof(ClassImplementingInterface))]
        [DataMember]
        public IInterface Interface { get; set; }

        [DataMember]
        public AbstractShape Rect { get; set; }

        public static ClassWithKnownTypesAndAvroUnion Create()
        {
            return new ClassWithKnownTypesAndAvroUnion
            {
                IntField = Utilities.GetRandom<int>(false),
                Rect = Rectangle.Create(),
                ASquare = AnotherSquare.Create(),
                Interface = ClassImplementingInterface.Create()
            };
        }

        public bool Equals(ClassWithKnownTypesAndAvroUnion other)
        {
            if (other == null)
            {
                return false;
            }

            return this.IntField == other.IntField
                && this.Rect.Equals(other.Rect)
                && this.ASquare.Equals(other.ASquare)
                && this.Interface.Equals(other.Interface);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassWithKnownTypesAndAvroUnion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class ClassOfUnionWith2ArrayAndMap : IEquatable<ClassOfUnionWith2ArrayAndMap>
    {
        public static ClassOfUnionWith2ArrayAndMap Create()
        {
            return new ClassOfUnionWith2ArrayAndMap
            {
                IntClassOfIntNullFieldClassOfIntArray = new [] { ClassOfInt.Create(false) },
                IntClassOfIntNullFieldClassOfIntMap = new Dictionary<string, ClassOfInt>()
                {
                    {"TestKey", ClassOfInt.Create(false)}
                },
                IntStringNullFieldInt = new [] { Utilities.GetRandom<int>(false) },
                IntStringNullFieldString = new [] { Utilities.GetRandom<string>(false) },
                IntStringNullFieldNull = null
            };
        }

        [DataMember]
        [AvroUnion(typeof(int[]), typeof(ClassOfInt[]), typeof(AvroNull))]
        public object IntClassOfIntNullFieldClassOfIntArray;

        [DataMember]
        [AvroUnion(typeof(Dictionary<string, int>), typeof(Dictionary<string, ClassOfInt>), typeof(AvroNull))]
        public object IntClassOfIntNullFieldClassOfIntMap;

        [DataMember]
        [AvroUnion(typeof(int[]), typeof(string[]), typeof(AvroNull))]
        public object IntStringNullFieldInt { get; set; }

        [DataMember]
        [AvroUnion(typeof(int[]), typeof(string[]), typeof(AvroNull))]
        public object IntStringNullFieldNull { get; set; }

        [DataMember]
        [AvroUnion(typeof(int[]), typeof(string[]), typeof(AvroNull))]
        public object IntStringNullFieldString { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassOfUnionWith2ArrayAndMap);
        }

        public bool Equals(ClassOfUnionWith2ArrayAndMap other)
        {
            if (other == null)
            {
                return false;
            }

            return CollectionEquals<ClassOfInt>(this.IntClassOfIntNullFieldClassOfIntArray, other.IntClassOfIntNullFieldClassOfIntArray)
                   && DictionaryEquals<string, ClassOfInt>(this.IntClassOfIntNullFieldClassOfIntMap, other.IntClassOfIntNullFieldClassOfIntMap)
                   && CollectionEquals<int>(this.IntStringNullFieldInt, other.IntStringNullFieldInt)
                   && CollectionEquals<string>(this.IntStringNullFieldString, other.IntStringNullFieldString)
                   && this.IntStringNullFieldNull == other.IntStringNullFieldNull;
        }

        private bool DictionaryEquals<TKey, TValue>(object object1, object object2)
        {
            var map1 = object1 as IDictionary<TKey, TValue>;
            var map2 = object2 as IDictionary<TKey, TValue>;
            if (map1 != null && map2 != null && map1.Count == map2.Count)
            {
                return map1.SequenceEqual(map2);
            }

            return false;
        }

        public bool CollectionEquals<T>(object object1, object object2)
        {
            var array1 = object1 as T[];
            var array2 = object2 as T[];
            if (array1 != null && array2 != null && array1.Length == array2.Length)
            {
                return array1.SequenceEqual(array2);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class ClassOfUnionWith2SameArrayAndMap : IEquatable<ClassOfUnionWith2SameArrayAndMap>
    {
        public static ClassOfUnionWith2SameArrayAndMap Create()
        {
            return new ClassOfUnionWith2SameArrayAndMap
            {
                IntArray = new[] { Utilities.GetRandom<int>(false) },
                IntMap = new Dictionary<string, int>()
                {
                    {"TestKey", Utilities.GetRandom<int>(false)}
                },
            };
        }

        [DataMember]
        [AvroUnion(typeof(int[]), typeof(int[]), typeof(AvroNull))]
        public object IntArray;

        [DataMember]
        [AvroUnion(typeof(Dictionary<string, int>), typeof(Dictionary<string, int>), typeof(AvroNull))]
        public object IntMap;

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassOfUnionWith2SameArrayAndMap);
        }

        public bool Equals(ClassOfUnionWith2SameArrayAndMap other)
        {
            if (other == null)
            {
                return false;
            }

            return CollectionEquals<int>(this.IntArray, other.IntArray)
                   && DictionaryEquals<string, int>(this.IntMap, other.IntMap);
        }

        private bool DictionaryEquals<TKey, TValue>(object object1, object object2)
        {
            var map1 = object1 as IDictionary<TKey, TValue>;
            var map2 = object2 as IDictionary<TKey, TValue>;
            if (map1 != null && map2 != null && map1.Count == map2.Count)
            {
                return map1.SequenceEqual(map2);
            }

            return false;
        }

        public bool CollectionEquals<T>(object object1, object object2)
        {
            var array1 = object1 as T[];
            var array2 = object2 as T[];
            if (array1 != null && array2 != null && array1.Length == array2.Length)
            {
                return array1.SequenceEqual(array2);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
