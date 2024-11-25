// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Key credential used to authenticate to an Azure Service.
    /// It provides the ability to update the key without creating a new client.
    /// </summary>
    public class AzureKeyCredential : ApiKeyCredential
    {
        /// <summary>
        /// Key used to authenticate to an Azure service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key
        {
            get
            {
                Deconstruct(out string key);
                return key;
            }

            private set => Update(value);
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
        public AzureKeyCredential(string key) : base(key)
        {
        }
    }
}
