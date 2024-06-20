import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ClientGenerator.Core;

@doc("Test for merge-patch+json content-type. It is to illustrate standalone model.")
@service({
    title: "Patch Service",
})
@versioned(Versions)
namespace Payload.JsonMergePatch;

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    v1_1: "v1.1"
}

/* RoundTrip cases */

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripPrimitiveModel {
    requiredString: string;
    optionalString?: string;

    requiredInt: int32;
    optionalInt?: int32;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripDictionaryModel {
    requiredStringDictionary: Record<string>;
    optionalStringDictionary?: Record<string>;

    requiredIntDictionary: Record<int32>;
    optionalIntDictionary?: Record<int32>;

    requiredModelDictionary: Record<RoundTripDummy>;
    optionalModelDictionary?: Record<RoundTripDummy>;

    requiredDictionaryDictionary: Record<Record<RoundTripDummy>>;
    optionalDictionaryDictionary?: Record<Record<RoundTripDummy>>;

    requiredArrayDictionary: Record<RoundTripDummy[]>;
    optionalArrayDictionary?: Record<RoundTripDummy[]>;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripArrayModel {
    requiredStringArray: string[];
    optionalStringArray?: string[];

    requiredIntArray: int32[];
    optionalIntArray?: int32[];

    requiredModelArray: RoundTripDummy[];
    optionalModelArray?: RoundTripDummy[];

    requiredArrayArray: RoundTripDummy[][];
    optionalArrayArray?: RoundTripDummy[][];

    requiredDictionaryArray: Record<RoundTripDummy>[];
    optionalDictionaryArray?: Record<RoundTripDummy>[];
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripInheritanceModel extends RoundTripBaseModel{
    extendedProperty?: string;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripBaseModel {
    baseProperty1?: string;
    baseProperty2: int32;
    baseProperty3?: Record<string>;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripAddAnotherLevelToInheritanceModel extends RoundTripInheritanceModel {
    anotherLevelProperty?: string;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripNestedModel {
    requiredModel: RoundTripDummy;
    optionalModel?: RoundTripDummy;
}

@usage(Usage.input | Usage.output)
@access(Access.public)
model RoundTripDummy {
    property?: string;
}

@put
op dummyOperation(): void;