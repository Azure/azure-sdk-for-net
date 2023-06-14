// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class DynamicJsonSerializationTests
    {
        [Test]
        public void CannotAssignModelWithBinaryDataProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
            BinaryDataModel model = new BinaryDataModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignModelWithStreamProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
            StreamModel model = new StreamModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignBinaryData()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
            BinaryData data = BinaryData.FromString("no");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = data);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = data);
        }

        [Test]
        public void CanAssignObjectArray()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            // Existing property
            Assert.DoesNotThrow(() => json.Foo = new object[] { 1, null, "a" });

            // New property
            Assert.DoesNotThrow(() => json.Bar = new object[] { 2, false, "b" });
        }

        [Test]
        public void CannotAssignObjectArrayContainingUnallowedTypes()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = new object[] { 1, BinaryData.FromString("no"), "a" });

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = new object[] { 2, BinaryData.FromString("no"), "b" });
        }

        [Test]
        public void CanAssignAnonymousType_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignAllowedModelsWithCyclesOneDeep_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
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
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignAllowedModelsWithCyclesOneDeep_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
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
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignAllowedModelsWithCyclesTwoDeep_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
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
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignAllowedModelsWithCyclesTwoDeep_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
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
        public void NewCyclesTest()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);
            Foo model = new()
            {
                BarProp = new Bar { N = 1 },
                FooProp = new Foo { BarProp = new Bar { N = 2 } },
                StreamProp = new MemoryStream()
            };

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CanAssignDictionaryContainingAllowedTypes_ExistingProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["intValue"] = "b";

            // Existing property
            json.Foo = values;
        }

        [Test]
        public void CanAssignDictionaryContainingAllowedTypes_NewProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["intValue"] = "b";

            // New property
            json.Bar = values;
        }

        [Test]
        public void CannotAssignDictionaryContainingUnallowedTypes()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["binaryDataValue"] = BinaryData.FromString("b");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = values);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = values);
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignModelWithValidObjectProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
        [Ignore("Disallowing POCO support in current version.")]
        public void ModelAssignmentRespectsValueSemantics()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            model.ObjectProperty = 2;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);

            json.Foo.StringProperty = "b";
            json.Foo.ObjectProperty = 2;

            json.Bar.StringProperty = "c";
            json.Bar.ObjectProperty = 3;

            Assert.AreEqual("b", (string)json.Foo.StringProperty);
            Assert.AreEqual(2, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("c", (string)json.Bar.StringProperty);
            Assert.AreEqual(3, (int)json.Bar.ObjectProperty);
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void ModelAssignmentRespectsValueSemanticsAndThrowsWithNewUnallowedValue()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.ObjectProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.ObjectProperty);

            json.Foo.StringProperty = "b";
            json.Bar.StringProperty = "c";

            Assert.AreEqual("b", (string)json.Foo.StringProperty);
            Assert.AreEqual("c", (string)json.Bar.StringProperty);

            Assert.Throws<NotSupportedException>(() => { json.Foo.ObjectProperty = BinaryData.FromString("no"); });
            Assert.Throws<NotSupportedException>(() => { json.Bar.ObjectProperty = BinaryData.FromString("no"); });
        }

        [Test]
        public void CannotAssignModelWithInvalidObjectProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(PropertyNameFormat.CamelCase);

            List<List<object>> list = new();
            list.Add(new List<object>() { BinaryData.FromString("a") });

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = list);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = list);
        }

        #region Helpers
        public class Foo
        {
            public Bar BarProp { get; set; }
            public Foo FooProp { get; set; }
            public Stream StreamProp { get; set; }
        }

        public class Bar
        {
            public int N { get; set; }
        }

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
