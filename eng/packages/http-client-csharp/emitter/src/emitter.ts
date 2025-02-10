// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createSdkContext, UsageFlags } from "@azure-tools/typespec-client-generator-core";
import {
  EmitContext,
  getDirectoryPath,
  joinPaths,
  logDiagnostics,
  NoTarget,
  Program,
  resolvePath,
} from "@typespec/compiler";

import fs, { statSync } from "fs";
import { PreserveType, stringifyRefs } from "json-serialize-refs";
import { dirname } from "path";
import { fileURLToPath } from "url";
import {
  configurationFileName,
  minSupportedDotNetSdkVersion,
  tspOutputFileName,
} from "./constants.js";
import { createModel } from "./lib/client-model-builder.js";
import { reportDiagnostic } from "./lib/lib.js";
import { LoggerLevel } from "./lib/log-level.js";
import { Logger } from "./lib/logger.js";
import { execAsync } from "./lib/utils.js";
import { NetEmitterOptions, resolveOptions, resolveOutputFolder } from "./options.js";
import { defaultSDKContextOptions } from "./sdk-context-options.js";
import { Configuration } from "./type/configuration.js";

/**
 * Look for the project root by looking up until a `package.json` is found.
 * @param path Path to start looking
 */
function findProjectRoot(path: string): string | undefined {
  let current = path;
  while (true) {
    const pkgPath = joinPaths(current, "package.json");
    const stats = checkFile(pkgPath);
    if (stats?.isFile()) {
      return current;
    }
    const parent = getDirectoryPath(current);
    if (parent === current) {
      return undefined;
    }
    current = parent;
  }
}

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
  const program: Program = context.program;
  const options = resolveOptions(context);
  const outputFolder = resolveOutputFolder(context);

  /* set the loglevel. */
  Logger.initialize(program, options.logLevel ?? LoggerLevel.INFO);

  if (!program.compilerOptions.noEmit && !program.hasError()) {
    // Write out the dotnet model to the output path
    const sdkContext = await createSdkContext(
      context,
      "@typespec/http-client-csharp",
      defaultSDKContextOptions,
    );
    const root = createModel(sdkContext);
    if (
      context.program.diagnostics.length > 0 &&
      context.program.diagnostics.filter((digs) => digs.severity === "error").length > 0
    ) {
      logDiagnostics(context.program.diagnostics, context.program.host.logSink);
      process.exit(1);
    }
    const tspNamespace = root.Name; // this is the top-level namespace defined in the typespec file, which is actually always different from the namespace of the SDK
    // await program.host.writeFile(outPath, prettierOutput(JSON.stringify(root, null, 2)));
    if (root) {
      const generatedFolder = resolvePath(outputFolder, "src", "Generated");

      if (!fs.existsSync(generatedFolder)) {
        fs.mkdirSync(generatedFolder, { recursive: true });
      }

      await program.host.writeFile(
        resolvePath(outputFolder, tspOutputFileName),
        prettierOutput(stringifyRefs(root, transformJSONProperties, 1, PreserveType.Objects)),
      );

      //emit configuration.json
      const namespace = options.namespace ?? tspNamespace;
      const configurations: Configuration = {
        "output-folder": ".",
        namespace: namespace,
        "library-name": options["library-name"] ?? namespace,
        "single-top-level-client": options["single-top-level-client"],
        "unreferenced-types-handling": options["unreferenced-types-handling"],
        "keep-non-overloadable-protocol-signature":
          options["keep-non-overloadable-protocol-signature"],
        "model-namespace": options["model-namespace"],
        "models-to-treat-empty-string-as-null": options["models-to-treat-empty-string-as-null"],
        "intrinsic-types-to-treat-empty-string-as-null": options[
          "models-to-treat-empty-string-as-null"
        ]
          ? options["additional-intrinsic-types-to-treat-empty-string-as-null"].concat(
              ["Uri", "Guid", "ResourceIdentifier", "DateTimeOffset"].filter(
                (item) =>
                  options["additional-intrinsic-types-to-treat-empty-string-as-null"].indexOf(
                    item,
                  ) < 0,
              ),
            )
          : undefined,
        "methods-to-keep-client-default-value": options["methods-to-keep-client-default-value"],
        "head-as-boolean": options["head-as-boolean"],
        "deserialize-null-collection-as-null-value":
          options["deserialize-null-collection-as-null-value"],
        flavor: options["flavor"],
        //only emit these if they are not the default values
        "generate-sample-project":
          options["generate-sample-project"] === true
            ? undefined
            : options["generate-sample-project"],
        "generate-test-project":
          options["generate-test-project"] === false ? undefined : options["generate-test-project"],
        "use-model-reader-writer": options["use-model-reader-writer"] ?? true,
        "disable-xml-docs":
          options["disable-xml-docs"] === false ? undefined : options["disable-xml-docs"],
      };

      await program.host.writeFile(
        resolvePath(outputFolder, configurationFileName),
        prettierOutput(JSON.stringify(configurations, null, 2)),
      );

      if (options.skipSDKGeneration !== true) {
        const csProjFile = resolvePath(
          outputFolder,
          "src",
          `${configurations["library-name"]}.csproj`,
        );
        Logger.getInstance().info(`Checking if ${csProjFile} exists`);
        const newProjectOption =
          options["new-project"] || !checkFile(csProjFile) ? "--new-project" : "";
        const existingProjectOption = options["existing-project-folder"]
          ? `--existing-project-folder ${options["existing-project-folder"]}`
          : "";
        const debugFlag = (options.debug ?? false) ? "--debug" : "";

        const emitterPath = options["emitter-extension-path"] ?? import.meta.url;
        const projectRoot = findProjectRoot(dirname(fileURLToPath(emitterPath)));
        const generatorPath = resolvePath(
          projectRoot + "/dist/generator/Microsoft.Generator.CSharp.dll",
        );

        const command = `dotnet --roll-forward Major ${generatorPath} ${outputFolder} -p ${options["plugin-name"]}${constructCommandArg(newProjectOption)}${constructCommandArg(existingProjectOption)}${constructCommandArg(debugFlag)}`;
        Logger.getInstance().info(command);

        try {
          const result = await execAsync(
            "dotnet",
            [
              "--roll-forward",
              "Major",
              generatorPath,
              outputFolder,
              "-p",
              options["plugin-name"],
              newProjectOption,
              existingProjectOption,
              debugFlag,
            ],
            { stdio: "inherit" },
          );
          if (result.exitCode !== 0) {
            const isValid = await validateDotNetSdk(
              sdkContext.program,
              minSupportedDotNetSdkVersion,
            );
            // if the dotnet sdk is valid, the error is not dependency issue, log it as normal
            if (isValid) {
              if (result.stderr) Logger.getInstance().error(result.stderr);
              if (result.stdout) Logger.getInstance().verbose(result.stdout);
              throw new Error(`Failed to generate the library. Exit code: ${result.exitCode}`);
            }
          }
        } catch (error: any) {
          const isValid = await validateDotNetSdk(sdkContext.program, minSupportedDotNetSdkVersion);
          // if the dotnet sdk is valid, the error is not dependency issue, log it as normal
          if (isValid) throw new Error(error);
        }
        if (!options["save-inputs"]) {
          // delete
          deleteFile(resolvePath(outputFolder, tspOutputFileName));
          deleteFile(resolvePath(outputFolder, configurationFileName));
        }
      }
    }
  }
}

/** check the dotnet sdk installation.
 * Report diagnostic if dotnet sdk is not installed or its version does not meet prerequisite
 * @param program The typespec compiler program
 * @param minVersionRequisite The minimum required major version
 */
export async function validateDotNetSdk(
  program: Program,
  minMajorVersion: number,
): Promise<boolean> {
  try {
    const result = await execAsync("dotnet", ["--version"], { stdio: "pipe" });
    return validateDotNetSdkVersion(program, result.stdout, minMajorVersion);
  } catch (error: any) {
    if (error && "code" in (error as {}) && error["code"] === "ENOENT") {
      reportDiagnostic(program, {
        code: "invalid-dotnet-sdk-dependency",
        messageId: "missing",
        format: {
          dotnetMajorVersion: `${minMajorVersion}`,
          downloadUrl: "https://dotnet.microsoft.com/",
        },
        target: NoTarget,
      });
    }
    return false;
  }
}

function validateDotNetSdkVersion(
  program: Program,
  version: string,
  minMajorVersion: number,
): boolean {
  if (version) {
    const dotIndex = version.indexOf(".");
    const firstPart = dotIndex === -1 ? version : version.substring(0, dotIndex);
    const major = Number(firstPart);

    if (isNaN(major)) {
      Logger.getInstance().error("Invalid .NET SDK version.");
      return false;
    }
    if (major < minMajorVersion) {
      reportDiagnostic(program, {
        code: "invalid-dotnet-sdk-dependency",
        messageId: "invalidVersion",
        format: {
          installedVersion: version,
          dotnetMajorVersion: `${minMajorVersion}`,
          downloadUrl: "https://dotnet.microsoft.com/",
        },
        target: NoTarget,
      });
      return false;
    }
    return true;
  } else {
    Logger.getInstance().error("Cannot get the installed .NET SDK version.");
    return false;
  }
}

function constructCommandArg(arg: string): string {
  return arg !== "" ? ` ${arg}` : "";
}

function transformJSONProperties(this: any, key: string, value: any): any {
  // convertUsageNumbersToStrings
  if (this["kind"] === "model" || this["kind"] === "enum") {
    if (key === "usage" && typeof value === "number") {
      if (value === 0) {
        return "None";
      }
      const result: string[] = [];
      for (const prop in UsageFlags) {
        if (!isNaN(Number(prop))) {
          if ((value & Number(prop)) !== 0) {
            result.push(UsageFlags[prop]);
          }
        }
      }
      return result.join(",");
    }
  }

  return value;
}

function deleteFile(filePath: string) {
  fs.unlink(filePath, (err) => {
    if (err) {
      //logger.error(`stderr: ${err}`);
    } else {
      Logger.getInstance().info(`File ${filePath} is deleted.`);
    }
  });
}

function prettierOutput(output: string) {
  return output + "\n";
}

function checkFile(pkgPath: string) {
  try {
    return statSync(pkgPath);
  } catch (error) {
    return undefined;
  }
}
