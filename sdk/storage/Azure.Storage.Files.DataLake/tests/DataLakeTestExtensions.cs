// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake.Tests
{
    public static partial class DataLakeTestExtensions
    {
        /// <summary>
        /// Convert a base <see cref="RequestConditions"/> to <see cref="DataLakeRequestConditions"/>.
        /// </summary>
        /// <param name="conditions">The <see cref="RequestConditions"/>.</param>
        /// <returns>The <see cref="DataLakeRequestConditions"/>.</returns>
        public static DataLakeRequestConditions ToDataLakeRequestConditions(this RequestConditions conditions) =>
            conditions == null ?
                null :
                new DataLakeRequestConditions
                {
                    IfMatch = conditions.IfMatch,
                    IfNoneMatch = conditions.IfNoneMatch,
                    IfModifiedSince = conditions.IfModifiedSince,
                    IfUnmodifiedSince = conditions.IfUnmodifiedSince
                };
    }
}
