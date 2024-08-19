// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Key credential used to authenticate to an Azure Service.
    /// It provides the ability to update the key without creating a new client.
    /// </summary>
    public class AzureKeyCredential
    {
        private string _key;

        /// <summary>
        /// Key used to authenticate to an Azure service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key
        {
            get => Volatile.Read(ref _key);
            private set => Volatile.Write(ref _key, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredential"/> class.
        /// </summary>
        /// <param name="key">Key to use to authenticate with the Azure service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="key"/> is empty.
        /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public AzureKeyCredential(string key) => Update(key);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Updates the service key.
        /// This is intended to be used when you've regenerated your service key
        /// and want to update long lived clients.
        /// </summary>
        /// <param name="key">Key to authenticate the service against.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="key"/> is empty.
        /// </exception>
        public void Update(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            Key = key;
        }
    }
}
