using System.Collections.Generic;

namespace Microsoft.Azure.Management.PolicyInsights.Models
{
    public partial class Attestation : Resource
    {
        public Attestation(string policyAssignmentId, string id = default(string), string name = default(string), string type = default(string), string policyDefinitionReferenceId = default(string), string complianceState = default(string), System.DateTime? expiresOn = default(System.DateTime?), string owner = default(string), string comments = default(string), IList<AttestationEvidence> evidence = default(IList<AttestationEvidence>), string provisioningState = default(string), System.DateTime? lastComplianceStateChangeAt = default(System.DateTime?), SystemData systemData = default(SystemData))
            : base(id, name, type)
        {
            PolicyAssignmentId = policyAssignmentId;
            PolicyDefinitionReferenceId = policyDefinitionReferenceId;
            ComplianceState = complianceState;
            ExpiresOn = expiresOn;
            Owner = owner;
            Comments = comments;
            Evidence = evidence;
            ProvisioningState = provisioningState;
            LastComplianceStateChangeAt = lastComplianceStateChangeAt;
            SystemData = systemData;
            CustomInit();
        }
    }
}
