// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a generic azure resource along with the instance operations that can be performed on it.
    /// </summary>
    public class Provider : ProviderOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Provider"/> class for mocking.
        /// </summary>
        protected Provider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Provider"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="providerData"></param>
        /// <exception cref="ArgumentNullException"> If <see cref="ArmClientOptions"/> or <see cref="TokenCredential"/> is null. </exception>
        internal Provider(OperationsBase operations, ProviderData providerData)
            : base(operations, providerData.Id)
        {
            Data = providerData;
        }

        internal Provider(ProviderData result) => Data = result;

        /// <summary>
        /// Gets the data representing this generic azure resource.
        /// </summary>
        public virtual ProviderData Data { get; }
    }
}
