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
/// <param name="Scope"> The scope information for the resource. </param>
/// <param name="Methods"> The list of methods associated with the resource. </param>
/// <param name="SingletonResourceName"> The singleton resource name, if applicable. </param>
/// <param name="ParentResourceId"> The parent resource ID pattern, if applicable. </param>
/// <param name="ChildResourceIds"> The list of child resource ID patterns. </param>
/// <param name="NameConstraints"> The name constraints for the resource. </param>
/// <param name="ApiVersions"> The API versions that this resource is available in. </param>
/// <param name="RbacRoles"> The RBAC roles defined for this resource. </param>
/// <param name="ConstantPathParameters"> Constant path parameter values for this resource. When a resource is expanded from a dynamic parent type pattern, this maps parameter names to their constant string values. </param>
public record ArmResourceMetadata(
    RequestPathPattern ResourceIdPattern,
    string ResourceName,
    string ResourceType,
    InputModelType ResourceModel,
    ArmScopeInfo Scope,
    IReadOnlyList<ResourceMethod> Methods,
    string? SingletonResourceName,
    RequestPathPattern? ParentResourceId,
    IReadOnlyList<RequestPathPattern> ChildResourceIds,
    ArmResourceNameConstraints NameConstraints,
    IReadOnlyList<string> ApiVersions,
    IReadOnlyList<ArmResourceRbacRole> RbacRoles,
    IReadOnlyDictionary<string, string>? ConstantPathParameters = null)
{
    // ChildResourceIds is currently unpopulated and passed in as an empty array
    internal static ArmResourceMetadata DeserializeResourceMetadata(JsonElement element, InputModelType inputModel, IReadOnlyList<RequestPathPattern> childResourceIds)
    {
        string? resourceIdPattern = null;
        string? resourceType = null;
        string? singletonResourceName = null;
        ArmScopeInfo? scope = null;
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
        if (element.TryGetProperty("scope", out var scopeElement))
        {
            scope = ArmScopeInfo.Deserialize(scopeElement);
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

        Dictionary<string, string>? constantPathParameters = null;
        if (element.TryGetProperty("constantPathParameters", out var constantPathParamsElement)
            && constantPathParamsElement.ValueKind == JsonValueKind.Object)
        {
            constantPathParameters = new Dictionary<string, string>();
            foreach (var prop in constantPathParamsElement.EnumerateObject())
            {
                var value = prop.Value.GetString();
                if (value is not null)
                {
                    constantPathParameters[prop.Name] = value;
                }
            }
        }

        return new(
            new RequestPathPattern(resourceIdPattern ?? throw new InvalidOperationException("resourceIdPattern cannot be null")),
            resourceName ?? throw new InvalidOperationException("resourceName cannot be null"),
            resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
            inputModel,
            scope ?? throw new InvalidOperationException("scope cannot be null"),
            methods,
            singletonResourceName,
            parentResource is not null ? new RequestPathPattern(parentResource) : null,
            childResourceIds,
            nameConstraints,
            apiVersions,
            rbacRoles,
            constantPathParameters);
    }
}
