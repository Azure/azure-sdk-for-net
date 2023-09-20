// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineMessage
{
    /// <summary>
    /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="PipelineMessage"/> processing.
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    public IResponse? Response { get; set; }

    public abstract void SetRequestHeader(string key, string value);

    public abstract void SetRequestContent(BinaryData content);

    public abstract bool TryGetRequestHeader(string name, [NotNullWhen(true)] out string? value);

    public abstract bool RemoveRequestHeader(string name);
}
