// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// Check if a string is entirely uppercase
function isUpper(ch: string) {
    return ch !== ch.toLowerCase() && ch === ch.toUpperCase();
}

// Change the case of a name (either the first character or the whole thing
// for 2-letter-acronyms)
function changeCase(name: string, lower: boolean): string {
    if (name && name.length > 0) {
        if (name.length < 2 || (name.length == 2 && name.toLowerCase() !== 'to' && isUpper(name[0]) == isUpper(name[1]))) {
            name = lower ? name.toLowerCase() : name.toUpperCase();
        } else {
            name = (lower ? name[0].toLowerCase() : name[0].toUpperCase()) + name.slice(1);
        }
    }
    return name;
}

// Split a name apart and format it accordingly
function formatName(name: string | null, fn: ((t: string, i: number) => string), regex: RegExp = /[ _-]/g) {
    return (name || "")
        .split(regex)
        .filter(p => p && p.length > 0)
        .map(fn)
        .join('');
}

export function pascalCase(name: string | null, regex?: RegExp) {
    return formatName(name, p => changeCase(p, false), regex);
}

export function camelCase(name: string | null) {
    // Lowercase the first part
    return formatName(name, (p, i) => changeCase(p, i === 0));
}

export function variable(name: string) { return camelCase(name); }
export function property(name: string) { return pascalCase(name); }
export function field(name: string) { return '_' + variable(name); }
export function method(name: string, isAsync: boolean) { return pascalCase(name) + (isAsync ? 'Async' : '') }
export function parameter(name: string) { return variable(name); }
export function type(name: string) { return pascalCase(name); }
export function interfaceName(name: string) { return "I" + type(name); }
export function namespace(name: string) { return pascalCase(name); }
export function enumField(name: string) {
    // Convert acronyms to PascalCase
    // example: StorageAPI -> StorageApi, StorageAPIGenerator -> StorageApiGenerator
    if (name && name.length > 2) {
        let nameArray = name.split(/(?=[A-Z]|[0-9]+)/);
        for (let index = 1; index < nameArray.length; index++) {
            if (nameArray[index].length === 1 && nameArray[index - 1].length === 1 && !(/^[0-9]$/.test(nameArray[index - 1]))) {
                nameArray[index] = nameArray[index].toLowerCase();
            }
        }
        name = nameArray.join('');
    }

    return pascalCase(name);
}
export function file(name: string) { return `${pascalCase(name)}.cs`; }
