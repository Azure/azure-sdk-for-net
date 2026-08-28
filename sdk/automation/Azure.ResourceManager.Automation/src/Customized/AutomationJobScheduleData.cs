// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // Generated job schedule parameters are nested under JobScheduleProperties as a mutable dictionary.
    // Keep the GA read-only Parameters property on AutomationJobScheduleData.
    public partial class AutomationJobScheduleData
    {
        /// <summary> Gets the parameters of the job schedule. </summary>
        public IReadOnlyDictionary<string, string> Parameters
        {
            get
            {
                return Properties?.Parameters is null ? default : new ReadOnlyDictionary<string, string>(Properties.Parameters);
            }
        }
    }
}
