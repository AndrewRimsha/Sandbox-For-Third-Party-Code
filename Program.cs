using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace _700100_ACW1
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //args = new string[] { "D:\\hello.exe", "-perm", "FileIOPermission.Read;Path:D:\\", "SecurityPermission.Execution", "UIPermission.Unrestricted" };
            //args = new string[] { "D:\\hello.exe", "-perm", "FileIOPermission.Unrestricted", "UIPermission.Unrestricted", "SecurityPermission.Execution", "DnsPermission.Unrestricted", "-args", "cssbct" };
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SandboxForm());
            }
            else
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                bool argsError = false;
                PermissionSet permission = new PermissionSet(PermissionState.None);
                List<string> argsToDeployList = new List<string>();
                int argsPosition = -1;
                try
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "-args")
                        {
                            argsPosition = i;
                            break;
                        }
                        if (args[i] != "-perm")
                        {
                            string[] argument = args[i].Split('.');
                            if (args[i].Length != 2)
                            {
                                switch (argument[0])
                                {
                                    case "AspNetHostingPermission":
                                        {
                                            PermissionsClass.AddAspNetHostingPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "DnsPermission":
                                        {
                                            PermissionsClass.AddDnsPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "EventLogPermission":
                                        {
                                            PermissionsClass.AddEventLogPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "NetworkInformationPermission":
                                        {
                                            PermissionsClass.AddNetworkInformationPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "PerformanceCounterPermission":
                                        {
                                            PermissionsClass.AddPerformanceCounterPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "SmtpPermission":
                                        {
                                            PermissionsClass.AddSmtpPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "SocketPermission":
                                        {
                                            PermissionsClass.AddSocketPermission(ref permission, argument[1]);
                                            break;
                                        }

                                    case "EnvironmentPermission":
                                        {
                                            PermissionsClass.AddEnvironmentPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "FileDialogPermission":
                                        {
                                            PermissionsClass.AddFileDialogPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "FileIOPermission":
                                        {
                                            FileIOPermission fIOP = new FileIOPermission(PermissionState.None);
                                            bool unrestricedOrNone = false;
                                            if (argument[1] == "Unrestricted")
                                            {
                                                unrestricedOrNone = true;
                                                permission.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
                                                break;
                                            }
                                            if (argument[1] == "None")
                                            {
                                                unrestricedOrNone = true;
                                                permission.AddPermission(new FileIOPermission(PermissionState.None));
                                                break;
                                            }
                                            PermissionsClass.AddFileIOPermission(ref fIOP, argument[1]);
                                            if (!unrestricedOrNone)
                                                permission.SetPermission(fIOP);
                                            break;
                                        }
                                    case "GacIdentityPermission":
                                        {
                                            PermissionsClass.AddGacIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "IsolatedStorageFilePermission":
                                        {
                                            PermissionsClass.AddIsolatedStorageFilePermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "KeyContainerPermission":
                                        {
                                            PermissionsClass.AddKeyContainerPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "MediaPermission":
                                        {
                                            PermissionsClass.AddMediaPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "PrincipalPermission":
                                        {
                                            PermissionsClass.AddPrincipalPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "PublisherIdentityPermission":
                                        {
                                            PermissionsClass.AddPublisherIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "ReflectionPermission":
                                        {
                                            PermissionsClass.AddReflectionPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "RegistryPermission":
                                        {
                                            PermissionsClass.AddRegistryPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "SecurityPermission":
                                        {
                                            PermissionsClass.AddSecurityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "SiteIdentityPermission":
                                        {
                                            PermissionsClass.AddSiteIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "StorePermission":
                                        {
                                            PermissionsClass.AddStorePermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "StrongNameIdentityPermission":
                                        {
                                            PermissionsClass.AddStrongNameIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "TypeDescriptorPermission":
                                        {
                                            PermissionsClass.AddTypeDescriptorPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "UIPermission":
                                        {
                                            PermissionsClass.AddUIPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "UrlIdentityPermission":
                                        {
                                            PermissionsClass.AddUrlIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "WebBrowserPermission":
                                        {
                                            PermissionsClass.AddWebBrowserPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "WebPermission":
                                        {
                                            PermissionsClass.AddWebPermission(ref permission, argument[1]);
                                            break;
                                        }
                                    case "ZoneIdentityPermission":
                                        {
                                            PermissionsClass.AddZoneIdentityPermission(ref permission, argument[1]);
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Input parameter is incorrect: Use dot (.) to input flag");
                                argsError = true;
                                break;
                            }
                        }
                    }
                    if (argsPosition != -1)
                    {
                        for (int i = ++argsPosition; i < args.Length; i++)
                        {
                            argsToDeployList.Add(args[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    argsError = true;
                    Console.WriteLine();
                    Console.WriteLine(string.Format("Incorrect parameter or args: {0}",ex.Message));
                }
                if (!argsError)
                {
                    var setUp = new AppDomainSetup();
                    setUp.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    AppDomain customDomain = AppDomain.CreateDomain("Sandbox", null, setUp, permission);
                    try
                    {
                        if (File.Exists(args[0]))
                        {
                            Console.WriteLine();
                            customDomain.ExecuteAssembly(args[0], argsToDeployList.ToArray());
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(string.Format("{0} Does Not Exist", args[0]));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine();
                            if (ex.InnerException.Message == "Execution permission cannot be acquired.")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Add: -perm SecurityPermission.Execution");
                                Console.WriteLine();
                            }
                            Console.WriteLine(string.Format("InnerException: {0}", ex.InnerException.Message));
                            Console.WriteLine(string.Format("Message: {0}", ex.Message));
                        }
                        else
                        {
                            string className = PermissionsClass.ExceptionPermissionName(ex.Message);
                            if (className != string.Empty)
                            {
                                Console.WriteLine();
                                Console.WriteLine(string.Format("Add: -perm {0}.Unrestricted", className));
                            }
                            Console.WriteLine();
                            Console.WriteLine(string.Format("Message: {0}", ex.Message));
                        }
                        AppDomain.Unload(customDomain);
                    }
                }
            }
        }
    }
}
