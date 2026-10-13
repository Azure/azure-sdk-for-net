// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>Tracks the replaceable framework-default credential registration.</summary>
internal sealed class TaskCredentialRegistrationState
{
    public ServiceDescriptor? DefaultDescriptor { get; set; }
}
