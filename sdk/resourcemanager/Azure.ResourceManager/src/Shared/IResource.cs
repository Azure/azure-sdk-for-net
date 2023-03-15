// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager
{
    /// <summary>
    /// Represent resource of data
    /// </summary>
    internal interface IResource
    {
        /// <summary>
        /// Represent data for the resrouce.
        /// </summary>
        ISerializable DataBag { get; }
    }
}
