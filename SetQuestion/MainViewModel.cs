using Caliburn.Micro;
using JP.ExamSystem.SetQuestion.SetQuestionModel;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using JP.ExamSystem.SetQuestion.Models;

namespace JP.ExamSystem.SetQuestion
{
     [Export(typeof(MainViewModel))]
    public class MainViewModel:Screen
     {
        public MainViewModel()
        {
            
        }

          /// <summary>
        /// 把MainListVM的创建从businessList中移出来，是为了，在类初始化时，就可使用MainListVM
        /// 这在InvoiceView中得到应用，
        /// 因为在invoiceView类初始化时可能要创建新项
        /// </summary>
        //private TestQuestionListViewModel<T, C> _mainListVM;
        //protected TestQuestionListViewModel<T, C> MainListVM
        //{
        //    get
        //    {
        //        if (_mainListVM == null)
        //        {
        //            if (_currentMx != null)
        //            {
        //                _mainListVM = new CommonListViewModel<T, C>(_currentMx.MxID);
        //            }
        //            else
        //            {
        //                _mainListVM = new CommonListViewModel<T, C>();
        //            }
        //            //订阅属性更改通知
        //            _mainListVM.PropertyChanged += new PropertyChangedEventHandler(blvm_PropertyChanged);
        //            //订阅 供添加新列表项后，初始化新项的事件
        //            _mainListVM.AddedNewItem += new EventHandler<AddedNewEventArgs<C>>(MainListVM_AddedNewItem);
        //            _mainListVM.CurrentNode = (_mainListVM.Model as ObservableCollection<C>).FirstOrDefault();

        //        }
        //        return _mainListVM;
        //    }
        //}

         public TestQuestionListView TqListView
        {
            get
            {
                //if ((MainListVM.Model as ICollection<C>).Count() > 0)
                //{
                    return (TestQuestionListView)Utils.GetBindingView(new TestQuestionListViewModel());
                //}
                //return null;
            }
        }
    }

    
       
        
  
}
