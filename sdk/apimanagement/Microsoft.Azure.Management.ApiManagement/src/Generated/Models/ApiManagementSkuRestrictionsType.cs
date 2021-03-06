// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApiManagementSkuRestrictionsType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApiManagementSkuRestrictionsType
    {
        [EnumMember(Value = "Location")]
        Location,
        [EnumMember(Value = "Zone")]
        Zone
    }
    internal static class ApiManagementSkuRestrictionsTypeEnumExtension
    {
        internal static string ToSerializedValue(this ApiManagementSkuRestrictionsType? value)
        {
            return value == null ? null : ((ApiManagementSkuRestrictionsType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this ApiManagementSkuRestrictionsType value)
        {
            switch( value )
            {
                case ApiManagementSkuRestrictionsType.Location:
                    return "Location";
                case ApiManagementSkuRestrictionsType.Zone:
                    return "Zone";
            }
            return null;
        }

        internal static ApiManagementSkuRestrictionsType? ParseApiManagementSkuRestrictionsType(this string value)
        {
            switch( value )
            {
                case "Location":
                    return ApiManagementSkuRestrictionsType.Location;
                case "Zone":
                    return ApiManagementSkuRestrictionsType.Zone;
            }
            return null;
        }
    }
}
