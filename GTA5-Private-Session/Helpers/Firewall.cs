using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTA5_Private_Session.Helpers
{
    public static class Firewall
    {
        static string firewallRuleName = "// GTA 5 Private //";
        static INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

        public static bool isRuleExist()
        {
            try
            {
                var fwItem = firewallPolicy.Rules.Item(firewallRuleName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void BlockPort(string port)
        {
            try
            {
                INetFwRule fwIn = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

                fwIn.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                fwIn.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

                fwIn.Name = firewallRuleName;
                fwIn.Description = "Use to block ports";

                fwIn.Enabled = true;
                fwIn.InterfaceTypes = "All";

                fwIn.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                fwIn.LocalPorts = port;

                INetFwRule fwOut = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

                fwOut.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                fwOut.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

                fwOut.Name = firewallRuleName;
                fwOut.Description = "Use to block ports";

                fwOut.Enabled = true;
                fwOut.InterfaceTypes = "All";

                fwOut.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                fwOut.LocalPorts = port;

                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(fwIn);
                firewallPolicy.Rules.Add(fwOut);
            }
            catch (Exception ex) { }
        }

        public static void AllowPort()
        {
            while (isRuleExist())
            {
                firewallPolicy.Rules.Remove(firewallRuleName);
            }
        }
    }
}
