using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK;

namespace PluginWin
{
    public partial class Form1 : Form
    {
        private List<Plug> myList = null;
        public Form1()
        {
            InitializeComponent();
            myList = Kit.GetAllPlugins(Application.StartupPath + "//plugins");
            foreach (var plug in myList)
            {
                Button button = new Button();
                button.Text = plug.pName;
                button.Click += b_Click;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            foreach (var p in myList)
            {
                if (p.pName==(sender as Button).Text)
                {
                    run(p);
                }
            }
        }

        private void run(Plug p)
        {
            IPlugin obj = (IPlugin) Kit.CreateObject(p);
            textBox1.Text = obj.Action(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
