// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobDirectoryTest.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

    [TestClass]
    public class CloudBlobDirectoryTest : BlobTestBase
    {
        string[] Delimiters = new string[] {"$", "@", "-", "%", "/", "|"};

        private bool CloudBlobDirectorySetupWithDelimiter(CloudBlobContainer container, string delimiter = "/")
        {
            try
            {
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        for (int k = 1; k < 3; k++)
                        {
                            String directory = "TopDir" + i + delimiter + "MidDir" + j + delimiter + "EndDir" + k + delimiter + "EndBlob" + k;
                            CloudPageBlob blob1 = container.GetPageBlobReference(directory);
                            blob1.Create(0);
                        }
                    }

                    CloudPageBlob blob2 = container.GetPageBlobReference("TopDir" + i + delimiter + "Blob" + i);
                    blob2.Create(0);
                }

                return true;
            }
            catch (StorageException)
            {
                throw;
            }
        }

        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        [Description("CloudBlobDirectory get parent of Blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryGetParent()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);
                try
                {
                    container.Create();
                    CloudPageBlob blob = container.GetPageBlobReference("Dir1" + delimiter + "Blob1");
                    blob.Create(0);
                    Assert.IsTrue(blob.Exists());
                    Assert.AreEqual("Dir1" + delimiter + "Blob1", blob.Name);
                    CloudBlobDirectory parent = blob.Parent;
                    Assert.AreEqual(parent.Prefix, "Dir1" + delimiter);
                    blob.Delete();
                }

                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobDirectory flat-listing and non flat-listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryFlatListing()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    container.Create();
                    if (CloudBlobDirectorySetupWithDelimiter(container, delimiter))
                    {
                        IEnumerable<IListBlobItem> list1 = container.ListBlobs("TopDir1" + delimiter, false, BlobListingDetails.None, null, null);

                        List<IListBlobItem> simpleList1 = list1.ToList();
                        ////Check if for 3 because if there were more than 3, the previous assert would have failed.
                        ////So the only thing we need to make sure is that it is not less than 3. 
                        Assert.IsTrue(simpleList1.Count == 3);

                        IListBlobItem item11 = simpleList1.ElementAt(0);
                        Assert.IsTrue(item11.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "Blob1"));

                        IListBlobItem item12 = simpleList1.ElementAt(1);
                        Assert.IsTrue(item12.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter));

                        IListBlobItem item13 = simpleList1.ElementAt(2);
                        Assert.IsTrue(item13.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter));
                        CloudBlobDirectory midDir2 = (CloudBlobDirectory)item13;

                        IEnumerable<IListBlobItem> list2 = container.ListBlobs("TopDir1" + delimiter + "MidDir1", true, BlobListingDetails.None, null, null);

                        List<IListBlobItem> simpleList2 = list2.ToList();
                        Assert.IsTrue(simpleList2.Count == 2);

                        IListBlobItem item21 = simpleList2.ElementAt(0);
                        Assert.IsTrue(item21.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter + "EndBlob1"));

                        IListBlobItem item22 = simpleList2.ElementAt(1);
                        Assert.IsTrue(item22.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir2" + delimiter + "EndBlob2"));

                        IEnumerable<IListBlobItem> list3 = container.ListBlobs("TopDir1" + delimiter + "MidDir1" + delimiter, false, BlobListingDetails.None, null, null);

                        List<IListBlobItem> simpleList3 = list3.ToList();
                        Assert.IsTrue(simpleList3.Count == 2);

                        IListBlobItem item31 = simpleList3.ElementAt(0);
                        Assert.IsTrue(item31.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter));

                        IListBlobItem item32 = simpleList3.ElementAt(1);
                        Assert.IsTrue(item32.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir2" + delimiter));

                        IEnumerable<IListBlobItem> list4 = midDir2.ListBlobs(true);

                        List<IListBlobItem> simpleList4 = list4.ToList();
                        Assert.IsTrue(simpleList4.Count == 2);

                        IListBlobItem item41 = simpleList4.ElementAt(0);
                        Assert.IsTrue(item41.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir1" + delimiter + "EndBlob1"));

                        IListBlobItem item42 = simpleList4.ElementAt(1);
                        Assert.IsTrue(item42.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir2" + delimiter + "EndBlob2"));
                    }
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("CloudBlobDirectory flat-listing and non flat-listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryFlatListingAPM()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    container.Create();
                    if (CloudBlobDirectorySetupWithDelimiter(container, delimiter))
                    {
                        using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                        {
                            IAsyncResult result;
                            BlobContinuationToken token = null;
                            CloudBlobDirectory directory = container.GetDirectoryReference("TopDir1");
                            List<IListBlobItem> list1 = new List<IListBlobItem>();
                            do
                            {
                                result = directory.BeginListBlobsSegmented(token, ar => waitHandle.Set(), null);
                                waitHandle.WaitOne();
                                BlobResultSegment result1 = directory.EndListBlobsSegmented(result);
                                list1.AddRange(result1.Results);
                                token = result1.ContinuationToken;
                            }
                            while(token!=null);

                            Assert.IsTrue(list1.Count == 3);

                            IListBlobItem item11 = list1.ElementAt(0);
                            Assert.IsTrue(item11.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "Blob1"));

                            IListBlobItem item12 = list1.ElementAt(1);
                            Assert.IsTrue(item12.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter));

                            IListBlobItem item13 = list1.ElementAt(2);
                            Assert.IsTrue(item13.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter));

                            CloudBlobDirectory midDir2 = (CloudBlobDirectory)item13;

                            List<IListBlobItem> list2 = new List<IListBlobItem>();
                            do
                            {
                                result = midDir2.BeginListBlobsSegmented(true, BlobListingDetails.None, null, token, null, null, ar => waitHandle.Set(), null);
                                waitHandle.WaitOne();
                                BlobResultSegment result2 = midDir2.EndListBlobsSegmented(result);
                                list2.AddRange(result2.Results);
                                token = result2.ContinuationToken;
                            }
                            while (token != null);

                            Assert.IsTrue(list2.Count == 2);

                            IListBlobItem item41 = list2.ElementAt(0);
                            Assert.IsTrue(item41.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir1" + delimiter + "EndBlob1"));

                            IListBlobItem item42 = list2.ElementAt(1);
                            Assert.IsTrue(item42.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir2" + delimiter + "EndBlob2"));                 
                        }
                    }
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

#if TASK
        [TestMethod]
        [Description("CloudBlobDirectory flat-listing and non flat-listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryFlatListingTask()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    container.CreateAsync().Wait();
                    if (CloudBlobDirectorySetupWithDelimiter(container, delimiter))
                    {
                        BlobContinuationToken token = null;
                        CloudBlobDirectory directory = container.GetDirectoryReference("TopDir1");
                        List<IListBlobItem> list1 = new List<IListBlobItem>();
                        do
                        {
                            BlobResultSegment result1 = directory.ListBlobsSegmentedAsync(token).Result;
                            list1.AddRange(result1.Results);
                            token = result1.ContinuationToken;
                        }
                        while (token != null);

                        Assert.IsTrue(list1.Count == 3);

                        IListBlobItem item11 = list1.ElementAt(0);
                        Assert.IsTrue(item11.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "Blob1"));

                        IListBlobItem item12 = list1.ElementAt(1);
                        Assert.IsTrue(item12.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter));

                        IListBlobItem item13 = list1.ElementAt(2);
                        Assert.IsTrue(item13.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter));

                        CloudBlobDirectory midDir2 = (CloudBlobDirectory)item13;

                        List<IListBlobItem> list2 = new List<IListBlobItem>();
                        do
                        {
                            BlobResultSegment result2 = midDir2.ListBlobsSegmentedAsync(true, BlobListingDetails.None, null, token, null, null).Result;
                            list2.AddRange(result2.Results);
                            token = result2.ContinuationToken;
                        }
                        while (token != null);

                        Assert.IsTrue(list2.Count == 2);

                        IListBlobItem item41 = list2.ElementAt(0);
                        Assert.IsTrue(item41.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir1" + delimiter + "EndBlob1"));

                        IListBlobItem item42 = list2.ElementAt(1);
                        Assert.IsTrue(item42.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir2" + delimiter + "EndBlob2"));
                    }
                }
                finally
                {
                    container.DeleteIfExistsAsync().Wait();
                }
            }
        }
#endif

        [TestMethod]
        [Description("CloudBlobDirectory flat-listing and non flat-listing")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryFlatListingWithPrefix()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    container.Create();
                    if (CloudBlobDirectorySetupWithDelimiter(container, delimiter))
                    {
                        BlobContinuationToken token = null;
                        CloudBlobDirectory directory = container.GetDirectoryReference("TopDir1");
                        List<IListBlobItem> list1 = new List<IListBlobItem>();
                        do
                        {
                            BlobResultSegment result1 = directory.ListBlobsSegmented(token);
                            token = result1.ContinuationToken;
                            list1.AddRange(result1.Results);
                        } 
                        while (token != null);

                        Assert.IsTrue(list1.Count == 3);

                        IListBlobItem item11 = list1.ElementAt(0);
                        Assert.IsTrue(item11.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "Blob1"));

                        IListBlobItem item12 = list1.ElementAt(1);
                        Assert.IsTrue(item12.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter));

                        IListBlobItem item13 = list1.ElementAt(2);
                        Assert.IsTrue(item13.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter));

                        CloudBlobDirectory midDir2 = (CloudBlobDirectory)item13;

                        List<IListBlobItem> list2 = new List<IListBlobItem>();
                        do
                        {
                            BlobResultSegment result2 = midDir2.ListBlobsSegmented(true, BlobListingDetails.None, null, token, null, null);
                            token = result2.ContinuationToken;
                            list2.AddRange(result2.Results);
                        } 
                        while (token != null);

                        Assert.IsTrue(list2.Count == 2);

                        IListBlobItem item41 = list2.ElementAt(0);
                        Assert.IsTrue(item41.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir1" + delimiter + "EndBlob1"));

                        IListBlobItem item42 = list2.ElementAt(1);
                        Assert.IsTrue(item42.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter + "EndDir2" + delimiter + "EndBlob2"));
                    }
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Get subdirectory and then traverse back to parent")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryGetSubdirectoryAndTraverseBackToParent()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    CloudBlobDirectory directory = container.GetDirectoryReference("TopDir1" + delimiter);
                    CloudBlobDirectory subDirectory = directory.GetSubdirectoryReference("MidDir1" + delimiter);
                    CloudBlobDirectory parent = subDirectory.Parent;
                    Assert.AreEqual(parent.Prefix, directory.Prefix);
                    Assert.AreEqual(parent.Uri, directory.Uri);
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Get parent on root")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryGetParentOnRoot()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    CloudBlobDirectory root = container.GetDirectoryReference("TopDir1" + delimiter);
                    CloudBlobDirectory parent = root.Parent;
                    Assert.IsNull(parent);
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Check multiple delimiters")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryMultipleDelimiters()
        {
            foreach (String delimiter in Delimiters)
            {

                CloudBlobClient client = GenerateCloudBlobClient();
                ////Set the default delimiter to \
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);
                try
                {
                    container.Create();
                    if (CloudBlobDirectorySetupWithDelimiter(container, delimiter))
                    {
                        IEnumerable<IListBlobItem> list1 = container.ListBlobs("TopDir1" + delimiter, false, BlobListingDetails.None, null, null);

                        List<IListBlobItem> simpleList1 = list1.ToList();
                        ////Check if for 3 because if there were more than 3, the previous assert would have failed.
                        ////So the only thing we need to make sure is that it is not less than 3. 
                        Assert.IsTrue(simpleList1.Count == 3);

                        IListBlobItem item11 = simpleList1.ElementAt(0);
                        Assert.IsTrue(item11.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "Blob1"));

                        IListBlobItem item12 = simpleList1.ElementAt(1);
                        Assert.IsTrue(item12.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter));

                        IListBlobItem item13 = simpleList1.ElementAt(2);
                        Assert.IsTrue(item13.Uri.Equals(container.Uri + "/TopDir1" + delimiter + "MidDir2" + delimiter));

                        CloudBlobDirectory directory = container.GetDirectoryReference("TopDir1" + delimiter);
                        CloudBlobDirectory subDirectory = directory.GetSubdirectoryReference("MidDir1" + delimiter);
                        CloudBlobDirectory parent = subDirectory.Parent;
                        Assert.AreEqual(parent.Prefix, directory.Prefix);
                        Assert.AreEqual(parent.Uri, directory.Uri);
                    }
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Hierarchical traversal")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryHierarchicalTraversal()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    ////Traverse hierarchically starting with length 1
                    CloudBlobDirectory directory1 = container.GetDirectoryReference("Dir1" + delimiter);
                    CloudBlobDirectory subdir1 = directory1.GetSubdirectoryReference("Dir2");
                    CloudBlobDirectory parent1 = subdir1.Parent;
                    Assert.AreEqual(parent1.Prefix, directory1.Prefix);

                    CloudBlobDirectory subdir2 = subdir1.GetSubdirectoryReference("Dir3");
                    CloudBlobDirectory parent2 = subdir2.Parent;
                    Assert.AreEqual(parent2.Prefix, subdir1.Prefix);

                    CloudBlobDirectory subdir3 = subdir2.GetSubdirectoryReference("Dir4");
                    CloudBlobDirectory parent3 = subdir3.Parent;
                    Assert.AreEqual(parent3.Prefix, subdir2.Prefix);

                    CloudBlobDirectory subdir4 = subdir3.GetSubdirectoryReference("Dir5");
                    CloudBlobDirectory parent4 = subdir4.Parent;
                    Assert.AreEqual(parent4.Prefix, subdir3.Prefix);
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Get directory parent for blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryBlobParentValidate()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);
                try
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter + "EndBlob1");
                    CloudBlobDirectory directory = blob.Parent;
                    Assert.AreEqual(directory.Prefix, "TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter);
                    Assert.AreEqual(directory.Uri, container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter);
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Validate CloudBlobDirectory in root container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryValidateInRootContainer()
        {
            foreach (String delimiter in Delimiters)
            {

                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                CloudBlobContainer container = client.GetContainerReference("$root");

                CloudPageBlob pageBlob = container.GetPageBlobReference("Dir1" + delimiter + "Blob1");
                if (delimiter == "/")
                {
                    TestHelper.ExpectedException(
                        () => pageBlob.Create(0),
                        "Try to create a CloudBlobDirectory/blob which has a slash in its name in the root container",
                        HttpStatusCode.BadRequest);
                }

                else
                {
                    CloudPageBlob blob = container.GetPageBlobReference("TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter + "EndBlob1");
                    CloudBlobDirectory directory = blob.Parent;
                    Assert.AreEqual(directory.Prefix, "TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter);
                    Assert.AreEqual(directory.Uri, container.Uri + "/TopDir1" + delimiter + "MidDir1" + delimiter + "EndDir1" + delimiter);

                    CloudBlobDirectory directory1 = container.GetDirectoryReference("TopDir1" + delimiter);
                    CloudBlobDirectory subdir1 = directory1.GetSubdirectoryReference("MidDir" + delimiter);
                    CloudBlobDirectory parent1 = subdir1.Parent;
                    Assert.AreEqual(parent1.Prefix, directory1.Prefix);
                    Assert.AreEqual(parent1.Uri, directory1.Uri);

                    CloudBlobDirectory subdir2 = subdir1.GetSubdirectoryReference("EndDir" + delimiter);
                    CloudBlobDirectory parent2 = subdir2.Parent;
                    Assert.AreEqual(parent2.Prefix, subdir1.Prefix);
                    Assert.AreEqual(parent2.Uri, subdir1.Uri);
                }
            }
        }

        [TestMethod]
        [Description("Multiple delimiters in a row or empty directory names")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobDirectoryDelimitersInARow()
        {
            foreach (String delimiter in Delimiters)
            {
                CloudBlobClient client = GenerateCloudBlobClient();
                client.DefaultDelimiter = delimiter;
                string name = GetRandomContainerName();
                CloudBlobContainer container = client.GetContainerReference(name);

                try
                {
                    CloudPageBlob blob = container.GetPageBlobReference(delimiter+delimiter+delimiter+"Blob1");

                    ////Traverse from leaf to root
                    CloudBlobDirectory directory1 = blob.Parent;
                    Assert.AreEqual(directory1.Prefix, delimiter+delimiter+delimiter);

                    CloudBlobDirectory directory2 = directory1.Parent;
                    Assert.AreEqual(directory2.Prefix, delimiter+delimiter);

                    CloudBlobDirectory directory3 = directory2.Parent;
                    Assert.AreEqual(directory3.Prefix, delimiter);

                    ////Traverse from root to leaf
                    CloudBlobDirectory directory4 = container.GetDirectoryReference(delimiter);
                    CloudBlobDirectory directory5 = directory4.GetSubdirectoryReference(delimiter);
                    Assert.AreEqual(directory5.Prefix, delimiter+delimiter);

                    CloudBlobDirectory directory6 = directory5.GetSubdirectoryReference(delimiter);
                    Assert.AreEqual(directory6.Prefix, delimiter+delimiter+delimiter);

                    CloudPageBlob blob2 = directory6.GetPageBlobReference("Blob1");
                    Assert.AreEqual(blob2.Name, delimiter+delimiter+delimiter+"Blob1");
                    Assert.AreEqual(blob2.Uri, blob.Uri);
                }
                finally
                {
                    container.DeleteIfExists();
                }
            }
        }


    }
}

