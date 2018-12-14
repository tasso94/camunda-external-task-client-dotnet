namespace Camunda
{
    public interface IHandler
    {
        
        void execute(ExternalTask task, ExternalTaskService service);

    }
}