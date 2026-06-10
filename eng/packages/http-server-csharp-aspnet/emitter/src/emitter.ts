// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  createSdkContext,
  getCrossLanguageDefinitionId
} from "@azure-tools/typespec-client-generator-core";
import type {
  SdkClientType,
  SdkEnumType,
  SdkHttpOperation,
  SdkMethod,
  SdkMethodResponse,
  SdkModelPropertyType,
  SdkModelType,
  SdkNamespace,
  SdkNullableType,
  SdkServiceMethod,
  SdkServiceOperation,
  SdkType,
  SdkUnionType
} from "@azure-tools/typespec-client-generator-core";
import {
  createDiagnosticCollector,
  getDirectoryPath,
  joinPaths,
  NoTarget,
  resolvePath
} from "@typespec/compiler";
import type {
  Diagnostic,
  EmitContext,
  Namespace,
  Operation,
  Program,
  Type
} from "@typespec/compiler";
import { unsafe_mutateSubgraphWithNamespace as mutateSubgraphWithNamespace } from "@typespec/compiler/experimental";
import { getHttpOperation } from "@typespec/http";
import { getVersioningMutators } from "@typespec/versioning";
import {
  createCSharpEmitterContext,
  createDiagnostic,
  createModel,
  LoggerLevel,
  Logger,
  resolveOptions,
  writeCodeModel
} from "@typespec/http-client-csharp";
import type { CSharpEmitterContext } from "@typespec/http-client-csharp";
import { spawn } from "child_process";
import type { ChildProcess } from "child_process";
import fs, { statSync } from "fs";
import { dirname, resolve } from "path";
import { fileURLToPath } from "url";

import { AspNetServerEmitterOptions } from "./options.js";

/**
 * Name of the C# generator class that the .NET generator host should load.
 * Must match the `[ExportMetadata(GeneratorMetadataName, ...)]` value on
 * `AspNetServerCodeModelGenerator` in the .NET project.
 */
const GENERATOR_NAME = "AspNetServerCodeModelGenerator";
const TSP_OUTPUT_FILE_NAME = "tspCodeModel.json";
const CONFIGURATION_FILE_NAME = "Configuration.json";

export async function $onEmit(
  context: EmitContext<AspNetServerEmitterOptions>
) {
  // Always force our generator name. Upstream's option schema applies a
  // default of `ScmCodeModelGenerator`, so a `??=` guard would never see the
  // option as unset and our generator would be skipped.
  context.options["generator-name"] = GENERATOR_NAME;
  // Tell the upstream emitter where to find this package on disk so it can
  // locate the .NET generator's `dist/generator` payload.
  context.options["emitter-extension-path"] ??= import.meta.url;
  // Filtering the SDK package below already removes unreferenced types, but
  // keep the downstream Roslyn pruning disabled so server scaffolding types
  // that are not yet wired into the input graph survive generation.
  context.options["unreferenced-types-handling"] ??= "keepAll";

  const [, diagnostics] = await emitChangedCodeModel(context);
  context.program.reportDiagnostics(diagnostics);
}

async function emitChangedCodeModel(
  context: EmitContext<AspNetServerEmitterOptions>
): Promise<[void, readonly Diagnostic[]]> {
  const diagnostics = createDiagnosticCollector();
  const program = context.program;
  const options = resolveOptions(context);
  const outputFolder = context.emitterOutputDir;

  if (options.plugins) {
    options.plugins = options.plugins.map((p) => resolve(outputFolder, p));
  }

  if (program.compilerOptions.noEmit || program.hasError()) {
    return diagnostics.wrap(undefined);
  }

  const logger = new Logger(program, options.logLevel);
  const sdkContext = createCSharpEmitterContext(
    await createSdkContext(
      context,
      "@typespec/http-client-csharp",
      options["sdk-context-options"]
    ),
    logger
  );

  for (const diagnostic of sdkContext.diagnostics) {
    diagnostics.add(diagnostic);
  }

  const changedOperations = analyzeChangedOperations(
    program,
    options["api-version"]
  );
  if (changedOperations === "unknown-version") {
    return diagnostics.wrap(undefined);
  }
  if (changedOperations !== undefined) {
    const changedOperationIds = new Set(
      changedOperations.map((operation) =>
        getCrossLanguageDefinitionId(sdkContext, operation)
      )
    );
    filterSdkPackage(sdkContext, changedOperationIds);
  }

  const root = diagnostics.pipe(createModel(sdkContext));
  if (root === undefined) {
    return diagnostics.wrap(undefined);
  }

  const generatedFolder = resolvePath(outputFolder, "src", "Generated");
  if (!fs.existsSync(generatedFolder)) {
    fs.mkdirSync(generatedFolder, { recursive: true });
  }

  await writeCodeModel(sdkContext, root, outputFolder);
  const configurations = createServerConfiguration(
    options,
    root.name,
    sdkContext
  );
  await writeServerConfiguration(sdkContext, configurations, outputFolder);

  const csProjFile = resolvePath(
    outputFolder,
    "src",
    `${configurations["package-name"]}.csproj`
  );
  const emitterPath = options["emitter-extension-path"] ?? import.meta.url;
  const projectRoot = findProjectRoot(dirname(fileURLToPath(emitterPath)));
  const generatorPath = resolvePath(
    projectRoot ?? "",
    "dist",
    "generator",
    "Microsoft.TypeSpec.Generator.dll"
  );

  const result = await execCSharpGenerator(sdkContext, {
    generatorPath,
    outputFolder,
    generatorName: options["generator-name"],
    newProject: options["new-project"] || !checkFile(csProjFile),
    debug: options.debug
  });

  if (result.exitCode !== 0) {
    diagnostics.add(
      createDiagnostic({
        code: "general-error",
        format: {
          message: `Failed to generate the library. Exit code: ${result.exitCode}.\n${result.stderr}`
        },
        target: NoTarget
      })
    );
  }

  if (!options["save-inputs"]) {
    await program.host.rm(resolvePath(outputFolder, TSP_OUTPUT_FILE_NAME));
    await program.host.rm(resolvePath(outputFolder, CONFIGURATION_FILE_NAME));
  }

  return diagnostics.wrap(undefined);
}

type ChangedOperationAnalysis = Operation[] | "unknown-version" | undefined;

function analyzeChangedOperations(
  program: Program,
  requestedVersion: string | undefined
): ChangedOperationAnalysis {
  if (requestedVersion === "all") {
    return undefined;
  }

  const serviceNs = findServiceNamespace(program);
  if (serviceNs === undefined) {
    return undefined;
  }

  const versioningMutators = getVersioningMutators(program, serviceNs);
  if (
    versioningMutators === undefined ||
    versioningMutators.kind !== "versioned"
  ) {
    return undefined;
  }

  const snapshots = versioningMutators.snapshots;
  const targetIndex =
    requestedVersion === undefined || requestedVersion === "latest"
      ? snapshots.length - 1
      : snapshots.findIndex((s) => s.version.value === requestedVersion);

  if (targetIndex < 0) {
    program.reportDiagnostic({
      code: "aspnet-server-csharp/unknown-version",
      severity: "error",
      message: `Unknown API version '${requestedVersion}'. Available versions are: ${snapshots
        .map((s) => s.version.value)
        .join(", ")}.`,
      target: NoTarget
    });
    return "unknown-version";
  }

  const { type: currentNs } = mutateSubgraphWithNamespace(
    program,
    [snapshots[targetIndex].mutator],
    serviceNs
  );
  const currentSnapshot = extractSnapshot(program, currentNs as Namespace);

  if (targetIndex === 0) {
    return currentSnapshot.operations.map((operation) => operation.operation);
  }

  const { type: previousNs } = mutateSubgraphWithNamespace(
    program,
    [snapshots[targetIndex - 1].mutator],
    serviceNs
  );
  const previousSnapshot = extractSnapshot(program, previousNs as Namespace);
  return diffSnapshots(previousSnapshot, currentSnapshot)
    .map((impact) => impact.operation)
    .filter((operation): operation is Operation => operation !== undefined);
}

interface OperationSnapshot {
  name: string;
  fingerprint: string;
  operation: Operation;
}

interface VersionSnapshot {
  operations: OperationSnapshot[];
}

interface OperationImpact {
  operation?: Operation;
}

function extractSnapshot(program: Program, ns: Namespace): VersionSnapshot {
  const operations: OperationSnapshot[] = [];

  function walkNamespace(current: Namespace, prefix: string): void {
    for (const [, iface] of current.interfaces) {
      for (const [, op] of iface.operations) {
        operations.push({
          name: `${prefix}${iface.name}.${op.name}`,
          fingerprint: fingerprintOperation(program, op),
          operation: op
        });
      }
    }

    for (const [, op] of current.operations) {
      operations.push({
        name: `${prefix}${op.name}`,
        fingerprint: fingerprintOperation(program, op),
        operation: op
      });
    }

    for (const [, child] of current.namespaces) {
      walkNamespace(child, `${prefix}${child.name}.`);
    }
  }

  walkNamespace(ns, "");
  return { operations };
}

function diffSnapshots(
  previous: VersionSnapshot,
  current: VersionSnapshot
): OperationImpact[] {
  const impacts: OperationImpact[] = [];
  const previousOperations = new Map(
    previous.operations.map((o) => [o.name, o])
  );

  for (const currentOperation of current.operations) {
    const previousOperation = previousOperations.get(currentOperation.name);
    if (
      previousOperation === undefined ||
      previousOperation.fingerprint !== currentOperation.fingerprint
    ) {
      impacts.push({ operation: currentOperation.operation });
    }
  }

  return impacts;
}

function fingerprintOperation(program: Program, operation: Operation): string {
  const [httpOperation] = getHttpOperation(program, operation);
  const seen = new Set<Type>();
  return [
    httpOperation.verb,
    httpOperation.path,
    fingerprintModel(operation.parameters, seen),
    fingerprintType(operation.returnType, seen)
  ].join("|");
}

function fingerprintModel(model: Type, seen: Set<Type>): string {
  if (model.kind !== "Model") {
    return fingerprintType(model, seen);
  }

  if (seen.has(model)) {
    return `<circular:${model.name || "anonymous"}>`;
  }
  seen.add(model);

  const props: string[] = [];
  for (const [name, prop] of model.properties) {
    props.push(
      `${name}${prop.optional ? "?" : ""}:${fingerprintType(prop.type, seen)}`
    );
  }

  seen.delete(model);
  return `{${props.join(",")}}`;
}

function fingerprintType(type: Type, seen: Set<Type>): string {
  switch (type.kind) {
    case "Scalar":
      return type.name;
    case "Model":
      if (type.indexer && type.name === "Array") {
        return `${fingerprintType(type.indexer.value, seen)}[]`;
      }
      return `${type.name}${fingerprintModel(type, seen)}`;
    case "Enum":
      return `${type.name}{${Array.from(type.members.keys()).join(",")}}`;
    case "Union":
      return Array.from(type.variants.values())
        .map((variant) => fingerprintType(variant.type, seen))
        .join("|");
    case "Tuple":
      return `[${type.values
        .map((value) => fingerprintType(value, seen))
        .join(",")}]`;
    default:
      return type.kind;
  }
}

function findServiceNamespace(program: Program): Namespace | undefined {
  const queue = Array.from(
    program.getGlobalNamespaceType().namespaces.values()
  );
  for (let index = 0; index < queue.length; index++) {
    const ns = queue[index];
    if (ns.decorators.some((d) => d.decorator.name === "$service")) {
      return ns;
    }
    queue.push(...ns.namespaces.values());
  }
  return undefined;
}

function filterSdkPackage(
  context: CSharpEmitterContext,
  changedOperationIds: Set<string>
): void {
  const retainedClients = new Set<SdkClientType<SdkHttpOperation>>();

  context.sdkPackage.clients = context.sdkPackage.clients.filter((client) =>
    filterClient(client, changedOperationIds, retainedClients)
  );

  const retainedTypes = collectRetainedTypes(context.sdkPackage.clients);
  context.sdkPackage.models = context.sdkPackage.models.filter((model) =>
    retainedTypes.models.has(model)
  );
  context.sdkPackage.enums = context.sdkPackage.enums.filter((enumType) =>
    retainedTypes.enums.has(enumType)
  );
  context.sdkPackage.unions = context.sdkPackage.unions.filter((unionType) =>
    retainedTypes.unions.has(unionType)
  );

  filterNamespaces(
    context.sdkPackage.namespaces,
    retainedClients,
    retainedTypes
  );
}

function filterClient(
  client: SdkClientType<SdkHttpOperation>,
  changedOperationIds: Set<string>,
  retainedClients: Set<SdkClientType<SdkHttpOperation>>
): boolean {
  client.methods = client.methods.filter((method) =>
    isChangedMethod(method, changedOperationIds)
  );

  if (client.children !== undefined) {
    client.children = client.children.filter((child) =>
      filterClient(child, changedOperationIds, retainedClients)
    );
  }

  const retain =
    client.methods.length > 0 || (client.children?.length ?? 0) > 0;
  if (retain) {
    retainedClients.add(client);
  }
  return retain;
}

function isChangedMethod(
  method: SdkMethod<SdkHttpOperation>,
  changedOperationIds: Set<string>
): boolean {
  if (method.__raw === undefined) {
    return false;
  }

  return changedOperationIds.has(method.crossLanguageDefinitionId);
}

interface RetainedTypes {
  models: Set<SdkModelType>;
  enums: Set<SdkEnumType>;
  unions: Set<SdkUnionType | SdkNullableType>;
}

function collectRetainedTypes(
  clients: SdkClientType<SdkHttpOperation>[]
): RetainedTypes {
  const retained: RetainedTypes = {
    models: new Set(),
    enums: new Set(),
    unions: new Set()
  };

  const visitClient = (client: SdkClientType<SdkHttpOperation>): void => {
    for (const method of client.methods) {
      collectMethodTypes(method, retained);
    }
    for (const child of client.children ?? []) {
      visitClient(child);
    }
  };

  for (const client of clients) {
    visitClient(client);
  }

  return retained;
}

function collectMethodTypes(
  method: SdkServiceMethod<SdkHttpOperation>,
  retained: RetainedTypes
): void {
  for (const parameter of method.parameters) {
    collectType(parameter.type, retained);
  }
  collectMethodResponseTypes(method.response, retained);
  if (method.exception !== undefined) {
    collectMethodResponseTypes(method.exception, retained);
  }
  collectOperationTypes(method.operation, retained);
}

function collectMethodResponseTypes(
  response: SdkMethodResponse,
  retained: RetainedTypes
): void {
  if (response.type !== undefined) {
    collectType(response.type, retained);
  }
  for (const segment of response.resultSegments ?? []) {
    collectType(segment.type, retained);
  }
  collectStreamMetadata(response.streamMetadata, retained);
}

function collectOperationTypes(
  operation: SdkServiceOperation,
  retained: RetainedTypes
): void {
  if (operation.kind !== "http") {
    return;
  }

  for (const parameter of operation.parameters) {
    collectType(parameter.type, retained);
  }
  if (operation.bodyParam !== undefined) {
    collectType(operation.bodyParam.type, retained);
    collectStreamMetadata(operation.bodyParam.streamMetadata, retained);
  }
  for (const response of operation.responses) {
    if (response.type !== undefined) {
      collectType(response.type, retained);
    }
    for (const header of response.headers) {
      collectType(header.type, retained);
    }
    collectStreamMetadata(response.streamMetadata, retained);
  }
  for (const response of operation.exceptions) {
    if (response.type !== undefined) {
      collectType(response.type, retained);
    }
    for (const header of response.headers) {
      collectType(header.type, retained);
    }
    collectStreamMetadata(response.streamMetadata, retained);
  }
}

function collectStreamMetadata(
  streamMetadata:
    | {
        bodyType: SdkType;
        originalType: SdkType;
        streamType: SdkType;
      }
    | undefined,
  retained: RetainedTypes
): void {
  if (streamMetadata === undefined) {
    return;
  }

  collectType(streamMetadata.bodyType, retained);
  collectType(streamMetadata.originalType, retained);
  collectType(streamMetadata.streamType, retained);
}

function collectType(type: SdkType, retained: RetainedTypes): void {
  switch (type.kind) {
    case "model":
      if (retained.models.has(type)) {
        return;
      }
      retained.models.add(type);
      if (type.baseModel !== undefined) {
        collectType(type.baseModel, retained);
      }
      if (type.additionalProperties !== undefined) {
        collectType(type.additionalProperties, retained);
      }
      if (type.discriminatorProperty !== undefined) {
        collectPropertyType(type.discriminatorProperty, retained);
      }
      for (const subtype of Object.values(type.discriminatedSubtypes ?? {})) {
        collectType(subtype, retained);
      }
      for (const property of type.properties) {
        collectPropertyType(property, retained);
      }
      break;
    case "enum":
      retained.enums.add(type);
      break;
    case "union":
      if (retained.unions.has(type)) {
        return;
      }
      retained.unions.add(type);
      for (const variant of type.variantTypes) {
        collectType(variant, retained);
      }
      break;
    case "nullable":
      if (retained.unions.has(type)) {
        return;
      }
      retained.unions.add(type);
      collectType(type.type, retained);
      break;
    case "array":
      collectType(type.valueType, retained);
      break;
    case "tuple":
      for (const valueType of type.valueTypes) {
        collectType(valueType, retained);
      }
      break;
    case "dict":
      collectType(type.keyType, retained);
      collectType(type.valueType, retained);
      break;
    case "enumvalue":
      retained.enums.add(type.enumType);
      break;
    case "constant":
      collectType(type.valueType, retained);
      break;
    case "utcDateTime":
    case "offsetDateTime":
    case "duration":
      collectType(type.wireType, retained);
      break;
    case "endpoint":
      for (const argument of type.templateArguments) {
        collectType(argument.type, retained);
      }
      break;
    default:
      break;
  }
}

function collectPropertyType(
  property: SdkModelPropertyType,
  retained: RetainedTypes
): void {
  collectType(property.type, retained);
  for (const multipartHeader of property.multipartOptions?.headers ?? []) {
    collectType(multipartHeader.type, retained);
  }
  if (property.multipartOptions?.filename !== undefined) {
    collectType(property.multipartOptions.filename.type, retained);
  }
  if (property.multipartOptions?.contentType !== undefined) {
    collectType(property.multipartOptions.contentType.type, retained);
  }
}

function filterNamespaces(
  namespaces: SdkNamespace<SdkHttpOperation>[],
  retainedClients: Set<SdkClientType<SdkHttpOperation>>,
  retainedTypes: RetainedTypes
): void {
  for (const namespace of namespaces) {
    namespace.clients = namespace.clients.filter((client) =>
      retainedClients.has(client)
    );
    namespace.models = namespace.models.filter((model) =>
      retainedTypes.models.has(model)
    );
    namespace.enums = namespace.enums.filter((enumType) =>
      retainedTypes.enums.has(enumType)
    );
    namespace.unions = namespace.unions.filter((unionType) =>
      retainedTypes.unions.has(unionType)
    );
    filterNamespaces(namespace.namespaces, retainedClients, retainedTypes);
  }
}

function findProjectRoot(path: string): string | undefined {
  let current = path;
  for (;;) {
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

function checkFile(path: string): fs.Stats | undefined {
  try {
    return statSync(path);
  } catch {
    return undefined;
  }
}

async function execCSharpGenerator(
  context: CSharpEmitterContext,
  options: {
    generatorPath: string;
    outputFolder: string;
    generatorName: string;
    newProject: boolean;
    debug: boolean;
  }
): Promise<{ exitCode: number; stderr: string; proc: ChildProcess }> {
  const command = "dotnet";
  const args = [
    "--roll-forward",
    "Major",
    options.generatorPath,
    options.outputFolder,
    "-g",
    options.generatorName
  ];
  if (options.newProject) {
    args.push("--new-project");
  }
  if (options.debug) {
    args.push("--debug");
  }

  context.logger.info(`${command} ${args.join(" ")}`);
  const child = spawn(command, args, { stdio: "pipe" });
  const stderr: Buffer[] = [];

  return new Promise((resolvePromise, reject) => {
    let buffer = "";
    child.stdout?.on("data", (data: Buffer) => {
      buffer += data.toString();
      let index = buffer.indexOf("\n");
      while (index !== -1) {
        const message = buffer.slice(0, index);
        buffer = buffer.slice(index + 1);
        processJsonRpc(context, message);
        index = buffer.indexOf("\n");
      }
    });
    child.stderr?.on("data", (data: Buffer) => {
      stderr.push(data);
    });
    child.on("error", reject);
    child.on("exit", (exitCode) => {
      resolvePromise({
        exitCode: exitCode ?? -1,
        stderr: Buffer.concat(stderr).toString(),
        proc: child
      });
    });
  });
}

interface GeneratorRpcMessage {
  method?: string;
  params?: Record<string, unknown>;
}

function processJsonRpc(context: CSharpEmitterContext, message: string): void {
  if (message.length === 0) {
    return;
  }

  const response = JSON.parse(message) as GeneratorRpcMessage;
  const params = response.params;
  if (params === undefined) {
    return;
  }

  switch (response.method) {
    case "trace":
      context.logger.trace(
        toLoggerLevel(params.level),
        String(params.message ?? "")
      );
      break;
    case "diagnostic":
      context.program.reportDiagnostic({
        code: String(params.code ?? "general-error"),
        message: String(params.message ?? ""),
        severity:
          params.severity === "warning" || params.severity === "error"
            ? params.severity
            : "error",
        target: findDiagnosticTarget(context, params)
      });
      break;
  }
}

type ResolvedCSharpEmitterOptions = ReturnType<typeof resolveOptions>;

interface GeneratorConfiguration {
  "package-name": string;
  "unreferenced-types-handling"?:
    | "removeOrInternalize"
    | "internalize"
    | "keepAll";
  "disable-xml-docs"?: boolean;
  license?: unknown;
  [key: string]: unknown;
}

function createServerConfiguration(
  options: ResolvedCSharpEmitterOptions,
  namespace: string,
  sdkContext: CSharpEmitterContext
): GeneratorConfiguration {
  const skipKeys = [
    "new-project",
    "sdk-context-options",
    "save-inputs",
    "generator-name",
    "debug",
    "logLevel",
    "api-version",
    "generate-protocol-methods",
    "generate-convenience-methods",
    "emitter-extension-path"
  ];
  const derivedOptions = Object.fromEntries(
    Object.entries(options).filter(([key]) => !skipKeys.includes(key))
  ) as Record<string, unknown>;

  return {
    ...derivedOptions,
    "package-name": options["package-name"] ?? namespace,
    "unreferenced-types-handling": options["unreferenced-types-handling"],
    "disable-xml-docs":
      options["disable-xml-docs"] === false
        ? undefined
        : options["disable-xml-docs"],
    license: sdkContext.sdkPackage.licenseInfo
  };
}

async function writeServerConfiguration(
  context: CSharpEmitterContext,
  configuration: GeneratorConfiguration,
  outputFolder: string
): Promise<void> {
  await context.program.host.writeFile(
    resolvePath(outputFolder, CONFIGURATION_FILE_NAME),
    `${JSON.stringify(configuration, null, 2)}\n`
  );
}

function toLoggerLevel(value: unknown): LoggerLevel {
  switch (value) {
    case LoggerLevel.DEBUG:
      return LoggerLevel.DEBUG;
    case LoggerLevel.VERBOSE:
      return LoggerLevel.VERBOSE;
    case LoggerLevel.INFO:
    default:
      return LoggerLevel.INFO;
  }
}

function findDiagnosticTarget(
  context: CSharpEmitterContext,
  params: Record<string, unknown>
): Type | typeof NoTarget {
  const crossLanguageDefinitionId =
    typeof params.crossLanguageDefinitionId === "string"
      ? params.crossLanguageDefinitionId
      : undefined;
  if (crossLanguageDefinitionId === undefined) {
    return NoTarget;
  }

  return (
    context.__typeCache.crossLanguageDefinitionIds.get(
      crossLanguageDefinitionId
    ) ?? NoTarget
  );
}
