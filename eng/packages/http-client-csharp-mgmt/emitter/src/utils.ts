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

  /** Serializes to the raw path string (used by JSON.stringify) */
  toJSON(): string {
    return this.path;
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
   * Returns true if this path is structurally equal to the other path.
   * Variable segments are considered matching regardless of their names,
   * e.g., "/subscriptions/{sub}" equals "/subscriptions/{subscriptionId}".
   */
  equals(other: RequestPath): boolean {
    if (this.length !== other.length) return false;
    for (let i = 0; i < this.length; i++) {
      if (
        isVariableSegment(this.segments[i]) &&
        isVariableSegment(other.segments[i])
      ) {
        continue;
      }
      if (this.segments[i] !== other.segments[i]) return false;
    }
    return true;
  }

  /**
   * Gets the scope path — the portion of the path before the last "/providers/" segment.
   * E.g., for ".../providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/...",
   * the scope is ".../providers/Microsoft.Compute/virtualMachines/{vmName}".
   * Returns undefined if the path has no "/providers/" segment.
   */
  get scopePath(): RequestPath | undefined {
    const providerIndex = this.path.lastIndexOf(ProvidersPrefix);
    if (providerIndex < 0) return undefined;
    return new RequestPath(this.path.substring(0, providerIndex));
  }

  /**
   * Returns true if this path has the same scope nesting structure as the other path.
   * Two paths are scope-compatible if their scope chains have the same depth:
   * both have no scope (no /providers/), or both have scopes that are themselves scope-compatible.
   *
   * This correctly distinguishes:
   * - RG-scoped vs MG-scoped resources (different scope chain shapes)
   * - Direct RG resources vs extension resources nested under RG (different depths)
   * while still allowing structural parent-length mismatches within the same scope level
   * (e.g., extension resource list endpoints with fewer parent segments).
   */
  hasSameScopeNesting(other: RequestPath): boolean {
    const scopeA = this.scopePath;
    const scopeB = other.scopePath;
    if (scopeA === undefined && scopeB === undefined) return true;
    if (scopeA === undefined || scopeB === undefined) return false;
    return scopeA.hasSameScopeNesting(scopeB);
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
    if (
      this.scopePath !== undefined &&
      this.scopePath.scopePath !== undefined
    ) {
      return ResourceScope.Extension;
    }

    return ResourceScope.Tenant;
  }

  /**
   * Returns a new RequestPath with the last segment removed (the "parent" or "collection" path).
   * E.g., for ".../virtualMachines/{vmName}", returns ".../virtualMachines".
   * Returns undefined if the path has no segments.
   */
  get parentPath(): RequestPath | undefined {
    if (this.length === 0) return undefined;
    const lastSlash = this.path.lastIndexOf("/");
    return lastSlash > 0
      ? new RequestPath(this.path.substring(0, lastSlash))
      : undefined;
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
 * Finds the candidate whose path is the longest prefix match against the target path.
 * @param targetPath the path to match against
 * @param candidates the list of candidates to search
 * @param getPath extracts the path from a candidate; return undefined to skip
 * @param properPrefix if true, requires the candidate path to be a proper prefix (not equal)
 * @returns the best matching candidate, or undefined if no match
 */
export function findLongestPrefixMatch<T>(
  targetPath: RequestPath,
  candidates: T[],
  getPath: (candidate: T) => RequestPath | undefined,
  properPrefix: boolean = false
): T | undefined {
  let bestMatch: T | undefined;
  let bestSegmentCount = 0;

  for (const candidate of candidates) {
    const candidatePath = getPath(candidate);
    if (!candidatePath) continue;
    if (!candidatePath.isPrefixOf(targetPath)) continue;
    if (properPrefix && targetPath.isPrefixOf(candidatePath)) continue;

    const segmentCount = candidatePath.getSharedSegmentCount(targetPath);
    if (segmentCount > bestSegmentCount) {
      bestSegmentCount = segmentCount;
      bestMatch = candidate;
    }
  }
  return bestMatch;
}
