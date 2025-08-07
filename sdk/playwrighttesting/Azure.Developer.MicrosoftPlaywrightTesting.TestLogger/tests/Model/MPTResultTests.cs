// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Model
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class MPTResultTests
    {
        [Test]
        public void RawTestResult_Errors_Initialized()
        {
            var rawTestResult = new RawTestResult();
            Assert.AreEqual("[]", rawTestResult.errors);
            Assert.AreEqual("[]", rawTestResult.stdOut);
            Assert.AreEqual("[]", rawTestResult.stdErr);
        }
    }
}
