﻿using Microsoft.SharePoint.Client;
using System;
using System.Collections;
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
                            where list.ItemCount > 3
                            select list;
                var lists = context.LoadQuery(query);
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
                context.Load(lists, l => l.Include(p => p.Title));
                context.ExecuteQuery();
                listBox1.Items.Clear();
                listBox1.Items.Add(context.Web.Title);
                foreach (var item in lists)
                {
                    listBox1.Items.Add(item.Title);
                }

            }

        }

        private void nestedIncludesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                var lists = context.Web.Lists;
                context.Load(context.Web, w => w.Title);
                context.Load(lists, ls => ls.Include(l => l.Title, l => l.Fields.Include(f => f.Title).Take(5)));
                context.ExecuteQuery();
                listBox1.Items.Clear();
                listBox1.Items.Add(context.Web.Title);
                foreach (var item in lists)
                {
                    listBox1.Items.Add(item.Title);
                    foreach (var f in item.Fields)
                    {
                        listBox1.Items.Add("\t" + f.Title);
                    }
                }

            }
        }

        private void cAMLQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                var web = context.Web;
                var list = web.Lists.GetByTitle("Categories");


                var query = new CamlQuery();
                query.ViewXml = "<View/>";
                var items = list.GetItems(query);
                context.Load(list, l => l.Title);
                context.Load(items, i => i.Include(li => li["Title"], li => li["ID"], li => li["Description"]));
                context.ExecuteQuery();

                listBox1.Items.Clear();
                listBox1.Items.Add(list.Title);
                foreach (var item in items)
                {
                    listBox1.Items.Add("\t(" + item["Description"] + ")" + item["Title"]);

                }

            }
        }

        private void dataBindingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                var web = context.Web;
                var list = web.Lists.GetByTitle("Products");


                var query = new CamlQuery();
                query.ViewXml = "<View><RowLimit>10</RowLimit></View>";
                var items = list.GetItems(query);
                context.Load(list, l => l.Title);
                context.Load(items, i => i.Include(li => li["Title"], li => li["ID"], li => li["UnitsInStock"]));
                context.ExecuteQuery();

                var dataList = new List<DictionaryEntry>();
                foreach (var item in items)
                {
                    dataList.Add(new DictionaryEntry { Key = item["ID"], Value = item["Title"] });
                }
                listBox1.DataSource = dataList;
                listBox1.DisplayMember = "Value";
                listBox1.ValueMember = "Key";
            }
        }

        private void addAListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var web = context.Web;
                    web.Lists.Add(new ListCreationInformation { Title = "My Announcements", TemplateType = (int)ListTemplateType.Announcements, QuickLaunchOption = QuickLaunchOptions.On });
                    context.ExecuteQuery();
                    listBox1.Items.Clear();
                    listBox1.Items.Add("List successfully created");
                }
                catch (Exception xcp)
                {
                    MessageBox.Show(xcp.Message);
                }
            }
        }

        private void batchExceptionHandlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {

                var web = context.Web;
                List list = null;
                var scope = new ExceptionHandlingScope(context);
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        list = web.Lists.GetByTitle("My Announcements");
                        context.Load(list);
                    }
                    using (scope.StartCatch())
                    {
                        list = web.Lists.Add(new ListCreationInformation { Title = "My Announcements", TemplateType = (int)ListTemplateType.Announcements, QuickLaunchOption = QuickLaunchOptions.On });
                    }
                    using (scope.StartFinally())
                    {
                        //list = web.Lists.GetByTitle("My Announcements");
                        //context.Load(list);
                    }
                    
                }
                context.ExecuteQuery();
                var status = scope.HasException ? "List successfully created" : "List loaded";
                listBox1.Items.Clear();
                listBox1.Items.Add(status);
            }
        }
    }
}
