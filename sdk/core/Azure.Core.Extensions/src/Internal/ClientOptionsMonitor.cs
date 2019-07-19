// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Azure.Core.Extensions
{
    internal class ClientOptionsFactory<TClient, TOptions> where TOptions : class
    {
        private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
        private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

        private readonly IEnumerable<ClientRegistration<TClient, TOptions>> _clientRegistrations;

        public ClientOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures, IEnumerable<ClientRegistration<TClient, TOptions>> clientRegistrations)
        {
            _setups = setups;
            _postConfigures = postConfigures;
            _clientRegistrations = clientRegistrations;
        }

        private TOptions CreateOptions(string name)
        {
            object version = null;

            foreach (var clientRegistration in _clientRegistrations)
            {
                if (clientRegistration.Name == name)
                {
                    version = clientRegistration.Version;
                }
            }

            ConstructorInfo parameterlessConstructor = null;
            ParameterInfo versionConstructor = null;

            foreach (var constructor in typeof(TOptions).GetConstructors())
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length == 0)
                {
                    parameterlessConstructor = constructor;
                }

                if (parameters.Length == 1)
                {
                    versionConstructor = parameters[0];
                }
            }

            if (version != null)
            {
                if (versionConstructor != null)
                {
                    return (TOptions)Activator.CreateInstance(typeof(TOptions), version);
                }

                throw new InvalidOperationException("Unable to find constructor that takes service version");
            }

            if (parameterlessConstructor != null)
            {
                return Activator.CreateInstance<TOptions>();
            }

            return (TOptions)Activator.CreateInstance(typeof(TOptions), versionConstructor.DefaultValue);
        }

        /// <summary>
        /// Returns a configured <typeparamref name="TOptions"/> instance with the given <paramref name="name"/>.
        /// </summary>
        public TOptions Create(string name)
        {
            var options = CreateOptions(name);
            foreach (var setup in _setups)
            {
                if (setup is IConfigureNamedOptions<TOptions> namedSetup)
                {
                    namedSetup.Configure(name, options);
                }
                else if (name == Options.DefaultName)
                {
                    setup.Configure(options);
                }
            }
            foreach (var post in _postConfigures)
            {
                post.PostConfigure(name, options);
            }

            return options;
        }
    }

    /// <summary>
    /// Implementation of <see cref="IOptionsMonitor{TOptions}"/>.
    /// </summary>
    /// <typeparam name="TOptions">Options type.</typeparam>
    /// <typeparam name="TClient"></typeparam>
    internal class ClientOptionsMonitor<TClient, TOptions> : IOptionsMonitor<TOptions>, IDisposable where TOptions : class
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
            name = name ?? Options.DefaultName;
            _cache.TryRemove(name);
            var options = Get(name);
            if (_onChange != null)
            {
                _onChange.Invoke(options, name);
            }
        }

        /// <summary>
        /// The present value of the options.
        /// </summary>
        public TOptions CurrentValue
        {
            get => Get(Options.DefaultName);
        }

        /// <summary>
        /// Returns a configured <typeparamref name="TOptions"/> instance with the given <paramref name="name"/>.
        /// </summary>
        public virtual TOptions Get(string name)
        {
            name = name ?? Options.DefaultName;
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