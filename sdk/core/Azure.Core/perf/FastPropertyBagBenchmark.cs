// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net462)]
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    public class FastPropertyBagBenchmark
    {
        private int readLoops = 30;
        private static MockRequest _req = new();

        [Benchmark]
        // [Arguments(1)]
        [Arguments(2)]
        // [Arguments(3)]
        [Arguments(5)]
        // [Arguments(10)]
        [Arguments(30)]
        public void ArrayBackedPropertyBagPool(int items)
        {
            object val1;
            object val2;
            object val3;
            object val4;
            object val5;
            object val6;
            object val7;
            object val8;
            object val9;
            object val10;
            object val11;
            object val12;
            object val13;
            object val14;
            object val15;
            object val16;
            object val17;
            object val18;
            object val19;
            object val20;
            object val21;
            object val22;
            object val23;
            object val24;
            object val25;
            object val26;
            object val27;
            object val28;
            object val29;
            object val30;

            using HttpMessage message = new HttpMessage(_req, new ResponseClassifier());
            switch (items)
            {
                case 1:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    break;
                case 2:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.TryGetProperty(typeof(T2), out val2);
                    break;
                case 3:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.TryGetProperty(typeof(T2), out val2);
                    message.SetProperty(typeof(T3), new T3() { Value = 1234 });
                    message.TryGetProperty(typeof(T3), out val3);
                    break;
                case 5:
                    var t3 = new T3() { Value = 1234 };
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.TryGetProperty(typeof(T2), out val2);
                    message.SetProperty(typeof(T3), new T3() { Value = 1234 });
                    message.TryGetProperty(typeof(T3), out val3);
                    message.SetProperty(typeof(T4), new T4() { Value = 1234 });
                    message.TryGetProperty(typeof(T4), out val4);
                    message.SetProperty(typeof(T5), new T5() { Value = 1234 });
                    message.TryGetProperty(typeof(T5), out val5);
                    for (int i = 0; i < readLoops; i++)
                    {
                        t3.Value = i;
                        message.SetProperty(typeof(T3), t3);
                    }
                    for (int i = 0; i < readLoops; i++)
                    {
                        message.TryGetProperty(typeof(T4), out val4);
                    }
                    break;

                case 10:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.SetProperty(typeof(T3), new T3() { Value = 1234 });
                    message.SetProperty(typeof(T4), new T4() { Value = 1234 });
                    message.SetProperty(typeof(T5), new T5() { Value = 1234 });
                    message.SetProperty(typeof(T6), new T6() { Value = 1234 });
                    message.SetProperty(typeof(T7), new T7() { Value = 1234 });
                    message.SetProperty(typeof(T8), new T8() { Value = 1234 });
                    message.SetProperty(typeof(T9), new T9() { Value = 1234 });
                    message.SetProperty(typeof(T10), new T10() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.TryGetProperty(typeof(T2), out val2);
                    message.TryGetProperty(typeof(T3), out val3);
                    message.TryGetProperty(typeof(T4), out val4);
                    message.TryGetProperty(typeof(T5), out val5);
                    message.TryGetProperty(typeof(T6), out val6);
                    message.TryGetProperty(typeof(T7), out val7);
                    message.TryGetProperty(typeof(T8), out val8);
                    message.TryGetProperty(typeof(T9), out val9);
                    message.TryGetProperty(typeof(T10), out val10);
                    break;

                case 20:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.SetProperty(typeof(T3), new T3() { Value = 1234 });
                    message.SetProperty(typeof(T4), new T4() { Value = 1234 });
                    message.SetProperty(typeof(T5), new T5() { Value = 1234 });
                    message.SetProperty(typeof(T6), new T6() { Value = 1234 });
                    message.SetProperty(typeof(T7), new T7() { Value = 1234 });
                    message.SetProperty(typeof(T8), new T8() { Value = 1234 });
                    message.SetProperty(typeof(T9), new T9() { Value = 1234 });
                    message.SetProperty(typeof(T10), new T10() { Value = 1234 });
                    message.SetProperty(typeof(T11), new T11() { Value = 1234 });
                    message.SetProperty(typeof(T12), new T12() { Value = 1234 });
                    message.SetProperty(typeof(T13), new T13() { Value = 1234 });
                    message.SetProperty(typeof(T14), new T14() { Value = 1234 });
                    message.SetProperty(typeof(T15), new T15() { Value = 1234 });
                    message.SetProperty(typeof(T16), new T16() { Value = 1234 });
                    message.SetProperty(typeof(T17), new T17() { Value = 1234 });
                    message.SetProperty(typeof(T18), new T18() { Value = 1234 });
                    message.SetProperty(typeof(T19), new T19() { Value = 1234 });
                    message.SetProperty(typeof(T20), new T20() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.TryGetProperty(typeof(T2), out val2);
                    message.TryGetProperty(typeof(T3), out val3);
                    message.TryGetProperty(typeof(T4), out val4);
                    message.TryGetProperty(typeof(T5), out val5);
                    message.TryGetProperty(typeof(T6), out val6);
                    message.TryGetProperty(typeof(T7), out val7);
                    message.TryGetProperty(typeof(T8), out val8);
                    message.TryGetProperty(typeof(T9), out val9);
                    message.TryGetProperty(typeof(T10), out val10);
                    message.TryGetProperty(typeof(T11), out val11);
                    message.TryGetProperty(typeof(T12), out val12);
                    message.TryGetProperty(typeof(T13), out val13);
                    message.TryGetProperty(typeof(T14), out val14);
                    message.TryGetProperty(typeof(T15), out val15);
                    message.TryGetProperty(typeof(T16), out val16);
                    message.TryGetProperty(typeof(T17), out val17);
                    message.TryGetProperty(typeof(T18), out val18);
                    message.TryGetProperty(typeof(T19), out val19);
                    message.TryGetProperty(typeof(T20), out val20);
                    break;
                case 30:
                    message.SetProperty(typeof(T1), new T1() { Value = 1234 });
                    message.SetProperty(typeof(T2), new T2() { Value = 1234 });
                    message.SetProperty(typeof(T3), new T3() { Value = 1234 });
                    message.SetProperty(typeof(T4), new T4() { Value = 1234 });
                    message.SetProperty(typeof(T5), new T5() { Value = 1234 });
                    message.SetProperty(typeof(T6), new T6() { Value = 1234 });
                    message.SetProperty(typeof(T7), new T7() { Value = 1234 });
                    message.SetProperty(typeof(T8), new T8() { Value = 1234 });
                    message.SetProperty(typeof(T9), new T9() { Value = 1234 });
                    message.SetProperty(typeof(T10), new T10() { Value = 1234 });
                    message.SetProperty(typeof(T11), new T11() { Value = 1234 });
                    message.SetProperty(typeof(T12), new T12() { Value = 1234 });
                    message.SetProperty(typeof(T13), new T13() { Value = 1234 });
                    message.SetProperty(typeof(T14), new T14() { Value = 1234 });
                    message.SetProperty(typeof(T15), new T15() { Value = 1234 });
                    message.SetProperty(typeof(T16), new T16() { Value = 1234 });
                    message.SetProperty(typeof(T17), new T17() { Value = 1234 });
                    message.SetProperty(typeof(T18), new T18() { Value = 1234 });
                    message.SetProperty(typeof(T19), new T19() { Value = 1234 });
                    message.SetProperty(typeof(T20), new T20() { Value = 1234 });
                    message.SetProperty(typeof(T21), new T21() { Value = 1234 });
                    message.SetProperty(typeof(T22), new T22() { Value = 1234 });
                    message.SetProperty(typeof(T23), new T23() { Value = 1234 });
                    message.SetProperty(typeof(T24), new T24() { Value = 1234 });
                    message.SetProperty(typeof(T25), new T25() { Value = 1234 });
                    message.SetProperty(typeof(T26), new T26() { Value = 1234 });
                    message.SetProperty(typeof(T27), new T27() { Value = 1234 });
                    message.SetProperty(typeof(T28), new T28() { Value = 1234 });
                    message.SetProperty(typeof(T29), new T29() { Value = 1234 });
                    message.SetProperty(typeof(T30), new T30() { Value = 1234 });
                    message.TryGetProperty(typeof(T1), out val1);
                    message.TryGetProperty(typeof(T2), out val2);
                    message.TryGetProperty(typeof(T3), out val3);
                    message.TryGetProperty(typeof(T4), out val4);
                    message.TryGetProperty(typeof(T5), out val5);
                    message.TryGetProperty(typeof(T6), out val6);
                    message.TryGetProperty(typeof(T7), out val7);
                    message.TryGetProperty(typeof(T8), out val8);
                    message.TryGetProperty(typeof(T9), out val9);
                    message.TryGetProperty(typeof(T10), out val10);
                    message.TryGetProperty(typeof(T11), out val11);
                    message.TryGetProperty(typeof(T12), out val12);
                    message.TryGetProperty(typeof(T13), out val13);
                    message.TryGetProperty(typeof(T14), out val14);
                    message.TryGetProperty(typeof(T15), out val15);
                    message.TryGetProperty(typeof(T16), out val16);
                    message.TryGetProperty(typeof(T17), out val17);
                    message.TryGetProperty(typeof(T18), out val18);
                    message.TryGetProperty(typeof(T19), out val19);
                    message.TryGetProperty(typeof(T20), out val20);
                    message.TryGetProperty(typeof(T21), out val21);
                    message.TryGetProperty(typeof(T22), out val22);
                    message.TryGetProperty(typeof(T23), out val23);
                    message.TryGetProperty(typeof(T24), out val24);
                    message.TryGetProperty(typeof(T25), out val25);
                    message.TryGetProperty(typeof(T26), out val26);
                    message.TryGetProperty(typeof(T27), out val27);
                    message.TryGetProperty(typeof(T28), out val28);
                    message.TryGetProperty(typeof(T29), out val29);
                    message.TryGetProperty(typeof(T30), out val30);
                    break;
            }
        }

        private struct T1
        {
            public int Value { get; set; }
        }

        private struct T2
        {
            public int Value { get; set; }
        }

        private struct T3
        {
            public int Value { get; set; }
        }

        private struct T4
        {
            public int Value { get; set; }
        }

        private struct T5
        {
            public int Value { get; set; }
        }

        private struct T6
        {
            public int Value { get; set; }
        }

        private struct T7
        {
            public int Value { get; set; }
        }

        private struct T8
        {
            public int Value { get; set; }
        }

        private struct T9
        {
            public int Value { get; set; }
        }

        private struct T10
        {
            public int Value { get; set; }
        }

        private struct T11
        {
            public int Value { get; set; }
        }

        private struct T12
        {
            public int Value { get; set; }
        }

        private struct T13
        {
            public int Value { get; set; }
        }

        private struct T14
        {
            public int Value { get; set; }
        }

        private struct T15
        {
            public int Value { get; set; }
        }

        private struct T16
        {
            public int Value { get; set; }
        }

        private struct T17
        {
            public int Value { get; set; }
        }

        private struct T18
        {
            public int Value { get; set; }
        }

        private struct T19
        {
            public int Value { get; set; }
        }

        private struct T20
        {
            public int Value { get; set; }
        }

        private struct T21
        {
            public int Value { get; set; }
        }

        private struct T22
        {
            public int Value { get; set; }
        }

        private struct T23
        {
            public int Value { get; set; }
        }

        private struct T24
        {
            public int Value { get; set; }
        }

        private struct T25
        {
            public int Value { get; set; }
        }

        private struct T26
        {
            public int Value { get; set; }
        }

        private struct T27
        {
            public int Value { get; set; }
        }

        private struct T28
        {
            public int Value { get; set; }
        }

        private struct T29
        {
            public int Value { get; set; }
        }

        private struct T30
        {
            public int Value { get; set; }
        }
    }
}
