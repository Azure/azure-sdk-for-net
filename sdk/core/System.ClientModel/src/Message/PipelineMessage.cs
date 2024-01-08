// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

public class PipelineMessage : IDisposable
{
    private PipelineResponse? _response;
    private ArrayBackedPropertyBag<ulong, object> _propertyBag;
    private bool _disposed;

    protected internal PipelineMessage(PipelineRequest request)
    {
        Argument.AssertNotNull(request, nameof(request));

        Request = request;
        _propertyBag = new ArrayBackedPropertyBag<ulong, object>();
    }

    public PipelineRequest Request { get; }

    public PipelineResponse? Response
    {
        get => _response;

        // This is set internally by the transport.
        protected internal set => _response = value;
    }

    #region Pipeline invocation options

    public CancellationToken CancellationToken { get; set; }

    // TODO: Classifier and RequestOptions will come in a later PR.
    //public PipelineMessageClassifier? MessageClassifier { get; protected internal set; }

    //public void Apply(RequestOptions options, PipelineMessageClassifier? messageClassifier = default)
    //{
    //    // TODO: Add test to validate CancellationToken is set by Apply
    //    options.Apply(this, messageClassifier);
    //}

    public bool TryGetProperty(Type type, out object? value) =>
        _propertyBag.TryGetValue((ulong)type.TypeHandle.Value, out value);

    public void SetProperty(Type type, object value) =>
        _propertyBag.Set((ulong)type.TypeHandle.Value, value);

    #endregion

    #region Meta-data for pipeline processing

    internal int RetryCount { get; set; }

    #endregion

    #region Per-request pipeline

    internal bool CustomRequestPipeline =>
        PerCallPolicies is not null || PerTryPolicies is not null;

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

            // TODO: this means we return a disposed response to the end-user.
            // Would be nice to possibly introduce an OnMessageDiposed pattern
            // to notify the response that it needs to dispose network resources
            // without being officially disposed itself?
            var response = _response;
            if (response != null)
            {
                _response = null;
                response.Dispose();
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
