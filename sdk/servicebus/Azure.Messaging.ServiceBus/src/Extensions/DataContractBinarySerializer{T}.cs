// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Messaging.ServiceBus.InteropExtensions
{
    /// <summary>
    /// Returns a static <see cref="DataContractBinarySerializer"/> instance of type T
    /// </summary>
    internal static partial class DataContractBinarySerializer<T>
    {
        /// <summary>
        /// Initializes a DataContractBinarySerializer instance of type T
        /// </summary>
        public static readonly XmlObjectSerializer Instance = new DataContractBinarySerializer(typeof(T));
    }
}
