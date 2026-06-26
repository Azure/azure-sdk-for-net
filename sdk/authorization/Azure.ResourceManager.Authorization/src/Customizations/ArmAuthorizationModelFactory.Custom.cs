// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Authorization.Models
{
    public static partial class ArmAuthorizationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DenyAssignmentPermission" />. </summary>
        /// <param name="actions"> Actions to which the deny assignment does not grant access. </param>
        /// <param name="notActions"> Actions to exclude from that the deny assignment does not grant access. </param>
        /// <param name="dataActions"> Data actions to which the deny assignment does not grant access. </param>
        /// <param name="notDataActions"> Data actions to exclude from that the deny assignment does not grant access. </param>
        /// <param name="condition"> The conditions on the Deny assignment permission. This limits the resources it applies to. </param>
        /// <param name="conditionVersion"> Version of the condition. </param>
        /// <returns> A new <see cref="Models.DenyAssignmentPermission" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DenyAssignmentPermission DenyAssignmentPermission(IEnumerable<string> actions = null, IEnumerable<string> notActions = null, IEnumerable<string> dataActions = null, IEnumerable<string> notDataActions = null, string condition = null, string conditionVersion = null)
        {
            var denyAssignmentPermission = new DenyAssignmentPermission
            {
                Condition = condition,
                ConditionVersion = conditionVersion,
            };
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    denyAssignmentPermission.Actions.Add(action);
                }
            }
            if (notActions != null)
            {
                foreach (var notAction in notActions)
                {
                    denyAssignmentPermission.NotActions.Add(notAction);
                }
            }
            if (dataActions != null)
            {
                foreach (var dataAction in dataActions)
                {
                    denyAssignmentPermission.DataActions.Add(dataAction);
                }
            }
            if (notDataActions != null)
            {
                foreach (var notDataAction in notDataActions)
                {
                    denyAssignmentPermission.NotDataActions.Add(notDataAction);
                }
            }
            return denyAssignmentPermission;
        }

        /// <summary> Initializes a new instance of <see cref="Models.RoleManagementPrincipal" />. </summary>
        /// <param name="id"> The id of the principal made changes. </param>
        /// <param name="displayName"> The name of the principal made changes. </param>
        /// <param name="principalType"> Type of the principal. </param>
        /// <param name="email"> Email of principal. </param>
        /// <returns> A new <see cref="Models.RoleManagementPrincipal" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RoleManagementPrincipal RoleManagementPrincipal(string id = null, string displayName = null, RoleManagementPrincipalType? principalType = null, string email = null)
        {
            return new RoleManagementPrincipal
            {
                Id = id,
                DisplayName = displayName,
                PrincipalType = principalType,
                Email = email,
            };
        }
    }
}
