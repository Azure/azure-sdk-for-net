// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the FlowLogProperties type. </summary>
    public partial class FlowLogProperties
    {
        /// <summary> Gets or sets the FormatType compatibility property. </summary>
        public FlowLogFormatType? FormatType
        {
            get => Format?.Type;
            set
            {
                if (Format is null)
                {
                    Format = new FlowLogFormatParameters();
                }

                Format.Type = value;
            }
        }

        /// <summary> Gets or sets the Version compatibility property. </summary>
        public int? Version
        {
            get => Format?.Version;
            set
            {
                if (Format is null)
                {
                    Format = new FlowLogFormatParameters();
                }

                Format.Version = value;
            }
        }
    }
}
