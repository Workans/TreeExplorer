using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach(var drive in drives)
            {
                TreeNode node = new TreeNode(drive.Name, 0,1);
                node.Tag = drive.Name;
                treeView1.Nodes.Add(node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectNode = treeView1.SelectedNode.Tag as string;
            foreach(var folder in Directory.GetDirectories(selectNode))
            {
                TreeNode node = new TreeNode(Path.GetFileName(folder), 0, 1);
                node.Tag = folder;
                e.Node.Nodes.Add(node);
            }
            foreach (var file in Directory.GetFiles(selectNode))
            {
                TreeNode node = new TreeNode(Path.GetFileName(file), 2, 2);
                node.Tag = file;
                e.Node.Nodes.Add(node);
            }
        }
    }
}
