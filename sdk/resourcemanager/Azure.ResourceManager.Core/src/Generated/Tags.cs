// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
    /// </summary>
    public class Tags : TagsOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tags"/> class for mocking.
        /// </summary>
        protected Tags()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tags"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tagDetails
        /// "> The data model representing the generic azure resource. </param>
        internal Tags(OperationsBase operations, TagDetails tagDetails)
            : base(new ClientContext(operations.ClientOptions,operations.Credential, operations.BaseUri, operations.Pipeline), new SubscriptionResourceIdentifier())
        {
            Details = tagDetails;
        }

        /// <summary>
        /// Gets the Tags data model.
        /// </summary>
        public virtual TagDetails Details { get; }
    }
}
