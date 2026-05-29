// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Generator bug: the MPG-emitted ModelFactory backward-compat overload uses RequestMethod for
    // the 'method' parameter instead of the original string, breaking the previously shipped wire
    // shape. Suppress that overload; consumers can call the current overload that takes a string.
    [CodeGenSuppress("RequestReportRecordContract", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestMethod), typeof(Uri), typeof(IPAddress), typeof(string), typeof(int?), typeof(int?), typeof(DateTimeOffset?), typeof(string), typeof(double?), typeof(double?), typeof(string), typeof(ResourceIdentifier), typeof(string), typeof(int?))]
    public static partial class ArmApiManagementModelFactory
    {
    }
}
