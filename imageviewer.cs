using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dashboard
{
    public partial class imageviewer : Form
    {
        System.Windows.Forms.ImageList myimagelist = new ImageList();
        System.Windows.Forms.ImageList myimagelistSmall = new ImageList();
        System.Windows.Forms.ImageList myimagelistLarge = new ImageList();
        int count = 0;
        OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png" };
        FileInfo fi;


        public imageviewer()
        {
            InitializeComponent();
            listView1.SmallImageList = myimagelistSmall;
            listView1.SmallImageList = myimagelistLarge;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            myimagelist.ImageSize = new Size(50, 50);
            myimagelistSmall.ImageSize = new Size(32, 32);
            myimagelistLarge.ImageSize = new Size(80, 80);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                foreach (string filename in ofd.FileNames)
                {
                    fi = new FileInfo(filename);
                    FileInfo fileinfo = new FileInfo(filename);
                    using (FileStream stream = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
                    {
                        myimagelist.Images.Add(Image.FromStream(stream));
                        myimagelistSmall.Images.Add(Image.FromStream(stream));
                        myimagelistLarge.Images.Add(Image.FromStream(stream));
                    }
                    listView1.LargeImageList = myimagelist;
                    listView1.Items.Add(new ListViewItem { ImageIndex = count, Text = fi.Name, Tag = fi.FullName });
                    count++;
                }
            }
        }

        private void radiobtnlarge_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnlarge.Checked == true)
            {
                listView1.LargeImageList = myimagelistLarge;
                listView1.View = View.LargeIcon;
            }
        }

        private void radiobtnSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnSmall.Checked == true)
            {
                listView1.View = View.SmallIcon;
            }
        }

        private void radioButtonList_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonList.Checked == true)
            {
                listView1.View = View.List;
            }
        }

        private void radioButtonTile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTile.Checked == true)
            {
                listView1.View = View.Tile;
            }
        }

    }
}
