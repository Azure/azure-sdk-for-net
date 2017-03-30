// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Exposes enumerators for a paged collection. These enumerators support simple iteration over a paged collection of a specified type.
    /// 
    /// Paged collections are backed by one or more calls to the Batch Service.  
    /// Each of these calls can return a variable sized page of data which is then consumed by the enumerator. 
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    public interface IPagedEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// Returns an asynchronous enumerator that iterates through the paged collection.
        /// </summary>
        /// <returns>The type of objects to enumerate.</returns>
        IPagedEnumerator<T> GetPagedEnumerator();
    }
}
