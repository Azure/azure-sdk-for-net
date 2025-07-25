// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents an update containing streaming output data from the service.
    /// </summary>
    public sealed class OutputStreamingUpdate : VoiceLiveUpdate
    {
        private readonly VoiceLiveServerEvent _serverEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputStreamingUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal OutputStreamingUpdate(VoiceLiveUpdateKind kind, VoiceLiveServerEvent serverEvent)
            : base(kind)
        {
            Argument.AssertNotNull(serverEvent, nameof(serverEvent));
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputStreamingUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal OutputStreamingUpdate(
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            VoiceLiveServerEvent serverEvent)
            : base(kind, eventId, additionalBinaryDataProperties)
        {
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Gets the response ID associated with this streaming update.
        /// </summary>
        public string ResponseId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseCreated responseCreated => responseCreated.Response?.Id,
                    VoiceLiveServerEventResponseDone responseDone => responseDone.Response?.Id,
                    VoiceLiveServerEventResponseOutputItemAdded itemAdded => itemAdded.ResponseId,
                    VoiceLiveServerEventResponseOutputItemDone itemDone => itemDone.ResponseId,
                    VoiceLiveServerEventResponseContentPartAdded partAdded => partAdded.ResponseId,
                    VoiceLiveServerEventResponseContentPartDone partDone => partDone.ResponseId,
                    VoiceLiveServerEventResponseTextDone textDone => textDone.ResponseId,
                    VoiceLiveServerEventResponseAudioDone audioDone => audioDone.ResponseId,
                    VoiceLiveServerEventResponseAudioTranscriptDone transcriptDone => transcriptDone.ResponseId,
                    ResponseAnimationBlendshapeDoneEvent blendshapeDone => blendshapeDone.ResponseId,
                    ResponseAnimationVisemeDoneEvent visemeDone => visemeDone.ResponseId,
                    ResponseAudioTimestampDoneEvent timestampDone => timestampDone.ResponseId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the item ID associated with this streaming update.
        /// </summary>
        public string ItemId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseOutputItemAdded itemAdded => itemAdded.Item?.Id,
                    VoiceLiveServerEventResponseOutputItemDone itemDone => itemDone.Item?.Id,
                    VoiceLiveServerEventResponseContentPartAdded partAdded => partAdded.ItemId,
                    VoiceLiveServerEventResponseContentPartDone partDone => partDone.ItemId,
                    VoiceLiveServerEventResponseTextDone textDone => textDone.ItemId,
                    VoiceLiveServerEventResponseAudioDone audioDone => audioDone.ItemId,
                    VoiceLiveServerEventResponseAudioTranscriptDone transcriptDone => transcriptDone.ItemId,
                    ResponseAnimationBlendshapeDoneEvent blendshapeDone => blendshapeDone.ItemId,
                    ResponseAnimationVisemeDoneEvent visemeDone => visemeDone.ItemId,
                    ResponseAudioTimestampDoneEvent timestampDone => timestampDone.ItemId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the output index for this streaming update.
        /// </summary>
        public int? OutputIndex
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseOutputItemAdded itemAdded => itemAdded.OutputIndex,
                    VoiceLiveServerEventResponseOutputItemDone itemDone => itemDone.OutputIndex,
                    VoiceLiveServerEventResponseContentPartAdded partAdded => partAdded.OutputIndex,
                    VoiceLiveServerEventResponseContentPartDone partDone => partDone.OutputIndex,
                    VoiceLiveServerEventResponseTextDone textDone => textDone.OutputIndex,
                    VoiceLiveServerEventResponseAudioDone audioDone => audioDone.OutputIndex,
                    VoiceLiveServerEventResponseAudioTranscriptDone transcriptDone => transcriptDone.OutputIndex,
                    ResponseAnimationBlendshapeDoneEvent blendshapeDone => blendshapeDone.OutputIndex,
                    ResponseAnimationVisemeDoneEvent visemeDone => visemeDone.OutputIndex,
                    ResponseAudioTimestampDoneEvent timestampDone => timestampDone.OutputIndex,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the content index for this streaming update.
        /// </summary>
        public int? ContentIndex
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseContentPartAdded partAdded => partAdded.ContentIndex,
                    VoiceLiveServerEventResponseContentPartDone partDone => partDone.ContentIndex,
                    VoiceLiveServerEventResponseTextDone textDone => textDone.ContentIndex,
                    VoiceLiveServerEventResponseAudioDone audioDone => audioDone.ContentIndex,
                    VoiceLiveServerEventResponseAudioTranscriptDone transcriptDone => transcriptDone.ContentIndex,
                    // ResponseAnimationBlendshapeDoneEvent blendshapeDone => blendshapeDone.ContentIndex,
                    ResponseAnimationVisemeDoneEvent visemeDone => visemeDone.ContentIndex,
                    ResponseAudioTimestampDoneEvent timestampDone => timestampDone.ContentIndex,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the response object, if this is a response-level update.
        /// </summary>
        public VoiceLiveResponse Response
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseCreated responseCreated => responseCreated.Response,
                    VoiceLiveServerEventResponseDone responseDone => responseDone.Response,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the conversation response item, if this is an item-level update.
        /// </summary>
        public VoiceLiveConversationItemWithReference Item
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseOutputItemAdded itemAdded => itemAdded.Item,
                    VoiceLiveServerEventResponseOutputItemDone itemDone => itemDone.Item,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the content part, if this is a content part update.
        /// </summary>
        public VoiceLiveContentPart ContentPart
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseContentPartAdded partAdded => partAdded.Part,
                    VoiceLiveServerEventResponseContentPartDone partDone => partDone.Part,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the final text content, if this is a text completion update.
        /// </summary>
        public string Text
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDone textDone => textDone.Text,
                    VoiceLiveServerEventResponseAudioTranscriptDone transcriptDone => transcriptDone.Transcript,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the response status, if this is a response completion update.
        /// </summary>
        public VoiceLiveResponseStatus? ResponseStatus => Response?.Status;

        /// <summary>
        /// Gets the response status details, if available.
        /// </summary>
        public VoiceLiveResponseStatusDetails ResponseStatusDetails => Response?.StatusDetails;

        /// <summary>
        /// Gets the response usage information, if available.
        /// </summary>
        public VoiceLiveResponseUsage Usage => Response?.Usage;

        /// <summary>
        /// Gets a value indicating whether this is a response start update.
        /// </summary>
        public bool IsResponseStarted => Kind == VoiceLiveUpdateKind.ResponseStarted;

        /// <summary>
        /// Gets a value indicating whether this is a response completion update.
        /// </summary>
        public bool IsResponseCompleted => Kind == VoiceLiveUpdateKind.ResponseCompleted;

        /// <summary>
        /// Gets a value indicating whether this is an output item start update.
        /// </summary>
        public bool IsOutputItemAdded => Kind == VoiceLiveUpdateKind.ResponseOutputItemAdded;

        /// <summary>
        /// Gets a value indicating whether this is an output item completion update.
        /// </summary>
        public bool IsOutputItemCompleted => Kind == VoiceLiveUpdateKind.ResponseOutputItemDone;

        /// <summary>
        /// Gets a value indicating whether this is a content part start update.
        /// </summary>
        public bool IsContentPartAdded => Kind == VoiceLiveUpdateKind.ResponseContentPartAdded;

        /// <summary>
        /// Gets a value indicating whether this is a content part completion update.
        /// </summary>
        public bool IsContentPartCompleted => Kind == VoiceLiveUpdateKind.ResponseContentPartDone;

        /// <summary>
        /// Gets a value indicating whether this is a text completion update.
        /// </summary>
        public bool IsTextCompleted => Kind == VoiceLiveUpdateKind.ResponseTextDone;

        /// <summary>
        /// Gets a value indicating whether this is an audio completion update.
        /// </summary>
        public bool IsAudioCompleted => Kind == VoiceLiveUpdateKind.ResponseAudioDone;

        /// <summary>
        /// Gets a value indicating whether this is an audio transcript completion update.
        /// </summary>
        public bool IsTranscriptCompleted => Kind == VoiceLiveUpdateKind.ResponseAudioTranscriptDone;

        /// <summary>
        /// Gets a value indicating whether this represents a completion of any kind.
        /// </summary>
        public bool IsCompleted => (Kind == VoiceLiveUpdateKind.ResponseCompleted ||
            Kind == VoiceLiveUpdateKind.ResponseOutputItemDone ||
            Kind == VoiceLiveUpdateKind.ResponseContentPartDone ||
            Kind == VoiceLiveUpdateKind.ResponseTextDone ||
            Kind == VoiceLiveUpdateKind.ResponseAudioDone ||
            Kind == VoiceLiveUpdateKind.ResponseAudioTranscriptDone ||
            Kind == VoiceLiveUpdateKind.ResponseAnimationBlendshapesDone ||
            Kind == VoiceLiveUpdateKind.ResponseAnimationVisemeDone ||
            Kind == VoiceLiveUpdateKind.ResponseAudioTimestampDone);
    }
}
