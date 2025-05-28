// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using Azure.IoT.DeviceOnboarding.Models;
using System.Net;
using Azure.IoT.DeviceOnboarding.Samples;

namespace Azure.IoT.DeviceOnboarding.Tests
{
    [TestFixture]
    public class DeviceOnboardingTestsBase : RecordedTestBase<DeviceOnboardingTestEnvironment>
    {
        protected DeviceOnboardingTestsBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DeviceOnboardingTestsBase(bool isAsync)
            : base(isAsync)
        {
        }
    }
}
