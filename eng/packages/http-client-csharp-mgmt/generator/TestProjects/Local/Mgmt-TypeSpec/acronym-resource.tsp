import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";

using Azure.ResourceManager;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/** An IP address resource with an automatically derived SDK name. */
model IpAddress is ProxyResource<IpAddressProperties> {
  ...ResourceNameParameter<
    Resource = IpAddress,
    KeyName = "ipAddressName",
    SegmentName = "ipAddresses",
    NamePattern = ""
  >;
}

/** Properties of the IP address. */
model IpAddressProperties {
  /** The address value. */
  address?: string;
}

@armResourceOperations
interface IpAddresses {
  get is ArmResourceRead<IpAddress>;
  listByResourceGroup is ArmResourceListByParent<IpAddress>;
}
