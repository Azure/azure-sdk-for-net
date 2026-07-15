// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

[NonParallelizable]
[LiveOnly]
public class SamplesRoutineBase : ProjectsClientTestBase
{
    protected readonly string SAMPLE_ROUTINE_NAME_PREFIX = "sample-routine";

    #region Snippet:Sample_HandleRunError_Routines
    protected static void CheckRunResult(RoutineRun completedRun, int minutesWait, bool runCreated)
    {
        if (completedRun == null)
        {
            if (runCreated)
            {
                throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
            }
            else
            {
                throw new InvalidOperationException("The run was not created.");
            }
        }
        if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException("The run was forcefully stopped.");
        }
        if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        }
    }
    #endregion

    public SamplesRoutineBase(bool isAsync) : base(isAsync)
    { }

    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, GetTestTokenProvider());
        // Remove Routines
        List<string> routines = await projectClient.Routines.GetRoutinesAsync().Where(x => x.Name.StartsWith(SAMPLE_ROUTINE_NAME_PREFIX)).Select(x => x.Name).ToListAsync();
        foreach (string routineName in routines)
        {
            await projectClient.Routines.DeleteAsync(routineName);
        }
    }
}
