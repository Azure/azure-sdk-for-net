﻿//-----------------------------------------------------------------------
// <copyright file="IListBlobItem.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the IListBlobItem interface.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Represents an item that may be returned by a blob listing operation.
    /// </summary>
    public interface IListBlobItem
    {
        /// <summary>
        /// Gets the URI to the blob item.
        /// </summary>
        /// <value>The blob item's URI.</value>
        Uri Uri { get; }

        /// <summary>
        /// Gets the blob item's parent.
        /// </summary>
        /// <value>The blob item's parent.</value>
        CloudBlobDirectory Parent { get; }

        /// <summary>
        /// Gets the blob item's container.
        /// </summary>
        /// <value>The blob item's container.</value>
        CloudBlobContainer Container { get; }
    }
}
