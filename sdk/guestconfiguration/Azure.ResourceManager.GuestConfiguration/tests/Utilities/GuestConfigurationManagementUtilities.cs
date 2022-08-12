﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public static AssignmentType DefaultAssignmentType = new AssignmentType("ApplyAndAutoCorrect");
        public static ConfigurationMode DefaultConfigurationMode= new ConfigurationMode("ApplyAndAutoCorrect");
        public static GuestConfigurationKind DefaultKind = new GuestConfigurationKind("DSC");
        public const string DefaultAssignmentVersion = "1.0.0.3";
        public const string DefaultContext = "Azure policy";
        public const string Builtin = "Builtin";

        public const string HybridRG = "neela-sdk-rg";
        public const string HybridMachineName = "LAPTOP-4B77J53J";
        public const string DefaultAssignmentName = "AuditSecureProtocol";

        public const string VMSSRG = "aashishDeleteRG";
        public const string VMSSName = "vmss1";
        public const string VMSSAssignmentName = "EnforcePasswordHistory$pidrt3t6jlihetr2";
        public const string VMSSReportID = "521eacf2-fbc8-4bb9-8ca3-05e336803416";
    }
}
