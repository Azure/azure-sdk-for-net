// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    // TODO (kasobol-msft) unused ?
#pragma warning disable CS0618 // Type or member is obsolete
    internal sealed class BlobWatchableValueProvider : IValueProvider, IWatchable
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private readonly BlobBaseClient _blob;
        private readonly object _value;
        private readonly Type _valueType;
#pragma warning disable CS0618 // Type or member is obsolete
        private readonly IWatcher _watcher;
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
        public BlobWatchableValueProvider(BlobBaseClient blob, object value, Type valueType, IWatcher watcher)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            if (value != null && !valueType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _blob = blob;
            _value = value;
            _valueType = valueType;
            _watcher = watcher;
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

#pragma warning disable CS0618 // Type or member is obsolete
        public static BlobWatchableValueProvider Create<T>(BlobBaseClient blob, T value, IWatcher watcher)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            return new BlobWatchableValueProvider(blob, value: value, valueType: typeof(T), watcher: watcher);
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        public string ToInvokeString()
        {
            return _blob.GetBlobPath();
        }
    }
}
