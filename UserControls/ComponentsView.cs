using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;

namespace MsCrmTools.SolutionComponentManager.UserControls
{
    public partial class ComponentsView : UserControl
    {
        public ComponentsView()
        {
            InitializeComponent();
        }

        public List<Entity> SelectedComponent
        {
            get { return lvComponents.SelectedItems.Cast<ListViewItem>().Select(i => (Entity)i.Tag).ToList(); }
        }


        public void LoadComponents(IEnumerable<Entity> components)
        {
            lvComponents.Items.Clear();

            var list = new List<ListViewItem>();

            foreach (var component in components)
            {
                string displayName = component.GetAttributeValue<string>("displayname");
                string name = component.GetAttributeValue<string>("name");

                var item = new ListViewItem(displayName ?? name);
                item.SubItems.Add(name);

                switch (component.LogicalName)
                {
                    case "sdkmessageprocessingstep":
                        item.SubItems.Add("Sdk Message Processing Step");
                        break;
                    case "pluginassembly":
                        item.SubItems.Add("Plugin Assembly");
                        break;
                    case "webresource":
                        item.SubItems.Add(component.FormattedValues["webresourcetype"]);
                        break;
                    case "workflow":
                        item.SubItems.Add(component.FormattedValues["category"]);
                        break;
                    case "report":
                        item.SubItems.Add(component.FormattedValues["reporttypecode"]);
                        break;
                }

                item.Tag = component;

                list.Add(item);
            }

            lvComponents.Items.AddRange(list.ToArray());
        }
    }
}
