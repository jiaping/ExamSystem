using Caliburn.Micro;

namespace JP.ExamSystem.SetQuestion.Models
{
    public class OperationViewModel:Screen
    {
        public void btnReturn()
        {
            var one = IoC.Get<ShellViewModel>();
            if (one.ActiveItem!=null)
                one.DeactivateItem(one.ActiveItem,true);
        }
    }
}
