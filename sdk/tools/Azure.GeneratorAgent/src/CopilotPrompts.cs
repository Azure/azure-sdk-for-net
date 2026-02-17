// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent;

/// <summary>
/// Provides prompt templates and instructions for Copilot interactions.
/// Centralizes all prompt engineering logic for better maintainability and testability.
/// </summary>
public static class CopilotPrompts
{
    /// <summary>
    /// Builds the system message for Azure SDK migration guidance.
    /// </summary>
    /// <param name="projectPath">Path to the project being analyzed.</param>
    /// <returns>System message content for migration assistance.</returns>
    public static string BuildMigrationSystemMessage(string projectPath)
    {
        return $"""
            You are an expert C# developer helping with Azure SDK code migration.

            CRITICAL RULES:
            1. NEVER modify files in 'Generated' folders - these are auto-generated
            2. Create customization files for Generated file errors instead
            3. Focus on migration patterns for Azure SDK modernization

            MIGRATION PATTERNS TO APPLY:
            1. Replace GeneratorPageableHelpers with CollectionResult patterns
            2. Remove ToRequestContent() calls (use implicit cast instead)
            3. Replace FromCancellationToken with ToRequestContext()
            4. Update factory method and ClientBuilderExtensions type names
            5. Replace LRO Fetch methods with FromLroResponse static methods
            6. Replace FromResponse methods with explicit cast operators

            Project location: {projectPath}
            """;
    }

    /// <summary>
    /// Builds the prompt for analyzing an Azure SDK project to find its Typespec specification path.
    /// </summary>
    /// <param name="projectPath">Path to the project being analyzed.</param>
    /// <param name="targetRepository">Target repository name (e.g., 'azure-rest-api-specs').</param>
    /// <returns>Analysis prompt for specification path discovery.</returns>
    public static string TypespecPathAnalysisPrompt(string projectPath, string targetRepository)
    {
        return $"""
            You are analyzing an Azure SDK for .NET project to find its corresponding OpenAPI/TypeSpec specification path in the {targetRepository} repository.

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

            RESPONSE FORMAT:
            - Return ONLY the specification directory path
            - Start with 'specification/'
            - End with '/'
            - No explanations, no backticks, no additional text
            - One line only

            EXAMPLES:
            - For Azure AI Vision services: specification/ai/ImageAnalysis/
            - For Azure Storage: specification/storage/StorageServices/
            - For Azure Compute: specification/compute/VirtualMachines/

            Based on your analysis of the project files at {projectPath}, what is the correct specification path in {targetRepository}?

            Answer:
            """;
    }
}
