// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted key-value pair. </summary>
    internal partial class KeyValuePair_internal
    {
        /// <summary> A user defined label for the key/value pair entry. </summary>
        public string Label { get; set; }
        /// <summary> Information about the extracted key or value in a key-value pair. </summary>
        public KeyValueElement_internal Key { get; set; } = new KeyValueElement_internal();
        /// <summary> Information about the extracted key or value in a key-value pair. </summary>
        public KeyValueElement_internal Value { get; set; } = new KeyValueElement_internal();
        /// <summary> Confidence value. </summary>
        public float Confidence { get; set; }
    }
}
