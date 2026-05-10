// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Options for configuring the Azure.Core HTTP pipeline
/// used by <see cref="FoundryStorageProvider"/> to communicate with the
/// Azure AI Foundry storage API.
/// <para>
/// Inheriting from <see cref="ClientOptions"/> provides automatic retry,
/// request ID, user-agent telemetry, logging, and distributed tracing.
/// </para>
/// </summary>
internal sealed class FoundryStorageClientOptions : ClientOptions
{
}
