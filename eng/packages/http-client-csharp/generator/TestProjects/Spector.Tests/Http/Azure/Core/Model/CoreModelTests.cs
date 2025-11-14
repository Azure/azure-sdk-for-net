// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Specs.Azure.Core.Model;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Model
{
    public class CoreModelTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_get() => Test(async (host) =>
        {
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().GetAsync();
            var result = response.Value.ToArray();
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, result);
        });

        [SpectorTest]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_put() => Test(async (host) =>
        {
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PutAsync(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_post() => Test(async (host) =>
        {
            var body = new AzureEmbeddingModel(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PostAsync(body);
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 8, 9 }, response.Value.Embedding.ToArray());
        });
    }
}