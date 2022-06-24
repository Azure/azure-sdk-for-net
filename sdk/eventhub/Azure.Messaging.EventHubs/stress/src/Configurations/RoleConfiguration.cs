// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The static names for each role, and the set of roles to run for each test scenario.
/// </summary>
///
internal class RoleConfiguration
{
    /// <summary>
    ///   A dictionary that maps each test scenario to the set of roles to run for that scenario.
    /// </summary>
    ///
    public Dictionary<string, List<string>> TestScenarioRoles;

    // Available roles

    /// <summary>
    ///   The name of the publisher role.
    /// </summary>
    ///
    public static string Publisher = "publisher";

    /// <summary>
    ///   The name of the buffered publisher role.
    /// </summary>
    ///
    public static string BufferedPublisher = "bufferedpublisher";

    /// <summary>
    ///   The name of the burst buffered publisher role.
    /// </summary>
    ///
    public static string BurstBufferedPublisher = "burstbufferedpublisher";

    /// <summary>
    ///   The name of the processor role.
    /// </summary>
    ///
    public static string Processor = "processor";

    /// <summary>
    ///   The name of the consumer role.
    /// </summary>
    ///
    public static string Consumer = "consumer";

    // Available test scenarios

    /// <summary>
    ///   The name of the event producer test scenario.
    /// </summary>
    ///
    public static string EventProducerTest = "EventProducerTest";

    /// <summary>
    ///   The short name of the event producer test scenario.
    /// </summary>
    ///
    public static string EventProducerTestShort = "EventProd";

    /// <summary>
    ///   The name of the buffered producer test scenario.
    /// </summary>
    ///
    public static string BufferedProducerTest = "BufferedProducerTest";

    /// <summary>
    ///   The short name of the buffered producer test scenario.
    /// </summary>
    ///
    public static string BufferedProducerTestShort = "BuffProd";

    /// <summary>
    ///   The name of the basic processor test scenario.
    /// </summary>
    ///
    public static string EventProcessorTest = "EventProcessorTest";

    /// <summary>
    ///   The short name of the basic processor test scenario.
    /// </summary>
    ///
    public static string EventProcessorTestShort = "Processor";

    /// <summary>
    ///   The name of the basic read test scenario.
    /// </summary>
    ///
    public static string BasicReadTest = "BasicReadTest";

    /// <summary>
    ///   The name of the burst buffered producer test scenario.
    /// </summary>
    ///
    public static string BurstBufferedProducerTest = "BurstBufferedProducerTest";

    /// <summary>
    ///   The short name of the burst buffered producer test scenario.
    /// </summary>
    ///
    public static string BurstBufferedProducerTestShort = "BurstBuffProd";

    // Roles needed for each scenario

    /// <summary>
    ///   The set of roles to deploy for the event producer test scenario.
    /// </summary>
    ///
    /// <remarks>
    ///   Each element in the array corresponds to a role to run for the event producer test.
    ///   In this case, the producer test will deploy two distinct <see cref="Publisher"/> roles.
    /// </remarks>
    ///
    private static string[] _eventProducerTestRoles = {Publisher, Publisher};

    /// <summary>
    ///   The set of roles to deploy for the buffered producer test scenario.
    /// </summary>
    ///
    /// <remarks>
    ///   Each element in the array corresponds to a role to run for the buffered producer test.
    ///   In this case, the producer test will deploy two distinct <see cref="BufferedPublisher"/> roles.
    /// </remarks>
    ///
    private static string[] _bufferedProducerTestRoles = {BufferedPublisher, BufferedPublisher};

    /// <summary>
    ///   The set of roles to deploy for the event processor test scenario.
    /// </summary>
    ///
    /// <remarks>
    ///   Each element in the array corresponds to a role to run for the processor test.
    ///   In this case, the producer test will deploy two distinct roles, one <see cref="Publisher"/>
    ///   and one <see cref="Processor"/>.
    /// </remarks>
    ///
    private static string[] _processorTestRoles = {Publisher, Processor};

    /// <summary>
    ///   The set of roles to deploy for the burst buffered producer test scenario.
    /// </summary>
    ///
    /// <remarks>
    ///   Each element in the array corresponds to a role to run for the burst buffered producer test.
    ///   In this case, the producer test will deploy two distinct burst <see cref="BufferedPublisher"/> roles.
    /// </remarks>
    ///
    private static string[] _burstBufferedProducerRoles = {BurstBufferedPublisher, BurstBufferedPublisher};

    /// <summary>
    ///   Initializes a new instance of the <see cref="RoleConfiguration" \> class.
    /// </summary>
    ///
    public RoleConfiguration()
    {
        TestScenarioRoles = new Dictionary<string, List<string>>();

        TestScenarioRoles[EventProducerTest] = new List<string>(_eventProducerTestRoles);
        TestScenarioRoles[BufferedProducerTest] = new List<string>(_bufferedProducerTestRoles);
        TestScenarioRoles[EventProcessorTest] = new List<string>(_processorTestRoles);
        TestScenarioRoles[BurstBufferedProducerTest] = new List<string>(_burstBufferedProducerRoles);
    }
}