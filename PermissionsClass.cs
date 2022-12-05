using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Permissions;
using System.Web;

namespace _700100_ACW1
{
    class PermissionsClass
    {
        static private Dictionary<string, string> parsePermission(string treeNodeText)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string treeNodeTextWithoutSpaces = treeNodeText.Replace(" ", "");
            string[] attributeStringArray = treeNodeTextWithoutSpaces.Split(';');
            dict.Add("Attribute", attributeStringArray[0]);
            if (attributeStringArray.Length > 1)
                dict.Add("Path", attributeStringArray[1].Replace("Path:", ""));
            return dict;
        }

        static public string ExceptionPermissionName(string exceptionMessage)
        {
            try
            {
                int systemPosition = exceptionMessage.IndexOf("System.");
                int commaPosition = exceptionMessage.IndexOf(',', systemPosition);
                string fullNameClass = exceptionMessage.Substring(systemPosition, commaPosition - systemPosition);
                string[] subClasses = fullNameClass.Split('.');
                return subClasses[subClasses.Length - 1];
            }
            catch
            {
                return string.Empty;
            }
        }

        static public void AddAspNetHostingPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryAspNetHostingPermission = parsePermission(permissionText);
            if (dictionaryAspNetHostingPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new AspNetHostingPermission(PermissionState.Unrestricted));
            if (dictionaryAspNetHostingPermission["Attribute"] == "None")
                permission.AddPermission(new AspNetHostingPermission(PermissionState.None));
            if (dictionaryAspNetHostingPermission["Attribute"] == "High")
                permission.AddPermission(new AspNetHostingPermission(AspNetHostingPermissionLevel.High));
            if (dictionaryAspNetHostingPermission["Attribute"] == "Low")
                permission.AddPermission(new AspNetHostingPermission(AspNetHostingPermissionLevel.Low));
            if (dictionaryAspNetHostingPermission["Attribute"] == "Medium")
                permission.AddPermission(new AspNetHostingPermission(AspNetHostingPermissionLevel.Medium));
            if (dictionaryAspNetHostingPermission["Attribute"] == "Minimal")
                permission.AddPermission(new AspNetHostingPermission(AspNetHostingPermissionLevel.Minimal));
        }

        static public void AddDnsPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryDnsPermission = parsePermission(permissionText);
            if (dictionaryDnsPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new DnsPermission(PermissionState.Unrestricted));
            if (dictionaryDnsPermission["Attribute"] == "None")
                permission.AddPermission(new DnsPermission(PermissionState.None));
        }

        static public void AddEventLogPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryEventLogPermission = parsePermission(permissionText);
            if (dictionaryEventLogPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new EventLogPermission(PermissionState.Unrestricted));
            if (dictionaryEventLogPermission["Attribute"] == "None")
                permission.AddPermission(new EventLogPermission(PermissionState.None));
            if (dictionaryEventLogPermission["Attribute"] == "Administer")
                permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.Administer, dictionaryEventLogPermission["Path"]));
            //if (dictionaryEventLogPermission["Attribute"] == "Audit")
            //    permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.Audit, dictionaryEventLogPermission["Path"]));
            //if (dictionaryEventLogPermission["Attribute"] == "Browse")
            //    permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.Browse, dictionaryEventLogPermission["Path"]));
            //if (dictionaryEventLogPermission["Attribute"] == "Instrument")
            //    permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.Instrument, dictionaryEventLogPermission["Path"]));
            if (dictionaryEventLogPermission["Attribute"] == "NoneEventLogs")
                permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.None, dictionaryEventLogPermission["Path"]));
            if (dictionaryEventLogPermission["Attribute"] == "Write")
                permission.AddPermission(new EventLogPermission(EventLogPermissionAccess.Write, dictionaryEventLogPermission["Path"]));
        }

        static public void AddNetworkInformationPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryNetworkInformationPermission = parsePermission(permissionText);
            if (dictionaryNetworkInformationPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new NetworkInformationPermission(PermissionState.Unrestricted));
            if (dictionaryNetworkInformationPermission["Attribute"] == "None")
                permission.AddPermission(new NetworkInformationPermission(PermissionState.None));
            if (dictionaryNetworkInformationPermission["Attribute"] == "NoneNetwork")
                permission.AddPermission(new NetworkInformationPermission(NetworkInformationAccess.None));
            if (dictionaryNetworkInformationPermission["Attribute"] == "Ping")
                permission.AddPermission(new NetworkInformationPermission(NetworkInformationAccess.Ping));
            if (dictionaryNetworkInformationPermission["Attribute"] == "Read")
                permission.AddPermission(new NetworkInformationPermission(NetworkInformationAccess.Read));
        }

        static public void AddPerformanceCounterPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryPerformanceCounterPermission = parsePermission(permissionText);
            if (dictionaryPerformanceCounterPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new PerformanceCounterPermission(PermissionState.Unrestricted));
            if (dictionaryPerformanceCounterPermission["Attribute"] == "None")
                permission.AddPermission(new PerformanceCounterPermission(PermissionState.None));
        }

        static public void AddSmtpPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionarySmtpPermission = parsePermission(permissionText);
            if (dictionarySmtpPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new SmtpPermission(PermissionState.Unrestricted));
            if (dictionarySmtpPermission["Attribute"] == "None")
                permission.AddPermission(new SmtpPermission(PermissionState.None));
            if (dictionarySmtpPermission["Attribute"] == "Connect")
                permission.AddPermission(new SmtpPermission(SmtpAccess.Connect));
            if (dictionarySmtpPermission["Attribute"] == "ConnectToUnrestrictedPort")
                permission.AddPermission(new SmtpPermission(SmtpAccess.ConnectToUnrestrictedPort));
            if (dictionarySmtpPermission["Attribute"] == "None SMTP")
                permission.AddPermission(new SmtpPermission(SmtpAccess.None));
        }

        static public void AddSocketPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionarySocketPermission = parsePermission(permissionText);
            if (dictionarySocketPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new SocketPermission(PermissionState.Unrestricted));
            if (dictionarySocketPermission["Attribute"] == "None")
                permission.AddPermission(new SocketPermission(PermissionState.None));
        }

        static public void AddEnvironmentPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryEnvironmentPermission = parsePermission(permissionText);
            if (dictionaryEnvironmentPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new EnvironmentPermission(PermissionState.Unrestricted));
            if (dictionaryEnvironmentPermission["Attribute"] == "None")
                permission.AddPermission(new EnvironmentPermission(PermissionState.None));
            if (dictionaryEnvironmentPermission["Attribute"] == "AllAccess")
                permission.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, dictionaryEnvironmentPermission["Path"]));
            if (dictionaryEnvironmentPermission["Attribute"] == "NoAccess")
                permission.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.NoAccess, dictionaryEnvironmentPermission["Path"]));
            if (dictionaryEnvironmentPermission["Attribute"] == "Read")
                permission.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.Read, dictionaryEnvironmentPermission["Path"]));
            if (dictionaryEnvironmentPermission["Attribute"] == "Write")
                permission.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.Write, dictionaryEnvironmentPermission["Path"]));
        }

        static public void AddFileDialogPermission(ref PermissionSet permission, string permissionText)
        {

            Dictionary<string, string> dictionaryFileDialogPermission = parsePermission(permissionText);
            if (dictionaryFileDialogPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new FileDialogPermission(PermissionState.Unrestricted));
            if (dictionaryFileDialogPermission["Attribute"] == "None")
                permission.AddPermission(new FileDialogPermission(PermissionState.None));
            if (dictionaryFileDialogPermission["Attribute"] == "NoneAccess")
                permission.AddPermission(new FileDialogPermission(FileDialogPermissionAccess.None));
            if (dictionaryFileDialogPermission["Attribute"] == "Open")
                permission.AddPermission(new FileDialogPermission(FileDialogPermissionAccess.Open));
            if (dictionaryFileDialogPermission["Attribute"] == "OpenSave")
                permission.AddPermission(new FileDialogPermission(FileDialogPermissionAccess.OpenSave));
            if (dictionaryFileDialogPermission["Attribute"] == "Save")
                permission.AddPermission(new FileDialogPermission(FileDialogPermissionAccess.Save));
        }

        static public void AddFileIOPermission(ref FileIOPermission fIOP, string permissionText)
        {
            Dictionary<string, string> dictionaryFileIOPermission = parsePermission(permissionText);
            if (dictionaryFileIOPermission["Attribute"] == "AllAccess")
            {
                fIOP.AddPathList(FileIOPermissionAccess.AllAccess, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.AllAccess;
                //fIOP.AllLocalFiles = FileIOPermissionAccess.AllAccess;
                //permission.AddPermission(fIOP);
            }
            if (dictionaryFileIOPermission["Attribute"] == "Append")
            {
                fIOP.AddPathList(FileIOPermissionAccess.Append, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.Append;
                //fIOP.AllLocalFiles = FileIOPermissionAccess.Append;
                //permission.AddPermission(fIOP);
            }
            if (dictionaryFileIOPermission["Attribute"] == "NoAccess")
            {
                fIOP.AddPathList(FileIOPermissionAccess.NoAccess, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.NoAccess;
                //fIOP.AllLocalFiles = FileIOPermissionAccess.NoAccess;
                //permission.AddPermission(fIOP);
            }
            if (dictionaryFileIOPermission["Attribute"] == "PathDiscovery")
            {
                fIOP.AddPathList(FileIOPermissionAccess.PathDiscovery, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.PathDiscovery;
                //fIOP.AllLocalFiles = FileIOPermissionAccess.PathDiscovery;
                //permission.AddPermission(fIOP);
            }
            if (dictionaryFileIOPermission["Attribute"] == "Read")
            {
                fIOP.AddPathList(FileIOPermissionAccess.Read, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.Read;
                //fIOP.AllLocalFiles = FileIOPermissionAccess.Read;
                //permission.AddPermission(fIOP);
            }
            if (dictionaryFileIOPermission["Attribute"] == "Write")
            {
                fIOP.AddPathList(FileIOPermissionAccess.Write, dictionaryFileIOPermission["Path"]);
                //fIOP.AllFiles = FileIOPermissionAccess.Write;
                //fIOP.AddPathList(FileIOPermissionAccess.Write, dictionaryFileIOPermission["Path"]);
                //fIOP.AllLocalFiles = FileIOPermissionAccess.Write;
                //permission.SetPermission(fIOP);
                //permission.AddPermission(fIOP);
            }
        }

        static public void AddGacIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryGacIdentityPermission = parsePermission(permissionText);
            if (dictionaryGacIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new GacIdentityPermission(PermissionState.Unrestricted));
            if (dictionaryGacIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new GacIdentityPermission(PermissionState.None));
        }

        static public void AddIsolatedStorageFilePermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryIsolatedStorageFilePermission = parsePermission(permissionText);
            if (dictionaryIsolatedStorageFilePermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new IsolatedStorageFilePermission(PermissionState.Unrestricted));
            if (dictionaryIsolatedStorageFilePermission["Attribute"] == "None")
                permission.AddPermission(new IsolatedStorageFilePermission(PermissionState.None));
        }

        static public void AddKeyContainerPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryKeyContainerPermission = parsePermission(permissionText);
            if (dictionaryKeyContainerPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new KeyContainerPermission(PermissionState.Unrestricted));
            if (dictionaryKeyContainerPermission["Attribute"] == "None")
                permission.AddPermission(new KeyContainerPermission(PermissionState.None));
            if (dictionaryKeyContainerPermission["Attribute"] == "AllFlags")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.AllFlags));
            if (dictionaryKeyContainerPermission["Attribute"] == "ChangeAcl")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.ChangeAcl));
            if (dictionaryKeyContainerPermission["Attribute"] == "Create")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Create));
            if (dictionaryKeyContainerPermission["Attribute"] == "Decrypt")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Decrypt));
            if (dictionaryKeyContainerPermission["Attribute"] == "Delete")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Delete));
            if (dictionaryKeyContainerPermission["Attribute"] == "Export")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Export));
            if (dictionaryKeyContainerPermission["Attribute"] == "Import")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Import));
            if (dictionaryKeyContainerPermission["Attribute"] == "NoFlags")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags));
            if (dictionaryKeyContainerPermission["Attribute"] == "Open")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Open));
            if (dictionaryKeyContainerPermission["Attribute"] == "Sign")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.Sign));
            if (dictionaryKeyContainerPermission["Attribute"] == "ViewAcl")
                permission.AddPermission(new KeyContainerPermission(KeyContainerPermissionFlags.ViewAcl));
        }

        static public void AddMediaPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryMediaPermission = parsePermission(permissionText);
            if (dictionaryMediaPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new MediaPermission(PermissionState.Unrestricted));
            if (dictionaryMediaPermission["Attribute"] == "None")
                permission.AddPermission(new MediaPermission(PermissionState.None));
            if (dictionaryMediaPermission["Attribute"] == "AllAudio")
                permission.AddPermission(new MediaPermission(MediaPermissionAudio.AllAudio));
            if (dictionaryMediaPermission["Attribute"] == "NoAudio")
                permission.AddPermission(new MediaPermission(MediaPermissionAudio.NoAudio));
            if (dictionaryMediaPermission["Attribute"] == "SafeAudio")
                permission.AddPermission(new MediaPermission(MediaPermissionAudio.SafeAudio));
            if (dictionaryMediaPermission["Attribute"] == "SiteOfOriginAudio")
                permission.AddPermission(new MediaPermission(MediaPermissionAudio.SiteOfOriginAudio));
            if (dictionaryMediaPermission["Attribute"] == "AllImage")
                permission.AddPermission(new MediaPermission(MediaPermissionImage.AllImage));
            if (dictionaryMediaPermission["Attribute"] == "NoImage")
                permission.AddPermission(new MediaPermission(MediaPermissionImage.NoImage));
            if (dictionaryMediaPermission["Attribute"] == "SafeImage")
                permission.AddPermission(new MediaPermission(MediaPermissionImage.SafeImage));
            if (dictionaryMediaPermission["Attribute"] == "SiteOfOriginImage")
                permission.AddPermission(new MediaPermission(MediaPermissionImage.SiteOfOriginImage));
            if (dictionaryMediaPermission["Attribute"] == "AllVideo")
                permission.AddPermission(new MediaPermission(MediaPermissionVideo.AllVideo));
            if (dictionaryMediaPermission["Attribute"] == "NoVideo")
                permission.AddPermission(new MediaPermission(MediaPermissionVideo.NoVideo));
            if (dictionaryMediaPermission["Attribute"] == "SafeVideo")
                permission.AddPermission(new MediaPermission(MediaPermissionVideo.SafeVideo));
            if (dictionaryMediaPermission["Attribute"] == "SiteOfOriginVideo")
                permission.AddPermission(new MediaPermission(MediaPermissionVideo.SiteOfOriginVideo));
        }

        static public void AddPrincipalPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryPrincipalPermission = parsePermission(permissionText);
            if (dictionaryPrincipalPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new PrincipalPermission(PermissionState.Unrestricted));
            if (dictionaryPrincipalPermission["Attribute"] == "None")
                permission.AddPermission(new PrincipalPermission(PermissionState.None));
        }

        static public void AddPublisherIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryPublisherIdentityPermission = parsePermission(permissionText);
            if (dictionaryPublisherIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new PublisherIdentityPermission(PermissionState.Unrestricted));
            if (dictionaryPublisherIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new PublisherIdentityPermission(PermissionState.None));
        }

        static public void AddReflectionPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryReflectionPermission = parsePermission(permissionText);
            if (dictionaryReflectionPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
            if (dictionaryReflectionPermission["Attribute"] == "None")
                permission.AddPermission(new ReflectionPermission(PermissionState.None));
        }

        static public void AddRegistryPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryRegistryPermission = parsePermission(permissionText);
            if (dictionaryRegistryPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new RegistryPermission(PermissionState.Unrestricted));
            if (dictionaryRegistryPermission["Attribute"] == "None")
                permission.AddPermission(new RegistryPermission(PermissionState.None));
            if (dictionaryRegistryPermission["Attribute"] == "AllAccess")
                permission.AddPermission(new RegistryPermission(RegistryPermissionAccess.AllAccess, dictionaryRegistryPermission["Path"]));
            if (dictionaryRegistryPermission["Attribute"] == "Create")
                permission.AddPermission(new RegistryPermission(RegistryPermissionAccess.Create, dictionaryRegistryPermission["Path"]));
            if (dictionaryRegistryPermission["Attribute"] == "NoAccess")
                permission.AddPermission(new RegistryPermission(RegistryPermissionAccess.NoAccess, dictionaryRegistryPermission["Path"]));
            if (dictionaryRegistryPermission["Attribute"] == "Read")
                permission.AddPermission(new RegistryPermission(RegistryPermissionAccess.Read, dictionaryRegistryPermission["Path"]));
            if (dictionaryRegistryPermission["Attribute"] == "Write")
                permission.AddPermission(new RegistryPermission(RegistryPermissionAccess.Write, dictionaryRegistryPermission["Path"]));
        }

        static public void AddSecurityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionarySecurityPermission = parsePermission(permissionText);
            if (dictionarySecurityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new SecurityPermission(PermissionState.Unrestricted));
            if (dictionarySecurityPermission["Attribute"] == "None")
                permission.AddPermission(new SecurityPermission(PermissionState.None));
            if (dictionarySecurityPermission["Attribute"] == "AllFlags")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags));
            if (dictionarySecurityPermission["Attribute"] == "Assertion")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.Assertion));
            if (dictionarySecurityPermission["Attribute"] == "BindingRedirects")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.BindingRedirects));
            if (dictionarySecurityPermission["Attribute"] == "ControlAppDomain")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlAppDomain));
            if (dictionarySecurityPermission["Attribute"] == "ControlDomainPolicy")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlDomainPolicy));
            if (dictionarySecurityPermission["Attribute"] == "ControlEvidence")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlEvidence));
            if (dictionarySecurityPermission["Attribute"] == "ControlPolicy")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlPolicy));
            if (dictionarySecurityPermission["Attribute"] == "ControlPrincipal")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlPrincipal));
            if (dictionarySecurityPermission["Attribute"] == "ControlThread")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlThread));
            if (dictionarySecurityPermission["Attribute"] == "Execution")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            if (dictionarySecurityPermission["Attribute"] == "Infrastructure")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.Infrastructure));
            if (dictionarySecurityPermission["Attribute"] == "NoFlags")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.NoFlags));
            if (dictionarySecurityPermission["Attribute"] == "RemotingConfiguration")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration));
            if (dictionarySecurityPermission["Attribute"] == "SerializationFormatter")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.SerializationFormatter));
            if (dictionarySecurityPermission["Attribute"] == "SkipVerification")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.SkipVerification));
            if (dictionarySecurityPermission["Attribute"] == "UnmanagedCode")
                permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
        }

        static public void AddSiteIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionarySiteIdentityPermission = parsePermission(permissionText);
            if (dictionarySiteIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new SiteIdentityPermission(PermissionState.Unrestricted));
            if (dictionarySiteIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new SiteIdentityPermission(PermissionState.None));
        }

        static public void AddStorePermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryStorePermission = parsePermission(permissionText);
            if (dictionaryStorePermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new StorePermission(PermissionState.Unrestricted));
            if (dictionaryStorePermission["Attribute"] == "None")
                permission.AddPermission(new StorePermission(PermissionState.None));
            if (dictionaryStorePermission["Attribute"] == "AllFlags")
                permission.AddPermission(new StorePermission(StorePermissionFlags.AllFlags));
            if (dictionaryStorePermission["Attribute"] == "AddToStore")
                permission.AddPermission(new StorePermission(StorePermissionFlags.AddToStore));
            if (dictionaryStorePermission["Attribute"] == "CreateStore")
                permission.AddPermission(new StorePermission(StorePermissionFlags.CreateStore));
            if (dictionaryStorePermission["Attribute"] == "DeleteStore")
                permission.AddPermission(new StorePermission(StorePermissionFlags.DeleteStore));
            if (dictionaryStorePermission["Attribute"] == "EnumerateCertificates")
                permission.AddPermission(new StorePermission(StorePermissionFlags.EnumerateCertificates));
            if (dictionaryStorePermission["Attribute"] == "EnumerateStores")
                permission.AddPermission(new StorePermission(StorePermissionFlags.EnumerateStores));
            if (dictionaryStorePermission["Attribute"] == "NoFlags")
                permission.AddPermission(new StorePermission(StorePermissionFlags.NoFlags));
            if (dictionaryStorePermission["Attribute"] == "OpenStore")
                permission.AddPermission(new StorePermission(StorePermissionFlags.OpenStore));
            if (dictionaryStorePermission["Attribute"] == "RemoveFromStore")
                permission.AddPermission(new StorePermission(StorePermissionFlags.RemoveFromStore));
        }

        static public void AddStrongNameIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryStrongNameIdentityPermission = parsePermission(permissionText);
            if (dictionaryStrongNameIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new StrongNameIdentityPermission(PermissionState.Unrestricted));
            if (dictionaryStrongNameIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new StrongNameIdentityPermission(PermissionState.None));
        }

        static public void AddTypeDescriptorPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryTypeDescriptorPermission = parsePermission(permissionText);
            if (dictionaryTypeDescriptorPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new TypeDescriptorPermission(PermissionState.Unrestricted));
            if (dictionaryTypeDescriptorPermission["Attribute"] == "None")
                permission.AddPermission(new TypeDescriptorPermission(PermissionState.None));
            if (dictionaryTypeDescriptorPermission["Attribute"] == "NoFlags")
                permission.AddPermission(new TypeDescriptorPermission(TypeDescriptorPermissionFlags.NoFlags));
            if (dictionaryTypeDescriptorPermission["Attribute"] == "RestrictedRegistrationAccess")
                permission.AddPermission(new TypeDescriptorPermission(TypeDescriptorPermissionFlags.RestrictedRegistrationAccess));
        }

        static public void AddUIPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryUIPermission = parsePermission(permissionText);
            if (dictionaryUIPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new UIPermission(PermissionState.Unrestricted));
            if (dictionaryUIPermission["Attribute"] == "None")
                permission.AddPermission(new UIPermission(PermissionState.None));
            if (dictionaryUIPermission["Attribute"] == "AllClipboard")
                permission.AddPermission(new UIPermission(UIPermissionClipboard.AllClipboard));
            if (dictionaryUIPermission["Attribute"] == "NoClipboard")
                permission.AddPermission(new UIPermission(UIPermissionClipboard.NoClipboard));
            if (dictionaryUIPermission["Attribute"] == "OwnClipboard")
                permission.AddPermission(new UIPermission(UIPermissionClipboard.OwnClipboard));
            if (dictionaryUIPermission["Attribute"] == "AllWindows")
                permission.AddPermission(new UIPermission(UIPermissionWindow.AllWindows));
            if (dictionaryUIPermission["Attribute"] == "NoWindows")
                permission.AddPermission(new UIPermission(UIPermissionWindow.NoWindows));
            if (dictionaryUIPermission["Attribute"] == "SafeSubWindows")
                permission.AddPermission(new UIPermission(UIPermissionWindow.SafeSubWindows));
            if (dictionaryUIPermission["Attribute"] == "SafeTopLevelWindows")
                permission.AddPermission(new UIPermission(UIPermissionWindow.SafeTopLevelWindows));
        }

        static public void AddUrlIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryUrlIdentityPermission = parsePermission(permissionText);
            if (dictionaryUrlIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new UrlIdentityPermission(PermissionState.Unrestricted));
            if (dictionaryUrlIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new UrlIdentityPermission(PermissionState.None));
        }

        static public void AddWebBrowserPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryWebBrowserPermission = parsePermission(permissionText);
            if (dictionaryWebBrowserPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new WebBrowserPermission(PermissionState.Unrestricted));
            if (dictionaryWebBrowserPermission["Attribute"] == "None")
                permission.AddPermission(new WebBrowserPermission(PermissionState.None));
            if (dictionaryWebBrowserPermission["Attribute"] == "NoneWebBrowser")
                permission.AddPermission(new WebBrowserPermission(WebBrowserPermissionLevel.None));
            if (dictionaryWebBrowserPermission["Attribute"] == "SafeWebBrowser")
                permission.AddPermission(new WebBrowserPermission(WebBrowserPermissionLevel.Safe));
            if (dictionaryWebBrowserPermission["Attribute"] == "UnrestrictedWebBrowser")
                permission.AddPermission(new WebBrowserPermission(WebBrowserPermissionLevel.Unrestricted));
        }

        static public void AddWebPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryWebPermission = parsePermission(permissionText);
            if (dictionaryWebPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new WebPermission(PermissionState.Unrestricted));
            if (dictionaryWebPermission["Attribute"] == "None")
                permission.AddPermission(new WebPermission(PermissionState.None));
            if (dictionaryWebPermission["Attribute"] == "Accept")
                permission.AddPermission(new WebPermission(NetworkAccess.Accept, dictionaryWebPermission["Path"]));
            if (dictionaryWebPermission["Attribute"] == "Connect")
                permission.AddPermission(new WebPermission(NetworkAccess.Connect, dictionaryWebPermission["Path"]));
        }

        static public void AddZoneIdentityPermission(ref PermissionSet permission, string permissionText)
        {
            Dictionary<string, string> dictionaryZoneIdentityPermission = parsePermission(permissionText);
            if (dictionaryZoneIdentityPermission["Attribute"] == "Unrestricted")
                permission.AddPermission(new ZoneIdentityPermission(PermissionState.Unrestricted));
            if (dictionaryZoneIdentityPermission["Attribute"] == "None")
                permission.AddPermission(new ZoneIdentityPermission(PermissionState.None));
            if (dictionaryZoneIdentityPermission["Attribute"] == "Internet")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.Internet));
            if (dictionaryZoneIdentityPermission["Attribute"] == "Intranet")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.Intranet));
            if (dictionaryZoneIdentityPermission["Attribute"] == "MyComputer")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.MyComputer));
            if (dictionaryZoneIdentityPermission["Attribute"] == "NoZone")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.NoZone));
            if (dictionaryZoneIdentityPermission["Attribute"] == "Trusted")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.Trusted));
            if (dictionaryZoneIdentityPermission["Attribute"] == "Untrusted")
                permission.AddPermission(new ZoneIdentityPermission(SecurityZone.Untrusted));
        }
    }
}
