// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.WebPubSub.Models
{
    /// <summary> Live trace category configuration of a Microsoft.SignalRService resource. </summary>
    public partial class LiveTraceCategory
    {
        /// <summary> Initializes a new instance of LiveTraceCategory. </summary>
        public LiveTraceCategory()
        {
        }

        /// <summary> Initializes a new instance of LiveTraceCategory. </summary>
        /// <param name="name">
        /// Gets or sets the live trace category&apos;s name.
        /// Available values: ConnectivityLogs, MessagingLogs.
        /// Case insensitive.
        /// </param>
        /// <param name="enabled">
        /// Indicates whether or the live trace category is enabled.
        /// Available values: true, false.
        /// Case insensitive.
        /// </param>
        internal LiveTraceCategory(string name, string enabled)
        {
            Name = name;
            Enabled = enabled;
        }

        /// <summary>
        /// Gets or sets the live trace category&apos;s name.
        /// Available values: ConnectivityLogs, MessagingLogs.
        /// Case insensitive.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Indicates whether or the live trace category is enabled.
        /// Available values: true, false.
        /// Case insensitive.
        /// </summary>
        private string Enabled { get; set; }
        /// <summary>
        /// Indicates whether or the live trace category is enabled.
        /// </summary>
        public bool? IsEnabled
        {
            get
            {
                return bool.Parse(Enabled);
            }
            set
            {
                Enabled = value.ToString().ToLower(new System.Globalization.CultureInfo("en-us"));
            }
        }
    }
}
