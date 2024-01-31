// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ContentTypeTests
    {
        [Test]
        public void Basics()
        {
            ContentType contentType = default;
            Assert.AreEqual("", contentType.ToString());
            Assert.IsTrue(contentType.Equals(null));
            Assert.IsTrue(contentType.Equals(new ContentType()));

            string aj = "application/json";
            contentType = ContentType.ApplicationJson;
            Assert.AreEqual(aj, contentType.ToString());
            Assert.IsTrue(contentType.Equals(aj));
            Assert.IsTrue(contentType.Equals(new ContentType(aj)));
            Assert.IsTrue(contentType.Equals((object)aj));
            Assert.IsTrue(contentType.Equals((object)new ContentType(aj)));
            Assert.IsFalse(contentType.Equals("text/plain"));
            Assert.IsFalse(contentType.Equals(null));

            string aos = "application/octet-stream";
            contentType = ContentType.ApplicationOctetStream;
            Assert.AreEqual(aos, contentType.ToString());
            Assert.IsTrue(contentType.Equals(aos));
            Assert.IsTrue(contentType.Equals(new ContentType(aos)));
            Assert.IsTrue(contentType.Equals((object)aos));
            Assert.IsTrue(contentType.Equals((object)new ContentType(aos)));
            Assert.IsFalse(contentType.Equals("text/plain"));
            Assert.IsFalse(contentType.Equals(null));

            string pt = "text/plain";
            contentType = ContentType.TextPlain;
            Assert.AreEqual(pt, contentType.ToString());
            Assert.IsTrue(contentType.Equals(pt));
            Assert.IsTrue(contentType.Equals(new ContentType(pt)));
            Assert.IsTrue(contentType.Equals((object)pt));
            Assert.IsTrue(contentType.Equals((object)new ContentType(pt)));
            Assert.IsFalse(contentType.Equals("application/json"));
            Assert.IsFalse(contentType.Equals(null));
        }
    }
}
