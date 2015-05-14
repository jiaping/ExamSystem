using System;
using System.Windows;
using Caliburn.Micro;

namespace JP.ExamSystem.SetQuestion.Models
{
    public class SetQuestionModelBase:Screen
    {
        /// <summary>
        /// 用于传递试题筛选标记
        /// </summary>
        private readonly string _tqFilterTag = string.Empty;
        /// <summary>
        /// 当前显示、修改、新增的试题ID
        /// </summary>
        private string _currentTqID = string.Empty;

        public SetQuestionModelBase()
        {
        }
        public SetQuestionModelBase(string tqFilter)
        {
            this._tqFilterTag = tqFilter;
        }

        protected override void OnViewLoaded(object view)
        {
            _vmTestQuestionListView.Refresh();
        }

        #region TestQuestionListViewModel
        /// <summary>
        /// 模块中的试题树形列表对象
        /// </summary>
        private TestQuestionListViewModel _vmTestQuestionListView;

        public TestQuestionListViewModel VmTestQuestionListView
        {
            get {
                return _vmTestQuestionListView ??
                       (_vmTestQuestionListView =
                           new TestQuestionListViewModel(_tqFilterTag));
            }
        }
        #endregion

        #region OperationViewModel

        private OperationViewModel _vmOperation;

        public OperationViewModel VmOperation
        {
            get { return _vmOperation ?? (_vmOperation = new OperationViewModel()); }
        }
        #endregion

        #region TestQuestionTreeView


        /*
        private ObservableCollection<TestQuestionTreeNode> _tvTestQuestionNodes;

        public ObservableCollection<TestQuestionTreeNode> TestQuestionNodes
        {
            get { return _tvTestQuestionNodes; }
        }
        public void Refresh()
        {
            _tvTestQuestionNodes.Clear();
            var list = ServiceHelper.GetTqList("111%");
            foreach (var item in list)
            {
                _tvTestQuestionNodes.Add(new TestQuestionTreeNode() { Id = item });
            }
        }
        /// <summary>
        /// 有二种方法可让ListView控件与选择项同步
        /// 1、在视图中使用SelectedItem="{Binding CurrnetNode}"，使选择项与CurrentNode同步
        /// 2、在视图中使用cal:Message.Attach="[SelectionChanged]=[SelectionChanged($Source,$EventArgs)]"，当选择项改变时，触发事件SelectionChanged
        /// 第一种方法，可通过创建时设置CurrentNode=* 来设置初始选择项
        /// 通过RaisePropertyChangedEventImmediately("CurrentNode");来通知UI更改选择项，以便事件订阅者获得通知
        /// </summary>
        public TestQuestionTreeNode _currentNode;
        public TestQuestionTreeNode CurrentNode
        {
            get
            {
                return _currentNode;
            }
            set
            {
                _currentNode = value;
                //RaisePropertyChangedEventImmediately("CurrentNode");
            }
        }
         * */

        #endregion


    }

    public static class Utils
    {
        /// <summary>
        /// 获取VM绑定的V
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static UIElement GetBindingView(Object vm)
        {
            var view = ViewLocator.LocateForModel(vm, null, null);
            ViewModelBinder.Bind(vm, view, null);
            return view;
        }
    }
}
