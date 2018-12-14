using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Refit;
using Camunda;
using System.Collections.Generic;
using System.Threading;

class MyHandler : IHandler {

    // customized handler
    public void execute(ExternalTask task, ExternalTaskService externalTaskService) {

        // complete external task
        externalTaskService.complete(task);

        Console.WriteLine("External Task " + task + " successfully completed!");
    }

}

class App
{
    static void Main()
    {
        // bootstrap the external task client
        ExternalTaskClient client = ExternalTaskClient.create()
            .endpoint("http://localhost:8080")
            .build();

        // subscribe to a topic name
        TopicSubscription topic = client.subscribe("invoiceCreator")
            .handler(new MyHandler())
            .open();
    }
}
