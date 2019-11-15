// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Azure.Storage.Files.Shares.Models
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
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => StorageExceptionExtensions.CreateException(response, Message, null, Code, AdditionalInformation);
    }
}
