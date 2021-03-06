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
using System.IO;
using Microsoft.SharePoint.Client.Taxonomy;
using Microsoft.SharePoint.Client.UserProfiles;

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
                        list = web.Lists.GetByTitle("Tasks");
                        context.Load(list);
                    }
                    using (scope.StartCatch())
                    {
                        list = web.Lists.Add(new ListCreationInformation { Title = "Tasks", TemplateType = (int)ListTemplateType.Tasks, QuickLaunchOption = QuickLaunchOptions.On });
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

        private void addEditListItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var web = context.Web;
                    var rand = new Random();
                    var list = web.Lists.GetByTitle("Tasks");
                    var item = new ListItemCreationInformation();
                    var addedItem = list.AddItem(item);
                    addedItem["Title"] = "Item " + rand.Next(1, 1000);
                    addedItem["DueDate"] = DateTime.Now.AddDays(7);
                    addedItem["PercentComplete"] = 0;
                    addedItem["AssignedTo"] = context.Web.CurrentUser;
                    addedItem.Update();
                    context.ExecuteQuery();
                    listBox1.Items.Add("Item added");
                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add("Operation failed:" + xcp.Message);
                }

            }
        }

        private void updateListItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var web = context.Web;
                    var rand = new Random();
                    var list = web.Lists.GetByTitle("Tasks");

                    var firstItems = list.GetItems(new CamlQuery { ViewXml = "<View><RowLimit>1</RowLimit></View>" });
                    context.Load(firstItems);
                    context.ExecuteQuery();
                    var firstItem = firstItems.First();
                    firstItem["PercentComplete"] = rand.Next(1, 100);
                    firstItem.Update();
                    context.ExecuteQuery();
                    listBox1.Items.Add("Item updated");
                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add("Operation failed:" + xcp.Message);
                }

            }
        }

        private void addALibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var conetxt = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var web = conetxt.Web;
                    var lci = new ListCreationInformation() { Title = "Project Documents", QuickLaunchOption = QuickLaunchOptions.On, TemplateType = (int)ListTemplateType.DocumentLibrary };
                    var lib = web.Lists.Add(lci);
                    lib.Fields.AddFieldAsXml("<Field Type=\"Number\" DisplayName=\"Year\" Min=\"2000\" Max=\"2100\" Decimals=\"0\" StaticName=\"Year\" Name=\"Year\" />", true, AddFieldOptions.DefaultValue);
                    lib.Fields.AddFieldAsXml("<Field Type=\"User\" DisplayName=\"Coordinator\" List=\"UserInfo\" ShowField=\"ImnName\" UserSelectionMode=\"PeopleOnly\" UserSelectionScope=\"0\" StaticName=\"Coordinator\" Name=\"Coordinator\" />", true, AddFieldOptions.DefaultValue);

                    conetxt.Load(web.Lists);
                    conetxt.ExecuteQuery();
                    listBox1.Items.Add("Document librarry created");
                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add("Operation failed:" + xcp.Message);
                }


            }
        }



        private void addSampleDocumentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var list = context.Web.Lists.GetByTitle("Project Documents");
                    var fci = new FileCreationInformation();
                    fci.Content = System.IO.File.ReadAllBytes(@"C:\Downloads\Sample.docx");
                    fci.Url = "Sample upload.docx";
                    var file = list.RootFolder.Files.Add(fci);
                    var item = file.ListItemAllFields;
                    item["Year"] = System.DateTime.Now.Year;
                    item["Coordinator"] = context.Web.CurrentUser;
                    item.Update();
                    listBox1.Items.Add("File uploaded successfuly");
                    context.ExecuteQuery();
                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add(xcp.Message);

                }

            }
        }

        private void createTermsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {

                    var lcid = Application.CurrentCulture.LCID;
                    var session = TaxonomySession.GetTaxonomySession(context);
                    var store = session.TermStores.GetByName("Managed Metadata Service");
                    var group = store.CreateGroup("C#", Guid.NewGuid());
                    var termSet = group.CreateTermSet("Projects", Guid.NewGuid(), lcid);
                    termSet.CreateTerm("Lists", lcid, Guid.NewGuid());
                    termSet.CreateTerm("Libraries", lcid, Guid.NewGuid());
                    termSet.CreateTerm("MMS", lcid, Guid.NewGuid());
                    context.ExecuteQuery();
                    listBox1.Items.Add("TermSet added!");

                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add(xcp.Message);

                }

            }
        }

        private void createLibWithTaxFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var conetxt = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var web = conetxt.Web;
                    var lci = new ListCreationInformation() { Title = "Project Documents Taxonomy", QuickLaunchOption = QuickLaunchOptions.On, TemplateType = (int)ListTemplateType.DocumentLibrary };
                    var lib = web.Lists.Add(lci);
                    lib.Fields.AddFieldAsXml("<Field Type=\"Number\" DisplayName=\"Year\" Min=\"2000\" Max=\"2100\" Decimals=\"0\" StaticName=\"Year\" Name=\"Year\" />", true, AddFieldOptions.DefaultValue);
                    lib.Fields.AddFieldAsXml("<Field Type=\"User\" DisplayName=\"Coordinator\" List=\"UserInfo\" ShowField=\"ImnName\" UserSelectionMode=\"PeopleOnly\" UserSelectionScope=\"0\" StaticName=\"Coordinator\" Name=\"Coordinator\" />", true, AddFieldOptions.DefaultValue);
                    var taxField=lib.Fields.AddFieldAsXml("<Field Type=\"TaxonomyFieldType\" DisplayName=\"Project\"  ShowField=\"Term1033\" Version=\"1\" Name=\"Project\" />", true, AddFieldOptions.DefaultValue);

                    var session = TaxonomySession.GetTaxonomySession(conetxt);
                    var termStore = session.TermStores.GetByName("Managed Metadata Service");
                    var group = termStore.Groups.GetByName("C#");
                    var termSet = group.TermSets.GetByName("Projects");

                    conetxt.Load(taxField);
                    conetxt.Load(termStore,ts=>ts.Id);
                    conetxt.Load(termSet, s => s.Id);
                    conetxt.ExecuteQuery();

                    var taxField2 = conetxt.CastTo<TaxonomyField>(taxField);
                    taxField2.SspId = termStore.Id;
                    taxField2.TermSetId = termSet.Id;
                    taxField2.Update();

                    conetxt.ExecuteQuery();
                    listBox1.Items.Add("Document librarry created");
                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add("Operation failed:" + xcp.Message);
                }


            }
        }

        private void uploadADocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var session = TaxonomySession.GetTaxonomySession(context);
                    var termStore = session.TermStores.GetByName("Managed Metadata Service");
                    var group = termStore.Groups.GetByName("C#");
                    var termSet = group.TermSets.GetByName("Projects");
                    var term = termSet.Terms.GetByName("Libraries");
                    
                    context.Load(term);

                    var list = context.Web.Lists.GetByTitle("Project Documents Taxonomy");
                    var fci = new FileCreationInformation();
                    fci.Content = System.IO.File.ReadAllBytes(@"C:\Downloads\Sample.docx");
                    fci.Url = "Sample upload.docx";
                    fci.Overwrite = true;
                    var file = list.RootFolder.Files.Add(fci);
                    var item = file.ListItemAllFields;
                    item["Year"] = System.DateTime.Now.Year;
                    item["Coordinator"] = context.Web.CurrentUser;
                    var field = list.Fields.GetByInternalNameOrTitle("Project");
                    var taxField = context.CastTo<TaxonomyField>(field);
                    taxField.SetFieldValueByTerm(item, term, 1033);
                    item.Update();
                    context.ExecuteQuery();
                    listBox1.Items.Add("File uploaded successfuly");

                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add(xcp.Message);

                }

            }
        }

        private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var list = context.Web.Lists.GetByTitle("Project Documents");
                   
                    context.Load(list,l=>l.EffectiveBasePermissions);
                

                    var mask = new BasePermissions();
                    mask.Set(PermissionKind.ManageLists);
                    var manageLists=context.Web.DoesUserHavePermissions(mask);
                    
                    context.ExecuteQuery();
                    listBox1.Items.Add("Manage Lists:" + manageLists.Value);
                    listBox1.Items.Add("Add list items:" +list.EffectiveBasePermissions.Has(PermissionKind.AddListItems));


                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add(xcp.Message);

                }

            }
        }

        private void userProfilePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new ClientContext("http://intranet.shpdev.com"))
            {
                try
                {
                    var manager = new PeopleManager(context);
                    var properties=manager.GetMyProperties();
                    context.Load(properties, p => p.DisplayName, p => p.UserProfileProperties);
                    context.ExecuteQuery();
                    listBox1.Items.Add("User profiles properties for: " + properties.DisplayName);
                    foreach(var k in properties.UserProfileProperties.Keys){
                        if (!String.IsNullOrEmpty(properties.UserProfileProperties[k]))
                        {
                            listBox1.Items.Add(k+":"+properties.UserProfileProperties[k]);
                        }
                    }

                }
                catch (Exception xcp)
                {
                    listBox1.Items.Add(xcp.Message);

                }

            }
        }


    }
}
