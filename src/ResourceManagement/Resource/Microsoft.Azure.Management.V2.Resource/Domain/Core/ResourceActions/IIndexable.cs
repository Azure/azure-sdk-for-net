/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{

    /// <summary>
    /// Base interface for all models that can be indexed by a key.
    /// </summary>
    public interface IIndexable 
    {
        /// <returns>the index key.</returns>
        string Key { get; }

    }
}