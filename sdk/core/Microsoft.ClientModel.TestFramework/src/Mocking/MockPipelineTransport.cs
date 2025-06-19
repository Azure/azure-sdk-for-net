// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// A mock of <see cref="PipelineTransport"/> to use for testing.
/// </summary>
public class MockPipelineTransport : PipelineTransport
{
    private readonly Func<PipelineMessage, MockPipelineResponse> _responseFactory;
    private readonly bool _addDelay;
    private readonly object _syncObj = new object();

    internal AsyncGate<MockPipelineRequest, MockPipelineResponse> RequestGate { get; }

    /// <summary>
    /// Whether this transport expects a synchronous pipeline.
    /// </summary>
    public bool? ExpectSyncPipeline { get; set; } = true;

    /// <summary>
    /// A list of mock pipeline requests that have been sent.
    /// </summary>
    public List<MockPipelineRequest> Requests { get; } = new List<MockPipelineRequest>();

    /// <summary>
    /// An action invoked when a request is being sent.
    /// </summary>
    public Action<MockPipelineMessage>? OnSendingRequest { get; set; }

    /// <summary>
    /// An action invoked when a response is received.
    /// </summary>
    public Action<MockPipelineMessage>? OnReceivedResponse { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="MockPipelineTransport"/>, which always returns a 200 response code.
    /// </summary>
    public MockPipelineTransport() : this([200])
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="codes"></param>
    public MockPipelineTransport(params int[] codes)
    {
        Id = id;
        var requestIndex = 0;
        _responseFactory = _ => { return new MockPipelineResponse(codes[requestIndex++]); };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="responseFactory"></param>
    /// <param name="enableLogging"></param>
    /// <param name="loggerFactory"></param>
    /// <param name="addDelay"></param>
    public MockPipelineTransport(string id, Func<PipelineMessage, MockPipelineResponse> responseFactory, bool enableLogging = false, ILoggerFactory? loggerFactory = null, bool addDelay = false) : base(enableLogging, loggerFactory)
    {
        Id = id;
        _responseFactory = responseFactory;
        _addDelay = addDelay;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    protected override PipelineMessage CreateMessageCore()
    {
        return new MockPipelineMessage();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    protected override void ProcessCore(PipelineMessage message)
    {
        //Stamp(message, "Transport");

        OnSendingRequest?.Invoke((MockPipelineMessage)message);

        ((MockPipelineMessage)message).SetResponse(_responseFactory(message));

        if (_addDelay)
        {
            Task.Delay(TimeSpan.FromSeconds(4)).Wait();
        }

        OnReceivedResponse?.Invoke((MockPipelineMessage)message);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        //Stamp(message, "Transport");

        OnSendingRequest?.Invoke((MockPipelineMessage)message);

        ((MockPipelineMessage)message).SetResponse(_responseFactory(message));

        if (_addDelay)
        {
            await Task.Delay(TimeSpan.FromSeconds(4)).ConfigureAwait(false);
        }

        OnReceivedResponse?.Invoke((MockPipelineMessage)message);
    }

    //private void Stamp(PipelineMessage message, string prefix)
    //{
    //    List<string> values;

    //    if (message.TryGetProperty(typeof(ObservablePolicy), out object? prop) &&
    //        prop is List<string> list)
    //    {
    //        values = list;
    //    }
    //    else
    //    {
    //        values = new List<string>();
    //        message.SetProperty(typeof(ObservablePolicy), values);
    //    }

    //    values.Add($"{prefix}:{Id}");
    //}
}
