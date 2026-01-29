// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Input text in the default script of the source language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SourceText : IJsonModel<SourceText>
    {
        /// <summary> Initializes a new instance of SourceText. </summary>
        internal SourceText() { }

        /// <summary> Input text in the default script of the source language. </summary>
        public string Text { get; }

        SourceText IJsonModel<SourceText>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceText is deprecated and not supported.");
        }

        SourceText IPersistableModel<SourceText>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceText is deprecated and not supported.");
        }

        string IPersistableModel<SourceText>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceText is deprecated and not supported.");
        }

        void IJsonModel<SourceText>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceText is deprecated and not supported.");
        }

        BinaryData IPersistableModel<SourceText>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceText is deprecated and not supported.");
        }
    }
}
