// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class FakeActivator : IJobActivator
    {
        private Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public FakeActivator(params object[] objs)
        {
            foreach (var obj in objs)
            {
                Add(obj);
            }
        }

        public void Add(object o)
        {
            _instances[o.GetType()] = o;
        }

        public T CreateInstance<T>()
        {
            return (T)_instances[typeof(T)];
        }
    }
}
