// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> A Microsoft Teams Phone user who is using a Communication Services resource to extend their Teams Phone set up. </summary>
    public partial class TeamsExtensionUserIdentifierModel
    {
        internal CommunicationCloudEnvironmentModel? Cloud { get; set; }
    }
}
