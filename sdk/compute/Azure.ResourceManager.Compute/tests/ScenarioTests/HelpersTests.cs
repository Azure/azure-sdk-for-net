// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class HelpersTests :ComputeClientBase
    {
        public HelpersTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public void TestUtilityFunctions()
        {
            Assert.AreEqual("Azure.ResourceManager.Compute.Tests.HelpersTests", this.GetType().FullName);
#if NET46
            Assert.Equal("TestUtilityFunctions", TestUtilities.GetCurrentMethodName(1));
#else
            //Assert.AreEqual("TestUtilityFunctions", TestUtilities.GetCurrentMethodName());
#endif
        }
    }
}
