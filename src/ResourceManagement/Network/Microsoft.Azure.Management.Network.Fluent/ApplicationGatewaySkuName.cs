using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewaySkuName : ExpandableStringEnum<ApplicationGatewaySkuName>
    {
        public static readonly ApplicationGatewaySkuName StandardSmall = new ApplicationGatewaySkuName() { Value = "Standard_Small" };
        public static readonly ApplicationGatewaySkuName StandardMedium = new ApplicationGatewaySkuName() { Value = "Standard_Medium" };
        public static readonly ApplicationGatewaySkuName StandardLarge = new ApplicationGatewaySkuName() { Value = "Standard_Large" };
    }
}
