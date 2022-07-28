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

public class RuntimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void CreaLabel()
    {
        var myTesto = LogicObject.GetVariable("Testo").Value;
        var myPage = Owner;
        var myLabel = InformationModel.Make<Label>("Label1");
        myLabel.Text = myTesto;
        myLabel.TextColor = Colors.Red;
        myPage.Add(myLabel);
    }
}
