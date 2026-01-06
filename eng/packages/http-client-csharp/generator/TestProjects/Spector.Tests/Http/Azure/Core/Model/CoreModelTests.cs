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
            Assert.That(result, Is.EqualTo(new[] { 0, 1, 2, 3, 4 }).AsCollection);
        });

        [SpectorTest]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_put() => Test(async (host) =>
        {
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PutAsync(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_Core_Model_AzureCoreEmbeddingVector_post() => Test(async (host) =>
        {
            var body = new AzureEmbeddingModel(new ReadOnlyMemory<int>(new[] { 0, 1, 2, 3, 4 }));
            var response = await new ModelClient(host, null).GetAzureCoreEmbeddingVectorClient().PostAsync(body);
            Assert.That(response.Value.Embedding.ToArray(), Is.EqualTo(new[] { 5, 6, 7, 8, 9 }).AsCollection);
        });
    }
}