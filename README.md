# Neustart
Neustart is a program designed in C# to automatically restart frozen and exited applications.
It was created for SuperiorServers to replace the ancient ServerDoc software that required yearly updates and insisted on donations. But hey, open source is the best!
### Interface
![Neustart](https://f.stonedpengu.in/index.php/s/ngOxBsotddkgEL2/download)  
From the main interface you'll be presented with simple controls to start, stop, show, hide and edit an application's preferences.  
**Note:** Neustart will remember your preference when you start or stop an application. So, stopping a program will mean that next time you open Neustart, it won't automatically start. That also means that a program that is started **will** automatically start next time Neustart is opened.

### Adding applications
![New App](https://f.stonedpengu.in/index.php/s/Ue5VxIvNj4rzDi7/download)  
Simple and easy to work, adding an application to be restarted is a breeze. Give it an identifier and tell it where and what to do! Optionally choose CPU cores for the application to run on to split your workload.

### Details
- Dynamically add, edit, and remove applications without ever needing to restart Neustart
- Automatically stop and restart an application if its process hasn't responded in about 5 seconds
- Visual indicator if a process is lagging. The background behind the process name becomes more red as it gets closer to the threshold for being restarted
- Configuration file is a nicely formatted JSON file that is human readable

### What's to come?
Depending on adoption, Neustart's development will continue as it is seen fit. One of the first features that come to mind is a simple web interface or API to allow users or scripts to dynamically add, edit, remove, or control application settings. Apart from that, bug reports and feature requests are welcome!

# Building
#### Prerequisites
- NewtonSoft JSON Library: [NuGet](https://www.nuget.org/packages/Newtonsoft.Json/)  

Apart from aquiring Json.NET, compiling Neustart should be very straightforward. Project files are already included and should be as simple as Project->Build.
