using System.ComponentModel.Composition;
using Caliburn.Micro;
using JP.ExamSystem.SetQuestion.Models;
using System.Collections.ObjectModel;
using JP.ExamSystem.SetQuestion.Command;

namespace JP.ExamSystem.SetQuestion
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<ShowSingleSelectModelMessage>
    {
        [ImportingConstructor]
        public ShellViewModel(IEventAggregator _event)
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            //_event.Subscribe(this);
            this.DisplayName = "一级Windows平台无纸化考试命题系统";
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            var bb = view;
        }

        #region 命令按钮相关
        #endregion 
      
        public string Title
        {
            get { return "一级Windows平台无纸化考试命题系统"; }
            private set {  }
        }

        private ObservableCollection<MenuCategoryItem> _mainMenu;

        public ObservableCollection<MenuCategoryItem> MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    MainMenuHelper newMainMenuHelper = new MainMenuHelper();
                    _mainMenu = newMainMenuHelper.MenuCategoryItems;
                }
                return _mainMenu;
            }
        }
        #region obsolete menu et.
        //private IEnumerable<ICommandMessage> _naviList;

        //public IEnumerable<ICommandMessage> NaviList
        //{
        //    get
        //    {
        //        if (_naviList == null)
        //        {
        //            ICommandMessageAggregator agg = IoC.Get<ICommandMessageAggregator>();
        //            _naviList = agg.CommandMessages;
        //        }
        //        return _naviList;
        //    }
        //}

      


        //public void OrgManage()
        //{
        //    OrgUserManagerTreeViewModel um = new OrgUserManagerTreeViewModel();
        //    this.ActivateItem(um);
        //}

       // private Expander _mainNavi;
       // public Expander MainNavi
       // {
       //     get
       //     {
       //         if (_mainNavi==null)
       //             CompositeNavi(ref _mainNavi);
       //         return _mainNavi;
       //     }
       // }
       // private void CompositeNavi(ref Expander navi)
       //{
       // //    if (navi != null) return;
       // //    navi = new Expander() { IsExpanded = true, Header = "功能" };

        // }
        #endregion

        #region IHandle<ShowSingleSelectModelMessage> 成员

        public void Handle(ShowSingleSelectModelMessage message)
        {
            SingleSelectViewModel um = new SingleSelectViewModel();
            this.ActivateItem(um);
        }

        #endregion
    }
}
