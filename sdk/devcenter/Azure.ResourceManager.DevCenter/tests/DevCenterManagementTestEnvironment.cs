// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class DevCenterManagementTestEnvironment : TestEnvironment
    {
        public string DefaultDevCenterId => GetRecordedOptionalVariable("DEFAULT_DEVCENTER_ID");

        public string DefaultProjectId => GetRecordedOptionalVariable("DEFAULT_PROJECT_ID");
        public string DefaultMarketplaceDefinitionId => GetRecordedOptionalVariable("DEFAULT_MARKETPLACE_DEFINITION_ID");

        public string DefaultNetworkConnectionId => GetRecordedOptionalVariable("DEFAULT_NETWORKCONNECTION_ID");

        public string DefaultAttachedNetworkName => GetRecordedOptionalVariable("DEFAULT_ATTACHED_NETWORK_NAME");

        public string DefaultNetworkConnection2Id => GetRecordedOptionalVariable("DEFAULT_NETWORK_CONNECTION_ID");
    }
}
