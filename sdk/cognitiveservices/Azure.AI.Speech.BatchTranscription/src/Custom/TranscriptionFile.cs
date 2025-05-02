// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> TranscriptionFile. </summary>
public partial class TranscriptionFile
{
    private string _id;

    internal Uri Self { get; }

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
