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
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Exposes synchronous and asynchronous enumerators based on async calls to server.
    /// </summary>
    internal class PagedEnumerable<EnumerationType> : IPagedEnumerable<EnumerationType>
    {
        private readonly NewEnumeratorFactory _enumeratorFactory;

        #region //constructors

        private PagedEnumerable()
        {
        }

        internal PagedEnumerable(NewEnumeratorFactory enumeratorFactory)
        {
            _enumeratorFactory = enumeratorFactory;
        }

        #endregion // constructors

        // this factory is called on every call to "GetEnumerator()"
        // it returns the derived class that implements the specific
        // protocol calls to traverse the collection
        internal delegate PagedEnumeratorBase<EnumerationType> NewEnumeratorFactory();


        // IEnumerable
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            PagedEnumeratorBase<EnumerationType> newEnumerator = _enumeratorFactory();

            return newEnumerator;
        }

        // IEnumerable<T>
        public IEnumerator<EnumerationType> GetEnumerator()
        {
            PagedEnumeratorBase<EnumerationType> newEnumerator = _enumeratorFactory();

            return newEnumerator;
        }

        // IPagedEnumerable
        public IPagedEnumerator<EnumerationType> GetPagedEnumerator()
        {
            PagedEnumeratorBase<EnumerationType> newEnumerator = _enumeratorFactory();

            return newEnumerator;
        }
    }
}
