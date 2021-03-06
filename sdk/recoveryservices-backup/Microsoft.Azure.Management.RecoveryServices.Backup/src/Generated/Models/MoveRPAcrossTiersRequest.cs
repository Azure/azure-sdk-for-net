// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class MoveRPAcrossTiersRequest
    {
        /// <summary>
        /// Initializes a new instance of the MoveRPAcrossTiersRequest class.
        /// </summary>
        public MoveRPAcrossTiersRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MoveRPAcrossTiersRequest class.
        /// </summary>
        /// <param name="objectType">Gets the class type.</param>
        /// <param name="sourceTierType">Source tier from where RP needs to be
        /// moved. Possible values include: 'Invalid', 'InstantRP',
        /// 'HardenedRP', 'ArchivedRP'</param>
        /// <param name="targetTierType">Target tier where RP needs to be
        /// moved. Possible values include: 'Invalid', 'InstantRP',
        /// 'HardenedRP', 'ArchivedRP'</param>
        public MoveRPAcrossTiersRequest(string objectType = default(string), RecoveryPointTierType? sourceTierType = default(RecoveryPointTierType?), RecoveryPointTierType? targetTierType = default(RecoveryPointTierType?))
        {
            ObjectType = objectType;
            SourceTierType = sourceTierType;
            TargetTierType = targetTierType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the class type.
        /// </summary>
        [JsonProperty(PropertyName = "objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets source tier from where RP needs to be moved. Possible
        /// values include: 'Invalid', 'InstantRP', 'HardenedRP', 'ArchivedRP'
        /// </summary>
        [JsonProperty(PropertyName = "sourceTierType")]
        public RecoveryPointTierType? SourceTierType { get; set; }

        /// <summary>
        /// Gets or sets target tier where RP needs to be moved. Possible
        /// values include: 'Invalid', 'InstantRP', 'HardenedRP', 'ArchivedRP'
        /// </summary>
        [JsonProperty(PropertyName = "targetTierType")]
        public RecoveryPointTierType? TargetTierType { get; set; }

    }
}
