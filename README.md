# Neustart
Neustart is a program designed in C# to automatically restart frozen and exited applications.
It was created for SuperiorServers to replace the ancient ServerDoc software that required yearly updates and insisted on donations. But hey, open source is the best!
### Interface
![Neustart](https://yasbit.ch/9ACXQ.png)  
From the main interface you'll be presented with simple controls to start, stop, show, hide and edit an application's preferences.  
**Note:** Neustart will remember your preference when you start or stop an application. So, stopping a program will mean that next time you open Neustart, it won't automatically start. That also means that a program that is started **will** automatically start next time Neustart is opened.

### Adding applications
![New App](https://yasbit.ch/20564.png)  
Simple and easy to work, adding an application to be restarted is a breeze. Give it an identifier and tell it where and what to do! Optionally choose CPU cores for the application to run on to split your workload.

### Details
- Dynamically add, edit, and remove applications without ever needing to restart Neustart
- Automatically stop and restart an application if its process hasn't responded in a significant amount of time
- Configuration file is a nicely formatted JSON file that is human readable
- Program-specific crash monitoring supported (i.e. querying srcds instances if Neustart can determine the IP and port being bound)
- Minimize to task tray and continue monitoring in the background
- Automatically checks for new releases on GitHub and gives a notification to update

### What's to come?
Our next goal will be to implement an optional web-based control panel to use remotely.

# Building
#### Prerequisites
- NewtonSoft JSON Library: [NuGet](https://www.nuget.org/packages/Newtonsoft.Json/)
- MetroModernUI: [NuGet](https://www.nuget.org/packages/MetroModernUI/)

Compiling Neustart should be very straightforward. Project files are already included and should be as simple as Project->Build.
