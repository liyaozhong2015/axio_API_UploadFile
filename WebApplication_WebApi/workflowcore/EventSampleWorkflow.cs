using WorkflowCore.Interface;

namespace WebApplication_WebApi.workflowcore
{
    public class EventSampleWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => "EventSampleWorkflow";

        public int Version => 1;
        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<FirstStepParamBody>()
                .Input(step => step.Input1, data => data.Value1)
                .Input(step => step.Input2, data => 100)
                .Output(data => data.Answer, step => step.Output)
                .WaitFor("MyEvent", key => "EventKey")
                .Output(data => data.Answer, step => step.EventData)
                .Then<FirstStepParamBody>()
                .Input(step => step.Input1, data => data.Value1)
                .Input(step => step.Input2, data => data.Answer)
                .Output(data => data.Answer, step => step.Output);
        }

    }
}
