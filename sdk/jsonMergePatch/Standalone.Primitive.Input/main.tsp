import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ClientGenerator.Core;

@doc("Test for merge-patch+json content-type")
@service({
    title: "Patch Service",
})
@versioned(Versions)
namespace Payload.JsonMergePatch;

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    v1_1: "v1.1"
}

// Standalone model as input model, with a required/optional primitive reference type and a required/optional primitive reference type
model PatchModel {
    requiredString: string;
    optionalString?: string;

    requiredInt: int32;
    optionalInt?: int32;
}

@put
@convenientAPI(true)
op patch(@header contentType: "application/merge-patch+json", @body body: PatchModel): void;