// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace
{
    /// <summary> Single sign-on configurations for a given monitor resource. </summary>
    public partial class DynatraceSingleSignOnData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="DynatraceSingleSignOnData"/>. </summary>
        public DynatraceSingleSignOnData()
        {
            Properties = new DynatraceSingleSignOnProperties();
        }
    }
}
