// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
    /// </summary>
    public class PreDefinedTags : PreDefinedTagsOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTags"/> class for mocking.
        /// </summary>
        protected PreDefinedTags()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTags"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tagDetails
        /// "> The data model representing the generic azure resource. </param>
        internal PreDefinedTags(OperationsBase operations, PreDefinedTagData tagDetails)
            : base(new ClientContext(operations.ClientOptions,operations.Credential, operations.BaseUri, operations.Pipeline), operations.Id.Parent, tagDetails)
        {
            Details = tagDetails;
        }

        /// <summary>
        /// Gets the Tags data model.
        /// </summary>
        public virtual PreDefinedTagData Details { get; }
    }
}
