// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.IO;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class StorageAbstractionTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetStorageAccountName_Internal()
        {
            var storageCreds = new WindowsAzureStorageAccountCredentials()
            {
                Name = Constants.WabsProtocolSchemeName + "demostorage.blob.core.windows-int.net"
            };

            var wabsStorageClient = new WabStorageAbstraction(storageCreds);
            Assert.AreEqual("demostorage", wabsStorageClient.StorageAccountName);
            Assert.AreEqual("http://demostorage.blob.core.windows-int.net", wabsStorageClient.StorageAccountRoot);
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanConvertWabsPathToHttpPath()
        {
            var storageCreds = new WindowsAzureStorageAccountCredentials()
            {
                Name = "demostorage.blob.core.windows-int.net"
            };

            var asvPath = Constants.WabsProtocolSchemeName + "container@demostorage.blob.core.windows-int.net/path1/path2";
            var httpPath = WabStorageAbstraction.ConvertToHttpPath(new Uri(asvPath));
            Assert.AreEqual("http://demostorage.blob.core.windows-int.net/container/path1/path2", httpPath.AbsoluteUri);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetStorageAccountName_Production()
        {
            var storageCreds = new WindowsAzureStorageAccountCredentials()
            {
                Name = "demostorage"
            };

            var wabsStorageClient = new WabStorageAbstraction(storageCreds);
            Assert.AreEqual(wabsStorageClient.StorageAccountName, "demostorage");
            Assert.AreEqual(wabsStorageClient.StorageAccountRoot, "http://demostorage.blob.core.windows.net/");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanRoundTripHttpPath()
        {
            var httpPath = new Uri("http://storageaccounthost.blob.core.windows.net/containerName");
            var asvPath = WabStorageAbstraction.ConvertToAsvPath(httpPath);
            var httpPathRoundTripped = WabStorageAbstraction.ConvertToHttpPath(asvPath);
            Assert.AreEqual(httpPath.OriginalString.TrimEnd('/'), httpPathRoundTripped.OriginalString.TrimEnd('/'));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanConvertAsvPathToHttpPath()
        {
            var asvPath = new Uri(Constants.WabsProtocolSchemeName + "containerName@storageaccounthost.blob.core.windows.net");
            var httpPath = WabStorageAbstraction.ConvertToHttpPath(asvPath);
            var expectedHttpPath = "http://storageaccounthost.blob.core.windows.net/containerName";
            Assert.AreEqual(expectedHttpPath, httpPath.OriginalString.TrimEnd('/'));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanConvertHttpPathToAsvPath()
        {
            var httpPath = new Uri("http://storageaccounthost.blob.core.windows.net/containerName");
            var asvPath = WabStorageAbstraction.ConvertToAsvPath(httpPath);
            var expectedAsvPath = Constants.WabsProtocolSchemeName + "containerName@storageaccounthost.blob.core.windows.net";
            Assert.AreEqual(expectedAsvPath, asvPath.OriginalString.TrimEnd('/'));
        }
    }
}
