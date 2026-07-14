# Resilience Sample Parity (.NET ↔ Python)

This document records the mapping between the Python
`azure-ai-agentserver-responses` resilient samples and their .NET counterparts,
and the explicit rationale for the samples that are intentionally **not** ported.

## Required 1:1 ports

| Python sample | .NET sample | Options | Focus |
|---------------|-------------|---------|-------|
| `sample_19_resilient_streaming.py` | `samples/Sample19_ResilientStreaming.md` | `ResilientBackground = true` | Handler-managed phase checkpoints; resumption response from `ConversationChainMetadata`; `response.in_progress` reset. |
| `sample_20_resilient_steering.py` | `samples/Sample20_ResilientSteering.md` | `ResilientBackground = true`, `SteerableConversations = true` | Steering × cancellation × recovery composition; empty resumption response for non-deterministic upstreams. |
| `sample_22_resilient_multiturn.py` | `samples/Sample22_ResilientMultiTurn.md` | `ResilientBackground = true`, `SteerableConversations = false` | Serial multi-turn (perpetual task); per-turn counters in `ConversationChainMetadata`. |

## Intentionally omitted (with rationale)

| Python sample | Reason for omission |
|---------------|---------------------|
| `sample_18_resilient_copilot.py` | Wraps the GitHub Copilot SDK — a third-party integration outside the .NET resilience surface. The generic resilience pattern it layers on is covered by samples 19/20/22. |
| `sample_21_resilient_langgraph.py` | Wraps LangGraph (Python-specific orchestration framework) with no .NET equivalent. The `ConversationChainId`-as-thread-id pattern it demonstrates is covered conceptually by the developer guide. |

## No `sample_17_*` source item (non-fabrication rule)

The Python samples directory jumps from `sample_16_structured_outputs.py`
directly to `sample_18_resilient_copilot.py`. Samples 19 and 20 reference a
"`sample_17` for Claude" in their docstrings, but **no `sample_17_*` file exists**
at the pinned commit (`3df89fec8d5d6ff072889a2cf9dd1723c019976a`). This is a
known off-by-one prose artifact on the Python side.

**.NET rule:** we do **not** fabricate a `Sample17_*` port. There is no source
to mirror. If the Python side later adds `sample_17_*`, a matching .NET port
should be added at that time and this note updated. Tracked as a Python-side
observation in `tests/e2e/resilience_contract/PARITY_REPORT.md`.
