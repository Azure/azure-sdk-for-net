// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
    {

        //$TODO: this should return FluentResourceT
        protected abstract IFluentResourceT WrapModel(InnerResourceT inner);

        /// <summary>
        /// This method returns a paged list where each page contains the instances that wraps inner resources in the corrosponding
        /// page of given inner paged list.
        /// </summary>
        /// <param name="innerList">The paged list of inner resources</param>
        /// <returns>The paged list of wrapped resources</returns>
        protected PagedList<IFluentResourceT> WrapList(PagedList<InnerResourceT> innerList)
        {
            return PagedListConverter.Convert(innerList, WrapModel);
        }

        /// <summary>
        /// This method returns a paged list with single page containing instances that wraps inner resources in the given list.
        /// </summary>
        /// <param name="innerList">The list of inner resources</param>
        /// <returns>The paged list of wrapped resources</returns>
        protected PagedList<IFluentResourceT> WrapList(IList<InnerResourceT> innerList)
        {
            return PagedListConverter.Convert(innerList, WrapModel);
        }
    }
}
