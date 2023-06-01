// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(Dynamic.DynamicCaseMapping.PascalToCamel);
            BinaryData data = BinaryData.FromString("no");

            // Existing property
            Assert.Throws<NotSupportedException>(() => json.Foo = data);

            // New property
            Assert.Throws<NotSupportedException>(() => json.Bar = data);
        }

        [Test]
        public void CanAssignAnonymousType()
        {
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(Dynamic.DynamicCaseMapping.PascalToCamel);

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
            dynamic json = BinaryData.FromString("""{"foo":1}""").ToDynamicFromJson(Dynamic.DynamicCaseMapping.PascalToCamel);

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
        #endregion
    }
}
