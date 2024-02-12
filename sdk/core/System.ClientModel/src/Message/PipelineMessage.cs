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
        ResponseClassifier = PipelineMessageClassifier.Default;
    }

    public PipelineRequest Request { get; }

    public PipelineResponse? Response
    {
        get;

        // Set internally by the transport.
        protected internal set;
    }

    public PipelineResponse? ExtractResponse()
    {
        PipelineResponse? response = Response;
        Response = null;
        return response;
    }

    internal void AssertResponse()
    {
        if (Response is null)
        {
            throw new InvalidOperationException($"'{nameof(Response)}' property is not set on message.");
        }
    }

    #region Pipeline invocation options

    public CancellationToken CancellationToken
    {
        get;

        // Set internally by RequestOptions.Apply
        protected internal set;
    }

    /// <summary>
    /// Gets or sets the message classifier used by the client pipeline to
    /// determine whether the response from the service should be considered
    /// an error, and populate the PipelineMessage.Response.IsError property.
    ///
    /// It is expected that this property will be set once in the client's
    /// service method with a classifier created from the service API's
    /// published success codes. Setting this value outside the service method
    /// will override the client-specified classifier and should be done at the
    /// caller's risk.
    /// </summary>
    //
    // In addition to the above comment visible to client-authors and end-users,
    // ClientModel maintainers should be aware that since MessageClassifiers
    // are not composable, we must not add another way to set a
    // MessageClassifier on the client, i.e. a public MessageClasifier property
    // on PipelineOptions or RequestOptions.  If we did, we would have to use
    // one or the other and it would not be transparent to the end-user which
    // one was in effect. Instead, we can add AddClassifier APIs like the ones
    // on Azure.Core's RequestContext that either add success/error codes to
    // the client-provided classifier or compose a chain of classification
    // handlers that preserve the functionality of the client-provided classifier
    // at the end of the chain.
    public PipelineMessageClassifier ResponseClassifier { get; set; }

    public void Apply(RequestOptions options)
    {
        // This design moves the client-author API (options.Apply) off the
        // client-user type RequestOptions.  Its only purpose is to call through to
        // the internal options.Apply method.
        options.Apply(this);
    }

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

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            PipelineResponse? response = Response;
            response?.Dispose();
            Response = null;

            PipelineRequest request = Request;
            request?.Dispose();

            _propertyBag.Dispose();

            _disposed = true;
        }
    }

    #endregion
}
