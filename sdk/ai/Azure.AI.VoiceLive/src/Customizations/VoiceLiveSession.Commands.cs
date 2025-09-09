// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
#pragma warning disable AZC0107
    public partial class VoiceLiveSession
    {
        #region Audio Data Transmission

        /// <summary>
        /// Transmits audio data from a byte array.
        /// </summary>
        /// <param name="audio">The audio data to transmit.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="audio"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when another audio stream is already being sent.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task SendInputAudioAsync(byte[] audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(audio, nameof(audio));
            ThrowIfDisposed();

            using (await _audioSendSemaphore.AutoReleaseWaitAsync(cancellationToken).ConfigureAwait(false))
            {
                if (_isSendingAudioStream)
                {
                    throw new InvalidOperationException("Cannot send a standalone audio chunk while a stream is already in progress.");
                }

                string base64Audio = Convert.ToBase64String(audio);
                ClientEventInputAudioBufferAppend appendCommand = new(base64Audio);
                await SendCommandAsync(appendCommand, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Transmits audio data from a byte array.
        /// </summary>
        /// <param name="audio">The audio data to transmit.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="audio"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when another audio stream is already being sent.</exception>
        public virtual void SendInputAudio(byte[] audio, CancellationToken cancellationToken = default)
        {
            SendInputAudioAsync(audio, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Transmits audio data from BinaryData.
        /// </summary>
        /// <param name="audio">The audio data to transmit.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="audio"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when another audio stream is already being sent.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task SendInputAudioAsync(BinaryData audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(audio, nameof(audio));
            ThrowIfDisposed();

            using (await _audioSendSemaphore.AutoReleaseWaitAsync(cancellationToken).ConfigureAwait(false))
            {
                if (_isSendingAudioStream)
                {
                    throw new InvalidOperationException("Cannot send a standalone audio chunk while a stream is already in progress.");
                }

                string base64Audio = Convert.ToBase64String(audio.ToArray());
                ClientEventInputAudioBufferAppend appendCommand = new(base64Audio);
                await SendCommandAsync(appendCommand, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Transmits audio data from BinaryData.
        /// </summary>
        /// <param name="audio">The audio data to transmit.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="audio"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when another audio stream is already being sent.</exception>
        public virtual void SendInputAudio(BinaryData audio, CancellationToken cancellationToken = default)
        {
            SendInputAudioAsync(audio, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Clears the input audio buffer.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ClearInputAudioAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            ClientEventInputAudioBufferClear clearCommand = new();
            await SendCommandAsync(clearCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Clears the input audio buffer.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void ClearInputAudio(CancellationToken cancellationToken = default)
        {
            ClearInputAudioAsync(cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Commits the input audio buffer.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task CommitInputAudioAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            ClientEventInputAudioBufferCommit commitCommand = new();
            await SendCommandAsync(commitCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Commits the input audio buffer.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void CommitInputAudio(CancellationToken cancellationToken = default)
        {
            CommitInputAudioAsync(cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Clears all input audio currently being streamed.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ClearStreamingAudioAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            ClientEventInputAudioClear clearCommand = new();
            await SendCommandAsync(clearCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Clears all input audio currently being streamed.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void ClearStreamingAudio(CancellationToken cancellationToken = default)
        {
            ClearStreamingAudioAsync(cancellationToken).EnsureCompleted();
        }

        #endregion

        #region Audio Turn Management

        /// <summary>
        /// Starts a new audio input turn.
        /// </summary>
        /// <param name="turnId">Unique identifier for the input audio turn.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task StartAudioTurnAsync(string turnId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(turnId, nameof(turnId));
            ThrowIfDisposed();

            ClientEventInputAudioTurnStart startCommand = new(turnId);
            await SendCommandAsync(startCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new audio input turn.
        /// </summary>
        /// <param name="turnId">Unique identifier for the input audio turn.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        public virtual void StartAudioTurn(string turnId, CancellationToken cancellationToken = default)
        {
            StartAudioTurnAsync(turnId, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Appends audio data to an ongoing input turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn this audio is part of.</param>
        /// <param name="audio">The audio data to append.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> or <paramref name="audio"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task AppendAudioToTurnAsync(string turnId, byte[] audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(turnId, nameof(turnId));
            Argument.AssertNotNull(audio, nameof(audio));
            ThrowIfDisposed();

            string base64Audio = Convert.ToBase64String(audio);
            ClientEventInputAudioTurnAppend appendCommand = new(turnId, base64Audio);
            await SendCommandAsync(appendCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Appends audio data to an ongoing input turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn this audio is part of.</param>
        /// <param name="audio">The audio data to append.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> or <paramref name="audio"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        public virtual void AppendAudioToTurn(string turnId, byte[] audio, CancellationToken cancellationToken = default)
        {
            AppendAudioToTurnAsync(turnId, audio, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Appends audio data to an ongoing input turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn this audio is part of.</param>
        /// <param name="audio">The audio data to append.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> or <paramref name="audio"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task AppendAudioToTurnAsync(string turnId, BinaryData audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(turnId, nameof(turnId));
            Argument.AssertNotNull(audio, nameof(audio));
            ThrowIfDisposed();

            string base64Audio = Convert.ToBase64String(audio.ToArray());
            ClientEventInputAudioTurnAppend appendCommand = new(turnId, base64Audio);
            await SendCommandAsync(appendCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Appends audio data to an ongoing input turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn this audio is part of.</param>
        /// <param name="audio">The audio data to append.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> or <paramref name="audio"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        public virtual void AppendAudioToTurn(string turnId, BinaryData audio, CancellationToken cancellationToken = default)
        {
            AppendAudioToTurnAsync(turnId, audio, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Marks the end of an audio input turn.
        /// </summary>
        /// <param name="turnId">The ID of the audio turn being ended.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task EndAudioTurnAsync(string turnId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(turnId, nameof(turnId));
            ThrowIfDisposed();

            ClientEventInputAudioTurnEnd endCommand = new(turnId);
            await SendCommandAsync(endCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Marks the end of an audio input turn.
        /// </summary>
        /// <param name="turnId">The ID of the audio turn being ended.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        public virtual void EndAudioTurn(string turnId, CancellationToken cancellationToken = default)
        {
            EndAudioTurnAsync(turnId, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Cancels an in-progress input audio turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn to cancel.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task CancelAudioTurnAsync(string turnId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(turnId, nameof(turnId));
            ThrowIfDisposed();

            ClientEventInputAudioTurnCancel cancelCommand = new(turnId);
            await SendCommandAsync(cancelCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels an in-progress input audio turn.
        /// </summary>
        /// <param name="turnId">The ID of the turn to cancel.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="turnId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="turnId"/> is empty.</exception>
        public virtual void CancelAudioTurn(string turnId, CancellationToken cancellationToken = default)
        {
            CancelAudioTurnAsync(turnId, cancellationToken).EnsureCompleted();
        }

        #endregion

        #region Session Configuration

        /// <summary>
        /// Updates the session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConfigureSessionAsync(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(sessionOptions, nameof(sessionOptions));
            ThrowIfDisposed();

            RequestSession requestSession = sessionOptions.ToRequestSession();
            ClientEventSessionUpdate updateCommand = new(requestSession);
            await SendCommandAsync(updateCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureSession(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            ConfigureSessionAsync(sessionOptions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Updates the conversation session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConfigureConversationSessionAsync(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            await ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the conversation session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureConversationSession(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            ConfigureConversationSessionAsync(sessionOptions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Updates the transcription session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConfigureTranscriptionSessionAsync(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            await ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the transcription session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureTranscriptionSession(SessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            ConfigureTranscriptionSessionAsync(sessionOptions, cancellationToken).EnsureCompleted();
        }

        #endregion

        #region Item Management

        /// <summary>
        /// Adds an item to the conversation.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task AddItemAsync(ConversationRequestItem item, CancellationToken cancellationToken = default)
        {
            await AddItemAsync(item, previousItemId: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds an item to the conversation.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        public virtual void AddItem(ConversationRequestItem item, CancellationToken cancellationToken = default)
        {
            AddItem(item, previousItemId: null, cancellationToken);
        }

        /// <summary>
        /// Adds an item to the conversation at a specific position.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="previousItemId">The ID of the item after which to insert the new item.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task AddItemAsync(ConversationRequestItem item, string previousItemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(item, nameof(item));
            ThrowIfDisposed();

            // Since the constructor and properties are internal/readonly, we need to
            // use the model factory or find another approach
            // For now, let's create a simple JSON payload
            var itemCreate = new ClientEventConversationItemCreate()
            {
                Item = item,
                PreviousItemId = previousItemId
            };

            await SendCommandAsync(itemCreate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds an item to the conversation at a specific position.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="previousItemId">The ID of the item after which to insert the new item.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        public virtual void AddItem(ConversationRequestItem item, string previousItemId, CancellationToken cancellationToken = default)
        {
            AddItemAsync(item, previousItemId, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Retrieves an item from the conversation.
        /// </summary>
        /// <param name="itemId">The ID of the item to retrieve.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task RequestItemRetrievalAsync(string itemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
            ThrowIfDisposed();

            ClientEventConversationItemRetrieve retrieveCommand = new(itemId);
            await SendCommandAsync(retrieveCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an item from the conversation.
        /// </summary>
        /// <param name="itemId">The ID of the item to retrieve.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        public virtual void RequestItemRetrieval(string itemId, CancellationToken cancellationToken = default)
        {
            RequestItemRetrievalAsync(itemId, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Deletes an item from the conversation.
        /// </summary>
        /// <param name="itemId">The ID of the item to delete.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task DeleteItemAsync(string itemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
            ThrowIfDisposed();

            ClientEventConversationItemDelete deleteCommand = new(itemId);
            await SendCommandAsync(deleteCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an item from the conversation.
        /// </summary>
        /// <param name="itemId">The ID of the item to delete.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        public virtual void DeleteItem(string itemId, CancellationToken cancellationToken = default)
        {
            DeleteItemAsync(itemId, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Truncates the conversation history.
        /// </summary>
        /// <param name="itemId">The ID of the item up to which to truncate the conversation.</param>
        /// <param name="contentIndex">The content index within the item to truncate to.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task TruncateConversationAsync(string itemId, int contentIndex, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
            ThrowIfDisposed();

            var truncateEvent = new ClientEventConversationItemTruncate(itemId, contentIndex, 0);

            await SendCommandAsync(truncateEvent, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Truncates the conversation history.
        /// </summary>
        /// <param name="itemId">The ID of the item up to which to truncate the conversation.</param>
        /// <param name="contentIndex">The content index within the item to truncate to.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemId"/> is empty.</exception>
        public virtual void TruncateConversation(string itemId, int contentIndex, CancellationToken cancellationToken = default)
        {
            TruncateConversationAsync(itemId, contentIndex, cancellationToken).EnsureCompleted();
        }
        #endregion

        #region Response Management

        /// <summary>
        /// Starts a new response generation.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task StartResponseAsync(CancellationToken cancellationToken = default)
        {
            await StartResponseAsync(responseOptions: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new response generation.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void StartResponse(CancellationToken cancellationToken = default)
        {
            StartResponse(responseOptions: null, cancellationToken);
        }

        /// <summary>
        /// Starts a new response generation with specific options.
        /// </summary>
        /// <param name="responseOptions">The options for response generation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task StartResponseAsync(VoiceLiveSessionOptions responseOptions, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            var responseEvent = new ClientEventResponseCreate()
            {
                AdditionalInstructions = responseOptions?.Instructions
            };

            await SendCommandAsync(responseEvent, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new response generation with specific options.
        /// </summary>
        /// <param name="responseOptions">The options for response generation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void StartResponse(VoiceLiveSessionOptions responseOptions, CancellationToken cancellationToken = default)
        {
            StartResponseAsync(responseOptions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Starts a new response generation with additional instructions.
        /// </summary>
        /// <param name="additionalInstructions">Additional instructions for this response.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="additionalInstructions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task StartResponseAsync(string additionalInstructions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(additionalInstructions, nameof(additionalInstructions));
            ThrowIfDisposed();

            var response = new ClientEventResponseCreate()
            {
                AdditionalInstructions = additionalInstructions,
            };

            await SendCommandAsync(response, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new response generation with additional instructions.
        /// </summary>
        /// <param name="additionalInstructions">Additional instructions for this response.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="additionalInstructions"/> is null.</exception>
        public virtual void StartResponse(string additionalInstructions, CancellationToken cancellationToken = default)
        {
            StartResponseAsync(additionalInstructions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Cancels the current response generation.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task CancelResponseAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            ClientEventResponseCancel cancelCommand = new();
            await SendCommandAsync(cancelCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels the current response generation.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void CancelResponse(CancellationToken cancellationToken = default)
        {
            CancelResponseAsync(cancellationToken).EnsureCompleted();
        }

        #endregion

        #region Avatar Management

        /// <summary>
        /// Connects and provides the client's SDP (Session Description Protocol) for avatar-related media negotiation.
        /// </summary>
        /// <param name="clientSdp">The client's SDP offer.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="clientSdp"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="clientSdp"/> is empty.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConnectAvatarAsync(string clientSdp, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clientSdp, nameof(clientSdp));
            ThrowIfDisposed();

            ClientEventSessionAvatarConnect avatarConnectCommand = new(clientSdp);
            await SendCommandAsync(avatarConnectCommand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Connects and provides the client's SDP (Session Description Protocol) for avatar-related media negotiation.
        /// </summary>
        /// <param name="clientSdp">The client's SDP offer.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="clientSdp"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="clientSdp"/> is empty.</exception>
        public virtual void ConnectAvatar(string clientSdp, CancellationToken cancellationToken = default)
        {
            ConnectAvatarAsync(clientSdp, cancellationToken).EnsureCompleted();
        }

        #endregion
    }
#pragma warning restore AZC0107
}
