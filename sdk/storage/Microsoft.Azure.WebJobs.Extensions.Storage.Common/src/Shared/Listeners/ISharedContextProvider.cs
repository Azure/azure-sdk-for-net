// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    /// <summary>
    /// Interface for providing host level state persistence.
    /// A new instance of the provider is created when a host
    /// is constructed.
    /// </summary>
    internal interface ISharedContextProvider
    {
        bool TryGetValue(string key, out object value);

        void SetValue(string key, object value);

        TValue GetOrCreateInstance<TValue>(IFactory<TValue> factory);
    }
}
