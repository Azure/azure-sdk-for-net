// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [SyncOnly]
    public class SyncOnlyClientTestBaseTests : ClientTestBase
    {
        public SyncOnlyClientTestBaseTests(bool isAsync) : base(isAsync)
        {
            Assert.That(isAsync, Is.False);
        }

        [Test]
        public void ValidateAllTestsAreSync()
        {
            Assert.That(IsAsync, Is.False);
        }
    }
}
