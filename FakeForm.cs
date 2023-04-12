using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZaverecnaPraceBaseDLL
{
    public partial class FakeForm : Form, IMainForm
    {
        public FakeForm()
        {
            InitializeComponent();
        }

        public void SendData(char c)
        {
            MessageBox.Show("Poslal se charakter " + c);
        }
    }
}
