// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> The content of a transcription file. </summary>
public class TranscriptionFileContent
{
    /// <summary> The source used to create the transcription. </summary>
    public Uri Source { get; }
    /// <summary> The timestamp the transcription was created at. </summary>
    public DateTime Timestamp { get; }
    /// <summary> The duration in ticks of the transcribed audio. </summary>
    public long DurationInTicks { get; }
    /// <summary> The duration in milliseconds of the transcribed audio. </summary>
    internal long DurationMilliseconds { get; }
    /// <summary> The duration of the transcribed audio. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }
    /// <summary> The combined recognized phrases of the transcription. </summary>
    public CombinedRecognizedPhrase[] CombinedRecognizedPhrases { get; }
    /// <summary> The recognized phrases of the transcription. </summary>
    public RecognizedPhrase[] RecognizedPhrases { get; }
}

/// <summary> A combined recognized phrase of a transcription file. </summary>
public class CombinedRecognizedPhrase
{
    /// <summary> The channel that the phrase was transcribed from. </summary>
    public int Channel { get; }
    /// <summary> The lexical phrase. </summary>
    public string Lexical { get; }
    /// <summary> The itn phrase. </summary>
    public string InverseTextNormalization
    {
        get
        {
            return Itn;
        }
    }
    internal string Itn { get; }
    /// <summary> The maskedITN phrase. </summary>
    public string MaskedInverseTextNormalization
    {
        get
        {
            return MaskedITN;
        }
    }
    internal string MaskedITN { get; }
    /// <summary> The display phrase. </summary>
    public string Display { get; }
}

/// <summary> A recognized phrase of a transcription file. </summary>
public class RecognizedPhrase
{
    /// <summary> The recognition status of the phrase. </summary>
    public string RecognitionStatus { get; }
    /// <summary> The channel that the phrase was transcribed from. </summary>
    public int? Channel { get; }
    /// <summary> The speaker that is associated with the phrase. </summary>
    public int? Speaker { get; }
    /// <summary> The offset in ticks of the phrase. </summary>
    public long OffsetInTicks { get; }
    /// <summary> The duration in ticks of the phrase. </summary>
    public long DurationInTicks { get; }
    /// <summary> The duration in milliseconds of the phrase. </summary>
    internal long DurationMilliseconds { get; }
    /// <summary> The duration of the phrase. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }
    /// <summary> The offset in milliseconds of the phrase. </summary>
    internal long OffsetMilliseconds { get; }
    /// <summary> The offset of the phrase. </summary>
    public TimeSpan Offset
    {
        get
        {
            return TimeSpan.FromMilliseconds(OffsetMilliseconds);
        }
    }
    /// <summary> The nBest of the transcribed phrase. </summary>
    public BestPhrase[] NBest { get; }
}

/// <summary> Content of a recognized phrase of a transcription file </summary>
public class BestPhrase
{
    /// <summary> The confidence for the transcribed phrase. </summary>
    public float Confidence { get; }
    /// <summary> The lexical phrase. </summary>
    public string Lexical { get; }
    /// <summary> The itn phrase. </summary>
    public string InverseTextNormalization
    {
        get
        {
            return Itn;
        }
    }
    internal string Itn { get; }
    /// <summary> The maskedITN phrase. </summary>
    public string MaskedInverseTextNormalization
    {
        get
        {
            return MaskedITN;
        }
    }
    internal string MaskedITN { get; }
    /// <summary> The display phrase. </summary>
    public string Display { get; }
}
#pragma warning restore AZC0012 // Single word class names are too generic
