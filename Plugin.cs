// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Zombie">
// Copyright (c) Zombie. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Heartbeat;

using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins.Enums;
using LabPlugin = LabApi.Loader.Features.Plugins.Plugin<Config>;

/// <summary>
/// The base plugin config for Heartbeat.
/// </summary>
public sealed class Plugin : LabPlugin
{
    /// <summary>
    /// Gets gives a static instance of the plugin class.
    /// </summary>
    public static Plugin? Instance { get; private set; }

    /// <summary>
    /// Gets gives a static instance of the heartbeat class.
    /// </summary>
    public static HeartbeatSignal? Signal { get; private set; }

    /// <inheritdoc />
    public override string Name => "Heartbeat";

    /// <inheritdoc />
    public override string Description => "A plugin for admins to monitor the status of their servers.";

    /// <inheritdoc />
    public override string Author => "Zombie";

    /// <inheritdoc />
    public override Version Version => new Version(0, 0, 2);

    /// <inheritdoc />
    public override Version RequiredApiVersion => new Version(LabApiProperties.CompiledVersion);

    /// <inheritdoc />
    public override LoadPriority Priority => LoadPriority.Medium;

    /// <inheritdoc />
    public override void Enable()
    {
        Instance = this;
        CosturaUtility.Initialize();
        this.LoadConfigs();
        Signal = new HeartbeatSignal();
        Signal.Start();
    }

    /// <inheritdoc />
    public override void Disable()
    {
        Signal!.Stop();
        Instance = null;
        Signal = null;
    }
}
