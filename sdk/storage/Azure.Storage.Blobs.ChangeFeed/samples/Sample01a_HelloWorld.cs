// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    /// <summary>
    /// Basic Azure ChangeFeed Storage samples.
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Sample sample.
        /// </summary>
        [Test]
        public void SampleSample()
        {
            Assert.AreEqual(1, 1);
        }
    }
}