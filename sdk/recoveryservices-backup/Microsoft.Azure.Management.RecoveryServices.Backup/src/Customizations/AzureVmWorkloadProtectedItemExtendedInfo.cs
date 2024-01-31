namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    public partial class AzureVmWorkloadProtectedItemExtendedInfo
    {
        public AzureVmWorkloadProtectedItemExtendedInfo(System.DateTime? oldestRecoveryPoint, int? recoveryPointCount, string policyState = default(string), string recoveryModel = default(string))
            : this(oldestRecoveryPoint, default(System.DateTime?), default(System.DateTime?), default(System.DateTime?), recoveryPointCount, policyState, recoveryModel)
        {
        }
    }
}
