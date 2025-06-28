namespace Heartbeat;

using System.ComponentModel;

/// <summary>
/// The primary configuration file used for <see cref="Plugin">Heartbeat</see>.
/// </summary>
public class Config
{
    /// <summary>
    /// Gets or sets a value indicating whether Heartbeat should be loaded.
    /// </summary>
    [Description("A boolean indicator that determines whether eartbeat should be loaded.")]
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether Heartbeat should output debug logs.
    /// </summary>
    [Description("A boolean indicator that determines whether Heartbeat should output debug logs.")]
    public bool Debug { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating where the HTTP heartbeat signal should go.
    /// </summary>
    [Description("Sets the target url to send a request to")]
    public string Target { get; set; } = "http://localhost";

    /// <summary>
    /// Gets or sets a value indicating what type of HTTP request to make.
    /// </summary>
    [Description("Sets the HTTP method to send to the target, valid options are: GET, POST")]
    public string Method { get; set; } = "GET";

    /// <summary>
    /// Gets or sets a value indicating how long the intervals of heartbeat signals should be.
    /// </summary>
    [Description("Sets the timeout (in seconds) to send a message to the target")]
    public int Timeout { get; set; } = 30;
}
