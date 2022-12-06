// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [AsyncOnly]
    public class AsyncOnlyClientTestBaseTests : ClientTestBase
    {
        public AsyncOnlyClientTestBaseTests(bool isAsync) : base(isAsync)
        {
            Assert.IsTrue(isAsync);
        }

        [Test]
        public void ValudateAllTestsAreAsync()
        {
            Assert.IsTrue(IsAsync);
        }
    }
}