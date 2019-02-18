using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//ReferenceSource:
//https://stackoverflow.com/questions/15191129/selectively-disabling-uac-for-specific-programs-on-windows-programatically

namespace BypassUACExample
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            TaskService ts = new TaskService();
            TaskDefinition td = ts.NewTask();
            td.Principal.RunLevel = TaskRunLevel.Highest;
            //td.Triggers.AddNew(TaskTriggerType.Logon);          
            td.Triggers.AddNew(TaskTriggerType.Registration);
            // you can have it dynamic
            // even of user choice giving an interface in win-form or wpf application
            string program_path = @"C:\x86\Debug\CEFSharpWin.exe";
            td.Actions.Add(new ExecAction(program_path, null));
            ts.RootFolder.RegisterTaskDefinition("anyNamefortask", td);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMain());
        }
    }
}
