using System.ComponentModel.Composition;

namespace JP.ExamSystem.SetQuestion.Command
{
    [Export(typeof(ICommandMessage))]
    public class ShowSingleSelectModelMessage : CommandMessageBase
    {
        public ShowSingleSelectModelMessage() : base() { Name = "ShowSingleSelectModel"; Label = "单项选择"; ToolTip = "单项选择"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }

    [Export(typeof(ICommandMessage))]
    public class ShowMultipleSelectModelMessage : CommandMessageBase
    {
        public ShowMultipleSelectModelMessage() : base() { Name = "ShowMultipleSelectModel"; Label = "多项选择"; ToolTip = "多项选择"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }
    [Export(typeof(ICommandMessage))]
    public class ShowWindowsOperateModelMessage : CommandMessageBase
    {
        public ShowWindowsOperateModelMessage() : base() { Name = "ShowWindowsOperateModel"; Label = "Windows操作"; ToolTip = "Windows操作"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }
    [Export(typeof(ICommandMessage))]
    public class ShowWordOperateModelMessage : CommandMessageBase
    {
        public ShowWordOperateModelMessage() : base() { Name = "ShowWordOperateModel"; Label = "Word操作"; ToolTip = "Word操作"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }
    [Export(typeof(ICommandMessage))]
    public class ShowExcelOperateModelMessage : CommandMessageBase
    {
        public ShowExcelOperateModelMessage() : base() { Name = "ShowExcelOperateModel"; Label = "Excel操作"; ToolTip = "Excel操作"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }
    [Export(typeof(ICommandMessage))]
    public class ShowPptOperateModelMessage : CommandMessageBase
    {
        public ShowPptOperateModelMessage() : base() { Name = "ShowPptOperateModel"; Label = "PPT操作"; ToolTip = "PPT操作"; Group = "Main"; IsMainMenuItem = true; Category = "命题模块"; }
    }
}
