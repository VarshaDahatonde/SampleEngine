using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines;
using Tricentis.Automation.Engines.SpecialExecutionTasks;
using Tricentis.Automation.Engines.SpecialExecutionTasks.Attributes;

namespace SETHelloWorld
{
    [SpecialExecutionTaskName("SETName_HelloWorld")]
    class HelloWorld : SpecialExecutionTask
    {
        public HelloWorld(Validator validator) : base(validator)
        {
        }

        public override ActionResult Execute(ISpecialExecutionTaskTestAction testAction)
        {
            return new PassedActionResult("Hello..!!");
        }
    }
}
