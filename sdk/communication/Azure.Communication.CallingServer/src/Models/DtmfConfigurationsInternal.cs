// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    [CodeGenModel("DtmfConfigurations")]
    internal partial class DtmfConfigurationsInternal
    {
        [CodeGenMember("StopTones")]
        public IList<StopTones> StopTones { get; set; }
    }
}
