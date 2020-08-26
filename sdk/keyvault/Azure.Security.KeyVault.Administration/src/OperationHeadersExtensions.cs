// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Administration
{
    internal static class OperationHeadersExtensions
    {
        /// <summary>
        /// Extracts the operation JobId from the <see cref="ServiceFullBackupHeaders" /> AzureAsyncOperation.
        /// </summary>
        /// <returns>The operation JobId.</returns>
        public static string JobId(this ServiceFullBackupHeaders header)
        {
            return GetJobIdFromAzureAsyncOperation(header.AzureAsyncOperation);
        }

        /// <summary>
        /// Extracts the operation JobId from the <see cref="ServiceFullRestoreOperationHeaders" /> AzureAsyncOperation.
        /// </summary>
        /// <returns>The operation JobId.</returns>
        public static string JobId(this ServiceFullRestoreOperationHeaders header)
        {
            return GetJobIdFromAzureAsyncOperation(header.AzureAsyncOperation);
        }

        /// <summary>
        /// Extracts the operation JobId from the <see cref="ServiceSelectiveKeyRestoreOperationHeaders" /> AzureAsyncOperation.
        /// </summary>
        /// <returns>The operation JobId.</returns>
        public static string JobId(this ServiceSelectiveKeyRestoreOperationHeaders header)
        {
            return GetJobIdFromAzureAsyncOperation(header.AzureAsyncOperation);
        }

        /// <summary>
        /// Extracts the operation JobId from the AzureAsyncOperation.
        /// </summary>
        /// <param name="azureAsyncOperation">The AzureAsyncOperation string, which is a URI.</param>
        /// <returns>The operation JobId.</returns>
        private static string GetJobIdFromAzureAsyncOperation(string azureAsyncOperation)
        {
            var uri = new Uri(azureAsyncOperation);

            // return segment 2 (<jobId>) from the azureAsyncOperation which takes the form:
            // "https://myvault.vault.azure.net/<operationName>/<jobId>/pending"

            return uri.Segments[2].TrimEnd('/');
        }
    }
}
