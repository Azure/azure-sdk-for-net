// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Host.Hosting
{
    internal class TrackedServiceCollection : IServiceCollection, ITrackedServiceCollection
    {
        private List<ServiceDescriptor> _trackedChanges { get; set; }

        public IServiceCollection ServiceCollection { get; set; }

        public IEnumerable<ServiceDescriptor> TrackedCollectionChanges => _trackedChanges; // tracks any service collection modification.

        public TrackedServiceCollection(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection == null ? new ServiceCollection() : serviceCollection;
            _trackedChanges = new List<ServiceDescriptor>();
        }

        public ServiceDescriptor this[int index] { get => ServiceCollection[index]; set => ServiceCollection[index] = value; }

        public int Count => ServiceCollection.Count;

        public bool IsReadOnly => ServiceCollection.IsReadOnly;

        public void Add(ServiceDescriptor item)
        {
            _trackedChanges.Add(item);
            ServiceCollection.Add(item);
        }

        public void Clear()
        {
            _trackedChanges.Clear();
            ServiceCollection.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
           return ServiceCollection.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            ServiceCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
           return ServiceCollection.GetEnumerator();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return ServiceCollection.IndexOf(item);
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            _trackedChanges.Add(item);
            ServiceCollection.Insert(index, item);
        }

        public bool Remove(ServiceDescriptor item)
        {
            _trackedChanges.Remove(item);
            return ServiceCollection.Remove(item);
        }

        public void RemoveAt(int index)
        {
            ServiceDescriptor item = ServiceCollection[index];
            _trackedChanges.Remove(item);
            ServiceCollection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ServiceCollection.GetEnumerator();
        }

        public void ResetTracking()
        {
            _trackedChanges.Clear();
        }
    }
}
