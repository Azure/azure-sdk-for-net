// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Models;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
public readonly partial struct IotSecurityRecommendationType
    {
        public static IotSecurityRecommendationType IotAcrAuthentication => IoTACRAuthentication;
        public static IotSecurityRecommendationType IotAgentSendsUnutilizedMessages => IoTAgentSendsUnutilizedMessages;
        public static IotSecurityRecommendationType IotBaseline => IoTBaseline;
        public static IotSecurityRecommendationType IotEdgeHubMemOptimize => IoTEdgeHubMemOptimize;
        public static IotSecurityRecommendationType IotEdgeLoggingOptions => IoTEdgeLoggingOptions;
        public static IotSecurityRecommendationType IotInconsistentModuleSettings => IoTInconsistentModuleSettings;
        public static IotSecurityRecommendationType IotInstallAgent => IoTInstallAgent;
        public static IotSecurityRecommendationType IotIPFilterDenyAll => IoTIPFilterDenyAll;
        public static IotSecurityRecommendationType IotIPFilterPermissiveRule => IoTIPFilterPermissiveRule;
        public static IotSecurityRecommendationType IotOpenPorts => IoTOpenPorts;
        public static IotSecurityRecommendationType IotPermissiveFirewallPolicy => IoTPermissiveFirewallPolicy;
        public static IotSecurityRecommendationType IotPermissiveInputFirewallRules => IoTPermissiveInputFirewallRules;
        public static IotSecurityRecommendationType IotPermissiveOutputFirewallRules => IoTPermissiveOutputFirewallRules;
        public static IotSecurityRecommendationType IotPrivilegedDockerOptions => IoTPrivilegedDockerOptions;
        public static IotSecurityRecommendationType IotSharedCredentials => IoTSharedCredentials;
        public static IotSecurityRecommendationType IotVulnerableTlsCipherSuite => IoTVulnerableTLSCipherSuite;
    }
}
