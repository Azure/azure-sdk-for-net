// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

public readonly partial struct AudioTranscriptionFormat : IEquatable<AudioTranscriptionFormat>
{
    // CUSTOM CODE NOTE:
    // Since we use strongly-typed classes to represent the response, there is virtually no
    // difference between the "json" and "text" formats from the perspective of the user. To avoid
    // any confusion, hide the latter by marking the "text" extensible enum value as internal.

    /// <summary> Use a response body that is plain text containing the raw, unannotated transcription. </summary>
    internal static AudioTranscriptionFormat InternalPlainText { get; } = new AudioTranscriptionFormat(InternalPlainTextValue);
}
