// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public enum Region
    {
        // Azure Cloud - Americas
        [EnumName("westus")]
        US_WEST,
        [EnumName("westus2")]
        US_WEST2,
        [EnumName("centralus")]
        US_CENTRAL,
        [EnumName("eastus")]
        US_EAST,
        [EnumName("eastus2")]
        US_EAST2,
        [EnumName("northcentralus")]
        US_NORTH_CENTRAL,
        [EnumName("southcentralus")]
        US_SOUTH_CENTRAL,
        [EnumName("westcentralus")]
        US_WEST_CENTRAL,
        [EnumName("canadacentral")]
        CANADA_CENTRAL,
        [EnumName("canadaeast")]
        CANADA_EAST,
        [EnumName("brazilsouth")]
        BRAZIL_SOUTH,
        // Azure Cloud - Europe
        [EnumName("northeurope")]
        EUROPE_NORTH,
        [EnumName("westeurope")]
        EUROPE_WEST,
        [EnumName("uksouth")]
        UK_SOUTH,
        [EnumName("ukwest")]
        UK_WEST,
        // Azure Cloud - Asia
        [EnumName("eastasia")]
        ASIA_EAST,
        [EnumName("southeastasia")]
        ASIA_SOUTHEAST,
        [EnumName("japaneast")]
        JAPAN_EAST,
        [EnumName("japanwest")]
        JAPAN_WEST,
        [EnumName("australiaeast")]
        AUSTRALIA_EAST,
        [EnumName("australiasoutheast")]
        AUSTRALIA_SOUTHEAST,
        [EnumName("centralindia")]
        INDIA_CENTRAL,
        [EnumName("southindia")]
        INDIA_SOUTH,
        [EnumName("westindia")]
        INDIA_WEST,
        // Azure China Cloud
        [EnumName("chinanorth")]
        CHINA_NORTH,
        [EnumName("chinaeast")]
        CHINA_EAST,
        // Azure German Cloud
        [EnumName("germanycentral")]
        GERMANY_CENTRAL,
        [EnumName("germanynortheast")]
        GERMANY_NORTHEAST,
        // Azure Government Cloud
        [EnumName("usgoveast")]
        GOV_US_VIRGINIA,
        [EnumName("usgovcentral")]
        GOV_US_IOWA
    }
}