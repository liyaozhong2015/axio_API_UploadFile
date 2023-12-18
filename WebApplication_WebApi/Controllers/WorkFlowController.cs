using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using WebApplication_WebApi.workflowcore;
using WorkflowCore.Interface;

namespace WebApplication_WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkflowHost _workflowHost;
        public WorkFlowController(IWorkflowHost workflowHost)
        {
            _workflowHost = workflowHost;
        }
        [HttpGet("WorkFlowStart")]
        public ContentResult Get()
        {
            if (!_workflowHost.Registry.IsRegistered("HelloWorld", 1))
            {
                _workflowHost.RegisterWorkflow<MyWorkflow>();
            }
            _workflowHost.Start();
            _workflowHost.StartWorkflow("HelloWorld");
            //_workflowHost.Stop();
            return Content("ok");
        }
        [HttpGet("WorkFlowParamGet")]
        public ContentResult ParamGet()
        {
            if (!_workflowHost.Registry.IsRegistered("HelloWorldParam", 1))
            {
                _workflowHost.RegisterWorkflow<MyParamWorkflow, MyDataClass>();
                _workflowHost.Start();
            }

            //执行工作流传入参数
            MyDataClass myDataClass = new MyDataClass();
            myDataClass.Value1 = 100;
            myDataClass.Value2 = 200;
            _workflowHost.StartWorkflow("HelloWorldParam", myDataClass);
            //_workflowHost.Stop();
            Console.WriteLine(myDataClass.Answer);
            return Content("ParamOk");

        }

        [HttpGet(Name = "EventWorkflow")]
        public ContentResult EventWorkflow()
        {
            if (!_workflowHost.Registry.IsRegistered("EventSampleWorkflow", 1))
            {
                _workflowHost.RegisterWorkflow<EventSampleWorkflow, MyDataClass>();
                _workflowHost.Start();
            }
            MyDataClass myDataClass = new MyDataClass();
            myDataClass.Value1 = 100;
            myDataClass.Value2 = 200;
            _workflowHost.StartWorkflow("EventSampleWorkflow", myDataClass);
            return Content("ok");
        }
        [HttpPost(Name = "event")]
        public ContentResult PublishEvent()
        {
            _workflowHost.PublishEvent("MyEvent", "EventKey", 200);
            return Content("ok");



        }
    }
}
