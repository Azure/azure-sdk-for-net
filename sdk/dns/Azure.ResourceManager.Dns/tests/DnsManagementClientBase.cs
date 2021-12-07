// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Dns.Tests
{
    public abstract class DnsManagementClientBase : ManagementRecordedTestBase<DnsManagementTestEnvironment>
    {
        protected DnsManagementClientBase(bool isAsync) : base(isAsync)
        {
        }

        protected DnsManagementClientBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
    }
}
