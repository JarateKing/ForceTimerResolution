# ForceTimerResolution

Lightweight system tray application that sets the timer resolution in windows to its minimum (generally ~0.5ms, from the default ~15ms). Running it automatically sets the timer, doubleclick its tray icon to close it and return the timer to default.

Because of the way windows handles timer resolution requests, this program must be running to have the timer resolution set. Any other application that tries to set the timer resolution will be ignored (as windows sets the timer resolution to whatever the lowest request is, which would be this).
