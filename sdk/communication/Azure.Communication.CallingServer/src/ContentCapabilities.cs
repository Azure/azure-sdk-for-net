// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Content Capabilities for the call.
    /// </summary>
    public class ContentCapabilities
    {
        internal ContentRestClient _client;
        private string _callConnectionId;

        internal ContentCapabilities(string callConnectionId, ContentRestClient client)
        {
            _callConnectionId = callConnectionId;
            _client = client;
        }

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public async Task<Response<PlayResponse>> PlayAsync(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            PlayRequest request = new PlayRequest(playSource, playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
            return await _client.PlayAsync(_callConnectionId, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<PlayResponse>> PlayToAllAsync(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            return await PlayAsync(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public Response<PlayResponse> Play(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            PlayRequest request = new PlayRequest(playSource, playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
            return _client.Play(_callConnectionId, request, cancellationToken);
        }

        /// <summary>
        /// Play to all participants.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response<PlayResponse> PlayToAll(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            return Play(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
        }
    }
}
