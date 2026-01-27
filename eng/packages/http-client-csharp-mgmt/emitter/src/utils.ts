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
