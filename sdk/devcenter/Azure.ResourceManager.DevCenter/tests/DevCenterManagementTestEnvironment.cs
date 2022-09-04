// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class DevCenterManagementTestEnvironment : TestEnvironment
    {
        public string DefaultDevCenterId => GetRecordedOptionalVariable("DefaultDevCenterId");

        public string DefaultProjectId => GetRecordedOptionalVariable("DefaultProjectId");
        public string DefaultMarketplaceDefinitionId => GetRecordedOptionalVariable("DefaultMarketplaceDefinitionId");

        public string DefaultNetworkConnectionId => GetRecordedOptionalVariable("DefaultNetworkConnectionId");

        public string DefaultAttachedNetworkName => GetRecordedOptionalVariable("DefaultAttachedNetworkName");

        /// <summary>
        /// Determines if tests running in recording model should delete the resource group after test run.
        /// </summary>
        internal static bool GlobalDisableResourceGroupCleanup
        {
            get
            {
                string switchString = TestContext.Parameters["DisableResourceGroupCleanup"] ?? Environment.GetEnvironmentVariable("AZURE_DISABLE_RESOURCE_GROUP_CLEANUP");

                bool.TryParse(switchString, out bool disableAutoRecording);

                return disableAutoRecording || GlobalIsRunningInCI;
            }
        }
    }
}
