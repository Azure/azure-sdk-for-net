# Resilience Contract — Test Coverage Matrix (.NET)

**Purpose**: Map every normative clause of the resilient-responses contract
(`docs/resilience-contract.md`, mirrored from Python
`specs/resilience-contract.md`) to the .NET conformance test that verifies it.
This is the .NET companion to the Python
`tests/e2e/resilience_contract/CONTRACT_COVERAGE.md`.

Each row is one normative claim. Columns:

- **Clause** — the claim, paraphrased with a section anchor.
- **Test** — the .NET conformance/protocol/unit test that verifies it, or the
  task ID that will add it.
- **Dimension** — the per-cell **assertion-depth** the test must reach for that
  clause. One or more of: `event sequence`, `event content`,
  `seq monotonicity`, `response.output content`, `response.status`,
  `response.error`, `metadata`, `chain id`, `composition guard`,
  `payload schema`, `dispatch`, `recovery drop`, `meta`. This column is the
  normative depth declaration enforced by
  `ContractCoverageCompletenessTests` (T080): every `covered` row MUST declare
  a non-empty depth here (see `docs/resilience-contract.md` §"Per-cell
  assertion depth").
- **Status** — `covered` (implemented + green) or `pending:<task>` (planned).
  The completeness meta-test (`ContractCoverageCompletenessTests`, T059) fails
  on any remaining `pending:` cell that is not explicitly whitelisted.

## Protocol primitives (implemented + green)

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Persisted recovery payload has exactly the 9 fields (`response_id`, `disposition`, `request`, `agent_reference`, `agent_session_id`, `user_id_key`, `call_id`, `client_headers`, `query_parameters`) | `RecoveryPayloadParityProtocolTests.ToTaskInput_EmitsExactlyTheNinePersistedFields` | payload schema | covered |
| Re-derived fields (`store`/`stream`/`background`/`model`/`previous_response_id`/`conversation_id`/`input_items`) are NOT persisted | `RecoveryPayloadParityProtocolTests.ToTaskInput_DoesNotPersistReDerivedFields` | payload schema | covered |
| Field types/casing/nullability match the schema (absent optionals persist as explicit `null`) | `RecoveryPayloadParityProtocolTests.ToTaskInput_FieldTypesAndCasingMatchSchema` | payload schema | covered |
| Payload round-trips losslessly | `RecoveryPayloadParityProtocolTests.RoundTrip_PreservesAllPersistedFields` | payload schema | covered |
| Client headers/query preserved verbatim (Spec 033 FR-002b, no drop-to-`{}`) | `RecoveryPayloadParityProtocolTests.ClientHeadersAndQueryParameters_PreservedVerbatimNotDroppedToEmpty` | payload schema | covered |
| Fail-closed: malformed/missing/wrong-type required fields fail deterministically before dispatch | `RecoveryPayloadFailClosedTests` (11 cases) | payload schema | covered |
| Missing `disposition` defaults to `re-invoke` (backward compat) | `RecoveryPayloadFailClosedTests.FromTaskInput_MissingDisposition_DefaultsToReinvoke` | dispatch | covered |
| Dispatch `classify_row` matches Python across the full truth table | `ResponseResilienceDispatchTests.ClassifyRow_MatchesPythonTruthTable` | dispatch | covered |
| Dispatch `decide_disposition` — only Row 1 re-invokes | `ResponseResilienceDispatchTests.DecideDisposition_MatchesPython` | dispatch | covered |
| `conversation_chain_id` per-case shapes (`cchain_`/`rchain_`/verbatim) + cross-language digest parity | `ConversationChainIdentityTests` (8 cases) | chain id | covered |
| `conversation_chain_id` stable across turns/attempts of one chain | `ConversationChainIdentityTests.SameConversation_DifferentResponseIds_ShareChainId` | chain id | covered |
| `ConversationChainMetadata` namespace isolation, `_`-reserved rejection, snapshot, base no-op flush | `ConversationChainMetadataTests` (11 cases) | metadata | covered |
| Internal metadata persist-but-strip (`internal_metadata` item-level, `_internal_metadata` response-level, empty→null) | `InternalMetadataContractTests` (8 cases) | metadata | covered |

## Per-row × per-path matrix

> These cells exercise the crash-recovery composition layer (recovery scan
> across process lifetimes, SIGKILL/SIGTERM harnesses) via the Core
> task/streaming primitives the Responses layer composes. Each row × path is
> backed by a dedicated conformance test in `tests/e2e/resilience_contract/`.

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Row 1 Path A natural terminal | `TestRow1PathABSignalTests.Row1PathA_HandlerReachesTerminalWithinGrace_Completes` | response.status | covered |
| Row 1 Path B graceful handoff → next-lifetime re-invoke | `TestRow1PathABSignalTests.Row1PathB_GraceExhausted_HandsOffToRecovery_StaysInProgress` | response.status | covered |
| Row 1 Path C SIGKILL → next-lifetime re-invoke (`IsRecovery=true`) | `TestRow1PathCRecoveryTests` | response.status | covered |
| Row 1 Path C + SSE keep-alive still recovers | `TestRow1StreamingRecoveryParityTests` | response.status; response.output content | covered |
| Row 2 Path A — background completes naturally (`completed`, no recovery entry) | `TestRow2Row3Row4PathTests.Row2PathA_BackgroundCompletesNaturally_Completed_NoRecoveryEntry` | response.status; meta | covered |
| Row 2 Path B/C — mark failed (`server_error`) | `TestRow2PathCCrashFailedTests`, `TestRow2Row3Row4PathTests.Row2PathB_NonResilientBackground_MarksFailed_NoRecoveryEntry` | response.status; response.error | covered |
| Row 3 Path A — foreground completes naturally (`completed`, no recovery entry) | `TestRow2Row3Row4PathTests.Row3PathA_ForegroundCompletesNaturally_Completed_NoRecoveryEntry` | response.status; meta | covered |
| Row 3 Path B/C — foreground mark failed | `TestRow2Row3Row4PathTests.Row3Foreground_ShutdownDuringHandler_MarksFailed_NoRecoveryEntry` | response.status; response.error | covered |
| Row 4 Path A/B/C — ephemeral, GET 404, no next-lifetime action | `TestRow2Row3Row4PathTests.Row4StoreFalse_Ephemeral_Get404_NoRecoveryEntry` | response.status; meta | covered |
| Row 11 C1/C3 checkpoint cutpoints | `TestRow11CheckpointCutpointTests` | event content; response.output content | covered |
| Row 11 C4/C5 checkpoint unit guarantees | `ResponseEventStreamCheckpointTests` | metadata | covered |

## Streaming sub-contract

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Append-to-resilient-stream before wire flush | `TestRow1StreamingReconnectTests` | event sequence | covered |
| `starting_after` strict-`>` reconnect + live-tail | `ReconnectResponsesEndpointTests`, `TestRow1StreamingReconnectTests` | event sequence | covered |
| Single `response.created` across lifetimes | `StreamingRecoveryContractTests` | event sequence | covered |
| Recovered `response.in_progress` reset carries corrected output | `TestRow1StreamingRecoveryParityTests` | event content | covered |
| Output-index slot reuse → replacement semantics | `TestRow1StreamingRecoveryParityTests` | event content; response.output content | covered |

## Recovery drop precondition

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Definitive not-found → dropped (no re-invoke, GET 404) | `TestRecoveryDropPreconditionTests` | recovery drop | covered |
| Transient store error → NOT dropped | `TestRecoveryDropPreconditionTests` | recovery drop | covered |

## Steering

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Queue envelope (`queued`) + `PendingInputCount` | `TestSteerableConversationContractTests.SteeredTurn_QueuedBehindActiveTurn_ReturnsQueuedEnvelope`, `TestSteerableConversationContractTests.RealComposition_ConcurrentSteeredTurn_EnqueuesThenDrains` (asserts live `PendingInputCount >= 1` + drained turn `IsSteeredTurn`) | response.status; PendingInputCount; IsSteeredTurn | covered |
| Fork 409 `conversation_fork_not_supported` | `TestSteerableConversationContractTests.StaleAntecedent_MapsToConversationForkNotSupported409` | response.error | covered |
| Overlap 409 `conversation_locked` | `TestSteerableConversationContractTests.ConcurrentTurn_NonSteerable_MapsToConversationLocked409`, `TestSteerableConversationContractTests.SteeringQueueFull_MapsToConversationLocked409` | response.error | covered |
| `IsSteeredTurn` drain re-entry | `TestSteerableConversationContractTests.RealComposition_ConcurrentSteeredTurn_EnqueuesThenDrains` | metadata | covered |

## Fail-loud composition

| Clause | Test | Dimension | Status |
|---|---|---|---|
| Startup refuses non-persistent store under `ResilientBackground` | `ResilienceStartupValidationTests` | composition guard | covered |
| Request-time non-stream start failure → 500 + `x-platform-error-source: platform` | `ResilientStartFailureProtocolTests` | response.error | covered |
| Request-time stream start failure (pre-stream) → 500 + `x-platform-error-source: platform` | `ResilientStartFailureProtocolTests` | response.error | covered |
