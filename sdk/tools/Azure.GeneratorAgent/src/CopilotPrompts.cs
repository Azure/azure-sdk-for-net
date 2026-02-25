// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent;

/// <summary>
/// Provides prompt templates and instructions for Copilot interactions.
/// Centralizes all prompt engineering logic for better maintainability and testability.
/// </summary>
internal static class CopilotPrompts
{
    /// <summary>
    /// Builds the system message for Azure SDK migration guidance.
    /// </summary>
    /// <param name="projectPath">Path to the project being analyzed.</param>
    /// <returns>System message content for migration assistance.</returns>
    public static string BuildMigrationSystemMessage(string projectPath)
    {
        return $"""
            You are an expert C# developer helping fix build errors in Azure SDK libraries.

            CRITICAL RULES - YOU MUST FOLLOW THESE:
            1. NEVER modify, edit, or create files under any "Generated" folder or path containing "Generated".
            2. If an error is in a Generated file, you must fix it by creating/editing a CUSTOMIZATION file instead.
            3. Understand the fix-and-regenerate cycle:
               a. Not all errors can be fixed simply by modifying custom files
               b. You will need to regenerate code after making fixes
               c. You are being run in a loop where code generation re-runs after each fix iteration
               d. When you finish fixing errors and require regeneration, end your current fix iteration
            4. Common fix patterns for Generated file errors:
               - Create a partial class in the non-Generated folder to extend the generated type
               - Add missing interface implementations in customization files
               - Create wrapper methods or extension methods

            MIGRATION PATTERNS TO APPLY:
            1. GeneratorPageableHelpers -> CollectionResult pattern:
               - If you see code using GeneratorPageableHelpers.CreatePageable or similar, it needs to be replaced
               - Look in the Generated folder for types ending in "CollectionResult" or "PageableCollection"
               - Replace the helper call with instantiating the corresponding generated CollectionResult type
               - IMPORTANT: If you cannot find a CollectionResult type in the Generated folder:
                 a. The custom method is likely suppressing generation of the internal method that would create the CollectionResult
                 b. Find the [CodeGenSuppress] attribute that suppresses the generated method
                 c. Comment out or remove that attribute
                 d. re-run code generation to generate the CollectionResult type (in order to regenerate end your current build fix iteration)
                 e. After regeneration, the CollectionResult type will exist and can be used
               - Do NOT try to create the CollectionResult type manually - it must be generated

            2. ToRequestContent() removal:
               - Input models now have an implicit cast to RequestContent
               - Replace `foo.ToRequestContent()` with just `foo`
               - Example: `using RequestContent content = details.ToRequestContent();` becomes `using RequestContent content = details;`
               - IMPORTANT: do not remove the using statement - only remove the ToRequestContent() call

            3. FromCancellationToken replacement:
               - Replace `RequestContext context = FromCancellationToken(cancellationToken);`
               - With `RequestContext context = cancellationToken.ToRequestContext();`
                
            4. Mismatched factory method type names:
               - If there is a custom type ending in ModelFactory that has a different name than the 
                 generated type ending in ModelFactory, update the CodeGenType attribute in the custom type to match the generated type name. 

            5. Mismatched ClientBuilderExtensions type names. 
                - If there is a custom type ending in ClientBuilderExtensions that has a different name than the 
                  generated type ending in ClientBuilderExtensions, update the CodeGenType attribute in the custom type to match the generated type name.
            
            6. Fetch methods in custom LRO methods:
                - In the new generator, the Fetch methods are replaced by static methods called FromLroResponse on the Response models.
                - Update custom LRO methods to use ResponseModel.FromLroResponse(response) instead of calling Fetch methods.
                - Do NOT create Fetch methods manually - call the generated FromLroResponse method.
                
            7. FromResponse method removal:    
                - The FromResponse methods have been removed from models.
                - Instead, use the explicit cast from Response to the model type.
                - Example: `var model = ModelType.FromResponse(response);` becomes `var model = (ModelType)response;`
            The project is located at: {projectPath}

            When fixing errors:
            1. Use grep/glob to explore the codebase structure
            2. Use view to read files and understand the error context
            3. Determine if the error is in a Generated file (path contains "Generated")
            4. If in Generated file: create/edit a customization file in the parallel non-Generated location
            5. Use edit or create to make your fixes
            6. Only fix files that are NOT in Generated folders

            GENERATOR BUG IDENTIFICATION:
            If you encounter errors that appear to be generator bugs (syntax errors in Generated code, missing generated types that cannot be fixed through customization, TypeSpec compilation failures), document and report them instead of attempting fixes:
            - Gather error details, reproduction steps, and expected behavior
            - Report to the user with clear repro instructions
            - Do not attempt to manually fix generator-produced code
            """
;
    }

    /// <summary>
    /// Builds the prompt for analyzing an Azure SDK project and updating tsp-location.yaml with the correct Typespec specification path.
    /// </summary>
    /// <param name="projectPath">Path to the project being analyzed.</param>
    /// <param name="targetRepository">Target repository name (e.g., 'azure-rest-api-specs').</param>
    /// <returns>Analysis prompt for specification path discovery and file update.</returns>
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

            CRITICAL: You do NOT have access to a local clone of the {targetRepository} repository. Do not try to browse or search for it. You have access to an edit tool. Use it to physically update the tsp-location.yaml file. Do not just analyze and respond with what should be done - actually perform the file edit operation.

            EXAMPLES:
            - For Azure AI Vision services: directory: specification/ai/ImageAnalysis/
            - For Azure Storage: directory: specification/storage/StorageServices/
            - For Azure Compute: directory: specification/compute/VirtualMachines/

            RESPONSE:
            Based on your analysis of the project files at {projectPath}, update the tsp-location.yaml file with the correct specification path.
            """;
    }

    /// <summary>
    /// Builds the comprehensive prompt for handling the complete build-fix cycle during Azure SDK migration.
    /// </summary>
    /// <param name="projectPath">Path to the project being built.</param>
    /// <returns>Complete build-fix cycle prompt for Copilot to handle autonomously.</returns>
    public static string BuildAndFixCyclePrompt(string projectPath)
    {
        return $"""
            Your task is to run build commands, tests, and finalization scripts, fixing any errors. BE EXTREMELY VERBOSE about what you're doing.

            PROJECT DIRECTORY: {projectPath}

            STEPS:
            1. ANNOUNCE: "I'm about to run: dotnet build /t:generateCode"
            2. Run: dotnet build /t:generateCode  
            3. If successful, ANNOUNCE: "Code generation successful, now running regular build"
            4. If it fails, ANNOUNCE: "Code generation failed, analyzing errors to create fixes"
            5. Read and analyze any error output, create/edit custom files to fix issues
            6. REPEAT step 2-5 until code generation succeeds
            7. ANNOUNCE: "I'm about to run: dotnet build"
            8. Run: dotnet build
            9. If successful, ANNOUNCE: "Build completed successfully, now running tests"
            10. If it fails, ANNOUNCE: "Build failed, analyzing errors to create fixes"
            11. Read and analyze any error output, create/edit custom files to fix issues
            12. REPEAT step 8-11 until build succeeds
            13. ANNOUNCE: "I'm about to run: dotnet test"
            14. Run: dotnet test
            15. If successful, ANNOUNCE: "Tests completed successfully, running finalization scripts"
            16. If it fails, ANNOUNCE: "Tests failed, analyzing failures and updating tests based on new generated classes"
            17. Read and analyze test failures, update test files to work with new generated code
            18. REPEAT step 14-17 until tests succeed
            19. Find azure-sdk-for-net repository root (navigate up from project path until you find 'eng' folder)
            20. Extract service directory name from project path (the folder name after 'sdk/' in the path)
            21. ANNOUNCE: "Running Export-API.ps1 script from repository root with ServiceDirectory parameter"
            22. Run: .\eng\scripts\Export-API.ps1 -ServiceDirectory <service_directory_name> (from repository root)
            23. ANNOUNCE: "Running Update-Snippets.ps1 script from repository root with ServiceDirectory parameter"  
            24. Run: .\eng\scripts\Update-Snippets.ps1 -ServiceDirectory <service_directory_name> (from repository root)
            25. ANNOUNCE: "Migration completed successfully - all steps finished"

            CRITICAL RULES:
            - NEVER modify files in 'Generated' or 'generated' folders
            - Only create/modify custom files outside Generated folders  
            - ALWAYS ANNOUNCE what command you're about to run before running it
            - ALWAYS ANNOUNCE the result after running commands
            - For PowerShell scripts, find the azure-sdk-for-net root directory first (contains 'eng' folder and 'global.json')
            - Run PowerShell scripts from the repository root, not the project directory
            - Be extremely verbose about your reasoning and actions

            ERROR HANDLING STRATEGY:
            When encountering multiple build errors:
            1. DO NOT try to fix all errors at once
            2. Fix errors in small batches (3-5 related errors maximum)
            3. After each batch of fixes, immediately re-run the build command
            4. Some errors may disappear after fixing others due to dependencies
            5. This iterative approach prevents confusion and allows for better error resolution

            GENERATOR BUG DIAGNOSIS:
            When encountering errors, evaluate if they might be generator bugs by looking for these patterns:
            - Generated code with syntax errors or compilation issues that cannot be fixed by customization files
            - Missing or incorrectly generated types, methods, or properties in Generated folder
            - Generated code that violates C# language rules or .NET conventions
            - TypeSpec compilation errors or issues with the generator itself
            - Generated code that produces runtime exceptions or unexpected behavior patterns
            
            If you suspect a generator bug:
            1. ANNOUNCE: "Potential generator bug detected - documenting issue for reporting"
            2. Gather the following information:
               - Specific error messages and stack traces
               - The generated code that appears incorrect
               - Steps to reproduce the issue (project path, build commands used)
               - Expected vs actual generated code behavior
            3. REPORT the bug details to the user instead of attempting further fixes
            4. ANNOUNCE: "Generator bug documented and reported - manual intervention may be required"

            If the issue can be resolved through customization files, continue with normal error fixing procedures.

            Start now. Remember to announce every command before you run it!
            """;
    }
}
