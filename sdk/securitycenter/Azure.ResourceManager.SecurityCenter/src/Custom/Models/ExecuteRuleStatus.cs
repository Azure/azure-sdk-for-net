// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary>
    /// Execute status of Security GovernanceRule over a given scope
    /// Serialized Name: ExecuteRuleStatus
    /// </summary>
    public partial class ExecuteRuleStatus
    {
        /// <summary> Initializes a new instance of ExecuteRuleStatus. </summary>
        internal ExecuteRuleStatus()
        {
        }

        /// <summary> Initializes a new instance of ExecuteRuleStatus. </summary>
        /// <param name="operationId">
        /// Unique key for the execution of GovernanceRule
        /// Serialized Name: ExecuteRuleStatus.operationId
        /// </param>
        internal ExecuteRuleStatus(string operationId)
        {
            OperationId = operationId;
        }

        /// <summary>
        /// Unique key for the execution of GovernanceRule
        /// Serialized Name: ExecuteRuleStatus.operationId
        /// </summary>
        public string OperationId { get; }
    }
}
