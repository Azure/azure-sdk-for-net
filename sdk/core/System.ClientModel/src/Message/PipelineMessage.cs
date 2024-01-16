// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

// TODO: MessageClassifier and RequestOptions will come in a later PR.

public class PipelineMessage : IDisposable
{
    private ArrayBackedPropertyBag<ulong, object> _propertyBag;
    private bool _disposed;

    protected internal PipelineMessage(PipelineRequest request)
    {
        Argument.AssertNotNull(request, nameof(request));

        Request = request;
        _propertyBag = new ArrayBackedPropertyBag<ulong, object>();

        BufferResponse = true;
    }

    public PipelineRequest Request { get; }

    public PipelineResponse? Response
    {
        get;

        // Set internally by the transport.
        protected internal set;
    }

    #region Pipeline invocation options

    public CancellationToken CancellationToken { get; set; }

    public bool TryGetProperty(Type type, out object? value) =>
        _propertyBag.TryGetValue((ulong)type.TypeHandle.Value, out value);

    public void SetProperty(Type type, object value) =>
        _propertyBag.Set((ulong)type.TypeHandle.Value, value);

    #endregion

    #region Meta-data for pipeline processing

    internal int RetryCount { get; set; }

    /// <summary>
    /// Gets or sets the value indicating whether the response should be buffered
    /// in-memory by the pipeline. Defaults to true.
    /// </summary>
    public bool BufferResponse { get; set; }

    /// <summary>
    /// Gets or sets the network timeout value for this message.
    /// If <c>null</c>, the value set on the client's options will be used.
    /// Defaults to <c>null</c>.
    /// </summary>
    public TimeSpan? NetworkTimeout { get; set; }

    #endregion

    #region Per-request pipeline

    internal bool UseCustomRequestPipeline =>
        PerCallPolicies is not null ||
        PerTryPolicies is not null ||
        BeforeTransportPolicies is not null;

    internal PipelinePolicy[]? PerCallPolicies { get; set; }

    internal PipelinePolicy[]? PerTryPolicies { get; set; }

    internal PipelinePolicy[]? BeforeTransportPolicies { get; set; }

    #endregion

    internal void AssertResponse()
    {
        if (Response is null)
        {
            throw new InvalidOperationException("Response is not set on message.");
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var request = Request;
            request?.Dispose();

            _propertyBag.Dispose();

            var response = Response;
            if (response != null)
            {
                response.Dispose();
                Response = null;
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
