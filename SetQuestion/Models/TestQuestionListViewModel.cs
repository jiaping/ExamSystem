using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Xceed.Wpf.DataGrid.Converters;

namespace JP.ExamSystem.SetQuestion.Models
{
    //[Export(typeof(BusinessListViewModel))]
    /// <summary>
    /// 实现通用列表VM
    /// 实现节点的选择、更改的通知事件
    /// 实现列表的添加、删除，保存，撤消
    /// </summary>
    /// <typeparam name="T">列表的类</typeparam>
    /// <typeparam name="C">列表项类</typeparam>
    public class TestQuestionListViewModel:Screen
    {
        /// <summary>
        /// 用于传递试题筛选标记
        /// </summary>
        private string _tqFilterTag = string.Empty;
          public TestQuestionListViewModel()
        {
            _tvTestQuestionNodes = new ObservableCollection<TestQuestionTreeNode>();
            //Model = DataPortal.Fetch<T>();
        }
        public TestQuestionListViewModel(string tqFilterTag)
        {
            this._tqFilterTag = tqFilterTag;
            _tvTestQuestionNodes = new ObservableCollection<TestQuestionTreeNode>();
            //Model = DataPortal.Fetch<T>(mxID);
        }
        //public TestQuestionListViewModel(T model)
        //{
        //    //Model = model;
        //}

        #region binding property

        private ObservableCollection<TestQuestionTreeNode> _tvTestQuestionNodes;

        public ObservableCollection<TestQuestionTreeNode> TestQuestionNodes
        {
            get { return _tvTestQuestionNodes; }
        }
        /// <summary>
        /// 获取试题列表
        /// </summary>
        public void GetTqList()
        {
            _tvTestQuestionNodes.Clear();
            var list = ServiceHelper.GetTqList(this._tqFilterTag);
            foreach (var item in list)
            {
                _tvTestQuestionNodes.Add(new TestQuestionTreeNode() { Id = item });
            }
            NotifyOfPropertyChange();
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        public void ReGetTqList()
        {
           GetTqList();
        }

        #endregion

        #region 节点选择属性和事件
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
                NotifyOfPropertyChange("CurrentNode");
                
            }
        }
        /// <summary>
        /// 保存后，Model对象被更新后的对象替换，所以重新定位到更新的子对象上
        /// </summary>
        public void SaveList()
        {
            //int currentIndex = (Model as IList<C>).IndexOf(_currentNode);
            //DoSave();
            //CurrentNode = (Model as IList<C>)[currentIndex];
        }
        public void CancelList()
        {
            //DoCancel();
            ////解决没记录时，如果添加，立即取消时，新建对象未被删除
            //if ((Model as ICollection<C>).Count == 0) { CurrentNode = default(C); }
        }
        /// <summary>
        /// 提供添加新列表项后，初始化新项的订阅事件
        /// </summary>
        //public event EventHandler<AddedNewEventArgs<C>> AddedNewItem;
        //public void  ListAddNew()
        //{
        //    C cc=(C)DoAddNew();
        //    OnAddedNewItem(cc); 
        //    CurrentNode = cc;
        //}
        //public virtual void OnAddedNewItem(C newModel)
        //{
        //    if (AddedNewItem != null)
        //        AddedNewItem(this, new AddedNewEventArgs<C>(newModel));
        //}
        //public void ListDeleteItem(C item)
        //{
        //    int currentIndex = (Model as IList<C>).IndexOf(item);
        //    DoRemove(item);
        //    DoSave();
        //    if ((Model as IList<C>).Count>0)
        //    CurrentNode = (Model as IList<C>)[currentIndex-1];
        //}
        
        //public void SelectionChanged(ListView sender, SelectionChangedEventArgs e)
        //{
        //    CurrentNode =(C) sender.SelectedItem;                  
        //}
        #endregion
        //protected override void OnDeactivate(bool close)
        //{
        //    if (close) IoC.Get<IEventAggregator>().Unsubscribe(this);
        //    base.OnDeactivate(close);
        //}
    }

    public class TestQuestionTreeNode
    {
        public string Id { get; set; }
        public bool IsSelected { get; set; }
    }
}
