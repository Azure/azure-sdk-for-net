// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
    {

        //$TODO: this should return FluentResourceT
        protected abstract IFluentResourceT WrapModel(InnerResourceT inner);

        /// <summary>
        /// This method returns a paged list where each page contains the instances that wraps inner resources in the corresponding
        /// page of given inner paged list.
        /// </summary>
        /// <param name="innerList">The paged list of inner resources</param>
        /// <returns>The paged list of wrapped resources</returns>
        protected IEnumerable<IFluentResourceT> WrapList(IEnumerable<InnerResourceT> innerList)
        {
            return innerList.Select(inner => WrapModel(inner));
        }
    }
}
