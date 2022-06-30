// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The options for removing participant from a call. </summary>
    public class RemoveParticipantsOptions
    {
        /// <summary> The Operation Context. </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Remove Participants Options
        /// </summary>
        /// <param name="operationContext">The operationContext.</param>
        public RemoveParticipantsOptions(string operationContext)
        {
            OperationContext = operationContext;
        }
    }
}
