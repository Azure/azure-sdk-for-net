#!/usr/bin/env node

import fs from "node:fs";
import path from "node:path";

const [command, project = "."] = process.argv.slice(2);
const root = path.resolve(project);
if (
  command !== "compile" ||
  !fs.existsSync(path.join(root, "main.tsp")) ||
  !fs.existsSync(path.join(root, "tspconfig.yaml"))
) {
  console.error("Expected: tsp compile . from the staged TypeSpec project.");
  process.exit(1);
}

console.log(
  `TypeSpec compilation succeeded for ${root} (hermetic eval fixture).`,
);
