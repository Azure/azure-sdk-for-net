// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

/**
 * Foundry State Storage — formal TypeSpec contract.
 *
 * Companion to the prose spec `foundry-state-storage-provider-spec.md` in
 * coreai-microsoft/foundrysdk_specs: this is the same `/storage/state_stores/*`
 * surface expressed as a compilable TypeSpec contract. It is the source for
 * the generated request/response model classes under
 * `azure/ai/agentserver/core/storage/_generated/` (see `Makefile` /
 * `type_spec/README.md` in this package for the local generation workflow).
 *
 * Authentication, base URL / API version, and the error envelope are
 * inherited from the parent `foundry-storage-protocol-spec.md` (§2, §3, §8)
 * and are stubbed locally below just enough to make this file self-contained.
 *
 * Status: this contract does not (yet) live under Azure/azure-rest-api-specs
 * the way sibling agentserver contracts (e.g. `sdk-service-agentserver-contracts`,
 * consumed by `azure-ai-agentserver-responses`) do — there is no
 * `state-stores` directory there yet. Until it lands upstream, models are
 * generated locally from this file directly (`make generate-models`) rather
 * than synced via `tsp-client`. Once the contract is published under
 * `specification/ai-foundry/data-plane/Foundry/src/state-stores/`, this file
 * should be replaced by a `tsp-location.yaml` pointing there, matching the
 * `azure-ai-agentserver-responses` pattern.
 *
 * Not public-facing (for now): this is an internal platform<->container wire
 * API. Agent code reaches it only through an SDK state-provider layer (see
 * `azure.ai.agentserver.core.storage.FoundryStateStore`).
 */

import "@typespec/http";

using TypeSpec.Http;

@service(#{ title: "Foundry State Storage" })
namespace Azure.AI.AgentServer.Core.Storage;

// ---------------------------------------------------------------------------
// Shared / inherited-from-parent stubs (kept minimal; see parent spec §2/§8).
// ---------------------------------------------------------------------------

/** Unix epoch seconds, as returned in `created_at` / `updated_at`. */
scalar FoundryTimestamp extends int64;

/** Standard Foundry error envelope (parent spec §8.1). */
@error
model ApiErrorResponse {
  error: ApiError;
}

model ApiError {
  @doc("Machine-readable error code.")
  code: string;

  @doc("Human-readable error message.")
  message: string;

  @doc("For 400 responses, the name of the offending request field.")
  param?: string;
}

/** A generic paged-list envelope, shared by store list and item list-keys. */
@doc("A page of results, ordered by `created_at` (parent spec §7).")
model ListResponse<T> {
  @doc("Always `\"list\"`.")
  object: "list";

  @doc("The page of results.")
  data: T[];

  @doc("The `id` of the first item in `data`, or `null` if `data` is empty.")
  first_id: string | null;

  @doc("The `id` of the last item in `data`, or `null` if `data` is empty.")
  last_id: string | null;

  @doc("Whether another page is available after `last_id`.")
  has_more: boolean;
}

/** Shared list query parameters (parent spec §7): limit, order, and cursor paging. */
model ListQueryParams {
  @query
  @doc("Maximum number of results to return.")
  @minValue(1)
  @maxValue(100)
  limit?: int32 = 20;

  @query
  @doc("Sort order over `created_at`.")
  order?: "asc" | "desc" = "desc";

  @query
  @doc("Cursor: return results after this id. Mutually exclusive with `before`.")
  after?: string;

  @query
  @doc("Cursor: return results before this id. Mutually exclusive with `after`.")
  before?: string;
}

/**
 * Trusted-only delegation header: supplies the resolved `user_id` for a
 * user-isolated store's item operations (spec §3). Honored only for trusted
 * (S2S/managed-identity) callers; ignored otherwise (falls back to
 * `hash(oid, tid)`).
 */
model DelegatedUserIdHeader {
  @header("x-ms-user-id")
  xMsUserId?: string;
}

/** Optional single-item optimistic-concurrency header (spec §4.2). */
model IfMatchHeader {
  @doc("`\"<etag>\"` for a conditional write/delete, or `\"*\"` to require the item already exists. Omit for unconditional last-write-wins.")
  @header("If-Match")
  ifMatch?: string;
}

/** The `ETag` response header carrying an item's current concurrency token. */
model ETagHeader {
  @header("ETag")
  etag?: string;
}

// ---------------------------------------------------------------------------
// 4.1 State Store Resource
// ---------------------------------------------------------------------------

/** A first-class, explicitly-created durable key-value store (spec §2, §4.1). */
model StateStore {
  @doc("Server-assigned, read-only. Not used for addressing (the `name` is).")
  id: string;

  @doc("Always `\"state_store\"`.")
  object: "state_store";

  @doc("Caller-chosen logical name. Unique within [project_id, agent_guid]. May contain `/` as a hierarchy separator. Immutable.")
  @minLength(1)
  @maxLength(128)
  name: string;

  @doc("Whether item operations are partitioned per resolved user (spec §3). Omitted at create -> `false`. Immutable.")
  user_isolation: boolean = false;

  @doc("Store-wide default TTL (seconds) inherited by every item, write-sliding per item. `-1` = never expire. Immutable.")
  @minValue(-1)
  @maxValue(2147483647)
  item_ttl_seconds: int32 = 2592000;

  @doc("Optional free-form description. Mutable via `updateStateStore`.")
  @maxLength(1024)
  description?: string;

  @doc("Optional string-to-string labels. Mutable (replaced wholesale) via `updateStateStore`.")
  tags?: Record<string>;

  @doc("Creation time.")
  created_at: FoundryTimestamp;

  @doc("Last metadata-update time.")
  updated_at: FoundryTimestamp;
}

/** Request body for `createStateStore` (spec §4.1.1). */
model CreateStateStoreRequest {
  @doc("Required. Unique within [project_id, agent_guid].")
  @minLength(1)
  @maxLength(128)
  name: string;

  @doc("Optional. Omitted -> `false` (agent-level, shared). Fixed at create.")
  user_isolation?: boolean = false;

  @doc("Optional. Default 30 days (2592000). `-1` = never expire. Fixed at create.")
  @minValue(-1)
  @maxValue(2147483647)
  item_ttl_seconds?: int32 = 2592000;

  @maxLength(1024)
  description?: string;

  tags?: Record<string>;
}

/**
 * Request body for `updateStateStore` (spec §4.1.3). Both fields optional;
 * a present field replaces the stored value (tags replaced wholesale, not
 * merged); an omitted field is left unchanged. `name`, `user_isolation`, and
 * `item_ttl_seconds` are immutable -- supplying them is rejected with `400`.
 */
model UpdateStateStoreRequest {
  @maxLength(1024)
  description?: string;

  tags?: Record<string>;
}

/** Response for `deleteStateStore` (spec §4.1.5). Idempotent. */
model DeletedStateStore {
  @doc("Present when the store existed; absent when the delete was a no-op (already gone).")
  id?: string;

  @doc("Always `\"state_store\"`.")
  object: "state_store";

  name: string;

  @doc("Always `true`.")
  deleted: boolean;
}

// ---------------------------------------------------------------------------
// 4.2 Item Resource
// ---------------------------------------------------------------------------

/** A single `key -> value` record within a state store (spec §2, §4.2). */
model StateStoreItem {
  @doc("Server-assigned, read-only. Not used for addressing (the `key` is.)")
  id: string;

  @doc("Always `\"state_store.item\"`.")
  object: "state_store.item";

  @doc("Logical key, unique within the store. May contain `/`.")
  @minLength(1)
  @maxLength(128)
  key: string;

  @doc("Opaque JSON object; stored and returned verbatim. <= 1 MB serialized inline.")
  value: Record<unknown>;

  @doc("Optional labels used to filter `listKeys`. Replaced wholesale on write.")
  tags?: Record<string>;

  @doc("Optimistic-concurrency token for this item; also echoed in the `ETag` response header.")
  etag: string;

  created_at: FoundryTimestamp;
  updated_at: FoundryTimestamp;
}

/** Request body for `createItem` (spec §4.2.1) — fails with `409` on a duplicate key. */
model CreateItemRequest {
  @minLength(1)
  @maxLength(128)
  key: string;

  value: Record<unknown>;

  tags?: Record<string>;
}

/** Request body for `putItem` (spec §4.2.2) — idempotent create-or-replace by key. */
model PutItemRequest {
  value: Record<unknown>;

  tags?: Record<string>;
}

/**
 * Response for `createItem` / `putItem` (spec §4.2.1/§4.2.2) — server
 * metadata only, no `value` echoed back.
 */
model StateStoreItemRef {
  id: string;

  @doc("Always `\"state_store.item\"`.")
  object: "state_store.item";

  key: string;

  etag: string;

  created_at: FoundryTimestamp;
  updated_at: FoundryTimestamp;
}

/** Response for `deleteItem` (spec §4.2.4). Idempotent. */
model DeletedStateStoreItem {
  @doc("Present when the item existed; absent when the delete was a no-op (already gone).")
  id?: string;

  @doc("Always `\"state_store.item\"`.")
  object: "state_store.item";

  key: string;

  @doc("Always `true`.")
  deleted: boolean;
}

/** A keys-only projection entry returned by `listKeys` (spec §4.2.5) -- never includes `value`. */
model StateStoreItemKey {
  id: string;

  @doc("Always `\"state_store.item\"`.")
  object: "state_store.item";

  key: string;

  tags?: Record<string>;

  etag: string;

  created_at: FoundryTimestamp;
  updated_at: FoundryTimestamp;
}

// ---------------------------------------------------------------------------
// 4. Endpoints
// ---------------------------------------------------------------------------

@route("/storage/state_stores")
interface StateStores {
  /** Create — spec §4.1.1. `201` on success, `409` if `name` already exists. */
  @post
  create(@body body: CreateStateStoreRequest): {
    @statusCode statusCode: 201;
    @body store: StateStore;
  } | {
    @statusCode statusCode: 409;
    @body error: ApiErrorResponse;
  };

  /** List — spec §4.1.4. Single-partition query over the store catalog. */
  @get
  list(...ListQueryParams): {
    @statusCode statusCode: 200;
    @body page: ListResponse<StateStore>;
  };

  /** Read — spec §4.1.2. `404` if no such store exists. */
  @get
  @route("{state_store}")
  read(@path state_store: string): {
    @statusCode statusCode: 200;
    @body store: StateStore;
  } | {
    @statusCode statusCode: 404;
    @body error: ApiErrorResponse;
  };

  /**
   * Update — spec §4.1.3. Mutable metadata only (`description` / `tags`);
   * `400` if the caller tries to change an immutable field.
   */
  @patch
  @route("{state_store}")
  update(@path state_store: string, @body body: UpdateStateStoreRequest): {
    @statusCode statusCode: 200;
    @body store: StateStore;
  } | {
    @statusCode statusCode: 404;
    @body error: ApiErrorResponse;
  } | {
    @statusCode statusCode: 400;
    @body error: ApiErrorResponse;
  };

  /**
   * Delete (cascade) — spec §4.1.5. Removes the store descriptor and every
   * item under it. Idempotent: deleting an absent store still returns `200`.
   */
  @delete
  @route("{state_store}")
  delete(@path state_store: string): {
    @statusCode statusCode: 200;
    @body deleted: DeletedStateStore;
  };
}

@route("/storage/state_stores/{state_store}/items")
interface StateStoreItems {
  /**
   * Create — spec §4.2.1. Fails with `409` on a duplicate `key`; `404` if the
   * store does not exist (there is no implicit store creation).
   */
  @post
  create(@path state_store: string, @body body: CreateItemRequest, ...DelegatedUserIdHeader): {
    @statusCode statusCode: 201;
    @body item: StateStoreItemRef;
  } | {
    @statusCode statusCode: 409;
    @body error: ApiErrorResponse;
  } | {
    @statusCode statusCode: 404;
    @body error: ApiErrorResponse;
  };

  /**
   * List keys — spec §4.2.5 (`items:keys` custom method). Never returns
   * `value`; ordered by write time within the single partition.
   */
  @get
  @route("{state_store}/items:keys")
  listKeys(
    @path state_store: string,
    ...ListQueryParams,
    @doc("Optional, repeatable tag-equality filter, e.g. `tags.version=1`. AND-combined; omit to list every key.")
    @query
    tags?: Record<string>,
    ...DelegatedUserIdHeader
  ): {
    @statusCode statusCode: 200;
    @body page: ListResponse<StateStoreItemKey>;
  };

  /**
   * Update (create-or-replace) — spec §4.2.2. Idempotent `PUT` by key;
   * `If-Match` gives optimistic concurrency (`412` on mismatch); each write
   * re-slides the item's inherited TTL. `404` if the store does not exist.
   */
  @put
  @route("{state_store}/items/{key}")
  put(
    @path state_store: string,
    @path key: string,
    @body body: PutItemRequest,
    ...IfMatchHeader,
    ...DelegatedUserIdHeader
  ): {
    @statusCode statusCode: 201;
    ...ETagHeader;
    @body item: StateStoreItemRef;
  } | {
    @statusCode statusCode: 200;
    ...ETagHeader;
    @body item: StateStoreItemRef;
  } | {
    @statusCode statusCode: 412;
    ...ETagHeader;
    @body error: ApiErrorResponse;
  } | {
    @statusCode statusCode: 404;
    @body error: ApiErrorResponse;
  };

  /** Get — spec §4.2.3. `404` if the key has never been written (a normal empty result). */
  @get
  @route("{state_store}/items/{key}")
  get(@path state_store: string, @path key: string, ...DelegatedUserIdHeader): {
    @statusCode statusCode: 200;
    ...ETagHeader;
    @body item: StateStoreItem;
  } | {
    @statusCode statusCode: 404;
    @body error: ApiErrorResponse;
  };

  /**
   * Delete — spec §4.2.4. `If-Match` gives a conditional delete (`412` on
   * mismatch); idempotent -- deleting a missing key still returns `200`.
   */
  @delete
  @route("{state_store}/items/{key}")
  delete(
    @path state_store: string,
    @path key: string,
    ...IfMatchHeader,
    ...DelegatedUserIdHeader
  ): {
    @statusCode statusCode: 200;
    @body deleted: DeletedStateStoreItem;
  } | {
    @statusCode statusCode: 412;
    ...ETagHeader;
    @body error: ApiErrorResponse;
  };
}
