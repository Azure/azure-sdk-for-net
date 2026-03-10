// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * Returns true if the segment is a variable segment like {subscriptionId}
 * @param segment the segment
 * @returns
 */
export function isVariableSegment(segment: string): boolean {
  return segment.startsWith("{") && segment.endsWith("}");
}

/**
 * Returns true if left path is a prefix of right path
 * @param left the first path
 * @param right the second path
 * @returns
 */
export function isPrefix(left: string, right: string): boolean {
  const leftSegments = left.split("/").filter((s) => s.length > 0);
  const rightSegments = right.split("/").filter((s) => s.length > 0);
  const sharedCount = getSharedSegmentCount(left, right);
  return (
    sharedCount === leftSegments.length && sharedCount <= rightSegments.length
  );
}

/**
 * Returns the number of shared segments between two paths. Variable segments are considered as matches.
 * @param left the first path
 * @param right the second path
 * @returns
 */
export function getSharedSegmentCount(left: string, right: string): number {
  const leftSegments = left.split("/").filter((s) => s.length > 0);
  const rightSegments = right.split("/").filter((s) => s.length > 0);
  let count = 0;
  const minLength = Math.min(leftSegments.length, rightSegments.length);
  for (let i = 0; i < minLength; i++) {
    // if both are variables, we consider it as a match
    if (
      isVariableSegment(leftSegments[i]) &&
      isVariableSegment(rightSegments[i])
    ) {
      count++;
    } else if (leftSegments[i] === rightSegments[i]) {
      count++;
    } else {
      break;
    }
  }
  return count;
}

/**
 * Counts the number of "providers" segments in a path.
 * Direct resources have 1, extension resources have 2+.
 * E.g., ".../providers/Microsoft.Compute/.../providers/Microsoft.GuestConfiguration/..." returns 2.
 */
export function countProviderSegments(path: string): number {
  const segments = path.split("/").filter((s) => s !== "");
  return segments.filter((s) => s === "providers").length;
}

/**
 * Extracts the resource type path after the last provider namespace in a path.
 * The trailing variable segment (resource name), if present, is stripped.
 * Variables in intermediate positions are normalized to "{}" for comparison.
 *
 * Examples:
 *   ".../providers/Microsoft.Maintenance/configurationAssignments"
 *     → "configurationAssignments"
 *   ".../providers/Microsoft.Maintenance/configurationAssignments/{name}"
 *     → "configurationAssignments"
 *   ".../providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{name}"
 *     → "locations/{}/deletedVaults"
 *   ".../providers/Microsoft.KeyVault/deletedVaults"
 *     → "deletedVaults"
 */
export function getResourceTypePath(path: string): string | undefined {
  const lastProviderIdx = path.lastIndexOf("/providers/");
  if (lastProviderIdx === -1) return undefined;

  const afterProviders = path
    .substring(lastProviderIdx + "/providers/".length)
    .split("/")
    .filter((s) => s !== "");

  // First segment is the provider namespace (e.g., "Microsoft.KeyVault")
  if (afterProviders.length < 2) return undefined;

  // Type path = everything after the namespace
  const typeSegments = afterProviders.slice(1);

  // Strip trailing variable (resource name for ID patterns, not present for list paths)
  if (
    typeSegments.length > 0 &&
    isVariableSegment(typeSegments[typeSegments.length - 1])
  ) {
    typeSegments.pop();
  }
  if (typeSegments.length === 0) return undefined;

  // Normalize variables to "{}" for comparison
  return typeSegments
    .map((s) => (isVariableSegment(s) ? "{}" : s.toLowerCase()))
    .join("/");
}

/**
 * Finds the candidate whose path is the longest prefix match against the target path.
 * @param targetPath the path to match against
 * @param candidates the list of candidates to search
 * @param getPath extracts the path from a candidate; return undefined to skip
 * @param properPrefix if true, requires the candidate path to be a proper prefix (not equal)
 * @returns the best matching candidate, or undefined if no match
 */
export function findLongestPrefixMatch<T>(
  targetPath: string,
  candidates: T[],
  getPath: (candidate: T) => string | undefined,
  properPrefix: boolean = false
): T | undefined {
  let bestMatch: T | undefined;
  let bestSegmentCount = 0;

  for (const candidate of candidates) {
    const candidatePath = getPath(candidate);
    if (!candidatePath) continue;
    if (!isPrefix(candidatePath, targetPath)) continue;
    if (properPrefix && isPrefix(targetPath, candidatePath)) continue;

    const segmentCount = getSharedSegmentCount(candidatePath, targetPath);
    if (segmentCount > bestSegmentCount) {
      bestSegmentCount = segmentCount;
      bestMatch = candidate;
    }
  }
  return bestMatch;
}
