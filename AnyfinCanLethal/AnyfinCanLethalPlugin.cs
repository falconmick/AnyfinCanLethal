using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyfinCanLethal
{
    public class AnyfinCanLethalPlugin : IPlugin
    {
        private static IAnyfinComboMonitor _anyfinComboMonitor;

        public AnyfinCanLethalPlugin()
        {
            _anyfinComboMonitor = new AnyfinComboMonitor();
        }

        public string Author
        {
            get
            {
                return "Michael Crook";
            }
        }

        public string ButtonText
        {
            get
            {
                return "Anyfin Can Lethal";
            }
        }

        public string Description
        {
            get
            {
                return "Calculates the minimum and maximum damage of your Anyfin Can Happen combo. Other cool features as such as % chance at lethal are also planned.";
            }
        }

        public MenuItem MenuItem
        {
            get
            {
                return null;
            }
        }

        public string Name
        {
            get
            {
                return "Anyfin Can Lethal";
            }
        }

        public Version Version
        {
            get
            {
                return new Version(0, 0, 0);
            }
        }

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _anyfinComboMonitor.OnLoad();
        }

        public void OnUnload()
        {
            
        }

        public void OnUpdate()
        {
            _anyfinComboMonitor.OnUpdate();
        }
    }
}
