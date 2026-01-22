// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TypeBinderTests
    {
        [Test]
        public void CanDeserializeFromDictionary()
        {
            var model = new TestBinder().Deserialize<ModelClass>(new Dictionary<string, object>()
            {
                { "IntProperty", 1 },
                { "IntField", 2 },
                { "StringProperty", "1" },
                { "StringField", "2" },
                { "IgnoredProperty", "5" },
                { "renamed_property", "renamed value"}
            });

            Assert.That(model.IntProperty, Is.EqualTo(1));
            Assert.That(model.IntField, Is.EqualTo(2));
            Assert.That(model.StringProperty, Is.EqualTo("1"));
            Assert.That(model.StringField, Is.EqualTo("2"));
            Assert.That(model.IgnoredProperty, Is.EqualTo("Ignore me"));
            Assert.That(model.RenamedProperty, Is.EqualTo("renamed value"));
        }

        [Test]
        public void CanSerializeToDictionary()
        {
            var dictionary = new Dictionary<string, object>();

            new TestBinder().Serialize(new ModelClass()
            {
                IntProperty = 1,
                IntField = 2,
                StringProperty = "1",
                StringField = "2",
                RenamedProperty = "renamed value"
            }, dictionary);

            Assert.That(dictionary["IntProperty"], Is.EqualTo(1));
            Assert.That(dictionary["IntField"], Is.EqualTo(2));
            Assert.That(dictionary["IntReadOnlyProperty"], Is.EqualTo(4));
            Assert.That(dictionary["IntReadOnlyField"], Is.EqualTo(5));
            Assert.That(dictionary["StringProperty"], Is.EqualTo("1"));
            Assert.That(dictionary["StringField"], Is.EqualTo("2"));
            Assert.That(dictionary["StringReadOnlyProperty"], Is.EqualTo("3"));
            Assert.That(dictionary["StringReadOnlyField"], Is.EqualTo("42"));
            Assert.That(dictionary["renamed_property"], Is.EqualTo("renamed value"));
            Assert.That(dictionary.ContainsKey("IgnoredProperty"), Is.False);
        }

        [Test]
        public void CanDeserializeStructFromDictionary()
        {
            var model = new TestBinder().Deserialize<ModelClass>(new Dictionary<string, object>()
            {
                { "IntProperty", 1 },
                { "IntField", 2 },
                { "StringProperty", "1" },
                { "StringField", "2" }
            });

            Assert.That(model.IntProperty, Is.EqualTo(1));
            Assert.That(model.IntField, Is.EqualTo(2));
            Assert.That(model.StringProperty, Is.EqualTo("1"));
            Assert.That(model.StringField, Is.EqualTo("2"));
        }

        [Test]
        public void CanSerializeStructToDictionary()
        {
            var dictionary = new Dictionary<string, object>();

            new TestBinder().Serialize(new ModelClass()
            {
                IntProperty = 1,
                IntField = 2,
                StringProperty = "1",
                StringField = "2",
                RenamedProperty = "renamed value"
            }, dictionary);

            Assert.That(dictionary["IntProperty"], Is.EqualTo(1));
            Assert.That(dictionary["IntField"], Is.EqualTo(2));
            Assert.That(dictionary["IntReadOnlyProperty"], Is.EqualTo(4));
            Assert.That(dictionary["IntReadOnlyField"], Is.EqualTo(5));
            Assert.That(dictionary["StringProperty"], Is.EqualTo("1"));
            Assert.That(dictionary["StringField"], Is.EqualTo("2"));
            Assert.That(dictionary["StringReadOnlyProperty"], Is.EqualTo("3"));
            Assert.That(dictionary["StringReadOnlyField"], Is.EqualTo("42"));
        }

        [Test]
        public void IgnoresPrivatesSetters()
        {
            var model = new TestBinder().Deserialize<ModelClass>(new Dictionary<string, object>()
            {
                { "PropertyWithPrivateSetter", "modified value" },
                { "PrivateField", "modified value" },
                { "PrivateProperty", "modified value" },
            });

            Assert.That(model.PropertyWithPrivateSetter, Is.EqualTo("private value"));
            Assert.That(model.GetPrivateField(), Is.EqualTo("private value"));
            Assert.That(model.GetPrivateProperty(), Is.EqualTo("private value"));
        }

        [Test]
        public void IgnoresPrivatesFieldsAndProperties()
        {
            var dictionary = new Dictionary<string, object>();

            new TestBinder().Serialize(new ModelClass(), dictionary);
            Assert.That(dictionary.ContainsKey("PrivateField"), Is.False);
            Assert.That(dictionary.ContainsKey("PrivateProperty"), Is.False);
        }

        [Test]
        public void CanDeserializeExplicitlyImplementedInterfaceProperties()
        {
            var binder = new TestBinder();
            var typeInfo = binder.GetBinderInfo(typeof(ClassWithInterface), typeof(IFoo));
            var model = typeInfo.Deserialize<ClassWithInterface>(new Dictionary<string, object>()
            {
                { "StringProperty", "1" },
                { "PrivateStringProperty", "1" },
            });

            Assert.That(model.StringProperty, Is.EqualTo("1"));
            Assert.That(((IFoo)model).InterfaceString, Is.EqualTo("1"));
        }

        [Test]
        public void CanSerializeExplicitlyImplementedInterfaceProperties()
        {
            var binder = new TestBinder();
            var typeInfo = binder.GetBinderInfo(typeof(ClassWithInterface), typeof(IFoo));
            var dictionary = new Dictionary<string, object>();

            typeInfo.Serialize(new ClassWithInterface()
            {
                StringProperty = "1",
            }, dictionary);

            Assert.That(dictionary["StringProperty"], Is.EqualTo("1"));
            Assert.That(dictionary["InterfaceString"], Is.EqualTo("1"));
        }

        [Test]
        [TestCase(typeof(SomeClass))]
        [TestCase(typeof(SomeStruct))]
        public void InterfaceTypeThrowsIfNotInterface(Type type)
        {
            var binder = new TestBinder();
            Assert.Throws<InvalidOperationException>(() => binder.GetBinderInfo(typeof(ClassWithInterface), type));
        }

        [Test]
        public void InterfaceTypeThrowsIfNotAssignableFrom()
        {
            var binder = new TestBinder();
            Assert.Throws<InvalidOperationException>(() => binder.GetBinderInfo(typeof(ClassWithInterface), typeof(IBar)));
        }

#pragma warning disable 414
#pragma warning disable 649
        private class ModelClass
        {
            public int IntProperty { get; set; }
            public int IntField;

            public int IntReadOnlyProperty { get; } = 4;
            public readonly int IntReadOnlyField = 5;

            public string StringProperty { get; set; }
            public string StringField;

            public string StringReadOnlyProperty { get; } = "3";
            public readonly string StringReadOnlyField = "42";

            [IgnoreDataMember]
            public string IgnoredProperty { get; set; } = "Ignore me";

            [DataMember(Name = "renamed_property")]
            public string RenamedProperty { get; set; } = "renamed property";

            public string PropertyWithPrivateSetter { get; private set; } = "private value";

            private string PrivateField = "private value";
            private string PrivateProperty => "private value";

            public string GetPrivateField() => PrivateField;
            public string GetPrivateProperty() => PrivateProperty;
        }

        private struct ModelStruct
        {
            public int IntProperty { get; set; }
            public int IntField;

            public int IntReadOnlyProperty => 4;
            public readonly int IntReadOnlyField;

            public string StringProperty { get; set; }
            public string StringField;

            public string StringReadOnlyProperty => "3";
            public readonly string StringReadOnlyField;
        }

        private class ClassWithInterface : IFoo
        {
            public int IntProperty { get; set; }
            public string StringProperty { get; set; }

            string IFoo.InterfaceString
            {
                get => StringProperty;
                set => StringProperty = value;
            }
        }

        private interface IFoo
        {
            string InterfaceString { get; set; }
        }

        private interface IBar
        {
            string InterfaceString { get; set; }
        }

        private class SomeClass { }
        private struct SomeStruct { }

#pragma warning restore 649
#pragma warning restore 414

        private class TestBinder : TypeBinder<IDictionary<string, object>>
        {
            protected override void Set<T>(IDictionary<string, object> destination, T value, BoundMemberInfo memberInfo)
            {
                destination[memberInfo.Name] = value;
            }

            protected override bool TryGet<T>(BoundMemberInfo memberInfo, IDictionary<string, object> source, out T value)
            {
                if (!source.TryGetValue(memberInfo.Name, out var objectValue))
                {
                    value = default;
                    return false;
                }

                if (typeof(T) == objectValue.GetType())
                {
                    value = (T)objectValue;
                    return true;
                }

                value = default;
                return false;
            }
        }
    }
}
