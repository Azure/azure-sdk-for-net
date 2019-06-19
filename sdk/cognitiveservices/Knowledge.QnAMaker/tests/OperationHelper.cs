using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QnAMaker.Tests
{
    public static class OperationHelper
    {
        public static Operation MonitorOperation(Operation operation, IQnAMakerClient client)
        {
            // Loop while operation is success
            for (int i = 0;
                i < 20 && (operation.OperationState == OperationStateType.NotStarted || operation.OperationState == OperationStateType.Running);
                i++)
            {
                // Uncomment when recording Thread.Sleep(1000);
                operation = client.Operations.GetDetailsAsync(operation.OperationId).Result;
            }

            return operation;
        }
    }
}
