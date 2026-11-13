// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.Provisioning.Tests;

[AsyncOnly]
public class ProvisioningTestBase : ManagementRecordedTestBase<ProvisioningTestEnvironment>
{
    public bool SkipTools { get; set; }
    public bool SkipLiveCalls { get; set; }

    public ProvisioningTestBase(bool async, bool skipTools = true, bool skipLiveCalls = true)
        : base(async, RecordedTestMode.Live)
    {
        // Ignore the version of the AZ CLI used to generate the ARM template as this will differ based on the environment
        JsonPathSanitizers.Add("$.._generator.version");
        JsonPathSanitizers.Add("$.._generator.templateHash");

        // Dial how long we spend waiting during iterative development since
        // we're not saving any of the recordings by default (yet)
        SkipTools = skipTools && skipLiveCalls; // We can't skip tools during live calls
        SkipLiveCalls = skipLiveCalls;
    }

    public override void GlobalTimeoutTearDown()
    {
        // Turn off global timeout errors because these tests can be much slower
        // base.GlobalTimeoutTearDown();
    }
}
