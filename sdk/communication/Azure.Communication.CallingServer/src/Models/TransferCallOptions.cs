// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> The options for transfering a call. </summary>
    public class TransferCallOptions
    {
        /// <summary> The alternate caller id of the source. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }

        /// <summary> The UserToUserInformation. </summary>
        public string UserToUserInformation { get; set; }

        /// <summary> The operationContext for this transfer call. </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Transfer Call Options.
        /// </summary>
        /// <param name="alternateCallerId">The alternate caller id of the source</param>
        /// <param name="userToUserInformation">The userToUserInformation.</param>
        /// <param name="operationContext">The operationContext for this transfer call.</param>
        public TransferCallOptions(PhoneNumberIdentifier alternateCallerId = default, string userToUserInformation = default, string operationContext = default)
        {
            AlternateCallerId = alternateCallerId;
            UserToUserInformation = userToUserInformation;
            OperationContext = operationContext;
        }
    }
}
