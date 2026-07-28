// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// Promotes oversized inline payload slots into task attachments and resolves
/// refs back to values, enforcing the protocol's size/count caps. Promotion
/// replaces the inline value with an <see cref="AttachmentRef"/> and stores the
/// value (carrying a content hash) under a deterministic attachment key.
/// </summary>
internal static class AttachmentPromoter
{
    /// <summary>Input slots larger than this many bytes are promoted to the <c>input</c> attachment.</summary>
    public const int InputThresholdBytes = 200 * 1024;

    /// <summary>Steering input slots larger than this many bytes are promoted to a <c>steering_input_&lt;seq&gt;</c> attachment.</summary>
    public const int SteeringThresholdBytes = 20 * 1024;

    /// <summary>The maximum serialized size of a single attachment value (10 MiB).</summary>
    public const int MaxAttachmentValueBytes = 10 * 1024 * 1024;

    /// <summary>The maximum number of attachments per task.</summary>
    public const int MaxAttachmentsPerTask = 20;

    /// <summary>The fixed attachment key used for a promoted task input.</summary>
    public const string InputAttachmentKey = "input";

    /// <summary>The attachment key prefix used for promoted steering inputs.</summary>
    public const string SteeringAttachmentKeyPrefix = "steering_input_";

    /// <summary>Measures the canonical (sized) byte length of a slot value.</summary>
    /// <param name="value">The JSON value to measure.</param>
    /// <returns>The canonical UTF-8 byte length.</returns>
    public static int MeasureBytes(JsonNode? value)
    {
        var element = System.Text.Json.JsonSerializer.SerializeToElement(value);
        return CanonicalJson.MeasureByteSize(element);
    }

    /// <summary>Computes the <c>sha256:</c>-prefixed content hash of a slot value.</summary>
    /// <param name="value">The JSON value to hash.</param>
    /// <returns>The hash string, e.g. <c>sha256:&lt;64 hex&gt;</c>.</returns>
    public static string ComputeHash(JsonNode? value)
    {
        var element = System.Text.Json.JsonSerializer.SerializeToElement(value);
        return "sha256:" + CanonicalJson.ComputeSha256Hex(element);
    }

    /// <summary>
    /// Promotes <paramref name="value"/> into <paramref name="attachments"/> under
    /// <paramref name="attachmentKey"/> when it exceeds <paramref name="thresholdBytes"/>;
    /// otherwise returns the inline value unchanged. Enforces the per-value and
    /// per-task caps and raises <see cref="InputTooLargeException"/> on violation.
    /// </summary>
    /// <param name="attachments">The task attachments object (created/mutated as needed).</param>
    /// <param name="value">The inline value to promote or keep.</param>
    /// <param name="attachmentKey">The attachment key to store the promoted value under.</param>
    /// <param name="thresholdBytes">The promotion threshold for this channel.</param>
    /// <returns>A tuple: the slot node to persist (inline clone or ref) and the possibly-created attachments object.</returns>
    public static (JsonNode? Slot, JsonObject? Attachments) Promote(
        JsonObject? attachments,
        JsonNode? value,
        string attachmentKey,
        int thresholdBytes)
    {
        int size = MeasureBytes(value);
        if (size <= thresholdBytes)
        {
            return (value?.DeepClone(), attachments);
        }

        if (size > MaxAttachmentValueBytes)
        {
            throw new InputTooLargeException(
                $"The value is {size} bytes, exceeding the per-attachment maximum of {MaxAttachmentValueBytes} bytes.");
        }

        attachments ??= new JsonObject();

        // Count existing non-null attachments plus this addition (if new key).
        int existing = 0;
        foreach (var kvp in attachments)
        {
            if (kvp.Value is not null)
            {
                existing++;
            }
        }

        bool isNewKey = !attachments.ContainsKey(attachmentKey);
        if (isNewKey && existing + 1 > MaxAttachmentsPerTask)
        {
            throw new InputTooLargeException(
                $"Promoting '{attachmentKey}' would exceed the per-task attachment limit of {MaxAttachmentsPerTask}.");
        }

        string hash = ComputeHash(value);
        attachments[attachmentKey] = value?.DeepClone();
        var slot = new AttachmentRef(attachmentKey, hash).ToJson();
        return (slot, attachments);
    }

    /// <summary>
    /// Resolves a slot value to its concrete value, following an attachment ref
    /// into <paramref name="attachments"/> when present. Validates the content
    /// hash on read (a cross-language robustness improvement over the reference
    /// implementation) and raises on mismatch or a dangling ref.
    /// </summary>
    /// <param name="slot">The slot value (inline or ref).</param>
    /// <param name="attachments">The task attachments object.</param>
    /// <returns>The resolved value, or <see langword="null"/>.</returns>
    public static JsonNode? Resolve(JsonNode? slot, JsonObject? attachments)
    {
        if (!AttachmentRef.TryParse(slot, out var attachmentRef))
        {
            return slot;
        }

        var value = attachments?[attachmentRef!.Key];
        if (value is null && (attachments is null || !attachments.ContainsKey(attachmentRef!.Key)))
        {
            throw new TaskException($"Attachment '{attachmentRef!.Key}' referenced by a payload slot is missing.");
        }

        string actual = ComputeHash(value);
        if (!string.Equals(actual, attachmentRef!.Hash, StringComparison.Ordinal))
        {
            throw new TaskException(
                $"Attachment '{attachmentRef.Key}' failed hash validation (store-side corruption).");
        }

        return value;
    }

    /// <summary>
    /// Removes the attachment a slot points at, if the slot is a ref, leaving
    /// inline slots untouched. Used to clean up orphaned attachments when a slot
    /// is replaced or drained.
    /// </summary>
    /// <param name="slot">The slot whose backing attachment should be removed.</param>
    /// <param name="attachments">The task attachments object.</param>
    public static void RemoveOrphan(JsonNode? slot, JsonObject? attachments)
    {
        if (attachments is null)
        {
            return;
        }

        if (AttachmentRef.TryParse(slot, out var attachmentRef))
        {
            attachments.Remove(attachmentRef!.Key);
        }
    }
}
