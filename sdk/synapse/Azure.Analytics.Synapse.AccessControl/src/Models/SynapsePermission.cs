// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

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
        // TODO: change the below type from 'string' to 'SynapseDataAction', populate the list of actions
        public IList<string> DataActions { get; }

        public IList<string> NotDataActions { get; }
    }
}
