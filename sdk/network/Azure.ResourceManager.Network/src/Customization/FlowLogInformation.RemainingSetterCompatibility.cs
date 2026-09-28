// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the FlowLogInformation type. </summary>
    [CodeGenSuppress("Format")]
    public partial class FlowLogInformation
    {
        /// <summary> Gets or sets the Format compatibility property. </summary>
        public FlowLogProperties Format
        {
            get
            {
                var format = Properties?.Format;
                return format is null ? default : new FlowLogProperties
                {
                    FormatType = format.Type,
                    Version = format.Version
                };
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new FlowLogProperties();
                }

                Properties.Format = value is null ? default : new FlowLogFormatParameters
                {
                    Type = value.FormatType,
                    Version = value.Version
                };
            }
        }

        // TODO: Remove these properties when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> Gets or sets the flow log format type. </summary>
        public FlowLogFormatType? FormatType
        {
            get => Properties?.FormatType;
            set
            {
                Properties ??= new FlowLogProperties();
                Properties.FormatType = value;
            }
        }

        /// <summary> Gets or sets the flow log format version. </summary>
        public int? Version
        {
            get => Properties?.Version;
            set
            {
                Properties ??= new FlowLogProperties();
                Properties.Version = value;
            }
        }
    }
}
