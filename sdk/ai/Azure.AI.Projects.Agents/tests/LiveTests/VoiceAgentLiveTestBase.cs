// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.LiveTests;

/// <summary>
/// Base class for Voice Agent WebSocket streaming live tests. These tests exercise
/// <see cref="VoiceAgentSession"/> against the real Foundry service; the realtime protocol
/// cannot be meaningfully recorded/played back (see <see cref="VoiceAgentWebSocket"/>'s
/// AZC0004 suppression), so every test here only runs with CLIENTMODEL_TEST_MODE=Live.
/// </summary>
[NonParallelizable]
[LiveOnly]
public class VoiceAgentLiveTestBase : AgentsTestBase
{
    public VoiceAgentLiveTestBase(bool isAsync) : base(isAsync)
    {
    }
}
