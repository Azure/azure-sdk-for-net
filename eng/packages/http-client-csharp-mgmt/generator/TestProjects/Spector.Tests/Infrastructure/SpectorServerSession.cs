// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace TestProjects.Spector.Tests
{
    public class SpectorServerSession : TestServerSessionBase<SpectorServer>
    {
        private SpectorServerSession() : base()
        {
        }

        public static SpectorServerSession Start()
        {
            var server = new SpectorServerSession();
            return server;
        }

        public override ValueTask DisposeAsync()
        {
            Return();
            return new ValueTask();
        }
    }
}
