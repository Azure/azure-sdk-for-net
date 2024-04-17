// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Azure.Patch.PerfTests
{
    public class StringComparison
    {
        public void Run()
        {
            BenchmarkRunner.Run<StringComparisonPerf>();
        }
    }

    [MemoryDiagnoser]
    public class StringComparisonPerf
    {
        [Benchmark]
        public void CallSwitchCase2Branch()
        {
            _ = SwitchCase2Branch("BaseDict");
        }

        [Benchmark]
        public void CallOperator2Branch()
        {
            _ = Operator2Branch("BaseDict"u8);
        }

        [Benchmark]
        public void CallSwitchCase8Branch()
        {
            _ = SwitchCase8Branch("a6");
        }

        [Benchmark]
        public void CallOperator8Branch()
        {
            _ = Operator8Branch("a6"u8);
        }

        public bool SwitchCase2Branch(string name)
        {
            switch (name)
            {
                case "BaseValue":
                    return true;
                case "BaseDict":
                    return true;
                default:
                    return false;
            }
        }

        public bool Operator2Branch(ReadOnlySpan<byte> name)
        {
            if (name == "BaseValue"u8)
            {
                return true;
            }
            else if (name == "BaseDict"u8)
            {
                return true;
            }

            return false;
        }

        public bool SwitchCase8Branch(string name)
        {
            switch (name)
            {
                case "a1":
                    return true;
                case "a2":
                    return true;
                case "a3":
                    return true;
                case "a4":
                    return true;
                case "a5":
                    return true;
                case "a6":
                    return true;
                case "a7":
                    return true;
                case "a8":
                    return true;
                default:
                    return false;
            }
        }

        public bool Operator8Branch(ReadOnlySpan<byte> name)
        {
            if (name == "a1"u8)
            {
                return true;
            }
            else if (name == "a2"u8)
            {
                return true;
            }
            else if (name == "a3"u8)
            {
                return true;
            }
            else if (name == "a4"u8)
            {
                return true;
            }
            else if (name == "a5"u8)
            {
                return true;
            }
            else if (name == "a6"u8)
            {
                return true;
            }
            else if (name == "a7"u8)
            {
                return true;
            }
            else if (name == "a8"u8)
            {
                return true;
            }
            return false;
        }
    }
}
