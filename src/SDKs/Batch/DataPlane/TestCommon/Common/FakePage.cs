// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchTestCommon
{
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;

    public class FakePage<T> : IPage<T>
    {
        public FakePage(IList<T> collection, string nextPageLink = null)
        {
            this.NextPageLink = nextPageLink;
            this.Collection = collection;
        }

        public string NextPageLink { get; private set; }

        private IList<T> Collection { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
