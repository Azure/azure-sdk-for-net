// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class PagedCollectionUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfSequenceIsNull_ThenForEachAsyncThrowsArgumentNullException()
        {
            IPagedEnumerable<string> seq = null;

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => seq.ForEachAsync(_ => Task.Delay(0)));

            Assert.Equal("source", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfBodyIsNull_ThenForEachAsyncThrowsArgumentNullException()
        {
            IPagedEnumerable<string> seq = new PagedAlphabet();

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => seq.ForEachAsync((Func<string, Task>)null));

            Assert.Equal("body", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ForEachAsyncVisitsEveryMemberOfTheSequence()
        {
            var visited = new List<string>();

            var seq = new PagedAlphabet();

            await seq.ForEachAsync(s => { visited.Add(s); return Task.Delay(0); });

            Assert.Equal(26, visited.Count);
            Assert.Equal("A", visited.First());
            Assert.Equal("Z", visited.Last());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfSequenceIsNull_ThenForEachAsyncThrowsArgumentNullException_SyncDelegateOverload()
        {
            IPagedEnumerable<string> seq = null;

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => seq.ForEachAsync(_ => { }));

            Assert.Equal("source", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfBodyIsNull_ThenForEachAsyncThrowsArgumentNullException_SyncDelegateOverload()
        {
            IPagedEnumerable<string> seq = new PagedAlphabet();

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => seq.ForEachAsync((Action<string>)null));

            Assert.Equal("body", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ForEachAsyncVisitsEveryMemberOfTheSequence_SyncDelegateOverload()
        {
            var visited = new List<string>();

            var seq = new PagedAlphabet();

            await seq.ForEachAsync(s => visited.Add(s));

            Assert.Equal(26, visited.Count);
            Assert.Equal("A", visited.First());
            Assert.Equal("Z", visited.Last());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfSequenceIsNull_ThenToListAsyncThrowsArgumentNullException()
        {
            IPagedEnumerable<string> seq = null;

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => seq.ToListAsync());

            Assert.Equal("source", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ToListAsyncCollectsAllElementsOfSequence()
        {
            var seq = new PagedAlphabet(4, 10);

            var list = await seq.ToListAsync();

            Assert.Equal(10, list.Count);
            Assert.Equal("A", list.First());
            Assert.Equal("J", list.Last());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ToListAsyncCorrectlyHandlesEmptyCollections()
        {
            var seq = new PagedAlphabet(4, 0);

            var list = await seq.ToListAsync();

            Assert.Empty(list);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ToListAsyncSupportsCancellation()
        {
            PagedAlphabet seq = new PagedAlphabet(4, 10);

            //Call with an already cancelled cancellation token
            using CancellationTokenSource source = new CancellationTokenSource();
            source.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(async () => await seq.ToListAsync(source.Token));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ForEachAsyncActionSupportsCancellation()
        {
            PagedAlphabet seq = new PagedAlphabet(4, 10);

            //Call with an already cancelled cancellation token
            using CancellationTokenSource source = new CancellationTokenSource();
            source.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(async () => await seq.ForEachAsync(item => { }, source.Token));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ForEachAsyncFuncSupportsCancellation()
        {
            PagedAlphabet seq = new PagedAlphabet(4, 10);

            //Call with an already cancelled cancellation token
            using CancellationTokenSource source = new CancellationTokenSource();
            source.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(async () => await seq.ForEachAsync(item => Task.Delay(0), source.Token));
        }

        private class PagedAlphabet : PagedEnumerable<string>
        {
            public PagedAlphabet()
                : this(3)
            {
            }

            public PagedAlphabet(int pageSize)
                : this(pageSize, 26)
            {
            }

            public PagedAlphabet(int pageSize, int stopAfter)
                : base(() => new PagedAlphabetEnumerator(pageSize, stopAfter))
            {
            }

            private class PagedAlphabetEnumerator : PagedEnumeratorBase<string>
            {
                private readonly int pageSize;
                private readonly int last;

                public PagedAlphabetEnumerator(int pageSize, int stopAfter)
                {
                    this.pageSize = pageSize;
                    this.last = (int)'A' + stopAfter - 1;
                }

                public override string Current
                {
                    get { return (string)(_currentBatch[_currentIndex]); }
                }

                protected override Task GetNextBatchFromServerAsync(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
                {
                    IEnumerable<int> chars;
                    if (!skipHandler.AtLeastOneCallMade)
                    {
                        chars = Enumerable.Range((int)'A', this.pageSize);
                    }
                    else
                    {
                        chars = Enumerable.Range((int)(skipHandler.SkipToken[0]) + 1, this.pageSize);
                    }

                    var letters = chars.TakeWhile(c => c <= this.last)
                                       .Select(c => ((char)c).ToString())
                                       .ToArray();

                    _currentBatch = letters;

                    skipHandler.SkipToken = GetSkipToken();

                    return Task.Delay(0);
                }

                private string GetSkipToken()
                {
                    var letters = (string[])_currentBatch;

                    if (letters.Any())
                    {
                        var lastLetter = letters.Last()[0];

                        if (lastLetter < this.last)
                        {
                            return lastLetter.ToString();
                        }
                    }

                    return null;
                }
            }
        }
    }
}
