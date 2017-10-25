#addin "Cake.IIS"
#addin "Cake.Services"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    //Executed BEFORE the first task.
    Information("Tools dir: {0}.", EnvironmentVariable("CAKE_PATHS_TOOLS"));
});





///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Windows-Service")
    .Description("Stop / Start windows service")
    .Does(() =>
    {
		ServiceController controller = GetService("MpsSvc");

        if (controller != null)
        {
            StopService("MpsSvc");
        }
        else
        {
            StartService("MpsSvc");
        }
    });





//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Windows-Service");





///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);
