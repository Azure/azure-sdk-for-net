// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.GuestConfiguration.Tests.Utilities
{
    public class GuestConfigurationManagementUtilities
    {
        public const string DefaultResourceGroupName = "GuestConfigurationSDKTestRecord";
        //public const string DefaultResourceLocation = "westcentralus";
        public const string DefaultResourceLocation = "centraluseuap";
        public const string DefaultAzureVMName = "SDKTestRecordVM002";
        public const string DefaultAssignmentType = "ApplyAndAutoCorrect";
        public const string DefaultKind = "DSC";
        public const string DefaultAssignmentVersion = "1.0.0.3";
        public const string DefaultContext = "Azure policy A";

        public const string HybridRG = "neela-sdk-rg";
        public const string HybridMachineName = "LAPTOP-4B77J53J";
        public const string DefaultAssignmentName = "AuditSecureProtocol";

        public const string VMSSRG = "aashishDeleteRG";
        public const string VMSSName = "vmss6";
        public const string VMSSAssignmentName = "EnforcePasswordHistory$pid23q5eseudwr5y";
        public const string VMSSReportID = "21a601c0-f39e-48a0-82f2-7eb17e2c899c";
    }
}
