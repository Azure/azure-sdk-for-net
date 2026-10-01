// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

#pragma warning disable OPENAI001
#pragma warning disable AAIP001
#pragma warning disable AAIP002

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary> The ProjectConversationCreationOptions. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ProjectConversationCreationOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
        /// <param name="internalMetadata"></param>
        /// <param name="items"></param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal ProjectConversationCreationOptions(InternalMetadataContainer internalMetadata, IList<global::OpenAI.Responses.ResponseItem> items, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            InternalMetadata = internalMetadata;
            Items = items;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
