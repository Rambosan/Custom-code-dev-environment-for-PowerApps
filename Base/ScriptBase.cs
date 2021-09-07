using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomCodeTestEnv.Base {
    public abstract class ScriptBase {
        // Context object
        public IScriptContext Context { get; set; }

        // CancellationToken for the execution
        public CancellationToken CancellationToken { get; set; }

        // Helper: Creates a StringContent object from the serialized JSON
        public static StringContent CreateJsonContent(string serializedJson) {
            return new StringContent(serializedJson, Encoding.UTF8, "application/json");
        }

        // Abstract method for your code
        public abstract Task<HttpResponseMessage> ExecuteAsync();
    }

    public interface IScriptContext {
        // Correlation Id
        string CorrelationId { get; }

        // Connector Operation Id
        string OperationId { get; }

        // Incoming request
        HttpRequestMessage Request { get; }

        // Logger instance
        ILogger Logger { get; }

        // Used to send an HTTP request
        // Use this method to send requests instead of HttpClient.SendAsync
        Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken);
    }

}
