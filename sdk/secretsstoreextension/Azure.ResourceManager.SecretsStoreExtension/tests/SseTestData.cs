// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    // Constant data which is used for the test.  Non-constant data should be
    // supplied via environment variables and accessed via SecretsStoreExtensionManagementTestEnvironment.
    internal static class SseTestData
    {
        // Name of Kubernetes SPC object.
        internal const string SpcName = "sdk-test-spc";
        // Name of Kubernetes SecretSync object.
        internal const string SsName = "sdk-test-ss";
        // This custom location must already exist on the cluster.
        internal const string CustomLocationName = "sdk-test-custloc";
        // This service account must have already been created and federated with the UAMI.
        internal const string ServiceAccountName = "sdk-test-sa";
        // This secret must already exist in the keyvault
        internal const string RpSecretName1 = "sdk-test-secret-1";
        // This secret must already exist in the keyvault.
        internal const string RpSecretName2 = "sdk-test-secret-2";
        // This secret must already exist in the keyvault.
        internal const string RpSecretName3 = "sdk-test-secret-3";
        // This secret must already exist in the keyvault.
        internal const string RpSecretName4 = "sdk-test-secret-4";

        // Values used to test tagging and untagging objects in Azure.
        internal const string Tag1Name = "tag-1", Tag1Value = "value-1";
        // Values used to test tagging and untagging objects in Azure.
        internal const string Tag2Name = "tag-2", Tag2Value = "value-2";
        // Values used to test tagging and untagging objects in Azure.
        internal const string Tag3Name = "tag-3", Tag3Value = "value-3";
        // Values used to test tagging and untagging objects in Azure.
        internal const string Tag4Name = "tag-4", Tag4Value = "value-4";
        // Values used to test tagging and untagging objects in Azure.
    }
}
