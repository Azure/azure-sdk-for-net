// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public class Indexable : IIndexable
    {
        protected Indexable(string key)
        {
            Key = key;
        }

        public string Key
        {
            get; private set;
        }
    }
}
