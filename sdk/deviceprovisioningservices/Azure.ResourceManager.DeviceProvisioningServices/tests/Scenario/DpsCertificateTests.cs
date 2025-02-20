// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceProvisioningServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceProvisioningServices.Tests
{
    internal class DpsCertificateTests : DeviceProvisioningServicesManagementTestBase
    {
        private DeviceProvisioningServicesCertificateCollection _dpsCertificateCollection;
        private string _certContent = "Sanitized";

        public DpsCertificateTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var dps = await CreateDefaultDps(resourceGroup, Recording.GenerateAssetName("dps"));
            _dpsCertificateCollection = dps.GetDeviceProvisioningServicesCertificates();
        }

        [RecordedTest]
        [PlaybackOnly("Re-record needs to give a correct _certContent value")]
        public async Task DpsCertificateOperations()
        {
            // create
            string certName = Recording.GenerateAssetName("cert");
            var cert = await CreateDpsCertificate(certName);
            ValidateDpsCertificate(cert.Data, certName);

            // exist
            bool flag = await _dpsCertificateCollection.ExistsAsync(certName);
            Assert.IsTrue(flag);

            // get
            var getCert = await _dpsCertificateCollection.GetAsync(certName);
            ValidateDpsCertificate(getCert.Value.Data, certName);

            // getall
            var list = await _dpsCertificateCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDpsCertificate(list.FirstOrDefault().Data, certName);

            // delete
            await cert.DeleteAsync(WaitUntil.Completed, cert.Data.ETag.ToString());
            flag = await _dpsCertificateCollection.ExistsAsync(certName);
            Assert.IsFalse(flag);
        }

        private async Task<DeviceProvisioningServicesCertificateResource> CreateDpsCertificate(string certName)
        {
            var data = new DeviceProvisioningServicesCertificateData()
            {
                Properties = new DeviceProvisioningServicesCertificateProperties()
                {
                    Certificate = BinaryData.FromString($"\"{_certContent}\"")
                }
            };
            var certLro = await _dpsCertificateCollection.CreateOrUpdateAsync(WaitUntil.Completed, certName, data);
            return certLro.Value;
        }

        private void ValidateDpsCertificate(DeviceProvisioningServicesCertificateData dpsData, string dpsName)
        {
            Assert.IsNotNull(dpsData);
            Assert.IsNotNull(dpsData.Id);
            Assert.IsNotNull(dpsData.ETag);
            Assert.AreEqual(dpsData.Name, dpsName);
            Assert.AreEqual("Microsoft.Devices/provisioningServices/Certificates", dpsData.ResourceType.ToString());
        }
    }
}
