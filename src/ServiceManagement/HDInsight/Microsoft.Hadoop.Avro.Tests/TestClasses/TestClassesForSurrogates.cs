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
    internal class ClassWithoutParameterlessConstructor : IEquatable<ClassWithoutParameterlessConstructor>
    {
        public ClassWithoutParameterlessConstructor(AnotherClassWithoutParameterlessConstructor fieldValue)
        {
            this.Field = fieldValue;
        }

        public static ClassWithoutParameterlessConstructor Create()
        {
            return new ClassWithoutParameterlessConstructor(AnotherClassWithoutParameterlessConstructor.Create());
        }

        [DataMember]
        public AnotherClassWithoutParameterlessConstructor Field { get; set; }

        public bool Equals(ClassWithoutParameterlessConstructor other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Field.Equals(other.Field);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ClassWithoutParameterlessConstructor);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    [DataContract]
    internal class AnotherClassWithoutParameterlessConstructor : IEquatable<AnotherClassWithoutParameterlessConstructor>
    {
        public AnotherClassWithoutParameterlessConstructor(NestedClass fieldValue)
        {
            this.Field = fieldValue;
        }

        public static AnotherClassWithoutParameterlessConstructor Create()
        {
            return new AnotherClassWithoutParameterlessConstructor(NestedClass.Create(true));
        }

        [DataMember]
        public NestedClass Field { get; set; }

        public bool Equals(AnotherClassWithoutParameterlessConstructor other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Field.Equals(other.Field);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnotherClassWithoutParameterlessConstructor);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }

    [DataContract]
    internal class ClassWithoutParameterlessConstructorSurrogate : IEquatable<ClassWithoutParameterlessConstructor>
    {
        [DataMember]
        public AnotherClassWithoutParameterlessConstructor Field { get; set; }

        public bool Equals(ClassWithoutParameterlessConstructor other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Field.Equals(other.Field);
        }
    }

    [DataContract]
    internal class AnotherClassWithoutParameterlessConstructorSurrogate : IEquatable<AnotherClassWithoutParameterlessConstructor>
    {
        [DataMember]
        public NestedClass Field { get; set; }

        public bool Equals(AnotherClassWithoutParameterlessConstructor other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Field.Equals(other.Field);
        }
    }

    [DataContract]
    internal class Surrogate : IAvroSurrogate
    {
        public object GetDeserializedObject(object obj, Type targetType)
        {
            var instance1 = obj as ClassWithoutParameterlessConstructorSurrogate;
            if (instance1 != null)
            {
                return new ClassWithoutParameterlessConstructor(instance1.Field);
            }

            var instance2 = obj as AnotherClassWithoutParameterlessConstructorSurrogate;
            if (instance2 != null)
            {
                return new AnotherClassWithoutParameterlessConstructor(instance2.Field);
            }

            throw new NotImplementedException();
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            var instance1 = obj as ClassWithoutParameterlessConstructor;
            if (instance1 != null)
            {
                return new ClassWithoutParameterlessConstructorSurrogate { Field = instance1.Field };
            }

            var instance2 = obj as AnotherClassWithoutParameterlessConstructor;
            if (instance2 != null)
            {
                return new AnotherClassWithoutParameterlessConstructorSurrogate { Field = instance2.Field };
            }

            throw new NotImplementedException();
        }

        public Type GetSurrogateType(Type type)
        {
            if (type == typeof(ClassWithoutParameterlessConstructor))
            {
                return typeof(ClassWithoutParameterlessConstructorSurrogate);
            }

            if (type == typeof(AnotherClassWithoutParameterlessConstructor))
            {
                return typeof(AnotherClassWithoutParameterlessConstructorSurrogate);
            }

            if (type == typeof(Surrogate))
            {
                return null;
            }

            return type;
        }
    }
}
