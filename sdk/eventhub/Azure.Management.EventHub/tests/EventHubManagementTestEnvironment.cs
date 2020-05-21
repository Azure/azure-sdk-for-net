// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.EventHub.Tests
{
    public class EventHubManagementTestEnvironment : TestEnvironment
    {
        public EventHubManagementTestEnvironment() : base("eventhubmgmt")
        {
        }
    }
}
