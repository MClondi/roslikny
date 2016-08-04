using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roslinky
{
    public partial class GroupControl : UserControl
    {
        public GroupControl(String title, List<String> items, MainWindow parent)
        {
            InitializeComponent();
            this.Width = 240;
            var tb = new Label();
            tb.Text = title;
            this.Controls.Add(tb);
            
            foreach(var item in items)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                checkBox.Location = new Point(0, this.Height);
                checkBox.CheckedChanged += (sender, e) => {
                    parent.checkedType(checkBox.Text, checkBox.Checked);
                };
                this.Height += checkBox.Size.Height;
                this.Controls.Add(checkBox);
            }
        }
    }
}
