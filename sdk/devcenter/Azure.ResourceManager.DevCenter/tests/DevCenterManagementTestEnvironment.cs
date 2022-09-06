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

        public string DefaultNetworkConnection2Id => GetRecordedOptionalVariable("DefaultNetworkConnection2Id");
    }
}
