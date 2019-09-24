// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

export interface ITemplate {
    template: string,
    parts: ITemplatePart[]
}

export type ITemplatePart = ILiteralTemplatePart | IParameterTemplatePart;

export interface ILiteralTemplatePart {
    type: 'literal',
    value: string
}

export interface IParameterTemplatePart {
    type: 'parameter',
    name: string
}

export function parse(template: string): ITemplate {
    const parts = 
        <ITemplatePart[]>template
        .split(/({[^}]+})/g)
        .filter(p => p && p.length > 0)
        .map(p => p[0] === '{' && p[p.length - 1] === '}' ?
            { type: 'parameter', name: p.slice(1, -1) } :
            { type: 'literal', value: p });
    return {
        template: template,
        parts: parts
    };
}
