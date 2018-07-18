using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Windows.Forms;
using NetFwTypeLib;
using System.Runtime.InteropServices;
using System.Reflection;


namespace SAEView
{
    class AbrirPuerto 
    {
        const int NET_FW_IP_PROTOCOL_UDP = 17;
            const int NET_FW_IP_PROTOCOL_TCP = 6;
       
           //'Action
            const int NET_FW_ACTION_ALLOW = 1;
                


            const int NET_FW_SCOPE_ALL = 0;
            const int NET_FW_SCOPE_LOCAL_SUBNET = 1;
        //' IP Version <entity type="ndash"/> ANY is the only allowable setting for now
            const int NET_FW_IP_VERSION_ANY = 2;


        public AbrirPuerto()
        {

        }

        public void AgregarExcepcionAFireWall()
        {
            try
            {
               // INetFwMgr icfMgr = null;
                INetFwPolicy2 icfMgr = null;
                Type TicfMgr = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                
                icfMgr = (INetFwPolicy2)Activator.CreateInstance(TicfMgr);

               // INetFwProfile profile;
                INetFwOpenPort portClass;
                Type TportClass = Type.GetTypeFromProgID("HNetCfg.FWOpenPort");
                
                portClass = (INetFwOpenPort)Activator.CreateInstance(TportClass);
                // Get the current profile
                INetFwRules rulesObject = icfMgr.Rules;
                int currentProfiles = icfMgr.CurrentProfileTypes;

                Type Trule = Type.GetTypeFromProgID("HNetCfg.FWRule");
                INetFwRule NewRule = (INetFwRule) Activator.CreateInstance(Trule);

                NewRule.Name = "TestRule";
                NewRule.Description = "Allow incoming network traffic over port 2400 coming from LAN interfcace type";
                NewRule.Protocol = NET_FW_IP_PROTOCOL_TCP;
                NewRule.LocalPorts = "8000";
                NewRule.InterfaceTypes = "LAN";
                NewRule.Enabled = true;
                NewRule.Grouping = "@firewallapi.dll,-11255";
                NewRule.Profiles = currentProfiles;
               // NewRule.Action = NET_FW_ACTION_ALLOW;   

             //  NewRule.Protocol = int.Parse(
              //  NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP.ToString());
                
                rulesObject.Add(NewRule);
                
                // Add the port to the ICF Permissions List
                //profile.GloballyOpenPorts.Add(portClass);



               /*  // Create the firewall type.
                Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");

                // Use the firewall type to create a firewall manager object.
                dynamic FWManager = Activator.CreateInstance(FWManagerType);

              //  ' Get the Rules object
                    
                    var RulesObject = FWManager.Rules;

                    var currentProfiles = FWManager.CurrentProfileTypes;

                   // 'Create a Rule Object.
                    Type ruleType = Type.GetTypeFromProgID("HNetCfg.FWRule");
                    dynamic NewRule = Activator.CreateInstance(ruleType);
    
                    NewRule.Name = "AspelView";
                    NewRule.Description = "Allow incoming network traffic over port 8000 coming from LAN interfcace type";
                    NewRule.Protocol = NET_FW_IP_PROTOCOL_TCP;
                    NewRule.LocalPorts = 8000;
                    NewRule.Interfacetypes = "LAN";
                    NewRule.Enabled = true;
                    NewRule.Grouping = "@firewallapi.dll,-23255";
                    NewRule.Profiles = currentProfiles;
                    NewRule.Action = NET_FW_ACTION_ALLOW;

                    Console.WriteLine("regla");
                    //'Add a new rule
                    RulesObject.Add(NewRule);
                    Console.WriteLine("regl2");

                /*



                       
                // Get the current profile for the local firewall policy.
            
                var profile = FWManager.LocalPolicy.CurrentProfile;

            
                Type port = Type.GetTypeFromProgID("HNetCfg.FWOpenPort",false);
            
                dynamic portManager = Activator.CreateInstance(port);
            
                portManager.Name = "SAEView";
               // portManager.Protocol = NET_FW_IP_PROTOCOL_TCP;
                portManager.Port = 8000;

                //'If using Scope, don't use RemoteAddresses
                //port.Scope = NET_FW_SCOPE_ALL;
               // 'Use this line to scope the port to Local Subnet only
               // portManager.Scope = NET_FW_SCOPE_LOCAL_SUBNET;

                portManager.Enabled = true;
           
                //On Error Resume Next
                profile.GloballyOpenPorts.Add(portManager);
                Console.WriteLine("port");

                Type appType = Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication",false);
                dynamic app = Activator.CreateInstance(appType);

                app.ProcessImageFileName = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\StartUp\\SAEView.exe";
                app.Name = "SAEView";
                app.Scope = NET_FW_SCOPE_ALL;
               // ' Use either Scope or RemoteAddresses, but not both;
                //'app.RemoteAddresses = "*"
                app.IpVersion = NET_FW_IP_VERSION_ANY;
                app.Enabled = true;

                profile.AuthorizedApplications.Add(app);
                Console.WriteLine("App");                       */

            }catch(Exception e){
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
           
            


        }

        }
}
