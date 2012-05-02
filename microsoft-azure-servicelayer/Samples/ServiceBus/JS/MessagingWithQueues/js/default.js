//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                document.getElementById("runSendAndReceiveButton").addEventListener('click', runSendAndReceiveButtonClickHandler);
            } else {
            }
            args.setPromise(WinJS.UI.processAll());
            WinJS.Promise.onerror = errorHandler;
        }
    };
    app.oncheckpoint = function (args) {
    };
    app.start();
})();
var serviceBusClient = new Microsoft.WindowsAzure.ServiceLayer.ServiceBus.ServiceBusClient("<specify the serviceNamespace>", "<issuerName>", "<issuerPassword>");


function runSendAndReceiveButtonClickHandler() {
    //createQueue
    //in case of success/failure(queue already exists), send the message
    asyncCreateQueue().then(asyncSendAndReceiveMessage, asyncSendAndReceiveMessage);
}
//function to send message async
function asyncSendAndReceiveMessage() {
    
    //Send Message
    asyncSendMessage().then(
        function () {
            //Receive the message
            asyncReceiveAndDeleteMessage().then(
                function () {
                    //delete the queue
                    asyncDeleteQueue();
                });
        });
}
//function to create queue async
function asyncCreateQueue() {
    return new WinJS.Promise(function (complete, onerror) {
        var queueName = document.getElementById('queuenameTextBox').value;
        if (queueName == "")
            return;
        //create queue
        serviceBusClient.createQueueAsync(queueName).then(
            function (result) {
                log("Queue " + result.name + " was created successfully.");
                complete(result);
            },
            function (error) {
                
                log("Queue couldn't be created with an error. Error details: " + error.description);
                
                onerror(error);
            });
    });
}
//function to send message async
function asyncSendMessage() {
    return new WinJS.Promise(function (complete, onerror) {
        var messageTxt = document.getElementById('messageTextBox').value;
        var orderIDTxt = document.getElementById('orderIDTextBox').value;
        var queueName = document.getElementById('queuenameTextBox').value;
        var message = new Microsoft.WindowsAzure.ServiceLayer.ServiceBus.BrokeredMessageSettings.createFromText(messageTxt);
        //set a custom property of the message
        message.properties["orderid"] = orderIDTxt;
        //send the message
        serviceBusClient.sendMessageAsync(queueName, message).then(
            function (result) {
                log("Message was sent successfully.");
                complete(result);
            }
            , function (error) {
                log("There was an error sending the message. Error details: " + error.description);
                onerror(error);
            });
    });
}
//function to receive the message async
function asyncReceiveAndDeleteMessage() {
    return new WinJS.Promise(function (complete, onerror) {
        var messageReceiver = serviceBusClient.createMessageReceiver(document.getElementById('queuenameTextBox').value);
        messageReceiver.getMessageAsync(1000).then(
            function (result) {
                //get the custom property of the message
                log("Message Received. Custom property value: " + result.properties["orderid"]);

                //read the message content
                result.readContentAsStringAsync().then(
                    function (result) {
                        log("Message Body: " + result);
                    });
                complete(result);
            },
            function (error) {
                log("There was an error receiving the message. Error details: " + error.description);
                onerror(error);
            });
    });
}
//function to delete queue async
function asyncDeleteQueue() {
    return new WinJS.Promise(function (complete, onerror) {
        var queueName = document.getElementById('queuenameTextBox').value;
        //delete the queue
        serviceBusClient.deleteQueueAsync(queueName).then(
            function (result) {
                log("Deleted queue " + queueName + " successfully.");
                complete(result);
            },
            function (error) {
                log("There was an error deleting the queue. Error details: " + error.description);
                onerror(error);
            });
    });
}
//function to log messages on screen and in Javascript console output while debugging from Visual Studio
function log(logtext, errormessage) {
    var logTextelement = document.getElementById('logTextArea').value;
    console.log(logtext);
    logTextArea.value = logTextArea.value + logtext + "\n";
}
//error handler for winjs.promise
function errorHandler(event) {
    log(event.detail.exception);
}
