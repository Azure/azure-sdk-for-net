// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Data;
    using Microsoft.ServiceFabric.Data.Collections;
    using Microsoft.ServiceFabric.Data.Notifications;

    class MockReliableDictionary<X, Y> : IReliableDictionary<X, Y> where X : System.IEquatable<X>, System.IComparable<X>
    {
        private Dictionary<X, Y> innerDictionary = new Dictionary<X, Y>();

        public Task SetAsync(ITransaction tx, X key, Y value, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Puts key/value in dictionary, throwing away any current value for key.
            this.innerDictionary[key] = value;
            return Task.CompletedTask;
        }

        public Task<ConditionalValue<Y>> TryGetValueAsync(ITransaction tx, X key, TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (this.innerDictionary.ContainsKey(key))
            {
                return Task.FromResult<ConditionalValue<Y>>(new ConditionalValue<Y>(true, this.innerDictionary[key]));
            }
            Y dummy = default(Y);
            return Task.FromResult<ConditionalValue<Y>>(new ConditionalValue<Y>(false, dummy));
        }

        #region unused
        // Unused
        public Func<IReliableDictionary<X, Y>, NotifyDictionaryRebuildEventArgs<X, Y>, Task> RebuildNotificationAsyncCallback { set => throw new NotImplementedException(); }

        // Unused
        public Uri Name => throw new NotImplementedException();

        // Unused
        // This event is part of the IReliableDictionary interface and must be present, but without the pragma
        // the compiler warns that it is never used, the warnings are treated as errors, and the build fails.
        // The pragma is less ugly than adding a fake use of this event.
#pragma warning disable 67
        public event EventHandler<NotifyDictionaryChangedEventArgs<X, Y>> DictionaryChanged;
#pragma warning restore 67

        public Task AddAsync(ITransaction tx, X key, Y value)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task AddAsync(ITransaction tx, X key, Y value, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> AddOrUpdateAsync(ITransaction tx, X key, Func<X, Y> addValueFactory, Func<X, Y, Y> updateValueFactory)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> AddOrUpdateAsync(ITransaction tx, X key, Y addValue, Func<X, Y, Y> updateValueFactory)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> AddOrUpdateAsync(ITransaction tx, X key, Func<X, Y> addValueFactory, Func<X, Y, Y> updateValueFactory, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> AddOrUpdateAsync(ITransaction tx, X key, Y addValue, Func<X, Y, Y> updateValueFactory, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task ClearAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task ClearAsync()
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> ContainsKeyAsync(ITransaction tx, X key)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> ContainsKeyAsync(ITransaction tx, X key, LockMode lockMode)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> ContainsKeyAsync(ITransaction tx, X key, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> ContainsKeyAsync(ITransaction tx, X key, LockMode lockMode, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<KeyValuePair<X, Y>>> CreateEnumerableAsync(ITransaction txn)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<KeyValuePair<X, Y>>> CreateEnumerableAsync(ITransaction txn, EnumerationMode enumerationMode)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<KeyValuePair<X, Y>>> CreateEnumerableAsync(ITransaction txn, Func<X, bool> filter, EnumerationMode enumerationMode)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(ITransaction tx)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> GetOrAddAsync(ITransaction tx, X key, Func<X, Y> valueFactory)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> GetOrAddAsync(ITransaction tx, X key, Y value)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> GetOrAddAsync(ITransaction tx, X key, Func<X, Y> valueFactory, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<Y> GetOrAddAsync(ITransaction tx, X key, Y value, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task SetAsync(ITransaction tx, X key, Y value)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> TryAddAsync(ITransaction tx, X key, Y value)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> TryAddAsync(ITransaction tx, X key, Y value, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<Y>> TryGetValueAsync(ITransaction tx, X key)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<Y>> TryGetValueAsync(ITransaction tx, X key, LockMode lockMode)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<Y>> TryGetValueAsync(ITransaction tx, X key, LockMode lockMode, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<Y>> TryRemoveAsync(ITransaction tx, X key)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<Y>> TryRemoveAsync(ITransaction tx, X key, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> TryUpdateAsync(ITransaction tx, X key, Y newValue, Y comparisonValue)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<bool> TryUpdateAsync(ITransaction tx, X key, Y newValue, Y comparisonValue, TimeSpan timeout, CancellationToken cancellationToken)
        {
            // Unused
            throw new NotImplementedException();
        }
        #endregion
    }
}
