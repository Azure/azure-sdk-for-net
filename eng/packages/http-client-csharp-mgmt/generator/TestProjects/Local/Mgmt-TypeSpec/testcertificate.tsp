import "@typespec/rest";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

namespace MgmtTypeSpec;

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;

/** A test certificate resource. */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Test scenario"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Test scenario"
model TestCertificate is Azure.ResourceManager.ProxyResource<TestCertificateProperties, false> {
  ...ResourceNameParameter<
    Resource = TestCertificate,
    KeyName = "certificateName",
    SegmentName = "certificates",
    NamePattern = ""
  >;
}

/** Properties of a test certificate. */
model TestCertificateProperties {
  thumbprint?: string;
}

/** Parameters for creating or updating a certificate. */
model TestCertificateCreateOrUpdateParameters {
  /** The properties associated with the certificate. */
  properties?: TestCertificateCreateOrUpdateProperties;
}

/** Properties for creating or updating a certificate. */
model TestCertificateCreateOrUpdateProperties {
  /** The thumbprint algorithm. */
  thumbprintAlgorithm?: string;
  /** The thumbprint string. */
  thumbprintString?: string;
}

@armResourceOperations
interface TestCertificates {
  /** Gets information about the specified certificate. */
  get is ArmResourceRead<TestCertificate>;

  /** Creates or updates a certificate. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-put-operation-response-codes" "Test scenario"
  createOrUpdate is Azure.ResourceManager.Legacy.CreateOrReplaceAsync<
    TestCertificate,
    Request = TestCertificateCreateOrUpdateParameters
  >;

  /** Updates a certificate. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-patch" "Test scenario"
  @patch(#{ implicitOptionality: false })
  update is ArmCustomPatchSync<
    TestCertificate,
    PatchModel = TestCertificateCreateOrUpdateParameters
  >;

  /** Deletes a certificate. */
  delete is ArmResourceDeleteSync<TestCertificate>;
}
