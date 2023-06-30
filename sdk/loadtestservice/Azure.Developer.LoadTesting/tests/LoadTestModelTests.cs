// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Json;
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
            MutableJsonDocument doc = MutableJsonDocument.Parse("""{"testId":"abc"}""");
            Test test = new(doc.RootElement);

            Assert.AreEqual("abc", test.TestId);
        }

        [Test]
        public void CanPatchTestId_NoChanges()
        {
            MutableJsonDocument doc = MutableJsonDocument.Parse("""{"testId":"abc"}""");
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
            MutableJsonDocument doc = MutableJsonDocument.Parse("""{"testId":"abc"}""");
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

        [Test]
        public void CanPatchDictionaryValue()
        {
            MutableJsonDocument doc = MutableJsonDocument.Parse("""{"testId":"abc"}""");
            Test test = new(doc.RootElement);

            test.EnvironmentVariables["a"] = "a";

            BinaryData utf8;
            using (MemoryStream stream = new())
            {
                test.WritePatch(stream);
                stream.Position = 0;
                utf8 = BinaryData.FromStream(stream);
            }

            Assert.AreEqual("""{"environmentVariables":{"a":"a"}}""", utf8.ToString());
        }

        [Test]
        public void CanSetTestPassFailMetric()
        {
            Test test = new();
            test.TestId = "abc";
            test.PassFailCriteria.PassFailMetrics.Add("a", new PassFailMetric() { RequestName = "a"});

            Assert.AreEqual("a", test.PassFailCriteria.PassFailMetrics["a"].RequestName);
        }

        [Test]
        public void CanPatchTestPassFailMetric()
        {
            Test test = new();
            test.PassFailCriteria.PassFailMetrics.Add("a", new PassFailMetric() { RequestName = "a" });

            Assert.AreEqual("a", test.PassFailCriteria.PassFailMetrics["a"].RequestName);

            BinaryData utf8;
            using (MemoryStream stream = new())
            {
                test.WritePatch(stream);
                stream.Position = 0;
                utf8 = BinaryData.FromStream(stream);
            }

            Assert.AreEqual("""{"passFailCriteria":{"passFailMetrics":{"a":"a"}}}""", utf8.ToString());
        }
    }
}
