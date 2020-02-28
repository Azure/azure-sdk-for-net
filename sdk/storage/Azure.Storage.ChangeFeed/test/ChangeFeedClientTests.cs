// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.ChangeFeed;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Tests
{
    public class ChangeFeedClientTests
    {
        [Test]
        public void GetStarted()
        {
            Assert.AreEqual(42, ChangeFeedClient.GetChanges(new Uri("http://azure.com")));
        }
    }
}
