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
    using System.Runtime.Serialization;

    [DataContract]
    [KnownType(typeof(Square))]
    [KnownType(typeof(Rectangle))]
    internal abstract class AbstractShape
    {
        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public abstract string Name { get; set; }
    }

    [DataContract]
    internal class Square : AbstractShape, IEquatable<Square>
    {
        [DataMember]
        public int Side { get; set; }

        [DataMember]
        public override string Name { get; set; }

        public static Square Create()
        {
            return new Square
            {
                Color = Utilities.GetRandom<string>(false),
                Name = Utilities.GetRandom<string>(false),
                Side = Utilities.GetRandom<int>(false)
            };
        }

        public bool Equals(Square other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Side == other.Side && this.Name == other.Name && this.Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Square);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class DifferentSquare : Square, IEquatable<DifferentSquare>
    {
        [DataMember]
        public int AnotherProperty { get; set; }

        public static new DifferentSquare Create()
        {
            return new DifferentSquare
            {
                AnotherProperty = Utilities.GetRandom<int>(false),
                Color = Utilities.GetRandom<string>(false),
                Name = Utilities.GetRandom<string>(false),
                Side = Utilities.GetRandom<int>(false)
            };
        }

        public bool Equals(DifferentSquare other)
        {
            if (other == null)
            {
                return false;
            }

            return this.AnotherProperty == other.AnotherProperty
                && base.Equals((Square)other);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DifferentSquare);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class Rectangle : AbstractShape, IEquatable<Rectangle>
    {
        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public override string Name { get; set; }

        public static Rectangle Create()
        {
            return new Rectangle
            {
                Color = Utilities.GetRandom<string>(false),
                Name = Utilities.GetRandom<string>(false),
                Width = Utilities.GetRandom<int>(false),
                Height = Utilities.GetRandom<int>(false)
            };
        }

        public bool Equals(Rectangle other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Width == other.Width && this.Height == other.Height && this.Name == other.Name && this.Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Rectangle);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Width and Height property declaration order is reversed in compare with Rectangle
    /// </summary>
    [DataContract]
    internal class AnotherRectangle : AbstractShape, IEquatable<AnotherRectangle>
    {
        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public override string Name { get; set; }

        public static AnotherRectangle Create()
        {
            return new AnotherRectangle
            {
                Color = Utilities.GetRandom<string>(false),
                Name = Utilities.GetRandom<string>(false),
                Width = Utilities.GetRandom<int>(false),
                Height = Utilities.GetRandom<int>(false)
            };
        }

        public bool Equals(AnotherRectangle other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Width == other.Width && this.Height == other.Height && this.Name == other.Name && this.Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnotherRectangle);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    [KnownType(typeof(Rectangle))]
    internal abstract class AbstractClassWithInvalidKnownTypes
    {
        [DataMember]
        public int SomeValue { get; set; }
    }

    [DataContract]
    [KnownType(typeof(AnotherSquare))]
    internal abstract class AnotherAbstractShape
    {
        [DataMember]
        public int SomeValue { get; set; }
    }

    [DataContract]
    internal class AnotherSquare : AnotherAbstractShape, IEquatable<AnotherSquare>
    {
        [DataMember]
        public int Side { get; set; }

        public static AnotherSquare Create()
        {
            return new AnotherSquare { Side = Utilities.GetRandom<int>(false), SomeValue = Utilities.GetRandom<int>(false) };
        }

        public bool Equals(AnotherSquare other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Side == other.Side;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnotherSquare);
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
    internal class ClassWithAbstractMembers : IEquatable<ClassWithAbstractMembers>
    {
        [DataMember]
        public AnotherAbstractShape ASquare { get; set; }

        [DataMember]
        public int IntField { get; set; }

        [DataMember]
        public IInterface Interface { get; set; }

        [DataMember]
        public AbstractShape Rect { get; set; }

        public static ClassWithAbstractMembers Create()
        {
            return new ClassWithAbstractMembers
            {
                IntField = Utilities.GetRandom<int>(false),
                Rect = Rectangle.Create(),
                ASquare = AnotherSquare.Create(),
                Interface = ClassImplementingInterface.Create()
            };
        }

        public bool Equals(ClassWithAbstractMembers other)
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
            return this.Equals(obj as ClassWithAbstractMembers);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    [KnownType(typeof(ClassImplementingInterface))]
    internal class ClassInheritingClassWithAbstractMembers : ClassWithAbstractMembers, IEquatable<ClassInheritingClassWithAbstractMembers>
    {
        [DataMember]
        public AbstractShape InheritedShape { get; set; }

        public static new ClassInheritingClassWithAbstractMembers Create()
        {
            return new ClassInheritingClassWithAbstractMembers
            {
                IntField = Utilities.GetRandom<int>(false),
                Rect = Rectangle.Create(),
                ASquare = AnotherSquare.Create(),
                Interface = ClassImplementingInterface.Create(),
                InheritedShape = Square.Create()
            };
        }

        public bool Equals(ClassInheritingClassWithAbstractMembers other)
        {
            if (other == null)
            {
                return false;
            }

            return 
                this.IntField == other.IntField 
                && this.Rect.Equals(other.Rect) 
                && this.ASquare.Equals(other.ASquare) 
                && this.Interface.Equals(other.Interface)
                && this.InheritedShape.Equals(other.InheritedShape);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassInheritingClassWithAbstractMembers);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    internal interface IInterface
    {
        int IntField { get; set; }
    }

    internal interface IInheritedInterface : IInterface
    {
    }

    [DataContract]
    internal class ClassOfInheritedInterface : IInheritedInterface
    {
        [DataMember]
        public int IntField
        {
            get;
            set;
        }
    }

    [DataContract]
    internal class ClassImplementingInterface : IInterface
    {
        [DataMember]
        public double DoubleField { get; set; }

        [DataMember]
        public int IntField { get; set; }

        public static ClassImplementingInterface Create()
        {
            return new ClassImplementingInterface { IntField = Utilities.GetRandom<int>(false), DoubleField = Utilities.GetRandom<double>(false) };
        }

        public bool Equals(ClassImplementingInterface other)
        {
            if (other == null)
            {
                return false;
            }

            return this.IntField == other.IntField && this.DoubleField == other.DoubleField;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassImplementingInterface);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class InheritedClassImplementingInterface : ClassImplementingInterface, IEquatable<InheritedClassImplementingInterface>
    {
        [DataMember]
        public double OnMoreField { get; set; }

        public static InheritedClassImplementingInterface CreateInherited()
        {
            return new InheritedClassImplementingInterface
            {
                IntField = Utilities.GetRandom<int>(false),
                DoubleField = Utilities.GetRandom<double>(false),
                OnMoreField = Utilities.GetRandom<double>(false)
            };
        }

        public bool Equals(InheritedClassImplementingInterface other)
        {
            if (other == null)
            {
                return false;
            }

            return this.IntField == other.IntField && this.DoubleField == other.DoubleField && this.OnMoreField == other.OnMoreField;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as InheritedClassImplementingInterface);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    [KnownType(typeof(SquareInheritingConcreteConcreteShape))]
    internal class ConcreteShape : IEquatable<ConcreteShape>
    {
        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int Width { get; set; }

        public static ConcreteShape Create()
        {
            return new ConcreteShape { Length = Utilities.GetRandom<int>(false), Width = Utilities.GetRandom<int>(false) };
        }

        public bool Equals(ConcreteShape other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Length == other.Length && this.Width == other.Width;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ConcreteShape);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    internal class SquareInheritingConcreteConcreteShape : ConcreteShape, IEquatable<SquareInheritingConcreteConcreteShape>
    {
        [DataMember]
        public string Color;

        public static new SquareInheritingConcreteConcreteShape Create()
        {
            return new SquareInheritingConcreteConcreteShape { Color = Utilities.GetRandom<string>(false), Length = Utilities.GetRandom<int>(false), Width = Utilities.GetRandom<int>(false) };
        }

        public bool Equals(SquareInheritingConcreteConcreteShape other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Length == other.Length && this.Width == other.Width && this.Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SquareInheritingConcreteConcreteShape);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    [KnownType(typeof(NoGetter))]
    internal abstract class AbstractNoGetter
    {
        [DataMember]
        public abstract string Property { set; }
    }

    [DataContract]
    internal class NoGetter : AbstractNoGetter
    {
        [DataMember]
        public override string Property
        {
            set { }
        }
    }
}
