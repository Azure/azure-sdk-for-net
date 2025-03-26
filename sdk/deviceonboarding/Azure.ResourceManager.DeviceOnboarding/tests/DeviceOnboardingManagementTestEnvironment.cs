// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.DeviceOnboarding.Tests
{
    public class DeviceOnboardingManagementTestEnvironment : TestEnvironment
    {
        public string DeviceOnboardingResourceGroup => GetRecordedVariable("DEVICEONBOARDING_RESOURCE_GROUP");
        public string DeviceOnboardingSubscription => GetRecordedVariable("DEVICEONBOARDING_SUBSCRIPTION_ID");
    }
}
