// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataProtection.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class RestoreJobRecoveryPointDetails
    {
        /// <summary>
        /// Initializes a new instance of the RestoreJobRecoveryPointDetails
        /// class.
        /// </summary>
        public RestoreJobRecoveryPointDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RestoreJobRecoveryPointDetails
        /// class.
        /// </summary>
        public RestoreJobRecoveryPointDetails(string recoveryPointID = default(string), System.DateTime? recoveryPointTime = default(System.DateTime?))
        {
            RecoveryPointID = recoveryPointID;
            RecoveryPointTime = recoveryPointTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recoveryPointID")]
        public string RecoveryPointID { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recoveryPointTime")]
        public System.DateTime? RecoveryPointTime { get; set; }

    }
}
