// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.Client.Models.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    public partial class WritableSubResource
    {
        [Experimental("SCME0001")]
        private JsonPatch _patch = new();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Experimental("SCME0001")]
        public ref JsonPatch Patch => ref _patch;

        /// <summary>
        /// Initializes an empty instance of <see cref="WritableSubResource"/> for mocking.
        /// </summary>
        public WritableSubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        protected internal WritableSubResource(string? id, in JsonPatch jsonPatch)
        {
            Id = id;
            _patch = jsonPatch;
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        /// <summary>
        /// Gets or sets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public string? Id { get; set; }
    }
}
