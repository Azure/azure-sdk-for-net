// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ServiceEmergingIssueData
    {
        /// <summary> The list of emerging issues of banner type. </summary>
        [CodeGenMember("StatusBanners")]
        public IReadOnlyList<EmergingIssueBannerType> StatusBanners
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<EmergingIssueBannerType>)Properties.StatusBanners;
            }
        }

        /// <summary> The list of emerging issues of active event type. </summary>
        [CodeGenMember("StatusActiveEvents")]
        public IReadOnlyList<EmergingIssueActiveEventType> StatusActiveEvents
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<EmergingIssueActiveEventType>)Properties.StatusActiveEvents;
            }
        }
    }
}
