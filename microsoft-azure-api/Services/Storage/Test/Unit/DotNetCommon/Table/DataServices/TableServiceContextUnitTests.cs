// -----------------------------------------------------------------------------------------
// <copyright file="TableServiceContextUnitTests.cs" company="Microsoft">
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

using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using Microsoft.WindowsAzure.Storage.Table.DataServices.Entities;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
{
    /// <summary>
    /// Summary description for TableServiceContextUnitTests
    /// </summary>
    [TestClass]
    public class TableServiceContextUnitTests : TableTestBase
    {
        #region Ctors + Locals
        public TableServiceContextUnitTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        static CloudTable currentTable = null;
        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext){}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            currentTable = tableClient.GetTableReference(GenerateRandomTableName());
            currentTable.CreateIfNotExists();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            currentTable.DeleteIfExists();
        }
        #endregion

        #region RequestResults

        [TestMethod]
        [Description("TableServiceContext RequestResults - Verifies one Request Result is generated for each entity inserted using a non batch save changes.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextRequestResultsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            OperationContext opContext = new OperationContext();

            ctx.SaveChangesWithRetries(SaveChangesOptions.None, null, opContext);

            TestHelper.AssertNAttempts(opContext, 10);
        }

        [TestMethod]
        [Description("TableServiceContext RequestResults - Verifies one Request Result is generated for each entity inserted using a non batch save changes. APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextRequestResultsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            OperationContext opContext = new OperationContext();

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                ctx.BeginSaveChangesWithRetries(SaveChangesOptions.None, null, opContext,
                    (res) =>
                    {
                        ctx.EndSaveChangesWithRetries(res);
                        evt.Set();
                    }, null);
                evt.WaitOne();
            }

            TestHelper.AssertNAttempts(opContext, 10);
        }
        #endregion

        #region Send + Receive events

        [TestMethod]
        [Description("TableServiceContext OperationContextEvents - Verifies Send and Receive events for opcontext Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextOperationContextEvents()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            List<string> sends = new List<string>();
            List<string> receives = new List<string>();

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (sender, args) => sends.Add(args.RequestInformation.StartTime.Ticks.ToString());
            opContext.ResponseReceived += (sender, args) => receives.Add(args.RequestInformation.ServiceRequestID);

            ctx.SaveChangesWithRetries(SaveChangesOptions.None, null, opContext);

            TestHelper.AssertNAttempts(opContext, 10);

            Assert.AreEqual(sends.Count(), 10);
            Assert.AreEqual(receives.Count(), 10);
        }

        [TestMethod]
        [Description("TableServiceContext OperationContextEvents - Verifies Send and Receive events for opcontext APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextOperationContextEventsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            List<string> sends = new List<string>();
            List<string> receives = new List<string>();

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (sender, args) => sends.Add(args.RequestInformation.StartTime.Ticks.ToString());
            opContext.ResponseReceived += (sender, args) => receives.Add(args.RequestInformation.ServiceRequestID);

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                ctx.BeginSaveChangesWithRetries(SaveChangesOptions.None, null, opContext,
                    (res) =>
                    {
                        ctx.EndSaveChangesWithRetries(res);
                        evt.Set();
                    }, null);
                evt.WaitOne();
            }

            TestHelper.AssertNAttempts(opContext, 10);

            Assert.AreEqual(sends.Count(), 10);
            Assert.AreEqual(receives.Count(), 10);
        }
        #endregion

        #region Start + End Time

        [TestMethod]
        [Description("TableServiceContext OperationContext StartEndTime")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextOperationContextStartEndTime()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();
            DateTime start = DateTime.Now;
            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            OperationContext opContext = new OperationContext();
            ctx.SaveChangesWithRetries(SaveChangesOptions.None, null, opContext);

            Assert.IsNotNull(opContext.StartTime, "StartTime not set");
            Assert.IsTrue(opContext.StartTime >= start, "StartTime not set correctly");
            Assert.IsNotNull(opContext.EndTime, "EndTime not set");
            Assert.IsTrue(opContext.EndTime <= DateTime.Now, "EndTime not set correctly");
        }

        [TestMethod]
        [Description("TableServiceContext OperationContext StartEndTime APM ")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextOperationContextStartEndTimeAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            DateTime start = DateTime.Now;
            for (int m = 0; m < 10; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }


            OperationContext opContext = new OperationContext();
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                ctx.BeginSaveChangesWithRetries(SaveChangesOptions.None, null, opContext,
                    (res) =>
                    {
                        ctx.EndSaveChangesWithRetries(res);
                        evt.Set();
                    }, null);
                evt.WaitOne();
            }

            Assert.IsNotNull(opContext.StartTime, "StartTime not set");
            Assert.IsTrue(opContext.StartTime >= start, "StartTime not set correctly");
            Assert.IsNotNull(opContext.EndTime, "EndTime not set");
            Assert.IsTrue(opContext.EndTime <= DateTime.Now, "EndTime not set correctly");
        }
        #endregion

        #region ConcurrencyTests

        [TestMethod]
        [Description("TableServiceContext Concurrency Should allow only one in flight operation at any given time.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextConcurrencyAllowsOnlySingleOperationAtOnce()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext tableContext = tableClient.GetTableServiceContext();

            // insert entities to query against
            for (int i = 0; i < 5; i++)
            {
                for (int m = 0; m < 100; m++)
                {
                    BaseEntity ent = new BaseEntity("testpartition" + i, m.ToString());
                    ent.Randomize();
                    ent.A = ent.RowKey;
                    tableContext.AddObject(currentTable.Name, ent);
                }

                tableContext.SaveChangesWithRetries(SaveChangesOptions.Batch);
            }

            List<OperationContext> opContexts = new List<OperationContext>();
            object lockerObj = new object();
            DateTime start = DateTime.Now;

            int threadsRunning = 0;

            Exception lastEx = null;

            // Start 10 simultaneous threads to query entities associated with same context.
            for (int j = 0; j < 10; j++)
            {
                opContexts.Add(new OperationContext());
                Thread newThread = new Thread((arg) =>
                {
                    Interlocked.Increment(ref threadsRunning);
                    try
                    {
                        lock (lockerObj)
                        {
                            Monitor.Wait(lockerObj);
                        }

                        TableServiceQuery<BaseEntity> query = (from ent in tableContext.CreateQuery<BaseEntity>(currentTable.Name)
                                                               select ent).AsTableServiceQuery(tableContext);

                        Debug.WriteLine(String.Format("Thread {0} start operation @ {1}", Thread.CurrentThread.ManagedThreadId, (DateTime.Now - start).TotalMilliseconds));

                        try
                        {
                            query.Execute(null, arg as OperationContext).ToList();
                        }
                        catch (Exception)
                        {
                            // no op, expected to have some exceptions
                        }

                        Debug.WriteLine(String.Format("Thread {0} end operation @ {1}", Thread.CurrentThread.ManagedThreadId, (DateTime.Now - start).TotalMilliseconds));
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex;
                    }
                    finally
                    {
                        Interlocked.Decrement(ref threadsRunning);
                    }
                });

                newThread.Start(opContexts[j]);
            }

            // Wait for all threads to start
            while (Interlocked.CompareExchange(ref threadsRunning, 10, 10) < 10)
            {
                Thread.Sleep(200);
            }

            // pulse all threads
            lock (lockerObj)
            {
                Monitor.PulseAll(lockerObj);
            }

            // Wait for all threads to complete
            while (Interlocked.CompareExchange(ref threadsRunning, -1, 0) > -1)
            {
                Thread.Sleep(200);
            }

            if (lastEx != null)
            {
                throw lastEx;
            }

            foreach (OperationContext opContext in opContexts)
            {
                if (opContext.LastResult == null || opContext.LastResult.StartTime == null || opContext.LastResult.EndTime == null)
                    continue;

                TestHelper.AssertNAttempts(opContext, 1);

                RequestResult currRes = opContext.LastResult;

                // Make sure this results start time does not occur in between any other results start & end time
                var overlappingResults = (from ctx in opContexts
                                          where ctx.LastResult != null && ctx.LastResult != currRes &&
                                          ctx.LastResult.StartTime != null && ctx.LastResult.EndTime != null &&
                                          ctx.LastResult.StartTime.Ticks < currRes.StartTime.Ticks &&
                                          ctx.LastResult.EndTime.Ticks > currRes.StartTime.Ticks
                                          select ctx.LastResult);

                Assert.AreEqual(overlappingResults.Count(), 0, "Detected overlapping query");
            }
        }

        #endregion

        #region Timeout in save changes

        [TestMethod]
        [Description("TableServiceContext Ensure timeout is thrown during Save Changes with non batch. Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextTimeoutDuringSaveChangesNonBatchSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            OperationContext opContext = new OperationContext();
            TableRequestOptions requestOptions = new TableRequestOptions() { MaximumExecutionTime = TimeSpan.FromSeconds(5) };

            using (HttpMangler proxy = new HttpMangler(false,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).SkipNSessions(10)) }))
            {
                try
                {
                    ctx.SaveChangesWithRetries(SaveChangesOptions.None, requestOptions, opContext);
                }
                catch (StorageException ex)
                {
                    Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.RequestTimeout);
                    Assert.AreEqual("The client could not finish the operation within specified timeout.", ex.Message);
                    Assert.IsTrue(ex.InnerException is TimeoutException);
                }
            }
        }

        [TestMethod]
        [Description("TableServiceContext Ensure timeout is thrown during Save Changes with non batch. APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextTimeoutDuringSaveChangesNonBatchAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                BaseEntity ent = new BaseEntity("testpartition", m.ToString());
                ent.Randomize();
                ent.A = ent.RowKey;
                ctx.AddObject(currentTable.Name, ent);
            }

            OperationContext opContext = new OperationContext();
            TableRequestOptions requestOptions = new TableRequestOptions() { MaximumExecutionTime = TimeSpan.FromSeconds(5) };

            using (HttpMangler proxy = new HttpMangler(false,
                new[] { DelayBehaviors.DelayAllRequestsIf(2000, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).SkipNSessions(10)) }))
            {
                try
                {
                    using (ManualResetEvent evt = new ManualResetEvent(false))
                    {
                        IAsyncResult result = ctx.BeginSaveChangesWithRetries(SaveChangesOptions.None, requestOptions, opContext,
                            (res) =>
                            {
                                result = res;
                                evt.Set();
                            }, null);

                        evt.WaitOne();

                        ctx.EndSaveChangesWithRetries(result);
                    }

                    ctx.SaveChangesWithRetries(SaveChangesOptions.None, requestOptions, opContext);
                }
                catch (StorageException ex)
                {
                    Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.RequestTimeout);
                    Assert.AreEqual("The client could not finish the operation within specified timeout.", ex.Message);
                    Assert.IsTrue(ex.InnerException is TimeoutException);
                }
            }
        }
        #endregion
    }
}
