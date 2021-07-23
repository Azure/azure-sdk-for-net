// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests
{
    public class MachineLearningServicesManagerTestBase : ManagementRecordedTestBase<MachineLearningServicesTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected MachineLearningServicesManagerTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MachineLearningServicesManagerTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
    }
}
