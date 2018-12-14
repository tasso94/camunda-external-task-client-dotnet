using System;
using Camunda;

class ExampleApp
{
    static void Main()
    {
        // bootstrap the external task client
        ExternalTaskClient client = ExternalTaskClient.create()
            .endpoint("http://localhost:8080/engine-rest")
            .build();

        // subscribe to a topic name
        TopicSubscription topic = client.subscribe("invoiceCreator")
            .handler(new MyHandler())
            .open();
    }
}

class MyHandler : IHandler {

    // customized handler
    public void execute(ExternalTask task, ExternalTaskService externalTaskService) {

        // complete external task
        externalTaskService.complete(task);

        Console.WriteLine("External Task " + task + " successfully completed!\n");
    }

}