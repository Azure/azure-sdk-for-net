namespace Microsoft.Hadoop.Avro.Tests.TestClasses
{
    using System;
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
                   && other.IntStringNullFieldNull == other.IntStringNullFieldNull;
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
}
