import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

/** Internal properties retained by a customized resource model. */
@access(Access.internal)
model InternalFactoryAccountProperties {
  @visibility(Lifecycle.Read)
  organizationId?: string;

  @visibility(Lifecycle.Read)
  accountId?: string;
}

/** Resource used to verify model-factory accessibility after customization. */
@resource("internalFactoryAccounts")
model InternalFactoryAccount is ProxyResource<InternalFactoryAccountProperties> {
  ...ResourceNameParameter<InternalFactoryAccount>;
}

@armResourceOperations
interface InternalFactoryAccounts {
  get is ArmResourceRead<InternalFactoryAccount>;
}
