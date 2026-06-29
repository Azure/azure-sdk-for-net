// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.Extensions.OpenAI
{
    [CodeGenSuppress(nameof(InternalMetadataContainer), typeof(IReadOnlyDictionary<string, string>), typeof(IDictionary<string, BinaryData>))]
    internal partial class InternalMetadataContainer
    {
        /// <summary> Initializes a new instance of <see cref="InternalMetadataContainer"/>. </summary>
        /// <param name="additionalProperties"></param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal InternalMetadataContainer(IDictionary<string, string> additionalProperties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            _additionalStringProperties = new ChangeTrackingDictionary<string, string>(additionalProperties);
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets the AdditionalProperties. </summary>
        public IDictionary<string, string> AdditionalProperties => _additionalStringProperties;
    }
}
