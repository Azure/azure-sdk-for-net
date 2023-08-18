// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary>
        /// Public constructor.
        /// </summary>
        public RoundTripPatchModel(string id)
        {
            _id = id;
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        internal RoundTripPatchModel() { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal RoundTripPatchModel(string id, int value)
        {
            _id = id;
            _value = value;
        }

        private string _id;
        /// <summary>
        /// Required and read-only string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id => _id;

        private int? _value;
        private bool _valuePatchFlag;
        /// <summary>
        /// Optional read/write int property corresponding to JSON """{"value": 1}""".
        /// </summary>
        public int? Value
        {
            get => _value;
            set
            {
                _value = value;
                _valuePatchFlag = true;
            }
        }
#pragma warning restore AZC0020 // Avoid using banned types in libraries
    }
}
