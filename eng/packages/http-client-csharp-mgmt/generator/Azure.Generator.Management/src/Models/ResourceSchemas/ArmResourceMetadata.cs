// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary> Represents the metadata for an ARM resource, including its identity, scope, methods, and hierarchy. </summary>
/// <param name="ResourceIdPattern"> The ARM resource ID pattern. </param>
/// <param name="ResourceName"> The resource name. </param>
/// <param name="ResourceType"> The ARM resource type. </param>
/// <param name="ResourceModel"> The input model type for the resource. </param>
/// <param name="ResourceScope"> The scope of the resource. </param>
/// <param name="Methods"> The list of methods associated with the resource. </param>
/// <param name="SingletonResourceName"> The singleton resource name, if applicable. </param>
/// <param name="ParentResourceId"> The parent resource ID pattern, if applicable. </param>
/// <param name="ParentResourceType"> The expected parent resource type for extension resources with specific parent types (e.g., "Microsoft.Compute/virtualMachines"), if applicable. </param>
/// <param name="ChildResourceIds"> The list of child resource ID patterns. </param>
/// <param name="NameConstraints"> The name constraints for the resource. </param>
/// <param name="ApiVersions"> The API versions that this resource is available in. </param>
/// <param name="RbacRoles"> The RBAC roles defined for this resource. </param>
public record ArmResourceMetadata(
    string ResourceIdPattern,
    string ResourceName,
    string ResourceType,
    InputModelType ResourceModel,
    ResourceScope ResourceScope,
    IReadOnlyList<ResourceMethod> Methods,
    string? SingletonResourceName,
    string? ParentResourceId,
    string? ParentResourceType,
    IReadOnlyList<string> ChildResourceIds,
    ArmResourceNameConstraints NameConstraints,
    IReadOnlyList<string> ApiVersions,
    IReadOnlyList<ArmResourceRbacRole> RbacRoles)
{
    // ChildResourceIds is currently unpopulated and passed in as an empty array
    internal static ArmResourceMetadata DeserializeResourceMetadata(JsonElement element, InputModelType inputModel, IReadOnlyList<string> childResourceIds)
    {
        string? resourceIdPattern = null;
        string? resourceType = null;
        string? singletonResourceName = null;
        ResourceScope? resourceScope = null;
        var methods = new List<ResourceMethod>();
        string? parentResource = null;
        string? resourceName = null;

        if (element.TryGetProperty("resourceIdPattern", out var resourceIdPatternElement))
        {
            resourceIdPattern = resourceIdPatternElement.GetString();
        }
        if (element.TryGetProperty("resourceType", out var resourceTypeElement))
        {
            resourceType = resourceTypeElement.GetString();
        }
        if (element.TryGetProperty("singletonResourceName", out var singletonResourceElement))
        {
            singletonResourceName = singletonResourceElement.GetString();
        }
        if (element.TryGetProperty("resourceScope", out var scopeElement))
        {
            var scopeString = scopeElement.GetString();
            if (scopeString != null && Enum.TryParse<ResourceScope>(scopeString, true, out var scope))
            {
                resourceScope = scope;
            }

            //TODO: handle Extension resource in emitter
            if (resourceIdPattern is not null && (resourceIdPattern.StartsWith("/{resourceUri}/") || resourceIdPattern.StartsWith("/{scope}/")))
            {
                resourceScope = ResourceScope.Extension;
            }
        }
        if (element.TryGetProperty("methods", out var methodsElement))
        {
            foreach (var item in methodsElement.EnumerateArray())
            {
                methods.Add(ResourceMethod.DeserializeResourceMethod(item));
            }
        }
        if (element.TryGetProperty("parentResourceId", out var parentResourceElement))
        {
            parentResource = parentResourceElement.GetString();
        }
        string? parentResourceType = null;
        if (element.TryGetProperty("parentResourceType", out var parentResourceTypeElement))
        {
            parentResourceType = parentResourceTypeElement.GetString();
        }
        if (element.TryGetProperty("resourceName", out var resourceNameElement))
        {
            resourceName = resourceNameElement.GetString();
        }

        ArmResourceNameConstraints nameConstraints = new(null, null, null);
        if (element.TryGetProperty("nameConstraints", out var nameConstraintsElement))
        {
            nameConstraints = ArmResourceNameConstraints.DeserializeNameConstraints(nameConstraintsElement);
        }

        var apiVersions = new List<string>();
        if (element.TryGetProperty("apiVersions", out var apiVersionsElement))
        {
            foreach (var item in apiVersionsElement.EnumerateArray())
            {
                var version = item.GetString();
                if (version is not null)
                {
                    apiVersions.Add(version);
                }
            }
        }

        var rbacRoles = new List<ArmResourceRbacRole>();
        if (element.TryGetProperty("rbacRoles", out var rbacRolesElement))
        {
            foreach (var item in rbacRolesElement.EnumerateArray())
            {
                rbacRoles.Add(ArmResourceRbacRole.DeserializeRbacRole(item));
            }
        }

        return new(
            resourceIdPattern ?? throw new InvalidOperationException("resourceIdPattern cannot be null"),
            resourceName ?? throw new InvalidOperationException("resourceName cannot be null"),
            resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
            inputModel,
            resourceScope ?? throw new InvalidOperationException("resourceScope cannot be null"),
            methods,
            singletonResourceName,
            parentResource,
            parentResourceType,
            childResourceIds,
            nameConstraints,
            apiVersions,
            rbacRoles);
    }
}
