// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using OpenAI.Embeddings;

namespace Azure.AI.OpenAI.Tests;

public class EmbeddingTests : AoaiTestBase<EmbeddingClient>
{
    public EmbeddingTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<EmbeddingClient>());

    [RecordedTest]
    public async Task SimpleEmbeddingWithTopLevelClient()
    {
        EmbeddingClient embeddingClient = GetTestClient();
        ClientResult<Embedding> embeddingResult = await embeddingClient.GenerateEmbeddingAsync("sample text to embed");
        Assert.That(embeddingResult?.Value?.Vector.Length, Is.GreaterThan(0));
    }
}
