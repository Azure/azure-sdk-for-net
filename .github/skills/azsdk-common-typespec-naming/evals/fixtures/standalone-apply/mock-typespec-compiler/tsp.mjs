#!/usr/bin/env node

import fs from "node:fs";
import path from "node:path";

const [command, project = "."] = process.argv.slice(2);
const root = path.resolve(project);
const mainPath = path.join(root, "main.tsp");
const clientPath = path.join(root, "client.tsp");
const configPath = path.join(root, "tspconfig.yaml");
if (
  command !== "compile" ||
  !fs.existsSync(mainPath) ||
  !fs.existsSync(clientPath) ||
  !fs.existsSync(configPath)
) {
  console.error("Expected: tsp compile . from the staged TypeSpec project.");
  process.exit(1);
}

const main = fs.readFileSync(mainPath, "utf8");
const client = fs.readFileSync(clientPath, "utf8");
const checks = [
  {
    passed:
      /@@clientName\(\s*(?:Widget\.)?WidgetProperties\.enabled\s*,\s*["']IsEnabled["']\s*,\s*["']csharp["']\s*\)\s*;/.test(
        client,
      ),
    message:
      "client.tsp must contain the C# WidgetProperties.enabled -> IsEnabled override.",
  },
  {
    passed:
      /@@clientName\(\s*(?:Widget\.)?WidgetProperties\.enabled\s*,\s*["']EnabledForJava["']\s*,\s*["']java["']\s*\)\s*;/.test(
        client,
      ),
    message: "The existing Java override must be preserved.",
  },
  {
    passed:
      /@@clientName\(\s*(?:Widget\.)?WidgetProperties\.enabled\s*,\s*["']enabled_for_python["']\s*,\s*["']python["']\s*\)\s*;/.test(
        client,
      ),
    message: "The existing Python override must be preserved.",
  },
];

for (const check of checks) {
  if (!check.passed) {
    console.error(check.message);
    process.exit(1);
  }

  if (/clientName/.test(main)) {
    console.error("Naming-only customization must not modify main.tsp.");
    process.exit(1);
  }
}

console.log(
  `TypeSpec compilation succeeded for ${root} (hermetic eval fixture).`,
);
