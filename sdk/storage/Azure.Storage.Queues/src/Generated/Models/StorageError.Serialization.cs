// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    internal partial class StorageError
    {
        internal static StorageError DeserializeStorageError(XElement element)
        {
            string message = default;
            if (element.Element("Message") is XElement messageElement)
            {
                message = (string)messageElement;
            }
            return new StorageError(message);
        }
    }
}
