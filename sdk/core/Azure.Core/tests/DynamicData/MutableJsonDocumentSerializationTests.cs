// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonDocumentSerializationTests
    {
        [Test]
        public void CannotAssignModelWithBinaryDataProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(Dynamic.DynamicCaseMapping.PascalToCamel);
            BinaryDataModel model = new BinaryDataModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignModelWithStreamProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(Dynamic.DynamicCaseMapping.PascalToCamel);
            StreamModel model = new StreamModel();

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = model);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = model);
        }

        [Test]
        public void CannotAssignBinaryData()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);
            BinaryData data = BinaryData.FromString("no");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = data);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = data);
        }

        [Test]
        public void CanAssignAnonymousType()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            var anon = new
            {
                StringProperty = "foo",
                IntProperty = 1,
            };

            // Existing property
            json.Foo = anon;

            // New property
            json.Bar = anon;

            // TODO: Validate
        }

        [Test]
        public void CannotAssignAnonymousTypeWithUnallowedProperty()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

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
        public void CanAssignAllowedModelsWithCyclesOneDeep()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);
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

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual("b", (string)json.Foo.NestedProperty.StringProperty);
            Assert.AreEqual("c", (string)json.Foo.NestedProperty.NestedProperty.StringProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual("b", (string)json.Bar.NestedProperty.StringProperty);
            Assert.AreEqual("c", (string)json.Bar.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CanAssignAllowedModelsWithCyclesTwoDeep()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);
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

            // New property
            json.Bar = model;

            Assert.AreEqual("a", (string)json.Foo.StringProperty);
            Assert.AreEqual(1, (int)json.Foo.NestedProperty.IntProperty);
            Assert.AreEqual("b", (string)json.Foo.NestedProperty.NestedProperty.StringProperty);

            Assert.AreEqual("a", (string)json.Bar.StringProperty);
            Assert.AreEqual(1, (int)json.Bar.NestedProperty.IntProperty);
            Assert.AreEqual("b", (string)json.Bar.NestedProperty.NestedProperty.StringProperty);
        }

        [Test]
        public void CannotAssignCyclicalModelsWithUnallowedProperties()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);
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
        public void CanAssignDictionaryContainingAllowedTypes()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["intValue"] = "b";

            // Existing property
            json.Foo = values;

            // New property
            json.Bar = values;
        }

        [Test]
        public void CannotAssignDictionaryContainingUnallowedTypes()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(DynamicCaseMapping.PascalToCamel);

            Dictionary<string, object> values = new();
            values["stringValue"] = "a";
            values["binaryDataValue"] = BinaryData.FromString("b");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = values);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = values);
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
        #endregion
    }
}
