// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Customizes the generated VectorQuery to expose Fields as a list.
    /// </summary>
    [CodeGenSuppress("DeserializeVectorQuery", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public abstract partial class VectorQuery
    {
        /// <summary> Vector Fields of type Collection(Edm.Single) to be included in the vector searched. </summary>
        public IList<string> Fields { get; internal set; } = new List<string>();

        /// <summary>
        /// Join Fields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("Fields")]
        internal string FieldsRaw
        {
            get => Fields.CommaJoin();
            set => Fields = InternalSearchExtensions.CommaSplit(value);
        }

        internal static VectorQuery DeserializeVectorQuery(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "imageBinary":
                        return VectorizableImageBinaryQuery.DeserializeVectorizableImageBinaryQuery(element, options);
                    case "imageUrl":
                        return VectorizableImageUrlQuery.DeserializeVectorizableImageUrlQuery(element, options);
                    case "text":
                        return VectorizableTextQuery.DeserializeVectorizableTextQuery(element, options);
                    case "vector":
                        return VectorizedQuery.DeserializeVectorizedQuery(element, options);
                }
            }

            return UnknownVectorQuery.DeserializeUnknownVectorQuery(element, options);
        }
    }
}
