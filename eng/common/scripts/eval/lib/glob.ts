// Tiny dependency-free glob used by the eval matrix discovery. Supports `*` (one path
// segment), `?` (one char), and `**` (any number of segments).

import fs from "node:fs";
import path from "node:path";

// Convert one glob path-segment (no slashes) to an anchored RegExp.
//   *  -> any run of non-separator chars
//   ?  -> exactly one non-separator char
// All other regex metacharacters are escaped so they match literally.
function segmentToRegExp(segment: string): RegExp {
  const escaped = segment
    .replace(/[.+^${}()|[\]\\]/g, "\\$&")
    .replace(/\*/g, "[^/]*")
    .replace(/\?/g, "[^/]");
  return new RegExp(`^${escaped}$`);
}

/** Match an inventoried file path using the same segment rules as globFiles. */
export function matchesGlob(file: string, pattern: string): boolean {
  const names = file.split("/");
  const segments = pattern.split("/").filter(Boolean);
  function match(nameIndex: number, segmentIndex: number): boolean {
    if (segmentIndex === segments.length || nameIndex === names.length) {
      return segmentIndex === segments.length && nameIndex === names.length;
    }
    const segment = segments[segmentIndex];
    if (segment === "**") {
      // The filesystem walker never emits files for a terminal ** directory glob.
      return segmentIndex + 1 < segments.length &&
        (match(nameIndex, segmentIndex + 1) || match(nameIndex + 1, segmentIndex));
    }
    return segmentToRegExp(segment).test(names[nameIndex]) && match(nameIndex + 1, segmentIndex + 1);
  }
  return match(0, 0);
}

function walk(dir: string, segments: string[], out: string[]): void {
  if (segments.length === 0) {
    return;
  }
  const [head, ...rest] = segments;

  let entries;
  try {
    entries = fs.readdirSync(dir, { withFileTypes: true });
  } catch {
    // Missing/inaccessible directory: no matches.
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
 * @param {string} pattern Forward-slashed glob relative to `root` (e.g. "tools/*.eval.yaml").
 * @returns {string[]} Sorted absolute file paths.
 */
export function globFiles(root: string, pattern: string): string[] {
  const segments = pattern.split("/").filter(Boolean);
  const out: string[] = [];
  walk(path.resolve(root), segments, out);
  return out.sort();
}
