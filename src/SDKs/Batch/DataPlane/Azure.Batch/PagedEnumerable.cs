// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
