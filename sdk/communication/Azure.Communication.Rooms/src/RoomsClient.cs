// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.Rooms.Models;
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
        /// <param name="participants"></param>
        /// <param name="validUntil"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> CreateRoomAsync(IEnumerable<RoomParticipant> participants = default, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Response<CreateRoomResponse> createRoomResponse =
                    await RoomsServiceClient.CreateRoomAsync(_createRoomRequest(participants, validFrom, validUntil), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(createRoomResponse), createRoomResponse.GetRawResponse());
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
        /// <param name="participants"></param>
        /// <param name="validUntil"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> CreateRoom(IEnumerable<RoomParticipant> participants = default, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Response<CreateRoomResponse> createRoomResponse =
                     RoomsServiceClient.CreateRoom(_createRoomRequest(participants, validFrom, validUntil), cancellationToken);
                return Response.FromValue(new CommunicationRoom(createRoomResponse), createRoomResponse.GetRawResponse());
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
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> UpdateRoomAsync(string roomId, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<UpdateRoomResponse> updateRoomResponse =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, _updateRoomRequest(default, validFrom, validUntil), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
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
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<CommunicationRoom> UpdateRoom(string roomId, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<UpdateRoomResponse> updateRoomResponse =
                    RoomsServiceClient.UpdateRoom(roomId, _updateRoomRequest(default, validFrom, validUntil), cancellationToken);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
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
                Response<RoomModel> getRoomResponse =
                    await RoomsServiceClient.GetRoomAsync(roomId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(getRoomResponse), getRoomResponse.GetRawResponse());
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
                Response<RoomModel> getRoomResponse =
                    RoomsServiceClient.GetRoom(roomId, cancellationToken);
                return Response.FromValue(new CommunicationRoom(getRoomResponse), getRoomResponse.GetRawResponse());
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
        /// Add room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> AddParticipants(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var participant in participants)
                {
                    request.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    RoomsServiceClient.UpdateRoom(roomId, request, cancellationToken);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add room participants async.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response<CommunicationRoom>> AddParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var participant in participants)
                {
                    request.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, request, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> UpdateParticipants(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var participant in participants)
                {
                    request.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    RoomsServiceClient.UpdateRoom(roomId, request, cancellationToken);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update room participants async.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response<CommunicationRoom>> UpdateParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var participant in participants)
                {
                    request.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, request, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="communicationUsers"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> RemoveParticipants(string roomId, IEnumerable<string> communicationUsers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var communicationUser in communicationUsers)
                {
                    request.Participants.Add(communicationUser, null);
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    RoomsServiceClient.UpdateRoom(roomId, request, cancellationToken);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
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
        /// <param name="communicationUsers"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response<CommunicationRoom>> RemoveParticipantsAsync(string roomId, IEnumerable<string> communicationUsers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                UpdateRoomRequest request = new UpdateRoomRequest();
                foreach (var communicationUser in communicationUsers)
                {
                    request.Participants.Add(communicationUser, null);
                }

                Response<UpdateRoomResponse> updateRoomResponse =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, request, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CommunicationRoom(updateRoomResponse), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        private static CreateRoomRequest _createRoomRequest(IEnumerable<RoomParticipant> participants = default, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default)
        {
            CreateRoomRequest createRoomRequest = new CreateRoomRequest();

            if (validFrom != null && validFrom != default)
            {
                createRoomRequest.ValidFrom = validFrom;
            }

            if (validUntil != null && validUntil != default)
            {
                createRoomRequest.ValidUntil = validUntil;
            }

            if (participants != null)
            {
                foreach (var participant in participants)
                {
                    createRoomRequest.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }
            }

            return createRoomRequest;
        }

        private static UpdateRoomRequest _updateRoomRequest(IEnumerable<RoomParticipant> participants = default, DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default)
        {
            UpdateRoomRequest updateRoomRequest = new UpdateRoomRequest();

            if (validFrom != null && validFrom != default)
            {
                updateRoomRequest.ValidFrom = validFrom;
            }

            if (validUntil != null && validUntil != default)
            {
                updateRoomRequest.ValidUntil = validUntil;
            }

            if (participants != null && participants != default)
            {
                foreach (var participant in participants)
                {
                    updateRoomRequest.Participants.Add(participant.Identifier, participant.ToRoomParticipantInternal());
                }
            }

            return updateRoomRequest;
        }
    }
}
