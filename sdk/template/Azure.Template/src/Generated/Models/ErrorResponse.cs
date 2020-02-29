// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorResponse. </summary>
    public partial class ErrorResponse
    {
        public FormRecognizerError Error { get; set; } = new FormRecognizerError();
    }
}
