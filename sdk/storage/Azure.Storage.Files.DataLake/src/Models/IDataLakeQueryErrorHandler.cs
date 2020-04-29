// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Interface for user-implemented handlers for <see cref="DataLakeQueryError"/>.
    /// </summary>
    public interface IDataLakeQueryErrorHandler
    {
        /// <summary>
        /// Method to be called when a <see cref="DataLakeQueryError"/> occurs.
        /// </summary>
        /// <param name="dataLakeQueryError">
        /// <see cref="DataLakeQueryError"/> to handle.
        /// </param>
        public void ReportError(DataLakeQueryError dataLakeQueryError);
    }
}
