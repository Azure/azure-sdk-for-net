// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.Transcription;

/// <summary> The content of a transcription file. </summary>
public class TranscriptionFileContent
{
    /// <summary> The source used to create the transcription. </summary>
    public Uri source { get; set; }
    /// <summary> The timestamp the transcription was created at. </summary>
    public DateTime timestamp { get; set; }
    /// <summary> The duration in ticks of the transcribed audio. </summary>
    public long durationInTicks { get; set; }
    /// <summary> The duration in milliseconds of the transcribed audio. </summary>
    public long durationMilliseconds { get; set; }
    /// <summary> The combined recognized phrases of the transcription. </summary>
    public CombinedRecognizedPhrase[] combinedRecognizedPhrases { get; set; }
    /// <summary> The recognized phrases of the transcription. </summary>
    public RecognizedPhrase[] recognizedPhrases { get; set; }
}

/// <summary> A combined recognized phrase of a transcription file. </summary>
public class CombinedRecognizedPhrase
{
    /// <summary> The channel that the phrase was transcribed from. </summary>
    public int channel { get; set; }
    /// <summary> The lexical phrase. </summary>
    public string lexical { get; set; }
    /// <summary> The itn phrase. </summary>
    public string itn { get; set; }
    /// <summary> The maskedITN phrase. </summary>
    public string maskedITN { get; set; }
    /// <summary> The display phrase. </summary>
    public string display { get; set; }
}

/// <summary> A recognized phrase of a transcription file. </summary>
public class RecognizedPhrase
{
    /// <summary> The recognition status of the phrase. </summary>
    public string recognitionStatus { get; set; }
    /// <summary> The channel that the phrase was transcribed from. </summary>
    public int? channel { get; set; }
    /// <summary> The speaker that is associated with the phrase. </summary>
    public int? speaker { get; set; }
    /// <summary> The offset in ticks of the phrase. </summary>
    public long offsetInTicks { get; set; }
    /// <summary> The duration in ticks of the phrase. </summary>
    public long durationInTicks { get; set; }
    /// <summary> The duration in milliseconds of the phrase. </summary>
    public long durationMilliseconds { get; set; }
    /// <summary> The offset in milliseconds of the phrase. </summary>
    public long offsetMilliseconds { get; set; }
    /// <summary> The nBest of the transcribed phrase. </summary>
    public Best[] nBest { get; set; }
}

#pragma warning disable AZC0012 // Single word class names are too generic (Justification: Needed for the deserialization of a response of an existing service)
/// <summary> A combined recognized phrase of a transcription file </summary>
public class Best
{
    /// <summary> The confidence for the transcribed phrase. </summary>
    public float confidence { get; set; }
    /// <summary> The lexical phrase. </summary>
    public string lexical { get; set; }
    /// <summary> The itn phrase. </summary>
    public string itn { get; set; }
    /// <summary> The maskedITN phrase. </summary>
    public string maskedITN { get; set; }
    /// <summary> The display phrase. </summary>
    public string display { get; set; }
}
#pragma warning restore  AZC0012 // Single word class names are too generic
