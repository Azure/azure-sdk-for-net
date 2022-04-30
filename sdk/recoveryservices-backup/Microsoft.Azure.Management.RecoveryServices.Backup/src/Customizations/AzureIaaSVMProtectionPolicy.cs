namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public partial class AzureIaaSVMProtectionPolicy : ProtectionPolicy
    {
        public AzureIaaSVMProtectionPolicy(int? protectedItemsCount, IList<string> resourceGuardOperationRequests, InstantRPAdditionalDetails instantRPDetails, SchedulePolicy schedulePolicy, RetentionPolicy retentionPolicy, int? instantRpRetentionRangeInDays, string timeZone = default(string), string policyType = default(string))
            : this(protectedItemsCount, resourceGuardOperationRequests, instantRPDetails, schedulePolicy, retentionPolicy, default(IDictionary<string, TieringPolicy>), instantRpRetentionRangeInDays, timeZone, policyType)
        {
        }
    }
}
