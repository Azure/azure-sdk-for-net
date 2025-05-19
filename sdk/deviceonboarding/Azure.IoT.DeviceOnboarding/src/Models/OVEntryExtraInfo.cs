// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class for Ownership Voucher Entry Extra Information
    /// </summary>
    internal class OVEntryExtraInfo
    {
        /// <summary>
        /// Ownership Voucher Tool Version
        /// </summary>
        internal string OVExtensionToolVersion { get; set; }

        /// <summary>
        /// Ownership Voucher Tool Version
        /// </summary>
        internal string OVExtensionUTCTimestamp { get; set; }

        /// <summary>
        /// Construction OV Extra Bytes
        /// </summary>
        /// <returns></returns>
        internal static string[] GetOVEExtraInfo()
        {
            var ovExtra = new OVEntryExtraInfo();
            ovExtra.OVExtensionToolVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ovExtra.OVExtensionUTCTimestamp = DateTime.UtcNow.ToString();
            var ovExtraList = new List<string>()
            {
                ovExtra.OVExtensionToolVersion, ovExtra.OVExtensionUTCTimestamp
            };
            return ovExtraList.ToArray();
        }
    }
}
