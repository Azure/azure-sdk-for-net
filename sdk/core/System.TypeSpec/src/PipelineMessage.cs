// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class PipelineMessage
{
    /// <summary>
    /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="PipelineMessage"/> processing.
    /// </summary>
    public CancellationToken CancellationToken { get; set; }
}
