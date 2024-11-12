// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using IntegrationTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    public class CloudCertificateIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(6);

        public CloudCertificateIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        [Obsolete]
        public async Task TestCertificateVerbs()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                //Generate the certificates
                const string certificatePrefix = "testcertificatecrud";

                string cerFilePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));
                string pfxFilePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", certificatePrefix));

                IEnumerable<Certificate> certificates = GenerateCertificates(batchCli, cerFilePath, pfxFilePath);

                try
                {
                    foreach (Certificate certificate in certificates)
                    {
                        testOutputHelper.WriteLine("Adding certificate with thumbprint: {0}", certificate.Thumbprint);
                        await certificate.CommitAsync().ConfigureAwait(false);

                        Certificate boundCert = await batchCli.CertificateOperations.GetCertificateAsync(
                            certificate.ThumbprintAlgorithm,
                            certificate.Thumbprint).ConfigureAwait(false);

                        Assert.Equal(certificate.Thumbprint, boundCert.Thumbprint);
                        Assert.Equal(certificate.ThumbprintAlgorithm, boundCert.ThumbprintAlgorithm);
                        Assert.NotNull(boundCert.Url);

                        Certificate certLowerDetail = await batchCli.CertificateOperations.GetCertificateAsync(
                            certificate.ThumbprintAlgorithm,
                            certificate.Thumbprint,
                            new ODATADetailLevel() { SelectClause = "thumbprint, thumbprintAlgorithm" }).ConfigureAwait(false);

                        // confirm lower detail level
                        Assert.Null(certLowerDetail.Url);
                        //test refresh to higher detail level
                        await certLowerDetail.RefreshAsync();
                        // confirm higher detail level
                        Assert.NotNull(certLowerDetail.Url);
                        // test refresh can lower detail level
                        await certLowerDetail.RefreshAsync(new ODATADetailLevel() { SelectClause = "thumbprint, thumbprintAlgorithm" });
                        // confirm lower detail level via refresh
                        Assert.Null(certLowerDetail.Url);
                    }

                    List<CertificateReference> certificateReferences = certificates.Select(cer => new CertificateReference(cer)
                    {
                        StoreLocation = CertStoreLocation.LocalMachine,
                        StoreName = "My",
                        Visibility = CertificateVisibility.RemoteUser
                    }).ToList();

                    await TestCancelDeleteCertificateAsync(batchCli, certificateReferences, certificates.First()).ConfigureAwait(false);
                }
                finally
                {
                    File.Delete(pfxFilePath);
                    File.Delete(cerFilePath);

                    foreach (Certificate certificate in certificates)
                    {
                        TestUtilities.DeleteCertificateIfExistsAsync(batchCli, certificate.ThumbprintAlgorithm, certificate.Thumbprint).Wait();
                    }

                    foreach (Certificate certificate in certificates)
                    {
                        TestUtilities.DeleteCertMonitor(batchCli.CertificateOperations, testOutputHelper, certificate.ThumbprintAlgorithm, certificate.Thumbprint);
                    }
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task TestPoolCertificateReferencesWithUpdate()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                //Generate the certificates
                const string certificatePrefix = "poolwithcertificatereferences";

                string cerFilePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));
                string pfxFilePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", certificatePrefix));

                IEnumerable<Certificate> certificates = GenerateCertificates(batchCli, cerFilePath, pfxFilePath);

                try
                {
                    foreach (Certificate certificate in certificates)
                    {
                        testOutputHelper.WriteLine("Adding certificate with thumbprint: {0}", certificate.Thumbprint);
                        await certificate.CommitAsync().ConfigureAwait(false);
                    }

                    List<CertificateReference> certificateReferences = certificates.Select(cer => new CertificateReference(cer)
                    {
                        StoreLocation = CertStoreLocation.LocalMachine,
                        StoreName = "My",
                        Visibility = CertificateVisibility.RemoteUser
                    }).ToList();

                    await TestPoolCreateAndUpdateWithCertificateReferencesAsync(batchCli, certificateReferences).ConfigureAwait(false);
                    await TestAutoPoolCreateAndUpdateWithCertificateReferencesAsync(batchCli, certificateReferences).ConfigureAwait(false);
                }
                finally
                {
                    File.Delete(pfxFilePath);
                    File.Delete(cerFilePath);

                    foreach (Certificate certificate in certificates)
                    {
                        TestUtilities.DeleteCertificateIfExistsAsync(batchCli, certificate.ThumbprintAlgorithm, certificate.Thumbprint).Wait();
                    }

                    foreach (Certificate certificate in certificates)
                    {
                        TestUtilities.DeleteCertMonitor(batchCli.CertificateOperations, testOutputHelper, certificate.ThumbprintAlgorithm, certificate.Thumbprint);
                    }
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        #region Test helpers

        private static async Task WaitForCertificateState(Certificate certificate, CertificateState targetState)
        {
            TimeSpan timeout = TimeSpan.FromMinutes(3);
            DateTime startTime = DateTime.UtcNow;
            DateTime timeoutTime = startTime + timeout;
            while (certificate.State != targetState)
            {
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                await certificate.RefreshAsync().ConfigureAwait(false);

                if (DateTime.UtcNow > timeoutTime)
                {
                    throw new TimeoutException(string.Format("Timed out waiting for certificate {0} to reach state {1}",
                        certificate.Thumbprint,
                        targetState));
                }
            }
        }

        private static List<Certificate> GenerateCertificates(BatchClient batchClient, string cerFilePath, string pfxFilePath)
        {
            CertificateBuilder.CreateSelfSignedInFile("Foo", cerFilePath, CertificateBuilder.Sha1Algorithm);
            CertificateBuilder.CreateSelfSignedInFile("Foo", pfxFilePath, CertificateBuilder.Sha1Algorithm, password: CommonResources.CertificatePassword);

#pragma warning disable CS0618 // Type or member is obsolete
            Certificate cerCertificate = batchClient.CertificateOperations.CreateCertificateFromCer(cerFilePath);
            Certificate pfxCertificate = batchClient.CertificateOperations.CreateCertificateFromPfx(pfxFilePath, CommonResources.CertificatePassword);
#pragma warning restore CS0618 // Type or member is obsolete

            return new List<Certificate>
                {
                    cerCertificate,
                    pfxCertificate
                };
        }

        private class CertificateReferenceEqualityComparer : IEqualityComparer<CertificateReference>
        {
            public bool Equals(CertificateReference x, CertificateReference y)
            {
                return x.Thumbprint == y.Thumbprint &&
                    x.ThumbprintAlgorithm == y.ThumbprintAlgorithm &&
                    x.StoreLocation == y.StoreLocation && x.StoreName == y.StoreName &&
                    x.Visibility == y.Visibility;
            }

            public int GetHashCode(CertificateReference obj)
            {
                return obj.GetHashCode();
            }
        }

        private static void AssertCertificateReferenceCollectionsAreSame(IEnumerable<CertificateReference> expected, IEnumerable<CertificateReference> actual)
        {
            var orderedExpectedCollection = expected.OrderBy(certificateReference => certificateReference.Thumbprint);
            var orderedActualCollection = actual.OrderBy(certificateReference => certificateReference.Thumbprint);
            Assert.Equal(orderedExpectedCollection, orderedActualCollection, new CertificateReferenceEqualityComparer());
        }

        private static async Task TestPoolCreateAndUpdateWithCertificateReferencesAsync(
            BatchClient batchCli,
            IList<CertificateReference> certificateReferences)
        {

            PoolOperations poolOperations = batchCli.PoolOperations;

            string poolId = "CreateAndUpdateWithCertificateReferences-" + TestUtilities.GetMyName();

            try
            {
                // create a pool with initial cert refs
                CloudPool boundPool;

                {
                    var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                        ubuntuImageDetails.ImageReference,
                        nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                    CloudPool unboundPool = poolOperations.CreatePool(
                        poolId: poolId,
                        virtualMachineSize: PoolFixture.VMSize,
                        virtualMachineConfiguration: virtualMachineConfiguration,
                        targetDedicatedComputeNodes: 0);

                    // create the pool with initial cert refs
                    unboundPool.CertificateReferences = certificateReferences;

                    await unboundPool.CommitAsync().ConfigureAwait(false);

                    boundPool = await poolOperations.GetPoolAsync(poolId).ConfigureAwait(false);

                    // confirm the refs are there
                    Assert.NotNull(boundPool.CertificateReferences);
                    AssertCertificateReferenceCollectionsAreSame(certificateReferences, boundPool.CertificateReferences);
                }

                // mutate the cert refs: assign only one
                {
                    List<CertificateReference> listOfOne = new List<CertificateReference>
                    {
                        // just pick one cert
                        certificateReferences.ToArray()[1]
                    };

                    boundPool.CertificateReferences = listOfOne;

                    await boundPool.CommitAsync().ConfigureAwait(false);
                    await boundPool.RefreshAsync().ConfigureAwait(false);

                    // confirm that the ref collection is correct
                    AssertCertificateReferenceCollectionsAreSame(listOfOne, boundPool.CertificateReferences);
                }

                // mutate the pool cert refs: assign null to clear
                {
                    boundPool.CertificateReferences = null;

                    await boundPool.CommitAsync().ConfigureAwait(false);
                    await boundPool.RefreshAsync().ConfigureAwait(false);

                    Assert.Empty(boundPool.CertificateReferences);
                }
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
            }
        }

        private static async Task TestAutoPoolCreateAndUpdateWithCertificateReferencesAsync(
            BatchClient batchCli,
            IList<CertificateReference> certificateReferences)
        {
            string jobId = "TestAutoPoolCreateAndUpdateWithCertificateReferences-" + TestUtilities.GetMyName();

            try
            {
                var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    ubuntuImageDetails.ImageReference,
                    nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                PoolInformation poolInformation = new PoolInformation
                    {
                        AutoPoolSpecification = new AutoPoolSpecification
                            {
                                PoolSpecification = new PoolSpecification
                                    {
                                        CertificateReferences = certificateReferences,
                                        VirtualMachineConfiguration = virtualMachineConfiguration,
                                        TargetDedicatedComputeNodes = 0,
                                        VirtualMachineSize = PoolFixture.VMSize,
                                    },
                                AutoPoolIdPrefix = TestUtilities.GetMyName(),
                                PoolLifetimeOption = PoolLifetimeOption.Job
                            }
                    };

                CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInformation);

                await unboundJob.CommitAsync().ConfigureAwait(false);

                CloudJob boundJob = await batchCli.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                AssertCertificateReferenceCollectionsAreSame(
                    certificateReferences,
                    boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences);
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
            }
        }

        private static async Task TestCancelDeleteCertificateAsync(
            BatchClient batchCli,
            IList<CertificateReference> certificateReferences,
            Certificate certToDelete)
        {
            string poolId = "CancelDeleteCert-" + TestUtilities.GetMyName();
            var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                ubuntuImageDetails.ImageReference,
                nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

            try
            {
                {
                    CloudPool unboundPool = batchCli.PoolOperations.CreatePool(
                        poolId: poolId,
                        virtualMachineSize: PoolFixture.VMSize,
                        virtualMachineConfiguration: virtualMachineConfiguration,
                        targetDedicatedComputeNodes: 0);
                    unboundPool.CertificateReferences = certificateReferences;

                    await unboundPool.CommitAsync().ConfigureAwait(false);

                    CloudPool boundPool = await batchCli.PoolOperations.GetPoolAsync(poolId).ConfigureAwait(false);

                    // confirm the refs are there
                    Assert.NotNull(boundPool.CertificateReferences);
                    AssertCertificateReferenceCollectionsAreSame(certificateReferences, boundPool.CertificateReferences);
                }

                // test Certificate Delete/CancelDelete
                {
                    await batchCli.CertificateOperations.DeleteCertificateAsync(certToDelete.ThumbprintAlgorithm, certToDelete.Thumbprint).ConfigureAwait(false);
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // ok, it should be deleting
                    Assert.Equal(CertificateState.Deleting, certToDelete.State);

                    //now we wait for delete failed
                    await WaitForCertificateState(certToDelete, CertificateState.DeleteFailed).ConfigureAwait(false);

                    // test CertificateManger.CancelDelete.  now the delete failed, we can cancel it
                    await batchCli.CertificateOperations.CancelDeleteCertificateAsync(certToDelete.ThumbprintAlgorithm, certToDelete.Thumbprint).ConfigureAwait(false);

                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false); // gift to server to get going on that cancel.

                    // get fresh state
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // cert is now ok
                    Assert.Equal(CertificateState.Active, certToDelete.State);
                }

                // test Certificate.Delete/CancelDelete
                {
                    await certToDelete.DeleteAsync().ConfigureAwait(false);
                    await certToDelete.RefreshAsync().ConfigureAwait(false);

                    // ok, it should be deleting
                    Assert.Equal(CertificateState.Deleting, certToDelete.State);

                    //now we wait for delete failed
                    await WaitForCertificateState(certToDelete, CertificateState.DeleteFailed).ConfigureAwait(false);

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
                TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
            }
        }

        #endregion

    }
}
