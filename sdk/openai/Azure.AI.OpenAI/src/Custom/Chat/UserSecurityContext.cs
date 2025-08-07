// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

/// <summary> User security context contains several parameters that describe the application itself, and the end user that interacts with the application. These fields assist your security operations teams to investigate and mitigate security incidents by providing a comprehensive approach to protecting your AI applications. [Learn more](https://aka.ms/TP4AI/Documentation/EndUserContext) about protecting AI applications using Microsoft Defender for Cloud. </summary>
[CodeGenType("AzureUserSecurityContext")]
[Experimental("AOAI001")]
public partial class UserSecurityContext
{
    /// <summary> The name of the application. Sensitive personal information should not be included in this field. </summary>
    public string ApplicationName { get; set;}
    /// <summary> This identifier is the Microsoft Entra ID (formerly Azure Active Directory) user object ID used to authenticate end-users within the generative AI application. Sensitive personal information should not be included in this field. </summary>
    public string EndUserId { get; set; }
    /// <summary> The Microsoft 365 tenant ID the end user belongs to. It's required when the generative AI application is multitenant. </summary>
    public string EndUserTenantId { get; set; }
    /// <summary> Captures the original client's IP address. </summary>
    [CodeGenMember("SourceIp")]
    public string SourceIP { get; set; }

    public UserSecurityContext()
    { }
}