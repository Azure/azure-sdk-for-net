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

        public string DefaultPoolId => GetRecordedOptionalVariable("DEFAULT_POOL_ID");

        public string DefaultMarketplaceDefinitionId => GetRecordedOptionalVariable("DEFAULT_MARKETPLACE_DEFINITION_ID");

        public string DefaultNetworkConnectionId => GetRecordedOptionalVariable("DEFAULT_NETWORKCONNECTION_ID");

        public string DefaultAttachedNetworkName => GetRecordedOptionalVariable("DEFAULT_ATTACHED_NETWORK_NAME");

        public string DefaultNetworkConnection2Id => GetRecordedOptionalVariable("DEFAULT_NETWORK_CONNECTION_ID");

        public string DefaultComputeGalleryId => GetRecordedOptionalVariable("DEFAULT_COMPUTE_GALLERY_ID");

        public string CatalogKeyVaultSecretIdentifier => GetRecordedOptionalVariable("CATALOG_PAT_IDENTIFIER");

        public string GitHubRepoPath => GetRecordedOptionalVariable("CATALOG_GITHUB_PATH");

        public string GitHubRepoUri => GetRecordedOptionalVariable("CATALOG_GITHUB_URI");

        public string TestUserOid => GetRecordedOptionalVariable("STATIC_TEST_USER_ID");

        public string DefaultEnvironmentTypeName => GetRecordedOptionalVariable("DEFAULT_ENVIRONMENT_TYPE_NAME");
    }
}
