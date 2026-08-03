// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Voice Live Bridge Protocol constants shared by the codec and runtime.
/// </summary>
internal static class VoiceProtocolConstants
{
    /// <summary>The exact bridge protocol version this library implements.</summary>
    public const string ProtocolVersion = "1.0";

    // RFC 6455 close codes used by the typed voice layer.
    public const int CloseNormal = 1000;
    public const int CloseProtocolError = 1002;
    public const int CloseUnsupportedData = 1003;
    public const int ClosePolicyViolation = 1008;
    public const int CloseMessageTooBig = 1009;
    public const int CloseInternalError = 1011;

    // ID namespaces (prefix owner in parentheses).
    public const string EnvelopeIdPrefix = "m";   // each sender
    public const string InputItemPrefix = "in";   // bridge
    public const string ResponsePrefix = "r";     // library
    public const string OutputItemPrefix = "it";  // library
    public const string DtmfCollectionPrefix = "dc"; // library
    public const string HistoryItemPrefix = "hi"; // caller app / bridge

    // Bounded runtime limits that mirror the Python implementation.
    public const int MaxCallbackQueue = 128;
    public const int MaxSeenMessages = 4096;
    public const int MaxPendingProactive = 16;
    public const int MaxRecentResponses = 64;
    public const int MaxFrameBytes = 1024 * 1024;
    public const int MaxResponseItems = 1024;
    public const int MaxOutputItemChunks = 4096;
    public const int MaxOutputItemBytes = 900 * 1024;
    public const int MaxOutputItemEscapedBytes = MaxFrameBytes - 1024;
    public const int MaxResponseBytes = 8 * 1024 * 1024;
    public const double CleanupTimeoutSeconds = 5.0;
}
