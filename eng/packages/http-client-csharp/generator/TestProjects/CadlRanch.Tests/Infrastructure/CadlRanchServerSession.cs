// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace TestProjects.CadlRanch.Tests
{
    public class CadlRanchServerSession : TestServerSessionBase<CadlRanchServer>
    {
        private CadlRanchServerSession() : base()
        {
        }

        public static CadlRanchServerSession Start()
        {
            var server = new CadlRanchServerSession();
            return server;
        }

        public override ValueTask DisposeAsync()
        {
            Return();
            return new ValueTask();
        }
    }
}
