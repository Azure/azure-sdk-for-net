// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public interface IManager<InnerT> : IHasInner<InnerT>, IManagerBase
    {
        RestClient RestClient { get; }
    }

    public abstract class Manager<InnerT> : ManagerBase, IManager<InnerT>
    {
        public InnerT Inner { get; private set; }
        public RestClient RestClient { get; private set; }

        public Manager(RestClient restClient, string subscriptionId, InnerT inner) : base(restClient, subscriptionId)
        {
            Inner = inner;
            RestClient = restClient;
        }
    }
}
