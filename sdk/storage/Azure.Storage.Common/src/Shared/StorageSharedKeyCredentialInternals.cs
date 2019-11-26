// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// This class is added to access protected static methods off of the base class
    /// that should not be exposed directly to customers.
    /// </summary>
    internal class StorageSharedKeyCredentialInternals : StorageSharedKeyCredential
    {
        #pragma warning disable IDE0051 // Remove unused private members
        private StorageSharedKeyCredentialInternals(string accountName, string accountKey) :
        #pragma warning restore IDE0051 // Remove unused private members
            base(accountName, accountKey)
        {
        }

        internal static new string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            StorageSharedKeyCredential.ComputeSasSignature(credential, message);
    }
}
