// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorResponse. </summary>
    internal partial class ErrorResponse_internal
    {
        public FormRecognizerError Error { get; set; } = new FormRecognizerError();
    }
}
