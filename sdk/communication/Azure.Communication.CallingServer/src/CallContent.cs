// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Call Content Client.
    /// </summary>
    public class CallContent
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient ContentRestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallContent(string callConnectionId, ContentRestClient CallContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            ContentRestClient = CallContentRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallContent"/> for mocking.</summary>
        protected CallContent()
        {
            _clientDiagnostics = null;
            ContentRestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayAsync(FileSource fileSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(fileSource, playTo);

                return await ContentRestClient.PlayAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
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
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual Response Play(FileSource fileSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(fileSource, playTo);

                return ContentRestClient.Play(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static PlayRequestInternal CreatePlayRequest(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo)
        {
            if (playSource is FileSource fileSource)
            {
                PlaySourceInternal sourceInternal;
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.File);
                sourceInternal.FileSource = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceId = playSource.PlaySourceId;

                PlayRequestInternal request = new PlayRequestInternal(sourceInternal);
                request.PlayTo = playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList();

                return request;
            }
            else
            {
                throw new NotSupportedException(playSource.GetType().Name);
            }
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayToAllAsync(FileSource fileSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return await PlayAsync(fileSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
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
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response PlayToAll(FileSource fileSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return Play(fileSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> CancelAllMediaOperationsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return await ContentRestClient.CancelAllMediaOperationsAsync(CallConnectionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response CancelAllMediaOperations(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return ContentRestClient.CancelAllMediaOperations(CallConnectionId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
