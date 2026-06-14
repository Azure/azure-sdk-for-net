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
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the generated factory overload exposes an internal AzureResourceLink type after the
    // assessmentDefinitions property is hidden behind the public SubResource compatibility property below.
    // Suppress the invalid generated overload and preserve the previous public ModelFactory signature.
    [CodeGenSuppress("SecureScoreControlDefinitionItem", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(int?), typeof(IEnumerable<AzureResourceLink>), typeof(SecurityControlType?))]
    public static partial class ArmSecurityCenterModelFactory
    {
        public static SecureScoreControlDefinitionItem SecureScoreControlDefinitionItem(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string displayName = default, string description = default, int? maxScore = default, IEnumerable<SubResource> assessmentDefinitions = default, SecurityControlType? sourceType = default)
        {
            IReadOnlyList<AzureResourceLink> assessmentDefinitionLinks = assessmentDefinitions is null
                ? new List<AzureResourceLink>()
                : System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(assessmentDefinitions, item => new AzureResourceLink(item?.Id, new Dictionary<string, BinaryData>())));
            return new SecureScoreControlDefinitionItem(
                id,
                name,
                resourceType,
                systemData,
                new SecureScoreControlDefinitionItemProperties(displayName, description, maxScore, new SecureScoreControlDefinitionSource(sourceType, new Dictionary<string, BinaryData>()), assessmentDefinitionLinks, new Dictionary<string, BinaryData>()),
                new Dictionary<string, BinaryData>());
        }
    }
}
