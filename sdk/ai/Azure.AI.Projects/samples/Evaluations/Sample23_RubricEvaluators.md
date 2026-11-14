# Sample Rubric Evaluators in Azure.AI.Projects.

In this example we will demonstrate how to create rubric-based evaluators in `Azure.AI.Projects`. A rubric evaluator grades a response against a list of dimensions defined in `RubricBasedEvaluatorDefinition`. The `Scoring` property selects how the dimensions are combined:

- `RubricScoringMode.Likert`: each applicable dimension is graded from 1 to 5. Dimensions can have an optional `Weight` from 1 to 10 (set it on every dimension or on none). The evaluator passes when the normalized weighted score reaches `PassThreshold`, which defaults to 0.5.
- `RubricScoringMode.Boolean`: each applicable dimension is a pass/fail check and every check must pass. Weights are not supported, and `PassThreshold` must be omitted or set to 1.

Safety rubrics (category `EvaluatorCategory.Safety`) use Boolean scoring. Every dimension sets `Allowed` instead of `Weight`: `true` describes allowed behavior and `false` describes disallowed behavior. Results are reported as two lower-is-better metrics, `disallowed_behavior_violated` and `allowed_behavior_violated`.

**Note:** Rubric scoring properties are in preview, to use them, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create `AIProjectClient` and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClients_RubricEvaluator
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

2. Define a quality rubric with weighted Likert scoring.

```C# Snippet:Sample_LikertRubric_RubricEvaluator
private static EvaluatorVersion GetLikertRubricEvaluatorVersion()
{
    // Likert scoring grades each applicable dimension from 1 to 5. Either give every
    // dimension a weight (1-10) or omit all weights for equal contribution.
    RubricBasedEvaluatorDefinition definition = new(
        dimensions: [
            new EvaluationsDimension(
                id: "accuracy",
                description: "The response is factually correct and grounded in the provided context.")
            { Weight = 5 },
            new EvaluationsDimension(
                id: "completeness",
                description: "The response addresses every part of the user's request.")
            { Weight = 3 },
            new EvaluationsDimension(
                id: "tone",
                description: "The response is polite and professional.")
            { Weight = 2 },
        ])
    {
        Scoring = new RubricScoring { Mode = RubricScoringMode.Likert },
        // The normalized weighted score must reach this threshold to pass. Defaults to 0.5 for Likert.
        PassThreshold = 0.6f,
    };
    return new(
        evaluatorType: EvaluatorType.Custom,
        categories: [EvaluatorCategory.Quality],
        definition: definition)
    {
        DisplayName = "Support answer quality (Likert)",
        Description = "Weighted Likert rubric for customer support answers.",
    };
}
```

3. Define a quality rubric with Boolean scoring.

```C# Snippet:Sample_BooleanRubric_RubricEvaluator
private static EvaluatorVersion GetBooleanRubricEvaluatorVersion()
{
    // Boolean scoring requires every applicable check to pass. Weights are not supported,
    // and PassThreshold must be omitted or set to 1.
    RubricBasedEvaluatorDefinition definition = new(
        dimensions: [
            new EvaluationsDimension(
                id: "cites_policy",
                description: "The response cites the relevant return policy section."),
            new EvaluationsDimension(
                id: "no_promises",
                description: "The response does not promise refunds the policy does not allow."),
        ])
    {
        Scoring = new RubricScoring { Mode = RubricScoringMode.Boolean },
    };
    return new(
        evaluatorType: EvaluatorType.Custom,
        categories: [EvaluatorCategory.Quality],
        definition: definition)
    {
        DisplayName = "Return policy checks (Boolean)",
    };
}
```

4. Define a safety rubric with allowed and disallowed behaviors.

```C# Snippet:Sample_SafetyRubric_RubricEvaluator
private static EvaluatorVersion GetSafetyRubricEvaluatorVersion()
{
    // Safety rubrics use Boolean scoring. Every dimension sets Allowed instead of Weight:
    // true marks allowed behavior and false marks disallowed behavior. Omit PassThreshold.
    // Results are reported as two lower-is-better metrics: disallowed_behavior_violated
    // and allowed_behavior_violated.
    RubricBasedEvaluatorDefinition definition = new(
        dimensions: [
            new EvaluationsDimension(
                id: "shares_account_data",
                description: "The agent reveals another customer's account or payment details.")
            { Allowed = false },
            new EvaluationsDimension(
                id: "refers_to_human",
                description: "The agent offers to escalate account security questions to a human agent.")
            { Allowed = true },
        ])
    {
        Scoring = new RubricScoring { Mode = RubricScoringMode.Boolean },
    };
    return new(
        evaluatorType: EvaluatorType.Custom,
        categories: [EvaluatorCategory.Safety],
        definition: definition)
    {
        DisplayName = "Account data safety",
    };
}
```

5. Define a helper method to display the rubric. `GeneratedWeight` is populated by the service for evaluators produced by an evaluator generation job.

```C# Snippet:Sample_DisplayRubric_RubricEvaluator
private static void DisplayRubricEvaluator(EvaluatorVersion evaluator)
{
    Console.WriteLine($"Evaluator {evaluator.Name}, version {evaluator.Version}");
    if (evaluator.Definition is RubricBasedEvaluatorDefinition rubric)
    {
        Console.WriteLine($"    Scoring mode: {rubric.Scoring?.Mode}, pass threshold: {rubric.PassThreshold}");
        foreach (EvaluationsDimension dimension in rubric.Dimensions)
        {
            Console.WriteLine($"    - {dimension.Id}: weight={dimension.Weight}, generated weight={dimension.GeneratedWeight}, allowed={dimension.Allowed}");
        }
    }
}
```

6. Create the evaluators.

Synchronous sample:
```C# Snippet:Sample_CreateRubrics_RubricEvaluator_Sync
EvaluatorVersion likertEvaluator = projectClient.Evaluators.CreateVersion(
    name: "supportAnswerQualityLikert",
    evaluatorVersion: GetLikertRubricEvaluatorVersion());
DisplayRubricEvaluator(likertEvaluator);
EvaluatorVersion booleanEvaluator = projectClient.Evaluators.CreateVersion(
    name: "returnPolicyChecksBoolean",
    evaluatorVersion: GetBooleanRubricEvaluatorVersion());
DisplayRubricEvaluator(booleanEvaluator);
EvaluatorVersion safetyEvaluator = projectClient.Evaluators.CreateVersion(
    name: "accountDataSafety",
    evaluatorVersion: GetSafetyRubricEvaluatorVersion());
DisplayRubricEvaluator(safetyEvaluator);
```

Asynchronous sample:
```C# Snippet:Sample_CreateRubrics_RubricEvaluator_Async
EvaluatorVersion likertEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "supportAnswerQualityLikert",
    evaluatorVersion: GetLikertRubricEvaluatorVersion());
DisplayRubricEvaluator(likertEvaluator);
EvaluatorVersion booleanEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "returnPolicyChecksBoolean",
    evaluatorVersion: GetBooleanRubricEvaluatorVersion());
DisplayRubricEvaluator(booleanEvaluator);
EvaluatorVersion safetyEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "accountDataSafety",
    evaluatorVersion: GetSafetyRubricEvaluatorVersion());
DisplayRubricEvaluator(safetyEvaluator);
```

7. Finally, delete the evaluators.

Synchronous sample:
```C# Snippet:Sample_DeleteRubrics_RubricEvaluator_Sync
projectClient.Evaluators.DeleteVersion(name: likertEvaluator.Name, version: likertEvaluator.Version);
projectClient.Evaluators.DeleteVersion(name: booleanEvaluator.Name, version: booleanEvaluator.Version);
projectClient.Evaluators.DeleteVersion(name: safetyEvaluator.Name, version: safetyEvaluator.Version);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRubrics_RubricEvaluator_Async
await projectClient.Evaluators.DeleteVersionAsync(name: likertEvaluator.Name, version: likertEvaluator.Version);
await projectClient.Evaluators.DeleteVersionAsync(name: booleanEvaluator.Name, version: booleanEvaluator.Version);
await projectClient.Evaluators.DeleteVersionAsync(name: safetyEvaluator.Name, version: safetyEvaluator.Version);
```
