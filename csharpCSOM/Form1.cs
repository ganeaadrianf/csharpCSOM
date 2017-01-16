using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpCSOM
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://apps.shpdev.com"))
            {
                var lists = context.Web.Lists;
                context.Load(lists);
                context.ExecuteQuery();
                listBox1.Items.Clear();
                foreach (var item in lists)
                {
                    listBox1.Items.Add(item.Title);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://apps.shpdev.com"))
            {
                var query = from list in context.Web.Lists
                            where list.ItemCount>3
                            select list;
                var lists=context.LoadQuery(query);
                context.ExecuteQuery();
                listBox1.Items.Clear();
                foreach (var item in lists)
                {
                    listBox1.Items.Add(item.Title);
                }

            }

        }

        private void btnSelectFields_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                var lists = context.Web.Lists;
                context.Load(context.Web, w => w.Title);
                context.Load(lists,l=>l.Include(p=>p.Title));
                context.ExecuteQuery();
                listBox1.Items.Clear();
                listBox1.Items.Add(context.Web.Title);
                foreach (var item in lists)
                {
                    listBox1.Items.Add(item.Title);
                }

            }

        }
    }
}
