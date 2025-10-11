// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> Transcription. </summary>
public partial class TranscriptionJob
{
    private string _id;

    internal Uri Self { get; }

    internal TranscriptionLinks Links { get; set; }

    /// <summary> The id of this entity. </summary>
    public string Id
    {
        get
        {
            if (_id != null)
            {
                return _id;
            }

            return this.Self.Segments[this.Self.Segments.Length - 1];
        }

        set
        {
            _id = value;
        }
    }
}
