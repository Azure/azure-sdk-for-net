import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@resource("foos")
model Foo is TrackedResource<FooProperties> {
    ...ResourceNameParameter<Foo, SegmentName = "foos">;

    ...ExtendedLocationProperty;
}

@useSystemTextJsonConverter("csharp")
model FooProperties {
    /** the service url */
    serviceUrl?: url;

    /** something */
    something?: string;

    /** boolean value */
    boolValue?: boolean;

    /** float value */
    floatValue?: float32;

    /** double value */
    doubleValue?: float64;
}

@armResourceOperations
interface Foos {
    createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;

    get is ArmResourceRead<Foo>;

    delete is ArmResourceDeleteWithoutOkAsync<Foo>;

    list is ArmResourceListByParent<Foo>;
}
