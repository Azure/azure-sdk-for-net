// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
#pragma warning disable CS0618 // Type or member is obsolete
    internal sealed class BlobWatchableDisposableValueProvider : IValueProvider, IWatchable, IDisposable
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private readonly BlobBaseClient _blob;
        private readonly object _value;
        private readonly Type _valueType;
#pragma warning disable CS0618 // Type or member is obsolete
        private readonly IWatcher _watcher;
#pragma warning restore CS0618 // Type or member is obsolete
        private readonly IDisposable _disposable;

        private bool _disposed;

#pragma warning disable CS0618 // Type or member is obsolete
        public BlobWatchableDisposableValueProvider(BlobBaseClient blob, object value, Type valueType, IWatcher watcher,
#pragma warning restore CS0618 // Type or member is obsolete
            IDisposable disposable)
        {
            if (value != null && !valueType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _blob = blob;
            _value = value;
            _valueType = valueType;
            _watcher = watcher;
            _disposable = disposable;
        }

        public Type Type
        {
            get { return _valueType; }
        }

#pragma warning disable CS0618 // Type or member is obsolete
        public IWatcher Watcher
#pragma warning restore CS0618 // Type or member is obsolete
        {
            get { return _watcher; }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        public string ToInvokeString()
        {
            return _blob.GetBlobPath();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposable.Dispose();
                _disposed = true;
            }
        }
    }
}
