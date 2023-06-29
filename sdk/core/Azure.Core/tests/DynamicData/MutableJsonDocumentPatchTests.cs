// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class MutableJsonDocumentPatchTests
    {
        [Test]
        public void CanGetChanges()
        {
            string json = """
                {
                    "parent": {
                        "child": {
                            "a": "a",
                            "b": "b"
                        }
                    }
                }
                """;

            MutableJsonDocument mdoc = MutableJsonDocument.Parse(json);

            // Updates - 1
            mdoc.RootElement.GetProperty("parent").GetProperty("child").GetProperty("a").Set("a1");
            mdoc.RootElement.GetProperty("parent").GetProperty("child").GetProperty("b").Set("b1");

            // Updates - 2
            mdoc.RootElement.GetProperty("parent").SetProperty("child", new { b = "b2", c = "c2" });

            // Updates - 3
            mdoc.RootElement.GetProperty("parent").GetProperty("child").GetProperty("b").Set("b3");

            Assert.AreEqual(false, mdoc.RootElement.GetProperty("parent").GetProperty("child").TryGetProperty("a", out _));

            // Note: these throw because property "a" is not there.
            //Assert.AreEqual(null, mdoc.RootElement.GetProperty("parent").GetProperty("child").GetProperty("a").GetString());
            //Assert.AreEqual(JsonValueKind.Null, mdoc.RootElement.GetProperty("parent").GetProperty("child").GetProperty("a").GetJsonElement().ValueKind);

            // Note: The changelist currently won't see "a" as a removed property
            // TODO: We'll need to add a diff routine to identify added and removed properties
            //       when whole objects are modified.

            using MemoryStream stream = new();
            mdoc.WriteTo(stream, 'J');

            //mdoc.WriteTo(stream, 'P');
        }
    }
}
