// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//|           Categories | count |                           Method |         Mean |      Error |     StdDev | Ratio |  Gen 0 |  Gen 1 | Allocated |
//|--------------------- |------ |--------------------------------- |-------------:|-----------:|-----------:|------:|-------:|-------:|----------:|
//|                  Add |     2 |                       Dictionary |    58.775 ns |  0.3567 ns |  0.3162 ns |  1.00 | 0.0023 |      - |     216 B |
//|                  Add |     2 |   ArrayBackedPropertyBag Dispose |     7.994 ns |  0.0537 ns |  0.0476 ns |  0.14 |      - |      - |         - |
//|                  Add |     2 |           ArrayBackedPropertyBag |     7.648 ns |  0.0441 ns |  0.0413 ns |  0.13 |      - |      - |         - |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|                  Add |    10 |                       Dictionary |   298.463 ns |  1.4606 ns |  1.2948 ns |  1.00 | 0.0105 |      - |     992 B |
//|                  Add |    10 |   ArrayBackedPropertyBag Dispose |   109.127 ns |  0.1198 ns |  0.1001 ns |  0.37 |      - |      - |         - |
//|                  Add |    10 |           ArrayBackedPropertyBag |   112.202 ns |  0.6289 ns |  0.5575 ns |  0.38 | 0.0029 |      - |     280 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|                  Add |    30 |                       Dictionary |   679.226 ns |  3.4139 ns |  3.0264 ns |  1.00 | 0.0219 |      - |   2,080 B |
//|                  Add |    30 |   ArrayBackedPropertyBag Dispose |   495.500 ns |  0.8588 ns |  0.7171 ns |  0.73 |      - |      - |         - |
//|                  Add |    30 |           ArrayBackedPropertyBag |   549.329 ns |  2.3681 ns |  1.9775 ns |  0.81 | 0.0048 |      - |     536 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|                  Add |   100 |                       Dictionary | 2,607.939 ns | 16.1310 ns | 15.0889 ns |  1.00 | 0.1068 | 0.0038 |  10,192 B |
//|                  Add |   100 |   ArrayBackedPropertyBag Dispose | 3,958.022 ns |  2.0028 ns |  1.8734 ns |  1.52 |      - |      - |         - |
//|                  Add |   100 |           ArrayBackedPropertyBag | 4,137.429 ns |  8.2181 ns |  6.8625 ns |  1.59 | 0.0153 |      - |   2,072 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|         AddAndSearch |     2 |                       Dictionary |    69.193 ns |  0.0814 ns |  0.0635 ns |  1.00 | 0.0023 |      - |     216 B |
//|         AddAndSearch |     2 |                            Array |    44.743 ns |  0.0486 ns |  0.0380 ns |  0.65 |      - |      - |         - |
//|         AddAndSearch |     2 |   ArrayBackedPropertyBag Dispose |    12.617 ns |  0.0739 ns |  0.0691 ns |  0.18 |      - |      - |         - |
//|         AddAndSearch |     2 |           ArrayBackedPropertyBag |    14.015 ns |  0.0910 ns |  0.0807 ns |  0.20 |      - |      - |         - |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|         AddAndSearch |    10 |                       Dictionary |   354.885 ns |  0.5223 ns |  0.4361 ns |  1.00 | 0.0105 |      - |     992 B |
//|         AddAndSearch |    10 |                            Array |   140.876 ns |  0.2853 ns |  0.2529 ns |  0.40 |      - |      - |         - |
//|         AddAndSearch |    10 |   ArrayBackedPropertyBag Dispose |   167.121 ns |  0.4608 ns |  0.3848 ns |  0.47 |      - |      - |         - |
//|         AddAndSearch |    10 |           ArrayBackedPropertyBag |   174.539 ns |  0.2559 ns |  0.2137 ns |  0.49 | 0.0029 |      - |     280 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|         AddAndSearch |    30 |                       Dictionary |   842.348 ns |  2.0505 ns |  1.7122 ns |  1.00 | 0.0219 |      - |   2,080 B |
//|         AddAndSearch |    30 |                            Array |   783.189 ns |  1.6935 ns |  1.4141 ns |  0.93 |      - |      - |         - |
//|         AddAndSearch |    30 |   ArrayBackedPropertyBag Dispose | 1,062.949 ns |  4.1877 ns |  3.7123 ns |  1.26 |      - |      - |         - |
//|         AddAndSearch |    30 |           ArrayBackedPropertyBag |   983.893 ns |  5.6787 ns |  5.3118 ns |  1.17 | 0.0038 |      - |     536 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|         AddAndSearch |   100 |                       Dictionary | 3,205.095 ns | 14.6559 ns | 12.9920 ns |  1.00 | 0.1068 |      - |  10,192 B |
//|         AddAndSearch |   100 |                            Array | 8,188.936 ns | 26.7824 ns | 25.0522 ns |  2.56 |      - |      - |         - |
//|         AddAndSearch |   100 |   ArrayBackedPropertyBag Dispose | 9,617.326 ns |  6.4288 ns |  5.0192 ns |  3.00 |      - |      - |         - |
//|         AddAndSearch |   100 |           ArrayBackedPropertyBag | 9,248.835 ns |  8.1260 ns |  7.6011 ns |  2.89 | 0.0153 |      - |   2,072 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|            AddAndGet |    30 |                       Dictionary |   830.138 ns |  1.3406 ns |  1.0466 ns |  1.00 | 0.0219 |      - |   2,080 B |
//|            AddAndGet |    30 |           ArrayBackedPropertyBag |   960.831 ns |  0.8947 ns |  0.6985 ns |  1.16 | 0.0038 |      - |     536 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|            AddAndGet |   100 |                       Dictionary | 3,163.041 ns |  9.0416 ns |  8.4575 ns |  1.00 | 0.1068 |      - |  10,192 B |
//|            AddAndGet |   100 |           ArrayBackedPropertyBag | 8,256.591 ns | 10.8845 ns |  9.0890 ns |  2.61 | 0.0153 |      - |   2,072 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|   AddAndDeleteSingle |    10 |                       Dictionary |   301.349 ns |  1.5019 ns |  1.4048 ns |  1.00 | 0.0105 |      - |     992 B |
//|   AddAndDeleteSingle |    10 |           ArrayBackedPropertyBag |   120.107 ns |  0.4251 ns |  0.3769 ns |  0.40 | 0.0029 |      - |     280 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|   AddAndDeleteSingle |    30 |                       Dictionary |   682.782 ns |  1.2292 ns |  1.0264 ns |  1.00 | 0.0219 |      - |   2,080 B |
//|   AddAndDeleteSingle |    30 |           ArrayBackedPropertyBag |   537.276 ns |  0.6337 ns |  0.4947 ns |  0.79 | 0.0048 |      - |     536 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//|   AddAndDeleteSingle |    50 |                       Dictionary | 1,267.437 ns |  7.6331 ns |  6.7666 ns |  1.00 | 0.0477 |      - |   4,624 B |
//|   AddAndDeleteSingle |    50 |           ArrayBackedPropertyBag | 1,285.096 ns |  3.6396 ns |  3.4045 ns |  1.01 | 0.0095 |      - |   1,048 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//| AddAndDeleteMultiple |    10 |                       Dictionary |   324.364 ns |  1.4163 ns |  1.2555 ns |  1.00 | 0.0105 |      - |     992 B |
//| AddAndDeleteMultiple |    10 |           ArrayBackedPropertyBag |   179.908 ns |  0.4543 ns |  0.3794 ns |  0.55 | 0.0029 |      - |     280 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//| AddAndDeleteMultiple |    30 |                       Dictionary |   767.497 ns |  2.3824 ns |  2.1120 ns |  1.00 | 0.0219 |      - |   2,080 B |
//| AddAndDeleteMultiple |    30 |           ArrayBackedPropertyBag |   746.435 ns |  2.1788 ns |  2.0381 ns |  0.97 | 0.0048 |      - |     536 B |
//|                      |       |                                  |              |            |            |       |        |        |           |
//| AddAndDeleteMultiple |    50 |                       Dictionary | 1,403.626 ns |  6.2522 ns |  5.5424 ns |  1.00 | 0.0477 |      - |   4,624 B |
//| AddAndDeleteMultiple |    50 |           ArrayBackedPropertyBag | 1,803.574 ns |  6.2322 ns |  5.2042 ns |  1.28 | 0.0076 |      - |   1,048 B |

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class FastPropertyBagBenchmark
    {
        private ulong[] _typeHandles;
        private object[] _values;
        private Type[] _types;

        [GlobalSetup]
        public void Setup()
        {
            _types = typeof(object).Assembly.ExportedTypes.Take(200).ToArray();
            _typeHandles = _types.Select(t => (ulong)t.TypeHandle.Value).ToArray();
            _values = _types.Select((_, i) => (object)new[] { i }).ToArray();
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Add")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public Dictionary<ulong, object> Add_Dictionary(int count)
        {
            var dictionary = new Dictionary<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                dictionary[_typeHandles[i]] = _values[i];
            }
            return dictionary;
        }

        [Benchmark]
        [BenchmarkCategory("Add")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void Add_ArrayBackedPropertyBag(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }
            propertyBag.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory("Add")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void Add_ArrayBackedPropertyBag_NoDispose(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("AddAndSearch")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndSearch_Dictionary(int count)
        {
            var dictionary = new Dictionary<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                dictionary[_typeHandles[i]] = _values[i];
            }

            for (int i = 0; i < count; i += 1)
            {
                dictionary.TryGetValue(_typeHandles[i * 2], out _);
            }
        }

        [Benchmark]
        [BenchmarkCategory("AddAndSearch")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndSearch_ArrayBackedPropertyBag(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }

            for (int i = 0; i < count; i++)
            {
                propertyBag.TryGetValue(_typeHandles[i * 2], out _);
            }

            propertyBag.Dispose();
        }

        [Benchmark]
        [BenchmarkCategory("AddAndSearch")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndSearch_ArrayBackedPropertyBag_NoDispose(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }

            for (int i = 0; i < count; i++)
            {
                propertyBag.TryGetValue(_typeHandles[i * 2], out _);
            }
        }

        [Benchmark]
        [BenchmarkCategory("AddAndSearch")]
        [Arguments(2)]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndSearch_Array(int count)
        {
            var array =  ArrayPool<(ulong Key, object Value)>.Shared.Rent(count);
            for (int i = 0; i < count; i++)
            {
                var index = 0;
                var key = _typeHandles[i];
                while (index < i)
                {
                    if (array[index].Key == key)
                    {
                        array[index] = (key, _values[i]);
                        break;
                    }

                    index++;
                }

                if (i == index)
                {
                    array[index] = (key, _values[i]);
                }
            }

            for (int i = 0; i < count; i++)
            {
                var key = _typeHandles[i * 2];
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].Key == key)
                    {
                        break;
                    }
                }
            }

            ArrayPool<(ulong Key, object Value)>.Shared.Return(array);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("AddAndGet")]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndGet_Dictionary(int count)
        {
            var dictionary = new Dictionary<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                dictionary[_typeHandles[i]] = _values[i];
                dictionary.TryGetValue(_typeHandles[i], out _);
            }
        }

        [Benchmark]
        [BenchmarkCategory("AddAndGet")]
        [Arguments(30)]
        [Arguments(100)]
        public void AddAndGet_ArrayBackedPropertyBag(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
                propertyBag.TryGetValue(_typeHandles[i], out _);
            }
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("AddAndDeleteSingle")]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(50)]
        public Dictionary<ulong, object> AddAndDeleteSingle_Dictionary(int count)
        {
            var dictionary = new Dictionary<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                dictionary[_typeHandles[i]] = _values[i];
            }

            dictionary.Remove((ulong)(count / 2));
            return dictionary;
        }

        [Benchmark]
        [BenchmarkCategory("AddAndDeleteSingle")]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(50)]
        public void AddAndDeleteSingle_ArrayBackedPropertyBag(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }
            propertyBag.TryRemove((ulong)(count / 2));
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("AddAndDeleteMultiple")]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(50)]
        public Dictionary<ulong, object> AddAndDeleteMultiple_Dictionary(int count)
        {
            var dictionary = new Dictionary<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                dictionary[_typeHandles[i]] = _values[i];
            }
            for (int i = 0; i < count; i += 3)
            {
                dictionary.Remove(_typeHandles[i]);
            }

            return dictionary;
        }

        [Benchmark]
        [BenchmarkCategory("AddAndDeleteMultiple")]
        [Arguments(10)]
        [Arguments(30)]
        [Arguments(50)]
        public void AddAndDeleteMultiple_ArrayBackedPropertyBag(int count)
        {
            var propertyBag = new ArrayBackedPropertyBag<ulong, object>();
            for (int i = 0; i < count; i++)
            {
                propertyBag.Set(_typeHandles[i], _values[i]);
            }
            for (int i = 0; i < count; i += 3)
            {
                propertyBag.TryRemove(_typeHandles[i]);
            }
        }
    }
}
