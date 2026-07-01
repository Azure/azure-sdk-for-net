// Live API test: exercises internal protocol methods via reflection against the E2E Foundry endpoint.
// All generated methods are internal — this test uses reflection to invoke them.
// Run with: dotnet run --project tests/LiveApiTest
// Requires: az login (DefaultAzureCredential)

using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Azure;
using Azure.AI.AgentServer.Optimization;
using Azure.Core;
using Azure.Identity;

const string ProjectEndpoint = "https://e2e-tests-westus2-account.services.ai.azure.com/api/projects/faos-e2e-tests";
const string AgentName = "travel-agent-sample";
const string EvalModel = "gpt-5";
const int MaxIterations = 3;
const string FoundryFeatures = "AgentsOptimization=V1Preview";

var credential = new DefaultAzureCredential();
var client = new AgentOptimizationClient(new Uri(ProjectEndpoint), credential);

Console.WriteLine("═══════════════════════════════════════════════════════════");
Console.WriteLine("  Live API Test: Protocol Methods (via reflection)");
Console.WriteLine("═══════════════════════════════════════════════════════════");

// ─── Step 1: List existing jobs ────────────────────────────────────────────
Console.WriteLine("\n── Step 1: List Existing Jobs ──");
try
{
    int count = 0;
    var pages = InvokeGetAll(client, FoundryFeatures, limit: 5);
    await foreach (BinaryData page in pages)
    {
        using var doc = JsonDocument.Parse(page);
        var id = doc.RootElement.GetProperty("id").GetString();
        var status = doc.RootElement.GetProperty("status").GetString();
        Console.WriteLine($"  {id} | {status}");
        count++;
    }
    Console.WriteLine($"  Listed {count} job(s) successfully ✓");
}
catch (Exception ex)
{
    Console.WriteLine($"  ✗ List failed: {ex.GetType().Name}: {ex.Message}");
}

// ─── Step 2: Create a new job ──────────────────────────────────────────────
Console.WriteLine("\n── Step 2: Create Optimization Job ──");
Console.WriteLine($"  Agent: {AgentName}, MaxIterations: {MaxIterations}, EvalModel: {EvalModel}");

var body = BinaryData.FromObjectAsJson(new
{
    agent = new { agent_name = AgentName },
    evaluators = new[] { "task_adherence" },
    options = new
    {
        max_iterations = MaxIterations,
        eval_model = EvalModel,
        optimization_model = EvalModel,
    },
    dataset = new[]
    {
        new { name = "tokyo_visit", query = "What's the best time to visit Tokyo?" },
        new { name = "paris_budget", query = "Plan a 3-day trip to Paris on a budget." },
        new { name = "nyc_london", query = "Compare direct flights from NYC to London." },
    }
});

string? createdJobId = null;
try
{
    Response createResponse = await InvokeCreateAsync(client, body, FoundryFeatures);
    using var createDoc = JsonDocument.Parse(createResponse.Content);
    createdJobId = createDoc.RootElement.GetProperty("id").GetString();
    var createStatus = createDoc.RootElement.GetProperty("status").GetString();
    Console.WriteLine($"  ✓ Created job: {createdJobId} | Status: {createStatus}");
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"  ✗ Create failed: {ex.Status} {ex.ErrorCode}: {ex.Message}");
}

if (createdJobId is null)
{
    Console.WriteLine("\n  Cannot proceed without a created job. Exiting.");
    return;
}

// ─── Step 3: Poll until terminal ───────────────────────────────────────────
Console.WriteLine("\n── Step 3: Poll Job Until Terminal ──");
var sw = Stopwatch.StartNew();
var terminalStates = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "completed", "succeeded", "failed", "cancelled" };
string lastStatus = "";
const int MaxPollMinutes = 20;

while (sw.Elapsed.TotalMinutes < MaxPollMinutes)
{
    try
    {
        Response getResponse = await InvokeGetAsync(client, createdJobId, FoundryFeatures);
        using var getDoc = JsonDocument.Parse(getResponse.Content);
        var status = getDoc.RootElement.GetProperty("status").GetString()!;
        if (status != lastStatus)
        {
            Console.WriteLine($"  [{sw.Elapsed:mm\\:ss}] Status: {status}");
            lastStatus = status;
        }

        if (terminalStates.Contains(status))
        {
            Console.WriteLine($"  ✓ Job reached terminal state: {status} in {sw.Elapsed:mm\\:ss}");
            if (getDoc.RootElement.TryGetProperty("error", out var errorEl))
            {
                Console.WriteLine($"  Error: {errorEl.GetProperty("message").GetString()}");
            }
            break;
        }
    }
    catch (RequestFailedException ex)
    {
        Console.WriteLine($"  [{sw.Elapsed:mm\\:ss}] Poll error: {ex.Status} {ex.Message}");
    }

    await Task.Delay(TimeSpan.FromSeconds(15));
}

if (sw.Elapsed.TotalMinutes >= MaxPollMinutes)
{
    Console.WriteLine($"  ⚠ Timed out after {MaxPollMinutes} minutes.");
}

// ─── Step 4: List candidates ───────────────────────────────────────────────
Console.WriteLine("\n── Step 4: List Candidates ──");
try
{
    Response candidatesResponse = await InvokeGetCandidatesAsync(client, createdJobId, FoundryFeatures);
    using var candDoc = JsonDocument.Parse(candidatesResponse.Content);
    var data = candDoc.RootElement.GetProperty("data");
    Console.WriteLine($"  Found {data.GetArrayLength()} candidate(s):");
    string? bestCandId = null;
    foreach (var candidate in data.EnumerateArray())
    {
        var candId = candidate.GetProperty("candidate_id").GetString();
        var avgScore = candidate.GetProperty("avg_score").GetDouble();
        Console.WriteLine($"    • {candId} | AvgScore: {avgScore:F3}");
        bestCandId ??= candId;
    }

    if (bestCandId is not null)
    {
        Console.WriteLine($"\n  Getting deploy config for candidate: {bestCandId}");
        Response configResponse = await InvokeGetCandidateConfigFlatAsync(client, bestCandId, FoundryFeatures);
        using var configDoc = JsonDocument.Parse(configResponse.Content);
        var model = configDoc.RootElement.TryGetProperty("model", out var m) ? m.GetString() : "?";
        var instrLen = configDoc.RootElement.TryGetProperty("instructions", out var i) ? i.GetString()?.Length ?? 0 : 0;
        Console.WriteLine($"    ✓ Deploy config: model={model}, instructionsLen={instrLen}");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"  ✗ Candidates failed: {ex.Status} {ex.ErrorCode}: {ex.Message}");
}

Console.WriteLine("\n═══════════════════════════════════════════════════════════");
Console.WriteLine("  Done.");
Console.WriteLine("═══════════════════════════════════════════════════════════");

// ── Reflection helpers ─────────────────────────────────────────────────────

static MethodInfo GetMethod(string name, params Type[] paramTypes) =>
    typeof(AgentOptimizationClient).GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, paramTypes, null)
    ?? throw new MissingMethodException(nameof(AgentOptimizationClient), name);

static AsyncPageable<BinaryData> InvokeGetAll(AgentOptimizationClient client, string features, int? limit)
{
    // GetAllAsync(string foundryFeatures, int? limit, string? order, string? after, string? before, string? status, string? agentName, RequestContext context)
    var method = GetMethod("GetAllAsync",
        typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext));
    return (AsyncPageable<BinaryData>)method.Invoke(client, [features, limit, null, null, null, null, null, null])!;
}

static async Task<Response> InvokeCreateAsync(AgentOptimizationClient client, BinaryData body, string features)
{
    // CreateAsync(RequestContent content, string foundryFeatures, string? repeatabilityRequestId, string? repeatabilityFirstSent, RequestContext context)
    var method = GetMethod("CreateAsync",
        typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(RequestContext));
    return await (Task<Response>)method.Invoke(client, [RequestContent.Create(body), features, null, null, null])!;
}

static async Task<Response> InvokeGetAsync(AgentOptimizationClient client, string jobId, string features)
{
    // GetAsync(string jobId, string foundryFeatures, RequestContext context)
    var method = GetMethod("GetAsync",
        typeof(string), typeof(string), typeof(RequestContext));
    return await (Task<Response>)method.Invoke(client, [jobId, features, null])!;
}

static async Task<Response> InvokeGetCandidatesAsync(AgentOptimizationClient client, string jobId, string features)
{
    // GetCandidatesAsync(string jobId, string foundryFeatures, int? limit, string? order, string? after, string? before, RequestContext context)
    var method = GetMethod("GetCandidatesAsync",
        typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestContext));
    return await (Task<Response>)method.Invoke(client, [jobId, features, null, null, null, null, null])!;
}

static async Task<Response> InvokeGetCandidateConfigFlatAsync(AgentOptimizationClient client, string candidateId, string features)
{
    // GetCandidateConfigFlatAsync(string candidateId, string foundryFeatures, RequestContext context)
    var method = GetMethod("GetCandidateConfigFlatAsync",
        typeof(string), typeof(string), typeof(RequestContext));
    return await (Task<Response>)method.Invoke(client, [candidateId, features, null])!;
}
