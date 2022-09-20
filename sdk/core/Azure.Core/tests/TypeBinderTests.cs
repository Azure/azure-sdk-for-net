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

            Assert.AreEqual(1, model.IntProperty);
            Assert.AreEqual(2, model.IntField);
            Assert.AreEqual("1", model.StringProperty);
            Assert.AreEqual("2", model.StringField);
            Assert.AreEqual("Ignore me", model.IgnoredProperty);
            Assert.AreEqual("renamed value", model.RenamedProperty);
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

            Assert.AreEqual(1, dictionary["IntProperty"]);
            Assert.AreEqual(2, dictionary["IntField"]);
            Assert.AreEqual(4, dictionary["IntReadOnlyProperty"]);
            Assert.AreEqual(5, dictionary["IntReadOnlyField"]);
            Assert.AreEqual("1", dictionary["StringProperty"]);
            Assert.AreEqual("2", dictionary["StringField"]);
            Assert.AreEqual("3", dictionary["StringReadOnlyProperty"]);
            Assert.AreEqual("42", dictionary["StringReadOnlyField"]);
            Assert.AreEqual("renamed value", dictionary["renamed_property"]);
            Assert.False(dictionary.ContainsKey("IgnoredProperty"));
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

            Assert.AreEqual(1, model.IntProperty);
            Assert.AreEqual(2, model.IntField);
            Assert.AreEqual("1", model.StringProperty);
            Assert.AreEqual("2", model.StringField);
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

            Assert.AreEqual(1, dictionary["IntProperty"]);
            Assert.AreEqual(2, dictionary["IntField"]);
            Assert.AreEqual(4, dictionary["IntReadOnlyProperty"]);
            Assert.AreEqual(5, dictionary["IntReadOnlyField"]);
            Assert.AreEqual("1", dictionary["StringProperty"]);
            Assert.AreEqual("2", dictionary["StringField"]);
            Assert.AreEqual("3", dictionary["StringReadOnlyProperty"]);
            Assert.AreEqual("42", dictionary["StringReadOnlyField"]);
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

            Assert.AreEqual(model.PropertyWithPrivateSetter, "private value");
            Assert.AreEqual(model.GetPrivateField(), "private value");
            Assert.AreEqual(model.GetPrivateProperty(), "private value");
        }

        [Test]
        public void IgnoresPrivatesFieldsAndProperties()
        {
            var dictionary = new Dictionary<string, object>();

            new TestBinder().Serialize(new ModelClass(), dictionary);
            Assert.False(dictionary.ContainsKey("PrivateField"));
            Assert.False(dictionary.ContainsKey("PrivateProperty"));
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

            Assert.AreEqual("1", model.StringProperty);
            Assert.AreEqual("1", ((IFoo)model).InterfaceString);
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

            Assert.AreEqual("1", dictionary["StringProperty"]);
            Assert.AreEqual("1", dictionary["InterfaceString"]);
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
