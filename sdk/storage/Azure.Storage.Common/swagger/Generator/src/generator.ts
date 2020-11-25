// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import {
    IProject,
    IServiceModel, IService, IServiceInfo,
    IModels, IModelType, IObjectType, IEnumType, IPrimitiveType, IXmlSettings,
    IProperties, IProperty,
    isObjectType, isEnumType, isPrimitiveType,
    IParameters, IParameter,
    IResponses, IResponse,
    IHeaders, IHeader,
    IOperationGroup, IOperation
} from './models';
import IndentWriter from './writer';
import * as naming from './naming';
import * as types from './types';

export async function generate(model: IServiceModel): Promise<void> {
    const w = new IndentWriter();

    model.info.license.header.split(/\n/g).forEach(
        line => w.line(`// ${line}`));
    w.line();

    w.line(`// This file was automatically generated.  Do not edit.`);
    w.line();

    w.line(`#pragma warning disable IDE0016 // Null check can be simplified`);
    w.line(`#pragma warning disable IDE0017 // Variable declaration can be inlined`);
    w.line(`#pragma warning disable IDE0018 // Object initialization can be simplified`);
    w.line(`#pragma warning disable SA1402  // File may only contain a single type`);
    w.line();

    generateService(w, model);
    generateModels(w, model);

    await model.context.writeFile(naming.file(model.service.name), w.toString());
}

function generateService(w: IndentWriter, model: IServiceModel): void {
    const service = model.service;
    w.line(`#region Service`);
    w.line(`namespace ${service.namespace}`);
    w.scope(`{`, `}`, () => {
        w.line(`/// <summary>`);
        w.line(`/// ${service.title}`);
        if (service.description) {
            w.line(`/// ${service.description}`);
        }
        w.line(`/// </summary>`);
        w.line(`${model.info.public ? 'public' : 'internal'} static partial class ${service.name}`);
        w.scope('{', '}', () => {
            const fencepost = IndentWriter.createFenceposter();
            if (Object.keys(service.operations).length > 0) {
                if (fencepost()) { w.line(); }
                generateOperationGroup(w, model, `service operations`, service.operations);
            }
            for (const [name, group] of <[string, IOperationGroup][]>Object.entries(service.groups)) {
                if (fencepost()) { w.line(); }
                generateOperationGroup(w, model, name, group);
            }
        });

        // w.line();
        // w.line(`#region class ${service.extensionsName}`);
        // w.line(`/// <summary>`);
        // w.line(`/// ${service.name} response extensions`);
        // w.line(`/// </summary>`);
        // w.line(`public static partial class ${service.extensionsName}`);
        // w.scope('{', '}', () => {
        //     const fencepost = IndentWriter.createFenceposter();

        //     const responses: IModelType[] = [];
        //     [service.operations, ...Object.values(service.groups)].map(g => Object.values(g).forEach(op => responses.push(op.response.model)));
        //     for (const responseType of responses.filter((t, i) => responses.indexOf(t) === i)) {
        //         let unique = responseType.extendedHeaders.reduce((all: IHeader[], h) => all.some(v => v.name === h.name) ? all : [...all, h], []);
        //         for (const header of unique) {
        //             if (header.name === `x-ms-request-id` || header.name === `Date`) {
        //                 // Ignore headers promoted to Response...  and version.
        //                 continue;
        //             }
        //             const responseTypeName = responseType.type === 'void' ?
        //                 'Azure.Response' : 
        //                 `Azure.Response<${types.getName(responseType)}>`;
        //             if (fencepost()) { w.line(); }
        //             w.line(`/// <summary>`)
        //             w.line(`/// ${header.description || 'Try to get the ' + header.name + ' header.'}`);
        //             w.line(`/// </summary>`)
        //             w.write(`public static ${types.getDeclarationType(header.model, false)} ${naming.method('Get ' + header.clientName, false)}(this ${responseTypeName} response)`);
        //             w.scope(() => {
        //                 const headerAccess = responseType.type === `void` ? ``: `.Raw`;
        //                 w.write(`=> response${headerAccess}.Headers.TryGetValue("${header.name}", out string header) ?`);
        //                 w.scope(() => {  
        //                     w.line(`${types.convertFromString('header', header.model, service)} :`)
        //                     w.line(`default;`);
        //                 });
        //             });
        //         }
        //     }
        // });
        // w.line(`#endregion class ${service.extensionsName}`);
    });
    w.line(`#endregion Service`);
    w.line();
}

function generateOperationGroup(w: IndentWriter, model: IServiceModel, name: string, group: IOperationGroup) {
    w.line(`#region ${name} operations`);
    w.line(`/// <summary>`);
    w.line(`/// ${name} operations for ${model.info.title}`);
    w.line(`/// </summary>`);
    w.line(`public static partial class ${naming.type(name)}`);
    w.scope('{', '}', () => {
        const fencepost = IndentWriter.createFenceposter();
        for (const [name, operation] of <[string, IOperation][]>Object.entries(group)) {
            if (fencepost()) { w.line(); }
            generateOperation(w, model, group, name, operation);
        }
    });
    w.line(`#endregion ${name} operations`);
}

function generateOperation(w: IndentWriter, serviceModel: IServiceModel, group: IOperationGroup, name: string, operation: IOperation) {
    const service = serviceModel.service;
    const methodName = naming.method(operation.name, true);
    const regionName = (operation.group ? naming.type(operation.group) + '.' : '') + methodName;
    const pipelineName = "pipeline";
    const cancellationName = "cancellationToken";
    const bodyName = "_body";
    const requestName = "_request";
    const messageName = "_message";
    const headerName = "_header";
    const xmlName = "_xml";
    const textName = "_text";
    const valueName = "_value";
    const pairName = `_headerPair`;
    let responseName = "_response";
    const scopeName = "_scope";
    const clientDiagnostics = "clientDiagnostics";
    const operationName = "operationName";
    const result = operation.response.model;
    const sync = serviceModel.info.sync;

    const returnType = result.type === 'void' ? 'Azure.Response' : `Azure.Response<${types.getName(result)}>`;
    const returnTypeArguments = [];

    returnTypeArguments.push(returnType);

    if (result.returnStream) {
        returnTypeArguments.push("System.IO.Stream");
    }

    const sendMethodReturnType = returnTypeArguments.length == 1 ? returnTypeArguments[0] : `(${returnTypeArguments.join(", ")})`;

    w.line(`#region ${regionName}`);

    // #region Top level method
    w.line(`/// <summary>`);
    w.line(`/// ${operation.description || regionName}`);
    w.line(`/// </summary>`);
    for (const arg of operation.request.arguments) {
        const desc = arg.description || arg.model.description;
        if (desc) {
            w.line(`/// <param name="${naming.parameter(arg.clientName)}">${desc}</param>`);
        }
    }
    if (sync) {
        w.line(`/// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>`);
    }
    w.line(`/// <param name="${operationName}">Operation name.</param>`);
    w.line(`/// <param name="${cancellationName}">Cancellation token.</param>`);
    w.line(`/// <returns>${operation.response.model.description || returnType.replace(/</g, '{').replace(/>/g, '}')}</returns>`);
    w.write(`public static async System.Threading.Tasks.ValueTask<${sendMethodReturnType}> ${methodName}(`);
    w.scope(() => {
        const separateParams = IndentWriter.createFenceposter();
        for (const arg of operation.request.arguments) {
            if (separateParams()) { w.line(`,`); }
            w.write(`${types.getDeclarationType(arg.model, arg.required, false, true)} ${naming.parameter(arg.clientName)}`);
            if (!arg.required) { w.write(` = default`); }
        }
        if (sync) {
            if (separateParams()) { w.line(`,`); }
            w.write(`bool async = true`);
        }
        if (separateParams()) { w.line(`,`); }
        w.write(`string ${operationName} = "${operation.group ? operation.group + "Client" : naming.type(service.name)}.${operation.name}"`);
        w.line(`,`);
        w.write(`System.Threading.CancellationToken ${cancellationName} = default`);
        w.write(')')
    });
    w.scope('{', '}', () => {
        w.line(`Azure.Core.Pipeline.DiagnosticScope ${scopeName} = ${clientDiagnostics}.CreateScope(${operationName});`)
        w.line(`try`);
        w.scope('{', '}', () => {
            for (const arg of operation.request.arguments) {
                if (arg.trace) {
                    w.line(`${scopeName}.AddAttribute("${naming.parameter(arg.name)}", ${naming.parameter(arg.clientName)});`);
                }
            }
            w.line(`${scopeName}.Start();`);
            w.write(`using (Azure.Core.HttpMessage ${messageName} = ${methodName}_CreateMessage(`);
            w.scope(() => {
                const separateParams = IndentWriter.createFenceposter();
                for (const arg of operation.request.arguments.slice(1)) { // Skip ClientDiagnostics
                    if (separateParams()) { w.line(`,`); }
                    w.write(`${naming.parameter(arg.clientName)}`);
                }
                w.write(`))`);
            });
            w.scope('{', '}', () => {
                if (result.returnStream) {
                    w.line(`// Avoid buffering if stream is going to be returned to the caller`);
                    w.line(`${messageName}.BufferResponse = false;`);
                }

                const asyncCall = `await ${pipelineName}.SendAsync(${messageName}, ${cancellationName}).ConfigureAwait(false)`;
                if (sync) {
                    w.line(`if (async)`);
                    w.scope('{', '}', () => {
                        w.line(`// Send the request asynchronously if we're being called via an async path`);
                        w.line(`${asyncCall};`);
                    });
                    w.line(`else`);
                    w.scope('{', '}', () => {
                        w.line(`// Send the request synchronously through the API that blocks if we're being called via a sync path`);
                        w.line(`// (this is safe because the Task will complete before the user can call Wait)`);
                        w.line(`${pipelineName}.Send(${messageName}, ${cancellationName});`);
                    });
                } else {
                    w.line(`${asyncCall};`);
                }

                w.line(`Azure.Response ${responseName} = ${messageName}.Response;`);
                w.line(`${cancellationName}.ThrowIfCancellationRequested();`);

                const createResponse = `${methodName}_CreateResponse(${clientDiagnostics}, ${responseName})`;
                if (result.returnStream) {
                    w.line(`return (${createResponse}, ${messageName}.ExtractResponseContent());`);
                }
                else {
                    w.line(`return ${createResponse};`);
                }
            });
        });
        w.line(`catch (System.Exception ex)`);
        w.scope('{', '}', () => {
            w.line(`${scopeName}.Failed(ex);`);
            w.line(`throw;`);
        });
        w.line(`finally`);
        w.scope('{', '}', () => {
            w.line(`${scopeName}.Dispose();`);
        });
    });
    w.line();

    // #endregion Top level method

    // #region Create Request
    w.line(`/// <summary>`);
    w.line(`/// Create the ${regionName} request.`);
    w.line(`/// </summary>`);
    for (const arg of operation.request.arguments.slice(1)) { // Skip ClientDiagnostics
        const desc = arg.description || arg.model.description;
        if (desc) {
            w.line(`/// <param name="${naming.parameter(arg.clientName)}">${desc}</param>`);
        }
    }
    w.line(`/// <returns>The ${regionName} Message.</returns>`);
    w.write(`internal static Azure.Core.HttpMessage ${methodName}_CreateMessage(`);
    w.scope(() => {
        const separateParams = IndentWriter.createFenceposter();
        for (const arg of operation.request.arguments.slice(1)) { // Skip ClientDiagnostics
            if (separateParams()) { w.line(`,`); }
            w.write(`${types.getDeclarationType(arg.model, arg.required, false, true)} ${naming.parameter(arg.clientName)}`);
            if (!arg.required) { w.write(` = default`); }
        }
        w.write(')')
    });
    w.scope('{', '}', () => {
        // Get the value of a parameter (and inline constants as literals)
        const useParameter = (param: IParameter, use: ((value: string) => void)) => {
            const constant = isEnumType(param.model) && param.model.constant;
            const nullable = !constant && !param.required;
            const skipValue = isEnumType(param.model) ? param.model.skipValue : undefined;
            const name = naming.variable(param.clientName);
            if (nullable) {
                w.write(`if (${name} != null) {`);
            } else if (skipValue) {
                const value = (<IEnumType>param.model).values.find(v => v.name == skipValue || v.value == skipValue);
                if (!value) { throw `Cannot find a value for x-az-enum-skip-value ${skipValue} in ${types.getName(param.model)}`; }
                const skipValueName = naming.enumField(value.name || value.value);
                w.write(`if (${name} != ${types.getName(param.model)}.${skipValueName}) {`);
            }
            const indent = !!(nullable || skipValue);
            if (constant) {
                use(`"${((<IEnumType>param.model).values[0].value || '').toString()}"`);
            } else if (param.model.type === 'dictionary') {
                w.scope(() => {
                    w.line(`foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in ${naming.parameter(param.clientName)})`);
                    w.scope('{', '}', () => {
                        use("_pair");
                    });
                });
            } else if (param.location === `header` && isPrimitiveType(param.model) && param.model.collectionFormat === `csv`) {
                w.scope(() => {
                    w.line(`foreach (string _item in ${naming.parameter(param.clientName)})`);
                    w.scope('{', '}', () => {
                        use("_item");
                    });
                });
            } else {
                if (param.model.type === `boolean`) {
                    w.line();
                    w.line(`#pragma warning disable CA1308 // Normalize strings to uppercase`);
                } else if (indent) { w.write(` `); }
                use(types.convertToString(name, param.model, service, param.required));
                if (param.model.type === `boolean`) {
                    w.line();
                    w.line(`#pragma warning restore CA1308 // Normalize strings to uppercase`);
                } else if (indent) { w.write(` `); }
            }
            if (indent) { w.write(`}`); }
            w.line();
        };

        if (operation.request.arguments.length > 0) {
            w.line(`// Validation`);
            for (const arg of operation.request.arguments.slice(1)) { // Skip ClientDiagnostics
                generateValidation(w, operation, arg);
            }
            w.line();
        }

        w.line(`// Create the request`);
        w.line(`Azure.Core.HttpMessage ${messageName} = ${pipelineName}.CreateMessage();`);
        w.line(`Azure.Core.Request ${requestName} = ${messageName}.Request;`);
        w.line();

        w.line(`// Set the endpoint`);
        const httpMethod = naming.pascalCase(operation.method);
        w.line(`${requestName}.Method = Azure.Core.RequestMethod.${httpMethod};`);
        const uri = naming.parameter(operation.request.all[2].clientName);
        w.line(`${requestName}.Uri.Reset(${uri});`);
        if (operation.request.queries.length > 0) {
            for (const query of operation.request.queries) {
                const constant = isEnumType(query.model) && query.model.constant;
                useParameter(query, value => {
                    w.write(`${requestName}.Uri.AppendQuery("${query.name}", ${value}`);
                    if (query.skipUrlEncoding || constant) {
                        w.write(`, escapeValue: false`);
                    }

                    w.write(`);`);
                });
            }
        }
        if (operation.request.paths.length > 3) { // We're always ignoring url + pipeline + client diagnostics
            w.line(`// TODO: Ignoring request path vars: ${operation.request.paths.map(p => p.name).join(', ')}`)
        }
        w.line();

        if (operation.request.headers.length > 0) {
            w.line(`// Add request headers`);
            for (const header of operation.request.headers) {
                useParameter(header, value => {
                    let name = `"${header.name}"`;
                    if (isPrimitiveType(header.model) && header.model.type === `dictionary`) {
                        name = `"${header.model.dictionaryPrefix || 'x-ms-meta-'}" + ${value}.Key`;
                        value = `${value}.Value`;
                    }
                    if (isEnumType(header.model) && header.model.modelAsString) {
                        value = `${value}.ToString()`
                    }
                    w.write(`${requestName}.Headers.SetValue(${name}, ${value});`);
                });
            }
            w.line();
        }

        // Serialize
        if (operation.request.body) {
            w.line(`// Create the body`);
            const bodyType = operation.request.body.model;
            const bodyParamName = naming.parameter(operation.request.body.clientName);

            // Guard serialization if the body is optional
            const optionalBody =
                // Ignore anything required
                !operation.request.body.required &&
                // Ignore sequence types where we want an enclosing XML element for empty content
                !(operation.consumes === `xml` && isPrimitiveType(bodyType) && bodyType.itemType && isObjectType(bodyType.itemType) && bodyType.itemType.serialize);
            if (optionalBody) {
                w.line(`if (${bodyParamName} != null)`);
                w.pushScope(`{`);
            }

            if (bodyType.type === `string`) {
                // Temporary Hack: Serialize string content as JSON
                w.line(`string ${textName} = ${naming.parameter(operation.request.body.clientName)};`)
                w.line(`${requestName}.Headers.SetValue("Content-Type", "application/json");`);
                w.line(`${requestName}.Headers.SetValue("Content-Length", ${textName}.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));`);
                w.line(`${requestName}.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(${textName}));`);
            } else if (operation.consumes === `stream` || bodyType.type === `file`) {
                // Serialize a file
                w.line(`${requestName}.Content = Azure.Core.RequestContent.Create(${naming.parameter(operation.request.body.clientName)});`);
            } else if (operation.consumes === `xml`) {
                // Serialize XML
                if (isObjectType(bodyType)) {
                    if (bodyType.serialize) {
                        let elementName = (bodyType.xml ? bodyType.xml.name : undefined) || operation.request.body.name;
                        w.line(`System.Xml.Linq.XElement ${bodyName} = ${types.getName(operation.request.body.model)}.ToXml(${naming.parameter(operation.request.body.clientName)}, "${elementName}", "");`);
                    } else {
                        w.line(`// TODO:  ${bodyType.name} lacks a ToXml method!`);
                    }
                } else if (isPrimitiveType(bodyType) && bodyType.itemType) {
                    if (isObjectType(bodyType.itemType) && bodyType.itemType.serialize) {
                        // We're just going to one off this here for now because there's only
                        // one case of serializing raw arrays
                        const { xname } = getXmlShape(bodyType.itemType.name, bodyType.xml);
                        w.line(`System.Xml.Linq.XElement ${bodyName} = new System.Xml.Linq.XElement(${xname});`);

                        const itemType = bodyType.itemType;
                        w.line(`if (${bodyParamName} != null)`);
                        w.scope(`{`, `}`, () => {
                            w.line(`foreach (${types.getName(itemType)} _child in ${bodyParamName})`);
                            w.scope('{', '}', () => {
                                w.line(`${bodyName}.Add(${types.getName(itemType)}.ToXml(_child));`);
                            });
                        });
                    } else {
                        let itemName =
                            isObjectType(bodyType.itemType) || isEnumType(bodyType.itemType) ? bodyType.itemType.name :
                                isPrimitiveType(bodyType.itemType) ? bodyType.itemType.type :
                                    "unexpected type";
                        w.line(`// TODO: Serialize array of ${itemName}`);
                    }
                } else {
                    w.line(`System.Xml.Linq.XElement ${bodyName} = null;`);
                }

                w.line(`string ${textName} = ${bodyName}.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);`);
                w.line(`${requestName}.Headers.SetValue("Content-Type", "application/xml");`);
                w.line(`${requestName}.Headers.SetValue("Content-Length", ${textName}.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));`);
                w.line(`${requestName}.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(${textName}));`);
            } else {
                throw `Serialization format ${operation.produces} not supported (in ${name})`;
            }
            if (optionalBody) {
                // Finish check for optional body content
                w.popScope(`}`);
            }
            w.line();
        }

        w.line(`return ${messageName};`);
    });
    w.line();
    // #endregion Create Request

    // #region Create Response
    responseName = `response`;
    w.line(`/// <summary>`);
    w.line(`/// Create the ${regionName} response or throw a failure exception.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>`);
    w.line(`/// <param name="response">The raw Response.</param>`);
    w.line(`/// <returns>The ${regionName} ${returnType.replace(/</g, '{').replace(/>/g, '}')}.</returns>`);
    w.write(`internal static ${returnType} ${methodName}_CreateResponse(`);
    w.scope(() => {
        w.line(`Azure.Core.Pipeline.ClientDiagnostics ${clientDiagnostics},`);
        w.write(`Azure.Response ${responseName})`);
    });
    w.scope(`{`, `}`, () => {
        w.line(`// Process the response`);
        w.line(`switch (${responseName}.Status)`);
        w.scope('{', '}', () => {
            for (const response of operation.response.successes) {
                if (!response.model) { throw `Cannot deserialize without a response model (in ${name})`; }
                const model = response.model;

                w.line(`case ${response.code}:`);
                w.scope('{', '}', () => {
                    if (result.type === 'void') {
                        w.line(`return ${responseName};`);
                    } else {
                        processResponse(response);

                        w.line(`// Create the response`);
                        w.line(`return Response.FromValue(${valueName}, ${responseName});`);
                    }
                });
            }

            // We don't throw for 304s on read
            // (this may be too ambitious for all services, but works for
            // Storage so I'm not adding x-az- vendor extensions right now)
            const isReadOperation =
                operation.method.toLowerCase() == `get` ||
                operation.method.toLowerCase() == `head`;
            if (isReadOperation) {
                w.line(`case 304:`);
                w.scope('{', '}', () => {
                    if (result.type === `void`) {
                        // Just return the response if there's no model
                        w.line(`return ${responseName};`);
                    } else {
                        // Return an exploding Response if there's a model type
                        // (NoBodyResponse is shared source)
                        w.line(`return new Azure.NoBodyResponse<${types.getName(result)}>(${responseName});`);
                    }
                });
            }

            for (const response of operation.response.failures) {
                if (response.code === `304` && isReadOperation) {
                    // Ignore 304s handled above
                    continue;
                } else if (response.code === `default`) {
                    w.line(`default:`);
                } else {
                    w.line(`case ${response.code}:`);
                }
                w.scope('{', '}', () => {
                    processResponse(response);
                    if (response.exception) {
                        // If we're using x-ms-create-exception we'll pass the response to
                        // an unimplemented method on the partial class
                        w.line(`throw ${valueName}.CreateException(${clientDiagnostics}, ${responseName});`);
                    } else {
                        w.line(`throw new Azure.RequestFailedException(${responseName});`);
                    }
                });
            }
        });
    });

    function processResponse(response: IResponse) {
        if (!response.model) { throw `Cannot deserialize without a response model (in ${name})`; }
        const model = response.model;

        // Deserialize
        if (!response.struct) w.line(`// Create the result`);
        if (response.body) {
            const responseType = response.body;
            if (responseType.type === `string`) {
                const streamName = "_streamReader";
                w.line(`${types.getName(model)} ${valueName};`);
                w.line(`using (System.IO.StreamReader ${streamName} = new System.IO.StreamReader(${responseName}.ContentStream))`)
                w.scope('{', '}', () => {
                    w.line(`${valueName} = ${streamName}.ReadToEnd();`);
                });
            } else if (operation.produces === `stream` || responseType.type === `file`) {
                // Deserialize a file
                w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
                w.line(`${valueName}.${naming.property(response.bodyClientName)} = ${responseName}.ContentStream; // You should manually wrap with RetriableStream!`);
            } else if (operation.produces === `xml`) {
                // Deserialize XML
                w.line(`System.Xml.Linq.XDocument ${xmlName} = System.Xml.Linq.XDocument.Load(${responseName}.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);`);
                if (isObjectType(model) && model.deserialize) {
                    w.line(`${types.getName(model)} ${valueName} = ${types.getName(model)}.FromXml(${xmlName}.Root);`);
                } else {
                    if (model.type === `array` &&
                        isPrimitiveType(responseType) &&
                        responseType.itemType &&
                        isObjectType(responseType.itemType) &&
                        responseType.itemType.deserialize) {
                        // Get the target
                        const itemType = responseType.itemType;
                        const { xname, wrapped } = getXmlShape(itemType.name, responseType.xml);
                        let target = xmlName;
                        if (wrapped) { target = `${target}.Element(${xname})`; }
                        const { xname: childName } = getXmlShape(itemType.name, itemType.xml);
                        target = `${target}.Elements(${childName})`;
                        w.write(`${types.getName(model)} ${valueName} =`);
                        w.scope(() => {
                            w.scope('System.Linq.Enumerable.ToList(', '', () => {
                                w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                                    w.line(`${target},`);
                                    w.write(`${types.getName(itemType)}.FromXml));`);
                                });
                            });
                        });
                    } else if (model.type === `object`) {
                        w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
                        if (isObjectType(responseType)) {
                            w.line(`${valueName}.${naming.property(response.bodyClientName)} = ${types.getName(responseType)}.FromXml(${xmlName}.Root);`);
                        } else if (isPrimitiveType(responseType) &&
                            responseType.itemType &&
                            isObjectType(responseType.itemType) &&
                            responseType.itemType.deserialize) {

                            // Get the target
                            const itemType = responseType.itemType;
                            const { xname, wrapped } = getXmlShape(itemType.name, responseType.xml);
                            let target = xmlName;
                            if (wrapped) { target = `${target}.Element(${xname})`; }
                            const { xname: childName } = getXmlShape(itemType.name, itemType.xml);
                            target = `${target}.Elements(${childName})`;
                            w.write(`${valueName}.${naming.property(response.bodyClientName)} =`);
                            w.scope(() => {
                                w.scope('System.Linq.Enumerable.ToList(', '', () => {
                                    w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                                        w.line(`${target},`);
                                        w.write(`${types.getName(itemType)}.FromXml));`);
                                    });
                                });
                            });
                        }
                    } else {
                        w.line(`// TODO: Deserialize unexpected type`);
                    }
                }
            } else {
                throw `Serialization format ${operation.produces} not supported (in ${name})`;
            }
        } else if (!response.struct) {
            w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
        }
        w.line();

        const headers = <IHeader[]>Object.values(response.headers).filter(h => !(<IHeader>h).ignore);
        if (headers.length > 0) {
            w.line(`// Get response headers`);
            w.line(`string ${headerName};`);
            if (response.struct) {
                for (const header of headers) {
                    w.line(`${types.getDeclarationType(header.model, true, false, true)} ${naming.parameter(header.clientName)} = default;`);
                }
            }
            for (const header of headers) {
                if (isPrimitiveType(header.model) && header.model.type === 'dictionary') {
                    const prefix = header.model.dictionaryPrefix || `x-ms-meta-`;
                    w.line(`${valueName}.${naming.pascalCase(header.clientName)} = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                    w.line(`foreach (Azure.Core.HttpHeader ${pairName} in ${responseName}.Headers)`);
                    w.scope(`{`, `}`, () => {
                        w.line(`if (${pairName}.Name.StartsWith("${prefix}", System.StringComparison.InvariantCulture))`);
                        w.scope(`{`, `}`, () => {
                            w.line(`${valueName}.${naming.pascalCase(header.clientName)}[${pairName}.Name.Substring(${prefix.length})] = ${pairName}.Value;`);
                        });
                    });
                } else {
                    w.line(`if (${responseName}.Headers.TryGetValue("${header.name}", out ${headerName}))`);
                    w.scope('{', '}', () => {
                        if (response.struct) {
                            w.write(`${naming.parameter(header.clientName)} = `);
                        } else {
                            w.write(`${valueName}.${naming.pascalCase(header.clientName)} = `);
                        }
                        if (isPrimitiveType(header.model) && header.model.collectionFormat === `csv`) {
                            if (!header.model.itemType || header.model.itemType.type !== `string`) {
                                throw `collectionFormat csv is only supported for strings, at the moment`;
                            }
                            w.write(`(${headerName} ?? "").Split(',')`);
                        } else {
                            w.write(`${types.convertFromString(headerName, header.model, service)}`);
                        }
                        w.line(`;`);
                    });
                }
            }
            if (response.struct) {
                w.line();
                const separator = IndentWriter.createFenceposter();
                w.write(`${types.getName(model)} ${valueName} = new ${types.getName(model)}(`);
                for (const header of headers) {
                    if (separator()) { w.write(`, `); }
                    w.write(`${naming.parameter(header.clientName)}`);
                }
                w.write(`);`);
                w.line();
            }
            w.line();
        }
    }
    // #endregion Create Response

    w.line(`#endregion ${regionName}`);
}

function generateValidation(w: IndentWriter, operation: IOperation, parameter: IParameter) {
    const name = naming.parameter(parameter.clientName);
    // Null checks
    if (parameter.required && !types.isValueType(parameter.model)) {
        w.line(`if (${name} == null)`);
        w.scope('{', '}', () => {
            w.line(`throw new System.ArgumentNullException(nameof(${name}));`);
        });
    }

    // We can get more thorough with primitives
    if (isPrimitiveType(parameter.model)) {
        // TODO: Min/length/...
    }
}

function generateModels(w: IndentWriter, model: IServiceModel): void {
    w.line(`#region Models`);
    const fencepost = IndentWriter.createFenceposter();
    const types = <[string, IModelType][]>Object.entries(model.models);
    types.sort((a, b) =>
        a[0] < b[0] ? -1 :
            a[0] > b[0] ? 1 :
                0);
    for (const [name, def] of types) {
        if (fencepost()) { w.line(); }
        if (isEnumType(def) && !def.modelAsString) { generateEnum(w, model, def); }
        else if (isEnumType(def) && def.modelAsString) { generateEnumStrings(w, model, def); }
        else if (isObjectType(def)) { generateObject(w, model, def); }
    }
    w.line(`#endregion Models`);
    w.line();
}

function generateEnum(w: IndentWriter, model: IServiceModel, type: IEnumType) {
    // Generate the enum
    const regionName = `enum ${naming.type(type.name)}`;
    w.line(`#region ${regionName}`);
    if (!type.external) {
        w.line(`namespace ${naming.namespace(type.namespace)}`);
        w.scope('{', '}', () => {
            w.line(`/// <summary>`)
            w.line(`/// ${type.description || type.name + ' values'}`);
            w.line(`/// </summary>`)
            const notReallyPlural = naming.type(type.name).endsWith('Status');
            if (notReallyPlural) { w.line(`#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names`); }
            w.line(`${type.public ? 'public' : 'internal'} enum ${naming.type(type.name)}`);
            if (notReallyPlural) { w.line(`#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names`); }
            const separator = IndentWriter.createFenceposter();
            w.scope(`{`, `}`, () => {
                for (const value of type.values) {
                    if (separator()) { w.line(','); w.line(); }
                    w.line(`/// <summary>`);
                    w.line(`/// ${value.description || value.value || value.name}`);
                    w.line(`/// </summary>`);
                    w.write(naming.enumField(value.name || value.value));
                }
            });
        });
    }

    // Generate the custom serializers if needed
    if (type.customSerialization) {
        const service = model.service;
        w.line();
        w.line(`namespace ${naming.namespace(service.namespace)}`);
        w.scope('{', '}', () => {
            w.line(`internal static partial class ${naming.type(service.name)}`);
            w.scope('{', '}', () => {
                w.line(`public static partial class Serialization`);
                w.scope('{', '}', () => {
                    w.line(`public static string ToString(${types.getName(type)} value)`);
                    w.scope('{', '}', () => {
                        w.line(`return value switch`);
                        w.scope('{', '};', () => {
                            // Write the values
                            for (const value of type.values) {
                                w.write(`${types.getName(type)}.${naming.enumField(value.name || value.value)} =>`);
                                w.line(` ${value.value == null ? 'null' : '"' + value.value + '"'},`);
                            }
                            // Throw for random values
                            w.line(`_ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown ${types.getName(type)} value.")`);
                        });
                    });
                    w.line();

                    w.line(`public static ${types.getName(type)} Parse${naming.pascalCase(type.name)}(string value)`);
                    w.scope('{', '}', () => {
                        w.line(`return value switch`);
                        w.scope('{', '};', () => {
                            // Write the values
                            for (const value of type.values) {
                                w.write(`${value.value == null ? 'null' : '"' + value.value + '"'} => `);
                                w.line(`${types.getName(type)}.${naming.enumField(value.name || value.value)},`);
                            }
                            // Throw for random values
                            w.line(`_ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown ${types.getName(type)} value.")`);
                        });
                    });
                });
            });
        });
    }

    w.line(`#endregion ${regionName}`);
}

function generateEnumStrings(w: IndentWriter, model: IServiceModel, type: IEnumType) {
    if (type.external) { return; }

    const regionName = `enum strings ${naming.type(type.name)}`;
    w.line(`#region ${regionName}`);
    w.line(`namespace ${naming.namespace(type.namespace)}`);
    w.scope('{', '}', () => {
        w.line(`/// <summary>`);
        w.line(`/// ${type.description || type.name + ' values'}`);
        w.line(`/// </summary>`);
        const enumName = naming.type(type.name);
        const enumFullName = types.getName(type, false, false);
        w.line(`${type.public ? 'public' : 'internal'} readonly struct ${enumName} : System.IEquatable<${enumName}>`);
        w.scope(`{`, `}`, () => {
            w.line(`/// <summary>`);
            w.line(`/// The ${enumName} value.`);
            w.line(`/// </summary>`);
            w.line(`private readonly string _value;`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Initializes a new instance of the <see cref="${enumName}"/> structure.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="value">The string value of the instance.</param>`);
            w.line(`public ${enumName}(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }`);
            w.line(``);
            // Dump out the values
            const separator = IndentWriter.createFenceposter();
            for (const value of type.values) {
                if (separator()) { w.line(); }
                const name = naming.property((value.name || value.value) || '').toString();
                const text = (value.value || '').toString();
                w.line(`/// <summary>`);
                w.line(`/// ${value.description || text}`);
                w.line(`/// </summary>`);
                w.line(`public static ${enumFullName} ${name} { get; } = new ${enumName}(@"${text}");`)
            }
            if (separator()) { w.line(); }

            // Dump out the infrastructure
            w.line(`/// <summary>`);
            w.line(`/// Determines if two <see cref="${enumName}"/> values are the same.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="left">The first <see cref="${enumName}"/> to compare.</param>`);
            w.line(`/// <param name="right">The second <see cref="${enumName}"/> to compare.</param>`);
            w.line(`/// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>`);
            w.line(`public static bool operator ==(${enumFullName} left, ${enumFullName} right) => left.Equals(right);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Determines if two <see cref="${enumName}"/> values are different.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="left">The first <see cref="${enumName}"/> to compare.</param>`);
            w.line(`/// <param name="right">The second <see cref="${enumName}"/> to compare.</param>`);
            w.line(`/// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>`);
            w.line(`public static bool operator !=(${enumFullName} left, ${enumFullName} right) => !left.Equals(right);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Converts a string to a <see cref="${enumName}"/>.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="value">The string value to convert.</param>`);
            w.line(`/// <returns>The ${enumName} value.</returns>`);
            w.line(`public static implicit operator ${enumName}(string value) => new ${enumFullName}(value);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two <see cref="${enumName}"/> instances are equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="obj">The instance to compare to.</param>`);
            w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
            w.line(`[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]`);
            w.line(`public override bool Equals(object obj) => obj is ${enumFullName} other && Equals(other);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two <see cref="${enumName}"/> instances are equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="other">The instance to compare to.</param>`);
            w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
            w.line(`public bool Equals(${enumFullName} other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);`)
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Get a hash code for the <see cref="${enumName}"/>.`);
            w.line(`/// </summary>`);
            w.line(`/// <returns>Hash code for the ${enumName}.</returns>`);
            w.line(`[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]`);
            w.line(`public override int GetHashCode() => _value?.GetHashCode() ?? 0;`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Convert the <see cref="${enumName}"/> to a string.`);
            w.line(`/// </summary>`);
            w.line(`/// <returns>String representation of the ${enumName}.</returns>`);
            w.line(`public override string ToString() => _value;`);
        });
    });
    w.line(`#endregion ${regionName}`);
}

function generateObject(w: IndentWriter, model: IServiceModel, type: IObjectType) {
    const service = model.service;
    const regionName = type.struct ? `struct ${naming.type(type.name)}` : `class ${naming.type(type.name)}`;
    let needsModelFactory = false;
    w.line(`#region ${regionName}`);
    w.line(`namespace ${naming.namespace(type.namespace)}`);
    w.scope('{', '}', () => {
        w.line(`/// <summary>`);
        w.line(`/// ${type.description || type.name}`);
        w.line(`/// </summary>`);
        if (type.disableWarnings) { w.line(`#pragma warning disable ${type.disableWarnings}`); }
        if (type.struct) { w.line(`${type.public ? 'public' : 'internal'} readonly partial struct ${naming.type(type.name)}: System.IEquatable<${naming.type(type.name)}>`); }
        else { w.line(`${type.public ? 'public' : 'internal'} partial class ${naming.type(type.name)}`); }
        if (type.disableWarnings) { w.line(`#pragma warning restore ${type.disableWarnings}`); }
        const separator = IndentWriter.createFenceposter();
        w.scope('{', '}', () => {
            for (const property of <IProperty[]>Object.values(type.properties)) {
                if (separator()) { w.line(); }
                w.line(`/// <summary>`);
                w.line(`/// ${property.description || property.model.description || property.name}`);
                w.line(`/// </summary>`);
                let internalSetter = !property.isNullable && (property.readonly || property.model.type === `array`);
                let isCollection = isPrimitiveType(property.model) && property.model.itemType && !type.struct;
                if (property.model.type === `byte`) {
                    w.line(`#pragma warning disable CA1819 // Properties should not return arrays`);
                }
                if (isCollection && !internalSetter) {
                    w.line(`#pragma warning disable CA2227 // Collection properties should be readonly`);
                }
                w.write(`public ${types.getDeclarationType(property.model, property.required, property.readonly)} ${naming.property(property.clientName)} { get; `);
                if (!type.struct) {
                    if (internalSetter) {
                        w.write(`internal `);
                    }
                    w.write(`set; `);
                }
                w.write(`}`);
                w.line();
                if (property.model.type === `byte`) {
                    w.line(`#pragma warning restore CA1819 // Properties should not return arrays`);
                }
                if (isCollection && !internalSetter) {
                    w.line(`#pragma warning restore CA2227 // Collection properties should be readonly`);
                }
            }

            // Instantiate nested models if necessary
            const readonlyModel = Object.values(type.properties).every(p => (<IProperty>p).readonly);
            const nested = (<IProperty[]>Object.values(type.properties)).filter(p => !p.isNullable && (isObjectType(p.model) || (isPrimitiveType(p.model) && (p.model.itemType || p.model.type === `dictionary`))));
            if (nested.length > 0) {
                const skipInitName = `skipInitialization`;
                if (separator()) { w.line(); }
                w.line(`/// <summary>`);
                w.line(`/// Creates a new ${naming.type(type.name)} instance`);
                w.line(`/// </summary>`);
                if (type.deserialize) {
                    let visibility = `public`;
                    if (type.public && readonlyModel) {
                        visibility = `internal`;
                        needsModelFactory = true;
                    }
                    // Add an optional overload that prevents initialization for deserialiation
                    w.write(`${visibility} ${naming.type(type.name)}()`);
                    w.scope(() => w.write(`: this(false)`));
                    w.scope(`{`, `}`, () => null);
                    w.line();
                    w.line(`/// <summary>`);
                    w.line(`/// Creates a new ${naming.type(type.name)} instance`);
                    w.line(`/// </summary>`);
                    w.line(`/// <param name="${skipInitName}">Whether to skip initializing nested objects.</param>`);
                    w.line(`internal ${naming.type(type.name)}(bool ${skipInitName})`);
                } else {
                    w.line(`public ${naming.type(type.name)}()`);
                }
                w.scope('{', '}', () => {
                    if (type.deserialize) {
                        w.line(`if (!${skipInitName})`);
                        w.pushScope(`{`);
                    }
                    for (const property of nested) {
                        w.write(`${naming.property(property.clientName)} = `);
                        if (isObjectType(property.model)) {
                            w.line(`new ${types.getName(property.model)}();`);
                        } else if (property.model.type === `dictionary`) {
                            w.line(`new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                        } else if (isPrimitiveType(property.model) && property.model.itemType) {
                            w.line(`new System.Collections.Generic.List<${types.getName(property.model.itemType)}>();`);
                        } else if (isPrimitiveType(property.model) && property.model.type === `byte`) {
                            w.line(`System.Array.Empty<byte>();`);
                        }
                    }
                    if (type.deserialize) {
                        w.popScope(`}`);
                    }
                });
            } else if (readonlyModel) {
                needsModelFactory = true;
                const factoryName = naming.type(model.info.modelFactoryName);
                w.line();
                w.line(`/// <summary>`)
                w.line(`/// Prevent direct instantiation of ${naming.type(type.name)} instances.`);
                w.line(`/// You can use ${factoryName}.${naming.type(type.name)} instead.`);
                w.line(`/// </summary>`);
                if (type.struct) {
                    const properties = <IProperty[]>Object.values(type.properties);
                    w.write(`internal ${naming.type(type.name)}(`);
                    w.scope(() => {
                        const separator = IndentWriter.createFenceposter();
                        for (const property of properties) {
                            if (separator()) { w.line(`,`); }
                            w.write(`${types.getDeclarationType(property.model, property.required, property.readonly)} ${naming.parameter(property.clientName)}`);
                        }
                        w.line(`)`);
                        w.scope('{', '}', () => {
                            for (const property of properties) {
                                w.line(`${naming.property(property.clientName)} = ${naming.parameter(property.clientName)};`);
                            }
                        });
                    });
                    w.line();
                    w.line(`/// <summary>`)
                    w.line(`/// Check if two ${naming.type(type.name)} instances are equal.`);
                    w.line(`/// </summary>`);
                    w.line(`/// <param name="other">The instance to compare to.</param>`);
                    w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
                    w.line(`[System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]`);
                    w.line(`public bool Equals(${naming.type(type.name)} other)`);
                    w.scope('{', '}', () => {
                        for (const property of properties) {
                            const a = naming.property(property.clientName);
                            const b = `other.${naming.property(property.clientName)}`;
                            if (types.getDeclarationType(property.model, property.required, property.readonly) === "string") {
                                w.line(`if (!System.StringComparer.Ordinal.Equals(${a}, ${b}))`);
                            } else if (types.getDeclarationType(property.model, property.required, property.readonly).includes("[]")) {
                                w.line(`if (!System.Collections.StructuralComparisons.StructuralEqualityComparer.Equals(${a}, ${b}))`);
                            } else {
                                w.line(`if (!${a}.Equals(${b}))`);
                            }
                            w.scope('{', '}', () => {
                                w.line(`return false;`);
                            });
                        }
                        w.line();
                        w.line(`return true;`);
                    });
                    w.line();
                    w.line(`/// <summary>`);
                    w.line(`/// Check if two ${naming.type(type.name)} instances are equal.`);
                    w.line(`/// </summary>`);
                    w.line(`/// <param name="obj">The instance to compare to.</param>`);
                    w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
                    w.line(`[System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]`);
                    w.line(`public override bool Equals(object obj) => obj is ${naming.type(type.name)} && Equals((${naming.type(type.name)})obj);`);
                    w.line();
                    w.line(`/// <summary>`)
                    w.line(`/// Get a hash code for the ${naming.type(type.name)}.`);
                    w.line(`/// </summary>`);
                    w.line(`[System.ComponentModel.EditorBrowsable((System.ComponentModel.EditorBrowsableState.Never))]`);
                    w.line(`public override int GetHashCode()`);
                    w.scope('{', '}', () => {
                        w.line(`var hashCode = new Azure.Core.HashCodeBuilder();`);
                        for (const property of properties) {
                            if (types.getDeclarationType(property.model, property.required, property.readonly) === "string") {
                                w.line(`if (${naming.property(property.clientName)} != null)`)
                                w.scope('{', '}', () => {
                                    w.line(`hashCode.Add(${naming.property(property.clientName)}, System.StringComparer.Ordinal);`);
                                });
                            } else if (types.getDeclarationType(property.model, property.required, property.readonly).includes("[]")) {
                                w.line(`hashCode.Add(System.Collections.StructuralComparisons.StructuralEqualityComparer.GetHashCode(${naming.property(property.clientName)}));`);
                            } else {
                                w.line(`hashCode.Add(${naming.property(property.clientName)});`);
                            }
                        }
                        w.line();
                        w.line(`return hashCode.ToHashCode();`);
                    });
                }
                else { w.line(`internal ${naming.type(type.name)}() { }`); }
            } else {
                w.line();
                w.line(`/// <summary>`);
                w.line(`/// Creates a new ${naming.type(type.name)} instance`);
                w.line(`/// </summary>`);
                w.line(`public ${naming.type(type.name)}() { }`);
            }

            // Create serializers if necessary
            for (const serializationType of model.info.consumes) {
                const format =
                    (serializationType === 'application/xml') ? 'Xml' :
                    (serializationType === 'application/json') ? 'Json' :
                    serializationType;

                // TODO: JSON, ...
                if (format !== `Xml`) {
                    throw `Currently unsupported serialization format (in ${types.getName(type)})`;
                }

                if (type.serialize) {
                    if (separator()) { w.line(); }
                    generateSerialize(w, service, type, format);
                }

                if (type.deserialize) {
                    if (separator()) { w.line(); }
                    generateDeserialize(w, service, type, format);
                }
            }
        });

        // If there are readonly properties, we'll create a model factory
        const props = <IProperty[]>Object.values(type.properties);
        if (type.public && (needsModelFactory || props.some(p => p.readonly))) {
            const factoryName = naming.type(model.info.modelFactoryName);
            const typeName = naming.type(type.name);
            const modelName = `_model`;
            w.line();
            w.line(`/// <summary>`);
            w.line(`/// ${factoryName} provides utilities for mocking.`);
            w.line(`/// </summary>`);
            w.line(`public static partial class ${factoryName}`);
            w.scope(`{`, `}`, () => {
                w.line(`/// <summary>`);
                w.line(`/// Creates a new ${typeName} instance for mocking.`);
                w.line(`/// </summary>`);
                w.write(`public static ${typeName} ${typeName}(`);
                w.scope(() => {
                    const separator = IndentWriter.createFenceposter();
                    // Sort `= default` parameters last
                    props.sort((a: IProperty, b: IProperty) => a.required ? -1 : b.required ? 1 : 0);
                    for (const property of props) {
                        if (separator()) { w.line(`,`); }
                        w.write(`${types.getDeclarationType(property.model, property.required, property.readonly)} ${naming.parameter(property.clientName)}`);
                        if (!property.required) { w.write(` = default`); }
                    }
                    w.write(`)`);
                });
                const separator = IndentWriter.createFenceposter();
                if (type.struct) {
                    w.scope('{', '}', () => {
                        w.write(`return new ${typeName}(`);
                        for (const property of props) {
                            if (separator()) { w.write(`, `); }
                            w.write(`${naming.parameter(property.clientName)}`);
                            if (!property.required) { w.write(` = default`); }
                        }
                        w.write(`);`);
                    });
                } else {
                    w.scope('{', '}', () => {
                        w.line(`return new ${typeName}()`);

                        w.scope('{', '};', () => {
                            for (const property of props) {
                                w.line(`${naming.property(property.clientName)} = ${naming.parameter(property.clientName)},`);
                            }
                        });
                    });
                }
            });
        }
    });
    w.line(`#endregion ${regionName}`);
}

function generateSerialize(w: IndentWriter, service: IService, type: IObjectType, format: string) {
    const toName = naming.method(`To ${format}`, false);
    const { name: elementName, ns: elementNamespace } = getXmlName(type.name, type.xml);
    w.line(`/// <summary>`);
    w.line(`/// Serialize a ${naming.type(type.name)} instance as XML.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="value">The ${naming.type(type.name)} instance to serialize.</param>`);
    w.line(`/// <param name="name">An optional name to use for the root element instead of "${elementName}".</param>`);
    w.line(`/// <param name="ns">An optional namespace to use for the root element instead of "${elementNamespace}".</param>`);
    w.line(`/// <returns>The serialized XML element.</returns>`);
    w.line(`internal static System.Xml.Linq.XElement ${toName}(${types.getName(type)} value, string name = "${elementName}", string ns = "${elementNamespace}")`);
    w.scope('{', '}', () => {
        w.line(`System.Diagnostics.Debug.Assert(value != null);`)
        const elementName = "_element";
        let elementsName = undefined;

        // Create the element
        w.line(`System.Xml.Linq.XElement ${elementName} = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));`);

        // Serialize each of the properties
        const properties = <IProperty[]>Object.values(type.properties);
        for (const property of properties) {
            let current = elementName;
            const { xname: childName } = getXmlShape(property.name, property.xml);
            if (!property.required) {
                w.line(`if (value.${naming.property(property.name)} != null)`);
                w.pushScope('{');
            }
            const { name: xmlName, ns: xmlNs } = getXmlName(property.name, property.xml);
            const { xname, isAttribute, wrapped } = getXmlShape(property.name, property.xml);
            if (wrapped) {
                if (!elementsName) {
                    elementsName = "_elements";
                    w.write(`System.Xml.Linq.XElement `);
                }
                current = elementsName;
                w.line(`${current} = new System.Xml.Linq.XElement(${xname});`);
            }
            if (isObjectType(property.model)) {
                if (!property.model.serialize) {
                    throw `Cannot serialize ${types.getName(type)} if ${types.getName(property.model)} can't be serialized!`;
                }
                w.line(`${current}.Add(${types.getName(property.model)}.${toName}(value.${naming.property(property.name)}, "${xmlName}", "${xmlNs}"));`);
            } else if (isPrimitiveType(property.model) && property.model.itemType) {
                const itemType = property.model.itemType;
                const childName = `_child`;
                w.line(`foreach (${types.getName(itemType)} ${childName} in value.${naming.property(property.name)})`);
                w.scope('{', '}', () => {
                    if (isObjectType(itemType) && itemType.serialize) {
                        w.line(`${current}.Add(${types.getName(itemType)}.${toName}(${childName}));`);
                    } else if (itemType.type === `string`) {

                        w.line(`${current}.Add(new System.Xml.Linq.XElement(${xname}, ${childName}));`)
                    } else {
                        w.line(`// TODO: Cannot serialize unknown array type`);
                    }
                });
            } else {
                const text = types.convertToString('value.' + naming.property(property.name), property.model, service, property.required);
                w.write(`${current}.Add(new System.Xml.Linq.XElement(`);
                w.scope(() => {
                    w.line(`${childName},`);
                    if (property.model.type === `boolean`) {
                        w.line(`#pragma warning disable CA1308 // Normalize strings to uppercase`);
                    }
                    w.write(`${text}));`);
                    if (property.model.type === `boolean`) {
                        w.line();
                        w.line(`#pragma warning restore CA1308 // Normalize strings to uppercase`);
                    }

                });
            }
            if (wrapped) {
                w.write(`${elementName}.Add(${current});`);
            }
            if (!property.required) {
                w.popScope('}');
            }
        }

        w.line(`return ${elementName};`);
    });
}

function generateDeserialize(w: IndentWriter, service: IService, type: IObjectType, format: string) {
    const fromName = naming.method(`From ${format}`, false);
    const rootName = 'element';
    w.line(`/// <summary>`);
    w.line(`/// Deserializes XML into a new ${naming.type(type.name)} instance.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="${rootName}">The XML element to deserialize.</param>`);
    w.line(`/// <returns>A deserialized ${naming.type(type.name)} instance.</returns>`);
    w.line(`internal static ${types.getName(type)} ${fromName}(System.Xml.Linq.XElement ${rootName})`);
    w.scope('{', '}', () => {
        w.line(`System.Diagnostics.Debug.Assert(element != null);`);

        // Optionally declare the _child/_attribute temporaries
        const properties = <IProperty[]>Object.values(type.properties);
        const childName = '_child';
        if (properties.some(p =>
            ((!isPrimitiveType(p.model) || !p.model.itemType || !p.xml || !!p.xml.wrapped)) &&
            /* not attr */ (!p.xml || (p.xml.attribute !== true)) ||
            /* dictionary */ p.model.type === `dictionary`)) {
            w.line(`System.Xml.Linq.XElement ${childName};`);
        }
        const attributeName = '_attribute';
        if (properties.some(p => (p.xml !== undefined) && (p.xml.attribute === true))) {
            w.line(`System.Xml.Linq.XAttribute ${attributeName};`);
        }

        // Create the model
        const valueName = '_value';
        const skipInit = (<IProperty[]>Object.values(type.properties)).some(p => isObjectType(p.model) || (isPrimitiveType(p.model) && (!!p.model.itemType || p.model.type === `dictionary`)));
        if (!type.struct) { w.line(`${types.getName(type)} ${valueName} = new ${types.getName(type)}(${skipInit ? 'true' : ''});`); }

        if (type.struct) {
            for (const property of properties) {
                w.line(`${types.getDeclarationType(property.model, true, false, true)} ${naming.parameter(property.clientName)} = default;`);
            }
        }

        // Deserialize each of its properties
        for (const property of properties) {
            let isDict = property.model.type === `dictionary`;
            let isArray = !isDict && isPrimitiveType(property.model) && property.model.itemType !== undefined;

            // Get the XML for this propery (attribute and wrapped only come from
            // the property but name also be pulled from the model)
            let { isAttribute, wrapped } = getXmlShape(property.name, property.xml);
            let modelType = isArray ? <IModelType>(<IPrimitiveType>property.model).itemType : property.model;
            let { xname } = getXmlShape(
                isArray && !wrapped ? (<IObjectType>(<IPrimitiveType>property.model).itemType).name : property.name,
                property.xml && property.xml.name ? property.xml : (isObjectType(modelType) ? modelType.xml : undefined));

            let element = rootName;
            let accessor =
                wrapped && isArray ? 'Element' :
                    isAttribute && isArray ? 'Attributes' :
                        isAttribute ? 'Attribute' :
                            isArray ? 'Elements' :
                                'Element';
            element = `${element}.${accessor}(${xname})`;

            // Decide if we have to put it in the _child/_attribute temporaries or can use it directly
            const target = isAttribute ? attributeName : childName;

            // Read and parse the content of an indiviual element or attribute
            const parse = (text: string, model: IModelType): string => {
                if (isObjectType(model)) {
                    if (!model.deserialize) {
                        throw `Cannot deserialize ${types.getName(type)} if ${types.getName(model)} can't be deserialized!`;
                    }
                    // Change fromName if it ever stops being universal to the format
                    return `${types.getName(model)}.${fromName}(${text})`;
                } else {
                    if (isEnumType(model) && model.skipValue) {
                        // If skipValue is set on the enum, that means that the service would return a null for that value.
                        // Hence, we add the null conditional for this case. 
                        return types.convertFromString(`${text}?.Value`, model, service);
                    } else {
                        return types.convertFromString(`${text}.Value`, model, service);
                    }
                }
            };

            // Deserialize the XML
            if (isDict) {
                const itemType = (<IPrimitiveType>property.model).itemType
                if (!itemType || itemType.type !== 'string') {
                    throw `Only string dictionaries are supported for the moment`;
                }
                const pairName = `_pair`;
                w.line(`${valueName}.${naming.property(property.clientName)} = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                w.line(`${target} = ${element};`);
                w.line(`if (${target} != null)`);
                w.scope('{', '}', () => {
                    w.line(`foreach (System.Xml.Linq.XElement ${pairName} in ${target}.Elements())`);
                    w.scope(`{`, `}`, () => {
                        w.line(`${valueName}.${naming.property(property.clientName)}[${pairName}.Name.LocalName] = ${pairName}.Value;`);
                    });
                });
            } else if (isArray) {
                // Get the array item type
                let itemType = <IModelType>(<IPrimitiveType>property.model).itemType;
                if (isPrimitiveType(itemType) && itemType.itemType) {
                    throw `Nested arrays aren't supported!`
                }

                // Use LINQ extension methods to map over all the children in a single expression
                const mapAndAssign = (target: string) => {
                    w.write(`${valueName}.${naming.property(property.clientName)} = `);
                    w.scope('System.Linq.Enumerable.ToList(', '', () => {
                        w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                            w.line(`${target},`);
                            w.write(`e => ${parse('e', itemType)}));`);
                        });
                    });
                };
                if (wrapped) {
                    const { xname: nested } = getXmlShape(
                        isObjectType(itemType) || isEnumType(itemType) ? itemType.name : itemType.type,
                        isObjectType(itemType) || isPrimitiveType(itemType) ? itemType.xml : undefined);
                    w.line(`${target} = ${element};`);
                    w.line(`if (${target} != null)`);
                    w.scope('{', '}', () => mapAndAssign(`${target}.Elements(${nested})`));
                    w.line(`else`);
                    w.scope(`{`, `}`, () => {
                        w.write(`${valueName}.${naming.property(property.clientName)} = `);
                        w.line(`new System.Collections.Generic.List<${types.getName(itemType)}>();`);
                    });
                } else {
                    mapAndAssign(element);
                }
            } else {
                // Assign the value
                const assignment = type.struct ? `${naming.parameter(property.clientName)} = ${parse(target, property.model)};`
                    : `${valueName}.${naming.property(property.clientName)} = ${parse(target, property.model)};`;
                // we'll check if the element is there beforehand
                w.line(`${target} = ${element};`);
                w.write(`if (${target} != null`);
                if (isEnumType(property.model)) {
                    w.write(` && !string.IsNullOrEmpty(${target}.Value)`);
                }
                w.line(`)`);
                w.scope('{', '}', () => w.line(assignment));
            }
        }
        if (type.struct) {
            const separator = IndentWriter.createFenceposter();
            w.write(`${types.getName(type)} ${valueName} = new ${types.getName(type)}(`);
            for (const property of properties) {
                if (separator()) { w.write(`, `); }
                w.write(`${naming.parameter(property.clientName)}`);
            }
            w.write(`);`);
            w.line();
        }
        w.line(`Customize${fromName}(${rootName}, ${valueName});`);
        w.line(`return ${valueName};`);
    });
    w.line();
    w.line(`static partial void Customize${fromName}(System.Xml.Linq.XElement ${rootName}, ${types.getName(type)} value);`);
}

// Get the XML settings for IObjectType, IProperty, etc.
function getXmlShape(defaultName: string, xml?: IXmlSettings) {
    // Get the XML properties
    let elementNamespace = (xml ? xml.namespace : undefined) || '';
    let elementName = (xml ? xml.name : undefined) || defaultName;
    let { name, ns } = getXmlName(defaultName, xml);
    let isAttribute = (xml ? xml.attribute : undefined) || false;
    let wrapped = (xml ? xml.wrapped : undefined) || false;

    // Create the XML element name
    let xname = `System.Xml.Linq.XName.Get("${name}", "${ns}")`;

    return { xname, isAttribute, wrapped };
}

// Get the XML settings for IObjectType, IProperty, etc.
function getXmlName(defaultName: string, xml?: IXmlSettings) {
    // Get the XML properties
    let ns = (xml ? xml.namespace : undefined) || '';
    let name = (xml ? xml.name : undefined) || defaultName;

    return { name, ns };
}
