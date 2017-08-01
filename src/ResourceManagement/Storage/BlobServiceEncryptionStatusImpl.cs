// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation of StorageAccountEncryptionStatus for Blob service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uQmxvYlNlcnZpY2VFbmNyeXB0aW9uU3RhdHVzSW1wbA==
    internal partial class BlobServiceEncryptionStatusImpl : IStorageAccountEncryptionStatus
    {
        private readonly EncryptionServices encryptionServices;

        ///GENMHASH:DAB5602D433411FC81DD4AE9FB169399:1AACE820D8910F7BD0F84AAA4D78CCA7
        internal  BlobServiceEncryptionStatusImpl(EncryptionServices encryptionServices)
        {
            this.encryptionServices = encryptionServices;
        }

        ///GENMHASH:37A0EE464EE2C3F32288E8C35E06F1EA:A33D634F8782BF7783613105DEEC75A4
        public StorageService StorageService()
        {
            return Microsoft.Azure.Management.Storage.Fluent.StorageService.Blob;
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:CC6968668CFE462E08B722E80135BB36
        public bool IsEnabled()
        {
            if (this.encryptionServices.Blob != null && this.encryptionServices.Blob.Enabled.HasValue)
            {
                return this.encryptionServices.Blob.Enabled.Value;
            }
            return false;
        }

        ///GENMHASH:383E4E95C2764D4EF94A2DE388852F09:CE1C414F974A62AA7E3EC6809EF477EC
        public DateTime? LastEnabledTime()
        {
            if (this.encryptionServices.Blob != null && this.encryptionServices.Blob.LastEnabledTime.HasValue)
            {
                return this.encryptionServices.Blob.LastEnabledTime.Value;
            }
            return null;
        }
    }
}