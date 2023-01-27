// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class MutableJsonElementTests
    {
        [Test]
        public void CanGetElementAsString()
        {
            string json = @"
                {
                  ""Bar"" : ""Hi!""
                }";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(json),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(jd.RootElement.ToString()));
        }

        [Test]
        public void ChangesToElementAppearInToString()
        {
            string json = @"
                {
                  ""Bar"" : ""Hi!""
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Bar").Set("hello");

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Bar"" : ""hello""
                }"),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(jd.RootElement.ToString()));
        }

        [Test]
        public void ChangesToElementAppearInJsonElement()
        {
            string json = @"
                {
                  ""Bar"" : ""Hi!""
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Bar").Set("hello");

            JsonElement barElement = jd.RootElement.GetProperty("Bar").GetJsonElement();
            Assert.AreEqual("hello", barElement.GetString());

            JsonElement rootElement = jd.RootElement.GetJsonElement();
            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Bar"" : ""hello""
                }"),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(rootElement.ToString()));
        }
    }
}
