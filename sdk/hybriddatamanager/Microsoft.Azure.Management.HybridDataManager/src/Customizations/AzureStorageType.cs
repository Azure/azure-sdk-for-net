namespace Microsoft.Azure.Management.HybridData
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines values for AzureStorageType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AzureStorageType
    {
        /// <summary>
        /// Azure blob storage.
        /// </summary>
        [EnumMember(Value = "Blob")]
        Blob,

        /// <summary>
        /// Azure file share storage.
        /// </summary>
        [EnumMember(Value = "FileShare")]
        FileShare
    }

    internal static class AzureStorageTypeEnumExtension
    {
        internal static string ToSerializedValue(this AzureStorageType? value)
        {
            return value == null ? null : ((AzureStorageType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this AzureStorageType value)
        {
            switch (value)
            {
                case AzureStorageType.Blob:
                    return "Blob";
                case AzureStorageType.FileShare:
                    return "FileShare";
            }
            return null;
        }

        internal static AzureStorageType? ParseAzureStorageType(this string value)
        {
            switch (value)
            {
                case "Blob":
                    return AzureStorageType.Blob;
                case "FileShare":
                    return AzureStorageType.FileShare;
            }
            return null;
        }
    }
}
