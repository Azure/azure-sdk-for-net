// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using TestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public class ComputeNodeUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public ComputeNodeUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestComputeNodeCertificateReferencesAreReadOnly()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            var protoComputeNode = new Protocol.Models.ComputeNode()
            {
                CertificateReferences = new List<Protocol.Models.CertificateReference>
                            {
                                new Protocol.Models.CertificateReference(
                                    thumbprint: "1234",
                                    thumbprintAlgorithm: "SHA1",
                                    storeLocation: Protocol.Models.CertificateStoreLocation.CurrentUser,
                                    storeName: "My",
                                    visibility: new List<Protocol.Models.CertificateVisibility>
                                        {
                                            Protocol.Models.CertificateVisibility.Task
                                        })
                            }
            };

            ComputeNode computeNode = batchClient.PoolOperations.GetComputeNode(
                "dummy",
                "dummy",
                additionalBehaviors: InterceptorFactory.CreateGetComputeNodeRequestInterceptor(protoComputeNode));

            CertificateReference computeNodeCertificateReference = computeNode.CertificateReferences.First();

            // reads are allowed
            this.testOutputHelper.WriteLine(computeNodeCertificateReference.StoreLocation.ToString());
            this.testOutputHelper.WriteLine(computeNodeCertificateReference.StoreName);
            this.testOutputHelper.WriteLine(computeNodeCertificateReference.Thumbprint);
            this.testOutputHelper.WriteLine(computeNodeCertificateReference.ThumbprintAlgorithm);
            this.testOutputHelper.WriteLine(computeNodeCertificateReference.Visibility.ToString());

            // writes are foribdden
            Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.StoreLocation = CertStoreLocation.CurrentUser; });
            Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.StoreName = "x"; });
            Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.Thumbprint = "y"; });
            Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.ThumbprintAlgorithm = "z"; });
            Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.Visibility = CertificateVisibility.None; });
        }
    }
}
