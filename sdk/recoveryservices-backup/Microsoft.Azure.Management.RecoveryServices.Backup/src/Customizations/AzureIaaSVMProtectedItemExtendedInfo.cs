namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    public partial class AzureIaaSVMProtectedItemExtendedInfo
    {
        public AzureIaaSVMProtectedItemExtendedInfo(System.DateTime? oldestRecoveryPoint, int? recoveryPointCount, bool? policyInconsistent = default(bool?))
            : this(oldestRecoveryPoint, default(System.DateTime?), default(System.DateTime?), default(System.DateTime?), recoveryPointCount, policyInconsistent)
        {
        }
    }
}
