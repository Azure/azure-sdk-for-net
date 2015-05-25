using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.WindowsAzure.Management.Monitoring.Alerts.Models;
using Microsoft.Azure.Test;

namespace Monitoring.Tests.Helpers
{
    [UndoHandlerFactory]
    public static partial class UndoContextDiscoveryExtensions
    {
        /// <summary>
        /// Create an undo handler for AlertsClient operations
        /// </summary>
        /// <returns>An undo handler for AlertsClient operations</returns>
        public static OperationUndoHandler CreateAlertsClientUndoHandler()
        {
            return new AlertsClientUndoHandler();
        }
    }

    public class AlertsClientUndoHandler : ReflectingOperationUndoHandler
    {
        public AlertsClientUndoHandler()
        {
            this.ClientTypeName = "RuleOperations";
            this.ClientTypeNamespace = "Microsoft.WindowsAzure.Management.Monitoring.Alerts";
        }

        protected override bool TryFindUndoAction(object client, string method, IDictionary<string, object> parameters,
            out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateOrUpdateAsync":
                    return TryHandleCreateAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleCreateAsync(object client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            RuleCreateOrUpdateParameters ruleCreateOrUpdateParameters =
                parameters["parameters"] as RuleCreateOrUpdateParameters;
            PropertyInfo rulesOperationsProperty = this.GetServiceClientType(client).GetProperty("Rules");
            MethodInfo undoMethod = rulesOperationsProperty.PropertyType.GetMethod("DeleteAsync");
            ParameterInfo[] deleteParameters = undoMethod.GetParameters();
            if (deleteParameters.Length < 1 || deleteParameters[0].ParameterType != typeof (string))
            {
                TraceParameterError(this, "CreateOrUpdateAsync", parameters);
                return false;
            }

            undoAction = () =>
            {
                object serviceClient = this.CreateServiceClient(client);
                object rulesOperations = rulesOperationsProperty.GetValue(serviceClient);
                undoMethod.Invoke(rulesOperations, new object[] {ruleCreateOrUpdateParameters.Rule.Id});
                IDisposable disposableClient = serviceClient as IDisposable;
                if (disposableClient != null)
                {
                    disposableClient.Dispose();
                }
            };
            return true;
        }
    }
}
