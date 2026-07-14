// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.OperationalInsights
{
    // Preserve the previously shipped listKeys helper because custom actions are not
    // emitted by the TypeSpec-based provisioning generator.
    public partial class OperationalInsightsWorkspace
    {
        /// <summary>
        /// Get access keys for this OperationalInsightsWorkspace resource.
        /// </summary>
        /// <returns>The keys for this OperationalInsightsWorkspace resource.</returns>
        public OperationalInsightsWorkspaceSharedKeys GetKeys()
        {
            OperationalInsightsWorkspaceSharedKeys key = new();
            ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
            return key;
        }
    }
}
