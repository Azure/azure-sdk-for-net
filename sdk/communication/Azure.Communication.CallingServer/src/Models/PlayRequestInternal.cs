// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    [CodeGenModel("PlayRequest")]
    internal partial class PlayRequestInternal
    {
        [CodeGenMember("PlayTo")]
        public IList<CommunicationIdentifierModel> PlayTo { get; set; }
    }
}
