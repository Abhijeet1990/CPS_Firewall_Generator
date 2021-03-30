using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirewallGenerator
{
    public class Interface
    {
        public string interfaceName;
        public string ipAddress;
        public string subnetMask;
        public Interface()
        {

        }
    }

    public class PortObject
    {
        public string portNumber;
        public int portCount;
        public PortObject()
        {

        }
    }
    public class NetworkObject
    {
        public string type;
        public string ipAddress;
        public string subnetAddress;

        public NetworkObject()
        {

        }
    }

    public class ObjectGroup
    {
        public string objectName;
        public string objectType;
        public List<PortObject> portObjects;
        public List<NetworkObject> networkObjects;

        public ObjectGroup()
        {

        }
    }

    public class AccessGroup
    {
        public string groupName;
        public string interfaceName;
        List<AccessControl> acls;

        public AccessGroup()
        {

        }
    }
    public class AccessControl
    {
        public string permit;
        public string accessGroup;
        public string protocol;
        public List<string> objectGroups;

        public AccessControl()
        {

        }
    }
    public class FirewallConfig
    {
        public string label;
        public List<Interface> interfaces;
        public List<ObjectGroup> objectGroups;
        public List<AccessControl> acls;
        public FirewallConfig()
        {

        }
        public string createFirewall(FirewallConfig fw)
        {
            string config = "";
            return config;
        }

    }



}
