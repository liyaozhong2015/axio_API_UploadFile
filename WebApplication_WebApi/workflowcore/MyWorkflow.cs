using WorkflowCore.Interface;

namespace WebApplication_WebApi.workflowcore
{
    public class MyWorkflow:IWorkflow
    {
        public string Id => "HelloWorld";
        public int Version => 1;
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<FirstStepBody>()
                .Then<FirstStepBody>();
        }

    }
}
