// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    /// Extension for <see cref="MediaGraphNodeInput"/>.
    /// </summary>
    public partial class MediaGraphNodeInput
    {
        /// <summary>
        /// Constructs a <see cref="MediaGraphNodeInput"/> which connects all streams from the node with the given name.
        /// </summary>
        /// <param name="nodeName">The node name.</param>
        /// <returns>A node input.</returns>
#pragma warning disable CA2225 // Operator overloads have named alternates. FromString omitted because it suggests that any node input can be constructed from just a string
        public static implicit operator MediaGraphNodeInput(string nodeName)
#pragma warning restore CA2225 // Operator overloads have named alternates
        {
            return FromNodeName(nodeName);
        }

        /// <summary>
        /// Constructs a <see cref="MediaGraphNodeInput"/> which connects all streams from the node with the given name.
        /// </summary>
        /// <param name="nodeName">The node name.</param>
        /// <returns>A node input.</returns>
        public static MediaGraphNodeInput FromNodeName(string nodeName)
        {
            return new MediaGraphNodeInput(nodeName);
        }
    }
}
