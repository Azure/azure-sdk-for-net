// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Azure storage service types.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuU3RvcmFnZVNlcnZpY2U=
    public class StorageService  : ExpandableStringEnum<Microsoft.Azure.Management.Storage.Fluent.StorageService>
    {
        /// <summary>
        /// Static value Blob for StorageService.
        /// </summary>
        public static readonly StorageService Blob = Parse("Blob");

        /// <summary>
        /// Static value Table for StorageService.
        /// </summary>
        public static readonly StorageService Table = Parse("Table");

        /// <summary>
        /// Static value Queue for StorageService.
        /// </summary>
        public static readonly StorageService Queue = Parse("Queue");
    }
}