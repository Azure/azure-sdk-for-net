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
 * Finds the candidate whose path is the longest prefix match against the target path.
 * @param targetPath the path to match against
 * @param candidates the list of candidates to search
 * @param getPath extracts the path from a candidate; return undefined to skip
 * @param properPrefix if true, requires the candidate path to be a proper prefix (not equal)
 * @returns the best matching candidate, or undefined if no match
 */
/**
 * Gets the resource type segment from a resource ID pattern.
 * The type segment is the second-to-last segment, since the last is the key variable.
 * E.g., for ".../configurationAssignments/{configurationAssignmentName}", returns "configurationAssignments".
 */
export function getResourceTypeSegment(
  resourceIdPattern: string
): string | undefined {
  const segments = resourceIdPattern.split("/").filter((s) => s !== "");
  if (segments.length < 2) return undefined;

  const lastSegment = segments[segments.length - 1];
  const typeCandidate = segments[segments.length - 2];

  // The last segment must be a variable (e.g., "{name}")
  if (!isVariableSegment(lastSegment)) return undefined;
  // The type segment itself must not be a variable
  if (isVariableSegment(typeCandidate)) return undefined;

  return typeCandidate;
}

/**
 * Gets the last segment of a path.
 * For list operation paths, this is the resource type/collection segment.
 * E.g., for ".../configurationAssignments", returns "configurationAssignments".
 */
export function getLastPathSegment(path: string): string | undefined {
  const segments = path.split("/").filter((s) => s !== "");
  if (segments.length === 0) return undefined;
  return segments[segments.length - 1];
}

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
