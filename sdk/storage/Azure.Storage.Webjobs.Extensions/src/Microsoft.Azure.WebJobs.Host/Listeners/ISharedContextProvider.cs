// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Listeners
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
