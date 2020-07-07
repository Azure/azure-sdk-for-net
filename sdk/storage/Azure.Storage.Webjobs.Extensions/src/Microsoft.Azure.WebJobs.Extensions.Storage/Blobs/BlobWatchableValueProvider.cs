// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal sealed class BlobWatchableValueProvider : IValueProvider, IWatchable
    {
        private readonly ICloudBlob _blob;
        private readonly object _value;
        private readonly Type _valueType;
        private readonly IWatcher _watcher;

        public BlobWatchableValueProvider(ICloudBlob blob, object value, Type valueType, IWatcher watcher)
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

        public IWatcher Watcher
        {
            get { return _watcher; }
        }

        public static BlobWatchableValueProvider Create<T>(ICloudBlob blob, T value, IWatcher watcher)
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
