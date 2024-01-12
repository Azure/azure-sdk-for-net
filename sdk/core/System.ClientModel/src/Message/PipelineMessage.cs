// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

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

    public PipelineMessageClassifier? MessageClassifier { get; protected internal set; }

    public void Apply(RequestOptions options, PipelineMessageClassifier? messageClassifier = default)
    {
        // This design moves the client-author API (options.Apply) off the
        // client-user type RequestOptions.
        options.Apply(this, messageClassifier);
    }

    public bool TryGetProperty(Type type, out object? value) =>
        _propertyBag.TryGetValue((ulong)type.TypeHandle.Value, out value);

    public void SetProperty(Type type, object value) =>
        _propertyBag.Set((ulong)type.TypeHandle.Value, value);

    #endregion

    #region Meta-data for pipeline processing

    internal int RetryCount { get; set; }

    internal bool BufferResponse { get; set; }

    internal TimeSpan? NetworkTimeout { get; set; }

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
