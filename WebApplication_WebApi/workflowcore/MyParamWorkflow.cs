using WorkflowCore.Interface;

namespace WebApplication_WebApi.workflowcore
{
    public class MyParamWorkflow: IWorkflow<MyDataClass>
    {
        public string Id => "HelloWorldParam";
        public int Version => 1;
        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<FirstStepParamBody>()
                .Input(step => step.Input1, data => data.Value1)
                .Input(step => step.Input2, data => data.Value2)
                .Output(data => data.Answer, step => step.Output)
                .Then<FirstStepParamBody>()
                .Input(step => step.Input1, data => data.Value1)
                .Input(step => step.Input2, data => data.Answer)
                .Output(data => data.Answer, step => step.Output);
        }
        
    }
}
