// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class NullEntityValueProvider<TElement> : IValueProvider
    {
        private readonly TableEntityContext _entityContext;

        public NullEntityValueProvider(TableEntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public Type Type => typeof(TElement);

        public Task<object> GetValueAsync()
        {
            return Task.FromResult((object)default(TElement));
        }

        public string ToInvokeString()
        {
            return _entityContext.ToInvokeString();
        }
    }
}