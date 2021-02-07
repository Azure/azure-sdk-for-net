// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.Core.JsonPatch;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class JsonPatchDocumentTests
    {
        [Test]
        public void AddIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendAddRaw("/a/b/c","[ \"foo\", \"bar\" ]");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"add\",\"path\":\"/a/b/c\",\"value\":[\"foo\",\"bar\"]}]");
        }

        [Test]
        public void AddIsSerializedCorrectlyGeneric()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendAdd("/a/b/c",new[] { "foo", "bar" });
            Assert.AreEqual(document.ToString(), "[{\"op\":\"add\",\"path\":\"/a/b/c\",\"value\":[\"foo\",\"bar\"]}]");
        }

        [Test]
        public void ReplaceIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendReplaceRaw("/a/b/c","[ \"foo\", \"bar\" ]");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"replace\",\"path\":\"/a/b/c\",\"value\":[\"foo\",\"bar\"]}]");
        }

        [Test]
        public void ReplaceIsSerializedCorrectlyGeneric()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendReplace("/a/b/c",2);
            Assert.AreEqual(document.ToString(), "[{\"op\":\"replace\",\"path\":\"/a/b/c\",\"value\":2}]");
        }

        [Test]
        public void TestIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendTestRaw("/a/b/c","[ \"foo\", \"bar\" ]");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"test\",\"path\":\"/a/b/c\",\"value\":[\"foo\",\"bar\"]}]");
        }

        [Test]
        public void TestIsSerializedCorrectlyGeneric()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendTest("/a/b/c",new { a = 2});
            Assert.AreEqual(document.ToString(), "[{\"op\":\"test\",\"path\":\"/a/b/c\",\"value\":{\"a\":2}}]");
        }

        [Test]
        public void RemoveIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendRemove("/a/b/c");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"remove\",\"path\":\"/a/b/c\"}]");
        }

        [Test]
        public void MoveIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendMove("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"move\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void CopyIsSerializedCorrectly()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendCopy("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void MultipleOperationsSerializedInOrder()
        {
            JsonPatchDocument document = new JsonPatchDocument();
            document.AppendTestRaw("/a/b/c","\"foo\"");
            document.AppendAddRaw("/a/b/c","42");
            document.AppendReplaceRaw("/a/b/c","[ \"foo\", \"bar\" ]");
            document.AppendRemove("/a/b/c");
            document.AppendMove("/a/b/c", "/a/b/d");
            document.AppendCopy("/a/b/c", "/a/b/d");

            Assert.AreEqual(document.ToString(),
                "[" +
                     "{\"op\":\"test\",\"path\":\"/a/b/c\",\"value\":\"foo\"}," +
                     "{\"op\":\"add\",\"path\":\"/a/b/c\",\"value\":42}," +
                     "{\"op\":\"replace\",\"path\":\"/a/b/c\",\"value\":[\"foo\",\"bar\"]}," +
                     "{\"op\":\"remove\",\"path\":\"/a/b/c\"}," +
                     "{\"op\":\"move\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}," +
                     "{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}" +
                     "]");
        }

        [Test]
        public void CanAppendOperationsToExistingEmpty()
        {
            JsonPatchDocument document = new JsonPatchDocument(Encoding.UTF8.GetBytes(""));
            document.AppendCopy("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void CanAppendOperationsToExistingEmptyArray()
        {
            JsonPatchDocument document = new JsonPatchDocument(Encoding.UTF8.GetBytes("[]"));
            document.AppendCopy("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void CanAppendOperationsToExistingSingle()
        {
            JsonPatchDocument document = new JsonPatchDocument(Encoding.UTF8.GetBytes(
                "[{\"op\":\"custom\"}]"));
            document.AppendCopy("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"custom\"},{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void CanAppendOperationsToExistingMultiple()
        {
            JsonPatchDocument document = new JsonPatchDocument(Encoding.UTF8.GetBytes(
                "[" +
                "{\"op\":\"custom\"}," +
                "{\"op\":\"copy\",\"from\":\"q\",\"path\":\"w\"}]"));

            document.AppendCopy("/a/b/c", "/a/b/d");
            Assert.AreEqual(document.ToString(), "[{\"op\":\"custom\"},{\"op\":\"copy\",\"from\":\"q\",\"path\":\"w\"},{\"op\":\"copy\",\"from\":\"/a/b/c\",\"path\":\"/a/b/d\"}]");
        }

        [Test]
        public void ExistingBytesReturnedWithoutValidation()
        {
            JsonPatchDocument document = new JsonPatchDocument(Encoding.UTF8.GetBytes(
                "this is not correct json"));
            Assert.AreEqual(document.ToString(), "this is not correct json");
        }
    }
}