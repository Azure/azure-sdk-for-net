// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an HTTP message that can be sent from a
/// <see cref="ClientPipeline"/>.  <see cref="Request"/> holds the request sent
/// to the cloud service, and <see cref="Response"/> holds the response received
/// from the service.
/// </summary>
public class PipelineMessage : IDisposable
{
    private ArrayBackedPropertyBag<ulong, object> _propertyBag;
    private bool _disposed;

    /// <summary>
    /// Creates an instance of <see cref="PipelineMessage"/> with
    /// <see cref="Request"/> set to the provided <paramref name="request"/>.
    /// </summary>
    /// <param name="request">The <see cref="PipelineRequest"/> to set on this
    /// instance's <see cref="Request"/> property.</param>
    protected internal PipelineMessage(PipelineRequest request)
    {
        Argument.AssertNotNull(request, nameof(request));

        Request = request;
        _propertyBag = new ArrayBackedPropertyBag<ulong, object>();

        BufferResponse = true;
        ResponseClassifier = PipelineMessageClassifier.Default;
    }

    /// <summary>
    /// Gets the <see cref="PipelineRequest"/> to send to the service during
    /// the call to <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    public PipelineRequest Request { get; }

    /// <summary>
    /// Gets the <see cref="PipelineResponse"/> received from the service during
    /// the call to <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    public PipelineResponse? Response
    {
        get;

        // Set internally by the transport.
        protected internal set;
    }

    /// <summary>
    /// Returns the value of the <see cref="Response"/> property and transfers
    /// dispose ownership of the response to the caller. After calling this
    /// method, the <see cref="Response"/> property will be <code>null</code>
    /// and the caller will be responsible for disposing the returned value,
    /// which may hold a live network stream.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the <see cref="CancellationToken"/> used for the duration
    /// of the call to <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    public CancellationToken CancellationToken
    {
        get;

        // Set internally by RequestOptions.Apply
        protected internal set;
    }

    /// <summary>
    /// Gets or sets the <see cref="PipelineMessageClassifier"/> used by the
    /// <see cref="ClientPipeline"/> to determine whether the response received
    /// from the service is considered an error and populate the
    /// <see cref="PipelineResponse.IsError"/> on <see cref="Response"/>.
    ///
    /// This property is intended to be set in a client's service method to a
    /// a <see cref="PipelineMessageClassifier"/> that classifies responses as
    /// success responses based on the service API's published success codes.
    /// Setting this value outside the service method will override the
    /// client-specified classifier and may result in undesired behavior.
    /// </summary>
    public PipelineMessageClassifier ResponseClassifier { get; set; }

    /// <summary>
    /// Apply the options from the provided <see cref="RequestOptions"/> to
    /// this <see cref="PipelineMessage"/> instance. This method is intended to
    /// be called after the creation of the <see cref="PipelineMessage"/> and
    /// its <see cref="Request"/> is complete, and prior to the call to
    /// <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    /// <param name="options">The <see cref="RequestOptions"/> to apply to this
    /// <see cref="PipelineMessage"/> instance.</param>
    public void Apply(RequestOptions options)
    {
        // This design moves the client-author API (options.Apply) off the
        // client-user type RequestOptions.  Its only purpose is to call through to
        // the internal options.Apply method.
        options.Apply(this);
    }

    /// <summary>
    /// Attempts to get a property from the property bag for this
    /// <see cref="PipelineMessage"/> instance. Message properties are used to
    /// govern the behavior of specific policies in the
    /// <see cref="ClientPipeline"/>. Please refer to documentation for a
    /// specific <see cref="PipelinePolicy"/> to understand what properties it
    /// supports.
    /// </summary>
    /// <param name="key">The key for the property in the message's property
    /// bag.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns><c>true</c> if property exists; otherwise <c>false</c>.</returns>
    public bool TryGetProperty(Type key, out object? value) =>
        _propertyBag.TryGetValue((ulong)key.TypeHandle.Value, out value);

    /// <summary>
    /// Set a property in the property bag for this <see cref="PipelineMessage"/>
    /// instance. Message properties are used to govern the behavior of specific
    /// policies in the <see cref="ClientPipeline"/>. Please refer to
    /// documentation for a specific <see cref="PipelinePolicy"/> to understand
    /// what properties it supports.
    /// </summary>
    /// <param name="key">The key for the property in the message's property
    /// bag.</param>
    /// <param name="value">The value of the property.</param>
    public void SetProperty(Type key, object value) =>
        _propertyBag.Set((ulong)key.TypeHandle.Value, value);

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

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the
    /// <see cref="PipelineMessage"/> and optionally disposes of the managed
    /// resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and
    /// unmanaged resources; <c>false</c> to release only unmanaged resources.
    /// </param>
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
