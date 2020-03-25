// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import * as fs from 'fs';
import * as path from 'path';
import chalk from 'chalk';
import { AutoRestExtension, Channel } from '@microsoft.azure/autorest-extension-base';
import { IAutoRestPluginInitiator } from '@microsoft.azure/autorest-extension-base/dist/lib/extension-base';
import { IGeneratorContext, GeneratorHandler, IProject } from './models';

// Launch the generator either as an AutoRest plugin listening for requests or
// a debugging version that executes immediately
export async function launch(name: string, handler: GeneratorHandler) : Promise<void> {
    const debugPath = process.argv.length > 3 && process.argv[2] === '--debug' ? process.argv[3] : null;
    if (debugPath) {
        const ctx = await getDebugGeneratorContext(debugPath, process.argv[4]);
        await handler(ctx);
    } else {
        const extension = new AutoRestExtension();
        extension.Add(name, async autorest => {
            const ctx = getAutoRestGeneratorContext(autorest);
            await handler(ctx);
        });
        extension.Run();
    }
}

// Wrap AutoRest in our IGeneratorContext abstraction
function getAutoRestGeneratorContext(autorest: IAutoRestPluginInitiator) : IGeneratorContext {
    const ctx = {
        async getSetting(key: string) : Promise<any> { return await autorest.GetValue(key); },
        async getInputUris() : Promise<string[]> { return await autorest.ListInputs(); },
        async readFile(filename: string): Promise<string> { return await autorest.ReadFile(filename); },
        async writeFile(filename: string, content: string): Promise<void> {
            ctx.verbose(`Emitting file ${filename}`);
            autorest.WriteFile(filename, content);
        },
        log(message: string): void { autorest.Message({ Channel: Channel.Information, Text: message }); },
        warn(message: string): void { autorest.Message({ Channel: Channel.Warning, Text: message }); },
        error(message: string): void { autorest.Message({ Channel: Channel.Error, Text: message }); },
        verbose(message: string): void { autorest.Message({ Channel: Channel.Verbose, Text: message }); }
    };
    return ctx;
}

// Create a debugging version of our AutoRest abstraction (ideally we'd just
// launch AutoRest and parse the readme.md, but that's also nontrivial to get
// working correctly)
async function getDebugGeneratorContext(swaggerPath : string, outputPath?: string) : Promise<IGeneratorContext> {
    const dir = outputPath || path.dirname(swaggerPath);
    const settings : { [key: string]: any; } = {
        'input-file': swaggerPath,
        'output-folder': dir,
        'clear-output-folder': false,
        'azure-track2-csharp': true
    };
    const ctx = {
        async getSetting(key: string) : Promise<any> { return Promise.resolve(settings[key]); },
        async getInputUris() : Promise<string[]> { return Promise.resolve([swaggerPath]); },
        log(message: string): void { console.log(`INFORMATION: ${message}`); },
        warn(message: string): void { console.error(chalk.yellow(`WARNING: ${message}`)); },
        error(message: string): void { console.error(chalk.red(`ERROR: ${message}`)); },
        verbose(message: string): void { console.log(`VERBOSE: ${message}`); },
        async readFile(filename: string): Promise<string> {
            const data = await fs.promises.readFile(filename);
            return data.toString();
        },
        async writeFile(filename: string, content: string): Promise<void> {
            ctx.verbose(`Emitting file ${filename}`);
            filename = path.join(dir, filename);
            await fs.promises.mkdir(path.dirname(filename), { recursive: true });
            await fs.promises.writeFile(filename, content, 'utf8');
        }
    }
    return ctx;
}

// Load a project from the generator context
export async function loadProject(ctx: IGeneratorContext) : Promise<IProject> {
    const project : IProject = {
        context: ctx,
        settings: {
            'input-file': await ctx.getSetting('input-file'),
            'output-folder': await ctx.getSetting('output-folder'),
            'clear-output-folder': await ctx.getSetting('clear-output-folder'),
            'azure-track2-csharp': await ctx.getSetting('azure-track2-csharp')
        },
        swagger: null,
        cache: {
            parameters: { },
            definitions: { },
            responses: { },
            customTypes: { },
            voidType: { type: "void", external: true, extendedHeaders: [] }
        }
    };

    // TODO: To simplify things for now, we're going to insist on a single file...
    const files = await ctx.getInputUris();
    switch (files.length) {
        case 1: break; // Do nothing
        case 0: throw `Did not find any input files to generate!`;
        default: throw `TODO: Too many input files: ${files.join(', ')}`;
    }

    // Get the swagger we'll be using
    ctx.verbose(`Loading service ${files[0]}`);
    const source = await ctx.readFile(files[0]);
    project.swagger = JSON.parse(source);

    return project;
}
