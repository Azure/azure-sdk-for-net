// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import {
    IProject,
    IServiceModel, IService, IServiceInfo, 
    IModels, IModelType, isObjectType, isEnumType, isPrimitiveType,
    IObjectType, IProperties, IProperty,
    IEnumType, IEnumValue,
    IPrimitiveType,
    IParameters, IParameter,
    IResponses, IResponse, IResponseGroup,
    IHeaders, IHeader,
    IOperationGroup, IOperation
} from './models';
import * as naming from './naming';
import * as template from './template';

// Load the swagger into a more usable form
export async function create(project: IProject) : Promise<IServiceModel> {
    // Get the service properties
    const info = createServiceInfo(project);
    project.cache.info = info;
    
    // Process global parameters
    const params = optional(() => project.swagger.parameters, { });
    Object.keys(params).forEach(name => getGlobalParameter(project, `#/parameters/${name}`));

    // Process global definitions
    const defs = optional(() => project.swagger.definitions, { });
    Object.keys(defs).forEach(name => getGlobalDefinition(project, `#/definitions/${name}`));
    
    // Process global responses
    const responses = optional(() => project.swagger.responses, { });
    Object.keys(responses).forEach(name => getGlobalResponse(project, 'default', `#/responses/${name}`));

    // Process service operations
    const service = createService(project);

    // Fail on things we're not supporting
    unsupported(() => project.swagger.security);
    unsupported(() => project.swagger.tags);
    unsupported(() => project.swagger.externalDocs);

    // Filter the list of models to generate
    const models: IModels = { };
    for (const [name, model] of Object.entries(project.cache.customTypes)) {
        if (!model) { continue; }
        if (model.external) { continue; }
        if (isEnumType(model) && model.constant) { continue; }
        models[name] = model;
    }

    // Create the service model
    return {
        context: project.context,
        info: info,
        service: service,
        models,
        voidType: project.cache.voidType
    };
}

// ####################################
// Swagger quirks
// ####################################

// Read an expression and force an error if it's not found
function required(fn: () => any, location?: string): any {
    try {
        const value = fn();
        if (value !== null && value !== undefined) {
            return value;
        }
    } catch {
    }

    let msg = `Failed to read ${fn.toString()}`;
    if (location) { msg += ` (in ${location})`; }
    throw msg;
}

// Ignore failures in optional values that might not be present
function optional(fn: () => any, defaultValue: any = null): any {
    try {
        return fn() || defaultValue;
    } catch {
        return defaultValue;
    }
}

// Fail on swagger properties we're not checking (yet...)
function unsupported(fn: () => any, location?: string): void {
    let value = null;
    try { value = fn(); } catch { }
    if (value !== null && value !== undefined) {
        let msg = `Generator does not support ${fn.toString()}`;
        if (location) { msg += ` (in ${location})`; }
        throw msg;       
    }
}

// Warn about temporarily ignored TODOs
function todo(project: IProject, fn: () => any, location?: string): void {
    let value = null;
    try { value = fn(); } catch { }
    if (value !== null && value !== undefined) {
        let msg = `TODO: Support for ${fn.toString()}`;
        if (location) { msg += ` (in ${location})`; }
        project.context.warn(msg);
    }
}

// Look up a parameter in the global cache
function getGlobalParameter(project: IProject, ref: string): IParameter {
    const parts = ref.split(/#/)[1].split(/\//g);
    if (parts.length !== 3 || parts[0] !== '' || parts[1] !== 'parameters') {
        throw `Invalid parameter reference ${ref}`;
    }

    const name = parts[2];
    let param = project.cache.parameters[name];
    if (!param) {
        param = createParameter(project, project.swagger.parameters[name], `swagger.parameters['${name}']`);
        project.cache.parameters[name] = param;
    }
    return param;
}

// Look up a type definition in the global cache
function getGlobalDefinition(project: IProject, ref: string): IModelType {
    const parts = ref.split(/#/)[1].split(/\//g);
    if (parts.length !== 3 || parts[0] !== '' || parts[1] !== 'definitions') {
        throw `Invalid definition reference ${ref}`;
    }

    let name = parts[2];
    let type = project.cache.definitions[name];
    if (!type) {
        type = createType(project, name, project.swagger.definitions[name], `swagger.definitions['${name}']`);
        if (isObjectType(type) || isEnumType(type)) {
            name = type.name;
        }
        project.cache.definitions[name] = type;
    }
    return type;
}

// Look up a response in the global cache
function getGlobalResponse(project: IProject, code: string, ref: string): IResponse {
    const parts = ref.split(/#/)[1].split(/\//g);
    if (parts.length !== 3 || parts[0] !== '' || parts[1] !== 'responses') {
        throw `Invalid response reference ${ref}`;
    }

    const name = parts[2];
    let response = project.cache.responses[name];
    if (!response) {
        response = createResponse(project, code, name, project.swagger.responses[name], `swagger.responses['${name}']`);
        if (response.body) {
            enableDeserialization(response.body);
        }
        project.cache.responses[name] = response;
    }
    return response;
}

// Register a custom type to be generated
function registerCustomType(project: IProject, model: IModelType) {
    // Ignore constants
    if (isEnumType(model) && model.constant) { return; }

    // TODO: Consider merging?  At least for enums?  Or even checking values length for a winner?

    if (isObjectType(model) || isEnumType(model)) {
        if (project.cache.customTypes[model.name]) {
            // Ignore enums because you can't $ref them
            if (isObjectType(model)) {
                project.context.warn(`Ignoring redefined ${model.name}`);
            }
        } else {
            project.cache.customTypes[model.name] = model;
        }
    }
}

// ####################################
// Turn swagger into our service model
// ####################################

// Get the service info, host, and standard properties
function createServiceInfo(project: IProject): IServiceInfo {
    // Ensure it's the right version
    const swaggerVersion = required(() => project.swagger.swagger);
    if (swaggerVersion !== `2.0`) { throw `Can only process swagger 2.0, not ${swaggerVersion}`; }

    // x-az-skip-path-components is designed to let you pass in the base URI
    // and path components together as a formed URI rather than constructing it
    // via components.  
    const collapseResourceUris = optional(
        () => project.swagger.info[`x-ms-code-generation-settings`][`x-az-skip-path-components`]);
    if (!collapseResourceUris) {
        throw `x-az-skip-path-components is required (in project.swagger.info['x-ms-code-generation-settings'])`;
    }

    // Process info
    required(() => project.swagger.info);
    todo(project, () => project.swagger.info.contact, `project.swagger.info.contact`);
    todo(project, () => project.swagger.info.termsOfService, `project.swagger.info.termsOfService`);

    // Process license
    const license = <string>optional(
        () => project.swagger.license.name,
        optional(() => project.swagger.info[`x-ms-code-generation-settings`].header));
    if (license !== 'MIT') { throw `Only the MIT license is supported`; }

    // Process schemes
    const schemes = optional(() => project.swagger.schemes, [`https`]);
    if (schemes.length != 1 || schemes[0] != `https`) { throw `Only HTTPS is supported for  project.swagger.schemes`; }

    // Process produces + consumes
    const consumes = required(() => project.swagger.consumes);
    if (consumes.length != 1 || consumes[0] != `application/xml`) {
        throw `Only application/xml is supported for project.swagger.consumes`;
    }
    const produces = required(() => project.swagger.produces);
    if (produces.length != 1 || produces[0] != `application/xml`) {
        throw `Only application/xml is supported for project.swagger.produces`;
    }

    // Process host
    unsupported(() => project.swagger.host);
    unsupported(() => project.swagger.basePath);
    let serviceHost = undefined;
    const host = optional(() => project.swagger[`x-ms-parameterized-host`]);
    if (host) {
        const location = `project.swagger['x-ms-parameterized-host']`;

        // Load the parameters
        const params: IParameters = { };
        if (host.parameters && host.parameters.length > 0) {
            for (let i = 0; i < host.parameters.length; i++) {
                const p = createParameter(project, host.parameters[i], `${location}.parameters[${i}]`);
                params[p.name] = p;
            }
        }

        serviceHost = {
            template: template.parse(<string>required(() => host.hostTemplate, location)),
            parameters: params,
            useSchemePrefix: optional(() => host.useSchemePrefix, false),
            position: <string>optional(() => host.positionInOperation, "first")
        };
    }

    // Process security definitions
    if (project.swagger.securityDefinitions) {
        project.context.verbose(`project.swagger.securityDefinitions is being ignored`);
    }

    let isPublic: boolean|undefined = project.swagger.info[`x-ms-code-generation-settings`][`x-az-public`];
    if (isPublic === undefined) {
        isPublic = true;
    }

    // Create the info
    const title = <string>required(() => project.swagger.info.title);
    return {
        title: title,
        description: <string|null>optional(() => project.swagger.info.description, null),
        namespace: <string>required(() => project.swagger.info[`x-ms-code-generation-settings`].namespace),
        extensionsName: <string>optional(
            () => project.swagger.info[`x-ms-code-generation-settings`][`client-extensions-name`],
            title + ' Extensions'),
        modelFactoryName: <string>optional(
            () => project.swagger.info[`x-ms-code-generation-settings`][`client-model-factory-name`],
            title + ' ModelFactory'),
        versions: [ <string>required(() => project.swagger.info.version) ],
        public: isPublic,
        sync: <boolean>optional(() => project.swagger.info[`x-ms-code-generation-settings`][`x-az-include-sync-methods`], false),
        consumes: [`application/xml`],
        produces: [`application/xml`],
        host: serviceHost,
        license: {
            name: 'MIT',
            header: `Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License.`
        }
    };
}

function createParameter(project: IProject, swagger: any, location: string): IParameter {
    // Pull references first
    if (swagger[`$ref`]) {
        return getGlobalParameter(project, swagger[`$ref`]);
    }

    const name = required(() => swagger.name, location);

    const at = required(() => swagger[`in`], location);
    if (at === `formData`) { throw `formData is not supported for ${location}.in`; }

    const reqd = optional(() => swagger.required, at === `path`);
    if (at === `path` && !reqd) { throw `${location}.required must be true for path parameters`; }
    
    const clientName = optional(() => swagger[`x-ms-client-name`], name);
    const skipUrlEncoding = optional(() => swagger[`x-ms-skip-url-encoding`], false);
    
    const parameterLocation: string|undefined = swagger[`x-ms-parameter-location`];
    if (parameterLocation === 'client') {
        throw `'x-ms-parameter-location: client' is not currently supported (in ${location})`;
    }

    let parameterGroup: string|undefined = undefined;
    const grouping = swagger[`x-ms-parameter-grouping`];
    if (grouping) {
        parameterGroup = grouping.name;
        unsupported(() => grouping.postfix, `${location}['x-ms-parameter-grouping'].postfix`);
    }

    const trace = optional(() => swagger[`x-az-trace`], false);

    unsupported(() => swagger[`x-ms-client-flatten`], location);
    unsupported(() => swagger[`x-ms-client-request-id`], location);

    // TODO: Flip to '(at === `body`) ? ' instead of the 'schema || ' if there's trouble
    const model = createType(project, clientName, swagger.schema || swagger, location);
    if (reqd) { checkIfConstant(model); }
    
    // Make all the model properties writeable
    enableMutation(model);

    return {
        name,
        clientName,
        description: swagger.description,
        required: reqd,
        location: at,
        skipUrlEncoding,
        parameterGroup,
        model,
        trace
    };
}

function checkIfConstant(model: IModelType) {
    if (isEnumType(model) && model.values.length === 1) {
        // Mark required enums with 1 value as constants
        model.constant = true;
    }
}

function createType(project: IProject, name: string, swagger: any, location: string): IModelType {
    // Pull references first
    if (swagger[`$ref`]) {
        return getGlobalDefinition(project, swagger[`$ref`]);
    }

    let model: IModelType;

    // Create an object or primitive type
    if ((swagger.type === 'object' || swagger.type === undefined) && swagger.format !== `file` && !swagger.additionalProperties) {
        model = createObjectType(project, name, swagger, `${location}.schema`);
    } else if (swagger.enum || swagger[`x-ms-enum`]) {
        model = createEnumType(project, name, swagger, location);
    } else {
        model = createPrimitiveType(project, swagger, location);
    }

    // Check if it's only defined to represent an external type
    if (swagger[`x-ms-external`]) {
        model.external = true;
    }

    // Register the type
    registerCustomType(project, model);

    return model;
}

function createObjectType(project: IProject, name: string, swagger: any, location: string): IObjectType {
    if (swagger.type !== `object`) {
       project.context.warn(`${location}.type should be object, not ${swagger.type}`);
    }

    // Get the properties
    const properties: IProperties = { };
    for (const [name, def] of <[string, any]>Object.entries(swagger.properties || { })) {
        unsupported(() => def[`x-ms-client-flatten`], `${location}.properties['${name}']`);
        unsupported(() => def[`x-ms-mutability`], `${location}.properties['${name}']`);

        let isNullable: boolean|undefined = def[`x-az-nullable-array`];
        if (isNullable === undefined) {
            isNullable = false;
        }

        properties[name] = {
            name,
            clientName: optional(() => def[`x-ms-client-name`], name),
            description: def.description,
            readonly: true,
            xml: def.xml || { },
            model: createType(project, name, def, `${location}.properties['${name}']`),
            isNullable: isNullable
        };
    }

    // Set required properties
    for (const name of <string[]>(swagger.required || [])) {
        const prop = properties[name];
        if (prop) {
            prop.required = true;
            checkIfConstant(prop.model);
        }
    }

    // Add additional
    let additional: IModelType|undefined = undefined;
    if (swagger.additionalProperties) {
        additional = createType(project, '__additional__', swagger.additionalProperties, `${location}.additionalProperties`);
    }
    
    unsupported(() => swagger.allOf, location);
    unsupported(() => swagger.externalDocs, location);
    unsupported(() => swagger.example, location);
    unsupported(() => swagger.discriminator, location);
    unsupported(() => swagger[`x-ms-discriminator-value`], location);
    unsupported(() => swagger.readOnly, location);
    unsupported(() => swagger[`x-ms-azure-resource`], location);
    
    let isPublic: boolean|undefined = swagger[`x-az-public`];
    if (isPublic === undefined) {
        isPublic = true;
    }

    let isStruct: boolean|undefined = swagger[`x-az-struct`];
    if (isStruct === undefined) {
        isStruct = false;
    }

    const info = <IServiceInfo>required(() => project.cache.info);
    return {
        type: `object`,
        name: swagger[`x-ms-client-name`] || name,
        namespace: `${info.namespace}.Models`,
        description: swagger.description,
        properties,
        additionalPropeties: additional,
        xml: swagger.xml || { },
        serialize: false,
        deserialize: false,
        disableWarnings: swagger[`x-az-disable-warnings`],
        public: isPublic,
        extendedHeaders: [],
        struct: isStruct
    };
}

function createEnumType(project: IProject, name: string, swagger: any, location: string): IEnumType {
    if (swagger.type !== `string`) {
       project.context.warn(`${location}.type should be string, not ${swagger.type} for enum`);
    }

    let modelAsString: boolean|undefined = undefined;
    let values: IEnumValue[];
    let originalValues = <IEnumValue[]>(swagger.enum || []).map((v: any) => ({ value: v }));
    const ex = swagger[`x-ms-enum`];
    if (ex) {
        name = ex.name || name;
        modelAsString = ex.modelAsString;
        values = ex.values || originalValues;
    } else {
        values = originalValues;
    }

    // Check if we need a custom serializer
    const customSerialization = values.some(v => (v.value !== naming.enumField(v.name || v.value)));

    let isPublic: boolean|undefined = swagger[`x-az-public`];
    if (isPublic === undefined) {
        isPublic = true;
    }

    const info = <IServiceInfo>required(() => project.cache.info);
    return {
        type: `enum`,
        name: name,
        namespace: `${info.namespace}.Models`,
        description: swagger.description,
        modelAsString,
        constant: false,
        customSerialization,
        public: isPublic,
        skipValue: swagger[`x-az-enum-skip-value`],
        values,
        extendedHeaders: []
    };
}

function createPrimitiveType(project: IProject, swagger: any, location: string): IPrimitiveType {
    // The format is always more specific
    let type: string = swagger.format || swagger.type;
    if (type === 'int32') {
        type = 'integer';
    } else if (type === 'int64') {
        type = 'long';
    }

    let dictionaryPrefix = <string|undefined>swagger[`x-ms-header-collection-prefix`];
    let itemType: IPrimitiveType|undefined = undefined;
    if (swagger.items) {
        itemType = createType(project, '__item__', swagger.items, `${location}.items`);
    } else if (dictionaryPrefix || swagger.additionalProperties ) {
        itemType = createType(project, '__dictionary__', swagger.additionalProperties || {type: "string"}, `${location}.additionalProperties`);
        type = "dictionary";
    }
    
    if (type === `object`) {
        project.context.warn(`${location}.type should not be object`);
    }

    return {
        type,
        description: swagger.description,
        allowEmpty: swagger.allowEmptyValue,
        collectionFormat: swagger.collectionFormat,
        maximum: swagger.maximum,
        exclusiveMaximum: swagger.exclusiveMaximum,
        minimum: swagger.minimum,
        exclusiveMinimum: swagger.exclusiveMinimum,
        multipleOf: swagger.multipleOf,
        maxLength: swagger.maxLength,
        minLength: swagger.minLength,
        maxItems: swagger.maxItems,
        minItems: swagger.minItems,
        uniqueItems: swagger.uniqueItems,
        pattern: swagger.pattern,
        defaultValue: swagger.default,
        xml: swagger.xml || { },
        itemType,
        dictionaryPrefix,
        extendedHeaders: []
    };
}

// Walk all the reachable object types.  We have plenty of scenarios where we want
// to contextually enable a feature on an object hierarchy (like whether or not to
// serialize an object graph) which may not be evident on the individual types.
function eachReachableObject(type: IModelType, fn: ((t: IObjectType) => void), stop?: ((t: IObjectType) => boolean)): void {
    if (isObjectType(type) && (!stop || stop(type))) {
        fn(type);
        for (const prop of <IProperty[]>Object.values(type.properties)) {
            eachReachableObject(prop.model, fn, stop);
        }
    } else if (isPrimitiveType(type) && type.itemType) {
        // TODO: Figure out if this explodes on recursive self-reference indirected through an array
        eachReachableObject(type.itemType, fn, stop);
    }
}

// Mark an object hierarchy for serialization
function enableSerialization(type: IModelType) {
    eachReachableObject(
        type,
        t => t.serialize = true,
        t => !t.serialize);
}

// Mark an object hierarchy for deserialization
function enableDeserialization(type: IModelType) {
    eachReachableObject(
        type,
        t => t.deserialize = true,
        t => !t.deserialize);
}

// Mark an object hierarchy as mutable
function enableMutation(type: IModelType) {
    const visited = new Set();
    eachReachableObject(
        type,
        t => {
            visited.add(t);
            for (const prop of <IProperty[]>Object.values(t.properties)) {
                prop.readonly = false;
            }
        },
        t => !visited.has(t));
}

// Create the responses
function createResponse(project: IProject, code: string, name: string, swagger: any, location: string): IResponse {
    // Pull references first
    if (swagger[`$ref`]) {
        // Override the referenced code with what we're using
        const response = { ...getGlobalResponse(project, code, swagger[`$ref`]) };
        response.code = code;
        return response;
    }
    
    let model: IModelType|undefined = undefined;
    if (swagger.schema) {
        model = createType(project, name, swagger.schema, `${location}['${code}'].schema`);
    }

    const headers: IHeaders =
        createHeaders(project, swagger.headers, `${location}['${code}'].headers`);

    unsupported(() => swagger.examples, `${location}['${code}']`);

    let isPublic: boolean|undefined = swagger[`x-az-public`];
    if (isPublic === undefined) {
        isPublic = true;
    }

    let isStruct: boolean|undefined = swagger[`x-az-struct`];
    if (isStruct === undefined) {
        isStruct = false;
    }

    return {
        code,
        description: swagger.description,
        clientName: <string>optional(() => swagger[`x-az-response-name`]),
        body: model,
        bodyClientName: <string>optional(() => swagger[`x-az-response-schema-name`], `Body`), // TODO: switch from 'Body' to body.name?
        headers,
        exception: <boolean>optional(() => swagger[`x-az-create-exception`]),
        public: isPublic,
        returnStream: <boolean>optional(() => swagger[`x-az-stream`]),
        struct: isStruct
    };
}

function createHeaders(project: IProject, swagger: any, location: string): IHeaders {
    const headers: IHeaders = { };
    for (const [name, def] of <[string, any]>Object.entries(swagger || {})) {
        let ignore = def[`x-az-demote-header`];
        if (ignore === undefined) {
            ignore = false;
        }
        headers[name] = {
            name,
            clientName: def[`x-ms-client-name`] || name,
            description: def.description,
            collectionPrefix: def[`x-ms-header-collection-prefix`],
            model: createType(project, `__header__`, def, `${location}['${name}']`),
            ignore
        };
    }
    return headers;
}

function createService(project: IProject): IService {
    const info = <IServiceInfo>required(() => project.cache.info);

    const service = {
        title: info.title,
        description: info.description,
        name: naming.type(required(() => project.swagger.info[`x-ms-code-generation-settings`][`client-name`])),
        namespace: naming.namespace(info.namespace),
        extensionsName: naming.type(info.extensionsName),
        groups: { },
        operations: { }
    };

    // Process the paths
    for (const [path, def] of <[string, any]>Object.entries(optional(() => project.swagger.paths, { }))) {
        addOperations(project, service, path, def, `project.swagger.paths['${path}']`);
    }
    for (const [path, def] of <[string, any]>Object.entries(optional(() => project.swagger[`x-ms-paths`], { }))) {
        addOperations(project, service, path, def, `project.swagger['x-ms-paths']['${path}']`);
    }
 
    return service;
}

// Create the service operations for a path and add them to the appropriate group on the service
function addOperations(project: IProject, service: IService, path: string, swagger: any, location: string): void {
    unsupported(() => swagger[`$ref`], location);
    unsupported(() => swagger[`x-ms-examples`], location);
    unsupported(() => swagger[`x-ms-long-running-operation`], location);
    unsupported(() => swagger[`x-ms-long-running-operation-options`], location);
    unsupported(() => swagger[`x-ms-request-id`], location);

    // Get any group parameters
    const groupParameters: IParameter[] = [];
    for (let i = 0; i < (swagger.parameters || []).length; i++) {
        const param = createParameter(project, swagger.parameters[i], `${location}.parameters['${i}']`);
        groupParameters.push(param);
    }

    // Create the full path
    const info = <IServiceInfo>required(() => project.cache.info);
    let fullPath: string = info.host ? info.host.template.template + path : path;
    
    // Process the individual operations
    for (const [method, def] of <[string, any]>Object.entries(swagger || { })) {
        if (method === `parameters`) { continue; }

        const name = `${method} ${fullPath}`;
        const nextLocation = `${location}.${method}`

        // Not yet implemented
        const op = createOperation(project, method, def, fullPath, groupParameters, nextLocation);
        
        // Add the operation to the right part of the service
        if (op.group) {
            let operations = service.groups[op.group];
            if (!operations) { operations = service.groups[op.group] = { }; }
            operations[name] = op;
        } else {
            service.operations[name] = op;
        }
    }
}

function createOperation(project: IProject, method: string, def: any, fullPath: string, groupParams: IParameter[], location: string): IOperation {
    // Report ignored parameters
    unsupported(() => def[`$ref`], location);
    unsupported(() => def.externalDocs, location);
    unsupported(() => def.deprecated, location);
    unsupported(() => def.security, location);
    
    // Process schemes
    const schemes = optional(() => def.schemes, [`https`]);
    if (schemes.length != 1 || schemes[0] != `https`) {
        throw `Only HTTPS is supported for swagger.schemes (in ${location})`;
    }
    
    // Proces produces + consumes
    const info = <IServiceInfo>required(() => project.cache.info);
    const serializationFormats: { [key: string]: (string | undefined) } = {
        'application/xml': 'xml',
        'application/octet-stream': 'stream'
    };

    let consumes = optional(() => def.consumes, [...info.consumes]);
    if (consumes.length != 1 || (consumes[0] != `application/xml` && consumes[0] != `application/octet-stream`)) {
        throw `Only application/xml and application/octet-stream are supported for swagger.consumes, not ${consumes.join(', ')} (in ${location})`;
    }
    let consumed = <string>serializationFormats[consumes[0]];
    
    let produces = optional(() => def.produces, [...info.produces]);
    if (produces.length != 1 || produces[0] != `application/xml` && produces[0] != `application/octet-stream`) {
        throw `Only application/xml and application/octet-stream are supported for swagger.produces, not ${produces.join(', ')} (in ${location})`;
    }
    let produced = <string>serializationFormats[produces[0]];
    
    // Get the name and group
    let operationId: string = def.operationId;
    let group: string | undefined = undefined;
    const parts = operationId.split(/_/g);
    switch (parts.length) {
        case 1: break;
        case 2:
            group = parts[0];
            operationId = parts[1];
            break;
        default:
            throw `Operation ID can only have two parts, not ${operationId} (in ${location})`;
    }

    // Create the parameters and pull them into generatable groups
    const path = template.parse(fullPath);
    const parameters = getOperationParameters(project, info, path, groupParams, def, location);
    const request = {
        all: parameters,
        arguments: parameters.filter(p => !isEnumType(p.model) || !p.model.constant),
        constants: parameters.filter(p => isEnumType(p.model) && p.model.constant),
        paths: parameters.filter(p => p.location === `path`),
        queries: parameters.filter(p => p.location === `query`),
        headers: parameters.filter(p => p.location === `header`),
        body: parameters.find(p => p.location === `body`)
    };
    if (request.body) {
        enableSerialization(request.body.model);
    }

    // Get the responses
    const responseName = <string>optional(() => def[`x-ms-response-client-name`], `${group ? group + ' ' : ''}${operationId}Result`);
    const responses: IResponses = {};
    for (const [code, op] of <[string, any]>Object.entries(def.responses || {})) {
        responses[code] = createResponse(project, code, responseName + ' ' + code, op, `${location}.responses['${code}']`);
    }
    const responseGroup = getOperationResponse(project, responses, responseName, location);
    
    // Create the operation
    return {
        name: operationId,
        group,
        method,
        path,
        summary: def.summary,
        description: def.description,
        // tags: def.tags || [],
        consumes: consumed,
        produces: produced,
        request,
        response: responseGroup,
        paging: def[`x-ms-pageable`]
    };
}

function getOperationParameters(project: IProject, info: IServiceInfo, path: template.ITemplate, group: IParameter[], swagger: any, location: string): IParameter[] {
    let parameters: IParameter[] = [];

    // Start with any host parameters
    if (info.host) {
        (<IParameter[]>Object.values(info.host.parameters))
            .forEach(addOrReplaceParameter);
    }

    // Add all the group parameters 
    group.forEach(addOrReplaceParameter);

    // TODO: If we disable path collapsing, fetch any global path params and add them
    // before the operation's parameters

    // Finally add this operation's parameters
    for (let i = 0; i < (swagger.parameters || []).length; i++) {
        addOrReplaceParameter(
            createParameter(project, swagger.parameters[i], `${location}.parameters['${i}']`));
    }

    // Group the parameters
    let groups = groupParameters(parameters);
    for (const [name, params] of Object.entries(groups)) {
        if (!params || params.length <= 1) { continue; }
        //todo(project, () => groups, `${location} :: ${name}`);
    }

    // Place all the optional parameters last
    parameters = [
        ...parameters.filter(p => p.required),
        ...parameters.filter(p => !p.required)
    ];

    // Inject the Azure.Core pipeline as the first parameter
    parameters.splice(0, 0, {
        name: 'pipeline',
        clientName: 'pipeline',
        required: true,
        location: 'path',
        skipUrlEncoding: true,
        model: <IObjectType>{
            name: 'HttpPipeline',
            type: 'object',
            external: true,
            namespace: 'Azure.Core.Pipeline',
            properties: { },
            xml: { },
        },
        trace: false
    });

    return parameters;

    // Replace any existing parameters or add them to the end of the list
    function addOrReplaceParameter(param: IParameter): void {
        const existing = parameters.findIndex(p => p.name === param.name && p.location === param.location);
        if (existing >= 0) {
            parameters[existing] = param;
        }
        else {
            parameters.push(param);
        }
    }

    // Create groups of parameters based on their parameterGroup
    function groupParameters(parameters: IParameter[]) {
        const groups: { [key: string]: IParameter[]|undefined } = { };
        parameters.forEach(p => {
            if (p.parameterGroup) {
                let nameGroup = groups[p.parameterGroup];
                if (!nameGroup) {
                    nameGroup = groups[p.parameterGroup] = [];
                }
                nameGroup.push(p);
            }
        });
        return groups;
    }
}

function getOperationResponse(project: IProject, responses: IResponses, defaultName: string, location: string) : IResponseGroup {
    let model: IModelType;
    const all = <IResponse[]>Object.values(responses);
    
    // Get other failure types
    const failures = all.filter(s => s.code[0] !== `2` && s.code !== `default`);
    for (const other of failures) {
        other.model = createResponseType(other, `${defaultName}Failure${other.code}`, `${location}['${other.code}']`);
    }

    // Get the default (which we interpret to mean failure...)
    const defaultResponse = responses['default'];
    if (defaultResponse) {
        defaultResponse.model = createResponseType(defaultResponse, `${defaultName}Failure`, `${location}['${defaultResponse.code}']`);

        // Make the default come last
        failures.push(defaultResponse);
    }

    // Possibly merge the successful responses together
    const successes = all.filter(s => s.code[0] === '2');
    switch (successes.length) {
        case 0:
            throw `No succesful responses (in ${location})`;
            break;
        case 1:
            model = successes[0].model = createResponseType(successes[0], defaultName, `${location}['${successes[0].code}']`);
            break;
        default:
            const mergedResponses = successes.reduce(mergeResponses);
            model = createResponseType(mergedResponses, defaultName, `${location}[<<merging ${successes.map(s => s.code).join(', ')}>>]`);
            successes.forEach(s => s.model = model);
            break;
    }
    model.returnStream = successes[0].returnStream;
    
    // Return all the responses
    return {
        model,
        successes,
        failures
    };
    
    function createResponseType(response: IResponse, defaultName: string, location: string): IModelType {
        const headers = <IHeader[]>Object.values(response.headers);
        const ignoredHeaders = headers.filter(h => h.ignore);
        const validHeaders = headers.filter(h => !h.ignore);

        if (headers.filter(h => !h.ignore).length === 0) {
            let model: IModelType;
            if (response.body) {
                // Use the body as the response type if there aren't any headers
                model = response.body;
                enableDeserialization(response.body);
            } else {
                // Return void if both the headers and body are empty
                model = project.cache.voidType;
            }
            ignoredHeaders.forEach(h => model.extendedHeaders.push(h));
            return model;
        }

        // Share response types based on their client name
        if (response.clientName) {
            const existing = project.cache.customTypes[response.clientName];
            if (existing) {
                ignoredHeaders.forEach(h => existing.extendedHeaders.push(h));
                return existing;
            }
        }

        // Create an object to wrap it
        const info = <IServiceInfo>required(() => project.cache.info);
        const model: IObjectType = {
            type: `object`,
            name: response.clientName || defaultName,
            namespace: `${info.namespace}.Models`,
            public: response.public,
            properties: { },
            serialize: false,
            deserialize: false,
            extendedHeaders: ignoredHeaders,
            struct: response.struct
        };
        registerCustomType(project, model);

        // Add the headers
        for (const header of validHeaders) {
            model.properties[header.name] = {
                name: header.name,
                clientName: header.clientName || header.name,
                required: true,
                readonly: true,
                xml: { },
                model: header.model
            };
        }

        // Add the body
        if (response.body) {
            enableDeserialization(response.body);
            model.properties[response.bodyClientName] = {
                name: response.bodyClientName,
                clientName: response.bodyClientName,
                required: true,
                readonly: true,
                xml: { },
                model: response.body
            };
        }

        return model;
    }

    function mergeResponses(a: IResponse, b: IResponse): IResponse {
        // Make sure the body types match (which only makes sense if they're both primitives)
        if (a.body &&
            b.body &&
            a.body.type !== 'array' &&
            (!isPrimitiveType(a.body) || !isPrimitiveType(b.body) || a.body.type !== b.body.type)) {
            throw `Cannot merge incompatible schemas for ${a.body.type} and ${b.body.type}`;
        }

        // Prefer everything on the first
        return {
            code: a.code,
            description: a.description || b.description,
            clientName: a.clientName || b.clientName,
            body: a.body || b.body,
            bodyClientName: a.bodyClientName || b.bodyClientName,
            headers: { ...b.headers, ...a.headers },
            public: a.public && b.public,
            struct: a.struct && b.struct
        };
    }
}
