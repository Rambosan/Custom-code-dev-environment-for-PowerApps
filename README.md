# Custom C# Code Development Environment for Power Apps Custom Connector.

C# Custom Code development or test environment in Power Apps Custom Connector.

Microsoft PowerApps / PowerAutomate CustomConnector

Power Appsのカスタムコネクタに登場したC#カスタムコードの開発・テスト環境。
.NET Core3.1 C#8.0の環境。

Script.csの内容をカスタムコードに貼り付けて保存します。

![image](https://user-images.githubusercontent.com/42938266/132376427-3ec0267d-a505-41be-ac4b-4fab8430261e.png)

![image](https://user-images.githubusercontent.com/42938266/132376553-14535ace-5461-455c-977b-79aa33ba7db5.png)


# How to use

1. Coding Script Class with ExecuteAsync method.
```cs
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
```
 
 2. Coding Mock for UnitTest and Run Script.ExecuteAsync!!
```cs
            Script script = new Script() {
                //CancellationTokenの実装
                CancellationToken = _cts.Token,
                Context = moq.Object
            };

            var response = await script.ExecuteAsync();
            Console.WriteLine(await response.Content.ReadAsStringAsync());        
```
