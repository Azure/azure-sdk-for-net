// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ComputeBulkActions.Models
{
    /// <summary> Specifies Redeploy, Reboot and ScheduledEventsAdditionalPublishingTargets Scheduled Event related configurations. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AutomaticallyApprove")]
    public partial class ScheduledEventsPolicy
    {
        /// <summary> Specifies whether Redeploy Scheduled Events are automatically approved. </summary>
        public bool? IsRedeployAutomaticallyApproved
        {
            get
            {
                return UserInitiatedRedeploy is null ? default : UserInitiatedRedeploy.AutomaticallyApprove;
            }
            set
            {
                if (value is null)
                {
                    UserInitiatedRedeploy = null;
                    return;
                }
                if (UserInitiatedRedeploy is null)
                {
                    UserInitiatedRedeploy = new UserInitiatedRedeploy();
                }
                UserInitiatedRedeploy.AutomaticallyApprove = value;
            }
        }

        /// <summary> Specifies whether Reboot Scheduled Events are automatically approved. </summary>
        public bool? IsRebootAutomaticallyApproved
        {
            get
            {
                return UserInitiatedReboot is null ? default : UserInitiatedReboot.AutomaticallyApprove;
            }
            set
            {
                if (value is null)
                {
                    UserInitiatedReboot = null;
                    return;
                }
                if (UserInitiatedReboot is null)
                {
                    UserInitiatedReboot = new UserInitiatedReboot();
                }
                UserInitiatedReboot.AutomaticallyApprove = value;
            }
        }

        /// <summary> Specifies if Scheduled Events should be auto-approved when all instances are down. Its default value is true. </summary>
        public bool? IsAllInstancesDownAutomaticallyApproved
        {
            get
            {
                return AllInstancesDown is null ? default : AllInstancesDown.AutomaticallyApprove;
            }
            set
            {
                if (value is null)
                {
                    AllInstancesDown = null;
                    return;
                }
                if (AllInstancesDown is null)
                {
                    AllInstancesDown = new AllInstancesDown();
                }
                AllInstancesDown.AutomaticallyApprove = value;
            }
        }
    }
}
