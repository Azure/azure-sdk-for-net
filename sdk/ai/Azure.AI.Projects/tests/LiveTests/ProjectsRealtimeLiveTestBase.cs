// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.LiveTests;

/// <summary>
/// Base class for Voice Agent realtime streaming live tests. These tests exercise
/// <see cref="ProjectsRealtimeSessionClient"/> against the real Foundry service; the realtime
/// protocol cannot be meaningfully recorded/played back over HTTP, so every test here only runs
/// with CLIENTMODEL_TEST_MODE=Live.
/// </summary>
[NonParallelizable]
[LiveOnly]
public class ProjectsRealtimeLiveTestBase : AgentsTestBase
{
    public ProjectsRealtimeLiveTestBase(bool isAsync) : base(isAsync)
    {
    }
}
