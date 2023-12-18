using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WebApplication_WebApi.workflowcore
{
    public class FirstStepBody:StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world!First");
            return ExecutionResult.Next();
        }


    }
}
