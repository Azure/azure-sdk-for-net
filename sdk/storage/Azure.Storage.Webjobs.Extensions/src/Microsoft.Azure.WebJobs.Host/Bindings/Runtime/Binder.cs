// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Runtime;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Class providing functionality for dynamically binding to WebJobs SDK attributes at runtime.
    /// </summary>
    public class Binder : IBinder, IWatchable, IDisposable
    {
        private readonly IAttributeBindingSource _bindingSource;
        private readonly IList<IValueBinder> _binders = new List<IValueBinder>();
        private readonly RuntimeBindingWatcher _watcher = new RuntimeBindingWatcher();
        private readonly CollectingDisposable _disposable = new CollectingDisposable();
        private readonly Dictionary<string, object> _bindingData;
        private bool _disposed;

        /// <summary>
        /// For testing only.
        /// </summary>
        public Binder()
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="bindingSource">The binding source.</param>
        internal Binder(IAttributeBindingSource bindingSource)
        {
            _bindingSource = bindingSource;

            // take a snapshot of the binding data
            // any additional binding data added will be applied
            // on bind
            _bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (bindingSource.AmbientBindingContext.BindingData != null)
            {
                foreach (var pair in bindingSource.AmbientBindingContext.BindingData)
                {
                    _bindingData[pair.Key] = pair.Value;
                }
            }
        }

        /// <summary>
        /// Gets the binding data.
        /// </summary>
        public virtual Dictionary<string, object> BindingData
        {
            get
            {
                return _bindingData;
            }
        }

        IWatcher IWatchable.Watcher
        {
            get { return _watcher; }
        }

        /// <summary>
        /// Binds the specified attribute.
        /// </summary>
        /// <typeparam name="TValue">The type to bind to.</typeparam>
        /// <param name="attribute">The attribute to bind.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will provide the bound the value.</returns>
        public virtual async Task<TValue> BindAsync<TValue>(Attribute attribute, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await BindAsync<TValue>(new Attribute[] { attribute }, cancellationToken);
        }

        /// <summary>
        /// Binds the specified collection of attributes.
        /// </summary>
        /// <typeparam name="TValue">The type to bind to.</typeparam>
        /// <param name="attributes">The collection of attributes to bind. The first attribute in the
        /// collection should be the primary attribute.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        public virtual async Task<TValue> BindAsync<TValue>(Attribute[] attributes, CancellationToken cancellationToken = default(CancellationToken))
        {
            var attribute = attributes.First();
            var additionalAttributes = attributes.Skip(1).ToArray();

            IBinding binding = await _bindingSource.BindAsync<TValue>(attribute, additionalAttributes, cancellationToken);
            if (binding == null)
            {
                throw new InvalidOperationException("No binding found for attribute '" + attribute.GetType() + "'.");
            }

            // Create a clone of the binding context, so any binding data that was added
            // will be applied to the binding
            var ambientBindingContext = new AmbientBindingContext(_bindingSource.AmbientBindingContext.FunctionContext, _bindingData);
            var bindingContext = new BindingContext(ambientBindingContext, cancellationToken);

            IValueProvider provider = await binding.BindAsync(bindingContext);
            if (provider == null)
            {
                return default(TValue);
            }

            Debug.Assert(provider.Type == typeof(TValue));

            ParameterDescriptor parameterDesciptor = binding.ToParameterDescriptor();
            parameterDesciptor.Name = null; // Remove the dummy name "?" used for runtime binding.

            // Add even if watchable is null to show parameter descriptor in status.
            string value = provider.ToInvokeString();
            IWatchable watchable = provider as IWatchable;
            _watcher.Add(parameterDesciptor, value, watchable);

            IValueBinder binder = provider as IValueBinder;
            if (binder != null)
            {
                _binders.Add(binder);
            }

            IDisposable disposableProvider = provider as IDisposable;
            if (disposableProvider != null)
            {
                _disposable.Add(disposableProvider);
            }

            object result = await provider.GetValueAsync();
            return (TValue)result;
        }

        /// <summary>
        /// Called to complete the binding process.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        internal async Task Complete(CancellationToken cancellationToken)
        {
            foreach (IValueBinder binder in _binders)
            {
                // Binding can only be uses for non-Out parameters, and their binders ignore this argument.
                await binder.SetValueAsync(value: null, cancellationToken: cancellationToken);
            }
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_disposable != null)
                    {
                        _disposable.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
