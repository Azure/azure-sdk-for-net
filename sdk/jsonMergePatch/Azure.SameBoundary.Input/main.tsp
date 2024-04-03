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

/* Input cases */

@usage(Usage.input)
@access(Access.public)
model InputPrimitiveModel {
    requiredString: string;
    optionalString?: string;

    requiredInt: int32;
    optionalInt?: int32;
}

@usage(Usage.input)
@access(Access.public)
model InputDictionaryModel {
    requiredStringDictionary: Record<string>;
    optionalStringDictionary?: Record<string>;

    requiredIntDictionary: Record<int32>;
    optionalIntDictionary?: Record<int32>;

    requiredModelDictionary: Record<InputDummy>;
    optionalModelDictionary?: Record<InputDummy>;

    requiredDictionaryDictionary: Record<Record<InputDummy>>;
    optionalDictionaryDictionary?: Record<Record<InputDummy>>;

    requiredArrayDictionary: Record<InputDummy[]>;
    optionalArrayDictionary?: Record<InputDummy[]>;
}

@usage(Usage.input)
@access(Access.public)
model InputArrayModel {
    requiredStringArray: string[];
    optionalStringArray?: string[];

    requiredIntArray: int32[];
    optionalIntArray?: int32[];

    requiredModelArray: InputDummy[];
    optionalModelArray?: InputDummy[];

    requiredArrayArray: InputDummy[][];
    optionalArrayArray?: InputDummy[][];

    requiredDictionaryArray: Record<InputDummy>[];
    optionalDictionaryArray?: Record<InputDummy>[];
}

@usage(Usage.input)
@access(Access.public)
model InputInheritanceModel extends InputBaseModel{
    extendedProperty?: string;
}

@usage(Usage.input)
@access(Access.public)
model InputBaseModel {
    baseProperty1?: string;
    baseProperty2: int32;
    baseProperty3?: Record<string>;
}

@usage(Usage.input)
@access(Access.public)
model InputAddAnotherLevelToInheritanceModel extends InputInheritanceModel {
    anotherLevelProperty?: string;
}

@usage(Usage.input)
@access(Access.public)
model InputNestedModel {
    requiredModel: InputDummy;
    optionalModel?: InputDummy;
}

@usage(Usage.input)
@access(Access.public)
model InputDummy {
    property?: string;
}

@put
op dummyOperation(): void;