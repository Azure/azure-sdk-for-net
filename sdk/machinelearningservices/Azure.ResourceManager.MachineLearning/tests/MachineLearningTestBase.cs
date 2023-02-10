// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearning.Tests
{
    public class MachineLearningTestBase : ManagementRecordedTestBase<MachineLearningEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public AzureLocation DefaultLocation = AzureLocation.WestUS;

        public MachineLearningTestBase(bool isAsync) : base(isAsync)
        {
        }

        public MachineLearningTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
    }
}
