// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import { IModelType, isObjectType, isEnumType, isPrimitiveType, IService } from './models';
import * as naming from './naming';
import { isObject } from 'util';

export function getName(model: IModelType, readonly?: boolean, isParam?: boolean): string {
    if (isEnumType(model) && model.constant) {
        return `string`;
    } else if (isEnumType(model) || isObjectType(model)) {
        return `${naming.namespace(model.namespace)}.${naming.type(model.name)}`
    } else if (isPrimitiveType(model)) {
        switch (model.type.toLowerCase()) {
            case 'integer':
            case 'int32': return 'int';
            case 'int64': return 'long';
            case 'number': return 'double';
            case 'boolean': return 'bool';
            case 'byte': return 'byte[]'; // ?
            case 'binary':
            case 'file': return 'System.IO.Stream';
            case 'url': return 'System.Uri';
            case 'etag': return 'Azure.ETag';
            case 'date': return 'System.DateTime';
            case 'date-time':
            case 'date-time-8601':
            case 'date-time-rfc1123': return 'System.DateTimeOffset'; // ?
            case 'dictionary': return 'System.Collections.Generic.IDictionary<string, string>';
            case 'array':
                const elementType = model.itemType ? getName(model.itemType, readonly) : 'object';
                return isParam ? `System.Collections.Generic.IEnumerable<${elementType}>` :
                    readonly === false ? `System.Collections.Generic.IList<${elementType}>` :
                    `System.Collections.Generic.IEnumerable<${elementType}>`; // Consider switching back to something like IReadOnlyLIst
        }
    }
    return model.type;
}

export function isValueType(model: IModelType): boolean {
    if (isObjectType(model)) {
        switch (getName(model)) {
            case 'Azure.Core.Pipeline.HttpPipeline':
                return true;
            default:
                return false;
        }
    } else  if (isEnumType(model)) {
        return !model.constant;
    } else if (isPrimitiveType(model)) {
        switch (model.type.toLowerCase()) {
            case 'integer':
            case 'long':
            case 'int32':
            case 'int64':
            case 'number':
            case 'float':
            case 'double':
            case 'boolean':
            case 'etag':
            case 'date':
            case 'date-time':
            case 'date-time-8601':
            case 'date-time-rfc1123':
                return true;
        }
    }
    return false;
}

export function getDeclarationType(model: IModelType, required?: boolean, readonly?: boolean, isParam?: boolean): string {
    let name = getName(model, readonly, isParam);
    if (!required && isValueType(model)) {
        name += '?';
    }
    return name;
}

export function convertToString(expr: string, model: IModelType, service: IService, required?: boolean): string {
    if (model.type === 'string' || (isEnumType(model) && (model.modelAsString || model.constant))) {
        return expr;
    }

    if (isValueType(model) && !required) {
        expr += '.Value';
    }

    if (isEnumType(model) && model.customSerialization) {
        return `${naming.namespace(service.namespace)}.${naming.type(service.name)}.Serialization.ToString(${expr})`;
    }

    if (isPrimitiveType(model) && model.itemType) {
        let sep = `,`;
        switch (model.collectionFormat) {
            case `ssv`:
                sep = ` `;
                break;
            case `tsv`:
                sep = `\t`;
                break;
            case `pipes`:
                sep = `|`
                break;
            case `multi`:
                throw `collectionFormat multi is not implemented!`
        }
        const convertItems = convertToString(`item`, model.itemType, service, true);
        return `string.Join(${JSON.stringify(sep)}, System.Linq.Enumerable.Select(${expr}, item => ${convertItems}))`
    }

    switch (model.type.toLowerCase()) {
        case 'integer':
        case 'long':
        case 'int32':
        case 'int64':
        case 'number':
        case 'float':
        case 'double':
        case 'date':
            return `${expr}.ToString(System.Globalization.CultureInfo.InvariantCulture)`;
        case 'date-time':
            return `${expr}.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)`;
        case 'date-time-8601':
            return `${expr}.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ", System.Globalization.CultureInfo.InvariantCulture)`;
        case 'date-time-rfc1123':
            return `${expr}.ToString("R", System.Globalization.CultureInfo.InvariantCulture)`;
        case 'boolean':
            return `${expr}.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()`;
        case 'byte':
            return `System.Convert.ToBase64String(${expr})`;
        case 'url':
            return `${expr}.AbsoluteUri`;
        case 'dictionary':
        case 'binary': // stream
            throw `Cannot convert ${model.type} to string`;
        default: 
            return `${expr}.ToString()`;
    }
}

export function convertFromString(expr: string, model: IModelType, service: IService): string {
    if (model.type === 'string' || (isEnumType(model) && (model.modelAsString || model.constant))) {
        return expr;
    } else if (isEnumType(model)) {
        if (model.customSerialization) {
            return `${naming.namespace(service.namespace)}.${naming.type(service.name)}.Serialization.Parse${naming.pascalCase(model.name)}(${expr})`;
        } else {
            const enumName = getName(model);
            return `(${enumName})System.Enum.Parse(typeof(${enumName}), ${expr}, false)`;    
        }
    }

    switch (model.type.toLowerCase()) {
        case 'integer':
        case 'int32':
            return `int.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'long':
        case 'int64':
            return `long.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'float':
            return `float.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'number':
        case 'double':  
            return `double.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'boolean':
            return `bool.Parse(${expr})`;
        case 'date':
            return `System.DateTime.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'date-time':
        case 'date-time-8601':
        case 'date-time-rfc1123':
            return `System.DateTimeOffset.Parse(${expr}, System.Globalization.CultureInfo.InvariantCulture)`;
        case 'etag':
            return `new Azure.ETag(${expr})`;
        case 'url':
            return `new System.Uri(${expr})`;
        case 'byte':
            return `System.Convert.FromBase64String(${expr})`;
        case 'binary': // Stream
        case 'dictionary':
            throw `Cannot convert ${model.type} to string`;
        default: 
            return `${expr}`;
    }
}
