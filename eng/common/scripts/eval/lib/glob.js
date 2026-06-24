// Tiny dependency-free glob used by the eval matrix discovery.
//
// Vally has no `list` command, so scenario discovery is a filesystem glob of the
// same paths the suite uses. The default eval patterns only need `*` (single path
// segment) and `**` (any number of segments); we implement exactly that so the
// script has zero npm dependencies on the build agent.

import fs from "node:fs";
import path from "node:path";

// Convert one glob path-segment (no slashes) to an anchored RegExp.
//   *  -> any run of non-separator chars
//   ?  -> exactly one non-separator char
// All other regex metacharacters are escaped so they match literally.
function segmentToRegExp(segment) {
  const escaped = segment
    .replace(/[.+^${}()|[\]\\]/g, "\\$&")
    .replace(/\*/g, "[^/]*")
    .replace(/\?/g, "[^/]");
  return new RegExp(`^${escaped}$`);
}

function walk(dir, segments, out) {
  if (segments.length === 0) {
    return;
  }
  const [head, ...rest] = segments;

  let entries;
  try {
    entries = fs.readdirSync(dir, { withFileTypes: true });
  } catch {
    // Missing/inaccessible directory: no matches (mirrors PowerShell's
    // -ErrorAction SilentlyContinue on Get-ChildItem).
    return;
  }

  // `**` matches zero or more directory levels.
  if (head === "**") {
    walk(dir, rest, out); // zero levels: try the remainder right here
    for (const entry of entries) {
      if (entry.isDirectory()) {
        walk(path.join(dir, entry.name), segments, out); // one+ levels
      }
    }
    return;
  }

  const matcher = segmentToRegExp(head);
  for (const entry of entries) {
    if (!matcher.test(entry.name)) {
      continue;
    }
    const full = path.join(dir, entry.name);
    if (rest.length === 0) {
      if (entry.isFile()) {
        out.push(full);
      }
    } else if (entry.isDirectory()) {
      walk(full, rest, out);
    }
  }
}

/**
 * Returns the absolute paths of files under `root` matching the forward-slashed
 * glob `pattern`. Results are sorted for deterministic ordering.
 *
 * @param {string} root Absolute or relative base directory to glob from.
 * @param {string} pattern Forward-slashed glob relative to `root` (e.g. "evals/tools/*.eval.yaml").
 * @returns {string[]} Sorted absolute file paths.
 */
export function globFiles(root, pattern) {
  const segments = pattern.split("/").filter(Boolean);
  const out = [];
  walk(path.resolve(root), segments, out);
  return out.sort();
}
