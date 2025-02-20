// TARGET:"C:\Program Files\Notepad++\notepad++.exe -nosession" 
// START_IN:
using LoginPI.Engine.ScriptBase;

public class NotepadPlusPlus : ScriptBase
{
    void Execute() 
    {
        START();
        Wait(2); 
        
        // LeftClick on Pane "" at (241,14)

// LeftClick on Pane "" at (298,3)
var nWindow0 = FindWindowByClassAndName(className: "Window:Notepad++", name: "new 1 - Notepad++");
var Pane0 = nWindow0.FindControlWithXPathName(xPath : "Pane:Scintilla[][Position: 1]");
Pane0.Click(forceFocus:true);
Wait(2);

// This is a test{RETURN}{RETURN}This app rocks{LSHIFT+LALT+S}
nWindow0.Type("This is a test{RETURN}{RETURN}This app rocks and our package install clearly worked{LSHIFT+LALT+S}", forceFocus:true);
Wait(2);
TakeScreenshot("Confirm_Typing");

// LeftClick on Edit "File name:" at (154,8)
var EditFilename0 = nWindow0.FindControlWithXPathName(xPath : "Window:#32770[Save As][Position: 1]/Pane:DUIViewWndClassName[][Position: 1]/ComboBox:AppControlHost[File name:][AutomationId: FileNameControlHost][Position: 5]/Edit:Edit[File name:][AutomationId: 1001][Position: 1]");
EditFilename0.Click(forceFocus:false);
Wait(2);

// {LCONTROL+a}%TEMP%\\savefiletest
nWindow0.Type("{LCONTROL+a}%TEMP%\\savefiletest", forceFocus:false);
Wait(2);

// LeftClick on Button "Save" at (37,13)
var ButtonSave0 = nWindow0.FindControlWithXPathName(xPath : "Window:#32770[Save As][Position: 1]/Button:Button[Save][AutomationId: 1][Position: 4]");
ButtonSave0.Click(forceFocus:false);

StartTimer("Saving_File");

var Saved = FindWindow(title: "*testnotepadplusplus*",timeout:5,continueOnError:true);
if (Saved != null)
{
            StopTimer("Saving_File");
            Log("File is saved and file did not exist");
}

else
{
// LeftClick on Button "Yes" at (34,10)
var ConfirmSave = FindWindow(title:"Confirm Save As");
ConfirmSave.FindControl(title:"&Yes").Click();

FindWindow(title: "*savefiletest*",timeout:10);
StopTimer("Saving_File");
Log("File is overwritten and file existed");

}

        
        STOP();
    }
}
