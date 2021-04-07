// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;

namespace Proto.Client
{
    class SetTagsOnVm : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private void DumpDictionary(IDictionary<string, string> dic)
        {
            Console.WriteLine(string.Join(
                ", ",
                dic.Select(kvp => kvp.Key + ":" + kvp.Value)));
        }

        private async Task ExecuteAsync()
        {
            // Update Tag for a known resource
            var client = new ArmClient(new DefaultAzureCredential());
            var sub = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var rgOp = sub.GetResourceGroups().Get(Context.RgName).Value;
            var vmOp = rgOp.GetVirtualMachines().Get(Context.VmName).Value;

            Console.WriteLine($"Adding tags to {vmOp.Id.Name}");

            var vm = (await vmOp.StartAddTag("key1", "value1").WaitForCompletionAsync()).Value;
            Debug.Assert(vm.Data.Tags.Where(x => x.Key.StartsWith("key")).Count() == 1);
            DumpDictionary(vm.Data.Tags);

            vm = (await vm.StartAddTag("key2", "value2").WaitForCompletionAsync()).Value;
            Debug.Assert(vm.Data.Tags.Where(x => x.Key.StartsWith("key")).Count() == 2);
            DumpDictionary(vm.Data.Tags);

            vm = (await (await vmOp.StartAddTagAsync("key3", "value3")).WaitForCompletionAsync()).Value;
            Debug.Assert(vm.Data.Tags.Where(x => x.Key.StartsWith("key")).Count() == 3);
            DumpDictionary(vm.Data.Tags);

            vm = (await vm.StartAddTagAsync("key4", "value4")).WaitForCompletionAsync().Result.Value;
            Debug.Assert(vm.Data.Tags.Where(x => x.Key.StartsWith("key")).Count() == 4);
            DumpDictionary(vm.Data.Tags);
        }
    }
}
