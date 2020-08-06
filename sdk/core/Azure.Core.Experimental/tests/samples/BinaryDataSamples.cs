// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests.samples
{
    public class BinaryDataSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void HelloWorld()
        {
            #region Snippet:BinaryDataHelloWorld
            var data = new BinaryData("some data");

            // there is an implicit cast defined for ReadOnlyMemory<byte>
            ReadOnlyMemory<byte> bytes = data;

            // there is also a Bytes property that holds the data
            bytes = data.Bytes;

            // ToString will decode the bytes using UTF-8
            Console.WriteLine(data.ToString()); // prints "some data"

            // you can also create BinaryData from a stream
            data = BinaryData.FromStream(new MemoryStream());

            // and convert it to a stream
            var stream = data.ToStream();
            #endregion
        }
    }
}
