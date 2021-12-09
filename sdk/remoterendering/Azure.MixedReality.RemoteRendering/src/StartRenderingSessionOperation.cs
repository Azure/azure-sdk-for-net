// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Operation which represents the starting of a session.
    /// It is returned by StartSession, but you can also construct a StartSessionOperation for a sessionId which already exists.
    /// </summary>
    public class StartRenderingSessionOperation : Operation<RenderingSession>
    {
        private RemoteRenderingClient _client;
        private Response<RenderingSession> _response;

        /// <summary>
        /// Construct a StartSessionOperation from a session which already exists.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="client"></param>
        public StartRenderingSessionOperation(string sessionId, RemoteRenderingClient client)
        {
            _client = client;
            _response = client.GetSessionInternal(sessionId, $"{nameof(StartRenderingSessionOperation)}.{nameof(StartRenderingSessionOperation)}");
        }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        internal StartRenderingSessionOperation(RemoteRenderingClient client, Response<RenderingSession> response)
        {
            _client = client;
            _response = response;
        }

        /// <inheritdoc />
        public override string Id => _response.Value.SessionId;

        /// <inheritdoc />
        public override RenderingSession Value
        {
            get
            {
                return _response.Value;
            }
        }

        /// <inheritdoc />
        public override bool HasCompleted
        {
            get { return (_response.Value.Status != RenderingSessionStatus.Starting); }
        }

        /// <inheritdoc />
        public override bool HasValue
        {
            get { return true; }
        }

        /// <inheritdoc />
        public override Response GetRawResponse()
        {
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                _response = _client.GetSessionInternal(_response.Value.SessionId, $"{nameof(StartRenderingSessionOperation)}.{nameof(UpdateStatus)}", cancellationToken);
            }
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public async override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                _response = await _client.GetSessionInternalAsync(_response.Value.SessionId, $"{nameof(StartRenderingSessionOperation)}.{nameof(UpdateStatus)}", cancellationToken).ConfigureAwait(false);
            }
            return _response.GetRawResponse();
        }

        /// <inheritdoc />
        public async override ValueTask<Response<RenderingSession>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            int pollingPeriodInSeconds = (_response.Value.Size == RenderingServerSize.Standard) ? 2 : 10;
            return await WaitForCompletionAsync(TimeSpan.FromSeconds(pollingPeriodInSeconds), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async override ValueTask<Response<RenderingSession>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (HasCompleted)
                {
                    break;
                }
                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
            return _response;
        }

        /// <summary> Initializes a new instance of StartRenderingSessionOperation for mocking. </summary>
        protected StartRenderingSessionOperation()
        {
        }
    }
}
