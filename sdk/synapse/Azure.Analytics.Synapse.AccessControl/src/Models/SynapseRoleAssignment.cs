// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.AccessControl
{
    public class SynapseRoleAssignment
    {
        public SynapseRoleAssignment(string id, SynapseRoleAssignmentProperties properties)
        {
            Id = id;
            Properties = properties;

            // TODO: Why aren't name and type available?
            //Name = name;
            //Type = type;
        }

        public string Id { get; }

        public SynapseRoleAssignmentProperties Properties { get; }
    }
}
