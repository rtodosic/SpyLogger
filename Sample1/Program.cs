
using Sample1;
using Sample1.Services;

var startup = new Startup();

var myService = startup.ActivateInstance<IMyService>(typeof(MyService));
myService.Run();


