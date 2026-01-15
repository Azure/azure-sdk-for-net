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
            Assert.That(contentType.ToString(), Is.Empty);
            Assert.That(contentType.Equals(null), Is.True);
            Assert.That(contentType.Equals(new ContentType()), Is.True);

            string aj = "application/json";
            contentType = ContentType.ApplicationJson;
            Assert.That(contentType.ToString(), Is.EqualTo(aj));
            Assert.That(contentType.Equals(aj), Is.True);
            Assert.That(contentType.Equals(new ContentType(aj)), Is.True);
            Assert.That(contentType.Equals((object)aj), Is.True);
            Assert.That(contentType.Equals((object)new ContentType(aj)), Is.True);
            Assert.That(contentType.Equals("text/plain"), Is.False);
            Assert.That(contentType.Equals(null), Is.False);

            string aos = "application/octet-stream";
            contentType = ContentType.ApplicationOctetStream;
            Assert.That(contentType.ToString(), Is.EqualTo(aos));
            Assert.That(contentType.Equals(aos), Is.True);
            Assert.That(contentType.Equals(new ContentType(aos)), Is.True);
            Assert.That(contentType.Equals((object)aos), Is.True);
            Assert.That(contentType.Equals((object)new ContentType(aos)), Is.True);
            Assert.That(contentType.Equals("text/plain"), Is.False);
            Assert.That(contentType.Equals(null), Is.False);

            string pt = "text/plain";
            contentType = ContentType.TextPlain;
            Assert.That(contentType.ToString(), Is.EqualTo(pt));
            Assert.That(contentType.Equals(pt), Is.True);
            Assert.That(contentType.Equals(new ContentType(pt)), Is.True);
            Assert.That(contentType.Equals((object)pt), Is.True);
            Assert.That(contentType.Equals((object)new ContentType(pt)), Is.True);
            Assert.That(contentType.Equals("application/json"), Is.False);
            Assert.That(contentType.Equals(null), Is.False);
        }
    }
}
