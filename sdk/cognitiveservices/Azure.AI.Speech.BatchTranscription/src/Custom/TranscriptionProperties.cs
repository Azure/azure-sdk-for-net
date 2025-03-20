// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> TranscriptionProperties. </summary>
public partial class TranscriptionProperties
{
    /// <summary>
    /// The duration of the transcription.
    /// </summary>
    public TimeSpan? Duration
    {
        get
        {
            return DurationMilliseconds.HasValue ? TimeSpan.FromMilliseconds(DurationMilliseconds.Value) : null;
        }
    }

    /// <summary>
    /// How long the transcription will be kept in the system after it has completed. Once the transcription reaches the time to live after completion(successful or failed) it will be automatically deleted.
    ///
    /// Note: When using BYOS (bring your own storage), the result files on the customer owned storage account will also be deleted.Use either destinationContainerUrl to specify a separate container for result files which will not be deleted when the timeToLive expires, or retrieve the result files through the API and store them as needed.
    ///
    /// The shortest supported duration is 6 hours, the longest supported duration is 31 days. 2 days (48 hours) is the recommended default value when data is consumed directly.
    /// </summary>
    public TimeSpan TimeToLive
    {
        get
        {
            return TimeSpan.FromHours(TimeToLiveHours);
        }
    }

    /// <summary>
    /// The duration in milliseconds of the transcription.
    /// Durations larger than 2^53-1 are not supported to ensure compatibility with JavaScript integers.
    /// </summary>
    internal int? DurationMilliseconds { get; }

    /// <summary>
    /// How long the transcription will be kept in the system after it has completed. Once the transcription reaches the time to live after completion(successful or failed) it will be automatically deleted.
    ///
    /// Note: When using BYOS (bring your own storage), the result files on the customer owned storage account will also be deleted.Use either destinationContainerUrl to specify a separate container for result files which will not be deleted when the timeToLive expires, or retrieve the result files through the API and store them as needed.
    ///
    /// The shortest supported duration is 6 hours, the longest supported duration is 31 days. 2 days (48 hours) is the recommended default value when data is consumed directly.
    /// </summary>
    internal int TimeToLiveHours { get; set; }
}
