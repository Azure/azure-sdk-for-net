// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Rooms
{
    /// <summary>
    /// The Azure Communication Services Rooms client.
    /// </summary>
    public class RoomsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal RoomsRestClient RoomsServiceClient { get; }

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="connectionString"></param>
        public RoomsClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new RoomsClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="options"></param>
        public RoomsClient(string connectionString, RoomsClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new RoomsClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="keyCredential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, AzureKeyCredential keyCredential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new RoomsClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="tokenCredential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, TokenCredential tokenCredential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new RoomsClientOptions())
        { }

        #endregion

        #region private constructors

        private RoomsClient(ConnectionString connectionString, RoomsClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private RoomsClient(string endpoint, TokenCredential tokenCredential, RoomsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private RoomsClient(string endpoint, AzureKeyCredential keyCredential, RoomsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private RoomsClient(string endpoint, HttpPipeline httpPipeline, RoomsClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RoomsServiceClient = new RoomsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        protected RoomsClient()
        {
            _clientDiagnostics = null!;
            RoomsServiceClient = null!;
        }

        /// <summary>
        /// Creates a new room asynchronously.
        /// </summary>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="roomJoinPolicy"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> CreateRoomAsync(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, RoomJoinPolicy? roomJoinPolicy = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Guid repeatabilityRequestId = Guid.NewGuid();
                DateTimeOffset repeatabilityFirstSent = DateTimeOffset.UtcNow;
                Response<RoomModelInternal> createRoomResponseInternal =
                    await RoomsServiceClient.CreateRoomAsync(repeatabilityRequestId, repeatabilityFirstSent, validFrom, validUntil, roomJoinPolicy, participants == null ? null : participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(createRoomResponseInternal.Value), createRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new room.
        /// </summary>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="roomJoinPolicy"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> CreateRoom(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, RoomJoinPolicy? roomJoinPolicy = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Guid repeatabilityRequestId = Guid.NewGuid();
                DateTimeOffset repeatabilityFirstSent = DateTimeOffset.UtcNow;
                Response<RoomModelInternal> createRoomResponseInternal =
                     RoomsServiceClient.CreateRoom(repeatabilityRequestId, repeatabilityFirstSent, validFrom, validUntil, roomJoinPolicy, participants == null ? null : participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken);
                return Response.FromValue(new CommunicationRoom(createRoomResponseInternal.Value), createRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates a room asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="roomJoinPolicy"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> UpdateRoomAsync(string roomId, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, RoomJoinPolicy? roomJoinPolicy = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<RoomModelInternal> updateRoomResponseInternal =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, validFrom, validUntil, roomJoinPolicy, participants == null ? null : participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(updateRoomResponseInternal.Value), updateRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="roomJoinPolicy"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<CommunicationRoom> UpdateRoom(string roomId, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, RoomJoinPolicy? roomJoinPolicy = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<RoomModelInternal> updateRoomResponseInternal =
                    RoomsServiceClient.UpdateRoom(roomId, validFrom, validUntil, roomJoinPolicy, participants == null ? null : participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken);
                return Response.FromValue(new CommunicationRoom(updateRoomResponseInternal.Value), updateRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a room by id asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> GetRoomAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRoom)}");
            scope.Start();
            try
            {
                Response<RoomModelInternal> getRoomResponseInternal =
                    await RoomsServiceClient.GetRoomAsync(roomId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(getRoomResponseInternal.Value), getRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<CommunicationRoom> GetRoom(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRoom)}");
            scope.Start();
            try
            {
                Response<RoomModelInternal> getRoomResponseInternal =
                    RoomsServiceClient.GetRoom(roomId, cancellationToken);
                return Response.FromValue(new CommunicationRoom(getRoomResponseInternal.Value), getRoomResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a room by id asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{Response}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> DeleteRoomAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(DeleteRoom)}");
            scope.Start();
            try
            {
                return await RoomsServiceClient.DeleteRoomAsync(roomId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a room by id.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response DeleteRoom(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(DeleteRoom)}");
            scope.Start();
            try
            {
                return RoomsServiceClient.DeleteRoom(roomId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #region Participants Operations

        /// <summary>
        /// Gets room participants asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<ParticipantsCollection>> GetParticipantsAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> getParticipantsResponseInternal =
                    await RoomsServiceClient.GetParticipantsAsync(roomId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ParticipantsCollection(getParticipantsResponseInternal.Value.Participants), getParticipantsResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<ParticipantsCollection> GetParticipants(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> getParticipantsResponseInternal =
                    RoomsServiceClient.GetParticipants(roomId, cancellationToken);
                return Response.FromValue(new ParticipantsCollection(getParticipantsResponseInternal.Value.Participants), getParticipantsResponseInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add Participants to a Room asynchronously
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> AddParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> addParticipantsResponseInternal =
                    await RoomsServiceClient.AddParticipantsAsync(roomId, participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken).ConfigureAwait(false);

                return addParticipantsResponseInternal.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add Participants to a Room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response AddParticipants(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> addParticipantsResponseInternal =
                    RoomsServiceClient.AddParticipants(roomId, participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken);

                return addParticipantsResponseInternal.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update Participants in a Room asynchronously
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> UpdateParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> updateParticipantsResponseInternal =
                    await RoomsServiceClient.UpdateParticipantsAsync(roomId, participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken).ConfigureAwait(false);

                return updateParticipantsResponseInternal.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update Participants in a Room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response UpdateParticipants(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateParticipants)}");
            scope.Start();
            try
            {
                Response<ParticipantsCollectionInternal> updateParticipantsResponseInternal =
                     RoomsServiceClient.UpdateParticipants(roomId, participants.Select(x => x.ToRoomParticipantInternal()), cancellationToken);
                return updateParticipantsResponseInternal.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="communicationIdentifiers"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response RemoveParticipants(string roomId, IEnumerable<CommunicationIdentifier> communicationIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                List<RoomParticipantInternal> participants = new List<RoomParticipantInternal>();
                foreach (var communicationIdentifier in communicationIdentifiers)
                {
                    var participant = new RoomParticipant(communicationIdentifier);
                    participants.Add(participant.ToRoomParticipantInternal());
                }

                Response<ParticipantsCollectionInternal> removeParticipantsResponse =
                RoomsServiceClient.RemoveParticipants(roomId, participants, cancellationToken);
                return removeParticipantsResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete room participants async.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="communicationIdentifiers"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response> RemoveParticipantsAsync(string roomId, IEnumerable<CommunicationIdentifier> communicationIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                List<RoomParticipantInternal> participants = new List<RoomParticipantInternal>();
                foreach (var communicationIdentifier in communicationIdentifiers)
                {
                    var participant = new RoomParticipant(communicationIdentifier);
                    participants.Add(participant.ToRoomParticipantInternal());
                }

                Response<ParticipantsCollectionInternal> removeParticipantsResponse =
                await RoomsServiceClient.RemoveParticipantsAsync(roomId, participants, cancellationToken).ConfigureAwait(false);
                return removeParticipantsResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion
    }
}
