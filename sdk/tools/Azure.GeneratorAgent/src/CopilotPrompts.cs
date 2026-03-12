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
               - If the error is in a generated class, locate and fix the corresponding partial class in a customization file instead of editing the generated file directly
 
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

            8. Generator and customization file interaction:
                - The generator reads existing customization files (partial classes with [CodeGenSuppress], [CodeGenType], etc.) and produces DIFFERENT output based on them
                - Errors in Generated/ files are often CAUSED by stale customization files, not generator bugs
                - Fixing a Generated/ error usually means editing or removing the customization file that caused it,
                  then re-running [GENERATE] so the generator produces correct output without the stale influence
                - Only after eliminating customization interference can you identify true generator bugs

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
            Run build, fix errors, run tests, and finalize the migration. Be verbose — announce every command before and after.

            PROJECT: {projectPath}
            TESTS:   Use the tests directory under PROJECT (typically PROJECT/tests)
            REPO:    Navigate up from PROJECT until you find eng/ and global.json
            SERVICE: The folder name immediately after sdk/ in the PROJECT path

            === COMMAND MACROS (use these exact commands) ===
            [BUILD]      = dotnet build /clp:ErrorsOnly 2>&1 | Select-Object -First 50
            [GENERATE]   = dotnet build /t:generateCode
            [TEST]       = dotnet test --no-build --filter "TestCategory!=Live" 2>&1 | Select-Object -Last 30

            === RULES (apply throughout all phases) ===
            - NEVER modify/create files under any path containing "Generated/"
            - Fix errors through customization files (partial classes, wrappers, extensions) outside Generated/
            - Cap output: always use /clp:ErrorsOnly and pipe through Select-Object
            - Fix ~10 errors per iteration then rebuild — cascading errors often resolve themselves
            - Always check src/Generated/ for the actual new type names before writing fixes
            - Run PowerShell scripts from REPO root, not PROJECT directory

            === KEY INSIGHT: HOW THE GENERATOR AND CUSTOMIZATION FILES INTERACT ===
            The generator reads existing customization files (partial classes with [CodeGenSuppress], [CodeGenType],
            [CodeGenModel], [CodeGenMember], [CodeGenSerialization]) and produces DIFFERENT output based on them.
            This means:
            - Errors in Generated/ files are often CAUSED by stale customization files, not generator bugs
            - Fixing a Generated/ error usually means editing or removing the customization file that caused it,
              then re-running [GENERATE] so the generator produces correct output without the stale influence
            - Only after eliminating customization interference can you identify true generator bugs

            === PHASE 0: PRE-GENERATION CLEANUP (in PROJECT/src) ===

            1. Remove <IncludeAutorestDependency>true</IncludeAutorestDependency> from src/*.csproj if present.

            === PHASE 1: CODE GENERATION (in PROJECT/src) ===

            2. Run [GENERATE]
            3. IF fails → check if a customization file is causing it. Fix/remove the problematic customization,
               then re-run [GENERATE]. If it still fails with no customizations involved, it's a generator bug — report and stop.

            === PHASE 2: BUILD AND FIX (in PROJECT/src) ===

            4. Run [BUILD]
            5. IF succeeds → skip to PHASE 3
            6. IF fails → classify errors and fix:

               --- Errors in Generated/ files ---
               These are almost always caused by an existing customization file that the generator read.
               a. Find the corresponding customization file (partial class, [CodeGenSuppress], etc.)
               b. Read both the Generated file and the customization file to understand the mismatch
               c. Fix the customization file:
                  - Update [CodeGenSuppress] attributes (remove stale ones, update signatures)
                  - Update [CodeGenType]/[CodeGenModel] to match new generated type names
                  - Update method signatures, property types, etc. to match new generated code
                  - If the customization is entirely obsolete, DELETE it
               d. After fixing customization files that have generator attributes, run [GENERATE] then [BUILD]
               e. If the error persists after removing all related customizations and re-generating → generator bug

               --- Other compilation errors ---
               a. Create/edit customization files to fix (partial classes, wrappers, extensions)
               b. If the fix involves generator attributes → run [GENERATE] then [BUILD]
               c. Otherwise just run [BUILD]

            7. After ~10 fixes → run [BUILD]. Repeat (max 10 iterations).

            === PHASE 3: TEST PROJECT BUILD (in TESTS directory) ===

            3A. Move old generated samples:
                IF tests/Generated/Samples/ exists → move contents to tests/Samples/, delete empty folders.
                Do NOT run [GENERATE] in the tests directory — test files are not re-generated.

            3B. Build and fix:
                8. Run [BUILD] in tests/
                9. Fix ~10 errors per iteration (check src/Generated/ for new type names)
                10. Repeat (max 10 iterations). If still failing → skip to PHASE 5.

            === PHASE 4: TEST EXECUTION (in TESTS directory) ===

            11. Run [TEST]
            12. IF fails → fix non-Generated test files, run [BUILD], then [TEST] again
            13. Repeat (max 5 iterations). If still failing → continue to PHASE 5.

            === PHASE 5: FINALIZATION (from REPO root) ===

            14. Run: .\eng\scripts\Export-API.ps1 -ServiceDirectory SERVICE
            15. Run: .\eng\scripts\Update-Snippets.ps1 -ServiceDirectory SERVICE
            16. Announce: "Migration completed successfully"

            === GENERATOR BUG DIAGNOSIS ===

            A true generator bug is when Generated/ code is wrong even with NO customization files influencing it.
            Before reporting a generator bug, ALWAYS:
            1. Remove/fix any customization files that could be influencing the generator
            2. Re-run [GENERATE]
            3. If the error persists in Generated/ with no customization influence → it's a generator bug
            Report: error messages, generated code snippet, repro steps. Do NOT manually fix Generated/ code.

            Start now.
            """;
    }

    /// <summary>
    /// Builds the prompt for the local specs workflow: iterate through commits, diagnose failures,
    /// and take the appropriate action based on the root cause of each failure.
    /// </summary>
    /// <param name="sdkProjectPath">Absolute path to the SDK project being migrated.</param>
    /// <param name="tspLocationPath">Absolute path to the tsp-location.yaml file.</param>
    /// <param name="specsRelativeDirectory">The relative directory path for the specs (e.g., specification/ai/ImageAnalysis/).</param>
    /// <param name="localSpecsPath">Absolute path to the local specs repository.</param>
    /// <returns>Prompt instructing Copilot to iterate commits with failure diagnosis.</returns>
    public static string LocalSpecsCommitIterationPrompt(string sdkProjectPath, string tspLocationPath, string specsRelativeDirectory, string localSpecsPath)
    {
        var sdkNamespace = Path.GetFileName(sdkProjectPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

        return $$"""
            You need to find a commit whose tspconfig.yaml has the correct "@azure-typespec/http-client-csharp" emitter config for this SDK project.

            SDK PROJECT: {{sdkProjectPath}}
            SDK NAMESPACE: {{sdkNamespace}}
            TSP-LOCATION FILE: {{tspLocationPath}}
            SPECS DIRECTORY (relative): {{specsRelativeDirectory}}
            LOCAL SPECS REPO: {{localSpecsPath}}

            === WHAT A VALID tspconfig.yaml LOOKS LIKE ===

            The "options" section of tspconfig.yaml must contain an "@azure-typespec/http-client-csharp" key
            with EXACTLY these 3 fields and NO others:

            ```yaml
            options:
              "@azure-typespec/http-client-csharp":
                emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
                namespace: {{sdkNamespace}}
                model-namespace: false
            ```

            Validation rules:
            - The key "@azure-typespec/http-client-csharp" MUST exist under "options".
            - It MUST have exactly 3 fields: emitter-output-dir, namespace, model-namespace.

            === PHASE 1: READ CURRENT STATE ===

            1. Read {{tspLocationPath}} and extract the current "commit" field value. This is your STARTING commit.
            2. Use the powershell tool to run:
               git log --format="%H" --reverse <starting-commit>..HEAD -- {{specsRelativeDirectory}}
               in {{localSpecsPath}} to get all commits NEWER than the starting commit for this directory.
            3. Your candidate list is: [starting-commit, ...newer-commits] in chronological order (oldest first).

            === PHASE 2: ITERATE COMMITS ===

            For each candidate commit (starting from the current one, then progressively newer):

            4. Use the powershell tool to checkout the candidate commit:
               git checkout <candidate-commit> -- {{specsRelativeDirectory}}
               in {{localSpecsPath}}
            5. Read {{localSpecsPath}}/{{specsRelativeDirectory}}/tspconfig.yaml
            6. Check if the "@azure-typespec/http-client-csharp" section under "options" is EXACTLY valid per the rules above.
            7. IF VALID → Update the "commit" field in {{tspLocationPath}} to this commit SHA. Announce: "Found valid commit: <SHA>". Go to PHASE 4.
            8. IF INVALID → Log what's wrong (missing key, wrong namespace, extra fields, etc.) and move to the next candidate commit.

            === PHASE 3: FALLBACK (only if NO commit has a valid config) ===

            If every candidate commit had an invalid tspconfig.yaml:

            9. Use the LATEST (newest) candidate commit as the base.
            10. Checkout that commit's tspconfig.yaml:
                git checkout <latest-commit> -- {{specsRelativeDirectory}}
                in {{localSpecsPath}}
            11. Read {{localSpecsPath}}/{{specsRelativeDirectory}}/tspconfig.yaml
            12. Edit it so that the "@azure-typespec/http-client-csharp" section under "options" has EXACTLY the 3 required fields
                (emitter-output-dir, namespace, model-namespace) and NOTHING else. Remove any extra fields. Fix any wrong values.
            13. In {{localSpecsPath}}, run these git commands:
                a. git checkout -b sdk-migration-fallback
                b. git add {{specsRelativeDirectory}}/tspconfig.yaml
                c. git commit -m "Update tspconfig.yaml for SDK migration: set @azure-typespec/http-client-csharp emitter config"
                d. git rev-parse HEAD   (capture the new commit SHA)
            14. Use the edit tool to update the "commit" field in {{tspLocationPath}} with the new commit SHA.
            15. Announce: "No valid commit found. Created fallback commit: <SHA>"

            === PHASE 4: RESTORE LOCAL SPECS ===

            After finding or creating a valid commit:
            16. In {{localSpecsPath}}, restore the working tree to HEAD:
                git checkout HEAD -- {{specsRelativeDirectory}}

            === RULES ===
            - ACTUALLY execute every command — do not just describe what should be done.
            - Stop iterating as soon as you find a valid tspconfig.yaml.
            - Announce each commit you check and whether its tspconfig.yaml is valid or invalid (and why).
            - If the candidate list is empty (no newer commits and the current commit is also invalid), go directly to PHASE 3.
            - This phase does NOT run code generation — it only validates tspconfig.yaml content.

            Start now.
            """;
    }
}
