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

            // when using the ReadOnlySpan constructor the underlying data is copied.
            var data = new BinaryData(new ReadOnlySpan<byte>(bytes));

            // when using the FromMemory method, the data is wrapped
            data = BinaryData.FromMemory(bytes);

            // there is an implicit cast defined for ReadOnlyMemory<byte>
            ReadOnlyMemory<byte> rom = data;

            // there is also a Bytes property that holds the data
            rom = data.Bytes;
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

            var data = BinaryData.Serialize(model);
            model = data.Deserialize<CustomModel>();
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
