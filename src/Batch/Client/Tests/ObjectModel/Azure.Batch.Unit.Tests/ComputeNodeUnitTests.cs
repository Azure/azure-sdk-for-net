// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                var protoComputeNode = new Protocol.Models.ComputeNode()
                    {
                        CertificateReferences = new List<Protocol.Models.CertificateReference>
                            {
                                new Protocol.Models.CertificateReference(
                                    thumbprint: "1234",
                                    thumbprintAlgorithm: "SHA1",
                                    storeLocation: Protocol.Models.CertificateStoreLocation.Currentuser,
                                    storeName: "My",
                                    visibility: new List<Protocol.Models.CertificateVisibility?>
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
                this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.StoreLocation);
                this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.StoreName);
                this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.Thumbprint);
                this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.ThumbprintAlgorithm);
                this.testOutputHelper.WriteLine("{0}", computeNodeCertificateReference.Visibility);

                // writes are foribdden
                Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.StoreLocation = CertStoreLocation.CurrentUser; });
                Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.StoreName = "x"; });
                Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.Thumbprint = "y"; });
                Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.ThumbprintAlgorithm = "z"; });
                Assert.Throws<InvalidOperationException>(() => { computeNodeCertificateReference.Visibility = CertificateVisibility.None; });
            }
        }
    }
}
