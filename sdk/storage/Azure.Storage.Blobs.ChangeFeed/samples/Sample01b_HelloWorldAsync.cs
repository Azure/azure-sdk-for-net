// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    /// <summary>
    /// Basic Azure ChangeFeed Storage samples.
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Sample sample.
        /// </summary>
        [Test]
        public async Task SampleSample()
        {
            await Task.CompletedTask;
            Assert.AreEqual(1, 1);
        }
    }
}