// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using IntegrationTestCommon;

    public class ApplicationPackageFixture : IDisposable
    {
        private const string ApplicationId = "iaprt" + ApplicationIntegrationCommon.ApplicationId;
        private const string Version = ApplicationIntegrationCommon.Version;

        public ApplicationPackageFixture()
        {
            IntegrationTestCommon.EnableAutoStorageAsync().Wait();

            ApplicationIntegrationCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(
                ApplicationId,
                Version,
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountResourceGroup).Wait();
        }

        public void Dispose()
        {
            Task.Run(async () => await ApplicationIntegrationCommon.DeleteApplicationAsync(
                ApplicationId,
                TestCommon.Configuration.BatchAccountResourceGroup,
                TestCommon.Configuration.BatchAccountName)).GetAwaiter().GetResult();
        }
    }
}
