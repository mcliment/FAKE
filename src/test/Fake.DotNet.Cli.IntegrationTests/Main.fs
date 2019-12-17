module Main.Tests
open Expecto
open Fake.ExpectoSupport
open System

[<EntryPoint>]
let main argv =
    let writeResults = TestResults.writeNUnitSummary ("Fake_DotNet_Cli_IntegrationTests.TestResults.xml", "Fake.DotNet.Cli.IntegrationTests")
    let config =
        defaultConfig.appendSummaryHandler writeResults
        |> ExpectoHelpers.addTimeout (TimeSpan.FromMinutes(20.))
        |> ExpectoHelpers.setFakePrinter
    Expecto.Tests.runTestsInAssembly { config with parallel = false } argv
