namespace Project.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Project.Data;
    using Project.Data.UnitOfWork;
    using Project.Data.Models;

    public partial class SiteMaster : MasterPage
    {
        private static ApplicationDbContext context = new ApplicationDbContext();
        private readonly ProjectData Data = new ProjectData(context);

        public IQueryable<NavigationItem> GetData()
        {
            var data = this.Data.NavigationItems.All().Where(x => x.ParentNavigationItem.Id == null);

            return data;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var data = GetData();

                PopulateMenu(data);
                PopulateTree(data);
            }
        }

        private void PopulateMenu(IEnumerable<NavigationItem> data)
        {
            foreach (var item in data)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Description,
                    NavigateUrl = item.Url
                };

                NavigationMenu.Items.Add(menuItem);
                AddChildItems(item.Children, menuItem);

            }
        }

        private void AddChildItems(IEnumerable<NavigationItem> data, MenuItem Parent)
        {
            if (data.Count() == 0)
            {
                return;
            }

            foreach (var item in data)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Description,
                    NavigateUrl = item.Url
                };
                Parent.ChildItems.Add(menuItem);
                AddChildItems(item.Children, menuItem);
            }
        }

        private void PopulateTree(IEnumerable<NavigationItem> data)
        {
            foreach (var item in data)
            {
                TreeNode parentNode = new TreeNode
                {
                    Text = item.Description,
                    Value = item.Id.ToString(),
                    NavigateUrl = item.Url
                };
                AsideMenu.Nodes.Add(parentNode);
                AddChildTreeNodes(parentNode, item.Children);
            }
        }

        private void AddChildTreeNodes(TreeNode parentNode, IEnumerable<NavigationItem> data)
        {
            if (data.Count() == 0)
            {
                return;
            }

            foreach (var item in data)
            {
                TreeNode menuItem = new TreeNode
                {
                    Value = item.Id.ToString(),
                    Text = item.Description,
                    NavigateUrl = item.Url
                };
                parentNode.ChildNodes.Add(menuItem);
                AddChildTreeNodes(menuItem, item.Children);
            }
        }
    }
}