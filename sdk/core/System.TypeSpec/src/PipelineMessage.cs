// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineMessage
{
    protected PipelineMessage(PipelineRequest request)
    {
        Request = request;
    }

    /// <summary>
    /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="PipelineMessage"/> processing.
    /// </summary>
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    public IResponse? Response { get; set; }

    public PipelineRequest Request { get; set; }
}

public abstract class PipelineRequest : IDisposable
{
    public abstract bool IsHttps { get; }
    public abstract string ClientRequestId { get; set; }

    public abstract void SetHeaderValue(string key, string value);

    public abstract void SetContent(BinaryData content);

    public abstract bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);

    public abstract bool RemoveHeaderValue(string name);

    public abstract void Dispose();
}