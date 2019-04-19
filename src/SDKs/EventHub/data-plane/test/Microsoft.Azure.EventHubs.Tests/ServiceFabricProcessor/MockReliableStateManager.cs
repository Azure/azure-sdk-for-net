// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Data;
    using Microsoft.ServiceFabric.Data.Notifications;

    class MockReliableStateManager : IReliableStateManager
    {
        private Dictionary<string, IReliableState> dictionaryOfDictionaries = new Dictionary<string, IReliableState>();

        public ITransaction CreateTransaction()
        {
            return new MockTransaction();
        }

        public Task<T> GetOrAddAsync<T>(string name) where T : IReliableState
        {
            // Ignore T internally because we use only one type
            if (!this.dictionaryOfDictionaries.ContainsKey(name))
            {
                this.dictionaryOfDictionaries.Add(name, new MockReliableDictionary<string, Dictionary<string, object>>());
            }
            return Task.FromResult<T>((T)this.dictionaryOfDictionaries[name]);
        }

        public Task<ConditionalValue<T>> TryGetAsync<T>(string name) where T : IReliableState
        {
            if (this.dictionaryOfDictionaries.ContainsKey(name))
            {
                return Task.FromResult<ConditionalValue<T>>(new ConditionalValue<T>(true, (T)this.dictionaryOfDictionaries[name]));
            }
            IReliableState dummy = null; // compiler won't take null directly but will cast an IReliableState
            return Task.FromResult<ConditionalValue<T>>(new ConditionalValue<T>(false, (T)dummy));
        }

        #region unused
        // These events are part of the IReliableStateManager interface and must be present, but without the pragma
        // the compiler warns that they are never used, the warnings are treated as errors, and the build fails.
        // The pragma is less ugly than adding fake uses of these events.
#pragma warning disable 67
        public event EventHandler<NotifyTransactionChangedEventArgs> TransactionChanged;
        public event EventHandler<NotifyStateManagerChangedEventArgs> StateManagerChanged;
#pragma warning restore 67

        public IAsyncEnumerator<IReliableState> GetAsyncEnumerator()
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(ITransaction tx, Uri name, TimeSpan timeout) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(ITransaction tx, Uri name) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(Uri name, TimeSpan timeout) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(Uri name) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(ITransaction tx, string name, TimeSpan timeout) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(ITransaction tx, string name) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(string name, TimeSpan timeout) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ITransaction tx, Uri name, TimeSpan timeout)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ITransaction tx, Uri name)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Uri name, TimeSpan timeout)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Uri name)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ITransaction tx, string name, TimeSpan timeout)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ITransaction tx, string name)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string name, TimeSpan timeout)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string name)
        {
            // Unused
            throw new NotImplementedException();
        }

        public bool TryAddStateSerializer<T>(IStateSerializer<T> stateSerializer)
        {
            // Unused
            throw new NotImplementedException();
        }

        public Task<ConditionalValue<T>> TryGetAsync<T>(Uri name) where T : IReliableState
        {
            // Unused
            throw new NotImplementedException();
        }
        #endregion
    }
}
