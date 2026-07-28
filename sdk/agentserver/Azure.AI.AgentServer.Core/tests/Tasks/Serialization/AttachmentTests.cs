// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Serialization;

[TestFixture]
public class AttachmentTests
{
    private static JsonNode BigString(int bytes) => JsonValue.Create(new string('x', bytes))!;

    [Test]
    public void SmallInputStaysInline()
    {
        var (slot, attachments) = AttachmentPromoter.Promote(null, JsonValue.Create("hi"), AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);
        Assert.That(AttachmentRef.IsRef(slot), Is.False);
        Assert.That(attachments, Is.Null);
    }

    [Test]
    public void OversizedInputPromotesToRef()
    {
        var value = BigString(AttachmentPromoter.InputThresholdBytes + 10);
        var (slot, attachments) = AttachmentPromoter.Promote(null, value, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);

        Assert.That(AttachmentRef.TryParse(slot, out var attachmentRef), Is.True);
        Assert.That(attachmentRef!.Key, Is.EqualTo(AttachmentPromoter.InputAttachmentKey));
        Assert.That(attachmentRef.Hash, Does.StartWith("sha256:"));
        Assert.That(attachments, Is.Not.Null);
        Assert.That(attachments![AttachmentPromoter.InputAttachmentKey], Is.Not.Null);
    }

    [Test]
    public void SteeringChannelUsesLowerThreshold()
    {
        var value = BigString(AttachmentPromoter.SteeringThresholdBytes + 10);
        var (slot, _) = AttachmentPromoter.Promote(null, value, AttachmentPromoter.SteeringAttachmentKeyPrefix + "3", AttachmentPromoter.SteeringThresholdBytes);
        Assert.That(AttachmentRef.IsRef(slot), Is.True);
    }

    [Test]
    public void ResolveFollowsRefAndValidatesHash()
    {
        var value = BigString(AttachmentPromoter.InputThresholdBytes + 10);
        var (slot, attachments) = AttachmentPromoter.Promote(null, value, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);

        var resolved = AttachmentPromoter.Resolve(slot, attachments);
        Assert.That((string?)resolved, Is.EqualTo((string?)value));
    }

    [Test]
    public void ResolveRaisesOnCorruptedAttachment()
    {
        var value = BigString(AttachmentPromoter.InputThresholdBytes + 10);
        var (slot, attachments) = AttachmentPromoter.Promote(null, value, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);

        attachments![AttachmentPromoter.InputAttachmentKey] = JsonValue.Create("tampered");
        Assert.Throws<TaskException>(() => AttachmentPromoter.Resolve(slot, attachments));
    }

    [Test]
    public void OverlargeValueRaisesInputTooLarge()
    {
        var value = BigString(AttachmentPromoter.MaxAttachmentValueBytes + 1);
        Assert.Throws<InputTooLargeException>(() =>
            AttachmentPromoter.Promote(null, value, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes));
    }

    [Test]
    public void AttachmentCapIsTenMebibytes()
    {
        // Pin the bumped ceiling: a value just under 10 MiB promotes, just over is rejected.
        Assert.That(AttachmentPromoter.MaxAttachmentValueBytes, Is.EqualTo(10 * 1024 * 1024));

        var underCap = BigString(AttachmentPromoter.MaxAttachmentValueBytes - 1024);
        var (slot, attachments) = AttachmentPromoter.Promote(
            null, underCap, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);
        Assert.That(attachments, Is.Not.Null, "a value under the 10 MiB cap must promote to an attachment");

        var overCap = BigString(AttachmentPromoter.MaxAttachmentValueBytes + 1);
        Assert.Throws<InputTooLargeException>(() =>
            AttachmentPromoter.Promote(null, overCap, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes));
    }

    [Test]
    public void RemoveOrphanDeletesBackingAttachment()
    {
        var value = BigString(AttachmentPromoter.InputThresholdBytes + 10);
        var (slot, attachments) = AttachmentPromoter.Promote(null, value, AttachmentPromoter.InputAttachmentKey, AttachmentPromoter.InputThresholdBytes);

        AttachmentPromoter.RemoveOrphan(slot, attachments);
        Assert.That(attachments!.ContainsKey(AttachmentPromoter.InputAttachmentKey), Is.False);
    }

    [Test]
    public void PromotingBeyondPerTaskCapRaisesInputTooLarge()
    {
        // SOT §attachments: a task may hold at most MaxAttachmentsPerTask (20) attachments.
        // Fill the object to the cap, then promoting a new key must be rejected.
        Assert.That(AttachmentPromoter.MaxAttachmentsPerTask, Is.EqualTo(20));

        var attachments = new JsonObject();
        var oversized = BigString(AttachmentPromoter.SteeringThresholdBytes + 10);
        for (int i = 0; i < AttachmentPromoter.MaxAttachmentsPerTask; i++)
        {
            var (_, next) = AttachmentPromoter.Promote(
                attachments, oversized, AttachmentPromoter.SteeringAttachmentKeyPrefix + i, AttachmentPromoter.SteeringThresholdBytes);
            attachments = next!;
        }

        Assert.That(attachments.Count, Is.EqualTo(AttachmentPromoter.MaxAttachmentsPerTask));
        Assert.Throws<InputTooLargeException>(() =>
            AttachmentPromoter.Promote(
                attachments, oversized, AttachmentPromoter.SteeringAttachmentKeyPrefix + "overflow", AttachmentPromoter.SteeringThresholdBytes),
            "promoting a 21st distinct attachment must exceed the per-task cap");
    }

    [Test]
    public void PromotingExistingKeyAtCapDoesNotCountAsNewAttachment()
    {
        // Re-promoting to a key that already exists must not trip the per-task cap
        // (the count only grows for brand-new keys).
        var attachments = new JsonObject();
        var oversized = BigString(AttachmentPromoter.SteeringThresholdBytes + 10);
        for (int i = 0; i < AttachmentPromoter.MaxAttachmentsPerTask; i++)
        {
            var (_, next) = AttachmentPromoter.Promote(
                attachments, oversized, AttachmentPromoter.SteeringAttachmentKeyPrefix + i, AttachmentPromoter.SteeringThresholdBytes);
            attachments = next!;
        }

        Assert.DoesNotThrow(() =>
            AttachmentPromoter.Promote(
                attachments, oversized, AttachmentPromoter.SteeringAttachmentKeyPrefix + "0", AttachmentPromoter.SteeringThresholdBytes),
            "overwriting an existing attachment key must not count against the per-task cap");
    }
}
