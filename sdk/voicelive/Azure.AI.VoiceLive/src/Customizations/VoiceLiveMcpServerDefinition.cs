// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.VoiceLive
{
    public partial class VoiceLiveMcpServerDefinition
    {
        [CodeGenMember("RequireApproval")]
        private BinaryData _requireApproval;

        /// <summary>
        /// Gets or sets the approval requirements for MCP tool execution.
        /// </summary>
        public RequireApprovalOption RequireApproval
        {
            get => RequireApprovalOption.FromBinaryData(_requireApproval);
            set
            {
                if (value is null)
                {
                    _requireApproval = null;
                }
                else
                {
                    var persist = value as IPersistableModel<RequireApprovalOption>;
                    _requireApproval = persist.Write(new ModelReaderWriterOptions("J"));
                }
            }
        }
    }
}
