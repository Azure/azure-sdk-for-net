// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent;

/// <summary>
/// Provides prompt templates for Copilot interactions.
/// Only contains non-deterministic prompts — all deterministic fix patterns
/// are handled by MCP tools and the DeterministicFixRegistry.
/// See skills/migration-workflow.skill.md for the full tool + rule catalog.
/// </summary>
internal static class CopilotPrompts
{
    /// <summary>
    /// Builds the system message for Azure SDK migration guidance.
    /// Focuses on non-deterministic reasoning that tools cannot handle:
    /// customization file interactions, generator bug identification,
    /// and GeneratorPageableHelpers → CollectionResult migration.
    /// </summary>
    public static string BuildMigrationSystemMessage(string projectPath)
    {
        return $"""
            You are an expert C# developer helping fix build errors in Azure SDK libraries.

            CONTEXT:
            Deterministic fixes (field renames, missing usings, nullable annotations, type pattern
            replacements, ToRequestContent removal, FromCancellationToken replacement, FromResponse
            removal, Fetch→FromLroResponse, ModelFactory/ClientBuilderExtensions CodeGenType fixes)
            are handled AUTOMATICALLY by MCP tools before your involvement.
            You only see errors that require reasoning and contextual understanding.

            CRITICAL RULES:
            1. NEVER modify, edit, or create files under any "Generated" folder.
            2. Fix errors through customization files (partial classes, wrappers, extensions).
            3. The generator reads customization files and produces DIFFERENT output based on them.
               Errors in Generated/ are often caused by STALE customization files, not generator bugs.
            4. After fixing customization files with generator attributes ([CodeGenSuppress], [CodeGenType],
               etc.), the orchestrator will re-run code generation automatically.

            MIGRATION PATTERNS REQUIRING REASONING:

            1. GeneratorPageableHelpers → CollectionResult pattern:
               - Code using GeneratorPageableHelpers.CreatePageable needs replacement
               - Look in Generated/ for types ending in "CollectionResult" or "PageableCollection"
               - Replace the helper call with the corresponding generated CollectionResult type
               - If no CollectionResult exists in Generated/:
                 a. Find the [CodeGenSuppress] attribute suppressing the generated method
                 b. Comment out or remove that attribute
                 c. End your fix iteration — the orchestrator will regenerate
               - Do NOT create CollectionResult types manually

            2. Generator and customization file interaction:
               - [CodeGenSuppress], [CodeGenType], [CodeGenModel], [CodeGenMember] attributes
                 influence what the generator produces
               - Fixing a Generated/ error usually means editing the customization file,
                 then the orchestrator re-runs generation
               - Only after eliminating customization interference can you identify true generator bugs

            3. Complex type mismatches and interface implementations:
               - Missing interface members require understanding of the type hierarchy
               - Method signature changes may require wrapper methods

            GENERATOR BUG IDENTIFICATION:
            If you encounter errors that are generator bugs (syntax errors in Generated code,
            missing types that cannot be fixed through customization), document them clearly
            with error details, reproduction steps, and expected behavior. Do not manually fix
            Generated/ code.

            The project is located at: {projectPath}

            When fixing errors:
            1. Use grep/glob to explore the codebase structure
            2. Use view to read files and understand the error context
            3. Determine if the error is in a Generated file
            4. If in Generated file: create/edit a customization file instead
            5. Only fix files that are NOT in Generated folders
            """;
    }

    /// <summary>
    /// Builds the prompt for analyzing an Azure SDK project and updating tsp-location.yaml
    /// with the correct TypeSpec specification path. This is inherently non-deterministic
    /// as it requires understanding what Azure service the SDK represents.
    /// </summary>
    public static string TypespecPathAnalysisPrompt(string projectPath, string targetRepository)
    {
        return $"""
            You are analyzing an Azure SDK for .NET project to find its corresponding OpenAPI/TypeSpec specification path in the {targetRepository} repository and update the tsp-location.yaml file.

            PROJECT ANALYSIS TASK:
            1. Examine the project at: {projectPath}
            2. Read and analyze key files in this directory (README.md, .csproj files, source code, namespaces, etc.)
            3. Understand what Azure service this SDK represents
            4. Ignore any existing tsp-location.yaml or tsp-location.yml files - they may contain incorrect paths

            TARGET REPOSITORY: {targetRepository}

            ANALYSIS REQUIREMENTS:
            - Determine the Azure service category (ai, compute, storage, network, etc.)
            - Identify the specific service name from the project structure
            - Find the correct specification folder in {targetRepository} that matches this service

            FILE UPDATE TASK - YOU MUST ACTUALLY WRITE THE FILE:
            1. USE THE EDIT TOOL to update the tsp-location.yaml file in the project directory: {projectPath}
            2. Replace the current 'directory' field with the correct specification path
            3. The path must start with 'specification/' and end with '/'
            4. ACTUALLY WRITE the file using your edit tool - do not just provide instructions
            5. Preserve all existing fields and formatting in the file

            CRITICAL: You do NOT have access to a local clone of the {targetRepository} repository. Do not try to browse or search for it. You have access to an edit tool. Use it to physically update the tsp-location.yaml file.

            RESPONSE:
            Based on your analysis of the project files at {projectPath}, update the tsp-location.yaml file with the correct specification path.
            """;
    }

    /// <summary>
    /// Builds a focused prompt for the LLM when deterministic fixes have already been applied
    /// and only non-deterministic errors remain. This is the primary prompt used by the
    /// MigrationOrchestrator's build-fix cycle.
    /// </summary>
    public static string FocusedBuildFixPrompt(string projectPath, string preClassifiedErrors)
    {
        return $"""
            You are fixing build errors in an Azure SDK migration project. Deterministic fixes (field renames,
            missing usings, nullable annotations, type pattern replacements, ToRequestContent removal,
            FromCancellationToken replacement, FromResponse removal, Fetch→FromLroResponse,
            ModelFactory/ClientBuilderExtensions CodeGenType fixes) have ALREADY been applied automatically.

            The remaining errors below require your analysis and reasoning to fix. They may involve:
            - Stale customization files conflicting with generated code
            - Complex type mismatches requiring code restructuring
            - Missing interface implementations
            - GeneratorPageableHelpers → CollectionResult migration
            - Generator bugs that need to be reported
            - Logic errors in custom code

            PROJECT: {projectPath}

            === REMAINING ERRORS (deterministic fixes already applied) ===

            {preClassifiedErrors}

            === RULES ===
            - NEVER modify/create files under any path containing "Generated/"
            - Fix errors through customization files (partial classes, wrappers, extensions) outside Generated/
            - If an error is caused by a stale customization file, fix or remove the customization, then the
              orchestrator will re-run code generation
            - Fix ~10 errors then stop — the orchestrator will rebuild and send you any remaining errors
            - Always check src/Generated/ for the actual new type names before writing fixes
            - If you identify a generator bug, document it clearly and move on

            Start fixing now.
            """;
    }
}
