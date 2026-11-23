using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/** A resource with acronym-bearing path parameters. */
model AcronymWidget is TrackedResource<AcronymWidgetProperties> {
  ...ResourceNameParameter<
    AcronymWidget,
    KeyName = "sourceIpAddress",
    SegmentName = "acronymWidgets"
  >;
}

model AcronymWidgetProperties {
  description?: string;
}

/** An action body without a conventional ARM suffix. */
model IPAddress {
  address: string;
}

/** An IPv4 action body without a conventional ARM suffix. */
model IPv4Address {
  address: string;
}

model AcronymWidgetListResult is Azure.Core.Page<AcronymWidget>;

model AcronymWidgetProvider {
  ...ProviderNamespace<AcronymWidget>;

  /** The source address used to select the collection. */
  @path
  @segment("sourceAddresses")
  sourceIpv6Address: string;
}

@armResourceOperations
interface AcronymWidgets {
  get is ArmResourceRead<AcronymWidget, Provider = AcronymWidgetProvider>;

  listByAddress is ArmResourceListByParent<
    AcronymWidget,
    Response = ArmResponse<AcronymWidgetListResult>,
    Provider = AcronymWidgetProvider
  >;

  @post
  @action("configure")
  @armResourceAction(AcronymWidget)
  configure(
    ...ResourceInstanceParameters<AcronymWidget, Provider = AcronymWidgetProvider>,
    @body parameters: IPAddress,
  ): ArmResponse<IPAddress> | ErrorResponse;

  @post
  @action("configureIPv4")
  @armResourceAction(AcronymWidget)
  configureIPv4(
    ...ResourceInstanceParameters<AcronymWidget, Provider = AcronymWidgetProvider>,
    @body parameters: IPv4Address,
  ): ArmResponse<IPv4Address> | ErrorResponse;
}
