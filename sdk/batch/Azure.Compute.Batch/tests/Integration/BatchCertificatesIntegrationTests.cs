// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Common;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Pkcs;

namespace Azure.Compute.Batch.Tests.Integration
{
    public class BatchCertificatesIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchCertificatesIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchCertificatesIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchCertificatesIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchCertificatesIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [LiveOnly]
        public async Task CreateCertificate()
        {
            var client = CreateBatchClient();

            const string certificatePrefix = "testcertificatecrud";
            string cerFilePath = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));
            string pfxFilePath = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", certificatePrefix));
            List<BatchCertificate> certificates = null;

            try
            {
                certificates = await GenerateCertificatesAsync(client, cerFilePath, pfxFilePath);
                Assert.IsNotNull(certificates);
                Assert.AreEqual(1, certificates.Count());
            }
            finally
            {
                // Delete the certificate
                // Delete the certificate files
                if (File.Exists(cerFilePath))
                {
                    File.Delete(cerFilePath);
                    if (certificates != null && certificates.Count > 0)
                        await client.DeleteCertificateAsync(certificates[0].ThumbprintAlgorithm, certificates[0].Thumbprint);
                }
                if (File.Exists(pfxFilePath))
                {
                    File.Delete(pfxFilePath);
                    if (certificates != null && certificates.Count > 1)
                        await client.DeleteCertificateAsync(certificates[1].ThumbprintAlgorithm, certificates[1].Thumbprint);
                }
            }
        }

        [LiveOnly]
        public async Task DeleteCertificate()
         {
            var client = CreateBatchClient();

            const string certificatePrefix = "testcertificatecrud";
            string cerFilePath = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));
            string cerFilePath2 = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix+"2"));
            int count = 0;
            try
            {
                await GenerateCertificatesAsync(client, cerFilePath, "");
                await GenerateCertificatesAsync(client, cerFilePath2, "",2);

                await foreach (BatchCertificate item in client.GetCertificatesAsync())
                {
                    // delete
                    await client.DeleteCertificateAsync(item.ThumbprintAlgorithm, item.Thumbprint);
                    count++;
                }
            }
            finally
            {
                Assert.AreEqual(2, count);
                // Delete the certificate files
                if (File.Exists(cerFilePath))
                {
                    File.Delete(cerFilePath);
                }
                if (File.Exists(cerFilePath2))
                {
                    File.Delete(cerFilePath2);
                }
            }
        }

        [LiveOnly]
        public async Task PoolCreateAndUpdateWithCertificates()
        {
            const string certificatePrefix = "testcertificatecrud";
            var client = CreateBatchClient();
            List<BatchCertificate> certificates = null;
            string cerFilePath = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));

            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "CertPool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                certificates = await GenerateCertificatesAsync(client, cerFilePath, "");
                Assert.IsNotNull(certificates);
                Assert.AreEqual(1, certificates.Count());

                // create a pool to verify we have something to query for
                BatchPoolCreateOptions batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions();
                batchPoolCreateOptions.CertificateReferences.Add(
                    new BatchCertificateReference(certificates[0].Thumbprint, certificates[0].ThumbprintAlgorithm)
                );
                batchPoolCreateOptions.CertificateReferences[0].Visibility.Add(BatchCertificateVisibility.RemoteUser);
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool certPool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, iaasWindowsPoolFixture.PoolId);

                // verify autoscale settings
                Assert.IsNotNull(certPool);
                Assert.AreEqual(1, certPool.CertificateReferences.Count);
                Assert.AreEqual(certificates[0].Thumbprint, certPool.CertificateReferences[0].Thumbprint);
                Assert.AreEqual(certificates[0].ThumbprintAlgorithm, certPool.CertificateReferences[0].ThumbprintAlgorithm);
            }
            finally
            {
                //await client.DeletePoolAsync(poolID);
                if (File.Exists(cerFilePath))
                {
                    File.Delete(cerFilePath);
                    if (certificates != null && certificates.Count > 0)
                        await client.DeleteCertificateAsync(certificates[0].ThumbprintAlgorithm, certificates[0].Thumbprint);
                }

                await client.DeletePoolAsync(poolID);
            }
        }

        [LiveOnly]
        public async Task ReplaceCertPool()
        {
            const string certificatePrefix = "testcertificatecrud";
            var client = CreateBatchClient();
            List<BatchCertificate> certificates = null;
            string cerFilePath = CertificateBuilder.GetTemporaryCertificateFilePath(string.Format("{0}.cer", certificatePrefix));

            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ReplaceCertPool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                certificates = await GenerateCertificatesAsync(client, cerFilePath, "");
                Assert.IsNotNull(certificates);
                Assert.AreEqual(1, certificates.Count());

                // create a pool to verify we have something to query for
                BatchPool orginalPool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // replace pool
                BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
                };

                BatchMetadataItem[] metadataIems = new BatchMetadataItem[] {
                    new BatchMetadataItem("name", "value")
                };

                BatchCertificateReference[] certificateReferences = new BatchCertificateReference[] {
                new BatchCertificateReference(certificates[0].Thumbprint, certificates[0].ThumbprintAlgorithm)
                };

                BatchPoolReplaceOptions replaceContent = new BatchPoolReplaceOptions(certificateReferences, batchApplicationPackageReferences, metadataIems);
                Response response = await client.ReplacePoolPropertiesAsync(poolID, replaceContent);
                BatchPool replacePool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(replacePool.Metadata.First().Value, "value");
                Assert.AreEqual(1, replacePool.CertificateReferences.Count);
                Assert.AreEqual(certificates[0].Thumbprint, replacePool.CertificateReferences[0].Thumbprint);
                Assert.AreEqual(certificates[0].ThumbprintAlgorithm, replacePool.CertificateReferences[0].ThumbprintAlgorithm);
            }
            finally
            {
                //await client.DeletePoolAsync(poolID);
                if (File.Exists(cerFilePath))
                {
                    File.Delete(cerFilePath);
                    if (certificates != null && certificates.Count > 0)
                        await client.DeleteCertificateAsync(certificates[0].ThumbprintAlgorithm, certificates[0].Thumbprint);
                }

                await client.DeletePoolAsync(poolID);
            }
        }

        private async Task<List<BatchCertificate>> GenerateCertificatesAsync(BatchClient batchClient, string cerFilePath, string pfxFilePath, long seed=1)
        {
            X509Certificate2 cerCert = CertificateBuilder.CreateSelfSignedInFile2("Foo", cerFilePath, CertificateBuilder.Sha1Algorithm,seed:seed);
            BatchCertificate cerCertificate = new BatchCertificate(cerCert.Thumbprint, "sha1", BinaryData.FromBytes(cerCert.GetRawCertData()))
            {
                CertificateFormat = BatchCertificateFormat.Cer,
                Password = "",
            };

            Response response = await batchClient.CreateCertificateAsync(cerCertificate);

            BatchCertificate cerCertificateResponse = await batchClient.GetCertificateAsync(cerCertificate.ThumbprintAlgorithm, cerCertificate.Thumbprint);

            return new List<BatchCertificate>
                {
                    cerCertificateResponse//,
                   // pfxCertificateResponse
                };
        }
    }
}
