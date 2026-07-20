// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("BackupJobSubTask", typeof(int), typeof(string), typeof(string))]
    [CodeGenSuppress("TaskId")]
    [CodeGenSuppress("TaskName")]
    [CodeGenSuppress("TaskStatus")]
    public partial class BackupJobSubTask
    {
        /// <summary> Initializes a new instance of <see cref="BackupJobSubTask"/>. </summary>
        /// <param name="taskId"> Task Id of the Sub Task. </param>
        /// <param name="taskName"> Name of the Sub Task. </param>
        /// <param name="taskStatus"> Status of the Sub Task. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackupJobSubTask(int taskId, string taskName, string taskStatus)
        {
            Argument.AssertNotNull(taskName, nameof(taskName));
            Argument.AssertNotNull(taskStatus, nameof(taskStatus));

            AdditionalDetails = new ChangeTrackingDictionary<string, string>();
            TaskId = taskId;
            TaskName = taskName;
            TaskStatus = taskStatus;
        }

        /// <summary> Task Id of the Sub Task. </summary>
        public int TaskId { get; set; }

        /// <summary> Name of the Sub Task. </summary>
        public string TaskName { get; set; }

        /// <summary> Status of the Sub Task. </summary>
        public string TaskStatus { get; set; }
    }
}
