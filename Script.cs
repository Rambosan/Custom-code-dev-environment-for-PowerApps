using CustomCodeTestEnv.Base;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomCodeTestEnv {


    //C# custom code with PowerApps custom connector
    public partial class Script: ScriptBase {

        public override async Task<HttpResponseMessage> ExecuteAsync() {

            // Create a new response
            var response = new HttpResponseMessage();

            // Parse request body
            var contentAsJson = JObject.Parse(await Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false));

            // Set the content
            // Initialize a new JObject and call .ToString() to get the serialized JSON
            response.Content = CreateJsonContent(new JObject {
                ["message"] = (string)contentAsJson["message"],
                ["request_uri"] = Context.Request.RequestUri,
                ["operation_id"] = Context.OperationId,
                ["correlation_id"] = Context.CorrelationId,
                ["content"] = await Context.Request.Content.ReadAsStringAsync()
            }.ToString());

            return response;
        }

    }

}
