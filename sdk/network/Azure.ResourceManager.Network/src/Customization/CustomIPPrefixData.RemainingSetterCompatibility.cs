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

                Properties.Geo = value.HasValue ? new CidrAdvertisingGeoCode(value.Value.ToString()) : default(CidrAdvertisingGeoCode?);
            }
        }
    }
}
