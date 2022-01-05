// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a ResourceGroup along with the instance operations that can be performed on it. </summary>
    public partial class ResourceGroup : ArmResource
    {
        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }
    }
}
