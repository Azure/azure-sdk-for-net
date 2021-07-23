// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
    /// </summary>
    public class PredefinedTag : PredefinedTagOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PredefinedTag"/> class for mocking.
        /// </summary>
        protected PredefinedTag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PredefinedTag"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="data"> The data model representing the generic azure resource. </param>
        internal PredefinedTag(OperationsBase operations, PredefinedTagData data)
            : base(new ClientContext(operations.ClientOptions,operations.Credential, operations.BaseUri, operations.Pipeline), operations.Id)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the Tags data model.
        /// </summary>
        public virtual PredefinedTagData Data { get; }
    }
}
