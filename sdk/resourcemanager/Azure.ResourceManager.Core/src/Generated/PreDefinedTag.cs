// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
    /// </summary>
    public class PreDefinedTag : PreDefinedTagOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTag"/> class for mocking.
        /// </summary>
        protected PreDefinedTag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTag"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tagDetails
        /// "> The data model representing the generic azure resource. </param>
        internal PreDefinedTag(OperationsBase operations, PreDefinedTagData tagDetails)
            : base(new ClientContext(operations.ClientOptions,operations.Credential, operations.BaseUri, operations.Pipeline), operations.Id)
        {
            Details = tagDetails;
        }

        /// <summary>
        /// Gets the Tags data model.
        /// </summary>
        public virtual PreDefinedTagData Details { get; }
    }
}
