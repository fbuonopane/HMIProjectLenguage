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

public class MyDesignSampleScript : BaseNetLogic
{
    [ExportMethod]
    public void Crea100Variabili()
    {
        var myfolder = Project.Current.Get("Model");

        for (int i =0; i < 100; i++)
        {
            var myVar = InformationModel.MakeVariable("Variable"+i, OpcUa.DataTypes.Int32);
            myfolder.Add(myVar);
        }    
    }
    [ExportMethod]
    public void CreaLabel()
    {
        var myPage = Project.Current.Get("UI/MainWindow");
        var myLabel = InformationModel.Make<Label>("Label1");
        myLabel.Text = "Etichetta creata da NetLogic";
        myLabel.TextColor = Colors.Red;
        myPage.Add(myLabel);
    }
    [ExportMethod]
    public void ModificaLabel()
    {
        var myLabel = Project.Current.Get<Label>("UI/MainWindow/Label1");
        myLabel.Text = "Ciao Asem";
        myLabel.TextColor = Colors.Blue;
    }
    [ExportMethod]
    public void ModificaValNativa()
    {
        var myVar = Project.Current.GetVariable("Model/Variable1");
        myVar.Value = 100;
    }
    [ExportMethod]
    public void AggiungiButton()
    {
        var myPage = Project.Current.Get("UI/MainWindow");

        for (int i = 0; i < 10; i++)
        {
            var myButton = InformationModel.MakeObject<Button>("Button" + i);
            myPage.Add(myButton);
            myButton.Text = "Button Test";
        }
    }
    [ExportMethod]
    public void CancellaVariabiliDispari()
    {
        var myFolder = Project.Current.Get("Model");
        foreach (IUAVariable item in myFolder.Children)
        {
            string varName = item.BrowseName;
            int varNum = Convert.ToInt32(varName.Substring(varName.Length - 1));
            if(varNum % 2 != 0)
            {
               item.Delete();
            }

        }
    }
    }
