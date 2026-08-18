// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects;

namespace OpenAI;

// Internal types
[CodeGenType("ComputerAction")] internal partial class InternalComputerAction { }
[CodeGenType("EasyInputMessage")] internal partial class InternalEasyInputMessage { }
[CodeGenType("ImageGenToolBackground")] internal readonly partial struct ImageGenToolBackground { }
[CodeGenType("ImageGenToolInputImageMask")] internal partial class InternalImageGenToolInputImageMask { }
[CodeGenType("ImageGenToolModeration")] internal readonly partial struct ImageGenToolModeration { }
[CodeGenType("ImageGenToolOutputFormat")] internal readonly partial struct ImageGenToolOutputFormat { }
[CodeGenType("ImageGenToolQuality")] internal readonly partial struct ImageGenToolQuality { }
[CodeGenType("ImageGenToolSize")] internal readonly partial struct ImageGenToolSize { }
[CodeGenType("ItemParam")] internal partial class InternalItemParam { }
// Though these classes are not used anymore, the AzureAIProjectsContext-s are being generated for them
// for back compatibility.
[CodeGenType("LocalShellExecAction")] internal partial class InternalLocalShellExecAction { }
[CodeGenType("LogProb")] internal partial class InternalLogProb { }
[CodeGenType("MCPListToolsTool")] internal partial class InternalMCPListToolsTool { }
[CodeGenType("TopLogProb")] internal partial class InternalTopLogProb { }
[CodeGenType("VectorStoreFileAttributes")] internal partial class InternalVectorStoreFileAttributes { }
[CodeGenType("WebSearchActionFind")] internal partial class InternalWebSearchActionFind { }
[CodeGenType("WebSearchActionOpenPage")] internal partial class InternalWebSearchActionOpenPage { }
[CodeGenType("WebSearchActionSearch")] internal partial class InternalWebSearchActionSearch { }
[CodeGenType("Annotation")] internal partial class InternalAnnotation { }
[CodeGenType("CodeInterpreterOutputImage")] internal partial class InternalCodeInterpreterOutputImage { }
[CodeGenType("CodeInterpreterOutputLogs")] internal partial class InternalCodeInterpreterOutputLogs { }
