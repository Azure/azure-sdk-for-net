// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    public class SynapsePermission
    {
        public SynapsePermission(IList<string> actions, IList<string> notActions, IList<string> dataActions, IList<string> notDataActions)
        {
            Actions = actions;
            NotActions = notActions;
            DataActions = dataActions;
            NotDataActions = notDataActions;
        }

        public IList<string> Actions { get; }

        public IList<string> NotActions { get; }

        // TODO: In order to align with ARM/KeyVault RBAC APIs, change the below type from 'string' to 'SynapseDataAction', populate the list of actions
        public IList<string> DataActions { get; }

        public IList<string> NotDataActions { get; }

        public static implicit operator RequestContent(SynapsePermission permission) => RequestContent.Create(
            new
            {
                permission.Actions,
                permission.NotActions,
                permission.DataActions,
                permission.NotDataActions
            });
    }
}
