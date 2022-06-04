using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System
{
    public partial class list_tile : UserControl
    {
        #region Constructors
        // Empty constructor
        public list_tile()
        {
            InitializeComponent();
            _name = "Title";
            _clinc_name = "Sub Title";
            _icon = Properties.Resources.unknown_user;
        }
        // paramitrized constructor
        public list_tile(string name, string clinc_name, Image icon)
        {
            InitializeComponent();
            Title = name;
            SubTitle = clinc_name;
            Icon = icon;
        }
        #endregion

        #region Getter and setter
        private Image _icon;
        private string _name;
        private string _clinc_name;

        [Category("Custom Probs")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox.Image = value; }
        }
        [Category("Custom Probs")]
        public string Title
        {
            get { return _name; }
            set { _name = value; label1.Text = value; }
        }
        [Category("Custom Probs")]
        public string SubTitle
        {
            get { return _clinc_name; }
            set { _clinc_name = value; label2.Text = value; }
        }

        #endregion

        #region Hover Effect
        private void list_tile_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
            // TODO: change summary
        }

        private void list_tile_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

        #region components
        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void list_tile_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
