## Usage - Method 1

1. In your android (monodroid) project, add an `Application` class:

```

    [Application]
    public class MainApp : global::Android.App.Application
    {

        private static MainApp _current;    

        public MainApp(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {         
                base.OnCreate();

                // Application Initialisation ...
                _current = this;          
        }        

        public static MainApp Current
        {
            get { return _current; }
        }


    }

```

2. In your main activity:

```

            var lifecycleManager = new DroidViewLifecycleManager(application);
            lifecycleManager.Register();  
			
```

You can now get access to the current activity like so:

```
 _lifecycleManager.GetCurrentActivity();
```

If you are using a DI container, you can register the following services into the DI container, something like:

```

            services.AddSingleton<IDroidViewLifecycleManager>(lifecycleManager);           
            services.AddTransient<IAndroidCurrentTopActivity, AndroidCurrentTopActivity>();

```

`IAndroidCurrentTopActivity` is just a helper service for DI scenarios that makes it more explicit when you are just requiring access to the current / top activity.

## Usage - Method 2 Xamarin.Standard

I highly recommend using [Xamarin.Standard](https://github.com/dazinator/Xamarin.Standard/tree/develop/src) and then usage becomes simpler:

```

    public class Startup : AndroidStartup
    {
        public Startup(AppContextProvider context) : base(context)
        {
        }

        public override void RegisterServices(IServiceCollection services)
        {
            // register services.
            services.RegisterAndroidViewLifecycleManager(MainApp.Current);           
        }    
    }

```