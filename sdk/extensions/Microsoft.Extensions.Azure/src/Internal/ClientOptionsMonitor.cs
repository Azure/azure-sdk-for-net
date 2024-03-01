// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Extensions.Azure
{
    // Slightly adjusted copy of https://github.com/aspnet/Extensions/blob/master/src/Options/Options/src/OptionsMonitor.cs
    internal class ClientOptionsMonitor<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>
        : IOptionsMonitor<TOptions>, IDisposable where TOptions : class
    {
        private readonly IOptionsMonitorCache<TOptions> _cache;
        private readonly ClientOptionsFactory<TClient, TOptions> _factory;
        private readonly IEnumerable<IOptionsChangeTokenSource<TOptions>> _sources;
        private readonly List<IDisposable> _registrations = new List<IDisposable>();
        private event Action<TOptions, string> _onChange;

        public ClientOptionsMonitor(ClientOptionsFactory<TClient, TOptions> factory, IEnumerable<IOptionsChangeTokenSource<TOptions>> sources, IOptionsMonitorCache<TOptions> cache)
        {
            _factory = factory;
            _sources = sources;
            _cache = cache;

            foreach (var source in _sources)
            {
                var registration = ChangeToken.OnChange(
                    () => source.GetChangeToken(),
                    (name) => InvokeChanged(name),
                    source.Name);

                _registrations.Add(registration);
            }
        }

        private void InvokeChanged(string name)
        {
            name = name ?? Microsoft.Extensions.Options.Options.DefaultName;
            _cache.TryRemove(name);
            var options = Get(name);

            _onChange?.Invoke(options, name);
        }

        /// <summary>
        /// The present value of the options.
        /// </summary>
        public TOptions CurrentValue
        {
            get => Get(Microsoft.Extensions.Options.Options.DefaultName);
        }

        /// <summary>
        /// Returns a configured <typeparamref name="TOptions"/> instance with the given <paramref name="name"/>.
        /// </summary>
        public virtual TOptions Get(string name)
        {
            name = name ?? Microsoft.Extensions.Options.Options.DefaultName;
            return _cache.GetOrAdd(name, () => _factory.Create(name));
        }

        /// <summary>
        /// Registers a listener to be called whenever <typeparamref name="TOptions"/> changes.
        /// </summary>
        /// <param name="listener">The action to be invoked when <typeparamref name="TOptions"/> has changed.</param>
        /// <returns>An <see cref="IDisposable"/> which should be disposed to stop listening for changes.</returns>
        public IDisposable OnChange(Action<TOptions, string> listener)
        {
            var disposable = new ChangeTrackerDisposable(this, listener);
            _onChange += disposable.OnChange;
            return disposable;
        }

        /// <summary>
        /// Removes all change registration subscriptions.
        /// </summary>
        public void Dispose()
        {
            // Remove all subscriptions to the change tokens
            foreach (var registration in _registrations)
            {
                registration.Dispose();
            }

            _registrations.Clear();
        }

        internal class ChangeTrackerDisposable : IDisposable
        {
            private readonly Action<TOptions, string> _listener;
            private readonly ClientOptionsMonitor<TClient, TOptions> _monitor;

            public ChangeTrackerDisposable(ClientOptionsMonitor<TClient, TOptions> monitor, Action<TOptions, string> listener)
            {
                _listener = listener;
                _monitor = monitor;
            }

            public void OnChange(TOptions options, string name) => _listener.Invoke(options, name);

            public void Dispose() => _monitor._onChange -= OnChange;
        }
    }
}