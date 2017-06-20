using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.Configuration;
using Tricentis.Automation.AutomationInstructions.Dynamic.Values;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines;
using Tricentis.Automation.Engines.SpecialExecutionTasks;
using Tricentis.Automation.Engines.SpecialExecutionTasks.Attributes;

namespace BufferToFile
{
    [SpecialExecutionTaskName("BufferToFile")]
    class XMLOperation: SpecialExecutionTask
    {
        public XMLOperation(Validator validator) : base(validator)
        {
        }

        public override ActionResult Execute(ISpecialExecutionTaskTestAction testAction)
        {
            try
            {
                IInputValue buffer = testAction.GetParameterAsInputValue("Buffer Name", false, new[] { ActionMode.Input });
                IInputValue folder = testAction.GetParameterAsInputValue("Folder Path", false, new[] { ActionMode.Input });
                IInputValue fileName = testAction.GetParameterAsInputValue("File Name", false, new[] { ActionMode.Input });

                string fileContent = Buffers.Instance.GetBuffer(buffer.Value);
                if (fileContent.StartsWith("\"") && fileContent.EndsWith("\""))
                {
                    fileContent = fileContent.TrimStart('"').TrimEnd('"').Replace("\"\"", "\"");

                }
                File.WriteAllText(Path.Combine(folder.Value, fileName.Value), fileContent);
                return new PassedActionResult("File created as '" + Path.Combine(folder.Value, fileName.Value) + "'.");
            }
            catch (Exception e)
            {
                return new UnknownFailedActionResult(e.Message);
            }
        }
    }
}
