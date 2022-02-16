using GTA5_Private_Session.Helpers;
using NetFwTypeLib;
using System.Diagnostics;
using System.Net;
using System.Timers;
using Timer = System.Timers.Timer;

namespace GTA5_Private_Session
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Block()
        {
            List<string> ports = new List<string>() { "6672" };

            if (Firewall.isRuleExist())
            {
                Allow();
            }

            foreach (string port in ports)
            {
                Firewall.BlockPort(port);
            }
        }

        private void Allow()
        {
            Firewall.AllowPort();
        }

        private void Toggle()
        {
            if (Firewall.isRuleExist())
            {
                Allow();
                btnToggle.Text = "Off";
                btnToggle.BackColor = Color.Salmon;
            } else
            {
                Block();
                btnToggle.Text = "On";
                btnToggle.BackColor = Color.Green;
            }
        }

        // =============================================================================================

        private void btnToggle_Click(object sender, EventArgs e)
        {
            Toggle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Firewall.isRuleExist())
            {
                btnToggle.Text = "On";
                btnToggle.BackColor = Color.Green;
            };
        }
    }
}