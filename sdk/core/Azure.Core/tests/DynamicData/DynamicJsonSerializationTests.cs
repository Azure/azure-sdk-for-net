// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class DynamicJsonSerializationTests
    {
        [Test]
        public void CannotAssignModelWithBinaryDataProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            BinaryDataModel model = new BinaryDataModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignModelWithStreamProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            StreamModel model = new StreamModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignBinaryData()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            BinaryData data = BinaryData.FromString("no");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = data);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = data);
        }

        [Test]
        public void CanAssignAnonymousType_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            var anon = new
            {
                StringProperty = "foo",
                IntProperty = 1,
            };

            // Existing property
            Assert.DoesNotThrow(() => json.Foo = anon);
        }

        [Test]
        public void CanAssignAnonymousType_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            var anon = new
            {
                StringProperty = "foo",
                IntProperty = 1,
            };

            // New property
            Assert.DoesNotThrow(() => json.Bar = anon);
        }

        [Test]
        public void CannotAssignAnonymousTypeWithUnallowedProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            var anon = new
            {
                StringProperty = "foo",
                BinaryDataProperty = BinaryData.FromString("no"),
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = anon);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = anon);
        }

        [Test]
        public void CanAssignAllowedModelsWithCyclesOneDeep_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            NestedModel model = new()
            {
                StringProperty = "a",
                NestedProperty = new()
                {
                    StringProperty = "b",
                    NestedProperty = new()
                    {
                        StringProperty = "c",
                    }
                }
            };

            // Existing property
            json.Foo = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual("b", (string)json.Foo.NestedProperty.StringProperty);
            Assert.AreEqual("c", (string)json.Foo.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CanAssignAllowedModelsWithCyclesOneDeep_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            NestedModel model = new()
            {
                StringProperty = "a",
                NestedProperty = new()
                {
                    StringProperty = "b",
                    NestedProperty = new()
                    {
                        StringProperty = "c",
                    }
                }
            };

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual("b", (string)json.Bar.NestedProperty.StringProperty);
            Assert.AreEqual("c", (string)json.Bar.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CanAssignAllowedModelsWithCyclesTwoDeep_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            SkipNestedModel model = new()
            {
                StringProperty = "a",
                NestedProperty = new ChildNestedModel()
                {
                    IntProperty = 1,
                    NestedProperty = new SkipNestedModel()
                    {
                        StringProperty = "b",
                    }
                }
            };

            // Existing property
            json.Foo = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.NestedProperty.IntProperty);
            Assert.AreEqual("b", (string)json.Foo.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CanAssignAllowedModelsWithCyclesTwoDeep_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            SkipNestedModel model = new()
            {
                StringProperty = "a",
                NestedProperty = new ChildNestedModel()
                {
                    IntProperty = 1,
                    NestedProperty = new SkipNestedModel()
                    {
                        StringProperty = "b",
                    }
                }
            };

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.NestedProperty.IntProperty);
            Assert.AreEqual("b", (string)json.Bar.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CannotAssignCyclicalModelsWithUnallowedProperties()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);
            UnallowedNestedModel model = new()
            {
                StringProperty = "a",
                NestedProperty = new UnallowedNestedModel()
                {
                    StringProperty = "b",
                    NestedProperty = new UnallowedNestedModel()
                    {
                        StringProperty = "c",
                        BinaryDataProperty = BinaryData.FromString("d")
                    }
                }
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CanAssignDictionaryContainingAllowedTypes_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["intValue"] = "b";

            // Existing property
            json.Foo = values;
        }

        [Test]
        public void CanAssignDictionaryContainingAllowedTypes_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["intValue"] = "b";

            // New property
            json.Bar = values;
        }

        [Test]
        public void CannotAssignDictionaryContainingUnallowedTypes()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["binaryDataValue"] = BinaryData.FromString("b");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = values);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = values);
        }

        [Test]
        public void CanAssignModelWithValidObjectProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = 1,
            };

            // Existing property
            json.Foo = model;

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);
        }

        [Test]
        public void AssignedModelRespectsReferenceSemantics_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = 1,
            };

            // Existing property
            json.Foo = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            model.StringProperty = "b";
            model.ObjectProperty = 2;

            Assert.AreEqual("b", (string)json.Foo.StringProperty);
            Assert.AreEqual(2, (int)json.Foo.ObjectProperty);
        }

        [Test]
        public void AssignedModelRespectsReferenceSemantics_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = 1,
            };

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);

            model.StringProperty = "b";
            model.ObjectProperty = 2;

            Assert.AreEqual("b", (string)json.Bar.StringProperty);
            Assert.AreEqual(2, (int)json.Bar.ObjectProperty);
        }

        [Test]
        public void AssignedModelRespectsReferenceSemantics_MultipleProperties()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = 1,
            };

            // Existing property
            json.Foo = model;

            // New property
            json.Bar = model;

            //Assert.AreEqual("a", (string)json.Foo.StringProperty);
            //Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);

            model.StringProperty = "b";
            model.ObjectProperty = 2;

            //Assert.AreEqual("b", (string)json.Foo.StringProperty);
            //Assert.AreEqual(2, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("b", (string)json.Bar.StringProperty);
            Assert.AreEqual(2, (int)json.Bar.ObjectProperty);
        }

        [Test]
        public void AssignedModelRespectsReferenceSemanticsAndThrowsWithNewUnallowedValue()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = 1,
            };

            // Existing property
            json.Foo = model;

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);

            model.StringProperty = "b";
            model.ObjectProperty = BinaryData.FromString("no");

            Assert.AreEqual("b", (string)json.Foo.StringProperty);
            Assert.Throws<NotSupportedException>(() => { int i = (int)json.Foo.ObjectProperty; });

            Assert.AreEqual("b", (string)json.Bar.StringProperty);
            Assert.Throws<NotSupportedException>(() => { int i = (int)json.Bar.ObjectProperty; });

            Assert.Throws<NotSupportedException>(() =>
            {
                using MemoryStream stream = new();
                using Utf8JsonWriter writer = new(stream);
                json.WriteTo(writer);
            });
        }

        [Test]
        public void CannotAssignModelWithInvalidObjectProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            ObjectPropertyModel model = new()
            {
                StringProperty = "a",
                ObjectProperty = BinaryData.FromString("b"),
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignModelWithInvalidObjectPropertyRegardlessOfOrder()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            MultipleObjectPropertyModel model = new()
            {
                A = "a",
                B = BinaryData.FromString("b"),
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);

            model = new()
            {
                A = BinaryData.FromString("a"),
                B = "b",
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);

            model = new()
            {
                A = BinaryData.FromString("a"),
                B = BinaryData.FromString("b"),
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CanAssignNestedGenerics()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            List<List<object>> list = new();
            list.Add(new List<object>() { "a" });

            Assert.AreEqual("a", list[0][0]);

            // Existing property
            json.Foo = list;

            // New property
            json.Bar = list;

            Assert.AreEqual("a", (string)json.Foo[0][0]);
            Assert.AreEqual("a", (string)json.Bar[0][0]);
        }

        [Test]
        public void CannotAssignNestedGenericsWithUnallowedValues()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNamingConvention.CamelCase);

            List<List<object>> list = new();
            list.Add(new List<object>() { BinaryData.FromString("a") });

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = list);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = list);
        }

        #region Helpers
        internal class BinaryDataModel
        {
            public BinaryDataModel() { }
            public string StringProperty { get; set; }
            public BinaryData BinaryDataProperty { get; set; }
        }

        internal class StreamModel
        {
            public StreamModel() { }
            public string StringProperty { get; set; }
            public Stream StreamProperty { get; set; }
        }

        internal class NestedModel
        {
            public NestedModel() { }
            public string StringProperty { get; set; }
            public NestedModel NestedProperty { get; set; }
        }

        internal class SkipNestedModel
        {
            public SkipNestedModel() { }
            public string StringProperty { get; set; }
            public ChildNestedModel NestedProperty { get; set; }
        }

        internal class ChildNestedModel
        {
            public ChildNestedModel() { }
            public int IntProperty { get; set; }
            public SkipNestedModel NestedProperty { get; set; }
        }

        internal class UnallowedNestedModel
        {
            public UnallowedNestedModel() { }
            public string StringProperty { get; set; }
            public UnallowedNestedModel NestedProperty { get; set; }
            public BinaryData BinaryDataProperty { get; set; }
        }

        internal class ObjectPropertyModel
        {
            public ObjectPropertyModel() { }
            public string StringProperty { get; set; }
            public object ObjectProperty { get; set; }
        }

        internal class MultipleObjectPropertyModel
        {
            public MultipleObjectPropertyModel() { }
            public object A { get; set; }
            public object B { get; set; }
        }
        #endregion
    }
}
