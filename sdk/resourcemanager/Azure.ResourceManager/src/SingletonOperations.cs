// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class SingletonOperations : ResourceOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonOperations"/> class for mocking.
        /// </summary>
        protected SingletonOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonOperations"/> class.
        /// </summary>
        /// <param name="parent"></param>
        protected SingletonOperations(ResourceOperations parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), ResourceIdentifier.RootResourceIdentifier)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ResourceOperations Parent { get; }
    }
}
