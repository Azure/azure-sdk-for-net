// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // EventTypeInfo is a two-level flatten (properties.partnerTopicInfo.eventTypeInfo) beyond what the
    // single-level @@flattenProperty decorator can express; the generated member is suppressed and reshaped.
    [CodeGenSuppress("EventTypeInfo")]
    public partial class PartnerNamespaceChannelPatch
    {
        /// <summary> Gets or sets the partner topic event type information. </summary>
        [WirePath("properties.partnerTopicInfo.eventTypeInfo")]
        public PartnerTopicEventTypeInfo EventTypeInfo
        {
            get => Properties is null ? default : Properties.EventTypeInfo;
            set
            {
                Properties ??= new ChannelUpdateParametersProperties();
                Properties.EventTypeInfo = value;
            }
        }

        internal PartnerUpdateTopicInfo PartnerTopicInfo
        {
            get => Properties is null ? default : Properties.PartnerTopicInfo;
            set
            {
                if (Properties is null)
                {
                    Properties = new ChannelUpdateParametersProperties();
                }
                Properties.PartnerTopicInfo = value;
            }
        }
    }
}
