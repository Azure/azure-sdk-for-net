// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System.Threading;

//namespace ClientModel.Tests.Mocks;

//public class MockCancellationToken
//{
//    private readonly string _id;
//    private readonly CancellationTokenSource _cts;

//    public string CancelledId { get; private set; }

//    public MockCancellationToken(string id)
//    {
//        _id = id;
//        _cts = new CancellationTokenSource();

//        CancelledId = string.Empty;
//    }

//    public CancellationToken GetToken()
//    {
//        CancellationToken token = _cts.Token;
//        token.Register(id => GetId((string)id), _id);
//        return token;
//    }

//    public void Cancel()
//    {
//        _cts.Cancel();
//    }

//    public void GetId(string id)
//    {
//        CancelledId = id;
//    }
//}
