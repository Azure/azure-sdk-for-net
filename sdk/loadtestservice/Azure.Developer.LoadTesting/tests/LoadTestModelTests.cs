// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Developer.LoadTesting.Models;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestModelTests
    {
        [Test]
        public void CanSetTestId()
        {
            Test test = new()
            {
                TestId = "abc"
            };

            Assert.AreEqual("abc", test.TestId);
        }

        [Test]
        public void CanGetTestId()
        {
            JsonDocument doc = JsonDocument.Parse("""{"testId":"abc"}""");
            Test test = new(doc.RootElement);

            Assert.AreEqual("abc", test.TestId);
        }

        [Test]
        public void CanPatchTestId_NoChanges()
        {
            JsonDocument doc = JsonDocument.Parse("""{"testId":"abc"}""");
            Test test = new(doc.RootElement);

            BinaryData utf8;
            using (MemoryStream stream = new())
            {
                test.WritePatch(stream);
                stream.Position = 0;
                utf8 = BinaryData.FromStream(stream);
            }

            CollectionAssert.AreEqual(""u8.ToArray(), utf8.ToArray());
        }

        [Test]
        public void CanPatchTestId_OneChange()
        {
            JsonDocument doc = JsonDocument.Parse("""{"testId":"abc"}""");
            Test test = new(doc.RootElement);

            test.TestId = "def";

            BinaryData utf8;
            using (MemoryStream stream = new())
            {
                test.WritePatch(stream);
                stream.Position = 0;
                utf8 = BinaryData.FromStream(stream);
            }

            Assert.AreEqual("""{"testId":"def"}""", utf8.ToString());
        }
    }
}
