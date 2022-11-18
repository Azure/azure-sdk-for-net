// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// A helper class used to build long-running operation instances. In order to use this helper:
    /// <list type="number">
    ///   <item>Make sure your LRO implements the <see cref="IOperation"/> interface.</item>
    ///   <item>Add a private <see cref="OperationInternal"/> field to your LRO, and instantiate it during construction.</item>
    ///   <item>Delegate method calls to the <see cref="OperationInternal"/> implementations.</item>
    /// </list>
    /// Supported members:
    /// <list type="bullet">
    ///   <item>
    ///     <description><see cref="OperationInternalBase.HasCompleted"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.RawResponse"/>, used for <see cref="Operation.GetRawResponse"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.UpdateStatus"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.UpdateStatusAsync(CancellationToken)"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.WaitForCompletionResponseAsync(CancellationToken)"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.WaitForCompletionResponseAsync(TimeSpan, CancellationToken)"/></description>
    ///   </item>
    /// </list>
    /// </summary>
    internal class OperationInternal : OperationInternalBase
    {
        // To minimize code duplication and avoid introduction of another type,
        // OperationInternal delegates implementation to the OperationInternal<VoidValue>.
        // VoidValue is a private empty struct which only purpose is to be used as generic parameter.
        private readonly OperationInternal<VoidValue> _internalOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final successful state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        public static OperationInternal Succeeded(Response rawResponse) => new(OperationState.Success(rawResponse));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final failed state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        /// <param name="operationFailedException">The exception that will be thrown by <c>UpdateStatusAsync</c>.</param>
        public static OperationInternal Failed(Response rawResponse, RequestFailedException operationFailedException) => new(OperationState.Failure(rawResponse, operationFailedException));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class.
        /// </summary>
        /// <param name="clientDiagnostics">Used for diagnostic scope and exception creation. This is expected to be the instance created during the construction of your main client.</param>
        /// <param name="operation">The long-running operation making use of this class. Passing "<c>this</c>" is expected.</param>
        /// <param name="rawResponse">
        /// The initial value of <see cref="OperationInternalBase.RawResponse"/>. Usually, long-running operation objects can be instantiated in two ways:
        /// <list type="bullet">
        ///   <item>
        ///   When calling a client's "<c>Start&lt;OperationName&gt;</c>" method, a service call is made to start the operation, and an <see cref="Operation"/> instance is returned.
        ///   In this case, the response received from this service call can be passed here.
        ///   </item>
        ///   <item>
        ///   When a user instantiates an <see cref="Operation"/> directly using a public constructor, there's no previous service call. In this case, passing <c>null</c> is expected.
        ///   </item>
        /// </list>
        /// </param>
        /// <param name="operationTypeName">
        /// The type name of the long-running operation making use of this class. Used when creating diagnostic scopes. If left <c>null</c>, the type name will be inferred based on the
        /// parameter <paramref name="operation"/>.
        /// </param>
        /// <param name="scopeAttributes">The attributes to use during diagnostic scope creation.</param>
        /// <param name="fallbackStrategy">The fallback delay strategy when Retry-After header is not present.  When it is present, the longer of the two delays will be used. Default is <see cref="ConstantDelayStrategy"/>.</param>
        public OperationInternal(
            ClientDiagnostics clientDiagnostics,
            IOperation operation,
            Response? rawResponse,
            string? operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null,
            DelayStrategy? fallbackStrategy = null)
            :base(clientDiagnostics, operationTypeName ?? operation.GetType().Name, scopeAttributes, fallbackStrategy)
        {
            _internalOperation = new OperationInternal<VoidValue>(clientDiagnostics, new OperationToOperationOfTProxy(operation), rawResponse, operationTypeName ?? operation.GetType().Name, scopeAttributes, fallbackStrategy);
        }

        private OperationInternal(OperationState finalState)
            :base(finalState.RawResponse)
        {
            _internalOperation = finalState.HasSucceeded
                ? OperationInternal<VoidValue>.Succeeded(finalState.RawResponse, default)
                : OperationInternal<VoidValue>.Failed(finalState.RawResponse, finalState.OperationFailedException!);
        }

        public static OperationInternal Create(
            string id,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string? operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null,
            DelayStrategy? fallbackStrategy = null,
            string? interimApiVersion = null)
        {
            var lroDetails = BinaryData.FromBytes(Convert.FromBase64String(id)).ToObjectFromJson<Dictionary<string, string>>();

            if (lroDetails.TryGetValue("FinalResponse", out string? finalResponse))
            {
                Response response = JsonSerializer.Deserialize<DecodedResponse>(finalResponse)!;
                return OperationInternal.Succeeded(response);
            }
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, id, interimApiVersion);
            return new OperationInternal(clientDiagnostics, nextLinkOperation, null, operationTypeName, scopeAttributes, fallbackStrategy);
        }

        public override Response RawResponse => _internalOperation.RawResponse;

        public override bool HasCompleted => _internalOperation.HasCompleted;

        protected override async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken) =>
            async ? await _internalOperation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : _internalOperation.UpdateStatus(cancellationToken);

        public string GetOperationId()
        {
            return _internalOperation.GetOperationId();
        }

        // Wrapper type that converts OperationState to OperationState<T> and can be passed to `OperationInternal<T>` constructor.
        private class OperationToOperationOfTProxy : IOperation<VoidValue>
        {
            private readonly IOperation _operation;

            public OperationToOperationOfTProxy(IOperation operation)
            {
                _operation = operation;
            }

            public async ValueTask<OperationState<VoidValue>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
            {
                var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
                if (!state.HasCompleted)
                {
                    return OperationState<VoidValue>.Pending(state.RawResponse);
                }

                if (state.HasSucceeded)
                {
                    return OperationState<VoidValue>.Success(state.RawResponse, new VoidValue());
                }

                return OperationState<VoidValue>.Failure(state.RawResponse, state.OperationFailedException);
            }

            public string GetOperationId()
            {
                return _operation.GetOperationId();
            }
        }

        [JsonConverter(typeof(DecodedResponseConverter))]
        internal class DecodedResponse : Response
        {
    #nullable disable
            private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            public DecodedResponse()
            {
            }

            internal DecodedResponse(int status, string reasonPhrase, Stream contentStream, string clientRequestId, bool isError, Dictionary<string, List<string>> headers)
            {
                Status = status;
                ReasonPhrase = reasonPhrase;
                ContentStream = contentStream;
                ClientRequestId = clientRequestId;
                _isError = isError;
                _headers = headers;
            }

            internal static DecodedResponse DeserializeDecodedResponse(JsonElement element)
            {
                int status = default;
                Optional<string> reasonPhrase = default;
                Stream contentStream = new MemoryStream();
                Optional<string> clientRequestId = default;
                Optional<bool> isError = default;
                Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("Status"))
                    {
                        status = property.Value.GetInt32();
                        continue;
                    }
                    if (property.NameEquals("ReasonPhrase"))
                    {
                        reasonPhrase = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("ContentStream"))
                    {
                        var content = BinaryData.FromObjectAsJson(property.Value);
                        if (content != null)
                        {
                            content.ToStream().CopyTo(contentStream);
                            contentStream.Position = 0;
                        }
                        continue;
                    }
                    if (property.NameEquals("ClientRequestId"))
                    {
                        clientRequestId = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("IsError"))
                    {
                        isError = property.Value.GetBoolean();
                        continue;
                    }
                    if (property.NameEquals("Headers"))
                    {
                        List<HttpHeader> array = new List<HttpHeader>();
                        foreach (var item in property.Value.EnumerateArray())
                        {
                            string name = default;
                            string value = default;
                            foreach (var property0 in item.EnumerateObject())
                            {
                                if (property0.NameEquals("Name"))
                                {
                                    name = property0.Value.GetString();
                                    continue;
                                }
                                if (property0.NameEquals("Value"))
                                {
                                    value = property0.Value.GetString();
                                    continue;
                                }
                            }
                            array.Add(new HttpHeader(name, value));
                        }
                        foreach (var item in array)
                        {
                            if (!headers.TryGetValue(item.Name, out List<string> values))
                            {
                                headers[item.Name] = values = new List<string>();
                            }
                            values.Add(item.Value);
                        }
                        continue;
                    }
                }
                return new DecodedResponse(status, reasonPhrase, contentStream, clientRequestId, isError, headers);
            }

            internal partial class DecodedResponseConverter : JsonConverter<DecodedResponse>
            {
                public override void Write(Utf8JsonWriter writer, DecodedResponse model, JsonSerializerOptions options)
                {
                    writer.WriteObjectValue(model);
                }
                public override DecodedResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    using var document = JsonDocument.ParseValue(ref reader);
                    return DeserializeDecodedResponse(document.RootElement);
                }
            }

            public override int Status { get; }

            public override string ReasonPhrase { get; }

            public override Stream ContentStream { get; set; }

            public override string ClientRequestId { get; set; }

            private bool? _isError;
            public override bool IsError { get => _isError ?? base.IsError; }
            public void SetIsError(bool value) => _isError = value;

            public bool IsDisposed { get; private set; }

            public void SetContent(byte[] content)
            {
                ContentStream = new MemoryStream(content, 0, content.Length, false, true);
            }

            public DecodedResponse SetContent(string content)
            {
                SetContent(Encoding.UTF8.GetBytes(content));
                return this;
            }

            public DecodedResponse AddHeader(string name, string value)
            {
                return AddHeader(new HttpHeader(name, value));
            }

            public DecodedResponse AddHeader(HttpHeader header)
            {
                if (!_headers.TryGetValue(header.Name, out List<string> values))
                {
                    _headers[header.Name] = values = new List<string>();
                }

                values.Add(header.Value);
                return this;
            }

    #if HAS_INTERNALS_VISIBLE_CORE
            internal
    #endif
            protected override bool TryGetHeader(string name, out string value)
            {
                if (_headers.TryGetValue(name, out List<string> values))
                {
                    value = JoinHeaderValue(values);
                    return true;
                }

                value = null;
                return false;
            }

    #if HAS_INTERNALS_VISIBLE_CORE
            internal
    #endif
            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                var result = _headers.TryGetValue(name, out List<string> valuesList);
                values = valuesList;
                return result;
            }

    #if HAS_INTERNALS_VISIBLE_CORE
            internal
    #endif
            protected override bool ContainsHeader(string name)
            {
                return TryGetHeaderValues(name, out _);
            }

    #if HAS_INTERNALS_VISIBLE_CORE
            internal
    #endif
            protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, JoinHeaderValue(h.Value)));

            private static string JoinHeaderValue(IEnumerable<string> values)
            {
                return string.Join(",", values);
            }

            public override void Dispose()
            {
                IsDisposed = true;
                GC.SuppressFinalize(this);
            }
    #nullable enable
        }
    }

    /// <summary>
    /// An interface used by <see cref="OperationInternal"/> for making service calls and updating state. It's expected that
    /// your long-running operation classes implement this interface.
    /// </summary>
    internal interface IOperation
    {
        /// <summary>
        /// Calls the service and updates the state of the long-running operation. Properties directly handled by the
        /// <see cref="OperationInternal"/> class, such as <see cref="OperationInternalBase.RawResponse"/>
        /// don't need to be updated. Operation-specific properties, such as "<c>CreateOn</c>" or "<c>LastModified</c>",
        /// must be manually updated by the operation implementing this method.
        /// <example>Usage example:
        /// <code>
        ///   async ValueTask&lt;OperationState&gt; IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)<br/>
        ///   {<br/>
        ///     Response&lt;R&gt; response = async ? &lt;async service call&gt; : &lt;sync service call&gt;;<br/>
        ///     if (&lt;operation succeeded&gt;) return OperationState.Success(response.GetRawResponse(), &lt;parse response&gt;);<br/>
        ///     if (&lt;operation failed&gt;) return OperationState.Failure(response.GetRawResponse());<br/>
        ///     return OperationState.Pending(response.GetRawResponse());<br/>
        ///   }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="async"><c>true</c> if the call should be executed asynchronously. Otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A structure indicating the current operation state. The <see cref="OperationState"/> structure must be instantiated by one of
        /// its static methods:
        /// <list type="bullet">
        ///   <item>Use <see cref="OperationState.Success"/> when the operation has completed successfully.</item>
        ///   <item>Use <see cref="OperationState.Failure"/> when the operation has completed with failures.</item>
        ///   <item>Use <see cref="OperationState.Pending"/> when the operation has not completed yet.</item>
        /// </list>
        /// </returns>
        ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken);

        /// <summary>
        /// To get the Id of the operation for rehydration purpose.
        /// </summary>
        string GetOperationId();
    }

    /// <summary>
    /// A helper structure passed to <see cref="OperationInternal"/> to indicate the current operation state. This structure must be
    /// instantiated by one of its static methods, depending on the operation state:
    /// <list type="bullet">
    ///   <item>Use <see cref="OperationState.Success"/> when the operation has completed successfully.</item>
    ///   <item>Use <see cref="OperationState.Failure"/> when the operation has completed with failures.</item>
    ///   <item>Use <see cref="OperationState.Pending"/> when the operation has not completed yet.</item>
    /// </list>
    /// </summary>
    internal readonly struct OperationState
    {
        private OperationState(Response rawResponse, bool hasCompleted, bool hasSucceeded, RequestFailedException? operationFailedException)
        {
            RawResponse = rawResponse;
            HasCompleted = hasCompleted;
            HasSucceeded = hasSucceeded;
            OperationFailedException = operationFailedException;
        }

        public Response RawResponse { get; }

        public bool HasCompleted { get; }

        public bool HasSucceeded { get; }

        public RequestFailedException? OperationFailedException { get; }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has completed successfully.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Success(Response rawResponse)
        {
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
            return new OperationState(rawResponse, true, true, default);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has completed with failures.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <param name="operationFailedException">
        /// The exception to throw from <c>UpdateStatus</c> because of the operation failure. If left <c>null</c>,
        /// a default exception is created based on the <paramref name="rawResponse"/> parameter.
        /// </param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Failure(Response rawResponse, RequestFailedException? operationFailedException = null)
        {
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
            return new OperationState(rawResponse, true, false, operationFailedException);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has not completed yet.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Pending(Response rawResponse)
        {
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
            return new OperationState(rawResponse, false, default, default);
        }
    }
}
