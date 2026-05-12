// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Generates unique identifiers with embedded partition keys in the format
/// <c>{prefix}_{partitionKey}{entropy}</c> (50-character body).
/// </summary>
internal static class IdGenerator
{
    private const int PartitionKeyHexLength = 16;
    private const string PartitionKeySuffix = "00";
    private const int PartitionKeyTotalLength = PartitionKeyHexLength + 2; // 18
    private const int EntropyLength = 32;
    private const int NewFormatBodyLength = PartitionKeyTotalLength + EntropyLength; // 50
    private const int LegacyBodyLength = 48;
    private const int LegacyPartitionKeyLength = 16;

    // ─── Core method ────────────────────────────────────────────────

    /// <summary>
    /// Generates a new unique identifier with the given prefix.
    /// </summary>
    /// <param name="prefix">
    /// The resource type prefix (e.g., <c>"caresp"</c>, <c>"msg"</c>, <c>"fc"</c>).
    /// Must not include the delimiter — it is added automatically.
    /// </param>
    /// <param name="partitionKeyHint">
    /// An existing ID from which to extract the partition key. When provided,
    /// the generated ID shares the same partition key for storage colocation.
    /// When empty or null, a fresh partition key is auto-generated.
    /// </param>
    /// <returns>
    /// A string in the format <c>{prefix}_{partitionKey}{entropy}</c> where
    /// partition key is 18 characters and entropy is 32 alphanumeric characters.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="prefix"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="prefix"/> is empty.</exception>
    public static string NewId(string prefix, string? partitionKeyHint = "")
    {
        ArgumentNullException.ThrowIfNull(prefix);
        if (prefix.Length == 0)
            throw new ArgumentException("Prefix must not be empty.", nameof(prefix));

        string partitionKey;
        if (!string.IsNullOrEmpty(partitionKeyHint) && TryExtractPartitionKeyRaw(partitionKeyHint, out var extractedPk))
        {
            // If legacy pk (16 chars), pad with "00" to make 18
            partitionKey = extractedPk.Length == LegacyPartitionKeyLength
                ? extractedPk + PartitionKeySuffix
                : extractedPk;
        }
        else
        {
            partitionKey = GeneratePartitionKey();
        }

        var entropy = GenerateEntropy();
        return string.Concat(prefix, "_", partitionKey, entropy);
    }

    // ─── Convenience methods ────────────────────────────────────────

    /// <summary>Generates a new response ID with the <c>caresp</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A response ID in the format <c>caresp_{partitionKey}{entropy}</c>.</returns>
    public static string NewResponseId(string? partitionKeyHint = "")
        => NewId("caresp", partitionKeyHint);

    /// <summary>Generates a new output message item ID with the <c>msg</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A message item ID in the format <c>msg_{partitionKey}{entropy}</c>.</returns>
    public static string NewMessageItemId(string? partitionKeyHint = "")
        => NewId("msg", partitionKeyHint);

    /// <summary>Generates a new function tool call item ID with the <c>fc</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A function call item ID in the format <c>fc_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionCallItemId(string? partitionKeyHint = "")
        => NewId("fc", partitionKeyHint);

    /// <summary>Generates a new reasoning item ID with the <c>rs</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A reasoning item ID in the format <c>rs_{partitionKey}{entropy}</c>.</returns>
    public static string NewReasoningItemId(string? partitionKeyHint = "")
        => NewId("rs", partitionKeyHint);

    /// <summary>Generates a new file search call item ID with the <c>fs</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A file search call item ID in the format <c>fs_{partitionKey}{entropy}</c>.</returns>
    public static string NewFileSearchCallItemId(string? partitionKeyHint = "")
        => NewId("fs", partitionKeyHint);

    /// <summary>Generates a new web search call item ID with the <c>ws</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A web search call item ID in the format <c>ws_{partitionKey}{entropy}</c>.</returns>
    public static string NewWebSearchCallItemId(string? partitionKeyHint = "")
        => NewId("ws", partitionKeyHint);

    /// <summary>Generates a new code interpreter call item ID with the <c>ci</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A code interpreter call item ID in the format <c>ci_{partitionKey}{entropy}</c>.</returns>
    public static string NewCodeInterpreterCallItemId(string? partitionKeyHint = "")
        => NewId("ci", partitionKeyHint);

    /// <summary>Generates a new image generation call item ID with the <c>ig</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An image generation call item ID in the format <c>ig_{partitionKey}{entropy}</c>.</returns>
    public static string NewImageGenCallItemId(string? partitionKeyHint = "")
        => NewId("ig", partitionKeyHint);

    /// <summary>Generates a new MCP tool call item ID with the <c>mcp</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An MCP tool call item ID in the format <c>mcp_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpCallItemId(string? partitionKeyHint = "")
        => NewId("mcp", partitionKeyHint);

    /// <summary>Generates a new MCP list tools item ID with the <c>mcpl</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An MCP list tools item ID in the format <c>mcpl_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpListToolsItemId(string? partitionKeyHint = "")
        => NewId("mcpl", partitionKeyHint);

    /// <summary>Generates a new custom tool call item ID with the <c>ctc</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A custom tool call item ID in the format <c>ctc_{partitionKey}{entropy}</c>.</returns>
    public static string NewCustomToolCallItemId(string? partitionKeyHint = "")
        => NewId("ctc", partitionKeyHint);

    /// <summary>Generates a new custom tool call output item ID with the <c>ctco</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A custom tool call output item ID in the format <c>ctco_{partitionKey}{entropy}</c>.</returns>
    public static string NewCustomToolCallOutputItemId(string? partitionKeyHint = "")
        => NewId("ctco", partitionKeyHint);

    /// <summary>Generates a new function call output item ID with the <c>fco</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A function call output item ID in the format <c>fco_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionCallOutputItemId(string? partitionKeyHint = "")
        => NewId("fco", partitionKeyHint);

    /// <summary>Generates a new computer call item ID with the <c>cu</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A computer call item ID in the format <c>cu_{partitionKey}{entropy}</c>.</returns>
    public static string NewComputerCallItemId(string? partitionKeyHint = "")
        => NewId("cu", partitionKeyHint);

    /// <summary>Generates a new computer call output item ID with the <c>cuo</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A computer call output item ID in the format <c>cuo_{partitionKey}{entropy}</c>.</returns>
    public static string NewComputerCallOutputItemId(string? partitionKeyHint = "")
        => NewId("cuo", partitionKeyHint);

    /// <summary>Generates a new local shell call item ID with the <c>lsh</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A local shell call item ID in the format <c>lsh_{partitionKey}{entropy}</c>.</returns>
    public static string NewLocalShellCallItemId(string? partitionKeyHint = "")
        => NewId("lsh", partitionKeyHint);

    /// <summary>Generates a new local shell call output item ID with the <c>lsho</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A local shell call output item ID in the format <c>lsho_{partitionKey}{entropy}</c>.</returns>
    public static string NewLocalShellCallOutputItemId(string? partitionKeyHint = "")
        => NewId("lsho", partitionKeyHint);

    /// <summary>Generates a new function shell call item ID with the <c>lsh</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A function shell call item ID in the format <c>lsh_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionShellCallItemId(string? partitionKeyHint = "")
        => NewId("lsh", partitionKeyHint);

    /// <summary>Generates a new function shell call output item ID with the <c>lsho</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A function shell call output item ID in the format <c>lsho_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionShellCallOutputItemId(string? partitionKeyHint = "")
        => NewId("lsho", partitionKeyHint);

    /// <summary>Generates a new apply-patch call item ID with the <c>ap</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An apply-patch call item ID in the format <c>ap_{partitionKey}{entropy}</c>.</returns>
    public static string NewApplyPatchCallItemId(string? partitionKeyHint = "")
        => NewId("ap", partitionKeyHint);

    /// <summary>Generates a new apply-patch call output item ID with the <c>apo</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An apply-patch call output item ID in the format <c>apo_{partitionKey}{entropy}</c>.</returns>
    public static string NewApplyPatchCallOutputItemId(string? partitionKeyHint = "")
        => NewId("apo", partitionKeyHint);

    /// <summary>Generates a new MCP approval request item ID with the <c>mcpr</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An MCP approval request item ID in the format <c>mcpr_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpApprovalRequestItemId(string? partitionKeyHint = "")
        => NewId("mcpr", partitionKeyHint);

    /// <summary>Generates a new MCP approval response item ID with the <c>mcpa</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An MCP approval response item ID in the format <c>mcpa_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpApprovalResponseItemId(string? partitionKeyHint = "")
        => NewId("mcpa", partitionKeyHint);

    /// <summary>Generates a new compaction item ID with the <c>cmp</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A compaction item ID in the format <c>cmp_{partitionKey}{entropy}</c>.</returns>
    public static string NewCompactionItemId(string? partitionKeyHint = "")
        => NewId("cmp", partitionKeyHint);

    /// <summary>Generates a new workflow action output item ID with the <c>wfa</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A workflow action output item ID in the format <c>wfa_{partitionKey}{entropy}</c>.</returns>
    public static string NewWorkflowActionItemId(string? partitionKeyHint = "")
        => NewId("wfa", partitionKeyHint);

    /// <summary>Generates a new output message item ID with the <c>om</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>An output message item ID in the format <c>om_{partitionKey}{entropy}</c>.</returns>
    public static string NewOutputMessageItemId(string? partitionKeyHint = "")
        => NewId("om", partitionKeyHint);

    /// <summary>Generates a new structured output item ID with the <c>fco</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A structured output item ID in the format <c>fco_{partitionKey}{entropy}</c>.</returns>
    public static string NewStructuredOutputItemId(string? partitionKeyHint = "")
        => NewId("fco", partitionKeyHint);

    /// <summary>Generates a new generic item ID with the <c>item</c> prefix.</summary>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A generic item ID in the format <c>item_{partitionKey}{entropy}</c>.</returns>
    public static string NewGenericItemId(string? partitionKeyHint = "")
        => NewId("item", partitionKeyHint);

    // ─── Item dispatch ──────────────────────────────────────────────

    /// <summary>
    /// Generates a correctly prefixed ID for the given <see cref="Models.Item"/> subtype.
    /// Each item type receives a distinct prefix so IDs are self-describing.
    /// </summary>
    /// <param name="item">The input item whose type determines the ID prefix.</param>
    /// <param name="partitionKeyHint">Optional existing ID for partition key propagation.</param>
    /// <returns>A new ID with the appropriate type-specific prefix, or <c>null</c> for non-convertible items.</returns>
    public static string? NewItemId(Models.Item item, string? partitionKeyHint = "")
    {
        return item switch
        {
            Models.ItemMessage => NewMessageItemId(partitionKeyHint),
            Models.ItemOutputMessage => NewOutputMessageItemId(partitionKeyHint),
            Models.ItemFunctionToolCall => NewFunctionCallItemId(partitionKeyHint),
            Models.FunctionCallOutputItemParam => NewFunctionCallOutputItemId(partitionKeyHint),
            Models.ItemCustomToolCall => NewCustomToolCallItemId(partitionKeyHint),
            Models.ItemCustomToolCallOutput => NewCustomToolCallOutputItemId(partitionKeyHint),
            Models.ItemComputerToolCall => NewComputerCallItemId(partitionKeyHint),
            Models.ComputerCallOutputItemParam => NewComputerCallOutputItemId(partitionKeyHint),
            Models.ItemFileSearchToolCall => NewFileSearchCallItemId(partitionKeyHint),
            Models.ItemWebSearchToolCall => NewWebSearchCallItemId(partitionKeyHint),
            Models.ItemImageGenToolCall => NewImageGenCallItemId(partitionKeyHint),
            Models.ItemCodeInterpreterToolCall => NewCodeInterpreterCallItemId(partitionKeyHint),
            Models.ItemLocalShellToolCall => NewLocalShellCallItemId(partitionKeyHint),
            Models.ItemLocalShellToolCallOutput => NewLocalShellCallOutputItemId(partitionKeyHint),
            Models.FunctionShellCallItemParam => NewFunctionShellCallItemId(partitionKeyHint),
            Models.FunctionShellCallOutputItemParam => NewFunctionShellCallOutputItemId(partitionKeyHint),
            Models.ApplyPatchToolCallItemParam => NewApplyPatchCallItemId(partitionKeyHint),
            Models.ApplyPatchToolCallOutputItemParam => NewApplyPatchCallOutputItemId(partitionKeyHint),
            Models.ItemMcpListTools => NewMcpListToolsItemId(partitionKeyHint),
            Models.ItemMcpToolCall => NewMcpCallItemId(partitionKeyHint),
            Models.ItemMcpApprovalRequest => NewMcpApprovalRequestItemId(partitionKeyHint),
            Models.MCPApprovalResponse => NewMcpApprovalResponseItemId(partitionKeyHint),
            Models.ItemReasoningItem => NewReasoningItemId(partitionKeyHint),
            Models.CompactionSummaryItemParam => NewCompactionItemId(partitionKeyHint),
            Models.ItemReferenceParam => null, // resolved externally
            _ => null,
        };
    }

    // ─── Utility methods ────────────────────────────────────────────

    /// <summary>
    /// Extracts the partition key from an existing ID. Supports both new-format
    /// (50-char body, partition key at start) and legacy-format (48-char body,
    /// partition key at end) IDs.
    /// </summary>
    /// <param name="id">The ID to extract the partition key from.</param>
    /// <returns>The partition key (18 chars for new format, 16 chars for legacy).</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="id"/> is null, empty, has no delimiter,
    /// or has an unexpected body length.
    /// </exception>
    public static string ExtractPartitionKey(string id)
    {
        if (!TryExtractPartitionKeyRaw(id, out var pk))
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("ID must not be null or empty.", nameof(id));
            if (!id.Contains('_'))
                throw new ArgumentException($"ID '{id}' has no '_' delimiter.", nameof(id));
            throw new ArgumentException($"ID '{id}' has unexpected body length.", nameof(id));
        }

        return pk;
    }

    /// <summary>
    /// Validates that an ID conforms to the expected format.
    /// </summary>
    /// <param name="id">The ID to validate.</param>
    /// <param name="error">
    /// When the method returns <c>false</c>, contains a description of the validation failure.
    /// When the method returns <c>true</c>, this is <c>null</c>.
    /// </param>
    /// <param name="allowedPrefixes">
    /// Optional set of allowed prefixes. When provided, the ID's prefix must be in this set.
    /// </param>
    /// <returns><c>true</c> if the ID is valid; <c>false</c> otherwise.</returns>
    public static bool IsValid(string? id, out string? error, string[]? allowedPrefixes = null)
    {
        if (string.IsNullOrEmpty(id))
        {
            error = "ID must not be null or empty.";
            return false;
        }

        var delimiterIndex = id.IndexOf('_');
        if (delimiterIndex < 0)
        {
            error = $"ID '{id}' has no '_' delimiter.";
            return false;
        }

        var prefix = id[..delimiterIndex];
        if (prefix.Length == 0)
        {
            error = "ID has an empty prefix.";
            return false;
        }

        var body = id[(delimiterIndex + 1)..];
        if (body.Length != NewFormatBodyLength && body.Length != LegacyBodyLength)
        {
            error = $"ID '{id}' has unexpected body length {body.Length} (expected {NewFormatBodyLength} or {LegacyBodyLength}).";
            return false;
        }

        if (allowedPrefixes is not null && !Array.Exists(allowedPrefixes, p => p == prefix))
        {
            error = $"ID prefix '{prefix}' is not in the allowed set [{string.Join(", ", allowedPrefixes)}].";
            return false;
        }

        error = null;
        return true;
    }

    // ─── Private helpers ────────────────────────────────────────────

    /// <summary>
    /// Generates a fresh partition key: 8 random bytes → 16 lowercase hex + "00".
    /// </summary>
    private static string GeneratePartitionKey()
    {
        var bytes = RandomNumberGenerator.GetBytes(8);
        return string.Concat(Convert.ToHexString(bytes).ToLowerInvariant(), PartitionKeySuffix);
    }

    /// <summary>
    /// Generates 32 alphanumeric characters from cryptographic random bytes
    /// via Base64 encoding and filtering.
    /// </summary>
    private static string GenerateEntropy()
    {
        // We need 32 alphanumeric chars. Base64 is ~75% alphanumeric (after removing +, /, =).
        // Start with enough bytes to usually get 32 alphanumeric chars in one pass.
        var bufferSize = 48;
        Span<char> result = stackalloc char[EntropyLength];
        var filled = 0;

        while (filled < EntropyLength)
        {
            var bytes = RandomNumberGenerator.GetBytes(bufferSize);
            var base64 = Convert.ToBase64String(bytes);

            foreach (var c in base64)
            {
                if (filled >= EntropyLength)
                    break;

                if (char.IsLetterOrDigit(c))
                    result[filled++] = c;
            }
        }

        return new string(result);
    }

    /// <summary>
    /// Tries to extract the partition key from an ID without throwing.
    /// Returns the raw partition key string matching the format:
    /// - New format (50-char body): first 18 chars
    /// - Legacy format (48-char body): last 16 chars
    /// </summary>
    private static bool TryExtractPartitionKeyRaw(string? id, out string partitionKey)
    {
        partitionKey = "";

        if (string.IsNullOrEmpty(id))
            return false;

        var delimiterIndex = id.IndexOf('_');
        if (delimiterIndex < 0)
            return false;

        var body = id[(delimiterIndex + 1)..];

        if (body.Length == NewFormatBodyLength)
        {
            partitionKey = body[..PartitionKeyTotalLength];
            return true;
        }

        if (body.Length == LegacyBodyLength)
        {
            partitionKey = body[^LegacyPartitionKeyLength..];
            return true;
        }

        return false;
    }
}
