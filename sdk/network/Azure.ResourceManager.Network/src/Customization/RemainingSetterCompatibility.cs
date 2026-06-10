// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("Geo")]
    public partial class CustomIPPrefixData
    {
        public CidrAdvertisingGeoCode? Geo
        {
            get => Properties?.Geo is null ? default : new CidrAdvertisingGeoCode(Properties.Geo.Value.ToString());
            set
            {
                if (Properties is null)
                {
                    Properties = new CustomIpPrefixPropertiesFormat();
                }

                Properties.Geo = value.HasValue ? new Geo(value.Value.ToString()) : default(Geo?);
            }
        }
    }

    [CodeGenSuppress("Format")]
    public partial class FlowLogData
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
                    Properties = new FlowLogPropertiesFormat();
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

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Location")]
    [CodeGenSuppress("Tags")]
    public partial class ConnectionMonitorContent
    {
    }

    public partial class ConnectionMonitorCreateOrUpdateContent
    {
        public AzureLocation? Location { get; set; }

        public IDictionary<string, string> Tags { get; } = new ChangeTrackingDictionary<string, string>();
    }

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

    public partial class FlowLogProperties
    {
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

    public partial class PacketCaptureCreateOrUpdateContent
    {
        public bool? IsContinuousCapture
        {
            get => ContinuousCapture;
            set => ContinuousCapture = value;
        }
    }
}
