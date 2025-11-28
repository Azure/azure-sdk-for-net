// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.Speech.Transcription;

/// <summary> TranscribedPhrases. </summary>
public partial class TranscribedPhrases
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TranscribedPhrases"/> class.
    /// </summary>
    /// <param name="Channel"> The 0-based channel index. Only present if channel separation is enabled. </param>
    /// <param name="Text"> The complete transcribed text for the channel. </param>
    /// <param name="Phrases"> The transcription results segmented into phrases.</param>
    public TranscribedPhrases(int? Channel, string Text, IEnumerable<TranscribedPhrase> Phrases)
    {
        this.Channel = Channel;
        this.Text = Text;
        this.Phrases = Phrases;
    }

    /// <summary> The 0-based channel index. Only present if channel separation is enabled. </summary>
    public int? Channel;

    /// <summary> The complete transcribed text for the channel. </summary>
    public string Text { get; }

    /// <summary> The transcription results segmented into phrases. </summary>

    public IEnumerable<TranscribedPhrase> Phrases;
}
