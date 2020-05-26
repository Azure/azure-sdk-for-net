// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import { ITemplate } from './template';

// ####################################
// 0. AutoRest abstractions
// ####################################

// The API context we use to abstract AutoRest
export interface IGeneratorContext {
    // Get a setting (either via README.md or the CLI)
    getSetting(key: string): Promise<string>;

    // Get the list of input files as URIs
    getInputUris(): Promise<string[]>;

    // Read the text contents of a file
    readFile(filename: string): Promise<string>;

    // Write the text contents of a file
    writeFile(filename: string, content: String): Promise<void>;

    // Log information, errors, and verbose messages
    log(message: string): void;
    warn(message: string): void;
    error(message: string): void;
    verbose(message: string): void;
}

// The AutoRest plugin handler
export declare type GeneratorHandler = (ctx: IGeneratorContext) => Promise<void>;


// ####################################
// 1. Project files/settings
// ####################################

// A project full of files to translate into generated code
export interface IProject {
    // Generator context
    context: IGeneratorContext,

    // Top level settings
    settings: { [key: string]: any },

    // Swagger source file
    swagger: any,

    // Swagger cache for resolving references
    cache: {
        info?: IServiceInfo,
        parameters: IParameters,
        definitions: IModels,
        responses: IResponses,
        customTypes: IModels,
        voidType: IVoidType
    }
}


// ####################################
// 2. Service Model
// ####################################

export interface IServiceModel {
    context: IGeneratorContext,
    info: IServiceInfo,
    service: IService,
    models: IModels,
    voidType: IVoidType
}

export interface IServiceInfo {
    title: string,
    description: string|null,
    namespace: string,
    extensionsName: string,
    modelFactoryName: string,
    public: boolean,
    sync: boolean,
    consumes: string[],
    produces: string[],
    license: {
        name: string,
        header: string
    },
    versions: string[],
    host?: {
        template: ITemplate,
        parameters: IParameters,
        useSchemePrefix: boolean,
        position: string
    }
}

export interface IService {
    title: string,
    description: string|null,
    namespace: string,
    name: string,
    extensionsName: string,
    groups: {
        [key: string]: IOperationGroup
    },
    operations: IOperationGroup
}

export interface IModels {
    [key: string]: (IModelType|undefined)
}

export interface IModelType {
    type: string,
    description?: string,
    external?: boolean,
    extendedHeaders: IHeader[],
    returnStream?: boolean
}

export interface IVoidType extends IModelType {
    type: "void",
    external?: true
}

export interface IObjectType extends IModelType {
    name: string,
    namespace: string,
    properties: IProperties,
    additionalPropeties?: IModelType,
    xml?: IXmlSettings,
    serialize: boolean,
    deserialize: boolean,
    disableWarnings?: string,
    public: boolean,
    struct: boolean
}

export function isObjectType(model: IModelType): model is IObjectType {
    return model.type === `object`;
}

export interface IProperties {
    [name: string]: (IProperty|undefined)
}

export interface IProperty {
    name: string,
    clientName: string,
    description?: string,
    required?: boolean,
    readonly: boolean,
    xml?: IXmlSettings,
    model: IModelType,
    isNullable?: boolean
}

export interface IXmlSettings {
    name?: string,
    namespace?: string,
    prefix?: string,
    attribute?: boolean,
    wrapped?: boolean
}

export interface IEnumType extends IModelType {
    name: string,
    namespace: string,
    modelAsString?: boolean,
    customSerialization: boolean,
    constant: boolean,
    public: boolean,
    skipValue?: string,
    values: IEnumValue[]
}

export interface IEnumValue {
    value: any,
    name?: string,
    description?: string
}

export function isEnumType(model: IModelType): model is IEnumType {
    return model.type === `enum`;
}

export interface IPrimitiveType extends IModelType {
    allowEmpty?: boolean,
    collectionFormat?: string,
    maximum?: number,
    exclusiveMaximum?: boolean,
    minimum?: number,
    exclusiveMinimum?: boolean,
    multipleOf?: number,
    maxLength?: number,
    minLength?: number,
    maxItems?: number,
    minItems?: number,
    uniqueItems?: boolean,
    pattern?: string
    defaultValue?: any,
    xml?: IXmlSettings,
    itemType?: IModelType,
    dictionaryPrefix?: string
}

export function isPrimitiveType(model: IModelType): model is IPrimitiveType {
    return model.type !== `object` && model.type !== `enum`;
}

export interface IParameters {
    [key: string]: (IParameter|undefined)
}

export interface IParameter {
    name: string,
    clientName: string,
    description?: string,
    required: boolean,
    location: string,
    skipUrlEncoding: boolean,
    parameterGroup?: string,
    model: IModelType,
    trace: boolean
}

export interface IResponses {
    [code: string]: (IResponse|undefined)
}

export interface IResponse {
    code: string,
    description?: string,
    clientName?: string,
    body?: IModelType,
    bodyClientName: string,
    headers: IHeaders,
    model?: IModelType,
    exception?: boolean,
    public: boolean,
    returnStream?: boolean,
    struct: boolean
}

export interface IResponseGroup {
    model: IModelType,
    successes: IResponse[],
    failures: IResponse[]
}

export interface IHeaders {
    [key: string]: (IHeader|undefined)
}

export interface IHeader {
    name: string,
    clientName: string,
    description?: string,
    collectionPrefix?: string,
    model: IModelType,
    ignore: boolean
}

export interface IOperationGroup {
    [key: string]: IOperation
}

export interface IOperation {
    name: string,
    group?: string,
    method: string,
    path: ITemplate,
    summary?: string,
    description?: string,
    consumes: string,
    produces: string,
    request: {
        all: IParameter[],
        arguments: IParameter[],
        constants: IParameter[],
        paths: IParameter[],
        queries: IParameter[],
        headers: IParameter[],
        body?: IParameter
    },
    response: IResponseGroup,
    paging?: {
        nextLinkName: string,
        itemName?: string,
        operationName: string
    }
}
