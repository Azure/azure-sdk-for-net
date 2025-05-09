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

@resource("bars")
@parentResource(Foo)
model Bar is TrackedResource<BarProperties> {
    ...ResourceNameParameter<Bar, SegmentName = "bars">;
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

model BarProperties {
    /** the value for Bar */
    barValue?: string;
}

@armResourceOperations
interface Foos {
    createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;

    get is ArmResourceRead<Foo>;

    delete is ArmResourceDeleteWithoutOkAsync<Foo>;

    list is ArmResourceListByParent<Foo>;
}

@armResourceOperations
interface Bars {
    createOrUpdate is ArmResourceCreateOrUpdateAsync<Bar>;

    get is ArmResourceRead<Bar>;

    delete is ArmResourceDeleteWithoutOkAsync<Bar>;

    list is ArmResourceListByParent<Bar>;
}
