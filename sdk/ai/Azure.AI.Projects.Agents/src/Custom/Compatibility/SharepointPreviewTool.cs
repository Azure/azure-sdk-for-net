// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenAI;

namespace Azure.AI.Projects.Agents
{
    /// <summary> The input definition information for a sharepoint tool as used to configure an agent. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SharepointPreviewTool : ProjectsAgentTool
    {
        /// <summary> Initializes a new instance of <see cref="SharepointPreviewTool"/>. </summary>
        /// <param name="toolOptions"> The sharepoint grounding tool parameters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toolOptions"/> is null. </exception>
        public SharepointPreviewTool(SharePointGroundingToolOptions toolOptions) : base(ToolType.SharepointGroundingPreview)
        {
            Argument.AssertNotNull(toolOptions, nameof(toolOptions));

            ToolOptions = toolOptions;
        }

        /// <summary> Initializes a new instance of <see cref="SharepointPreviewTool"/>. </summary>
        /// <param name="type"></param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="toolOptions"> The sharepoint grounding tool parameters. </param>
        internal SharepointPreviewTool(ToolType @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, SharePointGroundingToolOptions toolOptions) : base(@type, additionalBinaryDataProperties)
        {
            ToolOptions = toolOptions;
        }

        /// <summary> The sharepoint grounding tool parameters. </summary>
        public SharePointGroundingToolOptions ToolOptions { get; set; }
    }
}
