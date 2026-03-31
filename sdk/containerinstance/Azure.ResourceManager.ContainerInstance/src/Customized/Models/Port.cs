// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Corrected copy of Generated/Models/Port.cs
// Renamed Port property to PortNumber to avoid CS0542.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> The port exposed on the container group. </summary>
    public partial class Port
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="Models.Port"/>. </summary>
        /// <param name="port"> The port number. </param>
        public Port(int port)
        {
            PortNumber = port;
        }

        /// <summary> Initializes a new instance of <see cref="Models.Port"/>. </summary>
        /// <param name="protocol"> The protocol associated with the port. </param>
        /// <param name="port"> The port number. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal Port(ContainerGroupNetworkProtocol? protocol, int port, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Protocol = protocol;
            PortNumber = port;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The protocol associated with the port. </summary>
        public ContainerGroupNetworkProtocol? Protocol { get; set; }

        /// <summary> The port number. </summary>
        public int PortNumber { get; set; }
    }
}
