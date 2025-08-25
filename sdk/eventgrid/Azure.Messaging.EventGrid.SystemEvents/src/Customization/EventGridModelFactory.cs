// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Messaging.EventGrid.Models;
using Azure.Messaging.EventGrid.SystemEvents;
using AcsRouterJobStatus = Azure.Messaging.EventGrid.Models.AcsRouterJobStatus;

namespace Azure.Messaging.EventGrid
{
#pragma warning disable CA1054 // URI-like parameters should not be strings
    [CodeGenType("EventGridSystemEventsModelFactory")]
    [CodeGenSuppress("ResourceWriteSuccessEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceWriteFailureEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceWriteCancelEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceDeleteSuccessEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceDeleteFailureEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceDeleteCancelEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceActionSuccessEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceActionFailureEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("ResourceActionCancelEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(JsonElement), typeof(JsonElement), typeof(string), typeof(JsonElement))]
    [CodeGenSuppress("StorageDirectoryDeletedEventData", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(object))]
    [CodeGenSuppress("ResourceHttpRequest", typeof(string), typeof(string), typeof(string), typeof(string))]
    public static partial class EventGridModelFactory
    {
        /// <summary> Initializes new instance of MediaJobError class. </summary>
        /// <param name="code"> Error code describing the error. </param>
        /// <param name="message"> A human-readable language-dependent representation of the error. </param>
        /// <param name="category"> Helps with categorization of errors. </param>
        /// <param name="retry"> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </param>
        /// <param name="details"> An array of details about specific errors that led to this reported error. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobError"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobError MediaJobError(MediaJobErrorCode? code, string message, MediaJobErrorCategory? category, MediaJobRetry? retry, IReadOnlyList<MediaJobErrorDetail> details)
        {
            return new MediaJobError(code, message, category, retry, details);
        }

        /// <summary> Initializes new instance of MediaJobFinishedEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobFinishedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobFinishedEventData MediaJobFinishedEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return new MediaJobFinishedEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes new instance of MediaJobCanceledEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobCanceledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobCanceledEventData MediaJobCanceledEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return new MediaJobCanceledEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes new instance of MediaJobErroredEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobErroredEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobErroredEventData MediaJobErroredEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return new MediaJobErroredEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobStateChangeEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobStateChangeEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobStateChangeEventData MediaJobStateChangeEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null)
        {
            correlationData ??= new Dictionary<string, string>();

            return new MediaJobStateChangeEventData(previousState, state, correlationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobError"/>. </summary>
        /// <param name="code"> Error code describing the error. </param>
        /// <param name="message"> A human-readable language-dependent representation of the error. </param>
        /// <param name="category"> Helps with categorization of errors. </param>
        /// <param name="retry"> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </param>
        /// <param name="details"> An array of details about specific errors that led to this reported error. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobError"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobError MediaJobError(MediaJobErrorCode? code = null, string message = null, MediaJobErrorCategory? category = null, MediaJobRetry? retry = null, IEnumerable<MediaJobErrorDetail> details = null)
        {
            details ??= new List<MediaJobErrorDetail>();

            return new MediaJobError(code, message, category, retry, details?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobErrorDetail"/>. </summary>
        /// <param name="code"> Code describing the error detail. </param>
        /// <param name="message"> A human-readable representation of the error. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobErrorDetail"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobErrorDetail MediaJobErrorDetail(string code = null, string message = null)
        {
            return new MediaJobErrorDetail(code, message);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutput"/>. </summary>
        /// <param name="odataType"> The discriminator for derived types. </param>
        /// <param name="error"> Gets the Job output error. </param>
        /// <param name="label"> Gets the Job output label. </param>
        /// <param name="progress"> Gets the Job output progress. </param>
        /// <param name="state"> Gets the Job output state. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutput"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutput MediaJobOutput(string odataType = null, MediaJobError error = null, string label = null, long progress = default, MediaJobState state = default)
        {
            return new MediaJobOutput(odataType, error, label, progress, state);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputAsset"/>. </summary>
        /// <param name="odataType"> The discriminator for derived types. </param>
        /// <param name="error"> Gets the Job output error. </param>
        /// <param name="label"> Gets the Job output label. </param>
        /// <param name="progress"> Gets the Job output progress. </param>
        /// <param name="state"> Gets the Job output state. </param>
        /// <param name="assetName"> Gets the Job output asset name. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputAsset"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputAsset MediaJobOutputAsset(string odataType = null, MediaJobError error = null, string label = null, long progress = default, MediaJobState state = default, string assetName = null)
        {
            return new MediaJobOutputAsset(
                odataType,
                error,
                label,
                progress,
                state,
                assetName);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputProgressEventData"/>. </summary>
        /// <param name="label"> Gets the Job output label. </param>
        /// <param name="progress"> Gets the Job output progress. </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputProgressEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputProgressEventData MediaJobOutputProgressEventData(string label = null, long? progress = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputProgressEventData(label, progress, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputStateChangeEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputStateChangeEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputStateChangeEventData MediaJobOutputStateChangeEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputStateChangeEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobScheduledEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobScheduledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobScheduledEventData MediaJobScheduledEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null)
        {
            correlationData ??= new Dictionary<string, string>();

            return new MediaJobScheduledEventData(previousState, state, correlationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobProcessingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobProcessingEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobProcessingEventData MediaJobProcessingEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null)
        {
            correlationData ??= new Dictionary<string, string>();

            return new MediaJobProcessingEventData(previousState, state, correlationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobCancelingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobCancelingEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobCancelingEventData MediaJobCancelingEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null)
        {
            correlationData ??= new Dictionary<string, string>();

            return new MediaJobCancelingEventData(previousState, state, correlationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobFinishedEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs">
        /// Gets the Job outputs.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobFinishedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobFinishedEventData MediaJobFinishedEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null, IEnumerable<MediaJobOutput> outputs = null)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();

            return new MediaJobFinishedEventData(previousState, state, correlationData, outputs?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobCanceledEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs">
        /// Gets the Job outputs.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobCanceledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobCanceledEventData MediaJobCanceledEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null, IEnumerable<MediaJobOutput> outputs = null)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();

            return new MediaJobCanceledEventData(previousState, state, correlationData, outputs?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobErroredEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs">
        /// Gets the Job outputs.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobErroredEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobErroredEventData MediaJobErroredEventData(MediaJobState? previousState = null, MediaJobState? state = null, IReadOnlyDictionary<string, string> correlationData = null, IEnumerable<MediaJobOutput> outputs = null)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();

            return new MediaJobErroredEventData(previousState, state, correlationData, outputs?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputCanceledEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputCanceledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputCanceledEventData MediaJobOutputCanceledEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputCanceledEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputCancelingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputCancelingEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputCancelingEventData MediaJobOutputCancelingEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputCancelingEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputErroredEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputErroredEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputErroredEventData MediaJobOutputErroredEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputErroredEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputFinishedEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputFinishedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputFinishedEventData MediaJobOutputFinishedEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputFinishedEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputProcessingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputProcessingEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputProcessingEventData MediaJobOutputProcessingEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputProcessingEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaJobOutputScheduledEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="output">
        /// Gets the output.
        /// Please note <see cref="SystemEvents.MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SystemEvents.MediaJobOutputAsset"/>.
        /// </param>
        /// <param name="jobCorrelationData"> Gets the Job correlation data. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobOutputScheduledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobOutputScheduledEventData MediaJobOutputScheduledEventData(MediaJobState? previousState = null, MediaJobOutput output = null, IReadOnlyDictionary<string, string> jobCorrelationData = null)
        {
            jobCorrelationData ??= new Dictionary<string, string>();

            return new MediaJobOutputScheduledEventData(previousState, output, jobCorrelationData);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventEncoderConnectedEventData"/>. </summary>
        /// <param name="ingestUrl"> Gets the ingest URL provided by the live event. </param>
        /// <param name="streamId"> Gets the stream Id. </param>
        /// <param name="encoderIp"> Gets the remote IP. </param>
        /// <param name="encoderPort"> Gets the remote port. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventEncoderConnectedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventEncoderConnectedEventData MediaLiveEventEncoderConnectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null)
        {
            return new MediaLiveEventEncoderConnectedEventData(ingestUrl, streamId, encoderIp, encoderPort);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventConnectionRejectedEventData"/>. </summary>
        /// <param name="ingestUrl"> Gets the ingest URL provided by the live event. </param>
        /// <param name="streamId"> Gets the stream Id. </param>
        /// <param name="encoderIp"> Gets the remote IP. </param>
        /// <param name="encoderPort"> Gets the remote port. </param>
        /// <param name="resultCode"> Gets the result code. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventConnectionRejectedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventConnectionRejectedEventData MediaLiveEventConnectionRejectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null, string resultCode = null)
        {
            return new MediaLiveEventConnectionRejectedEventData(ingestUrl, streamId, encoderIp, encoderPort, resultCode);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventEncoderDisconnectedEventData"/>. </summary>
        /// <param name="ingestUrl"> Gets the ingest URL provided by the live event. </param>
        /// <param name="streamId"> Gets the stream Id. </param>
        /// <param name="encoderIp"> Gets the remote IP. </param>
        /// <param name="encoderPort"> Gets the remote port. </param>
        /// <param name="resultCode"> Gets the result code. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventEncoderDisconnectedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventEncoderDisconnectedEventData MediaLiveEventEncoderDisconnectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null, string resultCode = null)
        {
            return new MediaLiveEventEncoderDisconnectedEventData(ingestUrl, streamId, encoderIp, encoderPort, resultCode);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventIncomingStreamReceivedEventData"/>. </summary>
        /// <param name="ingestUrl"> Gets the ingest URL provided by the live event. </param>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="encoderIp"> Gets the remote IP. </param>
        /// <param name="encoderPort"> Gets the remote port. </param>
        /// <param name="timestamp"> Gets the first timestamp of the data chunk received. </param>
        /// <param name="duration"> Gets the duration of the first data chunk. </param>
        /// <param name="timescale"> Gets the timescale in which timestamp is represented. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIncomingStreamReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIncomingStreamReceivedEventData MediaLiveEventIncomingStreamReceivedEventData(string ingestUrl = null, string trackType = null, string trackName = null, long? bitrate = null, string encoderIp = null, string encoderPort = null, string timestamp = null, string duration = null, string timescale = null)
        {
            return new MediaLiveEventIncomingStreamReceivedEventData(
                ingestUrl,
                trackType,
                trackName,
                bitrate,
                encoderIp,
                encoderPort,
                timestamp,
                duration,
                timescale);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData"/>. </summary>
        /// <param name="minLastTimestamp"> Gets the minimum last timestamp received. </param>
        /// <param name="typeOfStreamWithMinLastTimestamp"> Gets the type of stream with minimum last timestamp. </param>
        /// <param name="maxLastTimestamp"> Gets the maximum timestamp among all the tracks (audio or video). </param>
        /// <param name="typeOfStreamWithMaxLastTimestamp"> Gets the type of stream with maximum last timestamp. </param>
        /// <param name="timescaleOfMinLastTimestamp"> Gets the timescale in which "MinLastTimestamp" is represented. </param>
        /// <param name="timescaleOfMaxLastTimestamp"> Gets the timescale in which "MaxLastTimestamp" is represented. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIncomingStreamsOutOfSyncEventData MediaLiveEventIncomingStreamsOutOfSyncEventData(string minLastTimestamp = null, string typeOfStreamWithMinLastTimestamp = null, string maxLastTimestamp = null, string typeOfStreamWithMaxLastTimestamp = null, string timescaleOfMinLastTimestamp = null, string timescaleOfMaxLastTimestamp = null)
        {
            return new MediaLiveEventIncomingStreamsOutOfSyncEventData(
                minLastTimestamp,
                typeOfStreamWithMinLastTimestamp,
                maxLastTimestamp,
                typeOfStreamWithMaxLastTimestamp,
                timescaleOfMinLastTimestamp,
                timescaleOfMaxLastTimestamp);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData"/>. </summary>
        /// <param name="firstTimestamp"> Gets the first timestamp received for one of the quality levels. </param>
        /// <param name="firstDuration"> Gets the duration of the data chunk with first timestamp. </param>
        /// <param name="secondTimestamp"> Gets the timestamp received for some other quality levels. </param>
        /// <param name="secondDuration"> Gets the duration of the data chunk with second timestamp. </param>
        /// <param name="timescale"> Gets the timescale in which both the timestamps and durations are represented. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIncomingVideoStreamsOutOfSyncEventData MediaLiveEventIncomingVideoStreamsOutOfSyncEventData(string firstTimestamp = null, string firstDuration = null, string secondTimestamp = null, string secondDuration = null, string timescale = null)
        {
            return new MediaLiveEventIncomingVideoStreamsOutOfSyncEventData(firstTimestamp, firstDuration, secondTimestamp, secondDuration, timescale);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData"/>. </summary>
        /// <param name="timestamp"> Gets the timestamp of the data chunk dropped. </param>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="timescale"> Gets the timescale of the Timestamp. </param>
        /// <param name="resultCode"> Gets the result code for fragment drop operation. </param>
        /// <param name="trackName"> Gets the name of the track for which fragment is dropped. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIncomingDataChunkDroppedEventData MediaLiveEventIncomingDataChunkDroppedEventData(string timestamp = null, string trackType = null, long? bitrate = null, string timescale = null, string resultCode = null, string trackName = null)
        {
            return new MediaLiveEventIncomingDataChunkDroppedEventData(
                timestamp,
                trackType,
                bitrate,
                timescale,
                resultCode,
                trackName);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData"/>. </summary>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="bitrate"> Gets the bitrate. </param>
        /// <param name="previousTimestamp"> Gets the timestamp of the previous fragment. </param>
        /// <param name="newTimestamp"> Gets the timestamp of the current fragment. </param>
        /// <param name="timescale"> Gets the timescale in which both timestamps and discontinuity gap are represented. </param>
        /// <param name="discontinuityGap"> Gets the discontinuity gap between PreviousTimestamp and NewTimestamp. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventTrackDiscontinuityDetectedEventData MediaLiveEventTrackDiscontinuityDetectedEventData(string trackType = null, string trackName = null, long? bitrate = null, string previousTimestamp = null, string newTimestamp = null, string timescale = null, string discontinuityGap = null)
        {
            return new MediaLiveEventTrackDiscontinuityDetectedEventData(
                trackType,
                trackName,
                bitrate,
                previousTimestamp,
                newTimestamp,
                timescale,
                discontinuityGap);
        }

        /// <summary> Initializes new instance of MapsGeofenceEventProperties class. </summary>
        /// <param name="expiredGeofenceGeometryId"> Lists of the geometry ID of the geofence which is expired relative to the user time in the request. </param>
        /// <param name="geometries"> Lists the fence geometries that either fully contain the coordinate position or have an overlap with the searchBuffer around the fence. </param>
        /// <param name="invalidPeriodGeofenceGeometryId"> Lists of the geometry ID of the geofence which is in invalid period relative to the user time in the request. </param>
        /// <param name="isEventPublished"> True if at least one event is published to the Azure Maps event subscriber, false if no event is published to the Azure Maps event subscriber. </param>
        /// <returns> A new <see cref="SystemEvents.MapsGeofenceEventProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsGeofenceEventProperties MapsGeofenceEventProperties(IReadOnlyList<string> expiredGeofenceGeometryId, IReadOnlyList<MapsGeofenceGeometry> geometries, IReadOnlyList<string> invalidPeriodGeofenceGeometryId, bool? isEventPublished)
        {
            return MapsGeofenceEventProperties((IEnumerable<string>) expiredGeofenceGeometryId, geometries, invalidPeriodGeofenceGeometryId, isEventPublished);
        }

        /// <summary> Initializes new instance of AcsChatThreadCreatedWithUserEventData class. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedWithUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IReadOnlyList<AcsChatThreadParticipantProperties> participants)
        {
            return AcsChatThreadCreatedWithUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, null, participants);
        }

        /// <summary> Initializes new instance of AcsChatThreadCreatedEventData class. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IReadOnlyList<AcsChatThreadParticipantProperties> participants)
        {
            return AcsChatThreadCreatedEventData(transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), (IEnumerable<AcsChatThreadParticipantProperties>) participants);
        }

        /// <summary> Initializes a new instance of AcsChatThreadCreatedWithUserEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedWithUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IEnumerable<AcsChatThreadParticipantProperties> participants)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();

            return AcsChatThreadCreatedWithUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), participants?.ToList());
        }

        /// <summary> Initializes a new instance of AcsChatThreadParticipantProperties. </summary>
        /// <param name="displayName"> The name of the user. </param>
        /// <param name="participantCommunicationIdentifier"> The communication identifier of the user. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadParticipantProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadParticipantProperties AcsChatThreadParticipantProperties(string displayName, CommunicationIdentifierModel participantCommunicationIdentifier)
        {
            return AcsChatThreadParticipantProperties(displayName, participantCommunicationIdentifier, new Dictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatThreadPropertiesUpdatedPerUserEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="editedByCommunicationIdentifier"> The communication identifier of the user who updated the thread properties. </param>
        /// <param name="editTime"> The time at which the properties of the thread were updated. </param>
        /// <param name="properties"> The updated thread properties. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadPropertiesUpdatedPerUserEventData AcsChatThreadPropertiesUpdatedPerUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, DateTimeOffset? createTime = null, long? version = null, CommunicationIdentifierModel editedByCommunicationIdentifier = null, DateTimeOffset? editTime = null, IReadOnlyDictionary<string, object> properties = null)
        {
            properties ??= new Dictionary<string, object>();

            return AcsChatThreadPropertiesUpdatedPerUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, editedByCommunicationIdentifier, editTime, new Dictionary<string, string>(), properties);
        }

        /// <summary> Initializes a new instance of AcsChatThreadPropertiesUpdatedEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="editedByCommunicationIdentifier"> The communication identifier of the user who updated the thread properties. </param>
        /// <param name="editTime"> The time at which the properties of the thread were updated. </param>
        /// <param name="properties"> The updated thread properties. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadPropertiesUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadPropertiesUpdatedEventData AcsChatThreadPropertiesUpdatedEventData(string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel editedByCommunicationIdentifier, DateTimeOffset? editTime, IReadOnlyDictionary<string, object> properties)
        {
            properties ??= new Dictionary<string, object>();

            return AcsChatThreadPropertiesUpdatedEventData(transactionId, threadId, createTime, version, editedByCommunicationIdentifier, editTime, properties, new Dictionary<string, string>());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsChatThreadCreatedEventData"/>. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId = null, string threadId = null, DateTimeOffset? createTime = null, long? version = null, CommunicationIdentifierModel createdByCommunicationIdentifier = null, IReadOnlyDictionary<string, object> properties = null, IEnumerable<AcsChatThreadParticipantProperties> participants = null)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();

            return AcsChatThreadCreatedEventData(transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), participants?.ToList());
        }

        /// <summary> Initializes new instance of AcsSmsDeliveryReportReceivedEventData class. </summary>
        /// <param name="messageId"> The identity of the SMS message. </param>
        /// <param name="from"> The identity of SMS message sender. </param>
        /// <param name="to"> The identity of SMS message receiver. </param>
        /// <param name="deliveryStatus"> Status of Delivery. </param>
        /// <param name="deliveryStatusDetails"> Details about Delivery Status. </param>
        /// <param name="deliveryAttempts"> List of details of delivery attempts made. </param>
        /// <param name="receivedTimestamp"> The time at which the SMS delivery report was received. </param>
        /// <param name="tag"> Customer Content. </param>
        /// <returns> A new <see cref="SystemEvents.AcsSmsDeliveryReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsSmsDeliveryReportReceivedEventData AcsSmsDeliveryReportReceivedEventData(string messageId, string @from, string to, string deliveryStatus, string deliveryStatusDetails, IReadOnlyList<AcsSmsDeliveryAttemptProperties> deliveryAttempts, DateTimeOffset? receivedTimestamp, string tag)
        {
            return AcsSmsDeliveryReportReceivedEventData(messageId, @from, to, deliveryStatus, deliveryStatusDetails, (IEnumerable<AcsSmsDeliveryAttemptProperties>) deliveryAttempts, receivedTimestamp, tag);
        }

        /// <summary> Initializes new instance of AcsRecordingStorageInfoProperties class. </summary>
        /// <param name="recordingChunks"> List of details of recording chunks information. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingStorageInfoProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingStorageInfoProperties AcsRecordingStorageInfoProperties(IReadOnlyList<AcsRecordingChunkInfoProperties> recordingChunks)
        {
            return AcsRecordingStorageInfoProperties((IEnumerable<AcsRecordingChunkInfoProperties>) recordingChunks);
        }

        /// <summary> Initializes new instance of ResourceWriteSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteSuccessEventData"/> instance for mocking. </returns>
        public static ResourceWriteSuccessEventData ResourceWriteSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceWriteFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteFailureEventData"/> instance for mocking. </returns>
        public static ResourceWriteFailureEventData ResourceWriteFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceWriteCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteCancelEventData"/> instance for mocking. </returns>
        public static ResourceWriteCancelEventData ResourceWriteCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceDeleteSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteSuccessEventData"/> instance for mocking. </returns>
        public static ResourceDeleteSuccessEventData ResourceDeleteSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceDeleteFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteFailureEventData"/> instance for mocking. </returns>
        public static ResourceDeleteFailureEventData ResourceDeleteFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceDeleteCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteCancelEventData"/> instance for mocking. </returns>
        public static ResourceDeleteCancelEventData ResourceDeleteCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceActionSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionSuccessEventData"/> instance for mocking. </returns>
        public static ResourceActionSuccessEventData ResourceActionSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceActionFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionFailureEventData"/> instance for mocking. </returns>
        public static ResourceActionFailureEventData ResourceActionFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes new instance of ResourceActionCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionCancelEventData"/> instance for mocking. </returns>
        public static ResourceActionCancelEventData ResourceActionCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement, null);
        }

        /// <summary> Initializes a new instance of AcsChatMessageReceivedEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageReceivedEventData AcsChatMessageReceivedEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody)
        {
            return AcsChatMessageReceivedEventData(recipientCommunicationIdentifier, transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatMessageReceivedInThreadEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageReceivedInThreadEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageReceivedInThreadEventData AcsChatMessageReceivedInThreadEventData(string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody)
        {
            return AcsChatMessageReceivedInThreadEventData(transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatMessageEditedEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <param name="editTime"> The time at which the message was edited. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageEditedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageEditedEventData AcsChatMessageEditedEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody, DateTimeOffset? editTime)
        {
            return AcsChatMessageEditedEventData(recipientCommunicationIdentifier, transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>(), editTime);
        }

        /// <summary> Initializes a new instance of AcsChatMessageEditedInThreadEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <param name="editTime"> The time at which the message was edited. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageEditedInThreadEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageEditedInThreadEventData AcsChatMessageEditedInThreadEventData(string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody, DateTimeOffset? editTime)
        {
            return AcsChatMessageEditedInThreadEventData(transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>(), editTime);
        }

        /// <summary> Initializes a new instance of MediaLiveEventIngestHeartbeatEventData. </summary>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="incomingBitrate"> Gets the incoming bitrate. </param>
        /// <param name="lastTimestamp"> Gets the last timestamp. </param>
        /// <param name="timescale"> Gets the timescale of the last timestamp. </param>
        /// <param name="overlapCount"> Gets the fragment Overlap count. </param>
        /// <param name="discontinuityCount"> Gets the fragment Discontinuity count. </param>
        /// <param name="nonincreasingCount"> Gets Non increasing count. </param>
        /// <param name="unexpectedBitrate"> Gets a value indicating whether unexpected bitrate is present or not. </param>
        /// <param name="state"> Gets the state of the live event. </param>
        /// <param name="healthy"> Gets a value indicating whether preview is healthy or not. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIngestHeartbeatEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType, string trackName, long? bitrate, long? incomingBitrate, string lastTimestamp, string timescale, long? overlapCount, long? discontinuityCount, long? nonincreasingCount, bool? unexpectedBitrate, string state, bool? healthy)
        {
            return MediaLiveEventIngestHeartbeatEventData(trackType, trackName, default, default, bitrate, incomingBitrate, default, default, lastTimestamp, timescale, overlapCount, discontinuityCount, nonincreasingCount, unexpectedBitrate, state, healthy);
        }

        /// <summary> Initializes a new instance of MediaLiveEventIngestHeartbeatEventData. </summary>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="transcriptionLanguage"> Gets the Live Transcription language. </param>
        /// <param name="transcriptionState"> Gets the Live Transcription state. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="incomingBitrate"> Gets the incoming bitrate. </param>
        /// <param name="ingestDriftValue"> Gets the track ingest drift value. </param>
        /// <param name="lastFragmentArrivalTime"> Gets the arrival UTC time of the last fragment. </param>
        /// <param name="lastTimestamp"> Gets the last timestamp. </param>
        /// <param name="timescale"> Gets the timescale of the last timestamp. </param>
        /// <param name="overlapCount"> Gets the fragment Overlap count. </param>
        /// <param name="discontinuityCount"> Gets the fragment Discontinuity count. </param>
        /// <param name="nonincreasingCount"> Gets Non increasing count. </param>
        /// <param name="unexpectedBitrate"> Gets a value indicating whether unexpected bitrate is present or not. </param>
        /// <param name="state"> Gets the state of the live event. </param>
        /// <param name="healthy"> Gets a value indicating whether preview is healthy or not. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIngestHeartbeatEventData"/> instance for mocking. </returns>
        public static MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType = null, string trackName = null, string transcriptionLanguage = null, string transcriptionState = null, long? bitrate = null, long? incomingBitrate = null, int? ingestDriftValue = null, DateTimeOffset? lastFragmentArrivalTime = null, string lastTimestamp = null, string timescale = null, long? overlapCount = null, long? discontinuityCount = null, long? nonincreasingCount = null, bool? unexpectedBitrate = null, string state = null, bool? healthy = null)
        {
            return new MediaLiveEventIngestHeartbeatEventData(trackType, trackName, transcriptionLanguage, transcriptionState, bitrate, incomingBitrate, ingestDriftValue == null ? Constants.MediaEvents.NotApplicable : ingestDriftValue.Value.ToString(CultureInfo.InvariantCulture), lastFragmentArrivalTime, lastTimestamp, timescale, overlapCount, discontinuityCount, nonincreasingCount, unexpectedBitrate, state, healthy);
        }

        /// <summary> Initializes a new instance of MediaLiveEventChannelArchiveHeartbeatEventData. </summary>
        /// <param name="channelLatency"> The channel latency. </param>
        /// <param name="latencyResultCode"> The latency result code. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData"/> instance for mocking. </returns>
        public static MediaLiveEventChannelArchiveHeartbeatEventData MediaLiveEventChannelArchiveHeartbeatEventData(TimeSpan? channelLatency = null, string latencyResultCode = null)
        {
            return new MediaLiveEventChannelArchiveHeartbeatEventData(channelLatency == null ? Constants.MediaEvents.NotApplicable : channelLatency.Value.Milliseconds.ToString(CultureInfo.InvariantCulture), latencyResultCode);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <param name="recordingStorageInfo"> The details of recording storage information. </param>
        /// <param name="recordingStartTime"> The time at which the recording started. </param>
        /// <param name="recordingDurationMs"> The recording duration in milliseconds. </param>
        /// <param name="sessionEndReason"> The reason for ending recording session. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(AcsRecordingStorageInfoProperties recordingStorageInfo, DateTimeOffset? recordingStartTime, long? recordingDurationMs, string sessionEndReason)
        {
            return AcsRecordingFileStatusUpdatedEventData(recordingStorageInfo: recordingStorageInfo, recordingStartTime: recordingStartTime, recordingDurationMs: recordingDurationMs, sessionEndReason: sessionEndReason, channelType: null);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <param name="recordingStorageInfo"> The details of recording storage information. </param>
        /// <param name="recordingStartTime"> The time at which the recording started. </param>
        /// <param name="recordingDurationMs"> The recording duration in milliseconds. </param>
        /// <param name="recordingContentType"> The recording content type- AudioVideo, or Audio. </param>
        /// <param name="recordingChannelType"> The recording  channel type - Mixed, Unmixed. </param>
        /// <param name="recordingFormatType"> The recording format type - Mp4, Mp3, Wav. </param>
        /// <param name="sessionEndReason"> The reason for ending recording session. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(AcsRecordingStorageInfoProperties recordingStorageInfo = null, DateTimeOffset? recordingStartTime = null, long? recordingDurationMs = null, RecordingContentType? recordingContentType = null, RecordingChannelType? recordingChannelType = null, RecordingFormatType? recordingFormatType = null, string sessionEndReason = null)
        {
            var contentType = recordingContentType != null ? new AcsRecordingContentType(recordingContentType.ToString()) : null;
            var channelType = recordingChannelType != null ? new AcsRecordingChannelType(recordingChannelType.ToString()) : null;
            var formatType = recordingFormatType != null ? new AcsRecordingFormatType(recordingFormatType.ToString()) : null;
            return AcsRecordingFileStatusUpdatedEventData(recordingStorageInfo, recordingStartTime, recordingDurationMs, contentType, channelType, formatType, sessionEndReason);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData()
        {
            return AcsRecordingFileStatusUpdatedEventData(null, null, null, (RecordingContentType) null, null, null, null);
        }

        /// <summary> Initializes a new instance of AcsRecordingChunkInfoProperties. </summary>
        /// <param name="documentId"> The documentId of the recording chunk. </param>
        /// <param name="index"> The index of the recording chunk. </param>
        /// <param name="endReason"> The reason for ending the recording chunk. </param>
        /// <param name="metadataLocation"> The location of the metadata for this chunk. </param>
        /// <param name="contentLocation"> The location of the content for this chunk. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingChunkInfoProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingChunkInfoProperties AcsRecordingChunkInfoProperties(string documentId, long? index, string endReason, string metadataLocation, string contentLocation)
        {
            return AcsRecordingChunkInfoProperties(documentId: documentId, index: index, endReason: endReason, metadataLocation: metadataLocation, contentLocation: contentLocation, deleteLocation: null);
        }

        /// <summary> Initializes a new instance of ContainerRegistryEventData. </summary>
        /// <param name="id"> The event ID. </param>
        /// <param name="timestamp"> The time at which the event occurred. </param>
        /// <param name="action"> The action that encompasses the provided event. </param>
        /// <param name="target"> The target of the event. </param>
        /// <param name="request"> The request that generated the event. </param>
        /// <param name="actor"> The agent that initiated the event. For most situations, this could be from the authorization context of the request. </param>
        /// <param name="source"> The registry node that generated the event. Put differently, while the actor initiates the event, the source generates it. </param>
        /// <returns> A new <see cref="SystemEvents.ContainerRegistryEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryEventData ContainerRegistryEventData(string id, DateTimeOffset? timestamp, string action, ContainerRegistryEventTarget target, ContainerRegistryEventRequest request, ContainerRegistryEventActor actor, ContainerRegistryEventSource source)
        {
            return ContainerRegistryEventData(id: id, timestamp: timestamp, action: action, target: target, request: request, actor: actor, source: source, location: null);
        }

        /// <summary> Initializes a new instance of ContainerRegistryArtifactEventData. </summary>
        /// <param name="id"> The event ID. </param>
        /// <param name="timestamp"> The time at which the event occurred. </param>
        /// <param name="action"> The action that encompasses the provided event. </param>
        /// <param name="target"> The target of the event. </param>
        /// <returns> A new <see cref="SystemEvents.ContainerRegistryArtifactEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryArtifactEventData ContainerRegistryArtifactEventData(string id = null, DateTimeOffset? timestamp = null, string action = null, ContainerRegistryArtifactEventTarget target = null)
        {
            return ContainerRegistryArtifactEventData(id: id, timestamp: timestamp, action: action, target: target, location: null);
        }

        /// <summary> Initializes a new instance of ResourceHttpRequest. </summary>
        /// <param name="clientRequestId"> The client request ID. </param>
        /// <param name="clientIpAddress"> The client IP address. </param>
        /// <param name="method"> The request method. </param>
        /// <param name="url"> The url used in the request. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceHttpRequest"/> instance for mocking. </returns>
        public static ResourceHttpRequest ResourceHttpRequest(string clientRequestId = null, string clientIpAddress = null, RequestMethod? method = null, string url = null)
        {
            return new ResourceHttpRequest(clientRequestId, clientIpAddress, method?.Method, url, null);
        }

        /// <summary> Initializes a new instance of StorageDirectoryDeletedEventData. </summary>
        /// <param name="api"> The name of the API/operation that triggered this event. </param>
        /// <param name="clientRequestId"> A request id provided by the client of the storage API operation that triggered this event. </param>
        /// <param name="requestId"> The request id generated by the storage service for the storage API operation that triggered this event. </param>
        /// <param name="url"> The path to the deleted directory. </param>
        /// <param name="recursive"> Is this event for a recursive delete operation. </param>
        /// <param name="sequencer"> An opaque string value representing the logical sequence of events for any particular directory name. Users can use standard string comparison to understand the relative sequence of two events on the same directory name. </param>
        /// <param name="identity"> The identity of the requester that triggered this event. </param>
        /// <param name="storageDiagnostics"> For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers. </param>
        /// <returns> A new <see cref="SystemEvents.StorageDirectoryDeletedEventData"/> instance for mocking. </returns>
        public static StorageDirectoryDeletedEventData StorageDirectoryDeletedEventData(string api = null, string clientRequestId = null, string requestId = null, string url = null, bool? recursive = null, string sequencer = null, string identity = null, object storageDiagnostics = null)
        {
            return new StorageDirectoryDeletedEventData(api, clientRequestId, requestId, url, recursive?.ToString(), sequencer, identity, storageDiagnostics, default);
        }

        /// <summary> Initializes a new instance of AcsEmailDeliveryReportReceivedEventData. </summary>
        /// <param name="sender"> The Sender Email Address. </param>
        /// <param name="recipient"> The recipient Email Address. </param>
        /// <param name="messageId"> The Id of the email been sent. </param>
        /// <param name="status"> The status of the email. </param>
        /// <param name="deliveryAttemptTimestamp"> The time at which the email delivery report received timestamp. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailDeliveryReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailDeliveryReportReceivedEventData AcsEmailDeliveryReportReceivedEventData(string sender = null, string recipient = null, string messageId = null, AcsEmailDeliveryReportStatus? status = null, DateTimeOffset? deliveryAttemptTimestamp = null)
        {
            return AcsEmailDeliveryReportReceivedEventData(sender, recipient, default, messageId, status, default, deliveryAttemptTimestamp);
        }

        /// <summary> Initializes a new instance of HealthcareDicomImageCreatedEventData. </summary>
        /// <param name="imageStudyInstanceUid"> Unique identifier for the Study. </param>
        /// <param name="imageSeriesInstanceUid"> Unique identifier for the Series. </param>
        /// <param name="imageSopInstanceUid"> Unique identifier for the DICOM Image. </param>
        /// <param name="serviceHostName"> Domain name of the DICOM account for this image. </param>
        /// <param name="sequenceNumber"> Sequence number of the DICOM Service within Azure Health Data Services. It is unique for every image creation and deletion within the service. </param>
        /// <returns> A new <see cref="SystemEvents.HealthcareDicomImageCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareDicomImageCreatedEventData HealthcareDicomImageCreatedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = null)
        {
            return HealthcareDicomImageCreatedEventData(default, imageStudyInstanceUid, imageSeriesInstanceUid, imageSopInstanceUid, serviceHostName, sequenceNumber);
        }

        /// <summary> Initializes a new instance of HealthcareDicomImageDeletedEventData. </summary>
        /// <param name="imageStudyInstanceUid"> Unique identifier for the Study. </param>
        /// <param name="imageSeriesInstanceUid"> Unique identifier for the Series. </param>
        /// <param name="imageSopInstanceUid"> Unique identifier for the DICOM Image. </param>
        /// <param name="serviceHostName"> Host name of the DICOM account for this image. </param>
        /// <param name="sequenceNumber"> Sequence number of the DICOM Service within Azure Health Data Services. It is unique for every image creation and deletion within the service. </param>
        /// <returns> A new <see cref="SystemEvents.HealthcareDicomImageDeletedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareDicomImageDeletedEventData HealthcareDicomImageDeletedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = null)
        {
            return HealthcareDicomImageDeletedEventData(default, imageStudyInstanceUid, imageSeriesInstanceUid, imageSopInstanceUid, serviceHostName, sequenceNumber);
        }

        /// <summary> Initializes a new instance of AcsEmailEngagementTrackingReportReceivedEventData. </summary>
        /// <param name="sender"> The Sender Email Address. </param>
        /// <param name="messageId"> The Id of the email that has been sent. </param>
        /// <param name="userActionTimestamp"> The time at which the user interacted with the email. </param>
        /// <param name="engagementContext"> The context of the type of engagement user had with email. </param>
        /// <param name="userAgent"> The user agent interacting with the email. </param>
        /// <param name="engagement"> The type of engagement user have with email. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailEngagementTrackingReportReceivedEventData AcsEmailEngagementTrackingReportReceivedEventData(string sender, string messageId, DateTimeOffset? userActionTimestamp, string engagementContext, string userAgent, AcsUserEngagement? engagement)
        {
            return AcsEmailEngagementTrackingReportReceivedEventData(sender, null, messageId, userActionTimestamp, engagementContext, userAgent, engagement);
        }

        /// <summary> Initializes a new instance of AcsRouterJobReceivedEventData. </summary>
        /// <param name="jobId"> Router Event Job ID. </param>
        /// <param name="channelReference"> Router Event Channel Reference. </param>
        /// <param name="channelId"> Router Event Channel ID. </param>
        /// <param name="queueId"> Router Job events Queue Id. </param>
        /// <param name="labels"> Router Job events Labels. </param>
        /// <param name="tags"> Router Jobs events Tags. </param>
        /// <param name="jobStatus"> Router Job Received Job Status. </param>
        /// <param name="classificationPolicyId"> Router Job Classification Policy Id. </param>
        /// <param name="priority"> Router Job Priority. </param>
        /// <param name="requestedWorkerSelectors"> Router Job Received Requested Worker Selectors. </param>
        /// <param name="scheduledOn"> Router Job Received Scheduled Time in UTC. </param>
        /// <param name="unavailableForMatching"> Unavailable For Matching for Router Job Received. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRouterJobReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRouterJobReceivedEventData AcsRouterJobReceivedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, IReadOnlyDictionary<string, string> labels = null, IReadOnlyDictionary<string, string> tags = null, AcsRouterJobStatus? jobStatus = null, string classificationPolicyId = null, int? priority = null, IEnumerable<AcsRouterWorkerSelector> requestedWorkerSelectors = null, DateTimeOffset? scheduledOn = null, bool unavailableForMatching = default)
        {
            labels ??= new Dictionary<string, string>();
            tags ??= new Dictionary<string, string>();
            requestedWorkerSelectors ??= new List<AcsRouterWorkerSelector>();
            Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus? status = jobStatus.HasValue ? new Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus(jobStatus.ToString()) : null;

            return AcsRouterJobReceivedEventData(jobId, channelReference, channelId, queueId, labels, tags, status, classificationPolicyId, priority, requestedWorkerSelectors?.ToList(), scheduledOn, unavailableForMatching);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsIncomingCallEventData"/>. </summary>
        /// <param name="toCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="fromCommunicationIdentifier"> The communication identifier of the user who initiated the call. </param>
        /// <param name="serverCallId"> The Id of the server call. </param>
        /// <param name="callerDisplayName"> Display name of caller. </param>
        /// <param name="customContext"> Custom Context of Incoming Call. </param>
        /// <param name="incomingCallContext"> Signed incoming call context. </param>
        /// <param name="correlationId"> CorrelationId (CallId). </param>
        /// <returns> A new <see cref="SystemEvents.AcsIncomingCallEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsIncomingCallEventData AcsIncomingCallEventData(CommunicationIdentifierModel toCommunicationIdentifier, CommunicationIdentifierModel fromCommunicationIdentifier, string serverCallId, string callerDisplayName, AcsIncomingCallCustomContext customContext, string incomingCallContext, string correlationId)
        {
            return AcsIncomingCallEventData(
                toCommunicationIdentifier,
                fromCommunicationIdentifier,
                serverCallId,
                callerDisplayName,
                customContext,
                incomingCallContext,
                default,
                correlationId);
        }

        /// <summary> Initializes a new instance of ResourceNotificationsResourceUpdatedDetails. </summary>
        /// <param name="id"> id of the resource for which the event is being emitted. </param>
        /// <param name="name"> name of the resource for which the event is being emitted. </param>
        /// <param name="resourceType"> the type of the resource for which the event is being emitted. </param>
        /// <param name="location"> the location of the resource for which the event is being emitted. </param>
        /// <param name="tags"> the tags on the resource for which the event is being emitted. </param>
        /// <param name="properties"> properties in the payload of the resource for which the event is being emitted. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceNotificationsResourceUpdatedDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use the other overload ResourceNotificationsResourceUpdatedDetails.")]
        public static ResourceNotificationsResourceUpdatedDetails ResourceNotificationsResourceUpdatedDetails(string id = null, string name = null, string resourceType = null, string location = null, string tags = null, IReadOnlyDictionary<string, object> properties = null)
        {
            properties ??= new Dictionary<string, object>();

            return ResourceNotificationsResourceUpdatedDetails(id, name, resourceType, location,
                new Dictionary<string, string>(), properties);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.CommunicationIdentifierModel"/>. </summary>
        /// <param name="rawId"> Raw Id of the identifier. Optional in requests, required in responses. </param>
        /// <param name="communicationUser"> The communication user. </param>
        /// <param name="phoneNumber"> The phone number. </param>
        /// <param name="microsoftTeamsUser"> The Microsoft Teams user. </param>
        /// <returns> A new <see cref="SystemEvents.CommunicationIdentifierModel"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunicationIdentifierModel CommunicationIdentifierModel(string rawId, CommunicationUserIdentifierModel communicationUser, PhoneNumberIdentifierModel phoneNumber, MicrosoftTeamsUserIdentifierModel microsoftTeamsUser)
        {
            return CommunicationIdentifierModel(default, rawId, communicationUser, phoneNumber, microsoftTeamsUser, default);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.StorageBlobCreatedEventData"/>. </summary>
        /// <param name="api"> The name of the API/operation that triggered this event. </param>
        /// <param name="clientRequestId"> A request id provided by the client of the storage API operation that triggered this event. </param>
        /// <param name="requestId"> The request id generated by the Storage service for the storage API operation that triggered this event. </param>
        /// <param name="eTag"> The etag of the blob at the time this event was triggered. </param>
        /// <param name="contentType"> The content type of the blob. This is the same as what would be returned in the Content-Type header from the blob. </param>
        /// <param name="contentLength"> The size of the blob in bytes. This is the same as what would be returned in the Content-Length header from the blob. </param>
        /// <param name="contentOffset"> The offset of the blob in bytes. </param>
        /// <param name="blobType"> The type of blob. </param>
        /// <param name="url"> The path to the blob. </param>
        /// <param name="sequencer"> An opaque string value representing the logical sequence of events for any particular blob name. Users can use standard string comparison to understand the relative sequence of two events on the same blob name. </param>
        /// <param name="identity"> The identity of the requester that triggered this event. </param>
        /// <param name="storageDiagnostics"> For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers. </param>
        /// <returns> A new <see cref="SystemEvents.StorageBlobCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageBlobCreatedEventData StorageBlobCreatedEventData(
            string api = null,
            string clientRequestId = null,
            string requestId = null,
            string eTag = null,
            string contentType = null,
            long? contentLength = null,
            long? contentOffset = null,
            string blobType = null,
            string url = null,
            string sequencer = null,
            string identity = null,
            object storageDiagnostics = null)
        {
            return StorageBlobCreatedEventData(api, clientRequestId, requestId, eTag, contentType, contentLength,
                contentOffset, blobType, null, url, sequencer, identity, storageDiagnostics);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.StorageBlobTierChangedEventData"/>. </summary>
        /// <param name="api"> The name of the API/operation that triggered this event. </param>
        /// <param name="clientRequestId"> A request id provided by the client of the storage API operation that triggered this event. </param>
        /// <param name="requestId"> The request id generated by the Storage service for the storage API operation that triggered this event. </param>
        /// <param name="contentType"> The content type of the blob. This is the same as what would be returned in the Content-Type header from the blob. </param>
        /// <param name="contentLength"> The size of the blob in bytes. This is the same as what would be returned in the Content-Length header from the blob. </param>
        /// <param name="blobType"> The type of blob. </param>
        /// <param name="url"> The path to the blob. </param>
        /// <param name="sequencer"> An opaque string value representing the logical sequence of events for any particular blob name. Users can use standard string comparison to understand the relative sequence of two events on the same blob name. </param>
        /// <param name="identity"> The identity of the requester that triggered this event. </param>
        /// <param name="storageDiagnostics"> For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers. </param>
        /// <returns> A new <see cref="SystemEvents.StorageBlobTierChangedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageBlobTierChangedEventData StorageBlobTierChangedEventData(string api = null, string clientRequestId = null, string requestId = null, string contentType = null, long? contentLength = null, string blobType = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null)
        {
            return StorageBlobTierChangedEventData(
                api,
                clientRequestId,
                requestId,
                contentType,
                contentLength,
                blobType,
                null,
                null,
                url,
                sequencer,
                identity,
                storageDiagnostics);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.StorageLifecyclePolicyCompletedEventData"/>. </summary>
        /// <param name="scheduleTime"> The time the policy task was scheduled. </param>
        /// <param name="deleteSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <param name="tierToCoolSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <param name="tierToArchiveSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <returns> A new <see cref="SystemEvents.StorageLifecyclePolicyCompletedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageLifecyclePolicyCompletedEventData StorageLifecyclePolicyCompletedEventData(string scheduleTime, StorageLifecyclePolicyActionSummaryDetail deleteSummary, StorageLifecyclePolicyActionSummaryDetail tierToCoolSummary, StorageLifecyclePolicyActionSummaryDetail tierToArchiveSummary)
        {
            return StorageLifecyclePolicyCompletedEventData(scheduleTime, null, deleteSummary, tierToCoolSummary, default, tierToArchiveSummary);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.StorageLifecyclePolicyCompletedEventData"/>. </summary>
        /// <param name="scheduleTime"> The time the policy task was scheduled. </param>
        /// <param name="deleteSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <param name="tierToCoolSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <param name="tierToColdSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <param name="tierToArchiveSummary"> Execution statistics of a specific policy action in a Blob Management cycle. </param>
        /// <returns> A new <see cref="SystemEvents.StorageLifecyclePolicyCompletedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageLifecyclePolicyCompletedEventData StorageLifecyclePolicyCompletedEventData(string scheduleTime, StorageLifecyclePolicyActionSummaryDetail deleteSummary, StorageLifecyclePolicyActionSummaryDetail tierToCoolSummary, StorageLifecyclePolicyActionSummaryDetail tierToColdSummary, StorageLifecyclePolicyActionSummaryDetail tierToArchiveSummary)
        {
            return StorageLifecyclePolicyCompletedEventData(scheduleTime, null, deleteSummary, tierToCoolSummary, tierToColdSummary, tierToArchiveSummary);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsSmsReceivedEventData"/>. </summary>
        /// <param name="messageId"> The identity of the SMS message. </param>
        /// <param name="from"> The identity of SMS message sender. </param>
        /// <param name="to"> The identity of SMS message receiver. </param>
        /// <param name="message"> The SMS content. </param>
        /// <param name="receivedTimestamp"> The time at which the SMS was received. </param>
        /// <returns> A new <see cref="SystemEvents.AcsSmsReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsSmsReceivedEventData AcsSmsReceivedEventData(string messageId, string @from, string to, string message, DateTimeOffset? receivedTimestamp)
        {
            return AcsSmsReceivedEventData(messageId, @from, to, message, receivedTimestamp, default);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsEmailDeliveryReportReceivedEventData"/>. </summary>
        /// <param name="sender"> The Sender Email Address. </param>
        /// <param name="recipient"> The recipient Email Address. </param>
        /// <param name="messageId"> The Id of the email been sent. </param>
        /// <param name="status"> The status of the email. Any value other than Delivered is considered failed. </param>
        /// <param name="deliveryStatusDetails"> Detailed information about the status if any. </param>
        /// <param name="deliveryAttemptTimestamp"> The time at which the email delivery report received timestamp. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailDeliveryReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailDeliveryReportReceivedEventData AcsEmailDeliveryReportReceivedEventData(string sender, string recipient, string messageId, AcsEmailDeliveryReportStatus? status, AcsEmailDeliveryReportStatusDetails deliveryStatusDetails, DateTimeOffset? deliveryAttemptTimestamp)
        {
            return AcsEmailDeliveryReportReceivedEventData(
                sender,
                recipient,
                default,
                messageId,
                status,
                deliveryStatusDetails,
                deliveryAttemptTimestamp);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsEmailDeliveryReportStatusDetails"/>. </summary>
        /// <param name="statusMessage"> Detailed status message. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailDeliveryReportStatusDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailDeliveryReportStatusDetails AcsEmailDeliveryReportStatusDetails(string statusMessage)
        {
            return AcsEmailDeliveryReportStatusDetails(default, statusMessage);
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsMessageMediaContent"/>. </summary>
        /// <param name="mimeType"> The MIME type of the file this media represents. </param>
        /// <param name="mediaId"> The media identifier. </param>
        /// <param name="fileName"> The filename of the underlying media file as specified when uploaded. </param>
        /// <param name="caption"> The caption for the media object, if supported and provided. </param>
        /// <returns> A new <see cref="SystemEvents.AcsMessageMediaContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsMessageMediaContent AcsMessageMediaContent(string mimeType, string mediaId, string fileName, string caption)
        {
            return AcsMessageMediaContent(mimeType, mediaId, fileName, caption, default);
        }

        /// <summary> Initializes new instance of SubscriptionValidationResponse class. </summary>
        /// <param name="validationResponse"> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </param>
        /// <returns> A new <see cref="SystemEvents.SubscriptionValidationResponse"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionValidationResponse SubscriptionValidationResponse(string validationResponse = default)
        {
            return new(validationResponse);
        }
    }
#pragma warning restore CA1054 // URI-like parameters should not be strings
}
