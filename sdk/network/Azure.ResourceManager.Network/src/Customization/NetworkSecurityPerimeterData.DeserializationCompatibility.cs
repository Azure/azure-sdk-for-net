// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Temporary NSP deserialization workaround declarations are grouped for cleanup.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterData DeserializeNetworkSecurityPerimeterData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NetworkSecurityPerimeterProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NetworkSecurityPerimeterProperties.DeserializeNetworkSecurityPerimeterProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterProfileData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterProfileData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterProfileData DeserializeNetworkSecurityPerimeterProfileData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspProfileProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspProfileProperties.DeserializeNspProfileProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterProfileData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterAccessRuleData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterAccessRuleData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterAccessRuleData DeserializeNetworkSecurityPerimeterAccessRuleData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspAccessRuleProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspAccessRuleProperties.DeserializeNspAccessRuleProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterAccessRuleData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterAssociationData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterAssociationData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterAssociationData DeserializeNetworkSecurityPerimeterAssociationData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspAssociationProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspAssociationProperties.DeserializeNspAssociationProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterAssociationData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterLinkData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterLinkData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterLinkData DeserializeNetworkSecurityPerimeterLinkData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspLinkProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspLinkProperties.DeserializeNspLinkProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterLinkData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterLinkReferenceData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterLinkReferenceData DeserializeNetworkSecurityPerimeterLinkReferenceData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspLinkReferenceProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspLinkReferenceProperties.DeserializeNspLinkReferenceProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterLinkReferenceData(properties, name, additionalBinaryDataProperties);
        }
    }

    [CodeGenSuppress("DeserializeNetworkSecurityPerimeterLoggingConfigurationData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class NetworkSecurityPerimeterLoggingConfigurationData
    {
        // TODO: Remove when the generator custom-base serialization fix is available in this branch.
        internal static NetworkSecurityPerimeterLoggingConfigurationData DeserializeNetworkSecurityPerimeterLoggingConfigurationData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NspLoggingConfigurationProperties properties = default;
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = NspLoggingConfigurationProperties.DeserializeNspLoggingConfigurationProperties(prop.Value, options);
                    }
                    return true;
                }
                return false;
            });
            return new NetworkSecurityPerimeterLoggingConfigurationData(properties, name, additionalBinaryDataProperties);
        }
    }
}
