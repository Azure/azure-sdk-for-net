// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Json;
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

        #region Helpers
        internal class BinaryDataModel
        {
            public BinaryDataModel() { }
            public string StringProperty { get; set; }
            public BinaryData BinaryDataProperty { get; set; }
        }
        #endregion
    }
}
