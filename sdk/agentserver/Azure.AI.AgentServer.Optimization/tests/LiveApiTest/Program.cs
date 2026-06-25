// Live API test: exercises typed convenience methods against the E2E Foundry endpoint.
// Run with: dotnet run --project tests/LiveApiTest
// Requires: az login (DefaultAzureCredential)

using System.Diagnostics;
using Azure;
using Azure.AI.AgentServer.Optimization;
using Azure.Identity;

const string ProjectEndpoint = "https://e2e-tests-westus2-account.services.ai.azure.com/api/projects/faos-e2e-tests";
const string AgentName = "travel-agent-sample";
const string EvalModel = "gpt-5";
const int MaxIterations = 3; // Force multiple candidates

var credential = new DefaultAzureCredential();
var projectsClient = new ProjectsClient(new Uri(ProjectEndpoint), credential);
var jobsClient = projectsClient.GetAgentOptimizationJobsClient();

Console.WriteLine("═══════════════════════════════════════════════════════════");
Console.WriteLine("  Live API Test: Typed Convenience Methods");
Console.WriteLine("═══════════════════════════════════════════════════════════");

// ─── Step 1: List existing jobs (typed) ────────────────────────────────────
Console.WriteLine("\n── Step 1: List Existing Jobs (typed GetAllAsync) ──");
try
{
    int count = 0;
    await foreach (OptimizationJob job in jobsClient.GetAllAsync())
    {
        Console.WriteLine($"  {job.Id} | {job.Status} | Agent: {job.Inputs?.Agent?.AgentName ?? "?"}");
        count++;
        if (count >= 5) break; // Show first 5
    }
    Console.WriteLine($"  Listed {count} job(s) successfully ✓");
}
catch (Exception ex)
{
    Console.WriteLine($"  ✗ GetAllAsync failed: {ex.GetType().Name}: {ex.Message}");
}

// ─── Step 2: Create a new job (typed) ──────────────────────────────────────
Console.WriteLine("\n── Step 2: Create Optimization Job (typed CreateAsync) ──");
Console.WriteLine($"  Agent: {AgentName}, MaxIterations: {MaxIterations}, EvalModel: {EvalModel}");

var newJob = new OptimizationJob
{
    Inputs = new OptimizationJobInputs(new OptimizationAgentDefinition(AgentName))
    {
        Evaluators = { "task_adherence" },
        Options = new OptimizationOptions
        {
            MaxIterations = MaxIterations,
            EvalModel = EvalModel,
            OptimizationModel = EvalModel,
        },
        Dataset =
        {
            new DatasetItem("tokyo_visit", "What's the best time to visit Tokyo?"),
            new DatasetItem("paris_budget", "Plan a 3-day trip to Paris on a budget."),
            new DatasetItem("nyc_london", "Compare direct flights from NYC to London."),
        }
    }
};

string? createdJobId = null;
try
{
    Response<OptimizationJob> createResponse = await jobsClient.CreateAsync(newJob);
    createdJobId = createResponse.Value.Id;
    Console.WriteLine($"  ✓ Created job: {createdJobId} | Status: {createResponse.Value.Status}");
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"  ✗ CreateAsync failed: {ex.Status} {ex.ErrorCode}: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"  ✗ CreateAsync failed: {ex.GetType().Name}: {ex.Message}");
}

if (createdJobId is null)
{
    Console.WriteLine("\n  Cannot proceed without a created job. Exiting.");
    return;
}

// ─── Step 3: Poll until terminal (typed GetAsync) ──────────────────────────
Console.WriteLine("\n── Step 3: Poll Job Until Terminal (typed GetAsync) ──");
var sw = Stopwatch.StartNew();
var terminalStates = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "completed", "succeeded", "failed", "cancelled" };
string lastStatus = "";
int pollCount = 0;
const int MaxPollMinutes = 20;

while (sw.Elapsed.TotalMinutes < MaxPollMinutes)
{
    try
    {
        Response<OptimizationJob> getResponse = await jobsClient.GetAsync(createdJobId);
        var status = getResponse.Value.Status.ToString();
        if (status != lastStatus)
        {
            Console.WriteLine($"  [{sw.Elapsed:mm\\:ss}] Status: {status}");
            lastStatus = status;
        }

        if (terminalStates.Contains(status))
        {
            Console.WriteLine($"  ✓ Job reached terminal state: {status} in {sw.Elapsed:mm\\:ss}");

            if (getResponse.Value.Error is not null)
            {
                Console.WriteLine($"  Error: {getResponse.Value.Error.Message}");
            }

            if (getResponse.Value.Progress is not null)
            {
                    Console.WriteLine($"  Progress: iteration={getResponse.Value.Progress.CurrentIteration}, tasks={getResponse.Value.Progress.TasksCompleted}/{getResponse.Value.Progress.TasksTotal}");
            }

            break;
        }
    }
    catch (RequestFailedException ex)
    {
        Console.WriteLine($"  [{sw.Elapsed:mm\\:ss}] Poll error: {ex.Status} {ex.Message}");
    }

    pollCount++;
    await Task.Delay(TimeSpan.FromSeconds(15));
}

if (sw.Elapsed.TotalMinutes >= MaxPollMinutes)
{
    Console.WriteLine($"  ⚠ Timed out after {MaxPollMinutes} minutes. Proceeding anyway.");
}

// ─── Step 4: List candidates (typed) ───────────────────────────────────────
Console.WriteLine("\n── Step 4: List Candidates (typed GetCandidatesAsync) ──");
try
{
    Response<AgentsPagedResultOptimizationCandidate> candidatesResponse =
        await jobsClient.GetCandidatesAsync(createdJobId);

    Console.WriteLine($"  Found {candidatesResponse.Value.Data.Count} candidate(s):");
    foreach (var candidate in candidatesResponse.Value.Data)
    {
        Console.WriteLine($"    • {candidate.CandidateId} | AvgScore: {candidate.AvgScore:F3} | Strategy: {candidate.Strategy}");
    }

    // Get config for the first candidate
    if (candidatesResponse.Value.Data.Count > 0)
    {
        var bestCandidate = candidatesResponse.Value.Data[0];
        Console.WriteLine($"\n  Getting deploy config for candidate: {bestCandidate.CandidateId}");

        Response<CandidateDeployConfig> configResponse =
            await jobsClient.GetCandidateConfigAsync(createdJobId, bestCandidate.CandidateId);
        Console.WriteLine($"    ✓ Deploy config retrieved: model={configResponse.Value.Model ?? "?"}, instructionsLen={configResponse.Value.Instructions?.Length ?? 0}");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"  ✗ GetCandidatesAsync failed: {ex.Status} {ex.ErrorCode}: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"  ✗ GetCandidatesAsync failed: {ex.GetType().Name}: {ex.Message}");
}

// ─── Step 5: Final list to verify ──────────────────────────────────────────
Console.WriteLine("\n── Step 5: Final Job List (verify new job appears) ──");
try
{
    await foreach (OptimizationJob job in jobsClient.GetAllAsync(agentName: AgentName, limit: 3))
    {
        Console.WriteLine($"  {job.Id} | {job.Status} | Created: {job.CreatedAt:u}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"  ✗ Final list failed: {ex.GetType().Name}: {ex.Message}");
}

Console.WriteLine("\n═══════════════════════════════════════════════════════════");
Console.WriteLine("  Done.");
Console.WriteLine("═══════════════════════════════════════════════════════════");
