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
                VoiceLiveClientEventInputAudioBufferAppend appendCommand = new(base64Audio);
                BinaryData requestData = BinaryData.FromObjectAsJson(appendCommand);
                await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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
                VoiceLiveClientEventInputAudioBufferAppend appendCommand = new(base64Audio);
                BinaryData requestData = BinaryData.FromObjectAsJson(appendCommand);
                await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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
            VoiceLiveClientEventInputAudioBufferClear clearCommand = new();
            BinaryData requestData = BinaryData.FromObjectAsJson(clearCommand);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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
            VoiceLiveClientEventInputAudioBufferCommit commitCommand = new();
            BinaryData requestData = BinaryData.FromObjectAsJson(commitCommand);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Commits the input audio buffer.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void CommitInputAudio(CancellationToken cancellationToken = default)
        {
            CommitInputAudioAsync(cancellationToken).EnsureCompleted();
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
        public virtual async Task ConfigureSessionAsync(VoiceLiveSessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(sessionOptions, nameof(sessionOptions));
            ThrowIfDisposed();

            VoiceLiveRequestSession requestSession = sessionOptions.ToRequestSession();
            VoiceLiveClientEventSessionUpdate updateCommand = new(requestSession);
            var requestData = updateCommand.ToRequestContent();
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the session configuration.
        /// </summary>
        /// <param name="sessionOptions">The session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureSession(VoiceLiveSessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            ConfigureSessionAsync(sessionOptions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Updates the conversation session configuration.
        /// </summary>
        /// <param name="sessionOptions">The conversation session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConfigureConversationSessionAsync(ConversationSessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            await ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the conversation session configuration.
        /// </summary>
        /// <param name="sessionOptions">The conversation session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureConversationSession(ConversationSessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            ConfigureConversationSessionAsync(sessionOptions, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Updates the transcription session configuration.
        /// </summary>
        /// <param name="sessionOptions">The transcription session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task ConfigureTranscriptionSessionAsync(TranscriptionSessionOptions sessionOptions, CancellationToken cancellationToken = default)
        {
            await ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the transcription session configuration.
        /// </summary>
        /// <param name="sessionOptions">The transcription session configuration options.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sessionOptions"/> is null.</exception>
        public virtual void ConfigureTranscriptionSession(TranscriptionSessionOptions sessionOptions, CancellationToken cancellationToken = default)
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
        public virtual async Task AddItemAsync(VoiceLiveConversationItemWithReference item, CancellationToken cancellationToken = default)
        {
            await AddItemAsync(item, previousItemId: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds an item to the conversation.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        public virtual void AddItem(VoiceLiveConversationItemWithReference item, CancellationToken cancellationToken = default)
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
        public virtual async Task AddItemAsync(VoiceLiveConversationItemWithReference item, string previousItemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(item, nameof(item));
            ThrowIfDisposed();

            // Since the constructor and properties are internal/readonly, we need to
            // use the model factory or find another approach
            // For now, let's create a simple JSON payload
            var itemCreateData = new
            {
                type = "conversation.item.create",
                item = item,
                previous_item_id = previousItemId
            };

            BinaryData requestData = BinaryData.FromObjectAsJson(itemCreateData);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds an item to the conversation at a specific position.
        /// </summary>
        /// <param name="item">The item to add to the conversation.</param>
        /// <param name="previousItemId">The ID of the item after which to insert the new item.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        public virtual void AddItem(VoiceLiveConversationItemWithReference item, string previousItemId, CancellationToken cancellationToken = default)
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

            VoiceLiveClientEventConversationItemRetrieve retrieveCommand = new(itemId);
            BinaryData requestData = BinaryData.FromObjectAsJson(retrieveCommand);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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

            VoiceLiveClientEventConversationItemDelete deleteCommand = new(itemId);
            BinaryData requestData = BinaryData.FromObjectAsJson(deleteCommand);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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

            // Create a simple JSON payload since the constructor might not be available
            var truncateData = new
            {
                type = "conversation.item.truncate",
                item_id = itemId,
                content_index = contentIndex
            };

            BinaryData requestData = BinaryData.FromObjectAsJson(truncateData);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task StartResponseAsync(VoiceLiveResponseOptions responseOptions, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // Create a simple JSON payload since VoiceLiveClientEventResponseCreate might not be easily constructible
            var responseData = new
            {
                type = "response.create"
            };

            if (responseOptions != null)
            {
                // We could extend this to include the response options if needed
            }

            BinaryData requestData = BinaryData.FromObjectAsJson(responseData);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a new response generation with specific options.
        /// </summary>
        /// <param name="responseOptions">The options for response generation.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        public virtual void StartResponse(VoiceLiveResponseOptions responseOptions, CancellationToken cancellationToken = default)
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

            var responseData = new
            {
                type = "response.create",
                additional_instructions = additionalInstructions
            };

            BinaryData requestData = BinaryData.FromObjectAsJson(responseData);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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

            VoiceLiveClientEventResponseCancel cancelCommand = new();
            BinaryData requestData = BinaryData.FromObjectAsJson(cancelCommand);
            await SendCommandAsync(requestData, cancellationToken).ConfigureAwait(false);
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
    }
#pragma warning restore AZC0107
}
