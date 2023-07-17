// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppPlatform.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppPlatform.Tests
{
    internal class AppPlatformCertificateTests : AppPlatformManagementTestBase
    {
        //private AppPlatformBuildServiceCollection _appPlatformBuildServiceCollection;
        //private const string _buildServicesName = "default";

        public AppPlatformCertificateTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            var _appPlatformBuildServiceCollection = service.GetAppPlatformCertificates();
            var list = await _appPlatformBuildServiceCollection.GetAllAsync().ToEnumerableAsync();
        }

        [Test]
        public void Exist()
        {
            Assert.IsTrue(true);
        }
    }
}
