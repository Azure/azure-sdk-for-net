// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import { launch, loadProject } from './src/interface';
import { create as createServiceModel } from './src/serviceModel';
import { generate } from './src/generator';

// Launch the Azure Track 2 C# generator plugin
launch(
   'azure-track2-csharp-generator',
   async ctx => {
      try {
         // Helper to dump intermediate stages to a debugging directory
         const dump = async (name: string, value: any) =>
            null; // await ctx.writeFile(`debugging/${name}.json`, JSON.stringify(value, null, '   '));

         ctx.verbose(`>>> 1. Load the project...`);
         const project = await loadProject(ctx);
         dump('01-project', project);

         ctx.verbose(`>>> 2. Create the object model...`);
         const model = await createServiceModel(project);
         dump('02-model', model);
         dump('02-project', project);

         ctx.verbose(`>>> 3. Generate code...`);
         await generate(model);

      } catch (ex) {
         // Report any errors
         ctx.error(ex.toString());
         throw ex;
      }
   });
