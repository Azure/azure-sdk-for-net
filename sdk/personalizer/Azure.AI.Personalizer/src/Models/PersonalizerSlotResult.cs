// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Slot Result. </summary>
    [CodeGenModel("SlotResponse")]
    public partial class PersonalizerSlotResult
    {
        /// <summary> Start date for the range. </summary>
        [CodeGenMember("Id")]
        public string SlotId { get; }
    }
}
