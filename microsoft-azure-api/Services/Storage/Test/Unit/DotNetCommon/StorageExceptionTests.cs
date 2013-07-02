// -----------------------------------------------------------------------------------------
// <copyright file="StorageExceptionTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml;

    [TestClass]
    public class StorageExceptionTests
    {
        [TestMethod]
        [Description("Persist and read back StorageException")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageExceptionVerifyXml()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient client = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            CloudBlobContainer container = client.GetContainerReference(Guid.NewGuid().ToString("N"));
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                byte[] buffer = new byte[1024];
                Random random = new Random();
                random.NextBytes(buffer);

                using(MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(stream);
                }

                CloudPageBlob blob2 = container.GetPageBlobReference("blob1");
                StorageException e = TestHelper.ExpectedException<StorageException>(
                    () => blob2.FetchAttributes(),
                    "Fetching attributes of a block blob using a page blob reference should fail");

                using (Stream s = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, e);
                    s.Position = 0; // Reset stream position
                    StorageException e2 = (StorageException)formatter.Deserialize(s);

                    Assert.IsInstanceOfType(e2.InnerException, typeof(InvalidOperationException));
                    Assert.AreEqual(e.IsRetryable, e2.IsRetryable);
                    Assert.AreEqual(e.RequestInformation.HttpStatusCode, e2.RequestInformation.HttpStatusCode);
                    Assert.AreEqual(e.RequestInformation.HttpStatusMessage, e2.RequestInformation.HttpStatusMessage);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Persist and read back ExtendedErrorInfo")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ExtendedErrorInfoVerifyXml()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient client = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            CloudBlobContainer container = client.GetContainerReference(Guid.NewGuid().ToString("N"));
            
            try
            {
                StorageException e = TestHelper.ExpectedException<StorageException>(
                    () => container.GetPermissions(),
                    "Try to get permissions on a non-existent container");

                Assert.IsNotNull(e.RequestInformation.ExtendedErrorInformation);

                StorageExtendedErrorInformation retrErrorInfo = new StorageExtendedErrorInformation();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    e.RequestInformation.ExtendedErrorInformation.WriteXml(writer);
                }

                using (XmlReader reader = XmlReader.Create(new StringReader(sb.ToString())))
                {
                    retrErrorInfo.ReadXml(reader);
                }

                Assert.AreEqual(e.RequestInformation.ExtendedErrorInformation.ErrorCode, retrErrorInfo.ErrorCode);
                Assert.AreEqual(e.RequestInformation.ExtendedErrorInformation.ErrorMessage, retrErrorInfo.ErrorMessage);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Persist and read back RequestResult")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void RequestResultVerifyXml()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient blobClient = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            CloudBlobContainer container = blobClient.GetContainerReference(Guid.NewGuid().ToString("N"));

            OperationContext opContext = new OperationContext();
            Assert.IsNull(opContext.LastResult);
            container.Exists(null, opContext);
            Assert.IsNotNull(opContext.LastResult);

            // We do not have precision at milliseconds level. Hence, we need
            // to recreate the start DateTime to be able to compare it later.
            DateTime start = opContext.LastResult.StartTime;
            start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);

            DateTime end = opContext.LastResult.EndTime;
            end = new DateTime(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                opContext.LastResult.WriteXml(writer);
            }

            RequestResult retrResult = new RequestResult();
            using (XmlReader reader = XmlReader.Create(new StringReader(sb.ToString())))
            {
                retrResult.ReadXml(reader);
            }

            Assert.AreEqual(opContext.LastResult.RequestDate, retrResult.RequestDate);
            Assert.AreEqual(opContext.LastResult.ServiceRequestID, retrResult.ServiceRequestID);
            Assert.AreEqual(start, retrResult.StartTime);
            Assert.AreEqual(end, retrResult.EndTime);
            Assert.AreEqual(opContext.LastResult.HttpStatusCode, retrResult.HttpStatusCode);
            Assert.AreEqual(opContext.LastResult.HttpStatusMessage, retrResult.HttpStatusMessage);
            Assert.AreEqual(opContext.LastResult.ContentMd5, retrResult.ContentMd5);
            Assert.AreEqual(opContext.LastResult.Etag, retrResult.Etag);

            // Now test with no indentation
            sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                opContext.LastResult.WriteXml(writer);
            }

            retrResult = new RequestResult();
            using (XmlReader reader = XmlReader.Create(new StringReader(sb.ToString())))
            {
                retrResult.ReadXml(reader);
            }

            Assert.AreEqual(opContext.LastResult.RequestDate, retrResult.RequestDate);
            Assert.AreEqual(opContext.LastResult.ServiceRequestID, retrResult.ServiceRequestID);
            Assert.AreEqual(start, retrResult.StartTime);
            Assert.AreEqual(end, retrResult.EndTime);
            Assert.AreEqual(opContext.LastResult.HttpStatusCode, retrResult.HttpStatusCode);
            Assert.AreEqual(opContext.LastResult.HttpStatusMessage, retrResult.HttpStatusMessage);
            Assert.AreEqual(opContext.LastResult.ContentMd5, retrResult.ContentMd5);
            Assert.AreEqual(opContext.LastResult.Etag, retrResult.Etag);
        }
    }
}
