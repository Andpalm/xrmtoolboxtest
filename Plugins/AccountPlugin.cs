using Microsoft.Xrm.Sdk;
using System;

namespace Plugins
{
    public class AccountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity account = (Entity)context.InputParameters["Target"];

                if (account.Contains("telephone1"))
                {
                    account["fax"] = $"555-{account.GetAttributeValue<string>("telephone1")}";
                }
            }
        }
    }
}
