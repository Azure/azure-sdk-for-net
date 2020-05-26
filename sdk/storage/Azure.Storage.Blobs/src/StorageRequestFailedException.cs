// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core.Pipeline;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Convert StorageErrors into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class StorageError
    {
        /// <summary>
        /// Additional error information.
        /// </summary>
        public IDictionary<string, string> AdditionalInformation { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Get any additional XML elements for the error.
        /// </summary>
        /// <param name="root">The XML element</param>
        /// <param name="error">The StorageError</param>
        static partial void CustomizeFromXml(XElement root, StorageError error)
        {
            foreach (XElement element in root.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case Constants.Xml.Code:
                    case Constants.Xml.Message:
                        continue;
                    default:
                        error.AdditionalInformation[element.Name.LocalName] = element.Value;
                        break;
                }
            }
        }

        /// <summary>
        /// Create an exception corresponding to the StorageError.
        /// </summary>
        /// <param name="clientDiagnostics">The <see cref="ClientDiagnostics"/> instance to use.</param>
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(ClientDiagnostics clientDiagnostics, Azure.Response response)
            => clientDiagnostics.CreateRequestFailedExceptionWithContent(response, message: Message, content: null,  response.GetErrorCode(Code));
    }

    /// <summary>
    /// Convert ConditionNotMetErrors into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class ConditionNotMetError
    {
        /// <summary>
        /// Create an exception corresponding to the ConditionNotMetError.
        /// </summary>
        /// <param name="clientDiagnostics">The <see cref="ClientDiagnostics"/> instance to use.</param>
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(ClientDiagnostics clientDiagnostics, Azure.Response response)
            => clientDiagnostics.CreateRequestFailedExceptionWithContent(response, message: null, content: null, response.GetErrorCode(ErrorCode));
    }

    /// <summary>
    /// Convert DataLakeStorageError into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class DataLakeStorageError
    {
        /// <summary>
        /// Create an exception corresponding to the DataLakeStorageError.
        /// </summary>
        /// <param name="clientDiagnostics">The <see cref="ClientDiagnostics"/> instance to use.</param>
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(ClientDiagnostics clientDiagnostics, Azure.Response response)
            => clientDiagnostics.CreateRequestFailedExceptionWithContent(response, message: DataLakeStorageErrorDetails.Message, content: null, response.GetErrorCode(DataLakeStorageErrorDetails.Code));
    }
}
