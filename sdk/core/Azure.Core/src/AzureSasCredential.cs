// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Shared access signature credential used to authenticate to an Azure Service.
    /// It provides the ability to update the shared access signature without creating a new client.
    /// </summary>
    public class AzureSasCredential
    {
        private string _signature;

        /// <summary>
        /// Shared access signature used to authenticate to an Azure service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Signature
        {
            get => Volatile.Read(ref _signature);
            private set => Volatile.Write(ref _signature, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSasCredential"/> class.
        /// </summary>
        /// <param name="signature">Shared access signature to use to authenticate with the Azure service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="signature"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="signature"/> is empty.
        /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public AzureSasCredential(string signature) => Update(signature);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Updates the shared access signature.
        /// This is intended to be used when you've regenerated your shared access signature
        /// and want to update long lived clients.
        /// </summary>
        /// <param name="signature">Shared access signature to authenticate the service against.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="signature"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="signature"/> is empty.
        /// </exception>
        public void Update(string signature)
        {
            Argument.AssertNotNullOrWhiteSpace(signature, nameof(signature));
            Signature = signature;
        }
    }
}
