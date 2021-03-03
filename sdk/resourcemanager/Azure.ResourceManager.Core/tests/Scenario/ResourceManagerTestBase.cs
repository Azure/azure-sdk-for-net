// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceManagerTestBase : Track2ManagementRecordedTestBase<ResourceManagerTestEnvironment>
    {
        public AzureResourceManagerClient ArmClient { get; private set; }

        protected ResourceManagerTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ResourceManagerTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        private void Initialize()
        {
            ArmClient = GetArmClient();
        }

        [SetUp]
        public void SetUp()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        protected void TearDown()
        {
            CleanupResourceGroups();
        }
    }
}
