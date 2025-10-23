// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Expressions;

// At the moment I'm trying to keep this minimal and not pull everything in
// https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions
// but I expect it'll grow a fair bit over time.

/// <summary>
/// Provides access to standard Bicep functions.
/// </summary>
public static class BicepFunction
{
    /// <summary>
    /// Creates a deterministic hash string based on the <paramref name="values"/>
    /// provided as parameters.  This represents the <c>uniqueString</c> Bicep
    /// function.
    /// </summary>
    /// <param name="values">
    /// The value used in the hash function to create a unique string.  At
    /// least one value is required.
    /// </param>
    /// <returns>A string containing 13 characters.</returns>
    /// <remarks>
    /// <para>
    /// This function is helpful when you need to create a unique name for a
    /// resource.  You provide parameter values that limit the scope of
    /// uniqueness for the result.  You can specify whether the name is unique
    /// down to subscription, resource group, or deployment.
    /// </para>
    /// <para>
    /// The returned value isn't a random string, but rather the result of a
    /// hash function.  The returned value is 13 characters long.  It isn't
    /// globally unique.  You may want to combine the value with a prefix from
    /// your naming convention to create a name that is meaningful.
    /// </para>
    /// <para>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#uniquestring">
    /// Bicep Functions Reference</see> for more.
    /// </para>
    /// </remarks>
    public static BicepValue<string> GetUniqueString(params BicepValue<string>[] values)
    {
        if (values.Length < 1)
        {
            throw new ArgumentException($"{nameof(GetUniqueString)} requires at least one value.", nameof(values));
        }
        return BicepSyntax.Call("uniqueString", values.Select(v => v.Compile()).ToArray());
    }

    /// <summary>
    /// Returns a string with the specified number of characters from the start
    /// of the string.  This represents the <c>take</c> Bicep function.
    /// </summary>
    /// <param name="text">The string to take the elements from.</param>
    /// <param name="size">
    /// The number of characters to take.  If this value is 0 or less, an empty
    /// string is returned.  If it's larger than the length of the given
    /// string, all the characters in the string are returned.
    /// </param>
    /// <returns>A (possibly) shortened string.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#take">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<string> Take(BicepValue<string> text, BicepValue<int> size) =>
        BicepSyntax.Call("take", text.Compile(), size.Compile());

    /// <summary>
    /// Creates a value in the format of a globally unique identifier based on
    /// the values provided as parameters.  This represents the <c>guid</c>
    /// Bicep function.
    /// </summary>
    /// <param name="values">
    /// The value used in the hash function to create the GUID.  At least one
    /// value is required.
    /// </param>
    /// <returns>
    /// A string containing 36 characters in the format of a globally unique
    /// identifier.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This function is helpful when you need to create a value in the format
    /// of a globally unique identifier. You provide parameter values that
    /// limit the scope of uniqueness for the result. You can specify whether
    /// the name is unique down to subscription, resource group, or deployment.
    /// </para>
    /// <para>
    /// The returned value isn't a random string, but rather the result of a
    /// hash function on the parameters.  The returned value is 36 characters
    /// long.  It isn't globally unique.
    /// </para>
    /// <para>
    /// NOTE: The order of the parameters affects the returned value.  For
    /// example, <c>CreateGuid("Hello", "World")</c> and
    /// <c>CreateGuid("World", "Hello")</c> don't return the same value.
    /// </para>
    /// <para>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#guid">
    /// Bicep Functions Reference</see> for more.
    /// </para>
    /// </remarks>
    public static BicepValue<string> CreateGuid(params BicepValue<string>[] values)
    {
        if (values.Length < 1)
        {
            throw new ArgumentException($"{nameof(CreateGuid)} requires at least one value.", nameof(values));
        }
        return BicepSyntax.Call("guid", values.Select(v => v.Compile()).ToArray());
    }

    /// <summary>
    /// Returns the unique identifier for a resource deployed at the
    /// subscription level.  This represents the <c>subscriptionResourceId</c>
    /// Bicep function.
    /// </summary>
    /// <param name="values">
    /// Optional subscription id, resource types, and resource names used to
    /// construct the resource ID.  At least two values are required.
    /// </param>
    /// <returns>
    /// The unique identifier for a resource deployed at the subscription level.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The identifier is returned in the following format:
    /// <c>/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</c>
    /// </para>
    /// <para>
    /// You use this function to get the resource ID for resources that are
    /// deployed to the subscription rather than a resource group.  The
    /// returned ID differs from the value returned by the resourceId function
    /// by not including a resource group value.
    /// </para>
    /// <para>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-resource#subscriptionresourceid">
    /// Bicep Functions Reference</see> for more.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException">When <paramref name="values"/> is empty or contains fewer than two elements.</exception>
    public static BicepValue<ResourceIdentifier> GetSubscriptionResourceId(params BicepValue<string>[] values)
    {
        if (values.Length < 2)
        {
            throw new ArgumentException($"{nameof(GetSubscriptionResourceId)} requires at least two values.", nameof(values));
        }
        return BicepSyntax.Call("subscriptionResourceId", values.Select(v => v.Compile()).ToArray());
    }

    /// <summary>
    /// Returns the unique identifier of a resource. This represents the <c>resourceId</c>
    /// Bicep function.
    /// </summary>
    /// <param name="values">
    /// Optional subscription id, resource group name, resource types, and resource names used to
    /// construct the resource ID.  At least two values are required.
    /// </param>
    /// <returns>
    /// The unique identifier of the resource.
    /// </returns>
    /// <remarks>
    /// <para>
    /// You use this function when the resource name is ambiguous or not provisioned within the same Bicep file.
    /// The format of the returned identifier varies based on whether the deployment happens at the scope of
    /// a resource group, subscription, management group, or tenant.
    /// </para>
    /// <para>
    /// See the
    /// <see href="https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-functions-resource#resourceid">
    /// Bicep Functions Reference</see> for more.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException">When <paramref name="values"/> is empty or contains fewer than two elements.</exception>
    public static BicepValue<ResourceIdentifier> GetResourceId(params BicepValue<string>[] values)
    {
        if (values.Length < 2)
        {
            throw new ArgumentException($"{nameof(GetResourceId)} requires at least two values.", nameof(values));
        }
        return BicepSyntax.Call("resourceId", values.Select(v => v.Compile()).ToArray());
    }

    /// <summary>
    /// Returns the resource ID for an extension resource. An extension resource is a resource type
    /// that is applied to another resource to add to its capabilities.
    /// This represents the <c>extensionResourceId</c> Bicep function.
    /// </summary>
    /// <param name="resourceId">The resource ID to be extended on.</param>
    /// <param name="resourceType">The resource type.</param>
    /// <param name="resourceNames">The resource names.</param>
    /// <returns>
    /// The resource ID for an extension resource.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The basic format of the resource ID returned by this function is:
    /// <c>{scope}/providers/{extensionResourceProviderNamespace}/{extensionResourceType}/{extensionResourceName}</c>
    /// The scope segment varies by the resource being extended.
    /// When the extension resource is applied to a resource, the resource ID is returned in the following format:
    /// <c>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{baseResourceProviderNamespace}/{baseResourceType}/{baseResourceName}/providers/{extensionResourceProviderNamespace}/{extensionResourceType}/{extensionResourceName}</c>
    /// When the extension resource is applied to a resource group, the format is:
    /// <c>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{extensionResourceProviderNamespace}/{extensionResourceType}/{extensionResourceName}</c>
    /// When the extension resource is applied to a subscription, the format is:
    /// <c>/subscriptions/{subscriptionId}/providers/{extensionResourceProviderNamespace}/{extensionResourceType}/{extensionResourceName}</c>
    /// When the extension resource is applied to a management group, the format is:
    /// <c>/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/{extensionResourceProviderNamespace}/{extensionResourceType}/{extensionResourceName}</c>
    /// </para>
    /// <para>
    /// See the
    /// <see href="https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-functions-resource#extensionresourceid">
    /// Bicep Functions Reference</see> for more.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException">When <paramref name="resourceNames"/> is empty.</exception>
    public static BicepValue<ResourceIdentifier> GetExtensionResourceId(
        BicepValue<ResourceIdentifier> resourceId,
        BicepValue<string> resourceType,
        params BicepValue<string>[] resourceNames)
    {
        if (resourceNames.Length < 1)
        {
            throw new ArgumentException($"{nameof(GetExtensionResourceId)} requires at least one element for resourceNames parameter.", nameof(resourceNames));
        }
        return BicepSyntax.Call("extensionResourceId", [resourceId.Compile(), resourceType.Compile(), .. resourceNames.Select(v => v.Compile())]);
    }

    /// <summary>
    /// Returns information about the current deployment operation.  This
    /// represents the <c>deployment</c> Bicep function.
    /// </summary>
    /// <returns>
    /// This function returns the object that is passed during deployment.  The
    /// properties in the returned object differ based on whether you are
    /// deploying a local Bicep file or deploying to a resource group /
    /// subscription / management group / tenant.
    /// </returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.comazure/azure-resource-manager/bicep/bicep-functions-deployment#deployment">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static ArmDeployment GetDeployment()
    {
        ArmDeployment deployment = new("deployment");
        ((IBicepValue)deployment).Expression = BicepSyntax.Call("deployment");
        return deployment;
    }

    /// <summary>
    /// Returns details about the subscription for the current deployment.  This
    /// represents the <c>subscription</c> Bicep function.
    /// </summary>
    /// <returns>
    /// Returns details about the subscription for the current deployment.
    /// </returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-scope#subscription">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static Subscription GetSubscription()
    {
        Subscription subscription = new("subscription");
        ((IBicepValue)subscription).Expression = BicepSyntax.Call("subscription");
        return subscription;
    }

    /// <summary>
    /// Returns the tenant of the user.  This represents the <c>tenant</c>
    /// Bicep function.
    /// </summary>
    /// <returns>Properties of the current tenant.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-scope#tenant">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static Tenant GetTenant()
    {
        Tenant tenant = new("tenant");
        ((IBicepValue)tenant).Expression = BicepSyntax.Call("tenant");
        return tenant;
    }

    /// <summary>
    /// Returns an object that represents the current resource group.  This
    /// represents the <c>resourceGroup</c> Bicep function.
    /// </summary>
    /// <returns>Properties of the current resource group.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-scope#resourcegroup">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static ResourceGroup GetResourceGroup()
    {
        ResourceGroup rg = new("resourceGroup");
        ((IBicepValue)rg).Expression = BicepSyntax.Call("resourceGroup");
        return rg;
    }

    /// <summary>
    /// Converts a valid JSON string into a JSON data type.  This represents
    /// the <c>json</c> Bicep function.
    /// </summary>
    /// <param name="value">
    /// The value to convert to JSON. The string must be a properly formatted
    /// JSON string.
    /// </param>
    /// <returns>
    /// The JSON data type from the specified string, or an empty value when
    /// null is specified.
    /// </returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-object#json">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<object> ParseJson(BicepValue<object> value) =>
        BicepSyntax.Call("json", value.Compile());

    /// <summary>
    /// Converts the specified value to a string.  Strings are returned as-is.
    /// Other types are converted to their equivalent JSON representation.
    /// This represents the <c>string</c> Bicep function.
    /// </summary>
    /// <param name="value">
    /// The value to convert to string.  Any type of value can be converted,
    /// including objects and arrays.
    /// </param>
    /// <returns>A string of the converted value.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#string">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<string> AsString(BicepValue<object> value) =>
        BicepSyntax.Call("string", value.Compile());

    /// <summary>
    /// Converts the specified string to lower case.  This represents the
    /// <c>toLower</c> Bicep function.
    /// </summary>
    /// <param name="value">The value to convert to lower case.</param>
    /// <returns>The string converted to lower case.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#tolower">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<string> ToLower(BicepValue<object> value) =>
        BicepSyntax.Call("toLower", value.Compile());

    /// <summary>
    /// Converts the specified string to upper case.  This represents the
    /// <c>toUpper</c> Bicep function.
    /// </summary>
    /// <param name="value">The value to convert to upper case.</param>
    /// <returns>The string converted to upper case.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#toupper">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<string> ToUpper(BicepValue<object> value) =>
        BicepSyntax.Call("toUpper", value.Compile());

    /// <summary>
    /// Combines multiple string values <paramref name="values"/> and returns
    /// the concatenated string.  This represents the <c>concat</c> Bicep
    /// function.  To improve readability, prefer
    /// <see cref="Interpolate"/> instead of <see cref="Concat"/>.
    /// </summary>
    /// <param name="values">Strings in sequential order for concatenation.</param>
    /// <returns>A string or array of concatenated values.</returns>
    /// <remarks>
    /// See the
    /// <see href="https://learn.microsoft.com/azure/azure-resource-manager/bicep/bicep-functions-string#concat">
    /// Bicep Functions Reference</see> for more.
    /// </remarks>
    public static BicepValue<string> Concat(params BicepValue<string>[] values)
    {
        if (values.Length < 1)
        {
            throw new ArgumentException($"{nameof(Concat)} requires at least one value.", nameof(values));
        }
        return BicepSyntax.Call("concat", values.Select(v => v.Compile()).ToArray());
    }

    /// <summary>
    /// Builds a Bicep interpolated string expression from C# interpolated string syntax
    /// or a <see cref="FormattableString"/> instance.
    /// Use this method to combine literal text, C# expressions and Bicep expressions
    /// into a single Bicep string value.
    /// </summary>
    /// <param name="handler">
    /// The <see cref="BicepInterpolatedStringHandler"/> that collects literal and formatted segments from the interpolated string.
    /// </param>
    /// <returns>
    /// A <see cref="BicepValue{String}"/> representing the constructed Bicep interpolated string expression of type <c>string</c>.
    /// </returns>
    public static BicepValue<string> Interpolate(BicepInterpolatedStringHandler handler) =>
        handler.Build();
}
