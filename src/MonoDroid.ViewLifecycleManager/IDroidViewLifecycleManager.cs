using System;

using Android.App;

namespace MonoDroid.ViewLifecycleManager
{
    public interface IDroidViewLifecycleManager : IViewLifecycleManager, Application.IActivityLifecycleCallbacks
    {
        event EventHandler<ViewLifetimeEventArgs> LifetimeChanged;
        Activity GetCurrentActivity();
        int ActivityCount { get; }

        void Unregister();

        void Register();
    }
}