// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal static class TableExtensions
    {
        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code TableNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code
        /// TableNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundTableNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            RequestResult result = exception.RequestInformation;
            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;
            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "TableNotFound";
        }

        public static string GetDetailedErrorMessage(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            string message = exception.Message;
            if (exception.RequestInformation != null)
            {
                message += $" (HTTP status code {exception.RequestInformation.HttpStatusCode.ToString(CultureInfo.InvariantCulture)}: "
                           + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorCode}. "
                           + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorMessage})";
            }

            return message;
        }

        // $$$ Move to better place. From
        internal static void ValidateContractCompatibility<TPath>(this IBindablePath<TPath> path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            BindingTemplateExtensions.ValidateContractCompatibility(path.ParameterNames, bindingDataContract);
        }

        public static TableOperation CreateInsertOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.Insert(entity);
            return sdkOperation;
        }

        public static TableOperation CreateInsertOrReplaceOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.InsertOrReplace(entity);
            return sdkOperation;
        }

        public static TableOperation CreateReplaceOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.Replace(entity);
            return sdkOperation;
        }

        public static TableOperation CreateRetrieveOperation<TElement>(this CloudTable table, string partitionKey, string rowKey)
            where TElement : ITableEntity, new()
        {
            return Retrieve<TElement>(partitionKey, rowKey);
        }

        public static TableOperation Retrieve<TElement>(string partitionKey, string rowKey) where TElement : ITableEntity, new()
        {
            TableOperation sdkOperation = TableOperation.Retrieve<TElement>(partitionKey, rowKey);
            return sdkOperation;
        }
    }
}