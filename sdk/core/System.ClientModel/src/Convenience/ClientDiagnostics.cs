// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides distributed tracing support for client libraries built on System.ClientModel.
/// This class mirrors the API of Azure.Core.Pipeline.ClientDiagnostics to allow shared
/// code generation patterns between Azure and non-Azure clients.
/// </summary>
/// <remarks>
/// This class is intended to be used by client library authors only.
/// Applications should use the System.Diagnostics package directly for custom tracing.
/// </remarks>
public class ClientDiagnostics : DiagnosticScopeFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="ClientDiagnostics"/>.
    /// </summary>
    /// <param name="options">The client pipeline options containing tracing configuration.</param>
    /// <param name="suppressNestedClientActivities">
    /// Whether to suppress nested client activities. When true (recommended for new clients),
    /// nested Azure SDK client method calls will not create additional spans.
    /// </param>
    public ClientDiagnostics(ClientPipelineOptions options, bool suppressNestedClientActivities = true)
        : base(
            options.GetType().Namespace ?? "UnknownNamespace",
            options.EnableDistributedTracing ?? true,
            suppressNestedClientActivities)
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="ClientDiagnostics"/> with explicit namespace.
    /// </summary>
    /// <param name="clientNamespace">The namespace of the client.</param>
    /// <param name="options">The client pipeline options containing tracing configuration.</param>
    /// <param name="suppressNestedClientActivities">
    /// Whether to suppress nested client activities.
    /// </param>
    public ClientDiagnostics(string clientNamespace, ClientPipelineOptions options, bool suppressNestedClientActivities = true)
        : base(
            clientNamespace,
            options.EnableDistributedTracing ?? true,
            suppressNestedClientActivities)
    {
    }
}
