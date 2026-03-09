// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("LogFileType")]
    [CodeGenSuppress("Uri")]
    public partial class PostgreSqlFlexibleServerLogFile
    {
        /// <summary> Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'. </summary>
        [WirePath("properties.type")]
        public string LogFileType
        {
            get => Properties is null ? default : Properties.LogFileType;
            set
            {
                if (Properties is null)
                    Properties = new CapturedLogProperties();
                Properties.LogFileType = value;
            }
        }

        /// <summary> URL to download the log file from. </summary>
        [WirePath("properties.url")]
        public string UriString
        {
            get => Properties is null ? default : Properties.Uri;
            set
            {
                if (Properties is null)
                    Properties = new CapturedLogProperties();
                Properties.Uri = value;
            }
        }

        /// <summary> Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'. </summary>
        [WirePath("properties.type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TypePropertiesType
        {
            get => LogFileType;
            set => LogFileType = value;
        }

        /// <summary> URL to download the log file from. </summary>
        [WirePath("properties.url")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Uri
        {
            get => UriString is null ? null : new Uri(UriString);
            set => UriString = value?.AbsoluteUri;
        }
    }
}
