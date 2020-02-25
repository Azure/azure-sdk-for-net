// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted key-value pair. </summary>
    public partial class KeyValuePair
    {
        /// <summary> A user defined label for the key/value pair entry. </summary>
        public string Label { get; set; }
        /// <summary> Information about the extracted key or value in a key-value pair. </summary>
        public KeyValueElement Key { get; set; } = new KeyValueElement();
        /// <summary> Information about the extracted key or value in a key-value pair. </summary>
        public KeyValueElement Value { get; set; } = new KeyValueElement();
        /// <summary> Confidence value. </summary>
        public float Confidence { get; set; }
    }
}
