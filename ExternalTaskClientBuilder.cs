namespace Camunda
{
    interface ExternalTaskClientBuilder
    {

        ExternalTaskClientBuilder endpoint(string url);

        ExternalTaskClient build();

    }
}