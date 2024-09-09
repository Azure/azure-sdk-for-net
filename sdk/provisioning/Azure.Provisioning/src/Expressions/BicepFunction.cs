// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Expressions;

// At the moment I'm trying to keep this minimal and not pull everything in
// https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-functions
// but I expect it'll grow a fair bit over time.

public static class BicepFunction
{
    public static BicepValue<string> GetUniqueString(params BicepValue<string>[] values) =>
        BicepSyntax.Call("uniqueString", values.Select(v => v.Compile()).ToArray());

    public static BicepValue<string> Take(BicepValue<string> text, BicepValue<int> size) =>
        BicepSyntax.Call("take", text.Compile(), size.Compile());

    public static BicepValue<string> CreateGuid(params BicepValue<string>[] values) =>
        BicepSyntax.Call("guid", values.Select(v => v.Compile()).ToArray());

    public static BicepValue<ResourceIdentifier> GetSubscriptionResourceId(params BicepValue<string>[] values) =>
        BicepSyntax.Call("subscriptionResourceId", values.Select(v => v.Compile()).ToArray());

    // TODO: Use the more efficient interpolated string handler
    public static BicepValue<string> Interpolate(FormattableString text)
    {
        if (text == null) { return BicepSyntax.Null(); }
        BicepValue<object>[] values = new BicepValue<object>[text.ArgumentCount];
        for (int i = 0; i < text.ArgumentCount; i++)
        {
            values[i] =
                text.GetArgument(i) switch
                {
                    BicepValue v => v,
                    BicepVariable v => v.Value,
                    var a => new BicepValue<object>(a?.ToString() ?? "")
                };
        };
        BicepValue<string> result = BicepSyntax.Interpolate(text.Format, [.. values.Select(v => v.Compile())]);
        result.IsSecure = values.Any(v => v.IsSecure); // Make the entire expression "secure" if any of the values are
        // TODO: Link values to result to validate anything crossing module boundaries?
        return result;
    }

    public static BicepValue<object> GetReference(BicepValue<string> resourceName) =>
        BicepSyntax.Call("reference", resourceName.Compile());

    public static ArmDeployment GetDeployment() =>
        ArmDeployment.FromExpression(BicepSyntax.Call("deployment"));

    public static Subscription GetSubscription() =>
        Subscription.FromExpression(BicepSyntax.Call("subscription"));

    public static ResourceGroup GetResourceGroup() =>
        ResourceGroup.FromExpression(BicepSyntax.Call("resourceGroup"));

    public static ResourceGroup GetResourceGroup(BicepValue<string> resourceGroupName) =>
        ResourceGroup.FromExpression(BicepSyntax.Call("resourceGroup", resourceGroupName.Compile()));

    public static ResourceGroup GetResourceGroup(BicepValue<string> subscriptionId, BicepValue<string> resourceGroupName) =>
        ResourceGroup.FromExpression(BicepSyntax.Call("resourceGroup", subscriptionId.Compile(), resourceGroupName.Compile()));

    public static BicepValue<object> ParseJson(BicepValue<object> value) =>
        BicepSyntax.Call("json", value.Compile());

    public static BicepValue<string> AsString(BicepValue<object> value) =>
        BicepSyntax.Call("string", value.Compile());

    public static BicepValue<string> ToLower(BicepValue<object> value) =>
        BicepSyntax.Call("toLower", value.Compile());

    public static BicepValue<string> ToUpper(BicepValue<object> value) =>
        BicepSyntax.Call("toUpper", value.Compile());
}
