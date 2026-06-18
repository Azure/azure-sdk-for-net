// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
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
