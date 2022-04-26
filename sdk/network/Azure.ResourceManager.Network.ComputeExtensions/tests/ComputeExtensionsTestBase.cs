// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Network.ComputeExtensions.Tests.Scenario
{
    public class ComputeExtensionsTestBase : ManagementRecordedTestBase<NetworkManagementTestEnvironment>
    {
        public ComputeExtensionsTestBase(bool isAsync) : base(isAsync)
        {
        }

        public ComputeExtensionsTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
    }
}
