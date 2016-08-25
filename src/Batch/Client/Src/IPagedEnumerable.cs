// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
