// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests.samples
{
    public class BinaryDataSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ToFromString()
        {
            #region Snippet:BinaryDataToFromString
            var data = new BinaryData("some data");

            // ToString will decode the bytes using UTF-8
            Console.WriteLine(data.ToString()); // prints "some data"
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ToFromBytes()
        {
            #region Snippet:BinaryDataToFromBytes
            var bytes = Encoding.UTF8.GetBytes("some data");

            // Create BinaryData using a constructor ...
            var data = new BinaryData(bytes);

            // Or using a static factory method.
            data = BinaryData.FromBytes(bytes);

            // There is an implicit cast defined for ReadOnlyMemory<byte>
            ReadOnlyMemory<byte> rom = data;

            // there is also a ToBytes method that gives access to the ReadOnlyMemory.
            rom = data.ToBytes();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ToFromStream()
        {
            #region Snippet:BinaryDataToFromStream
            var bytes = Encoding.UTF8.GetBytes("some data");
            Stream stream = new MemoryStream(bytes);
            var data = BinaryData.FromStream(stream);

            // Calling ToStream will give back a stream that is backed by ReadOnlyMemory, so it is not writable.
            stream = data.ToStream();
            Console.WriteLine(stream.CanWrite); // prints false
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ToFromCustomType()
        {
            #region Snippet:BinaryDataToFromCustomModel
            var model = new CustomModel
            {
                A = "some text",
                B = 5,
                C = true
            };

            var data = BinaryData.FromObjectAsJson(model);
            model = data.ToObjectFromJson<CustomModel>();
            #endregion
        }

        private class CustomModel
        {
            public string A { get; set; }
            public int B { get; set; }
            public bool C { get; set; }
        }
    }
}
