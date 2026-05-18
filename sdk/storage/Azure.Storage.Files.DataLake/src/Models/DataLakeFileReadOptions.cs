// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for downloading a range of a file with
    /// <see cref="DataLakeFileClient.Read(DataLakeFileReadOptions, CancellationToken)"/>.
    /// </summary>
    public class DataLakeFileReadOptions
    {
        /// <summary>
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire file.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// downloading this file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="DataLakeClientOptions.TransferValidation"/> settings.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Optional. The layout endpoint for this download, optimized for locality.
        /// When set, rewrites the outgoing request URI's host/port to
        /// the specified endpoint while preserving the original Host header.
        /// <para>
        /// Enumerate the pages returned by
        /// <see cref="DataLakeFileClient.GetLayout(HttpRange, DataLakeRequestConditions, CancellationToken)"/>
        /// and select the endpoint whose layout range covers the offset of the
        /// requested <see cref="Range"/>; pass that value here.
        /// </para>
        /// <para>
        /// When null (the default), the request is sent to the client's
        /// configured endpoint with no rewriting.
        /// </para>
        /// </summary>
        public string LayoutEndpoint { get; set; }
    }
}
