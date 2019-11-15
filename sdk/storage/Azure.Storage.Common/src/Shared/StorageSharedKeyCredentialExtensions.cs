// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
internal class StorageSharedKeyCredentialExtensions : StorageSharedKeyCredential
    {
        public StorageSharedKeyCredentialExtensions(string accountName, string accountKey) :
            base(accountName, accountKey)
        {
        }

        internal static new string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            StorageSharedKeyCredential.ComputeSasSignature(credential, message);


        internal static new string ExportBase64EncodedKey(StorageSharedKeyCredential credential) =>
            StorageSharedKeyCredential.ExportBase64EncodedKey(credential);
    }
}
