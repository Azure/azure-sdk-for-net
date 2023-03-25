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

        internal ParticipantsRestClient ParticipantsServiceClient { get; }

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
        public virtual async Task<Response<CommunicationRoom>> CreateRoomAsync(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Guid repeatabilityRequestId = Guid.NewGuid();
                DateTimeOffset repeatabilityFirstSent = DateTimeOffset.UtcNow;
                var participantDictionary = ConvertRoomParticipantsToDictionaryForUpsert(participants);
                return await RoomsServiceClient.CreateAsync(repeatabilityRequestId, repeatabilityFirstSent, validFrom, validUntil, participantDictionary, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<CommunicationRoom> CreateRoom(DateTimeOffset? validFrom = default, DateTimeOffset? validUntil = default, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Guid repeatabilityRequestId = Guid.NewGuid();
                DateTimeOffset repeatabilityFirstSent = DateTimeOffset.UtcNow;
                var participantDictionary = ConvertRoomParticipantsToDictionaryForUpsert(participants);
                return RoomsServiceClient.Create(repeatabilityRequestId, repeatabilityFirstSent, validFrom, validUntil, participantDictionary, cancellationToken);
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
                return await RoomsServiceClient.UpdateAsync(roomId, validFrom, validUntil, cancellationToken).ConfigureAwait(false);
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
                return RoomsServiceClient.Update(roomId, validFrom, validUntil, cancellationToken);
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
        /// Lists all rooms asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<RoomsCollection>> ListRoomsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(ListRooms)}");
            scope.Start();
            try
            {
                return await RoomsServiceClient.ListAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Lists all rooms.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual Response<RoomsCollection> ListRooms(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(ListRooms)}");
            scope.Start();
            try
            {
                return RoomsServiceClient.List(cancellationToken);
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
        public virtual async Task<Response<ParticipantsCollection>> GetParticipantsAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                return await ParticipantsServiceClient.ListAsync(roomId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the room participants.
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
                return ParticipantsServiceClient.List(roomId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Upsert participants in a room asynchronously.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<object>> UpsertParticipantsAsync(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpsertParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForUpsert(participants);
                return await ParticipantsServiceClient.UpdateAsync(roomId, participantDictionary, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Upsert participants in a room.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="participants"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<object> UpsertParticipants(string roomId, IEnumerable<RoomParticipant> participants = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpsertParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForUpsert(participants);
                return ParticipantsServiceClient.Update(roomId, participantDictionary, cancellationToken);
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
        public virtual async Task<Response<object>> RemoveParticipantsAsync(string roomId, IEnumerable<CommunicationIdentifier> communicationIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForRemove(communicationIdentifiers);
                return await ParticipantsServiceClient.UpdateAsync(roomId, participantDictionary, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<object> RemoveParticipants(string roomId, IEnumerable<CommunicationIdentifier> communicationIdentifiers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var participantDictionary = ConvertRoomParticipantsToDictionaryForRemove(communicationIdentifiers);
                return ParticipantsServiceClient.Update(roomId, participantDictionary, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#nullable enable
        private static Dictionary<string, ParticipantProperties?> ConvertRoomParticipantsToDictionaryForUpsert(IEnumerable<RoomParticipant> participants)
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
        private static Dictionary<string, ParticipantProperties?> ConvertCommunicationIdentifiersToDictionaryForRemove(IEnumerable<CommunicationIdentifier> identifiers)
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
