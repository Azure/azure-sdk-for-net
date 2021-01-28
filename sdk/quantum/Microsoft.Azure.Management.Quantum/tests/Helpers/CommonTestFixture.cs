// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.Quantum.Tests
{
    public class CommonTestFixture : TestBase
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets storage account name.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets storage account access key.
        /// </summary>
        public string StorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets storage account id.
        /// </summary>
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        public const string WorkspaceType = "Microsoft.Quantum/workspaces";

        /// <summary>
        /// Ctor
        /// </summary>
        public CommonTestFixture()
        {
            Location = "westus";
            ResourceGroupName = TestUtilities.GenerateName("sdktestrg-");
            StorageAccountName = TestUtilities.GenerateName("sdktestst");
        }
    }
}