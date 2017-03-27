using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.Messages;
using MsCrmTools.SolutionComponentManager.AppCode;
using MsCrmTools.SolutionComponentManager.Forms.Solutions;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.SolutionComponentManager
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        private ComponentsManager cManager;

        public MainControl()
        {
            InitializeComponent();

            cbbComponentType.SelectedIndex = 0;
        }

        public string HelpUrl
        {
            get
            {
                return "https://github.com/MscrmTools/MsCrmTools.SolutionComponentsMover/wiki";
            }
        }

        public string RepositoryName
        {
            get
            {
                return "MsCrmTools.SolutionComponentsManager";
            }
        }

        public string UserName
        {
            get
            {
                return "MscrmTools";
            }
        }

        private Entity SelectedSolution;
        private string SelectComponentType;


        public void LoadSolutions()
        {
            var sPicker = new SolutionPicker(Service) { StartPosition = FormStartPosition.CenterParent };
            if (sPicker.ShowDialog(ParentForm) == DialogResult.OK)
            {
                SelectedSolution = sPicker.SelectedSolution;
            }
            else
            {
                return;
            }

            LoadComponentsforSolution();
        }

        public void LoadComponentsforSolution()
        {
            cManager = new ComponentsManager(Service);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading components...",
                Work = (bw, e) =>
                {
                    List<Entity> solutionComponents = new List<Entity>();
                    solutionComponents.AddRange(cManager.RetrieveComponentBySolution(SelectedSolution.Id));
                    e.Result = solutionComponents;
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error == null)
                    {
                        lvComponents.LoadComponents((IEnumerable<Entity>)e.Result);
                    }
                    else
                    {
                        MessageBox.Show(ParentForm, "An error occured: " + e.Error.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                },
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadSolutions);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectComponentType = cbbComponentType.SelectedItem.ToString();

            ExecuteMethod(SearchComponents);
        }

        public void SearchComponents()
        {

            if (string.IsNullOrWhiteSpace(txtKeyword.Text))
            {
                MessageBox.Show(ParentForm, "Please type a keyword!", "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                return;
            }


            cManager = new ComponentsManager(Service);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Search components...",
                Work = (bw, e) =>
                {
                    List<Entity> solutionComponents = new List<Entity>();
                    solutionComponents.AddRange(cManager.SearchComponentByType(SelectComponentType, txtKeyword.Text));
                    e.Result = solutionComponents;
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error == null)
                    {
                        lvSearchResults.LoadComponents((IEnumerable<Entity>)e.Result);
                    }
                    else
                    {
                        MessageBox.Show(ParentForm, "An error occured: " + e.Error.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                },
            });
        }

        private void btnAddExsting_Click(object sender, EventArgs e)
        {

            if (SelectedSolution == null)
            {
                MessageBox.Show(ParentForm, "Please select a solution first ", "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);

                return;
            }

            if (lvSearchResults.SelectedComponent.Count == 0)
            {
                MessageBox.Show(ParentForm, "Please select a component first ", "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);

                return;
            }


            ComponentAction addAction = new ComponentAction
            {
                Components = lvSearchResults.SelectedComponent,
                Solution = SelectedSolution
            };



            cManager = new ComponentsManager(Service);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Starting add...",
                AsyncArgument = addAction,
                Work = (bw, evt) =>
                {
                    cManager.AddExstignComponentToSolution((ComponentAction)evt.Argument);
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(ParentForm, "An error occured: " + evt.Error.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        ExecuteMethod(LoadComponentsforSolution);
                    }
                },
                ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (SelectedSolution == null)
            {
                MessageBox.Show(ParentForm, "Please select a solution first ", "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);

                return;
            }

            if (lvComponents.SelectedComponent.Count == 0)
            {
                MessageBox.Show(ParentForm, "Please select a component first ", "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);

                return;
            }

            ComponentAction removeAction = new ComponentAction
            {
                Components = lvComponents.SelectedComponent,
                Solution = SelectedSolution
            };



            cManager = new ComponentsManager(Service);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Starting remove...",
                AsyncArgument = removeAction,
                Work = (bw, evt) =>
                {
                    cManager.RemoveComponentFromSolution((ComponentAction)evt.Argument);
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(ParentForm, "An error occured: " + evt.Error.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        ExecuteMethod(LoadComponentsforSolution);
                    }
                },
                ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
            });
        }

       
    }
}
