// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.HDInsight.Models
{
    /// <summary> The create cluster extension request parameters. </summary>
    public partial class HDInsightClusterCreateExtensionContent
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="HDInsightClusterCreateExtensionContent"/>. </summary>
        public HDInsightClusterCreateExtensionContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HDInsightClusterCreateExtensionContent"/>. </summary>
        /// <param name="workspaceId"> The workspace ID for the cluster extension. </param>
        /// <param name="primaryKey"> The certificate for the cluster extension. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal HDInsightClusterCreateExtensionContent(string workspaceId, string primaryKey, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            WorkspaceId = workspaceId;
            PrimaryKey = primaryKey;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The workspace ID for the cluster extension. </summary>
        public string WorkspaceId { get; set; }

        /// <summary> The certificate for the cluster extension. </summary>
        public string PrimaryKey { get; set; }
    }
}
