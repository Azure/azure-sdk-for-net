namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using TestResources;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    public class CloudCertificateIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public CloudCertificateIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public async Task LongRunning_Bug1770943_1770945_1771076_1771170_CertificateCRUD()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    //Generate the certificates
                    const string certificatePrefix = "longrunningcerttest";

                    string cerFilePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));
                    string pfxFilePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", certificatePrefix));

                    CertificateBuilder.CreateSelfSignedInFile("Foo", cerFilePath);
                    CertificateBuilder.CreateSelfSignedInFile("Foo", pfxFilePath, CommonResources.CertificatePassword);

                    Dictionary<string, Certificate> localCerts = new Dictionary<string, Certificate>();
                    Dictionary<string, CertificateReference> certRefs = new Dictionary<string, CertificateReference>();
                    try
                    {
                        // get local certs for testing
                        localCerts.Add(cerFilePath, batchCli.CertificateOperations.CreateCertificate(cerFilePath));
                        localCerts.Add(pfxFilePath, batchCli.CertificateOperations.CreateCertificate(pfxFilePath, CommonResources.CertificatePassword));

                        // test raw data constructors
                        {
                            Certificate certReference = localCerts[cerFilePath];
                            Certificate pfxReference = localCerts[pfxFilePath];

                            // Create an Azure Batch Certificate object from .cer
                            {
                                X509Certificate2 cerX509 = new X509Certificate2(cerFilePath);
                                byte[] cerBytes = cerX509.Export(X509ContentType.Cert);

                                Certificate cerRaw = batchCli.CertificateOperations.CreateCertificate(cerBytes);

                                // confirm the certs are the same
                                Assert.Equal(cerRaw.Thumbprint, certReference.Thumbprint);
                            }

                            // Create an Azure Batch Certificate object from .pfx
                            {
                                X509Certificate2 pfxX509 = new X509Certificate2(pfxFilePath, CommonResources.CertificatePassword);
                                byte[] pfxBytes = pfxX509.Export(X509ContentType.Cert, CommonResources.CertificatePassword);

                                Certificate pfxRaw = batchCli.CertificateOperations.CreateCertificate(pfxBytes, CommonResources.CertificatePassword);

                                // confirm the cets are the same
                                Assert.Equal(pfxRaw.Thumbprint, pfxReference.Thumbprint);
                            }
                        }

                        // build cert refs and ensure certs are installed
                        foreach (string curKey in localCerts.Keys)
                        {
                            Certificate certLocal = localCerts[curKey];

                            // if cert is not yet installed, add it
                            bool mustAddCert = true;

                            foreach (Certificate curAccountCert in batchCli.CertificateOperations.ListCertificates())
                            {
                                // if we find the cert, we do not need to add it.
                                if (curAccountCert.ThumbprintAlgorithm.Equals(certLocal.ThumbprintAlgorithm,
                                        StringComparison.InvariantCultureIgnoreCase) &&
                                    curAccountCert.Thumbprint.Equals(certLocal.Thumbprint,
                                        StringComparison.InvariantCultureIgnoreCase))
                                {
                                    // dont add the cert... it is already added
                                    mustAddCert = false;

                                    break;
                                }
                            }

                            if (mustAddCert)
                            {
                                this.testOutputHelper.WriteLine("Adding certificate with thumbprint: {0}", certLocal.Thumbprint);
                                await certLocal.CommitAsync().ConfigureAwait(false);
                            }

                            // test GetCert (from server)
                            this.testOutputHelper.WriteLine("Testing protocol GetCertAsync");

                            Certificate boundCert = await batchCli.CertificateOperations.GetCertificateAsync(
                                certLocal.ThumbprintAlgorithm,
                                certLocal.Thumbprint).ConfigureAwait(false);

                            Assert.Equal(certLocal.Thumbprint, boundCert.Thumbprint);
                            Assert.Equal(certLocal.ThumbprintAlgorithm, boundCert.ThumbprintAlgorithm);
                            
                            this.testOutputHelper.WriteLine("Testing ICert.GetCert + lower detail level");

                            //
                            // test reduced detail level
                            //

                            // this should be there because we will set detail level to remove it
                            Assert.NotNull(boundCert.Url);

                            Certificate certLowerDetail = await batchCli.CertificateOperations.GetCertificateAsync(
                                certLocal.ThumbprintAlgorithm,
                                certLocal.Thumbprint,
                                new ODATADetailLevel() { SelectClause = "thumbprint, thumbprintAlgorithm" }).ConfigureAwait(false);

                            // confirm lower detail level
                            Assert.Null(certLowerDetail.Url);

                            this.testOutputHelper.WriteLine("Testing that refresh can elevate to full detail level.");

                            //test refresh to higher detail level
                            await certLowerDetail.RefreshAsync();

                            // confirm higher detail level
                            Assert.NotNull(certLowerDetail.Url);

                            this.testOutputHelper.WriteLine("Testing that refresh can lower detail level.");

                            // test refresh can lower detail level
                            await certLowerDetail.RefreshAsync(new ODATADetailLevel() { SelectClause = "thumbprint, thumbprintAlgorithm" });

                            // confirm lower detail level via refresh
                            Assert.Null(certLowerDetail.Url);
                            
                            // now construct the cert ref
                            CertificateReference cref = new CertificateReference(certLocal);

                            cref.StoreLocation = CertStoreLocation.LocalMachine;
                            cref.StoreName = "My";
                            cref.Visibility = CertificateVisibility.RemoteUser;

                            certRefs.Add(curKey, cref);
                        }
                        
                        List<Task> runningTests = new List<Task>();

                        // start autopool test
                        Task asyncAutoPoolTest =
                            Bug1770943_1770945_1771076_1771170_CertificateCRUD_LongRunning_AutoPoolTest(batchCli,
                                certRefs.Values.ToList());

                        // we'll wait on these later
                        runningTests.Add(asyncAutoPoolTest);

                        Task asyncPoolTest =
                            Bug1770943_1770945_1771076_1771170_CertificateCRUD_LongRunning_PoolTest(batchCli,
                                certRefs.Values.ToList());

                        runningTests.Add(asyncPoolTest);

                        // wait for these tests because the compute node test deletes a cert...
                        await Task.WhenAll(runningTests).ConfigureAwait(false);

                        // pick a cert to delete
                        Certificate certToDelete = localCerts[cerFilePath];

                        // run the test to confirm the compute node gets cert refs AND CancelDeleteCert
                        await LongRunning_Bug1770943_1770945_1771076_1771170_CertificateCRUD_ComputeNodeTest_CancelDeleteCert(
                            batchCli,
                            certRefs.Values.ToList(),
                            certToDelete).ConfigureAwait(false);
                    }
                    finally
                    {
                        File.Delete(pfxFilePath);
                        File.Delete(cerFilePath);

                        TestUtilities.DeleteCertificateIfExistsAsync(batchCli, localCerts[cerFilePath].ThumbprintAlgorithm, localCerts[cerFilePath].Thumbprint).Wait();
                        TestUtilities.DeleteCertificateIfExistsAsync(batchCli, localCerts[pfxFilePath].ThumbprintAlgorithm, localCerts[pfxFilePath].Thumbprint).Wait();

                        //Wait for the certificates to be deleted
                        TestUtilities.DeleteCertMonitor(batchCli.CertificateOperations, this.testOutputHelper, localCerts[cerFilePath].ThumbprintAlgorithm, localCerts[cerFilePath].Thumbprint);
                        TestUtilities.DeleteCertMonitor(batchCli.CertificateOperations, this.testOutputHelper, localCerts[pfxFilePath].ThumbprintAlgorithm, localCerts[pfxFilePath].Thumbprint);
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }

        #region Test helpers

        private static bool CertRefCollectionsMustBeEqualDeepDeepDeep(IEnumerable<CertificateReference> refsA, IEnumerable<CertificateReference> refsB)
        {
            Assert.Equal(refsA.Count(), refsB.Count());   // ok linc doesnt completely suck always

            foreach (CertificateReference curA in refsA)
            {
                foreach (CertificateReference curB in refsB)
                {
                    if (curA.StoreLocation == curB.StoreLocation)
                    {
                        if (curA.StoreName.Equals(curB.StoreName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (curA.Thumbprint.Equals(curB.Thumbprint, StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (curA.ThumbprintAlgorithm.Equals(curB.ThumbprintAlgorithm, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (curA.Visibility == curB.Visibility)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private async System.Threading.Tasks.Task Bug1770943_1770945_1771076_1771170_CertificateCRUD_LongRunning_PoolTest(
            BatchClient batchCli,
            IList<CertificateReference> certRefs)
        {

            PoolOperations poolOperations = batchCli.PoolOperations;

            // cache because props cannot be read after commit
            string unboundPoolId = "Bug1770943_LongRunning_PoolTest-" + TestUtilities.GetMyName();

            try
            {
                // create a pool with initial cert refs
                CloudPool boundPool = null;

                {
                    CloudPool unboundPool = poolOperations.CreatePool();

                    unboundPool.Id = unboundPoolId;

                    unboundPool.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);

                    unboundPool.VirtualMachineSize = PoolFixture.VMSize;
                    unboundPool.TargetDedicated = 0;

                    // create the pool with initial cert refs
                    unboundPool.CertificateReferences = certRefs;

                    await unboundPool.CommitAsync().ConfigureAwait(false);

                    System.Threading.Tasks.Task<CloudPool> asyncGetPool = poolOperations.GetPoolAsync(unboundPoolId);

                    await asyncGetPool.ConfigureAwait(false);

                    boundPool = asyncGetPool.Result;

                    // confirm the refs are there
                    Assert.NotNull(boundPool.CertificateReferences);
                    Assert.True(CertRefCollectionsMustBeEqualDeepDeepDeep(certRefs, boundPool.CertificateReferences));
                }

                // mutate the cert refs: assign only one
                {
                    List<CertificateReference> listOfOne = new List<CertificateReference>();

                    // just pick one cert
                    listOfOne.Add(certRefs.ToArray()[1]);

                    boundPool.CertificateReferences = listOfOne;

                    await boundPool.CommitAsync().ConfigureAwait(false);
                    await boundPool.RefreshAsync().ConfigureAwait(false);

                    // confirm that the ref collection is correct
                    Assert.True(CertRefCollectionsMustBeEqualDeepDeepDeep(listOfOne, boundPool.CertificateReferences));
                }

                // mutate the pool cert refs: assign null to clear
                {
                    boundPool.CertificateReferences = null;

                    await boundPool.CommitAsync().ConfigureAwait(false);

                    await boundPool.RefreshAsync().ConfigureAwait(false);

                    Assert.Null(boundPool.CertificateReferences);
                }
            }
            catch (Exception e)
            {
                //Because a lot of the certificate exceptions use the Key-Value part of the BatchException, print that
                this.testOutputHelper.WriteLine(e.ToString());
            }
            finally
            {
                // cleanup
                TestUtilities.DeletePoolIfExistsAsync(batchCli, unboundPoolId).Wait();
            }
        }
        
        private static async System.Threading.Tasks.Task Bug1770943_1770945_1771076_1771170_CertificateCRUD_LongRunning_AutoPoolTest(
            BatchClient batchCli,
            IList<CertificateReference> certRefs)
        {
            string jobId = "Bug1770943CertificateCRUD_LongRun_AutoPoolTest-" + TestUtilities.GetMyName();

            try
            {
                // set cert refs on autopoolspec
                CloudJob boundJob = null; // used across tests

                {
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    AutoPoolSpecification aps = new AutoPoolSpecification();
                    PoolSpecification pus = new PoolSpecification();

                    // set the cert refs on the auto pool
                    pus.CertificateReferences = certRefs;

                    pus.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);
                    pus.TargetDedicated = 0;
                    pus.VirtualMachineSize = PoolFixture.VMSize;

                    aps.AutoPoolIdPrefix = TestUtilities.GetMyName();
                    aps.PoolLifetimeOption = PoolLifetimeOption.Job;

                    aps.PoolSpecification = pus;
                    unboundJob.PoolInformation.AutoPoolSpecification = aps;

                    await unboundJob.CommitAsync().ConfigureAwait(false);

                    // start get job
                    System.Threading.Tasks.Task<CloudJob> asyncGetJob = batchCli.JobOperations.GetJobAsync(jobId);

                    // await for completion
                    await asyncGetJob.ConfigureAwait(false);

                    // extract result
                    boundJob = asyncGetJob.Result;

                    Assert.NotNull(boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences);

                    List<CertificateReference> boundRefs = boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences.ToList();

                    Assert.True(CertRefCollectionsMustBeEqualDeepDeepDeep(boundRefs, certRefs));
                }
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
            }
        }

        private async System.Threading.Tasks.Task LongRunning_Bug1770943_1770945_1771076_1771170_CertificateCRUD_ComputeNodeTest_CancelDeleteCert(
            BatchClient batchCli,
            IList<CertificateReference> certRefs,
            Certificate certToDelete)
        {
            CloudPool boundPool = null;

            try
            {
                // create a pool with initial cert refs
                {
                    CloudPool unboundPool = batchCli.PoolOperations.CreatePool();

                    string unboundPoolId = "Bug1770943_ComputeNodeTest_CancelDeleteCert-" + TestUtilities.GetMyName();
                    unboundPool.Id = unboundPoolId;

                    unboundPool.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);

                    unboundPool.VirtualMachineSize = PoolFixture.VMSize;
                    unboundPool.TargetDedicated = 1;

                    // create the pool with initial cert reffs
                    unboundPool.CertificateReferences = certRefs;

                    await unboundPool.CommitAsync().ConfigureAwait(false);

                    Task<CloudPool> asyncGetPool = batchCli.PoolOperations.GetPoolAsync(unboundPoolId);

                    await asyncGetPool.ConfigureAwait(false);

                    boundPool = asyncGetPool.Result;

                    // confirm the refs are there
                    Assert.NotNull(boundPool.CertificateReferences);
                    Assert.True(CertRefCollectionsMustBeEqualDeepDeepDeep(certRefs, boundPool.CertificateReferences));
                }

                List<ComputeNode> computeNodes = new List<ComputeNode>();

                // monitor/wait till a compute node can be listed... then check its cert refs
                while (computeNodes.Count <= 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

                    computeNodes = new List<ComputeNode>(boundPool.ListComputeNodes());

                    this.testOutputHelper.WriteLine("Bug1770943_LongRunning_PoolTest # of compute nodes: " + computeNodes.Count());
                }

                // confirm the correct pool size
                Assert.Equal(1, computeNodes.Count());

                ComputeNode computeNodePickMe = computeNodes[0]; // should only be 1

                // wait for compute node to have cert refs (active)
                while (computeNodePickMe.State != ComputeNodeState.Idle)
                {
                    this.testOutputHelper.WriteLine("Bug1770943_LongRunning_PoolTest computeNode.Id: " + computeNodePickMe.Id +
                                        ", state: " + computeNodePickMe.State);

                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

                    await computeNodePickMe.RefreshAsync().ConfigureAwait(false);
                }

                // confirm the compute node has the required cert refs
                Assert.NotNull(computeNodePickMe.CertificateReferences);
                Assert.True(CertRefCollectionsMustBeEqualDeepDeepDeep(certRefs, computeNodePickMe.CertificateReferences));

                // test cert-ref on compute node is read-only
                {
                    CertificateReference computeNodeCertificateReference = computeNodePickMe.CertificateReferences.ToList()[0];

                    // reads are allowed
                    this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.StoreLocation);
                    this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.StoreName);
                    this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.Thumbprint);
                    this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.ThumbprintAlgorithm);
                    this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.Visibility);

                    // writes are foribdden
                    TestUtilities.AssertThrows<InvalidOperationException>(
                        () => { computeNodeCertificateReference.StoreLocation = CertStoreLocation.CurrentUser; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNodeCertificateReference.StoreName = "x"; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNodeCertificateReference.Thumbprint = "y"; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNodeCertificateReference.ThumbprintAlgorithm = "z"; });
                    TestUtilities.AssertThrows<InvalidOperationException>(
                        () => { computeNodeCertificateReference.Visibility = CertificateVisibility.None; });
                }

                // test ICertificateManager.Delete/CancelDelete
                {
                    batchCli.CertificateOperations.DeleteCertificate(certToDelete.ThumbprintAlgorithm, certToDelete.Thumbprint);
                    // sync calls async so call that

                    // get fresh state
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // ok, it should be deleting
                    Assert.Equal(CertificateState.Deleting, certToDelete.State);

                    // now we wait for delete failed
                    while (CertificateState.DeleteFailed != certToDelete.State)
                    {
                        this.testOutputHelper.WriteLine(
                            "A: Bug1770943_LongRunning_PoolTest waiting for cert delete to fail.  thumb: " +
                            certToDelete.Thumbprint + ", state: " + certToDelete.State);

                        await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

                        await certToDelete.RefreshAsync().ConfigureAwait(false);
                    }

                    // test CertificateManger.CancelDelete.  now the delete failed, we can cancel it
                    batchCli.CertificateOperations.CancelDeleteCertificate(certToDelete.ThumbprintAlgorithm, certToDelete.Thumbprint);

                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false); // gift to server to get going on that cancel.

                    // get fresh state
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // cert is now ok
                    Assert.Equal(CertificateState.Active, certToDelete.State);
                }

                // test Certificate.Delete/CancelDelete
                {
                    await certToDelete.DeleteAsync().ConfigureAwait(false);

                    // get fresh state
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // ok, it should be deleting
                    Assert.Equal(CertificateState.Deleting, certToDelete.State);

                    // now we wait for delete failed
                    while (CertificateState.DeleteFailed != certToDelete.State)
                    {
                        this.testOutputHelper.WriteLine(
                            "B: Bug1770943_LongRunning_PoolTest waiting for cert delete to fail.  thumb: " +
                            certToDelete.Thumbprint + ", state: " + certToDelete.State);
                        await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

                        await certToDelete.RefreshAsync().ConfigureAwait(false);
                    }

                    // test Certificate.CancelDelete.  now the delete failed, we can cancel it
                    await certToDelete.CancelDeleteAsync().ConfigureAwait(false);

                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

                    // get fresh state
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // cert is now ok
                    Assert.Equal(CertificateState.Active, certToDelete.State);
                }
            }
            finally
            {
                // cleanup
                if (null != boundPool)
                {
                    boundPool.Delete();
                }
            }
        }

        #endregion

    }
}
