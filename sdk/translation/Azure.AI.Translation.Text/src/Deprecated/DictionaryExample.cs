// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Dictionary Example. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DictionaryExample : IJsonModel<DictionaryExample>
    {
        /// <summary> Initializes a new instance of DictionaryExample. </summary>
        internal DictionaryExample() { }

        /// <summary>
        /// The string to concatenate before the value of sourceTerm to form a complete example.
        /// Do not add a space character, since it is already there when it should be.
        /// This value may be an empty string.
        /// </summary>
        public string SourcePrefix { get; }
        /// <summary>
        /// A string equal to the actual term looked up. The string is added with sourcePrefix
        /// and sourceSuffix to form the complete example. Its value is separated so it can be
        /// marked in a user interface, e.g., by bolding it.
        /// </summary>
        public string SourceTerm { get; }
        /// <summary>
        /// The string to concatenate after the value of sourceTerm to form a complete example.
        /// Do not add a space character, since it is already there when it should be.
        /// This value may be an empty string.
        /// </summary>
        public string SourceSuffix { get; }
        /// <summary> A string similar to sourcePrefix but for the target. </summary>
        public string TargetPrefix { get; }
        /// <summary> A string similar to sourceTerm but for the target. </summary>
        public string TargetTerm { get; }
        /// <summary> A string similar to sourceSuffix but for the target. </summary>
        public string TargetSuffix { get; }

        DictionaryExample IJsonModel<DictionaryExample>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExample is deprecated and not supported.");
        }

        DictionaryExample IPersistableModel<DictionaryExample>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExample is deprecated and not supported.");
        }

        string IPersistableModel<DictionaryExample>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExample is deprecated and not supported.");
        }

        void IJsonModel<DictionaryExample>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExample is deprecated and not supported.");
        }

        BinaryData IPersistableModel<DictionaryExample>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExample is deprecated and not supported.");
        }
    }
}
