// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Format")]
    public partial class FlowLogInformation
    {
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
    }
}
