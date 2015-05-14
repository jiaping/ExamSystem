using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Windows;
using Caliburn.Micro;

namespace JP.ExamSystem.SetQuestion
{
    public class AppBootstrapper : BootstrapperBase
    {
        CompositionContainer container;

        public AppBootstrapper()
        {
            this.Initialize();
        }
        /// <summary>
        /// By default, we are configured to use MEF
        /// </summary>
        protected override void Configure()
        {

            // Check for design mode.

            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                return;
                ///在设计时，AssemblySource.Instance未被初始化，
                ///因些出来异常
            }

            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)));
            // catalog.Catalogs.Add() ;     //.OfType<ComposablePartCatalog>()     // AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()


            container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();
            //batch.AddExportedValue<IGlobalData>(new GlobalData());  
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            //batch.AddExportedValue<ICommandMessageAggregator>(new CommandMessageAggregator());
            //batch.AddExportedValue<IBusinessHandler>(new BusinessHandler());
            batch.AddExportedValue<Logger>(new Logger());

            batch.AddExportedValue(container);
            batch.AddExportedValue(catalog);

            container.Compose(batch);
            //container.ComposeParts(this);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //if (!Lygl.DalLib.Util.CommonFactory.TestDBConn())
            //{
            //    IoC.Get<IGlobalData>().ShowDialog(new DbConfigViewModel());
            //}

            base.OnStartup(sender, e);
            Dictionary<string, object> settings = new Dictionary<string, object>() { { "WindowState", WindowState.Maximized } };


            DisplayRootViewFor<ShellViewModel>();
            //DisplayRootViewFor<ShellViewModel>(settings);
            //var wm = IoC.Get<IShell>();
            //var vm = wm as ShellViewModel;
            //var vview = vm.GetView();
            //var mw = (IoC.Get<IShell>() as ShellViewModel).GetView() as Window;
            //mw.WindowState = System.Windows.WindowState.Normal;
            //mw.WindowState = System.Windows.WindowState.Minimized;
            //if (!StartLogin())
            //{
            //    Application.Shutdown();
            //}
            //  mw.WindowState = System.Windows.WindowState.Maximized;

        }
        bool StartLogin()
        {
            bool result = false;
//#if NOLOGIN
//            CustomPrincipal.Login("0002", "1365015bfa7cfa5d35cb8c96ffd06ee7");
//            result = true;
//#else
//            var login = IoC.Get<LoginViewModel>();
//            IoC.Get<IGlobalData>().ShowDialog(login, new string[] { "Transparency" });
//            result = login._result;
//#endif
//            IoC.Get<IGlobalData>().CurrentMx = null;
//            if (result)
//                log4net.GlobalContext.Properties["user"] = (Csla.ApplicationContext.User.Identity as CustomIdentity).User.Name;
            return result;
        }


        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Count() > 0)
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

    }
}
