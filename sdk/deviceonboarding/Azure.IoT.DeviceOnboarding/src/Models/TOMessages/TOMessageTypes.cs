// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// FDO Message Types Defined by the Protocol
    /// </summary>
    public enum TOMessageTypes
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Initiating the TO0 from owner onboarding service to rendevous server
        /// </summary>
        TO0_Hello = 20,
        /// <summary>
        /// Acknowledge the hello from owner onboarding service
        /// </summary>
        TO0_HelloAck = 21,
        /// <summary>
        /// Owner demonstrates credentials
        /// </summary>
        TO0_OwnerSign = 22,
        /// <summary>
        /// Rendevous server accepts owner credentials
        /// </summary>
        TO0_AcceptOwner = 23,
        /// <summary>
        /// Device reaches out to rendevous server
        /// </summary>
        TO1_HelloRV = 30,
        /// <summary>
        /// Rendevous server acknowledges device
        /// </summary>
        TO1_HelloRVAck = 31,
        /// <summary>
        /// Device provides proof of identity
        /// </summary>
        TO1_ProveToRV = 32,
        /// <summary>
        /// Rendevous server provides information to connect to new owner
        /// </summary>
        TO1_RVRedirect = 33,
        /// <summary>
        /// Device reaches out to new owner
        /// </summary>
        TO2_HelloDevice = 60,
        /// <summary>
        /// New owner sends ownership voucher header
        /// </summary>
        TO2_ProveOVHdr = 61,
        /// <summary>
        /// Device asks for next ownership voucher entry
        /// </summary>
        TO2_GetOVNextEntry = 62,
        /// <summary>
        /// New owner sends next ownership voucher entry
        /// </summary>
        TO2_OVNextEntry = 63,
        /// <summary>
        /// Device proves provenance
        /// </summary>
        TO2_ProveDevice = 64,
        /// <summary>
        /// New owner sends information for ownership transfer
        /// </summary>
        TO2_SetupDevice = 65,
        /// <summary>
        /// Device is ready for service info
        /// </summary>
        TO2_DeviceServiceInfoReady = 66,
        /// <summary>
        /// Owner is ready for service info
        /// </summary>
        TO2_OwnerServiceInfoReady = 67,
        /// <summary>
        /// Device sends service info
        /// </summary>
        TO2_DeviceServiceInfo = 68,
        /// <summary>
        /// Owner sends service information
        /// </summary>
        TO2_OwnerServiceInfo = 69,
        /// <summary>
        /// Successful ownership transfer
        /// </summary>
        TO2_Done = 70,
        /// <summary>
        /// Final ack
        /// </summary>
        TO2_Done2 = 71,
        /// <summary>
        /// Message type for error
        /// </summary>
        Error = 255
    }
}
