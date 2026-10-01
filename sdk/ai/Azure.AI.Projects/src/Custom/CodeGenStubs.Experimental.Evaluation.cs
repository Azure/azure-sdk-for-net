// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Evaluation;

// Keep the experimental markers on public types that were experimental in the previous SDK.
[Experimental("AAIP001")] public partial class EvaluationCredentialContent { }
[Experimental("AAIP001")] public partial class EvaluationsDimension { }
[Experimental("AAIP001")] public readonly partial struct EvaluatorCategory { }
[Experimental("AAIP001")] public abstract partial class EvaluatorDefinition { }
[Experimental("AAIP001")] public readonly partial struct EvaluatorDefinitionType { }
[Experimental("AAIP001")] public partial class EvaluatorGenerationArtifacts { }
[Experimental("AAIP001")] public partial class EvaluatorGenerationInputs { }
[Experimental("AAIP001")] public partial class EvaluatorGenerationJob { }
[Experimental("AAIP001")] public abstract partial class EvaluatorGenerationJobSource { }
[Experimental("AAIP001")] public partial class EvaluatorGenerationTokenUsage { }
[Experimental("AAIP001")] public partial class EvaluatorMetric { }
[Experimental("AAIP001")] public readonly partial struct EvaluatorMetricDirection { }
[Experimental("AAIP001")] public readonly partial struct EvaluatorMetricType { }
[Experimental("AAIP001")] public partial class EvaluatorVersion { }
