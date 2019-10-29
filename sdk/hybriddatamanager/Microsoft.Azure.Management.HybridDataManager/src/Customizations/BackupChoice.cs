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
    /// Defines values for BackUpChoice.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BackupChoice
    {
        /// <summary>
        /// Use the latest existing backup 
        /// </summary>
        [EnumMember(Value = "UseExistingLatest")]
        UseExistingLatest,

        /// <summary>
        /// Take a backup now.
        /// </summary>
        [EnumMember(Value = "TakeNow")]
        TakeNow
    }

    internal static class BackupChoiceEnumExtension
    {
        internal static string ToSerializedValue(this BackupChoice? value)
        {
            return value == null ? null : ((BackupChoice)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this BackupChoice value)
        {
            switch (value)
            {
                case BackupChoice.UseExistingLatest:
                    return "UseExistingLatest";
                case BackupChoice.TakeNow:
                    return "TakeNow";
            }
            return null;
        }

        internal static BackupChoice? ParseBackupChoice(this string value)
        {
            switch (value)
            {
                case "UseExistingLatest":
                    return BackupChoice.UseExistingLatest;
                case "TakeNow":
                    return BackupChoice.TakeNow;
            }
            return null;
        }
    }
}
