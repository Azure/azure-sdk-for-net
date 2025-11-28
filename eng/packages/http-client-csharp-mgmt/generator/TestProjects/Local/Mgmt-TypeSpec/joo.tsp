import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-liftr-base";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using Azure.Core;
using LiftrBase;

namespace MgmtTypeSpec;

@resource("joos")
model Joo is TrackedResource<JooProperties, false> {
  ...ResourceNameParameter<Joo, SegmentName = "joos">;
}

model JooProperties {
  name: string;
}

@armResourceOperations
interface Joos {
  createOrUpdate is ArmResourceCreateOrReplaceSync <Joo>;

  get is ArmResourceRead<Joo>;

  delete is ArmResourceDeleteWithoutOkAsync<Joo>;
}