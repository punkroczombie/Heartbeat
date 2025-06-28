## Heartbeat

![Downloads](https://img.shields.io/github/downloads/punkroczombie/Heartbeat/total.svg)

> Supports [PlaceholderAPI](https://github.com/PlaceholderAPI-SL/PlaceholderAPI)

### How do I download this?
- Go here and download the latest release, [https://github.com/punkroczombie/Heartbeat/releases](https://github.com/punkroczombie/Heartbeat/releases)

### Default Config
```yml
Heartbeat:
  is_enabled: true
  # Indicates whether debug messages should be shown.
  debug: false
  # Sets the target url to send a request to
  target: 'http://localhost'
  # Sets the HTTP method to send to the target, valid options are: GET, POST
  method: 'GET'
  # Sets the timeout (in seconds) to send a message to the target
  timeout: 30
```