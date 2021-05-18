// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineRequestContentTests
    {
        [Test]
        public void StreamCopyToCancellation()
        {
            int size = 100;
            var source = new MemoryStream(size);
            var destination = new MemoryStream(size);
            var content = RequestContent.Create(source);
            var cancellation = new CancellationTokenSource();
            cancellation.Cancel();
            Assert.Throws<OperationCanceledException>(() => { content.WriteTo(destination, cancellation.Token); });
        }

        [Test]
        public void StreamCopyTo()
        {
            int size = 100;
            var sourceArray = new byte[size];
            var destinationArray = new byte[size * 2];
            new Random(100).NextBytes(sourceArray);

            var source = new MemoryStream(sourceArray);
            var destination = new MemoryStream(destinationArray);
            var content = RequestContent.Create(source);

            content.WriteTo(destination, default);

            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(sourceArray[i], destinationArray[i]);
            }
            for (int i = size; i < destinationArray.Length; i++)
            {
                Assert.AreEqual(0, destinationArray[i]);
            }
        }

        [Test]
        public void BinaryDataContent()
        {
            int size = 100;
            var sourceArray = new byte[size];
            var destinationArray = new byte[size];
            new Random(100).NextBytes(sourceArray);

            var source = new BinaryData(sourceArray);
            var destination = new MemoryStream(destinationArray);
            var content = RequestContent.Create(source);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(sourceArray, destination.ToArray());
        }

        [Test]
        public void StringContent()
        {
            const string testString = "sample content";

            var expected = (new UTF8Encoding(false)).GetBytes(testString);
            var destination = new MemoryStream();
            var content = RequestContent.Create(testString);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected, destination.ToArray());
        }

        [Test]
        public void ObjectContent()
        {
            var objectToSerialize = new
            {
                StringProperty = "foo",
                NumberProperty = 5,
            };

            var expected = (new UTF8Encoding(false)).GetBytes(JsonSerializer.Serialize(objectToSerialize));
            var destination = new MemoryStream();
            var content = RequestContent.Create(objectToSerialize);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected, destination.ToArray());
        }
    }
}
