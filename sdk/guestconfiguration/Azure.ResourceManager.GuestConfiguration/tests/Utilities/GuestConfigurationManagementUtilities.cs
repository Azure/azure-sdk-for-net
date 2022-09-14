// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.GuestConfiguration.Models;

namespace Azure.ResourceManager.GuestConfiguration.Tests.Utilities
{
    public class GuestConfigurationManagementUtilities
    {
        public const string DefaultResourceGroupName = "GuestConfigurationSDKTestRecord";
        public static AzureLocation DefaultResourceLocation = new AzureLocation("westcentralus");
        public static string DefaultResourceType = "ApplyAndAutoCorrect";
        public const string DefaultAzureVMName = "SDKTestVM";
        public static GuestConfigurationAssignmentType DefaultAssignmentType = new GuestConfigurationAssignmentType("ApplyAndAutoCorrect");
        public static LcmConfigurationMode DefaultConfigurationMode = new LcmConfigurationMode("ApplyAndAutoCorrect");
        public static GuestConfigurationKind DefaultKind = new GuestConfigurationKind("DSC");
        public const string DefaultAssignmentVersion = "1.0.0.3";
        public const string DefaultContext = "Azure policy";
        public const string Builtin = "Builtin";

        public const string HybridRG = "neela-sdk-rg";
        public const string HybridMachineName = "LAPTOP-4B77J53J";
        public const string DefaultAssignmentName = "AuditSecureProtocol";

        public const string VMSSRG = "aashishDeleteRG";
        public const string VMSSName = "vmssNeela";
        public const string VMSSAssignmentName = "EnforcePasswordHistory$pidrt3t6jlihetr2";
        public const string VMSSReportID = "da034575-e995-4ac2-af28-7efc2fac1efa";
    }
}
