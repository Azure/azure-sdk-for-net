using System;
using System.Linq;
using System.Reflection;

namespace Proto.Client
{
    enum Scenarios
    {
        All,
        GetVMTaskExamples,
        CreateSingleVmExample,
        CreateSingleVMCheckLocation,
        ShutdownVmsByName,
        StartStopVm,
        StartFromVm,
        SetTagsOnVm,
        ShutdownVmsByTag,
        CreateMultipleVms,
        GenericEntityLoop,
        ShutdownVmsByLINQ,
        ShutdownVmsByNameAcrossResourceGroups,
        //ShutdownVmsByNameAcrossSubscriptions,
        ListByNameExpanded,
        ClientOptionsOverride,
        GetSubscription,
        NullDataValues,
        //RoleAssignment,
        //DeleteGeneric,
        //AddTagToGeneric,
        CheckResourceExists,
        GetFromOperations,
        CreateSingleVmExampleAsync,
        StartCreateSingleVmExampleAsync,
        StartCreateSingleVmExample,
        DefaultSubscription,
        SubscriptionExists,
        UseParentLocation,
    }

    class ScenarioFactory
    {
        public static Scenario GetScenario(Scenarios scenario)
        {
            switch(scenario)
            {
                default:
                    var type = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.Name == scenario.ToString())
                        .First();
                    return Activator.CreateInstance(type) as Scenario;
            }
        }
    }
}
