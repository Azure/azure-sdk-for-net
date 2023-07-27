// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.WebPubSub.Models
{
    /// <summary> Live trace configuration of a Microsoft.SignalRService resource. </summary>
    public partial class LiveTraceConfiguration
    {
        /// <summary> Initializes a new instance of LiveTraceConfiguration. </summary>
        public LiveTraceConfiguration()
        {
            Categories = new ChangeTrackingList<LiveTraceCategory>();
        }

        /// <summary> Initializes a new instance of LiveTraceConfiguration. </summary>
        /// <param name="enabled">
        /// Indicates whether or not enable live trace.
        /// When it&apos;s set to true, live trace client can connect to the service.
        /// Otherwise, live trace client can&apos;t connect to the service, so that you are unable to receive any log, no matter what you configure in &quot;categories&quot;.
        /// Available values: true, false.
        /// Case insensitive.
        /// </param>
        /// <param name="categories"> Gets or sets the list of category configurations. </param>
        internal LiveTraceConfiguration(string enabled, IList<LiveTraceCategory> categories)
        {
            Enabled = enabled;
            Categories = categories;
        }

        /// <summary>
        /// Indicates whether or not enable live trace.
        /// When it&apos;s set to true, live trace client can connect to the service.
        /// Otherwise, live trace client can&apos;t connect to the service, so that you are unable to receive any log, no matter what you configure in &quot;categories&quot;.
        /// Available values: true, false.
        /// Case insensitive.
        /// </summary>
        private string Enabled { get; set; }

        /// <summary>
        /// Indicates whether or not enable live trace.
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
        /// <summary> Gets or sets the list of category configurations. </summary>
        public IList<LiveTraceCategory> Categories { get; }
    }
}
