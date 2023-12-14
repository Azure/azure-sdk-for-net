// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Tests.Client.Models.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    public partial class WritableSubResource
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="WritableSubResource"/> for mocking.
        /// </summary>
        public WritableSubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        protected internal WritableSubResource(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public string Id { get; set; }
    }
}
