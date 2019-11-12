// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if CommonSDK
namespace Azure.Storage.Shared.Common
#else
namespace Azure.Storage.Shared
#endif
{
internal class StorageSharedKeyCredentialExtensions : StorageSharedKeyCredential
    {
        public StorageSharedKeyCredentialExtensions(string accountName, string accountKey) :
            base(accountName, accountKey)
        {
        }

        internal static new string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            StorageSharedKeyCredential.ComputeSasSignature(credential, message);
    }
}
