// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Suppress broken ModelFactory overload where RequestMethod? is used instead of string.
// Generator bug: ModelFactory backward-compat overload uses wrong parameter type.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Suppress broken backward-compat overload where RequestMethod? is used instead of string
    [CodeGenSuppress("RequestReportRecordContract", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestMethod), typeof(Uri), typeof(IPAddress), typeof(string), typeof(int?), typeof(int?), typeof(DateTimeOffset?), typeof(string), typeof(double?), typeof(double?), typeof(string), typeof(ResourceIdentifier), typeof(string), typeof(int?))]
    public static partial class ArmApiManagementModelFactory
    {
    }
}
