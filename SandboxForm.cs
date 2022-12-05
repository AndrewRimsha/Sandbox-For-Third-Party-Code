using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace _700100_ACW1
{
    public partial class SandboxForm : Form
    {
        TableLayoutPanel aspNetHostingTLP = CreateControls.createTableLayoutPanel("aspNetHostingTLP", 1, 6);
        RadioButton unrestrictedAspNetHostingRadioButton = CreateControls.createRadioButton("unrestrictedAspNetHostingRadioButton", "Unrestricted");
        RadioButton noneAspNetHostingRadioButton = CreateControls.createRadioButton("noneAspNetHostingRadioButton", "None");
        RadioButton highAspNetHostingRadioButton = CreateControls.createRadioButton("highAspNetHostingRadioButton", "High");
        RadioButton lowAspNetHostingRadioButton = CreateControls.createRadioButton("lowAspNetHostingRadioButton", "Low");
        RadioButton mediumAspNetHostingRadioButton = CreateControls.createRadioButton("mediumAspNetHostingRadioButton", "Medium");
        RadioButton minimalAspNetHostingRadioButton = CreateControls.createRadioButton("minimalAspNetHostingRadioButton", "Minimal");
        TableLayoutPanel dnsTLP = CreateControls.createTableLayoutPanel("dnsTLP", 1, 2);
        RadioButton unrestrictedDnsRadioButton = CreateControls.createRadioButton("unrestrictedDnsRadioButton", "Unrestricted");
        RadioButton noneDnsRadioButton = CreateControls.createRadioButton("noneDnsRadioButton", "None");
        TableLayoutPanel eventLogTLP = CreateControls.createTableLayoutPanel("eventLogTLP", 1, 6);
        RadioButton unrestrictedEventLogRadioButton = CreateControls.createRadioButton("unrestrictedEventLogRadioButton", "Unrestricted");
        RadioButton noneEventLogRadioButton = CreateControls.createRadioButton("noneEventLogRadioButton", "None");
        RadioButton administerEventLogRadioButton = CreateControls.createRadioButton("administerEventLogRadioButton", "Administer");
        //RadioButton auditEventLogRadioButton = CreateControls.createRadioButton("auditEventLogRadioButton", "Audit");
        //RadioButton browseEventLogRadioButton = CreateControls.createRadioButton("browseEventLogRadioButton", "Browse");
        //RadioButton instrumentEventLogRadioButton = CreateControls.createRadioButton("instrumentEventLogRadioButton", "Instrument");
        RadioButton noneELEventLogRadioButton = CreateControls.createRadioButton("noneELEventLogRadioButton", "None Event Logs");
        RadioButton writeEventLogRadioButton = CreateControls.createRadioButton("writeEventLogRadioButton", "Write");
        TextBox pathEventLogTextBox = CreateControls.createTextBox("pathEventLogTextBox");
        TableLayoutPanel networkInformationTLP = CreateControls.createTableLayoutPanel("networkInformationTLP", 1, 5);
        RadioButton unrestrictedNetworkInformationRadioButton = CreateControls.createRadioButton("unrestrictedNetworkInformationRadioButton", "Unrestricted");
        RadioButton noneNetworkInformationRadioButton = CreateControls.createRadioButton("noneNetworkInformationRadioButton", "None");
        RadioButton readNetworkInformationRadioButton = CreateControls.createRadioButton("readNetworkInformationRadioButton", "Read");
        RadioButton pingNetworkInformationRadioButton = CreateControls.createRadioButton("pingNetworkInformationRadioButton", "Ping");
        RadioButton noneNetNetworkInformationRadioButton = CreateControls.createRadioButton("noneNetNetworkInformationRadioButton", "None Network");
        TableLayoutPanel performanceCounterTLP = CreateControls.createTableLayoutPanel("performanceCounterTLP", 1, 2);
        RadioButton unrestrictedPerformanceCounterRadioButton = CreateControls.createRadioButton("unrestrictedPerformanceCounterRadioButton", "Unrestricted");
        RadioButton nonePerformanceCounterRadioButton = CreateControls.createRadioButton("nonePerformanceCounterRadioButton", "None");
        TableLayoutPanel smtpTLP = CreateControls.createTableLayoutPanel("smtpTLP", 1, 5);
        RadioButton unrestrictedSmtpRadioButton = CreateControls.createRadioButton("unrestrictedSmtpRadioButton", "Unrestricted");
        RadioButton noneSmtpRadioButton = CreateControls.createRadioButton("noneSmtpRadioButton", "None");
        RadioButton connectSmtpRadioButton = CreateControls.createRadioButton("administerSmtpRadioButton", "Connect");
        RadioButton connectToUnrestrictedPortRadioButton = CreateControls.createRadioButton("auditSmtpRadioButton", "Connect To Unrestricted Port");
        RadioButton noneSMTPSmtpRadioButton = CreateControls.createRadioButton("browseSmtpRadioButton", "None SMTP");
        TableLayoutPanel socketTLP = CreateControls.createTableLayoutPanel("socketTLP", 1, 2);
        RadioButton unrestrictedSocketRadioButton = CreateControls.createRadioButton("unrestrictedSocketRadioButton", "Unrestricted");
        RadioButton noneSocketRadioButton = CreateControls.createRadioButton("noneSocketRadioButton", "None");
        TableLayoutPanel environmentTLP = CreateControls.createTableLayoutPanel("environmentTLP", 1, 7);
        RadioButton unrestrictedEnvironmentRadioButton = CreateControls.createRadioButton("unrestrictedEnvironmentRadioButton", "Unrestricted");
        RadioButton noneEnvironmentRadioButton = CreateControls.createRadioButton("noneEnvironmentRadioButton", "None");
        RadioButton allAccessEnvironmentRadioButton = CreateControls.createRadioButton("allAccessEnvironmentRadioButton", "All Access");
        RadioButton noAccessEnvironmentRadioButton = CreateControls.createRadioButton("noAccessEnvironmentRadioButton", "No Access");
        RadioButton readEnvironmentRadioButton = CreateControls.createRadioButton("readEnvironmentRadioButton", "Read");
        RadioButton writeEnvironmentRadioButton = CreateControls.createRadioButton("writeEnvironmentRadioButton", "Write");
        TextBox pathEnvironmentTextBox = CreateControls.createTextBox("pathEnvironmentTextBox");
        TableLayoutPanel fileDialogTLP = CreateControls.createTableLayoutPanel("fileDialogTLP", 1, 6);
        RadioButton unrestrictedFileDialogRadioButton = CreateControls.createRadioButton("unrestrictedFileDialogRadioButton", "Unrestricted");
        RadioButton noneFileDialogRadioButton = CreateControls.createRadioButton("noneFileDialogRadioButton", "None");
        RadioButton noneAccessFileDialogRadioButton = CreateControls.createRadioButton("noneAccessFileDialogRadioButton", "None access");
        RadioButton openFileDialogRadioButton = CreateControls.createRadioButton("openFileDialogRadioButton", "Open");
        RadioButton saveFileDialogRadioButton = CreateControls.createRadioButton("saveFileDialogRadioButton", "Save");
        RadioButton openSaveFileDialogRadioButton = CreateControls.createRadioButton("openSaveFileDialogRadioButton", "Open and Save");
        TableLayoutPanel fileIOTLP = CreateControls.createTableLayoutPanel("fileIOTLP", 1, 9);
        RadioButton unrestrictedFileIORadioButton = CreateControls.createRadioButton("unrestrictedFileIORadioButton", "Unrestricted");
        RadioButton noneFileIORadioButton = CreateControls.createRadioButton("noneFileIORadioButton", "None");
        RadioButton allAccessFileIORadioButton = CreateControls.createRadioButton("allAccessFileIORadioButton", "All Access");
        RadioButton appendFileIORadioButton = CreateControls.createRadioButton("appendFileIORadioButton", "Append");
        RadioButton noAccessFileIORadioButton = CreateControls.createRadioButton("noAccessFileIORadioButton", "No Access");
        RadioButton pathDiscoveryFileIORadioButton = CreateControls.createRadioButton("pathDiscoveryFileIORadioButton", "Path Discovery");
        RadioButton readFileIORadioButton = CreateControls.createRadioButton("readFileIORadioButton", "Read");
        RadioButton writeFileIORadioButton = CreateControls.createRadioButton("writeFileIORadioButton", "Write");
        TextBox pathFileIOTextBox = CreateControls.createTextBox("pathFileIOTextBox");
        TableLayoutPanel gacIdentityTLP = CreateControls.createTableLayoutPanel("gacIdentityTLP", 1, 2);
        RadioButton unrestrictedGacIdentityRadioButton = CreateControls.createRadioButton("unrestrictedGacIdentityRadioButton", "Unrestricted");
        RadioButton noneGacIdentityRadioButton = CreateControls.createRadioButton("noneGacIdentityRadioButton", "None");
        TableLayoutPanel isolatedStorageFileTLP = CreateControls.createTableLayoutPanel("isolatedStorageFileTLP", 1, 2);
        RadioButton unrestrictedIsolatedStorageFileRadioButton = CreateControls.createRadioButton("unrestrictedIsolatedStorageFileRadioButton", "Unrestricted");
        RadioButton noneIsolatedStorageFileRadioButton = CreateControls.createRadioButton("noneIsolatedStorageFileRadioButton", "None");
        TableLayoutPanel keyContainerFileTLP = CreateControls.createTableLayoutPanel("keyContainerFileTLP", 1, 13);
        RadioButton unrestrictedKeyContainerFileRadioButton = CreateControls.createRadioButton("unrestrictedKeyContainerFileRadioButton", "Unrestricted");
        RadioButton noneKeyContainerFileRadioButton = CreateControls.createRadioButton("noneKeyContainerFileRadioButton", "None");
        RadioButton allFlagsKeyContainerFileRadioButton = CreateControls.createRadioButton("allFlagsKeyContainerFileRadioButton", "AllFlags");
        RadioButton changeAclKeyContainerFileRadioButton = CreateControls.createRadioButton("changeAclKeyContainerFileRadioButton", "Change Acl");
        RadioButton createKeyContainerFileRadioButton = CreateControls.createRadioButton("createKeyContainerFileRadioButton", "Create");
        RadioButton decryptKeyContainerFileRadioButton = CreateControls.createRadioButton("decryptKeyContainerFileRadioButton", "Decrypt");
        RadioButton deleteKeyContainerFileRadioButton = CreateControls.createRadioButton("deleteKeyContainerFileRadioButton", "Delete");
        RadioButton exportKeyContainerFileRadioButton = CreateControls.createRadioButton("exportKeyContainerFileRadioButton", "Export");
        RadioButton importKeyContainerFileRadioButton = CreateControls.createRadioButton("importKeyContainerFileRadioButton", "Import");
        RadioButton noFlagsKeyContainerFileRadioButton = CreateControls.createRadioButton("noFlagsKeyContainerFileRadioButton", "No Flags");
        RadioButton openKeyContainerFileRadioButton = CreateControls.createRadioButton("openKeyContainerFileRadioButton", "Open");
        RadioButton signKeyContainerFileRadioButton = CreateControls.createRadioButton("signKeyContainerFileRadioButton", "Sign");
        RadioButton viewAclKeyContainerFileRadioButton = CreateControls.createRadioButton("viewAclKeyContainerFileRadioButton", "View Acl");
        TableLayoutPanel mediaPermissionTLP = CreateControls.createTableLayoutPanel("mediaPermissionTLP", 1, 14);
        RadioButton unrestrictedMediaPermissionRadioButton = CreateControls.createRadioButton("unrestrictedMediaPermissionRadioButton", "Unrestricted");
        RadioButton noneMediaPermissionRadioButton = CreateControls.createRadioButton("noneMediaPermissionRadioButton", "None");
        RadioButton allAudioMediaPermissionRadioButton = CreateControls.createRadioButton("allAudioMediaPermissionRadioButton", "All Audio");
        RadioButton noAudioMediaPermissionRadioButton = CreateControls.createRadioButton("noAudioMediaPermissionRadioButton", "No Audio");
        RadioButton safeAudioMediaPermissionRadioButton = CreateControls.createRadioButton("safeAudioMediaPermissionRadioButton", "Safe Audio");
        RadioButton safeOfOriginAudioMediaPermissionRadioButton = CreateControls.createRadioButton("safeOfOriginAudioMediaPermissionRadioButton", "Safe of Origin Audio");
        RadioButton allVideoMediaPermissionRadioButton = CreateControls.createRadioButton("allVideoMediaPermissionRadioButton", "All Video");
        RadioButton noVideoMediaPermissionRadioButton = CreateControls.createRadioButton("noVideoMediaPermissionRadioButton", "No Video");
        RadioButton safeVideoMediaPermissionRadioButton = CreateControls.createRadioButton("safeVideoMediaPermissionRadioButton", "Safe Video");
        RadioButton safeOfOriginVideoMediaPermissionRadioButton = CreateControls.createRadioButton("safeOfOriginVideoMediaPermissionRadioButton", "Safe of Origin Video");
        RadioButton allImageMediaPermissionRadioButton = CreateControls.createRadioButton("allImageMediaPermissionRadioButton", "All Image");
        RadioButton noImageMediaPermissionRadioButton = CreateControls.createRadioButton("noImageMediaPermissionRadioButton", "No Image");
        RadioButton safeImageMediaPermissionRadioButton = CreateControls.createRadioButton("safeImageMediaPermissionRadioButton", "Safe Image");
        RadioButton safeOfOriginImageMediaPermissionRadioButton = CreateControls.createRadioButton("safeOfOriginImageMediaPermissionRadioButton", "Safe of Origin Image");
        TableLayoutPanel principalPermissionTLP = CreateControls.createTableLayoutPanel("principalPermissionTLP", 1, 2);
        RadioButton unrestrictedPrincipalPermissionRadioButton = CreateControls.createRadioButton("unrestrictedPrincipalPermissionRadioButton", "Unrestricted");
        RadioButton nonePrincipalPermissionRadioButton = CreateControls.createRadioButton("nonePrincipalPermissionRadioButton", "None");
        TableLayoutPanel publisherIdentityPermissionTLP = CreateControls.createTableLayoutPanel("publisherIdentityPermissionTLP", 1, 2);
        RadioButton unrestrictedPublisherIdentityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedPublisherIdentityPermissionRadioButton", "Unrestricted");
        RadioButton nonePublisherIdentityPermissionRadioButton = CreateControls.createRadioButton("nonePublisherIdentityPermissionRadioButton", "None");
        TableLayoutPanel reflectionPermissionTLP = CreateControls.createTableLayoutPanel("reflectionPermissionTLP", 1, 2);
        RadioButton unrestrictedReflectionPermissionRadioButton = CreateControls.createRadioButton("unrestrictedReflectionPermissionRadioButton", "Unrestricted");
        RadioButton noneReflectionPermissionRadioButton = CreateControls.createRadioButton("noneReflectionPermissionRadioButton", "None");
        TableLayoutPanel registryPermissionTLP = CreateControls.createTableLayoutPanel("registryPermissionTLP", 1, 8);
        RadioButton unrestrictedRegistryPermissionRadioButton = CreateControls.createRadioButton("unrestrictedRegistryPermissionRadioButton", "Unrestricted");
        RadioButton noneRegistryPermissionRadioButton = CreateControls.createRadioButton("noneRegistryPermissionRadioButton", "None");
        RadioButton allAccessRegistryPermissionRadioButton = CreateControls.createRadioButton("allAccessRegistryPermissionRadioButton", "All Access");
        RadioButton createRegistryPermissionRadioButton = CreateControls.createRadioButton("createRegistryPermissionRadioButton", "Create");
        RadioButton noAccessRegistryPermissionRadioButton = CreateControls.createRadioButton("noAccessRegistryPermissionRadioButton", "No Access");
        RadioButton readRegistryPermissionRadioButton = CreateControls.createRadioButton("readRegistryPermissionRadioButton", "Read");
        RadioButton writeRegistryPermissionRadioButton = CreateControls.createRadioButton("writeRegistryPermissionRadioButton", "Write");
        TextBox pathRegistryPermissionTextBox = CreateControls.createTextBox("pathRegistryPermissionTextBox");
        TableLayoutPanel securityPermissionTLP = CreateControls.createTableLayoutPanel("securityPermissionTLP", 1, 18);
        RadioButton unrestrictedSecurityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedSecurityPermissionRadioButton", "Unrestricted");
        RadioButton noneSecurityPermissionRadioButton = CreateControls.createRadioButton("noneSecurityPermissionRadioButton", "None");
        RadioButton allFlagsSecurityPermissionRadioButton = CreateControls.createRadioButton("allFlagsSecurityPermissionRadioButton", "All Flags");
        RadioButton assertionSecurityPermissionRadioButton = CreateControls.createRadioButton("assertionSecurityPermissionRadioButton", "Assertion");
        RadioButton bindingRedirectsSecurityPermissionRadioButton = CreateControls.createRadioButton("bindingRedirectsSecurityPermissionRadioButton", "Binding Redirects");
        RadioButton controlAppDomainSecurityPermissionRadioButton = CreateControls.createRadioButton("controlAppDomainSecurityPermissionRadioButton", "Control App Domain");
        RadioButton controlDomainPolicySecurityPermissionRadioButton = CreateControls.createRadioButton("controlDomainPolicySecurityPermissionRadioButton", "Control Domain Policy");
        RadioButton controlEvidenceSecurityPermissionRadioButton = CreateControls.createRadioButton("controlEvidenceSecurityPermissionRadioButton", "Control Evidence");
        RadioButton controlPolicySecurityPermissionRadioButton = CreateControls.createRadioButton("controlPolicySecurityPermissionRadioButton", "Control Policy");
        RadioButton controlPrincipalSecurityPermissionRadioButton = CreateControls.createRadioButton("controlPrincipalSecurityPermissionRadioButton", "Control Principal");
        RadioButton controlThreadSecurityPermissionRadioButton = CreateControls.createRadioButton("controlThreadSecurityPermissionRadioButton", "Control Thread");
        RadioButton executionSecurityPermissionRadioButton = CreateControls.createRadioButton("executionSecurityPermissionRadioButton", "Execution");
        RadioButton infrastructureSecurityPermissionRadioButton = CreateControls.createRadioButton("infrastructureSecurityPermissionRadioButton", "Infrastructure");
        RadioButton noFlagsSecurityPermissionRadioButton = CreateControls.createRadioButton("noFlagsSecurityPermissionRadioButton", "No Flags");
        RadioButton remotingConfigurationSecurityPermissionRadioButton = CreateControls.createRadioButton("remotingConfigurationSecurityPermissionRadioButton", "Remoting Configuration");
        RadioButton serializationFormatterSecurityPermissionRadioButton = CreateControls.createRadioButton("serializationFormatterSecurityPermissionRadioButton", "Serialization Formatter");
        RadioButton skipVerificationSecurityPermissionRadioButton = CreateControls.createRadioButton("skipVerificationSecurityPermissionRadioButton", "Skip Verification");
        RadioButton unmanagedCodeSecurityPermissionRadioButton = CreateControls.createRadioButton("unmanagedCodeSecurityPermissionRadioButton", "Unmanaged Code");
        TableLayoutPanel siteIdentityPermissionTLP = CreateControls.createTableLayoutPanel("siteIdentityPermissionTLP", 1, 2);
        RadioButton unrestrictedSiteIdentityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedSiteIdentityPermissionRadioButton", "Unrestricted");
        RadioButton noneSiteIdentityPermissionRadioButton = CreateControls.createRadioButton("noneSiteIdentityPermissionRadioButton", "None");
        TableLayoutPanel storePermissionTLP = CreateControls.createTableLayoutPanel("storePermissionTLP", 1, 11);
        RadioButton unrestrictedStorePermissionRadioButton = CreateControls.createRadioButton("unrestrictedStorePermissionRadioButton", "Unrestricted");
        RadioButton noneStorePermissionRadioButton = CreateControls.createRadioButton("noneStorePermissionRadioButton", "None");
        RadioButton addToStoreStorePermissionRadioButton = CreateControls.createRadioButton("addToStoreStorePermissionRadioButton", "Add To Store");
        RadioButton allFlagsStorePermissionRadioButton = CreateControls.createRadioButton("allFlagsStorePermissionRadioButton", "All Flags");
        RadioButton createStoreStorePermissionRadioButton = CreateControls.createRadioButton("createStoreStorePermissionRadioButton", "Create Store");
        RadioButton deleteStoreStorePermissionRadioButton = CreateControls.createRadioButton("deleteStoreStorePermissionRadioButton", "Delete Store");
        RadioButton enumerateCertificatesStorePermissionRadioButton = CreateControls.createRadioButton("enumerateCertificatesStorePermissionRadioButton", "Enumerate Certificates");
        RadioButton enumerateStoresStorePermissionRadioButton = CreateControls.createRadioButton("enumerateStoresStorePermissionRadioButton", "Enumerate Stores");
        RadioButton noFlagsStorePermissionRadioButton = CreateControls.createRadioButton("noFlagsStorePermissionRadioButton", "No Flags");
        RadioButton openStoreStorePermissionRadioButton = CreateControls.createRadioButton("openStoreStorePermissionRadioButton", "Open Store");
        RadioButton removeFromStoreStorePermissionRadioButton = CreateControls.createRadioButton("removeFromStoreStorePermissionRadioButton", "Remove From Store");
        TableLayoutPanel strongNameIdentityPermissionTLP = CreateControls.createTableLayoutPanel("strongNameIdentityPermissionTLP", 1, 2);
        RadioButton unrestrictedStrongNameIdentityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedStrongNameIdentityPermissionRadioButton", "Unrestricted");
        RadioButton noneStrongNameIdentityPermissionRadioButton = CreateControls.createRadioButton("noneStrongNameIdentityPermissionRadioButton", "None");
        TableLayoutPanel typeDescriptorPermissionTLP = CreateControls.createTableLayoutPanel("typeDescriptorPermissionTLP", 1, 4);
        RadioButton unrestrictedTypeDescriptorPermissionRadioButton = CreateControls.createRadioButton("unrestrictedTypeDescriptorPermissionRadioButton", "Unrestricted");
        RadioButton noneTypeDescriptorPermissionRadioButton = CreateControls.createRadioButton("noneTypeDescriptorPermissionRadioButton", "None");
        RadioButton noFlagsTypeDescriptorPermissionRadioButton = CreateControls.createRadioButton("noFlagsTypeDescriptorPermissionRadioButton", "No Flags");
        RadioButton restrictedRegistrationAccessTypeDescriptorPermissionRadioButton = CreateControls.createRadioButton("restrictedRegistrationAccessTypeDescriptorPermissionRadioButton", "Restricted Registration Access");
        TableLayoutPanel uIPermissionTLP = CreateControls.createTableLayoutPanel("uIPermissionTLP", 1, 9);
        RadioButton unrestrictedUIPermissionRadioButton = CreateControls.createRadioButton("unrestrictedUIPermissionRadioButton", "Unrestricted");
        RadioButton noneUIPermissionRadioButton = CreateControls.createRadioButton("noneUIPermissionRadioButton", "None");
        RadioButton allClipboardUIPermissionClipboardRadioButton = CreateControls.createRadioButton("allClipboardUIPermissionClipboardRadioButton", "All Clipboard");
        RadioButton noClipboardUIPermissionClipboardRadioButton = CreateControls.createRadioButton("noClipboardUIPermissionClipboardRadioButton", "No Clipboard");
        RadioButton ownClipboardUIPermissionClipboardRadioButton = CreateControls.createRadioButton("ownClipboardUIPermissionClipboardRadioButton", "Own Clipboard");
        RadioButton allWindowsUIPermissionWindowRadioButton = CreateControls.createRadioButton("allWindowsUIPermissionWindowRadioButton", "All Windows");
        RadioButton noWindowsUIPermissionWindowRadioButton = CreateControls.createRadioButton("noWindowsUIPermissionWindowRadioButton", "No Windows");
        RadioButton safeSubWindowsUIPermissionWindowRadioButton = CreateControls.createRadioButton("safeSubWindowsUIPermissionWindowRadioButton", "Safe Sub Windows");
        RadioButton safeTopLevelWindowsUIPermissionWindowRadioButton = CreateControls.createRadioButton("safeTopLevelWindowsUIPermissionWindowRadioButton", "Safe Top Level Windows");
        TableLayoutPanel urlIdentityPermissionTLP = CreateControls.createTableLayoutPanel("urlIdentityPermissionTLP", 1, 2);
        RadioButton unrestrictedUrlIdentityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedUrlIdentityPermissionRadioButton", "Unrestricted");
        RadioButton noneUrlIdentityPermissionRadioButton = CreateControls.createRadioButton("noneUrlIdentityPermissionRadioButton", "None");
        TableLayoutPanel webBrowserPermissionTLP = CreateControls.createTableLayoutPanel("webBrowserPermissionTLP", 1, 5);
        RadioButton unrestrictedWebBrowserPermissionRadioButton = CreateControls.createRadioButton("unrestrictedWebBrowserPermissionRadioButton", "Unrestricted");
        RadioButton noneWebBrowserPermissionRadioButton = CreateControls.createRadioButton("noneWebBrowserPermissionRadioButton", "None");
        RadioButton noneWBWebBrowserPermissionRadioButton = CreateControls.createRadioButton("noneWBWebBrowserPermissionRadioButton", "None Web Browser");
        RadioButton safeWebBrowserPermissionRadioButton = CreateControls.createRadioButton("safeWebBrowserPermissionRadioButton", "Safe Web Browser");
        RadioButton unrestrictedWBWebBrowserPermissionRadioButton = CreateControls.createRadioButton("unrestrictedWBWebBrowserPermissionRadioButton", "Unrestricted Web Browser");
        TableLayoutPanel webPermissionTLP = CreateControls.createTableLayoutPanel("webPermissionTLP", 1, 5);
        RadioButton unrestrictedWebPermissionRadioButton = CreateControls.createRadioButton("unrestrictedWebPermissionRadioButton", "Unrestricted");
        RadioButton noneWebPermissionRadioButton = CreateControls.createRadioButton("noneWebPermissionRadioButton", "None");
        RadioButton acceptWebPermissionRadioButton = CreateControls.createRadioButton("noneWBWebPermissionRadioButton", "Accept");
        RadioButton connectWebPermissionRadioButton = CreateControls.createRadioButton("safeWebPermissionRadioButton", "Connect");
        TextBox pathWebPermissionTextBox = CreateControls.createTextBox("pathWebPermissionTextBox");
        TableLayoutPanel zoneIdentityPermissionTLP = CreateControls.createTableLayoutPanel("zoneIdentityPermissionTLP", 1, 8);
        RadioButton unrestrictedZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("unrestrictedZoneIdentityPermissionRadioButton", "Unrestricted");
        RadioButton noneZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("noneZoneIdentityPermissionRadioButton", "None");
        RadioButton internetZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("internetZoneIdentityPermissionRadioButton", "Internet");
        RadioButton intranetZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("intranetZoneIdentityPermissionRadioButton", "Intranet");
        RadioButton myComputerZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("myComputerZoneIdentityPermissionRadioButton", "My Computer");
        RadioButton noZoneZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("noZoneZoneIdentityPermissionRadioButton", "No Zone");
        RadioButton trustedZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("trustedZoneIdentityPermissionRadioButton", "Trusted");
        RadioButton untrustedZoneIdentityPermissionRadioButton = CreateControls.createRadioButton("untrustedZoneIdentityPermissionRadioButton", "Untrusted");

        public SandboxForm()
        {
            InitializeComponent();
            this.Text = "Sandbox by Andrew Rimsha";
            launchAppButton.Click += LaunchAppButton_Click;
            addPermissionsButton.Click += AddPermissionsButton_Click;
            exitButton.Click += ExitButton_Click;
            permissionsListBox.SelectedValueChanged += PermissionsListBox_SelectedValueChanged;
            addedPermissionsTreeView.CheckBoxes = true;
            //removePermissionsButton.Click += RemovePermissionsButton_Click;
            invertAllTreeViewButton.Click += InvertAllTreeViewButton_Click;
            unselectAllTreeViewButton.Click += UnselectAllTreeViewButton_Click;
            selectAllTreeViewButton.Click += SelectAllTreeViewButton_Click;
            sortAllTreeViewButton.Click += SortAllTreeViewButton_Click;
            removeSelectedTreeViewButton.Click += RemoveSelectedTreeViewButton_Click;
            clearAllTreeViewButton.Click += ClearAllTreeViewButton_Click;
            pathToAppButton.Click += PathToAppButton_Click;
            clearArgsButton.Click += ClearArgsButton_Click;

            #region ASPNetHost
            unrestrictedAspNetHostingRadioButton.Checked = true;
            aspNetHostingTLP.Controls.Add(unrestrictedAspNetHostingRadioButton, 0, 0);
            aspNetHostingTLP.Controls.Add(noneAspNetHostingRadioButton, 0, 1);
            aspNetHostingTLP.Controls.Add(highAspNetHostingRadioButton, 0, 2);
            aspNetHostingTLP.Controls.Add(lowAspNetHostingRadioButton, 0, 3);
            aspNetHostingTLP.Controls.Add(mediumAspNetHostingRadioButton, 0, 4);
            aspNetHostingTLP.Controls.Add(minimalAspNetHostingRadioButton, 0, 5);
            #endregion
            #region DNS
            unrestrictedDnsRadioButton.Checked = true;
            dnsTLP.Controls.Add(unrestrictedDnsRadioButton, 0, 0);
            dnsTLP.Controls.Add(noneDnsRadioButton, 0, 1);
            #endregion
            #region EventLog
            unrestrictedEventLogRadioButton.Checked = true;
            eventLogTLP.Controls.Add(unrestrictedEventLogRadioButton, 0, 0);
            eventLogTLP.Controls.Add(noneEventLogRadioButton, 0, 1);
            eventLogTLP.Controls.Add(administerEventLogRadioButton, 0, 2);
            //eventLogTLP.Controls.Add(auditEventLogRadioButton, 0, 3);
            //eventLogTLP.Controls.Add(browseEventLogRadioButton, 0, 4);
            //eventLogTLP.Controls.Add(instrumentEventLogRadioButton, 0, 5);
            eventLogTLP.Controls.Add(noneELEventLogRadioButton, 0, 3);
            eventLogTLP.Controls.Add(writeEventLogRadioButton, 0, 4);
            eventLogTLP.Controls.Add(pathEventLogTextBox, 0, 5);
            #endregion
            #region NetworkInformation
            unrestrictedNetworkInformationRadioButton.Checked = true;
            networkInformationTLP.Controls.Add(unrestrictedNetworkInformationRadioButton, 0, 0);
            networkInformationTLP.Controls.Add(noneNetworkInformationRadioButton, 0, 1);
            networkInformationTLP.Controls.Add(readNetworkInformationRadioButton, 0, 2);
            networkInformationTLP.Controls.Add(pingNetworkInformationRadioButton, 0, 3);
            networkInformationTLP.Controls.Add(noneNetNetworkInformationRadioButton, 0, 4);
            #endregion
            #region PerformanceCounter
            unrestrictedPerformanceCounterRadioButton.Checked = true;
            performanceCounterTLP.Controls.Add(unrestrictedPerformanceCounterRadioButton, 0, 0);
            performanceCounterTLP.Controls.Add(nonePerformanceCounterRadioButton, 0, 1);
            #endregion
            #region SMTP
            unrestrictedSmtpRadioButton.Checked = true;
            smtpTLP.Controls.Add(unrestrictedSmtpRadioButton, 0, 0);
            smtpTLP.Controls.Add(noneSmtpRadioButton, 0, 1);
            smtpTLP.Controls.Add(connectSmtpRadioButton, 0, 2);
            smtpTLP.Controls.Add(connectToUnrestrictedPortRadioButton, 0, 3);
            smtpTLP.Controls.Add(noneSMTPSmtpRadioButton, 0, 4);
            #endregion
            #region Socket
            unrestrictedSocketRadioButton.Checked = true;
            socketTLP.Controls.Add(unrestrictedSocketRadioButton, 0, 0);
            socketTLP.Controls.Add(noneSocketRadioButton, 0, 1);
            #endregion

            #region Environment
            unrestrictedEnvironmentRadioButton.Checked = true;
            environmentTLP.Controls.Add(unrestrictedEnvironmentRadioButton, 0, 0);
            environmentTLP.Controls.Add(noneEnvironmentRadioButton, 0, 1);
            environmentTLP.Controls.Add(allAccessEnvironmentRadioButton, 0, 2);
            environmentTLP.Controls.Add(noAccessEnvironmentRadioButton, 0, 3);
            environmentTLP.Controls.Add(readEnvironmentRadioButton, 0, 4);
            environmentTLP.Controls.Add(writeEnvironmentRadioButton, 0, 5);
            environmentTLP.Controls.Add(pathEnvironmentTextBox, 0, 6);
            #endregion
            #region FileDialog
            unrestrictedFileDialogRadioButton.Checked = true;
            fileDialogTLP.Controls.Add(unrestrictedFileDialogRadioButton, 0, 0);
            fileDialogTLP.Controls.Add(noneFileDialogRadioButton, 0, 1);
            fileDialogTLP.Controls.Add(noneAccessFileDialogRadioButton, 0, 2);
            fileDialogTLP.Controls.Add(openFileDialogRadioButton, 0, 3);
            fileDialogTLP.Controls.Add(saveFileDialogRadioButton, 0, 4);
            fileDialogTLP.Controls.Add(openSaveFileDialogRadioButton, 0, 5);
            #endregion
            #region FileIO
            unrestrictedFileIORadioButton.Checked = true;
            fileIOTLP.Controls.Add(unrestrictedFileIORadioButton, 0, 0);
            fileIOTLP.Controls.Add(noneFileIORadioButton, 0, 1);
            fileIOTLP.Controls.Add(allAccessFileIORadioButton, 0, 2);
            fileIOTLP.Controls.Add(appendFileIORadioButton, 0, 3);
            fileIOTLP.Controls.Add(noAccessFileIORadioButton, 0, 4);
            fileIOTLP.Controls.Add(pathDiscoveryFileIORadioButton, 0, 5);
            fileIOTLP.Controls.Add(readFileIORadioButton, 0, 6);
            fileIOTLP.Controls.Add(writeFileIORadioButton, 0, 7);
            fileIOTLP.Controls.Add(pathFileIOTextBox, 0, 8);
            #endregion
            #region GacIdentity
            unrestrictedGacIdentityRadioButton.Checked = true;
            gacIdentityTLP.Controls.Add(unrestrictedGacIdentityRadioButton, 0, 0);
            gacIdentityTLP.Controls.Add(noneGacIdentityRadioButton, 0, 1);
            #endregion
            #region IsolatedStorageFile
            unrestrictedIsolatedStorageFileRadioButton.Checked = true;
            isolatedStorageFileTLP.Controls.Add(unrestrictedIsolatedStorageFileRadioButton, 0, 0);
            isolatedStorageFileTLP.Controls.Add(noneIsolatedStorageFileRadioButton, 0, 1);
            #endregion
            #region KeyContainerFile
            unrestrictedKeyContainerFileRadioButton.Checked = true;
            keyContainerFileTLP.Controls.Add(unrestrictedKeyContainerFileRadioButton, 0, 0);
            keyContainerFileTLP.Controls.Add(noneKeyContainerFileRadioButton, 0, 1);
            keyContainerFileTLP.Controls.Add(allFlagsKeyContainerFileRadioButton, 0, 2);
            keyContainerFileTLP.Controls.Add(changeAclKeyContainerFileRadioButton, 0, 3);
            keyContainerFileTLP.Controls.Add(createKeyContainerFileRadioButton, 0, 4);
            keyContainerFileTLP.Controls.Add(decryptKeyContainerFileRadioButton, 0, 5);
            keyContainerFileTLP.Controls.Add(deleteKeyContainerFileRadioButton, 0, 6);
            keyContainerFileTLP.Controls.Add(exportKeyContainerFileRadioButton, 0, 7);
            keyContainerFileTLP.Controls.Add(importKeyContainerFileRadioButton, 0, 8);
            keyContainerFileTLP.Controls.Add(noFlagsKeyContainerFileRadioButton, 0, 9);
            keyContainerFileTLP.Controls.Add(openKeyContainerFileRadioButton, 0, 10);
            keyContainerFileTLP.Controls.Add(signKeyContainerFileRadioButton, 0, 11);
            keyContainerFileTLP.Controls.Add(viewAclKeyContainerFileRadioButton, 0, 12);
            #endregion
            #region MediaPermission
            unrestrictedMediaPermissionRadioButton.Checked = true;
            mediaPermissionTLP.Controls.Add(unrestrictedMediaPermissionRadioButton, 0, 0);
            mediaPermissionTLP.Controls.Add(noneMediaPermissionRadioButton, 0, 1);
            mediaPermissionTLP.Controls.Add(allAudioMediaPermissionRadioButton, 0, 2);
            mediaPermissionTLP.Controls.Add(noAudioMediaPermissionRadioButton, 0, 3);
            mediaPermissionTLP.Controls.Add(safeAudioMediaPermissionRadioButton, 0, 4);
            mediaPermissionTLP.Controls.Add(safeOfOriginAudioMediaPermissionRadioButton, 0, 5);
            mediaPermissionTLP.Controls.Add(allVideoMediaPermissionRadioButton, 0, 6);
            mediaPermissionTLP.Controls.Add(noVideoMediaPermissionRadioButton, 0, 7);
            mediaPermissionTLP.Controls.Add(safeVideoMediaPermissionRadioButton, 0, 8);
            mediaPermissionTLP.Controls.Add(safeOfOriginVideoMediaPermissionRadioButton, 0, 9);
            mediaPermissionTLP.Controls.Add(allImageMediaPermissionRadioButton, 0, 10);
            mediaPermissionTLP.Controls.Add(noImageMediaPermissionRadioButton, 0, 11);
            mediaPermissionTLP.Controls.Add(safeImageMediaPermissionRadioButton, 0, 12);
            mediaPermissionTLP.Controls.Add(safeOfOriginImageMediaPermissionRadioButton, 0, 13);
            #endregion
            #region Principal
            unrestrictedPrincipalPermissionRadioButton.Checked = true;
            principalPermissionTLP.Controls.Add(unrestrictedPrincipalPermissionRadioButton, 0, 0);
            principalPermissionTLP.Controls.Add(nonePrincipalPermissionRadioButton, 0, 1);
            #endregion
            #region PublisherIdentity
            unrestrictedPublisherIdentityPermissionRadioButton.Checked = true;
            publisherIdentityPermissionTLP.Controls.Add(unrestrictedPublisherIdentityPermissionRadioButton, 0, 0);
            publisherIdentityPermissionTLP.Controls.Add(nonePublisherIdentityPermissionRadioButton, 0, 1);
            #endregion
            #region Reflection
            unrestrictedReflectionPermissionRadioButton.Checked = true;
            reflectionPermissionTLP.Controls.Add(unrestrictedReflectionPermissionRadioButton, 0, 0);
            reflectionPermissionTLP.Controls.Add(noneReflectionPermissionRadioButton, 0, 1);
            #endregion
            #region Registry
            unrestrictedRegistryPermissionRadioButton.Checked = true;
            registryPermissionTLP.Controls.Add(unrestrictedRegistryPermissionRadioButton, 0, 0);
            registryPermissionTLP.Controls.Add(noneRegistryPermissionRadioButton, 0, 1);
            registryPermissionTLP.Controls.Add(allAccessRegistryPermissionRadioButton, 0, 2);
            registryPermissionTLP.Controls.Add(createRegistryPermissionRadioButton, 0, 3);
            registryPermissionTLP.Controls.Add(noAccessRegistryPermissionRadioButton, 0, 4);
            registryPermissionTLP.Controls.Add(readRegistryPermissionRadioButton, 0, 5);
            registryPermissionTLP.Controls.Add(writeRegistryPermissionRadioButton, 0, 6);
            registryPermissionTLP.Controls.Add(pathRegistryPermissionTextBox, 0, 7);
            #endregion
            #region Security
            unrestrictedSecurityPermissionRadioButton.Checked = true;
            securityPermissionTLP.Controls.Add(unrestrictedSecurityPermissionRadioButton, 0, 0);
            securityPermissionTLP.Controls.Add(noneSecurityPermissionRadioButton, 0, 1);
            securityPermissionTLP.Controls.Add(allFlagsSecurityPermissionRadioButton, 0, 2);
            securityPermissionTLP.Controls.Add(assertionSecurityPermissionRadioButton, 0, 3);
            securityPermissionTLP.Controls.Add(bindingRedirectsSecurityPermissionRadioButton, 0, 4);
            securityPermissionTLP.Controls.Add(controlAppDomainSecurityPermissionRadioButton, 0, 5);
            securityPermissionTLP.Controls.Add(controlDomainPolicySecurityPermissionRadioButton, 0, 6);
            securityPermissionTLP.Controls.Add(controlEvidenceSecurityPermissionRadioButton, 0, 7);
            securityPermissionTLP.Controls.Add(controlPolicySecurityPermissionRadioButton, 0, 8);
            securityPermissionTLP.Controls.Add(controlPrincipalSecurityPermissionRadioButton, 0, 9);
            securityPermissionTLP.Controls.Add(controlThreadSecurityPermissionRadioButton, 0, 10);
            securityPermissionTLP.Controls.Add(executionSecurityPermissionRadioButton, 0, 11);
            securityPermissionTLP.Controls.Add(infrastructureSecurityPermissionRadioButton, 0, 12);
            securityPermissionTLP.Controls.Add(noFlagsSecurityPermissionRadioButton, 0, 13);
            securityPermissionTLP.Controls.Add(remotingConfigurationSecurityPermissionRadioButton, 0, 14);
            securityPermissionTLP.Controls.Add(serializationFormatterSecurityPermissionRadioButton, 0, 15);
            securityPermissionTLP.Controls.Add(skipVerificationSecurityPermissionRadioButton, 0, 16);
            securityPermissionTLP.Controls.Add(unmanagedCodeSecurityPermissionRadioButton, 0, 17);
            #endregion
            #region SiteIdentity
            unrestrictedSiteIdentityPermissionRadioButton.Checked = true;
            siteIdentityPermissionTLP.Controls.Add(unrestrictedSiteIdentityPermissionRadioButton, 0, 0);
            siteIdentityPermissionTLP.Controls.Add(noneSiteIdentityPermissionRadioButton, 0, 1);
            #endregion
            #region Store
            unrestrictedStorePermissionRadioButton.Checked = true;
            storePermissionTLP.Controls.Add(unrestrictedStorePermissionRadioButton, 0, 0);
            storePermissionTLP.Controls.Add(noneStorePermissionRadioButton, 0, 1);
            storePermissionTLP.Controls.Add(addToStoreStorePermissionRadioButton, 0, 2);
            storePermissionTLP.Controls.Add(allFlagsStorePermissionRadioButton, 0, 3);
            storePermissionTLP.Controls.Add(createStoreStorePermissionRadioButton, 0, 4);
            storePermissionTLP.Controls.Add(deleteStoreStorePermissionRadioButton, 0, 5);
            storePermissionTLP.Controls.Add(enumerateCertificatesStorePermissionRadioButton, 0, 6);
            storePermissionTLP.Controls.Add(enumerateStoresStorePermissionRadioButton, 0, 7);
            storePermissionTLP.Controls.Add(noFlagsStorePermissionRadioButton, 0, 8);
            storePermissionTLP.Controls.Add(openStoreStorePermissionRadioButton, 0, 9);
            storePermissionTLP.Controls.Add(removeFromStoreStorePermissionRadioButton, 0, 10);
            #endregion
            #region StrongNameIdentity
            unrestrictedStrongNameIdentityPermissionRadioButton.Checked = true;
            strongNameIdentityPermissionTLP.Controls.Add(unrestrictedStrongNameIdentityPermissionRadioButton, 0, 0);
            strongNameIdentityPermissionTLP.Controls.Add(noneStrongNameIdentityPermissionRadioButton, 0, 1);
            #endregion
            #region TypeDescriptor
            unrestrictedTypeDescriptorPermissionRadioButton.Checked = true;
            typeDescriptorPermissionTLP.Controls.Add(unrestrictedTypeDescriptorPermissionRadioButton, 0, 0);
            typeDescriptorPermissionTLP.Controls.Add(noneTypeDescriptorPermissionRadioButton, 0, 1);
            typeDescriptorPermissionTLP.Controls.Add(noFlagsTypeDescriptorPermissionRadioButton, 0, 2);
            typeDescriptorPermissionTLP.Controls.Add(restrictedRegistrationAccessTypeDescriptorPermissionRadioButton, 0, 3);
            #endregion
            #region UI
            unrestrictedUIPermissionRadioButton.Checked = true;
            uIPermissionTLP.Controls.Add(unrestrictedUIPermissionRadioButton, 0, 0);
            uIPermissionTLP.Controls.Add(noneUIPermissionRadioButton, 0, 1);
            uIPermissionTLP.Controls.Add(allClipboardUIPermissionClipboardRadioButton, 0, 2);
            uIPermissionTLP.Controls.Add(noClipboardUIPermissionClipboardRadioButton, 0, 3);
            uIPermissionTLP.Controls.Add(ownClipboardUIPermissionClipboardRadioButton, 0, 4);
            uIPermissionTLP.Controls.Add(allWindowsUIPermissionWindowRadioButton, 0, 5);
            uIPermissionTLP.Controls.Add(noWindowsUIPermissionWindowRadioButton, 0, 6);
            uIPermissionTLP.Controls.Add(safeSubWindowsUIPermissionWindowRadioButton, 0, 7);
            uIPermissionTLP.Controls.Add(safeTopLevelWindowsUIPermissionWindowRadioButton, 0, 8);
            #endregion
            #region UrlIdentity
            unrestrictedUrlIdentityPermissionRadioButton.Checked = true;
            urlIdentityPermissionTLP.Controls.Add(unrestrictedUrlIdentityPermissionRadioButton, 0, 0);
            urlIdentityPermissionTLP.Controls.Add(noneUrlIdentityPermissionRadioButton, 0, 1);
            #endregion
            #region WebBrowser
            unrestrictedWebBrowserPermissionRadioButton.Checked = true;
            webBrowserPermissionTLP.Controls.Add(unrestrictedWebBrowserPermissionRadioButton, 0, 0);
            webBrowserPermissionTLP.Controls.Add(noneWebBrowserPermissionRadioButton, 0, 1);
            webBrowserPermissionTLP.Controls.Add(noneWBWebBrowserPermissionRadioButton, 0, 2);
            webBrowserPermissionTLP.Controls.Add(safeWebBrowserPermissionRadioButton, 0, 3);
            webBrowserPermissionTLP.Controls.Add(unrestrictedWBWebBrowserPermissionRadioButton, 0, 4);
            #endregion
            #region WebPermission
            unrestrictedWebPermissionRadioButton.Checked = true;
            webPermissionTLP.Controls.Add(unrestrictedWebPermissionRadioButton, 0, 0);
            webPermissionTLP.Controls.Add(noneWebPermissionRadioButton, 0, 1);
            webPermissionTLP.Controls.Add(acceptWebPermissionRadioButton, 0, 2);
            webPermissionTLP.Controls.Add(connectWebPermissionRadioButton, 0, 3);
            webPermissionTLP.Controls.Add(pathWebPermissionTextBox, 0, 4);
            #endregion
            #region ZoneIdentity
            unrestrictedZoneIdentityPermissionRadioButton.Checked = true;
            zoneIdentityPermissionTLP.Controls.Add(unrestrictedZoneIdentityPermissionRadioButton, 0, 0);
            zoneIdentityPermissionTLP.Controls.Add(noneZoneIdentityPermissionRadioButton, 0, 1);
            zoneIdentityPermissionTLP.Controls.Add(internetZoneIdentityPermissionRadioButton, 0, 2);
            zoneIdentityPermissionTLP.Controls.Add(intranetZoneIdentityPermissionRadioButton, 0, 3);
            zoneIdentityPermissionTLP.Controls.Add(myComputerZoneIdentityPermissionRadioButton, 0, 4);
            zoneIdentityPermissionTLP.Controls.Add(noZoneZoneIdentityPermissionRadioButton, 0, 5);
            zoneIdentityPermissionTLP.Controls.Add(trustedZoneIdentityPermissionRadioButton, 0, 6);
            zoneIdentityPermissionTLP.Controls.Add(untrustedZoneIdentityPermissionRadioButton, 0, 7);
            #endregion
            permissionsListBox.Items.Add("AspNetHostingPermission");
            permissionsListBox.Items.Add("DnsPermission");
            permissionsListBox.Items.Add("EnvironmentPermission");
            permissionsListBox.Items.Add("EventLogPermission");
            permissionsListBox.Items.Add("FileDialogPermission");
            permissionsListBox.Items.Add("FileIOPermission");
            permissionsListBox.Items.Add("GacIdentityPermission");
            permissionsListBox.Items.Add("IsolatedStorageFilePermission");
            permissionsListBox.Items.Add("KeyContainerPermission");
            permissionsListBox.Items.Add("MediaPermission");
            permissionsListBox.Items.Add("NetworkInformationPermission");
            permissionsListBox.Items.Add("PerformanceCounterPermission");
            permissionsListBox.Items.Add("PrincipalPermission");
            permissionsListBox.Items.Add("PublisherIdentityPermission");
            permissionsListBox.Items.Add("ReflectionPermission");
            permissionsListBox.Items.Add("RegistryPermission");
            permissionsListBox.Items.Add("SecurityPermission");
            permissionsListBox.Items.Add("SiteIdentityPermission");
            permissionsListBox.Items.Add("SmtpPermission");
            permissionsListBox.Items.Add("SocketPermission");
            permissionsListBox.Items.Add("StorePermission");
            permissionsListBox.Items.Add("StrongNameIdentityPermission");
            permissionsListBox.Items.Add("TypeDescriptorPermission");
            permissionsListBox.Items.Add("UIPermission");
            permissionsListBox.Items.Add("UrlIdentityPermission");
            permissionsListBox.Items.Add("WebBrowserPermission");
            permissionsListBox.Items.Add("WebPermission");
            permissionsListBox.Items.Add("ZoneIdentityPermission");
        }

        private void ClearArgsButton_Click(object sender, EventArgs e)
        {
            argsTextBox.Text = string.Empty;
        }

        private void PathToAppButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPathFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse exe File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "exe",
                Filter = "exe files (*.exe)|*.exe|All files|*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openPathFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToAppTextBox.Text = openPathFileDialog.FileName;
            }
        }

        private void actionCheckBoxNodeTreeView(TreeNode tn, string action)
        {
            if(action == "select")
            {
                tn.Checked = true;
            }
            if (action == "unselect")
            {
                tn.Checked = false;
            }
            if (action == "invert")
            {
                if(tn.Checked)
                    tn.Checked = false;
                else
                    tn.Checked = true;
            }
            if (tn != null)
            {
                if (tn.Nodes.Count > 0)
                {
                    foreach (TreeNode tnn in tn.Nodes)
                    {
                        actionCheckBoxNodeTreeView(tnn, action);
                    }
                }
                if (action == "remove")
                {
                    if (tn.Checked)
                        tn.Remove();
                }
            }
        }

        private void InvertAllTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach(TreeNode tn in addedPermissionsTreeView.Nodes)
            {
                actionCheckBoxNodeTreeView(tn, "invert");
            }
        }

        private void UnselectAllTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in addedPermissionsTreeView.Nodes)
            {
                actionCheckBoxNodeTreeView(tn, "unselect");
            }
        }

        private void SelectAllTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in addedPermissionsTreeView.Nodes)
            {
                actionCheckBoxNodeTreeView(tn, "select");
            }
        }

        private void SortAllTreeViewButton_Click(object sender, EventArgs e)
        {
            addedPermissionsTreeView.Sort();
        }

        private void RemoveSelectedTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in addedPermissionsTreeView.Nodes)
            {
                actionCheckBoxNodeTreeView(tn, "remove");
            }
        }

        private void ClearAllTreeViewButton_Click(object sender, EventArgs e)
        {
            addedPermissionsTreeView.Nodes.Clear();
        }

        //private void RemovePermissionsButton_Click(object sender, EventArgs e)
        //{
        //    this.Text = string.Format("Width = {0}, Height = {1}", this.Width, this.Height);
        //}

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonAddPermission(string selectedItemListBox, RadioButton rb)
        {
            if (rb.Checked)
            {
                string keyListBox = string.Format("{0}: {1}", selectedItemListBox, rb.Text.ToString());
                if (!addedPermissionsTreeView.Nodes.ContainsKey(selectedItemListBox))
                {
                    addedPermissionsTreeView.Nodes.Add(selectedItemListBox, selectedItemListBox);
                    addedPermissionsTreeView.Nodes[selectedItemListBox].Checked = true;
                }
                if (!addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.ContainsKey(keyListBox))
                {
                    addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.Add(keyListBox, rb.Text.ToString());
                    addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes[keyListBox].Checked = true;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("The {0} has already been added. Add another?", selectedItemListBox), "Add similar permission?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.Add(keyListBox, rb.Text.ToString());
                        addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes[keyListBox].Checked = true;
                    }
                }
            }
        }

        private void radioButtonWithPathAddPermission(string selectedItemListBox, RadioButton rb, TextBox tb)
        {
            if (rb.Checked)
            {
                string keyListBox = string.Format("{0}: {1}", selectedItemListBox, rb.Text.ToString());
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    if (!addedPermissionsTreeView.Nodes.ContainsKey(selectedItemListBox))
                    {
                        addedPermissionsTreeView.Nodes.Add(selectedItemListBox, selectedItemListBox);
                        addedPermissionsTreeView.Nodes[selectedItemListBox].Checked = true;
                    }
                    if (!addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.ContainsKey(keyListBox))
                    {
                            addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.Add(keyListBox, string.Format("{0}; Path: {1}", rb.Text.ToString(), tb.Text));
                            addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes[keyListBox].Checked = true;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(string.Format("The {0} has already been added. Add another?", selectedItemListBox), "Add similar permission?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                                addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes.Add(keyListBox, string.Format("{0}; Path: {1}", rb.Text.ToString(), tb.Text));
                                addedPermissionsTreeView.Nodes[selectedItemListBox].Nodes[keyListBox].Checked = true;
                        }
                    }
                }
                else
                    CreateControls.createMessageBoxError("For this permission the path is required", "Input the path");
            }
        }

        private void AddPermissionsButton_Click(object sender, EventArgs e)
        {
            if (permissionsListBox.SelectedItem != null)
            {
                if (permissionsListBox.SelectedItem.ToString() == "AspNetHostingPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedAspNetHostingRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneAspNetHostingRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), highAspNetHostingRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), lowAspNetHostingRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), mediumAspNetHostingRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), minimalAspNetHostingRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "DnsPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedDnsRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneDnsRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "EventLogPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedEventLogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneEventLogRadioButton);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), administerEventLogRadioButton, pathEventLogTextBox);
                    //radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), auditEventLogRadioButton, pathEventLogTextBox);
                    //radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), browseEventLogRadioButton, pathEventLogTextBox);
                    //radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), instrumentEventLogRadioButton, pathEventLogTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), noneELEventLogRadioButton, pathEventLogTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), writeEventLogRadioButton, pathEventLogTextBox);
                }
                if (permissionsListBox.SelectedItem.ToString() == "NetworkInformationPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedNetworkInformationRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneNetworkInformationRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), readNetworkInformationRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), pingNetworkInformationRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneNetNetworkInformationRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PerformanceCounterPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedPerformanceCounterRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), nonePerformanceCounterRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SmtpPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedSmtpRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneSmtpRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), connectSmtpRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), connectToUnrestrictedPortRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneSMTPSmtpRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SocketPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedSocketRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneSocketRadioButton);
                }

                if (permissionsListBox.SelectedItem.ToString() == "EnvironmentPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedEnvironmentRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneEnvironmentRadioButton);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), allAccessEnvironmentRadioButton, pathEnvironmentTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), noAccessEnvironmentRadioButton, pathEnvironmentTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), readEnvironmentRadioButton, pathEnvironmentTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), writeEnvironmentRadioButton, pathEnvironmentTextBox);
                }
                if (permissionsListBox.SelectedItem.ToString() == "FileDialogPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedFileDialogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneFileDialogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneAccessFileDialogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), openFileDialogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), saveFileDialogRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), openSaveFileDialogRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "FileIOPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedFileIORadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneFileIORadioButton);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), allAccessFileIORadioButton, pathFileIOTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), appendFileIORadioButton, pathFileIOTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), noAccessFileIORadioButton, pathFileIOTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), pathDiscoveryFileIORadioButton, pathFileIOTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), readFileIORadioButton, pathFileIOTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), writeFileIORadioButton, pathFileIOTextBox);
                }
                if (permissionsListBox.SelectedItem.ToString() == "GacIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedGacIdentityRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneGacIdentityRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "IsolatedStorageFilePermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedIsolatedStorageFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneIsolatedStorageFileRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "KeyContainerPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allFlagsKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), changeAclKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), createKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), decryptKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), deleteKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), exportKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), importKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noFlagsKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), openKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), signKeyContainerFileRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), viewAclKeyContainerFileRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "MediaPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allAudioMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noAudioMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeAudioMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeOfOriginAudioMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allVideoMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noVideoMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeVideoMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeOfOriginVideoMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allImageMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noImageMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeImageMediaPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeOfOriginImageMediaPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PrincipalPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedPrincipalPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), nonePrincipalPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PublisherIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedPublisherIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), nonePublisherIdentityPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "ReflectionPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedReflectionPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneReflectionPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "RegistryPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedRegistryPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneRegistryPermissionRadioButton);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), allAccessRegistryPermissionRadioButton, pathRegistryPermissionTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), createRegistryPermissionRadioButton, pathRegistryPermissionTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), noAccessRegistryPermissionRadioButton, pathRegistryPermissionTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), readRegistryPermissionRadioButton, pathRegistryPermissionTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), writeRegistryPermissionRadioButton, pathRegistryPermissionTextBox);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SecurityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allFlagsSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), assertionSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), bindingRedirectsSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlAppDomainSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlDomainPolicySecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlEvidenceSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlPolicySecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlPrincipalSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), controlThreadSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), executionSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), infrastructureSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noFlagsSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), remotingConfigurationSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), serializationFormatterSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), skipVerificationSecurityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unmanagedCodeSecurityPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SiteIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedSiteIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneSiteIdentityPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "StorePermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), addToStoreStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allFlagsStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), createStoreStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), deleteStoreStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), enumerateCertificatesStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), enumerateStoresStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noFlagsStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), openStoreStorePermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), removeFromStoreStorePermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "StrongNameIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedStrongNameIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneStrongNameIdentityPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "TypeDescriptorPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedTypeDescriptorPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneTypeDescriptorPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noFlagsTypeDescriptorPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), restrictedRegistrationAccessTypeDescriptorPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "UIPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedUIPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneUIPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allClipboardUIPermissionClipboardRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noClipboardUIPermissionClipboardRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), ownClipboardUIPermissionClipboardRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), allWindowsUIPermissionWindowRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noWindowsUIPermissionWindowRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeSubWindowsUIPermissionWindowRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeTopLevelWindowsUIPermissionWindowRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "UrlIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedUrlIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneUrlIdentityPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "WebBrowserPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedWebBrowserPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneWebBrowserPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneWBWebBrowserPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), safeWebBrowserPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedWBWebBrowserPermissionRadioButton);
                }
                if (permissionsListBox.SelectedItem.ToString() == "WebPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedWebPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneWebPermissionRadioButton);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), acceptWebPermissionRadioButton, pathWebPermissionTextBox);
                    radioButtonWithPathAddPermission(permissionsListBox.SelectedItem.ToString(), connectWebPermissionRadioButton, pathWebPermissionTextBox);
                }
                if (permissionsListBox.SelectedItem.ToString() == "ZoneIdentityPermission")
                {
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), unrestrictedZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noneZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), internetZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), intranetZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), myComputerZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), noZoneZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), trustedZoneIdentityPermissionRadioButton);
                    radioButtonAddPermission(permissionsListBox.SelectedItem.ToString(), untrustedZoneIdentityPermissionRadioButton);
                }
            }
        }

        private void PermissionsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            tableLayoutPanel7.Controls.Clear();
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8,0,1);
            if (permissionsListBox.SelectedItem != null)
            {
                if (permissionsListBox.SelectedItem.ToString() == "AspNetHostingPermission")
                {
                    tableLayoutPanel7.Controls.Add(aspNetHostingTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "DnsPermission")
                {
                    tableLayoutPanel7.Controls.Add(dnsTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "EventLogPermission")
                {
                    tableLayoutPanel7.Controls.Add(eventLogTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "NetworkInformationPermission")
                {
                    tableLayoutPanel7.Controls.Add(networkInformationTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PerformanceCounterPermission")
                {
                    tableLayoutPanel7.Controls.Add(performanceCounterTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SmtpPermission")
                {
                    tableLayoutPanel7.Controls.Add(smtpTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SocketPermission")
                {
                    tableLayoutPanel7.Controls.Add(socketTLP, 0, 0);
                }

                if (permissionsListBox.SelectedItem.ToString() == "EnvironmentPermission")
                {
                    tableLayoutPanel7.Controls.Add(environmentTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "FileDialogPermission")
                {
                    tableLayoutPanel7.Controls.Add(fileDialogTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "FileIOPermission")
                {
                    tableLayoutPanel7.Controls.Add(fileIOTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "GacIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(gacIdentityTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "IsolatedStorageFilePermission")
                {
                    tableLayoutPanel7.Controls.Add(isolatedStorageFileTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "KeyContainerPermission")
                {
                    tableLayoutPanel7.Controls.Add(keyContainerFileTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "MediaPermission")
                {
                    tableLayoutPanel7.Controls.Add(mediaPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PrincipalPermission")
                {
                    tableLayoutPanel7.Controls.Add(principalPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "PublisherIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(publisherIdentityPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "ReflectionPermission")
                {
                    tableLayoutPanel7.Controls.Add(reflectionPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "RegistryPermission")
                {
                    tableLayoutPanel7.Controls.Add(registryPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SecurityPermission")
                {
                    tableLayoutPanel7.Controls.Add(securityPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "SiteIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(siteIdentityPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "StorePermission")
                {
                    tableLayoutPanel7.Controls.Add(storePermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "StrongNameIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(strongNameIdentityPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "TypeDescriptorPermission")
                {
                    tableLayoutPanel7.Controls.Add(typeDescriptorPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "UIPermission")
                {
                    tableLayoutPanel7.Controls.Add(uIPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "UrlIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(urlIdentityPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "WebBrowserPermission")
                {
                    tableLayoutPanel7.Controls.Add(webBrowserPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "WebPermission")
                {
                    tableLayoutPanel7.Controls.Add(webPermissionTLP, 0, 0);
                }
                if (permissionsListBox.SelectedItem.ToString() == "ZoneIdentityPermission")
                {
                    tableLayoutPanel7.Controls.Add(zoneIdentityPermissionTLP, 0, 0);
                }
            }
        }

        private void LaunchAppButton_Click(object sender, EventArgs e)
        {
            PermissionSet permission = new PermissionSet(PermissionState.None);
            if (addedPermissionsTreeView.Nodes.Count > 0)
            {
                foreach (TreeNode tn in addedPermissionsTreeView.Nodes)
                {
                    switch (tn.Text)
                    {
                        case "AspNetHostingPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["AspNetHostingPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddAspNetHostingPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "DnsPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["DnsPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddDnsPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "EventLogPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["EventLogPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddEventLogPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "NetworkInformationPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["NetworkInformationPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddNetworkInformationPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "PerformanceCounterPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["PerformanceCounterPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddPerformanceCounterPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "SmtpPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["SmtpPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddSmtpPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "SocketPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["SocketPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddSocketPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }

                        case "EnvironmentPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["EnvironmentPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddEnvironmentPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "FileDialogPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["FileDialogPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddFileDialogPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "FileIOPermission":
                            {
                                FileIOPermission fIOP = new FileIOPermission(PermissionState.None);
                                bool unrestricedOrNone = false;
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["FileIOPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        if (tnn.Text == "Unrestricted")
                                        {
                                            unrestricedOrNone = true;
                                            permission.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
                                            break;
                                        }
                                        if (tnn.Text == "None")
                                        {
                                            unrestricedOrNone = true;
                                            permission.AddPermission(new FileIOPermission(PermissionState.None));
                                            break;
                                        }
                                        PermissionsClass.AddFileIOPermission(ref fIOP, tnn.Text);
                                    }
                                }
                                if(!unrestricedOrNone)
                                    permission.SetPermission(fIOP);
                                break;
                            }
                        case "GacIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["GacIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddGacIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "IsolatedStorageFilePermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["IsolatedStorageFilePermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddIsolatedStorageFilePermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "KeyContainerPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["KeyContainerPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddKeyContainerPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "MediaPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["MediaPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddMediaPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "PrincipalPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["PrincipalPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddPrincipalPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "PublisherIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["PublisherIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddPublisherIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "ReflectionPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["ReflectionPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddReflectionPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "RegistryPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["RegistryPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddRegistryPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "SecurityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["SecurityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddSecurityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "SiteIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["SiteIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddSiteIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "StorePermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["StorePermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddStorePermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "StrongNameIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["StrongNameIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddStrongNameIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "TypeDescriptorPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["TypeDescriptorPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddTypeDescriptorPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "UIPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["UIPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddUIPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "UrlIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["UrlIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddUrlIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "WebBrowserPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["WebBrowserPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddWebBrowserPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "WebPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["WebPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddWebPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                        case "ZoneIdentityPermission":
                            {
                                foreach (TreeNode tnn in addedPermissionsTreeView.Nodes["ZoneIdentityPermission"].Nodes)
                                {
                                    if (tnn.Checked)
                                    {
                                        PermissionsClass.AddZoneIdentityPermission(ref permission, tnn.Text);
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            var setUp = new AppDomainSetup();
            setUp.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            AppDomain customDomain = AppDomain.CreateDomain("Sandbox", null, setUp, permission);
            outputTextBox.Text = string.Empty;
            StringBuilder outputString = new StringBuilder();
            try
            {
                String myApplication = pathToAppTextBox.Text;
                if (File.Exists(myApplication))
                {
                    string[] args = argsTextBox.Text.Split(' ');
                    customDomain.ExecuteAssembly(myApplication, args);
                    Process process = new Process();
                    process.StartInfo.FileName = myApplication;
                    process.StartInfo.Arguments = argsTextBox.Text;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.ErrorDataReceived += (s, ev) => { ThreadHelperClass.WriteText(this, outputTextBox, ev.Data); };
                    process.Start();
                    process.BeginErrorReadLine();
                    string output = process.StandardOutput.ReadToEnd();
                    ThreadHelperClass.WriteText(this, outputTextBox, output);
                    process.WaitForExit(2000);
                }
                else
                {
                    CreateControls.createMessageBoxError("File Does Not Exist","Incorrect Path");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "Execution permission cannot be acquired.")
                    {
                        outputString.AppendFormat("Add: SecurityPermission -> Execution");
                        outputString.AppendLine();
                    }
                    outputString.AppendFormat("InnerException: {0}", ex.InnerException.Message);
                    outputString.AppendLine();
                    outputString.AppendFormat("Message: {0}", ex.Message);
                    outputTextBox.Text = outputString.ToString();
                }
                else
                {
                    string className = PermissionsClass.ExceptionPermissionName(ex.Message);
                    if (className != string.Empty)
                    {
                        outputString.AppendFormat("Add: {0} -> Unrestricted", className);
                        outputString.AppendLine();
                    }
                    outputString.AppendFormat("Message: {0}", ex.Message);
                    outputTextBox.Text = outputString.ToString();
                }
                AppDomain.Unload(customDomain);
            }
        }
    }
}