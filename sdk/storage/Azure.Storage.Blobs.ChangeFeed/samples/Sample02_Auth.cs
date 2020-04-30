// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    public class Sample02_Auth : SampleTest
    {
        [Test]
        public async Task SampleSample()
        {
            await Task.CompletedTask;
            Assert.IsTrue(true);
        }
    }
}