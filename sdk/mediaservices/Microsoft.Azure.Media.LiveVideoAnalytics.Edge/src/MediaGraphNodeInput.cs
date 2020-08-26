// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Media.LiveVideoAnalytics.Edge.Models
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
            return new MediaGraphNodeInput()
            {
                NodeName = nodeName,
                OutputSelectors = new MediaGraphOutputSelector[0],
            };
        }
    }
}
