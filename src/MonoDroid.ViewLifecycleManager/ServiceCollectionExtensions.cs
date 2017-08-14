using Android.App;
using Microsoft.Extensions.DependencyInjection;

namespace MonoDroid.ViewLifecycleManager
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAndroidViewLifecycleManager(this IServiceCollection services, Application application)
        {
            var lifecycleManager = new DroidViewLifecycleManager(application);
            lifecycleManager.Register();            
            services.AddSingleton<IDroidViewLifecycleManager>(lifecycleManager);
            services.AddSingleton<IViewLifecycleManager>(lifecycleManager);
            services.AddTransient<IAndroidCurrentTopActivity, AndroidCurrentTopActivity>();
        }
    }
}


