// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.CallingServer.Models;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services CallContent client.
    /// </summary>
    public class CallContentClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient RestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallContentClient(string callConnectionId, ContentRestClient callContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            RestClient = callContentRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallContentClient"/> for mocking.</summary>
        protected CallContentClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual async Task<Response<PlayResponse>> PlayMediaAsync(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallContentClient)}.{nameof(PlayMedia)}");
            scope.Start();
            try
            {
                PlaySourceInternal sourceInternal = new PlaySourceInternal(playSource.SourceType);
                sourceInternal.PlaySourceId = playSource.PlaySourceId;

                PlayRequestInternal request = new PlayRequestInternal(sourceInternal, playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
                return await RestClient.PlayAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual Response<PlayResponse> PlayMedia(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallContentClient)}.{nameof(PlayMedia)}");
            scope.Start();
            try
            {
                PlaySourceInternal sourceInternal = new PlaySourceInternal(playSource.SourceType);
                sourceInternal.PlaySourceId = playSource.PlaySourceId;

                PlayRequestInternal request = new PlayRequestInternal(sourceInternal, playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
                return RestClient.Play(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<PlayResponse>> PlayMediaToAllAsync(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallContentClient)}.{nameof(PlayMediaToAll)}");
            scope.Start();
            try
            {
                return await PlayMediaAsync(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play to all participants.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<PlayResponse> PlayMediaToAll(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallContentClient)}.{nameof(PlayMediaToAll)}");
            scope.Start();
            try
            {
                return PlayMedia(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
