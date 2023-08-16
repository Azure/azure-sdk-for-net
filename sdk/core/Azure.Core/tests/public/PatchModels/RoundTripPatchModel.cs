// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a model that can be used for both GET and PATCH operations.
    ///
    /// For GET operations, a model is an output model, as described by https://github.com/Azure/autorest.csharp/issues/2341
    /// For PATCH operations, a model is an input model, as described by https://github.com/Azure/autorest.csharp/issues/2339
    /// For both, a model is a round-trip model, as described by https://github.com/Azure/autorest.csharp/issues/2463
    /// </summary>
    public partial class RoundTripPatchModel
    {
#pragma warning disable AZC0020 // Avoid using banned types in libraries
        private readonly MutableJsonElement _element;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public RoundTripPatchModel(string id)
        {
            // Parse the initial element with JSON containing its id.
            int idLen = id.Length;
            Memory<byte> utf8Json = new byte[9 + idLen];
            "{\"id\":\""u8.CopyTo(utf8Json.Span);
            Encoding.UTF8.GetBytes(id).CopyTo(utf8Json.Span.Slice(7));
            "\"}"u8.CopyTo(utf8Json.Span.Slice(7 + idLen));
            _element = MutableJsonDocument.Parse(utf8Json).RootElement;
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        internal RoundTripPatchModel() { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal RoundTripPatchModel(MutableJsonElement element)
        {
            _element = element;
        }

        /// <summary>
        /// Required and read-only string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id => _element.GetProperty("id").GetString();

        /// <summary>
        /// Optional read/write int property corresponding to JSON """{"value": 1}""".
        /// </summary>
        public int? Value
        {
            get
            {
                if (_element.TryGetProperty("value", out MutableJsonElement value))
                {
                    return value.GetInt32();
                }
                return null;
            }
            set => _element.SetProperty("value", value);
        }
#pragma warning restore AZC0020 // Avoid using banned types in libraries
    }
}
