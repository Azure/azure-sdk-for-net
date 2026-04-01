// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Hci.Models
{
    public partial class ArcExtensionInstanceView
    {
        /// <summary> Specifies the type of the extension; an example is "MicrosoftMonitoringAgent". </summary>
        [WirePath("type")]
        public string ExtensionInstanceViewType => Type;
    }
}
