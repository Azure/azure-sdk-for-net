// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    // todo: rename: MachineLearningServicesTestBase? RecordedTestBase?
    public abstract class TestBase : ManagementRecordedTestBase<MachineLearningTestEnvironment>
    {
        protected TestBase(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        protected TestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ArmClient Client { get; private set; }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
    }
}
