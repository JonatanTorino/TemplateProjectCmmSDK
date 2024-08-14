using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Commerce.Runtime.Messages;
using Microsoft.Dynamics.Commerce.Runtime;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevAxTemplateSample.CommerceRuntime.Triggers
{
    public class DefinePosExtensionTrigger : IRequestTriggerAsync
    {
        public IEnumerable<Type> SupportedRequestTypes => new[] { typeof(GetExtensionPackageDefinitionsRequest) };

        public Task OnExecuted(Request request, Response response)
        {
            ThrowIf.Null(request, "request");
            ThrowIf.Null(response, "response");

            var getExtensionsResponse = (GetExtensionPackageDefinitionsResponse)response;
            var extensionPackageDefinition = new ExtensionPackageDefinition();
            extensionPackageDefinition.Name = "DevAxNOMBREEXTENSION";
            extensionPackageDefinition.Publisher = "Axxon Consulting";
            extensionPackageDefinition.IsEnabled = true;

            getExtensionsResponse.ExtensionPackageDefinitions.Add(extensionPackageDefinition);

            return Task.CompletedTask;
        }

        public Task OnExecuting(Request request)
        {
            return Task.CompletedTask;
        }
    }
}
