// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Recording.RecordingProxy;

namespace OpenAI.TestFramework.Tests
{
    [TestFixture]
    public class RecordingTests
    {
        [TestCase]
        public async Task StartProxy()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            Proxy proxy = await Proxy.CreateNewAsync(
                new ProxyOptions()
                {
                    StorageLocationDir = @"c:\temp"
                },
                cts.Token);

            Assert.That(proxy, Is.Not.Null);
            Assert.DoesNotThrow(proxy.ThrowOnErrors);
            proxy.Dispose();
        }
    }
}
