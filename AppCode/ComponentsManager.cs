using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace MsCrmTools.SolutionComponentManager.AppCode
{
    internal class ComponentsManager
    {
        #region Variables

        /// <summary>
        /// Xrm Organization service
        /// </summary>
        private readonly IOrganizationService innerService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class WebResourceManager
        /// </summary>
        /// <param name="service">Xrm Organization service</param>
        public ComponentsManager(IOrganizationService service)
        {
            innerService = service;
        }

        #endregion Constructor

        /// <summary>
        /// Retrieves all web resources that are customizable
        /// </summary>
        /// <returns>List of web resources</returns>
        internal IEnumerable<Entity> RetrieveWebResources(Guid solutionId)
        {
            try
            {
                var types = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });


                var qba = new QueryByAttribute("solutioncomponent") { ColumnSet = new ColumnSet(true) };
                qba.Attributes.AddRange(new[] { "solutionid", "componenttype" });
                qba.Values.AddRange(new object[] { solutionId, SolutionComponentType.WebResource });

                var components = innerService.RetrieveMultiple(qba).Entities;

                var componentIdlist =
                    components.Select(component => component.GetAttributeValue<Guid>("objectid").ToString("B"))
                        .ToList();

                if (componentIdlist.Count > 0)
                {
                    var qe = new QueryExpression("webresource")
                    {
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Filters =
                            {
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions =
                                    {
                                        new ConditionExpression("ishidden", ConditionOperator.Equal, false),
                                        new ConditionExpression("webresourcetype", ConditionOperator.In, types.ToArray()),
                                        new ConditionExpression("webresourceid", ConditionOperator.In, componentIdlist.ToArray())
                                    }
                                },
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.Or,
                                     Conditions =
                                    {
                                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false),
                                        //new ConditionExpression("iscustomizable", ConditionOperator.Equal, true),
                                    }
                                }
                            }
                        },
                        Orders = { new OrderExpression("name", OrderType.Ascending) }
                    };

                    return innerService.RetrieveMultiple(qe).Entities;
                }

                return new List<Entity>();

            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving web resources: " + error.Message);
            }
        }

        internal IEnumerable<Entity> RetrievePluginSteps(Guid solutionId)
        {
            try
            {
                var qba = new QueryByAttribute("solutioncomponent") { ColumnSet = new ColumnSet(true) };
                qba.Attributes.AddRange(new[] { "solutionid", "componenttype" });
                qba.Values.AddRange(new object[] { solutionId, SolutionComponentType.SDKMessageProcessingStep });

                var components = innerService.RetrieveMultiple(qba).Entities;

                var componentIdlist =
                    components.Select(component => component.GetAttributeValue<Guid>("objectid").ToString("B"))
                        .ToList();

                if (componentIdlist.Count > 0)
                {
                    var qe = new QueryExpression("sdkmessageprocessingstep")
                    {
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Filters =
                            {
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions =
                                    {
                                        new ConditionExpression("ishidden", ConditionOperator.Equal, false),
                                         new ConditionExpression("sdkmessageprocessingstepid", ConditionOperator.In, componentIdlist.ToArray())
                                    }
                                },
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.Or,
                                     Conditions =
                                    {
                                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false),
                                        //new ConditionExpression("iscustomizable", ConditionOperator.Equal, true),
                                    }
                                }
                            }
                        },
                        Orders = { new OrderExpression("name", OrderType.Ascending) }
                    };

                    return innerService.RetrieveMultiple(qe).Entities;
                }

                return new List<Entity>();
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving plugin steps: " + error.Message);
            }

        }

        internal IEnumerable<Entity> RetrievePluginAssembiles(Guid solutionId)
        {
            try
            {
                var qba = new QueryByAttribute("solutioncomponent") { ColumnSet = new ColumnSet(true) };
                qba.Attributes.AddRange(new[] { "solutionid", "componenttype" });
                qba.Values.AddRange(new object[] { solutionId, SolutionComponentType.PluginAssembly });

                var components = innerService.RetrieveMultiple(qba).Entities;

                var componentIdlist =
                    components.Select(component => component.GetAttributeValue<Guid>("objectid").ToString("B"))
                        .ToList();

                if (componentIdlist.Count > 0)
                {
                    // Instantiate QueryExpression QEpluginassembly
                    var qe = new QueryExpression("pluginassembly");

                    // Add all columns to QEpluginassembly.ColumnSet
                    qe.ColumnSet.AllColumns = true;
                    qe.AddOrder("name", OrderType.Ascending);

                    // Define filter QEpluginassembly.Criteria
                    qe.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
                    qe.Criteria.AddCondition("createdbyname", ConditionOperator.NotEqual, "SYSTEM");
                    qe.Criteria.AddCondition("pluginassemblyid", ConditionOperator.In, componentIdlist.ToArray());

                    return innerService.RetrieveMultiple(qe).Entities;
                }

                return new List<Entity>();
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving plugin steps: " + error.Message);
            }

        }

        internal IEnumerable<Entity> RetrieveWorkflows(Guid solutionId)
        {
            try
            {
                var qba = new QueryByAttribute("solutioncomponent") { ColumnSet = new ColumnSet(true) };
                qba.Attributes.AddRange(new[] { "solutionid", "componenttype" });
                qba.Values.AddRange(new object[] { solutionId, SolutionComponentType.Workflow });

                var components = innerService.RetrieveMultiple(qba).Entities;

                var componentIdlist =
                    components.Select(component => component.GetAttributeValue<Guid>("objectid").ToString("B"))
                        .ToList();

                if (componentIdlist.Count > 0)
                {
                    var qe = new QueryExpression("workflow");
                    // Add columns to QEworkflow.ColumnSet
                    qe.ColumnSet.AddColumns("workflowid", "name", "category");
                    qe.AddOrder("name", OrderType.Ascending);

                    // Define filter QEworkflow.Criteria
                    qe.Criteria.AddCondition("type", ConditionOperator.Equal, 1);
                    qe.Criteria.AddCondition("rendererobjecttypecode", ConditionOperator.Null);
                    qe.Criteria.AddCondition("workflowid", ConditionOperator.In, componentIdlist.ToArray());
                    var fiter1 = new FilterExpression();
                    qe.Criteria.AddFilter(fiter1);

                    // Define filter QEworkflow_Criteria_0
                    fiter1.FilterOperator = LogicalOperator.Or;
                    fiter1.AddCondition("category", ConditionOperator.Equal, 0);
                    fiter1.AddCondition("category", ConditionOperator.Equal, 3);
                    fiter1.AddCondition("category", ConditionOperator.Equal, 4);
                    var filter2 = new FilterExpression();
                    fiter1.AddFilter(filter2);

                    // Define filter QEworkflow_Criteria_0_0
                    filter2.AddCondition("category", ConditionOperator.Equal, 1);
                    filter2.AddCondition("languagecode", ConditionOperator.EqualUserLanguage);

                    return innerService.RetrieveMultiple(qe).Entities;
                }

                return new List<Entity>();
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving plugin steps: " + error.Message);
            }

        }

        internal IEnumerable<Entity> RetrieveReports(Guid solutionId)
        {
            try
            {
                var qba = new QueryByAttribute("solutioncomponent") { ColumnSet = new ColumnSet(true) };
                qba.Attributes.AddRange(new[] { "solutionid", "componenttype" });
                qba.Values.AddRange(new object[] { solutionId, SolutionComponentType.Report });

                var components = innerService.RetrieveMultiple(qba).Entities;

                var componentIdlist =
                    components.Select(component => component.GetAttributeValue<Guid>("objectid").ToString("B"))
                        .ToList();

                if (componentIdlist.Count > 0)
                {
                    // Instantiate QueryExpression QEreport
                    var qe = new QueryExpression("report");

                    // Add columns to QEreport.ColumnSet
                    qe.ColumnSet.AddColumns("name", "reporttypecode", "reportid");
                    qe.AddOrder("name", OrderType.Ascending);
                    qe.Criteria.AddCondition("reportid", ConditionOperator.In, componentIdlist.ToArray());

                    return innerService.RetrieveMultiple(qe).Entities;
                }

                return new List<Entity>();
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving plugin steps: " + error.Message);
            }
        }

        internal IEnumerable<Entity> SearchPluginSteps(string keyword)
        {
            var qe = new QueryExpression("sdkmessageprocessingstep")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Filters =
                            {
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions =
                                    {
                                        new ConditionExpression("ishidden", ConditionOperator.Equal, false)
                                    }
                                },
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.Or,
                                     Conditions =
                                    {
                                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false),
                                        //new ConditionExpression("iscustomizable", ConditionOperator.Equal, true),
                                    }
                                }
                            }
                },
                Orders = { new OrderExpression("name", OrderType.Ascending) }
            };

            qe.Criteria.AddFilter(LogicalOperator.And).AddCondition("name", ConditionOperator.Like, "%" + keyword + "%");


            return innerService.RetrieveMultiple(qe).Entities;
        }


        internal IEnumerable<Entity> SearchPluginAssemblies(string keyword)
        {
            // Instantiate QueryExpression QEpluginassembly
            var qe = new QueryExpression("pluginassembly");

            // Add all columns to QEpluginassembly.ColumnSet
            qe.ColumnSet.AllColumns = true;
            qe.AddOrder("name", OrderType.Ascending);

            // Define filter QEpluginassembly.Criteria
            qe.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
            qe.Criteria.AddCondition("createdbyname", ConditionOperator.NotEqual, "SYSTEM");


            qe.Criteria.AddCondition("name", ConditionOperator.Like, "%" + keyword + "%");


            return innerService.RetrieveMultiple(qe).Entities;
        }

        internal IEnumerable<Entity> SearchWebResources(string keyword)
        {
            var types = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            var qe = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Filters =
                            {
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions =
                                    {
                                        new ConditionExpression("ishidden", ConditionOperator.Equal, false),
                                        new ConditionExpression("webresourcetype", ConditionOperator.In, types.ToArray()),
                                    }
                                },
                                new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                     Conditions =
                                    {
                                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false),
                                        //new ConditionExpression("iscustomizable", ConditionOperator.Equal, true),
                                    }
                                }
                            }
                },
                Orders = { new OrderExpression("name", OrderType.Ascending) }
            };

            qe.Criteria.AddFilter(LogicalOperator.And).AddCondition("name", ConditionOperator.Like, "%" + keyword + "%");


            return innerService.RetrieveMultiple(qe).Entities;
        }

        internal IEnumerable<Entity> SearchWorkflows(string keyword)
        {
            try
            {


                var qe = new QueryExpression("workflow");
                // Add columns to QEworkflow.ColumnSet
                qe.ColumnSet.AddColumns("workflowid", "name", "category");
                qe.AddOrder("name", OrderType.Ascending);

                // Define filter QEworkflow.Criteria
                qe.Criteria.AddCondition("type", ConditionOperator.Equal, 1);
                qe.Criteria.AddCondition("rendererobjecttypecode", ConditionOperator.Null);
                qe.Criteria.AddCondition("name", ConditionOperator.Like, "%" + keyword + "%");
                var fiter1 = new FilterExpression();
                qe.Criteria.AddFilter(fiter1);

                // Define filter QEworkflow_Criteria_0
                fiter1.FilterOperator = LogicalOperator.Or;
                fiter1.AddCondition("category", ConditionOperator.Equal, 0);
                fiter1.AddCondition("category", ConditionOperator.Equal, 3);
                fiter1.AddCondition("category", ConditionOperator.Equal, 4);
                var filter2 = new FilterExpression();
                fiter1.AddFilter(filter2);

                // Define filter QEworkflow_Criteria_0_0
                filter2.AddCondition("category", ConditionOperator.Equal, 1);
                filter2.AddCondition("languagecode", ConditionOperator.EqualUserLanguage);


                return innerService.RetrieveMultiple(qe).Entities;

            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving workflows " + error.Message);
            }
        }

        internal IEnumerable<Entity> SearchReports(string keyword)
        {
            try
            {
                // Instantiate QueryExpression QEreport
                var qe = new QueryExpression("report");

                // Add columns to QEreport.ColumnSet
                qe.ColumnSet.AddColumns("name", "reporttypecode", "reportid");
                qe.Criteria.AddCondition("name", ConditionOperator.Like, "%" + keyword + "%");
                qe.AddOrder("name", OrderType.Ascending);

                return innerService.RetrieveMultiple(qe).Entities;

            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving reports: " + error.Message);
            }
        }


        internal List<Entity> SearchComponentByType(string typeName, string keyword)
        {
            List<Entity> componentList = new List<Entity>();

            switch (typeName)
            {
                case "Web Resources":
                    componentList = SearchWebResources(keyword).ToList();
                    break;
                case "Plugin Steps":
                    componentList = SearchPluginSteps(keyword).ToList();
                    break;
                case "Plugin Assemblies":
                    componentList = SearchPluginAssemblies(keyword).ToList();
                    break;
                case "Workflows":
                    componentList = SearchWorkflows(keyword).ToList();
                    break;
                case "Reports":
                    componentList = SearchReports(keyword).ToList();
                    break;
            }

            return componentList;
        }

        internal List<Entity> RetrieveComponentBySolution(Guid solutionId)
        {
            List<Entity> solutionComponents = new List<Entity>();

            solutionComponents.AddRange(RetrieveWebResources(solutionId));
            solutionComponents.AddRange(RetrievePluginSteps(solutionId));
            solutionComponents.AddRange(RetrieveWorkflows(solutionId));
            solutionComponents.AddRange(RetrieveReports(solutionId));
            solutionComponents.AddRange(RetrievePluginAssembiles(solutionId));

            return solutionComponents;
        }

        internal void AddExstignComponentToSolution(ComponentAction addAction)
        {
            foreach (var component in addAction.Components)
            {
                AddSolutionComponentRequest req = new AddSolutionComponentRequest();
                req.SolutionUniqueName = addAction.Solution.GetAttributeValue<string>("uniquename");
                req.ComponentId = component.Id;
                req.ComponentType = MatchSolutionComponentType(component.LogicalName);
                req.AddRequiredComponents = false;
                AddSolutionComponentResponse resp = (AddSolutionComponentResponse)innerService.Execute(req);
            }
        }

        internal void RemoveComponentFromSolution(ComponentAction removeAction)
        {
            foreach (var component in removeAction.Components)
            {
                RemoveSolutionComponentRequest removeReq = new RemoveSolutionComponentRequest()
                {
                    ComponentId = component.Id,
                    SolutionUniqueName = removeAction.Solution.GetAttributeValue<string>("uniquename"),
                    ComponentType = MatchSolutionComponentType(component.LogicalName)
                };

                innerService.Execute(removeReq);
            }
        }

        internal int MatchSolutionComponentType(string entityname)
        {
            switch (entityname)
            {
                case "webresource":
                    return SolutionComponentType.WebResource;

                case "sdkmessageprocessingstep":
                    return SolutionComponentType.SDKMessageProcessingStep;
                   
                case "workflow":

                    return SolutionComponentType.Workflow;
                case "report":
                    return SolutionComponentType.Report;
                case "pluginassembly":
                    return SolutionComponentType.PluginAssembly;
                default:
                    throw new Exception("No Solution Component Type found");
            }
        }
    }
}
