using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayOperationalState : ExpandableStringEnum<ApplicationGatewayOperationalState>
    {
        public static readonly ApplicationGatewayOperationalState Stopped = new ApplicationGatewayOperationalState() { Value = "Stopped" };
        public static readonly ApplicationGatewayOperationalState Starting = new ApplicationGatewayOperationalState() { Value = "Starting" };
        public static readonly ApplicationGatewayOperationalState Running = new ApplicationGatewayOperationalState() { Value = "Running" };
        public static readonly ApplicationGatewayOperationalState Stopping = new ApplicationGatewayOperationalState() { Value = "Stopping" };
    }
}
