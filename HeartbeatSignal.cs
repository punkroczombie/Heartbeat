// -----------------------------------------------------------------------
// <copyright file="HeartbeatSignal.cs" company="Zombie">
// Copyright (c) Zombie. All rights reserved.
// Licensed under the CC BY-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Heartbeat;

using System;
using System.Threading;
using System.Threading.Tasks;

using PlaceholderAPI.API;
using UnityEngine;
using UnityEngine.Networking;
using Logger = LabApi.Features.Console.Logger;

/// <summary>
/// Class that contains the logic for sending out a heartbeat signal.
/// </summary>
public sealed class HeartbeatSignal
{
    private static CancellationTokenSource Cts => new();

    /// <summary>
    /// Method that starts the Thread that continuously sends out a heartbeat signal.
    /// </summary>
    public void Start()
    {
        Task.Run(() => RunAsync(Cts.Token));
    }

    /// <summary>
    /// Method that stops the Thread that continuously sends out a heartbeat signal.
    /// </summary>
    public void Stop()
    {
        Cts?.Cancel();
    }

    private static async Task RunAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            LabAPILogger.Debug("Sending Heartbeat Signal");

            string target = Plugin.Instance!.Config!.Target;

            try
            {
                switch (Plugin.Instance!.Config!.Method)
                {
                    case "GET":
                        UnityWebRequest get = new(target, "GET");
                        await get.SendWebRequest();
                        break;
                    case "POST":
                        UnityWebRequest post = new(target, "POST");
                        await post.SendWebRequest();
                        break;
                    default:
                        LabAPILogger.Error("Invalid Method Selected, Valid options are: GET, POST");
                        break;
                }

                await Task.Delay(TimeSpan.FromSeconds(Plugin.Instance!.Config!.Timeout), token);
            }
            catch (TaskCanceledException)
            {
                LabAPILogger.Error("Something went wrong while cancelling the Heartbeat Task");
            }
        }
    }
}