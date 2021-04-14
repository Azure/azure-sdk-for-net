// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public class ChatSampleBase : SamplesBase<ChatTestEnvironment>
    {
        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreTests)
            {
                Assert.Ignore("Chat samples are skipped " +
                    "because chat package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }
    }
}
