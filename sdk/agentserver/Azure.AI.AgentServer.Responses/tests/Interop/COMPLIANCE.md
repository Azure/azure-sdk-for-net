# OpenAI Responses API — Compliance Requirements

> Source of truth: [OpenAI OpenAPI spec v2.3.0](https://app.stainless.com/api/spec/documented/openai/openapi.documented.yml)
> (also cross-referenced against the OpenAI .NET SDK v2.9.1)

This document captures the wire-format contracts that our Responses server **must**
satisfy to remain drop-in compatible with the OpenAI SDK. Tests in this directory
enforce these contracts. **When a test fails, fix the service — not the test.**

---

## 1. CreateResponse Request Body

| Property | Type | Required | Default | Notes |
|---|---|---|---|---|
| `model` | string | No* | — | *Our server resolves via DefaultModel when omitted |
| `input` | `string \| InputItem[]` | No | — | String shorthand = single user message |
| `instructions` | string \| null | No | — | System/developer instructions |
| `tools` | Tool[] | No | — | Available tools |
| `tool_choice` | `"none" \| "auto" \| "required" \| object` | No | — | String shorthands expand to ToolChoiceAllowed |
| `temperature` | number(0–2) \| null | No | 1 | |
| `top_p` | number(0–1) \| null | No | 1 | |
| `max_output_tokens` | integer \| null | No | — | |
| `metadata` | map\<string,string\> \| null | No | — | |
| `store` | boolean \| null | No | true | |
| `stream` | boolean \| null | No | false | |
| `previous_response_id` | string \| null | No | — | |
| `parallel_tool_calls` | boolean \| null | No | true | |
| `truncation` | `"auto" \| "disabled"` \| null | No | `"disabled"` | |
| `reasoning` | Reasoning \| null | No | — | |
| `conversation` | `string \| { id: string }` \| null | No | — | |
| `text` | ResponseTextParam | No | — | |

## 2. Input Items

### 2.1 EasyInputMessage (`type: "message"`)

| Property | Type | Required | Default | OpenAI Spec Reference |
|---|---|---|---|---|
| `type` | `"message"` | **No** | `"message"` | Not in required array |
| `role` | `"user" \| "assistant" \| "system" \| "developer"` | **Yes** | — | |
| `content` | `string \| ContentPart[]` | **Yes** | — | String shorthand = single input_text |
| `phase` | `"commentary" \| "final_answer"` \| null | No | — | |

**Compliance rule C-MSG-01**: Server MUST accept messages without `type` field and
default to `"message"`.

**Compliance rule C-MSG-02**: Server MUST accept content as a plain string OR an
array of content parts.

### 2.2 Content Parts (inside message content array)

#### InputTextContent (`type: "input_text"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"input_text"` | **Yes** |
| `text` | string | **Yes** |

#### InputImageContent (`type: "input_image"`)
| Property | Type | Required | Default |
|---|---|---|---|
| `type` | `"input_image"` | **Yes** | |
| `image_url` | string \| null | No | |
| `file_id` | string \| null | No | |
| `detail` | `"low" \| "high" \| "auto" \| "original"` \| null | **No** | `"auto"` |

**Compliance rule C-IMG-01**: Server MUST accept input_image content parts
**without** `detail` field. When omitted, the server should default to `"auto"`.

> The OpenAI spec's `InputImageContentParamAutoParam` (used in EasyInputMessage)
> only requires `type`. The `detail` field is nullable and optional.

#### InputFileContent (`type: "input_file"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"input_file"` | **Yes** |
| `file_id` | string \| null | No |
| `filename` | string | No |
| `file_data` | string | No |

### 2.3 FunctionCall (`type: "function_call"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"function_call"` | **Yes** |
| `call_id` | string | **Yes** |
| `name` | string | **Yes** |
| `arguments` | string (JSON) | **Yes** |
| `id` | string | No |
| `status` | enum | No |

### 2.4 FunctionCallOutput (`type: "function_call_output"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"function_call_output"` | **Yes** |
| `call_id` | string (1–64 chars) | **Yes** |
| `output` | `string \| ContentPart[]` | **Yes** |
| `id` | string \| null | No |
| `status` | enum \| null | No |

**Compliance rule C-FCO-01**: `output` is `oneOf: [string, array<content>]`.
A JSON string value is the common case. An array of content parts (input_text,
input_image, input_file) is also valid.

### 2.5 ItemReference (`type: "item_reference"`)

| Property | Type | Required | Default |
|---|---|---|---|
| `type` | `"item_reference"` | **Yes** | `"item_reference"` |
| `id` | string | **Yes** | |

> **Note**: The OpenAI OpenAPI spec marks `type` as optional/nullable for
> `ItemReferenceParam`, but the OpenAI SDK **always serializes `type`** — the
> base class `ResponseItem.JsonModelWriteCore` unconditionally writes it.
> This is a spec anomaly, not a real optionality. We keep `type` required.

### 2.6 ComputerCallOutput (`type: "computer_call_output"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"computer_call_output"` | **Yes** |
| `call_id` | string | **Yes** |
| `output` | ComputerScreenshotImage | **Yes** |
| `acknowledged_safety_checks` | array \| null | No |
| `id` | string | No |

### 2.7 Reasoning (`type: "reasoning"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"reasoning"` | **Yes** |
| `id` | string | **Yes** |
| `summary` | SummaryTextContent[] | **Yes** |
| `encrypted_content` | string \| null | No |

### 2.8 MCPApprovalResponse (`type: "mcp_approval_response"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"mcp_approval_response"` | **Yes** |
| `approval_request_id` | string | **Yes** |
| `approve` | boolean | **Yes** |
| `reason` | string \| null | No |
| `id` | string \| null | No |

## 3. Tool Definitions

### 3.1 FunctionTool (`type: "function"`)

| Property | Type | Required | Default |
|---|---|---|---|
| `type` | `"function"` | **Yes** | `"function"` |
| `name` | string (1–128 chars) | **Yes** | — |
| `description` | string \| null | No | — |
| `parameters` | object (JSON Schema) \| null | **No** | — |
| `strict` | boolean \| null | **No** | — |

**Compliance rule C-FUNC-01**: Server MUST accept function tools **without**
`strict` field. It is nullable and optional.

**Compliance rule C-FUNC-02**: Server MUST accept function tools **without**
`parameters` field. It is nullable and optional.

### 3.2 WebSearchPreviewTool (`type: "web_search_preview"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"web_search_preview"` | **Yes** |
| `user_location` | object \| null | No |
| `search_context_size` | enum | No |

### 3.3 FileSearchTool (`type: "file_search"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"file_search"` | **Yes** |
| `vector_store_ids` | string[] | **Yes** |
| `max_num_results` | integer | No |
| `ranking_options` | object | No |
| `filters` | object \| null | No |

### 3.4 CodeInterpreterTool (`type: "code_interpreter"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"code_interpreter"` | **Yes** |
| `container` | string \| object | **Yes** |

### 3.5 ImageGenerationTool (`type: "image_generation"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"image_generation"` | **Yes** |
| (all other props) | various | No |

### 3.6 MCPTool (`type: "mcp"`)

| Property | Type | Required |
|---|---|---|
| `type` | `"mcp"` | **Yes** |
| `server_label` | string | **Yes** |
| `server_url` | string | No |
| `allowed_tools` | array \| object \| null | No |
| `require_approval` | object \| string \| null | No |

## 4. ToolChoice

| Form | Wire Representation | Meaning |
|---|---|---|
| String `"none"` | `"none"` | No tools used |
| String `"auto"` | `"auto"` | Model decides |
| String `"required"` | `"required"` | Must use a tool |
| Function object | `{ "type": "function", "name": "..." }` | Force specific function |
| Type object | `{ "type": "<tool-type>" }` | Force tool type |

## 5. Response Object

| Property | Type | Required | Notes |
|---|---|---|---|
| `id` | string | **Yes** | Starts with `resp_` |
| `object` | `"response"` | **Yes** | |
| `status` | enum | **Yes** | `completed \| failed \| in_progress \| cancelled \| queued \| incomplete` |
| `model` | string | **Yes** | |
| `output` | OutputItem[] | **Yes** | |
| `created_at` | number | **Yes** | Unix timestamp |
| `error` | object \| null | **Yes** | |
| `incomplete_details` | object \| null | **Yes** | |
| `instructions` | string \| null | **Yes** | |
| `usage` | ResponseUsage | No | |
| `metadata` | map | No | |
| `temperature` | number | No | |
| `top_p` | number | No | |
| `tools` | Tool[] | No | |
| `tool_choice` | ToolChoiceParam | No | |
| `parallel_tool_calls` | boolean | No | |

## 6. Output Item Types

### OutputMessage (`type: "message"`)
| Property | Type | Required |
|---|---|---|
| `id` | string | **Yes** |
| `type` | `"message"` | **Yes** |
| `role` | `"assistant"` | **Yes** |
| `status` | enum | **Yes** |
| `content` | (OutputTextContent \| RefusalContent)[] | **Yes** |

### FunctionToolCall (`type: "function_call"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"function_call"` | **Yes** |
| `call_id` | string | **Yes** |
| `name` | string | **Yes** |
| `arguments` | string (JSON) | **Yes** |
| `id` | string | No |
| `status` | enum | No |

### FunctionToolCallOutput (`type: "function_call_output"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"function_call_output"` | **Yes** |
| `call_id` | string | **Yes** |
| `output` | string \| array | **Yes** |
| `id` | string | No |
| `status` | enum | No |

### WebSearchCall (`type: "web_search_call"`)
| Property | Type | Required |
|---|---|---|
| `id` | string | **Yes** |
| `type` | `"web_search_call"` | **Yes** |
| `status` | enum | **Yes** |

### FileSearchCall (`type: "file_search_call"`)
| Property | Type | Required |
|---|---|---|
| `id` | string | **Yes** |
| `type` | `"file_search_call"` | **Yes** |
| `status` | enum | **Yes** |
| `queries` | string[] | **Yes** |
| `results` | array \| null | No |

### CodeInterpreterCall (`type: "code_interpreter_call"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"code_interpreter_call"` | **Yes** |
| `id` | string | **Yes** |
| `status` | enum | **Yes** |
| `container_id` | string | **Yes** |
| `code` | string \| null | **Yes** |
| `outputs` | array \| null | **Yes** |

### ImageGenerationCall (`type: "image_generation_call"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"image_generation_call"` | **Yes** |
| `id` | string | **Yes** |
| `status` | enum | **Yes** |
| `result` | string \| null | **Yes** |

### ComputerCall (`type: "computer_call"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"computer_call"` | **Yes** |
| `id` | string | **Yes** |
| `call_id` | string | **Yes** |
| `pending_safety_checks` | array | **Yes** |
| `status` | enum | **Yes** |

### ReasoningItem (`type: "reasoning"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"reasoning"` | **Yes** |
| `id` | string | **Yes** |
| `summary` | SummaryTextContent[] | **Yes** |

### MCPCall (`type: "mcp_call"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"mcp_call"` | **Yes** |
| `id` | string | **Yes** |
| `server_label` | string | **Yes** |
| `name` | string | **Yes** |
| `arguments` | string (JSON) | **Yes** |

### MCPApprovalRequest (`type: "mcp_approval_request"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"mcp_approval_request"` | **Yes** |
| `id` | string | **Yes** |
| `server_label` | string | **Yes** |
| `name` | string | **Yes** |
| `arguments` | string (JSON) | **Yes** |

### MCPListTools (`type: "mcp_list_tools"`)
| Property | Type | Required |
|---|---|---|
| `type` | `"mcp_list_tools"` | **Yes** |
| `id` | string | **Yes** |
| `server_label` | string | **Yes** |
| `tools` | MCPTool[] | **Yes** |

---

## 7. Known Compliance Gaps (to fix in service)

| ID | Gap | OpenAI Spec Says | Our Spec Says | Fix |
|---|---|---|---|---|
| GAP-01 | `EasyInputMessage.type` required | Optional (not in required) | Required | Make optional via overlay `not_required` or custom validator default |
| ~~GAP-02~~ | ~~`ItemReferenceParam.type` required~~ | ~~Optional (nullable)~~ | Required | **Not a real gap** — OpenAI SDK always sends `type`. Spec anomaly. |
| GAP-03 | `MessageContentInputImageContent.detail` required | Optional (nullable, not in required for Param variant) | Required | Make optional via overlay `not_required` |
| GAP-04 | `FunctionTool.strict` required | Optional (nullable, not in required) | Required | Make optional via overlay `not_required` |
| GAP-05 | `FunctionTool.parameters` required | Optional (nullable, not in required) | Required | Make optional via overlay `not_required` |

---

## 8. Test Organization

### Raw JSON Compliance Tests (`OpenAIWireComplianceTests.cs`)
Send raw JSON that matches exactly what the OpenAI SDK would produce. Tests
validate the server accepts each payload and correctly deserializes the model.

### SDK Compliance Tests (`OpenAISdkComplianceTests.cs`)
Use the OpenAI .NET SDK (`OpenAI.Responses` namespace) to construct requests
using their CLR types and send to our server. Tests validate end-to-end
compatibility through the SDK's serialization.
