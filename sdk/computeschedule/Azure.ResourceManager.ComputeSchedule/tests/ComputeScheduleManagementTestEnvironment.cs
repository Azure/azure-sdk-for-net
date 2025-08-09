// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleManagementTestEnvironment : TestEnvironment
    {
        public string ResourceGroupName => GetRecordedVariable("COMPUTESCHEDULE_RESOURCE_GROUP");
        public string SubId => GetRecordedVariable("COMPUTESCHEDULE_SUBSCRIPTION_ID");
        public string CsLocation => GetRecordedVariable("COMPUTESCHEDULE_LOCATION");
    }
}
