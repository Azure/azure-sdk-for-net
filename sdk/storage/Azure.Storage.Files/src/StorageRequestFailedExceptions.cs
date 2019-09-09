// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Azure.Storage.Files.Models
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
            foreach (var element in root.Elements())
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
        /// <param name="response">The failed response.</param>
        /// <returns>A StorageRequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => new StorageRequestFailedException(response, this.Message, null, this.Code, this.AdditionalInformation);
    }

    /// <summary>
    /// Convert FailureNoContent into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class FailureNoContent
    {
        /// <summary>
        /// Create an exception corresponding to the FailureNoContent.
        /// </summary>
        /// <param name="response">The failed response.</param>
        /// <returns>A StorageRequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => new StorageRequestFailedException(response, null, null, this.ErrorCode);
    }
}
