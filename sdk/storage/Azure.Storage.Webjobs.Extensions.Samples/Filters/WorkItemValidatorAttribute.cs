// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SampleHost.Models;

namespace SampleHost.Filters
{
    /// <summary>
    /// Sample invocation filter that demonstrates how declarative validation logic
    /// can be integrated into the execution pipeline.
    /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete
    public class WorkItemValidatorAttribute : FunctionInvocationFilterAttribute
#pragma warning restore CS0618 // Type or member is obsolete
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            executingContext.Logger.LogInformation("WorkItemValidator executing...");

            var workItem = executingContext.Arguments.First().Value as WorkItem;
            string errorMessage = null;
            if (!TryValidateWorkItem(workItem, out errorMessage))
            {
                executingContext.Logger.LogError(errorMessage);
                throw new ValidationException(errorMessage);
            }

            return base.OnExecutingAsync(executingContext, cancellationToken);
        }

        private static bool TryValidateWorkItem(WorkItem workItem, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrEmpty(workItem.ID))
            {
                errorMessage = "ID cannot be null or empty.";
                return false;
            }
            if (workItem.Priority > 100 || workItem.Priority < 0)
            {
                errorMessage = "Priority must be between 0 and 100";
                return false;
            }

            return true;
        }
    }
}
