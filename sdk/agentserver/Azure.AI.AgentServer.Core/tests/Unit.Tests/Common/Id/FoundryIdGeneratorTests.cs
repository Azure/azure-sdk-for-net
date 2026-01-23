// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Common.Id;

namespace Azure.AI.AgentServer.Core.Unit.Tests.Common.Id;

public class FoundryIdGeneratorTests
{
    // Valid ID format: prefix_<18 char partition key><32 char entropy> = prefix_50 chars
    // Example: conv_abc123def456ghi789jkl012mno345pqr678stu901vwx234ab
    private const string ValidConversationId = "conv_abc123def456ghi7jkl012mno345pqr678stu901vwx234abcdef";
    private const string ValidResponseId = "resp_xyz789abc123def4ghi789jkl012mno345pqr678stu901vwx234";

    [Test]
    public void Constructor_WithNullIds_GeneratesNewIds()
    {
        var generator = new FoundryIdGenerator(null, null);

        Assert.That(generator.ResponseId, Does.StartWith("resp_"));
        Assert.That(generator.ConversationId, Does.StartWith("conv_"));
    }

    [Test]
    public void Constructor_WithProvidedResponseId_UsesProvidedResponseId()
    {
        var generator = new FoundryIdGenerator(ValidResponseId, ValidConversationId);

        Assert.That(generator.ResponseId, Is.EqualTo(ValidResponseId));
        Assert.That(generator.ConversationId, Is.EqualTo(ValidConversationId));
    }

    [Test]
    public void Constructor_WithProvidedConversationId_UsesProvidedConversationId()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        Assert.That(generator.ConversationId, Is.EqualTo(ValidConversationId));
        Assert.That(generator.ResponseId, Does.StartWith("resp_"));
    }

    [Test]
    public void Generate_WithCategory_GeneratesIdWithPrefix()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        var id = generator.Generate("msg");

        Assert.That(id, Does.StartWith("msg_"));
    }

    [Test]
    public void Generate_WithNullCategory_UsesDefaultPrefix()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        var id = generator.Generate(null);

        Assert.That(id, Does.StartWith("id_"));
    }

    [Test]
    public void Generate_WithEmptyCategory_UsesDefaultPrefix()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        var id = generator.Generate("");

        Assert.That(id, Does.StartWith("id_"));
    }

    [Test]
    public void Generate_PreservesPartitionKeyFromConversationId()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        var id1 = generator.Generate("msg");
        var id2 = generator.Generate("item");

        // Both IDs should share the same partition key (first 18 chars after prefix)
        var partitionKey1 = id1.Split('_')[1].Substring(0, 18);
        var partitionKey2 = id2.Split('_')[1].Substring(0, 18);
        Assert.That(partitionKey1, Is.EqualTo(partitionKey2));
    }

    [Test]
    public void Generate_ProducesUniqueIds()
    {
        var generator = new FoundryIdGenerator(null, ValidConversationId);

        var ids = new HashSet<string>();
        for (int i = 0; i < 100; i++)
        {
            ids.Add(generator.Generate("test"));
        }

        Assert.That(ids.Count, Is.EqualTo(100));
    }

    [Test]
    public void Constructor_WithEmptyConversationId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new FoundryIdGenerator(null, ""));
    }

    [Test]
    public void Constructor_WithInvalidConversationIdFormat_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new FoundryIdGenerator(null, "invalid"));
    }

    [Test]
    public void Constructor_WithShortConversationId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new FoundryIdGenerator(null, "conv_short"));
    }
}
