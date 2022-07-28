#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.System;
using FTOptix.Recipe;
#endregion

public class LedBlink : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        //Definiamo una task periodica a 100ms
        myPeriodicTask = new PeriodicTask(LampeggioLed, 100, LogicObject);
        myPeriodicTask.Start();
       

    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        myPeriodicTask.Dispose(); 
    }

    private PeriodicTask myPeriodicTask;

    private void LampeggioLed()
    {
        var myLed = Owner.Get<Led>("LED1");
        myLed.Active = !myLed.Active;
    }


}
