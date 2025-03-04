// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        internal ParticipantsRestClient ParticipantsServiceClient { get; }

        #region public constructors - all arguments need null check
        #pragma warning disable AZC0007

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
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, AzureKeyCredential credential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new RoomsClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, TokenCredential credential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new RoomsClientOptions())
        { }

        #pragma warning restore AZC0007
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
            RoomsServiceClient = new RoomsRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
            ParticipantsServiceClient = new ParticipantsRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class for mock.
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
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> CreateRoomAsync(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, IEnumerable<RoomParticipant> participants = null, CancellationToken cancellationToken = default)
        {
            return await CreateRoomAsync(new CreateRoomOptions { ValidFrom = validFrom, ValidUntil = validUntil, Participants = participants != null ? new List<RoomParticipant>(participants) : null }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new room asynchronously.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> CreateRoomAsync(CreateRoomOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForAddOrUpdate(options?.Participants);
                return await RoomsServiceClient.CreateAsync(options?.ValidFrom, options?.ValidUntil, options?.PstnDialOutEnabled, participantDictionary, cancellationToken).ConfigureAwait(false);
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
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> CreateRoom(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, IEnumerable<RoomParticipant> participants = null, CancellationToken cancellationToken = default)
        {
            return CreateRoom(new CreateRoomOptions { ValidFrom = validFrom, ValidUntil = validUntil, Participants = participants != null ? new List<RoomParticipant>(participants) : null }, cancellationToken);
        }

        /// <summary>
        /// Creates a new room.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<CommunicationRoom> CreateRoom(CreateRoomOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForAddOrUpdate(options?.Participants);
                return RoomsServiceClient.Create(options?.ValidFrom, options?.ValidUntil, options?.PstnDialOutEnabled, participantDictionary, cancellationToken);
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
           return await UpdateRoomAsync(roomId, new UpdateRoomOptions { ValidFrom = validFrom, ValidUntil = validUntil }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a room asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<CommunicationRoom>> UpdateRoomAsync(string roomId, UpdateRoomOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                return await RoomsServiceClient.UpdateAsync(roomId, options?.ValidFrom, options?.ValidUntil, options?.PstnDialOutEnabled, cancellationToken).ConfigureAwait(false);
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
            return UpdateRoom(roomId, new UpdateRoomOptions { ValidFrom = validFrom, ValidUntil = validUntil }, cancellationToken);
        }

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="options?.Id"/> is null. </exception>
        public virtual Response<CommunicationRoom> UpdateRoom(string roomId, UpdateRoomOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                return RoomsServiceClient.Update(roomId, options?.ValidFrom, options?.ValidUntil, options?.PstnDialOutEnabled, cancellationToken);
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
                return await RoomsServiceClient.GetAsync(roomId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a room by id.
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
                return RoomsServiceClient.Get(roomId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all rooms asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<CommunicationRoom> GetRoomsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CommunicationRoom>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRooms)}");
                scope.Start();
                try
                {
                    Response<RoomsCollection> getRoomsResponse = await RoomsServiceClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(getRoomsResponse.Value.Value, getRoomsResponse.Value.NextLink, getRoomsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<CommunicationRoom>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRooms)}");
                scope.Start();
                try
                {
                    Response<RoomsCollection> getRoomsResponse = await RoomsServiceClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(getRoomsResponse.Value.Value, getRoomsResponse.Value.NextLink, getRoomsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all rooms.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<CommunicationRoom> GetRooms(CancellationToken cancellationToken = default)
        {
            Page<CommunicationRoom> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRooms)}");
                scope.Start();
                try
                {
                    Response<RoomsCollection> getRoomsResponse = RoomsServiceClient.List(cancellationToken);
                    return Page.FromValues(getRoomsResponse.Value.Value, getRoomsResponse.Value.NextLink, getRoomsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            Page<CommunicationRoom> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRooms)}");
                scope.Start();
                try
                {
                    Response<RoomsCollection> getParticipantsResponse = RoomsServiceClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(getParticipantsResponse.Value.Value, getParticipantsResponse.Value.NextLink, getParticipantsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
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
                return await RoomsServiceClient.DeleteAsync(roomId, cancellationToken).ConfigureAwait(false);
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
                return RoomsServiceClient.Delete(roomId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #region Participants Operations

        /// <summary>
        /// Gets the room participants asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RoomParticipant> GetParticipantsAsync(string roomId, CancellationToken cancellationToken = default)
        {
            async Task<Page<RoomParticipant>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<ParticipantsCollection> getParticipantsResponse = await ParticipantsServiceClient.ListAsync(roomId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(getParticipantsResponse.Value.Value, getParticipantsResponse.Value.NextLink, getParticipantsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<RoomParticipant>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<ParticipantsCollection> getParticipantsResponse = await ParticipantsServiceClient.ListNextPageAsync(nextLink, roomId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(getParticipantsResponse.Value.Value, getParticipantsResponse.Value.NextLink, getParticipantsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the room participants.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RoomParticipant> GetParticipants(string roomId, CancellationToken cancellationToken = default)
        {
            Page<RoomParticipant> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<ParticipantsCollection> getParticipantsResponse = ParticipantsServiceClient.List(roomId, cancellationToken);
                    return Page.FromValues(getParticipantsResponse.Value.Value, getParticipantsResponse.Value.NextLink, getParticipantsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            Page<RoomParticipant> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<ParticipantsCollection> getParticipantsResponse = ParticipantsServiceClient.ListNextPage(nextLink, roomId, cancellationToken);
                    return Page.FromValues(getParticipantsResponse.Value.Value, getParticipantsResponse.Value.NextLink, getParticipantsResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Add or update participants in a room asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> AddOrUpdateParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddOrUpdateParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForAddOrUpdate(participants);
                Response<object> addOrUpdateParticipantResponse = await ParticipantsServiceClient.UpdateAsync(roomId, participantDictionary, cancellationToken).ConfigureAwait(false);
                return addOrUpdateParticipantResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add or update participants in a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response AddOrUpdateParticipants(string roomId, IEnumerable<RoomParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(AddOrUpdateParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForAddOrUpdate(participants);
                Response<object> addOrUpdateParticipantResponse = ParticipantsServiceClient.Update(roomId, participantDictionary, cancellationToken);
                return addOrUpdateParticipantResponse.GetRawResponse();
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
        /// <param name="participantIdentifiers"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response> RemoveParticipantsAsync(string roomId, IEnumerable<CommunicationIdentifier> participantIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertCommunicationIdentifiersToDictionaryForRemove(participantIdentifiers);
                Response<object> removeParticipantResponse = await ParticipantsServiceClient.UpdateAsync(roomId, participantDictionary, cancellationToken).ConfigureAwait(false);
                return removeParticipantResponse.GetRawResponse();
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
        /// <param name="participantIdentifiers"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response RemoveParticipants(string roomId, IEnumerable<CommunicationIdentifier> participantIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertCommunicationIdentifiersToDictionaryForRemove(participantIdentifiers);
                Response<object> removeParticipantResponse = ParticipantsServiceClient.Update(roomId, participantDictionary, cancellationToken);
                return removeParticipantResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#nullable enable
        private static Dictionary<string, ParticipantProperties?> ConvertRoomParticipantsToDictionaryForAddOrUpdate(IEnumerable<RoomParticipant>? participants)
        {
            var participantDictionary = new Dictionary<string, ParticipantProperties?>() { };
#nullable disable
            participants?.ToList().ForEach(participant =>
            {
                participantDictionary.Add(participant.CommunicationIdentifier.RawId, new ParticipantProperties() { Role = participant.Role });
            });

            return participantDictionary;
        }

#nullable enable
        private static Dictionary<string, ParticipantProperties?> ConvertCommunicationIdentifiersToDictionaryForRemove(IEnumerable<CommunicationIdentifier>? identifiers)
        {
            var participantDictionary = new Dictionary<string, ParticipantProperties?>() { };
#nullable disable
            identifiers?.ToList().ForEach(identifier =>
            {
                participantDictionary.Add(identifier.RawId, null);
            });

            return participantDictionary;
        }

        #endregion
    }
}
