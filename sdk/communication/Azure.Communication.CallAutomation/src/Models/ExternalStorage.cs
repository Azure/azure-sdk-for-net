// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

using System;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("ExternalStorage")]
    public partial class ExternalStorage
    {
        /// <summary> Gets the Uri of a container or a location within a container. </summary>
        [CodeGenMember("RecordingDestinationContainerUrl")]
        public Uri RecordingDestinationContainerUri { get; set; }
    }
}
