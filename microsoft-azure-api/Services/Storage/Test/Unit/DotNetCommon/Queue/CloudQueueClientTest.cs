// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueClientTest.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    /// <summary>
    /// Summary description for CloudQueueClientTest
    /// </summary>
    [TestClass]
    public class CloudQueueClientTest : QueueTestBase
    {
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.QueueBufferManager != null)
            {
                TestBase.QueueBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.QueueBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.QueueBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        [Description("A test checks basic function of CloudQueueClient.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientConstructor()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint);
            CloudQueueClient queueClient = new CloudQueueClient(baseAddressUri, TestBase.StorageCredentials);
            Assert.IsTrue(queueClient.BaseUri.ToString().StartsWith(TestBase.TargetTenantConfig.QueueServiceEndpoint));
            Assert.AreEqual(TestBase.StorageCredentials, queueClient.Credentials);
            Assert.AreEqual(AuthenticationScheme.SharedKey, queueClient.AuthenticationScheme);
        }

        [TestMethod]
        [Description("A test checks basic function of CloudQueueClient.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientConstructorInvalidParam()
        {
            TestHelper.ExpectedException<ArgumentNullException>(() => new CloudQueueClient(null, TestBase.StorageCredentials), "Pass null into CloudQueueClient");
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesBasic()
        {
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 30;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            CloudQueueClient client = GenerateCloudQueueClient();
            List<CloudQueue> emptyResults = client.ListQueues(prefix, QueueListingDetails.All, null, null).ToList();
            Assert.AreEqual<int>(0, emptyResults.Count);

            foreach (string name in queueNames)
            {
                client.GetQueueReference(name).Create();
            }

            List<CloudQueue> results = client.ListQueues(prefix, QueueListingDetails.All, null, null).ToList();
            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmented()
        {
            CloudQueueClient client = GenerateCloudQueueClient();

            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                string queueName = prefix + i;
                queueNames.Add(queueName);
                client.GetQueueReference(queueName).Create();
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(token);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    client.GetQueueReference(queue.Name).Delete();
                }
            }

            Assert.AreEqual(0, queueNames.Count);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefix()
        {
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            CloudQueueClient client = GenerateCloudQueueClient();
            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, QueueListingDetails.None, null, token, null, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(0, results.Count);

            foreach (string name in queueNames)
            {
                client.GetQueueReference(name).Create();
            }

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, QueueListingDetails.None, 10, token, null, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefixOverload()
        {
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            CloudQueueClient client = GenerateCloudQueueClient();
            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, token);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(0, results.Count);

            foreach (string name in queueNames)
            {
                client.GetQueueReference(name).Create();
            }

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, token);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("Verify GetSchema, WriteXml and ReadXml on QueueContinuationToken")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueContinuationTokenVerifyXml()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 30;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
                client.GetQueueReference(prefix + i).Create();
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, QueueListingDetails.None, 5, token, null, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
                if (token != null)
                {
                    Assert.AreEqual(null, token.GetSchema());

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    StringBuilder sb = new StringBuilder();
                    using (XmlWriter writer = XmlWriter.Create(sb, settings))
                    {
                        token.WriteXml(writer);
                    }

                    using (XmlReader reader = XmlReader.Create(new StringReader(sb.ToString())))
                    {
                        token = new QueueContinuationToken();
                        token.ReadXml(reader);
                    }
                }
            }
            while (token != null);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("Verify GetSchema, WriteXml and ReadXml on QueueContinuationToken within another Xml")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueContinuationTokenVerifyXmlWithinXml()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 30;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
                client.GetQueueReference(prefix + i).Create();
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmented(prefix, QueueListingDetails.None, 5, token, null, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
                if (token != null)
                {
                    Assert.AreEqual(null, token.GetSchema());

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    StringBuilder sb = new StringBuilder();
                    using (XmlWriter writer = XmlWriter.Create(sb, settings))
                    {
                        writer.WriteStartElement("test1");
                        writer.WriteStartElement("test2");
                        token.WriteXml(writer);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    using (XmlReader reader = XmlReader.Create(new StringReader(sb.ToString())))
                    {
                        token = new QueueContinuationToken();
                        reader.ReadStartElement();
                        reader.ReadStartElement();
                        token.ReadXml(reader);
                        reader.ReadEndElement();
                        reader.ReadEndElement();
                    }
                }
            }
            while (token != null);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("Test Create Queue with Shared Key Lite")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientCreateQueueSharedKeyLite()
        {
            CloudQueueClient queueClient = GenerateCloudQueueClient();
            queueClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string queueName = Guid.NewGuid().ToString("N");
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            queue.Create();

            bool exists = queue.Exists();
            Assert.IsTrue(exists);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();

            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                string queueName = prefix + i;
                queueNames.Add(queueName);
                client.GetQueueReference(queueName).Create();
            }

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                QueueContinuationToken token = null;
                List<CloudQueue> results = new List<CloudQueue>();

                do
                {
                    IAsyncResult result = client.BeginListQueuesSegmented(token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueueResultSegment segment = client.EndListQueuesSegmented(result);
                    token = segment.ContinuationToken;
                    results.AddRange(segment.Results);
                }
                while (token != null);

                foreach (CloudQueue queue in results)
                {
                    if (queueNames.Remove(queue.Name))
                    {
                        client.GetQueueReference(queue.Name).Delete();
                    }
                }

                Assert.AreEqual(0, queueNames.Count);
            }
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefixAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                QueueContinuationToken token = null;
                List<CloudQueue> results = new List<CloudQueue>();
                do
                {
                    IAsyncResult result = client.BeginListQueuesSegmented(prefix, QueueListingDetails.None, null, token, null, null, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueueResultSegment segment = client.EndListQueuesSegmented(result);
                    results.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                }
                while (token != null);

                Assert.AreEqual<int>(0, results.Count);

                foreach (string name in queueNames)
                {
                    client.GetQueueReference(name).Create();
                }

                do
                {
                    IAsyncResult result = client.BeginListQueuesSegmented(prefix, QueueListingDetails.None, 10, token, null, null, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueueResultSegment segment = client.EndListQueuesSegmented(result);
                    results.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                }
                while (token != null);

                Assert.AreEqual<int>(results.Count, queueNames.Count);

                foreach (CloudQueue queue in results)
                {
                    if (queueNames.Remove(queue.Name))
                    {
                        queue.Delete();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

                Assert.AreEqual<int>(0, queueNames.Count);
            }
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefixAPMOverload()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                QueueContinuationToken token = null;
                List<CloudQueue> results = new List<CloudQueue>();
                do
                {
                    IAsyncResult result = client.BeginListQueuesSegmented(prefix, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueueResultSegment segment = client.EndListQueuesSegmented(result);
                    results.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                }
                while (token != null);

                Assert.AreEqual<int>(0, results.Count);

                foreach (string name in queueNames)
                {
                    client.GetQueueReference(name).Create();
                }

                do
                {
                    IAsyncResult result = client.BeginListQueuesSegmented(prefix, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueueResultSegment segment = client.EndListQueuesSegmented(result);
                    results.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                }
                while (token != null);

                Assert.AreEqual<int>(results.Count, queueNames.Count);

                foreach (CloudQueue queue in results)
                {
                    if (queueNames.Remove(queue.Name))
                    {
                        queue.Delete();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

                Assert.AreEqual<int>(0, queueNames.Count);
            }
        }

#if TASK
        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();

            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                string queueName = prefix + i;
                queueNames.Add(queueName);
                client.GetQueueReference(queueName).CreateAsync().Wait();
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmentedAsync(token).Result;
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    client.GetQueueReference(queue.Name).DeleteAsync().Wait();
                }
            }

            Assert.AreEqual(0, queueNames.Count);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefixTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();
            do
            {
                QueueResultSegment segment = client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, null, token, null, null).Result;
                results.AddRange(segment.Results);
                token = segment.ContinuationToken;
            }
            while (token != null);

            Assert.AreEqual<int>(0, results.Count);

            foreach (string name in queueNames)
            {
                client.GetQueueReference(name).CreateAsync().Wait();
            }

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, 10, token, null, null).Result;
                results.AddRange(segment.Results);
                token = segment.ContinuationToken;
            }
            while (token != null);

            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.DeleteAsync().Wait();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesSegmentedWithPrefixTaskOverload()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "dotnetqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();
            do
            {
                QueueResultSegment segment = client.ListQueuesSegmentedAsync(prefix, token).Result;
                results.AddRange(segment.Results);
                token = segment.ContinuationToken;
            }
            while (token != null);

            Assert.AreEqual<int>(0, results.Count);

            foreach (string name in queueNames)
            {
                client.GetQueueReference(name).CreateAsync().Wait();
            }

            do
            {
                QueueResultSegment segment = client.ListQueuesSegmentedAsync(prefix, token).Result;
                results.AddRange(segment.Results);
                token = segment.ContinuationToken;
            }
            while (token != null);

            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.DeleteAsync().Wait();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }
#endif
    }
}
