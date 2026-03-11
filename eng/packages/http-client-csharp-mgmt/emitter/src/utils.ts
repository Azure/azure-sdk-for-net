// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ResourceScope } from "./resource-metadata.js";

/**
 * Returns true if the segment is a variable segment like {subscriptionId}
 * @param segment the segment
 * @returns
 */
export function isVariableSegment(segment: string): boolean {
  return segment.startsWith("{") && segment.endsWith("}");
}

const providersLiteral = "providers";

/**
 * Represents a parsed ARM request path with pre-computed segment information.
 *
 * This class parses a path string (e.g., "/subscriptions/{subscriptionId}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}")
 * once and caches the resulting segments, avoiding repeated `.split("/")` calls throughout the codebase.
 *
 * Inspired by the C# generator's RequestPathPattern class, it consolidates path parsing,
 * prefix matching, scope detection, and resource type extraction in a single place.
 */
export class RequestPath {
  /** The non-empty path segments (e.g., ["subscriptions", "{subscriptionId}", "providers", ...]) */
  public readonly segments: readonly string[];

  /** The original raw path string */
  public readonly path: string;

  constructor(path: string) {
    this.path = path;
    this.segments = path.split("/").filter((s) => s.length > 0);
  }

  /** Number of segments in this path */
  get length(): number {
    return this.segments.length;
  }

  /**
   * Returns true if this path is a prefix of the other path.
   * Variable segments are considered as matches regardless of their names.
   */
  isPrefixOf(other: RequestPath): boolean {
    const sharedCount = this.getSharedSegmentCount(other);
    return sharedCount === this.length && sharedCount <= other.length;
  }

  /**
   * Returns the number of leading segments shared with another path.
   * Variable segments are considered as matches regardless of their names.
   */
  getSharedSegmentCount(other: RequestPath): number {
    let count = 0;
    const minLength = Math.min(this.length, other.length);
    for (let i = 0; i < minLength; i++) {
      if (
        isVariableSegment(this.segments[i]) &&
        isVariableSegment(other.segments[i])
      ) {
        count++;
      } else if (this.segments[i] === other.segments[i]) {
        count++;
      } else {
        break;
      }
    }
    return count;
  }

  /**
   * Extracts the singleton resource name from this path, if it exists.
   * A path ending with a fixed (non-variable) segment indicates a singleton resource.
   */
  get singletonName(): string | undefined {
    const lastSeg =
      this.length > 0 ? this.segments[this.length - 1] : undefined;
    if (lastSeg && !isVariableSegment(lastSeg)) {
      return lastSeg;
    }
    return undefined;
  }

  /**
   * Counts the number of "providers" segments in this path.
   * Direct resources have 1, extension resources have 2+.
   */
  get providerSegmentCount(): number {
    let count = 0;
    for (const seg of this.segments) {
      if (seg === providersLiteral) {
        count++;
      }
    }
    return count;
  }

  /** Returns true if this path has multiple /providers/ segments, indicating an extension resource. */
  get hasMultipleProviderSegments(): boolean {
    return this.providerSegmentCount > 1;
  }

  /**
   * Gets the scope path — the portion of the path before the last "/providers/" segment.
   * E.g., for "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/...",
   * returns "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}".
   * Returns undefined if the path has no "/providers/" segment.
   */
  get scopePath(): string | undefined {
    const providerIndex = this.path.lastIndexOf(ProvidersPrefix);
    if (providerIndex < 0) return undefined;
    return this.path.substring(0, providerIndex);
  }

  /**
   * Extracts the ARM resource type from this path.
   * E.g., for ".../providers/Microsoft.Compute/virtualMachines/{vmName}", returns "Microsoft.Compute/virtualMachines".
   *
   * For paths without a "/providers/" segment, returns well-known resource types
   * for resourceGroups, subscriptions, and tenants.
   */
  get resourceType(): string {
    const providerIndex = this.path.lastIndexOf(ProvidersPrefix);
    if (providerIndex === -1) {
      if (this.path.startsWith(ResourceGroupScopePrefix)) {
        return "Microsoft.Resources/resourceGroups";
      } else if (this.path.startsWith(SubscriptionScopePrefix)) {
        return "Microsoft.Resources/subscriptions";
      } else if (this.path.startsWith(TenantScopePrefix)) {
        return "Microsoft.Resources/tenants";
      }
      throw `Path ${this.path} doesn't have resource type`;
    }

    return this.path
      .substring(providerIndex + ProvidersPrefix.length)
      .split("/")
      .reduce((result, current, index) => {
        if (index === 1 || index % 2 === 0)
          return result === "" ? current : `${result}/${current}`;
        else return result;
      }, "");
  }

  /**
   * Determines the operation scope (Tenant, Subscription, ResourceGroup, ManagementGroup, Extension)
   * from the path structure.
   */
  get operationScope(): ResourceScope {
    // Match any path starting with a variable segment followed by /providers/
    // This covers scope-based operations like /{resourceUri}/providers/..., /{scope}/providers/..., etc.
    if (
      this.length >= 3 &&
      isVariableSegment(this.segments[0]) &&
      this.segments[1].toLowerCase() === providersLiteral
    ) {
      return ResourceScope.Extension;
    }

    // /subscriptions/{sub}/resourceGroups/{rg}/...
    if (
      this.length >= 4 &&
      this.segments[0] === "subscriptions" &&
      isVariableSegment(this.segments[1]) &&
      this.segments[2] === "resourceGroups" &&
      isVariableSegment(this.segments[3])
    ) {
      return ResourceScope.ResourceGroup;
    }

    // /subscriptions/{sub}/...
    if (
      this.length >= 2 &&
      this.segments[0] === "subscriptions" &&
      isVariableSegment(this.segments[1])
    ) {
      return ResourceScope.Subscription;
    }

    // /providers/Microsoft.Management/managementGroups/{groupId}/...
    if (
      this.length >= 4 &&
      this.segments[0].toLowerCase() === providersLiteral &&
      this.segments[1] === "Microsoft.Management" &&
      this.segments[2] === "managementGroups" &&
      isVariableSegment(this.segments[3])
    ) {
      return ResourceScope.ManagementGroup;
    }

    // Paths with multiple /providers/ segments indicate extension resources
    if (this.hasMultipleProviderSegments) {
      return ResourceScope.Extension;
    }

    return ResourceScope.Tenant;
  }

  toString(): string {
    return this.path;
  }
}

const ResourceGroupScopePrefix =
  "/subscriptions/{subscriptionId}/resourceGroups";
const SubscriptionScopePrefix = "/subscriptions";
const TenantScopePrefix = "/tenants";
const ProvidersPrefix = "/providers";

// ─── Legacy function wrappers ───────────────────────────────────────────────
// These functions delegate to RequestPath to maintain backward
// compatibility with call sites that pass raw path strings.

/**
 * Returns true if left path is a prefix of right path
 * @param left the first path
 * @param right the second path
 */
export function isPrefix(left: string, right: string): boolean {
  return new RequestPath(left).isPrefixOf(new RequestPath(right));
}

/**
 * Counts the number of "providers" segments in a path.
 * Direct resources have 1, extension resources have 2+.
 * E.g., ".../providers/Microsoft.Compute/.../providers/Microsoft.GuestConfiguration/..." returns 2.
 */
export function countProviderSegments(path: string): number {
  return new RequestPath(path).providerSegmentCount;
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
  const target = new RequestPath(targetPath);
  let bestMatch: T | undefined;
  let bestSegmentCount = 0;

  for (const candidate of candidates) {
    const candidatePathStr = getPath(candidate);
    if (!candidatePathStr) continue;
    const candidatePath = new RequestPath(candidatePathStr);
    if (!candidatePath.isPrefixOf(target)) continue;
    if (properPrefix && target.isPrefixOf(candidatePath)) continue;

    const segmentCount = candidatePath.getSharedSegmentCount(target);
    if (segmentCount > bestSegmentCount) {
      bestSegmentCount = segmentCount;
      bestMatch = candidate;
    }
  }
  return bestMatch;
}
