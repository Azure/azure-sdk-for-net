using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace AlertsManagement.Tests.Helpers
{
    public class MockServer
    {
        private List<Alert> mockAlertsStore;

        private List<SmartGroup> mockSmartGroupsStore;

        public MockServer()
        {
            PopulateMockStore();
        }

        #region Mock response generation

        public string GenerateMockResponse(Uri uri)
        {
            string response = "";

            if (uri.LocalPath.Contains("/alerts"))
            {
                response = GenerateMockResponseForAlerts(uri);
            }
            else if (uri.LocalPath.Contains("/smartGroups"))
            {
                response = GenerateMockResponseForSmartGroups(uri);
            }
            else if (uri.LocalPath.Contains("/operations"))
            {
                response = GenerateMockResponseForOperations(uri);
            }

            return response;
        }

        private string GenerateMockResponseForAlerts(Uri uri)
        {
            string response = "";

            if (uri.LocalPath.EndsWith("/alerts"))
            {
                Page<Alert> page = new Page<Alert>();
                page.Items = mockAlertsStore;
                response = Newtonsoft.Json.JsonConvert.SerializeObject(page);
            }
            else if (uri.LocalPath.EndsWith("/alertsSummary"))
            {
                response = Newtonsoft.Json.JsonConvert.SerializeObject(GetTestSummary());
                //string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);
            }
            else if (uri.LocalPath.EndsWith("/changestate"))
            {
                // Extract Alert ID
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                // Fetch alert from store by id
                Alert alert = SearchAlertInStore(id);

                // Extract updated state from query
                string updatedState = ComparisonUtility.ExtractStateFromQuery(uri.Query);

                Alert updatedAlert = CreateAlert(id, alert.Name, updatedState);
                response = Newtonsoft.Json.JsonConvert.SerializeObject(updatedAlert);
            }
            else if (uri.LocalPath.EndsWith("/history"))
            {
                // Extract Alert ID
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                List<AlertModificationItem> modificationitems = new List<AlertModificationItem>
                    {
                        new AlertModificationItem(AlertModificationEvent.AlertCreated),
                        new AlertModificationItem(AlertModificationEvent.StateChange, AlertState.New, AlertState.Closed)
                    };

                AlertModification history = new AlertModification(properties: new AlertModificationProperties(id, modificationitems));
                response = Newtonsoft.Json.JsonConvert.SerializeObject(history);
            }
            else
            {
                // Extract Alert ID
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                // Fetch alert from store by id
                Alert alert = SearchAlertInStore(id);

                response = Newtonsoft.Json.JsonConvert.SerializeObject(alert);
            }

            return response;
        }

        private string GenerateMockResponseForSmartGroups(Uri uri)
        {
            string response = "";

            if (uri.LocalPath.EndsWith("/smartGroups"))
            {
                Page<SmartGroup> page = new Page<SmartGroup>();
                page.Items = mockSmartGroupsStore;
                response = Newtonsoft.Json.JsonConvert.SerializeObject(page);
            }
            else if (uri.LocalPath.EndsWith("/changestate"))
            {
                // Extract smart group id
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                // Fetch alert from store by id
                SmartGroup smartGroup = SearchSmartGroupInStore(id);

                // Extract updated state from query
                string updatedState = ComparisonUtility.ExtractStateFromQuery(uri.Query);

                SmartGroup updatedSmartGroup = CreateTestSmartGroup(id, updatedState);
                response = Newtonsoft.Json.JsonConvert.SerializeObject(updatedSmartGroup);
            }
            else if (uri.LocalPath.EndsWith("/history"))
            {
                // Extract smart group id
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                List<SmartGroupModificationItem> modificationitems = new List<SmartGroupModificationItem>
                    {
                        new SmartGroupModificationItem(SmartGroupModificationEvent.AlertAdded),
                        new SmartGroupModificationItem(SmartGroupModificationEvent.StateChange, AlertState.New, AlertState.Closed)
                    };

                SmartGroupModification history = new SmartGroupModification(properties: new SmartGroupModificationProperties(id, modificationitems));
                response = Newtonsoft.Json.JsonConvert.SerializeObject(history);
            }
            else
            {
                // Extract smart group ID
                string id = ComparisonUtility.ExtractIdFromLocalPath(uri.LocalPath);

                // Fetch smart group from store by id
                SmartGroup alert = SearchSmartGroupInStore(id);

                response = Newtonsoft.Json.JsonConvert.SerializeObject(alert);
            }

            return response;
        }

        private string GenerateMockResponseForOperations(Uri uri)
        {
            string response = "";

            return response;
        }

        private Alert SearchAlertInStore(string id)
        {
            Alert alert = new Alert();
            foreach (var temp in mockAlertsStore)
            {
                if (temp.Id == id)
                {
                    alert = temp;
                }
            }

            return alert;
        }

        private SmartGroup SearchSmartGroupInStore(string id)
        {
            SmartGroup smartGroup = new SmartGroup();
            foreach (var temp in mockSmartGroupsStore)
            {
                if (temp.Id == id)
                {
                    smartGroup = temp;
                }
            }

            return smartGroup;
        }
        #endregion

        #region Mock data creation
        private void PopulateMockStore()
        {
            mockAlertsStore = GetTestAlertsList();
            mockSmartGroupsStore = GetTestSmartGroupList();
        }

        private List<Alert> GetTestAlertsList()
        {
            return new List<Alert>
            {
                CreateAlert("249a7944-dabc-4c80-8025-61165619d78f", "Alert Name 1"),
                CreateAlert(Guid.NewGuid().ToString(), "Alert Name 2"),
                CreateAlert(Guid.NewGuid().ToString(), "Alert Name 3")
            };
        }

        private Alert GetAlertById(string id)
        {
            return CreateAlert(id);
        }

        private Alert CreateAlert(string id = "Alert ID", string name = "Alert Name", string alertState = AlertState.New)
        {
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>
            {
                {"key1", "value1"},
                {"key2", "value2"}
            };

            Essentials essentials = new Essentials(
                severity: Severity.Sev2,
                signalType: SignalType.Metric,
                alertState: alertState,
                monitorCondition: MonitorCondition.Fired,
                targetResource: "r1",
                targetResourceGroup: "rg1",
                targetResourceName: "target resource",
                monitorService: MonitorService.Platform,
                sourceCreatedId: "ID",
                smartGroupId: "Smart Group ID",
                smartGroupingReason: "Based on Similarity",
                startDateTime: new DateTime(2019, 6, 19, 12, 30, 45),
                lastModifiedDateTime: new DateTime(2019, 6, 20, 11, 45, 9),
                lastModifiedUserName: "System"
                );

            AlertProperties properties = new AlertProperties(essentials);
            return new Alert(
                id: id,
                name: name,
                properties: properties
            );
        }

        private AlertsSummary GetTestSummary()
        {
            AlertsSummaryGroup group = new AlertsSummaryGroup(
                    total: 7,
                    smartGroupsCount: 2,
                    groupedby: "Severity",
                    values: new List<AlertsSummaryGroupItem>
                    {
                        new AlertsSummaryGroupItem("Sev0", 4, "AlertState", new List<AlertsSummaryGroupItem>{
                            new AlertsSummaryGroupItem("New", 1),
                            new AlertsSummaryGroupItem("Closed", 3)
                        }),
                        new AlertsSummaryGroupItem("Sev2", 3, "AlertState", new List<AlertsSummaryGroupItem>{
                            new AlertsSummaryGroupItem("New", 1),
                            new AlertsSummaryGroupItem("Acknowledged", 2)
                        })
                    }
                );

            return new AlertsSummary(properties: group);
        }

        private List<SmartGroup> GetTestSmartGroupList()
        {
            return new List<SmartGroup>
            {
                CreateTestSmartGroup("249a7944-dabc-4c80-8025-61165619d78f"),
                CreateTestSmartGroup(Guid.NewGuid().ToString()),
                CreateTestSmartGroup(Guid.NewGuid().ToString())
            };
        }

        private SmartGroup CreateTestSmartGroup(string smartGroupId, string smartGroupState = "New")
        {
            return new SmartGroup(
                id: smartGroupId,
                alertsCount: 10,
                smartGroupState: smartGroupState,
                severity: Severity.Sev2,
                startDateTime: new DateTime(2019, 6, 19, 12, 30, 45),
                lastModifiedDateTime: new DateTime(2019, 6, 20, 11, 45, 9),
                lastModifiedUserName: "System"
            );
        }

        private SmartGroupModification GetTestSmartGroupHistory(string id)
        {
            List<SmartGroupModificationItem> modificationitems = new List<SmartGroupModificationItem>
            {
                new SmartGroupModificationItem(SmartGroupModificationEvent.SmartGroupCreated),
                new SmartGroupModificationItem(SmartGroupModificationEvent.AlertAdded, "AddedAlertId"),
                new SmartGroupModificationItem(SmartGroupModificationEvent.AlertRemoved, "RemovedAlertId"),
                new SmartGroupModificationItem(SmartGroupModificationEvent.StateChange, AlertState.New, AlertState.Closed)
            };

            SmartGroupModification history = new SmartGroupModification(properties: new SmartGroupModificationProperties(id, modificationitems));

            return history;
        }
        #endregion
    }
}
