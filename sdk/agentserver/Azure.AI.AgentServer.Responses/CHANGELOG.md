# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of Azure.AI.AgentServer.Responses.
- ASP.NET Core server library implementing the Azure AI Responses API.
- `ResponseHandler` abstract class for custom response handling.
- Streaming event builder pattern for real-time SSE responses.
- Built-in in-memory response provider and execution tracking.
- Support for default, streaming, background, and streaming+background response modes.
- Protocol identity registration with `ServerUserAgentRegistry` during route mapping.
