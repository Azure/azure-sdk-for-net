// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Time Configuration
    /// </summary>
    public class TimeConfiguration
    {
        /// <summary>
        /// Primary Time Server
        /// </summary>
        public string PrimaryTimeServer { get; set; }

        /// <summary>
        /// Secondary Time Server
        /// </summary>
        public string SecondaryTimeServer { get; set; }

        /// <summary>
        /// Time Zone
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(PrimaryTimeServer)}={PrimaryTimeServer}, {nameof(SecondaryTimeServer)}={SecondaryTimeServer}, {nameof(TimeZone)}={TimeZone}}}";
        }
    }
}
