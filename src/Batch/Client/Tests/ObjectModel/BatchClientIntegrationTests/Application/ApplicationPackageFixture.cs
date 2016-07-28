// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;

    public class ApplicationPackageFixture : IDisposable
    {
        private const string ApplicationId = "iaprt" + ApplicationIntegrationCommon.ApplicationId;
        private const string Version = ApplicationIntegrationCommon.Version;

        public ApplicationPackageFixture()
        {
            TestCommon.EnableAutoStorageAsync().Wait();

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
