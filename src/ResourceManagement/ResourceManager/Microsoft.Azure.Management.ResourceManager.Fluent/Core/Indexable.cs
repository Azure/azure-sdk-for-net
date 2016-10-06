// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using System;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public class Indexable : IIndexable
    {
        protected Indexable()
        {
            Key = Guid.NewGuid().ToString();
        }

        public string Key
        {
            get; private set;
        }
    }
}
